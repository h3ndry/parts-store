using System.Text;
using BMW.CloudAdoption.Parts.Api.Messaging.Kafka;

namespace BMW.CloudAdoption.Parts.Api.Messaging;

public class PartsProducer : KafkaProducer<string, string>
{
    public PartsProducer(IConfiguration configuration, ILogger<PartsProducer> logger) 
        : base(configuration, logger) { }

    protected override string GetTopic()
    {
        return _configuration.GetSection("KafkaTopics")
            .GetValue<string>("Parts") ?? string.Empty;
    }
    
    public void Produce(string partNumber, PartRequest? part)
    {
        var json = part is null 
            ? string.Empty 
            : JsonConvert.SerializeObject(part, AppConstants.JsonSerializerSettings);

        var headers = new Headers
        {
            new Header("MessageType", Encoding.UTF8.GetBytes(nameof(PartRequest)))
        };
        
        Produce(partNumber, json, headers);
    }

    protected override void DeliveryHandler(DeliveryReport<string, string?> report)
    {
        _logger.LogInformation("Delivery report for part {PartNumber}. Status: {Status}", report.Key, report.Status);
    }
}