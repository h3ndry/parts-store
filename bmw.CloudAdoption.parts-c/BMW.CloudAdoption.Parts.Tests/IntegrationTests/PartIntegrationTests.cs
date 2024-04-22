using System.Net.Http.Json;
using BMW.CloudAdoption.Parts.Api.Core;
using BMW.CloudAdoption.Parts.Api.Models;
using BMW.CloudAdoption.Parts.Tests.Helpers;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BMW.CloudAdoption.Parts.Tests.IntegrationTests;

[TestFixture]
public class PartIntegrationTests
{
    [Test]
    public async Task Confirm_Web_API_Is_Healthy()
    {
        var response = await IntegrationSetUp.TestClient.GetAsync("/healthz");
        Assert.That(response.IsSuccessStatusCode, Is.EqualTo(true));
    }
    
    [Test]
    public async Task Confirm_Part_Created_Successfully()
    {
        var partRequest = PartRequestFactory.GeneratePartRequests(1)[0];
        var postResponse = await IntegrationSetUp.TestClient.PostAsJsonAsync("api/part", partRequest);
        Assert.That(postResponse.IsSuccessStatusCode, Is.EqualTo(true));
        
        var response = await IntegrationSetUp.TestClient.GetUntilSuccessAsync(
            $"api/part/{partRequest.PartNumber}", TimeSpan.FromSeconds(10));
        Assert.That(response.IsSuccessStatusCode, Is.EqualTo(true));
        
        var partResponse = JsonConvert.DeserializeObject<PartRequest>(
            await response.Content.ReadAsStringAsync(), AppConstants.JsonSerializerSettings);

        Assert.NotNull(partResponse);
        Assert.That(partResponse!.PartNumber, Is.EqualTo(partRequest.PartNumber));
    }
}