namespace BMW.CloudAdoption.Parts.Tests.Helpers;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> GetUntilSuccessAsync(this HttpClient httpClient, 
        string requestUri, TimeSpan timeout)
    {
        var cts = new CancellationTokenSource(timeout);
        while (!cts.IsCancellationRequested)
        {
            var response = await httpClient.GetAsync(requestUri, cts.Token);
            if (response.IsSuccessStatusCode)
                return response;
            await Task.Delay(TimeSpan.FromMilliseconds(100), cts.Token);
        }

        throw new OperationCanceledException("Failed to get a Success response in allowed time span.");
    }
}