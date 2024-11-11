using System.Text.Json;
using Ogmios.Domain.Exceptions;

namespace Ogmios.Services.ServerHealth;

public class ServerHealthService(HttpClient httpClient) : IServerHealthService
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

    public async Task<Domain.Server.ServerHealth> GetServerHealthAsync(Uri serverAddress)
    {
        if (serverAddress is null)
        {
            throw new ArgumentNullException(nameof(serverAddress));
        }

        var healthUri = BuildHealthUri(serverAddress);

        HttpResponseMessage response;
        try
        {
            response = await _httpClient.GetAsync(healthUri);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            throw new HttpRequestException($"An error occurred while fetching server health from {healthUri}.", ex);
        }

        return await ParseServerHealthResponseAsync(response);
    }

    private static Uri BuildHealthUri(Uri serverAddress)
    {
        if (!Uri.IsWellFormedUriString(serverAddress.ToString(), UriKind.Absolute))
            throw new ArgumentException("The provided server address is not a valid absolute URI.", nameof(serverAddress));

        return new UriBuilder(serverAddress) { Path = "health" }.Uri;
    }

    private async Task<Domain.Server.ServerHealth> ParseServerHealthResponseAsync(HttpResponseMessage response)
    {
        var responseBody = await response.Content.ReadAsStringAsync();

        try
        {
            var serverHealth = JsonSerializer.Deserialize<Domain.Server.ServerHealth>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (serverHealth is null)
                throw new InvalidOperationException("Server health response deserialized to null.");

            if (string.IsNullOrWhiteSpace(serverHealth.LastTipUpdate))
                throw new ServerNotReadyException(serverHealth);

            return serverHealth;
        }
        catch (JsonException ex)
        {
            throw new Exception("Failed to deserialize the server health response.", ex);
        }
    }
}
