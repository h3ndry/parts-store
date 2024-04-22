using System.Text;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace BMW.CloudAdoption.Parts.PartsLoader;

public class PartsProducer : IDisposable
{
    private readonly ILogger _logger;
    private readonly IProducer<string, string> _producer;
    
    private readonly string _topic;
    
    public PartsProducer(IConfiguration configuration, ILogger<PartsProducer> logger)
    {
        _logger = logger;

        var config = new ProducerConfig();
        configuration.GetSection("Kafka").Bind(config);
        _producer = new ProducerBuilder<string, string>(config)
            .SetErrorHandler((_, error) => _logger.LogError("{Message}", error.Reason))
            .SetLogHandler((_, msg) => _logger.Log(ToLogLevel(msg.Level), "{Message}", msg.Message))
            .Build();

        _topic = configuration.GetSection("KafkaTopics")
            .GetValue<string>("Parts") ?? string.Empty;
        
        if (string.IsNullOrEmpty(_topic))
            throw new ArgumentException("Producer Topic Required", nameof(_topic));
    }

    public void Produce(string partNumber, PartRequest? part)
    {
        var json = part is null 
            ? string.Empty 
            : JsonConvert.SerializeObject(part, JsonSerializerSettings);

        var headers = new Headers
        {
            new Header("MessageType", Encoding.UTF8.GetBytes(nameof(PartRequest)))
        };
        
        Produce(partNumber, json, headers);
    }
    
    public void Produce(string key, string value = "", Headers? headers = null)
    {
        _producer.Produce(_topic, new Message<string, string> { Key = key, Value = value, Headers = headers}, DeliveryHandler);  
    }

    private void DeliveryHandler(DeliveryReport<string, string> report)
    {
        _logger.LogDebug("Delivery report for {Key}. Status: {Status}", report.Key, report.Status);
    }

    public void Dispose()
    {
        _producer.Flush(TimeSpan.FromSeconds(5));
        _producer.Dispose();  
    } 
    
    private static LogLevel ToLogLevel(SyslogLevel logLevel)
    {
        return logLevel switch  
        {  
            SyslogLevel.Critical => LogLevel.Critical,  
            SyslogLevel.Emergency or SyslogLevel.Alert or SyslogLevel.Error => LogLevel.Error,  
            SyslogLevel.Warning => LogLevel.Warning,
            SyslogLevel.Info or SyslogLevel.Notice  => LogLevel.Information,  
            SyslogLevel.Debug => LogLevel.Debug,  
            _ => LogLevel.Trace,
        };
    }
    
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        Converters = { new StringEnumConverter() },
        ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
}