using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace BMW.CloudAdoption.Parts.Tests;

[SetUpFixture]
public class IntegrationSetUp
{
    public static HttpClient TestClient = new();
    public static TestServer Server = default!;
    private WebApplicationFactory<Program> _appFactory = default!;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _appFactory = new WebApplicationFactory<Program>().WithWebHostBuilder(
            builder =>
            {
                builder.ConfigureAppConfiguration((_, config) =>
                {
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("appsettings.Integration.json");
                    config.AddEnvironmentVariables();
                }).ConfigureTestServices(services =>
                {
                    // custom service registrations
                }).UseEnvironment("Integration");
            });
        TestClient = _appFactory.CreateClient();
        Server = _appFactory.Server;
    }
    
    [OneTimeTearDown]
    public void OneTimeTeardown()
    {
        TestClient.Dispose();
        _appFactory.Dispose();
    }
}