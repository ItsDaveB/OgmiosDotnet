using System.Text.Json;
using Ogmios.Domain.Exceptions;

namespace Ogmios.Services.ServerHealth;

public class ServerHealthService(HttpClient httpClient) : IServerHealthService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<Domain.Server.ServerHealth> GetServerHealthAsync(Uri serverAddress)
    {
        if (serverAddress is null)
        {
            throw new ArgumentNullException(nameof(serverAddress));
        }

        if (!Uri.IsWellFormedUriString(serverAddress.ToString(), UriKind.Absolute))
            throw new ArgumentException("The provided server address is not a valid absolute URI.", nameof(serverAddress));

        Uri healthUri;
        try
        {
            healthUri = new Uri(serverAddress, "health");
        }
        catch (UriFormatException ex)
        {
            throw new ArgumentException("The provided URI is not in a valid format.", nameof(serverAddress), ex);
        }

        HttpResponseMessage response;
        try
        {
            response = await _httpClient.GetAsync(healthUri);
        }
        catch (HttpRequestException ex)
        {
            throw new Exception("An error occurred while making the HTTP request.", ex);
        }

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Failed to fetch server health. Status: {response.StatusCode}, Reason: {response.ReasonPhrase}.");

        var responseBody = await response.Content.ReadAsStringAsync();
        var serverHealth = JsonSerializer.Deserialize<Domain.Server.ServerHealth>(responseBody, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }) ?? throw new Exception("Failed to deserialize server health response.");

        if (string.IsNullOrWhiteSpace(serverHealth.LastTipUpdate))
        {
            throw new ServerNotReadyException(serverHealth);
        }

        return serverHealth;
    }
}