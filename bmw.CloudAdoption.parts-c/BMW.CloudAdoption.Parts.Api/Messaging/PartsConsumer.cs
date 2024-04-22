using BMW.CloudAdoption.Parts.Api.Messaging.Kafka;

namespace BMW.CloudAdoption.Parts.Api.Messaging;

public class PartsConsumer : KafkaConsumer<string, string>
{
    private readonly IServiceProvider _serviceProvider;
    
    public PartsConsumer(IServiceProvider serviceProvider,
        IConfiguration configuration, ILogger<PartsConsumer> logger) 
        : base(configuration, logger)
    {
        _serviceProvider = serviceProvider;
    }
    
    protected override string GetTopic()
    {
        return _configuration.GetSection("KafkaTopics")
            .GetValue<string>("Parts") ?? string.Empty;
    }

    protected override async Task ProcessConsumeResultAsync(ConsumeResult<string, string?> consumeResult)
    {
        try
        {
            using var scope = _serviceProvider.CreateScope();
            var partsRepository = scope.ServiceProvider.GetRequiredService<IPartsRepository>();

            if (string.IsNullOrEmpty(consumeResult.Message.Value))
                await partsRepository.DeleteAsync(consumeResult.Message.Key);

            var partRequest = JsonConvert.DeserializeObject<PartRequest>(consumeResult.Message.Value ?? string.Empty,
                AppConstants.JsonSerializerSettings);
            if (partRequest is not null)
                await partsRepository.AddOrUpdateAsync(partRequest);
        }
        catch (Exception e)
        {
            // Handle Exception
            _logger.LogWarning(e, "Could not process PartRequest Message {MessageKey}", consumeResult.Message.Key);
        }
    }
}