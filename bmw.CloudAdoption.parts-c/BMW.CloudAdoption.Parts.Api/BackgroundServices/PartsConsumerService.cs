namespace BMW.CloudAdoption.Parts.Api.BackgroundServices;

public class PartsConsumerService : BackgroundService
{
    private readonly PartsConsumer _consumer;

    public PartsConsumerService(PartsConsumer consumer)
    {
        _consumer = consumer;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Task.Run(async () => await _consumer.ConsumeAsync(stoppingToken), stoppingToken);
        return Task.CompletedTask;
    }
}