using BMW.CloudAdoption.Parts.PartsLoader;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration(app =>
    {
        //app.SetBasePath(Directory.GetCurrentDirectory());
        app.AddJsonFile("appsettings.json");
    })
    .ConfigureServices(services =>
    {
        services.AddSingleton<PartsProducer>();
        services.AddSingleton<PartsLoaderService>();
        services.AddLogging(config =>
        {
            config.AddConsole();
        });
    })
    .Build();
        
host.Services.CreateScope().ServiceProvider
    .GetRequiredService<PartsLoaderService>()
    .Run();

try
{
    host.Run();
}
catch (OperationCanceledException)
{
    Console.WriteLine("Existing App");
}

