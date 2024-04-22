using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BMW.CloudAdoption.Parts.PartsLoader;

internal class PartsLoaderService
{
    private readonly PartsProducer _producer;
    private readonly IHostApplicationLifetime _lifeTime;
    private readonly ILogger<PartsLoaderService> _logger;

    public PartsLoaderService(PartsProducer producer, IHostApplicationLifetime lifeTime, ILogger<PartsLoaderService> logger)
    {
        _producer = producer;
        _lifeTime = lifeTime;
        _logger = logger;
    }

    public void Run()
    {
        Console.WriteLine("Enter Parts seed Count (Q to exit)");
        var input = Console.ReadLine();
        while (input != null && !input.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
        {
            try
            {
                if (int.TryParse(input, out var count))
                {
                    var parts = PartRequestFactory.GeneratePartRequests(count);
                    foreach (var part in parts)
                    {
                        _producer.Produce(part.PartNumber, part);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            finally
            {
                Console.WriteLine("Enter Parts seed Count (Q to exit)");
                input = Console.ReadLine();
            }
        }
        _lifeTime.StopApplication();
    }
}