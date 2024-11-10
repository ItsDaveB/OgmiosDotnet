using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;

namespace Ogmios.Services.InteractionContext;

public class InteractionContextService(IWebSocketService webSocketService) : IInteractionContextService
{
    public Connection CreateConnectionObject(ConnectionConfig config)
    {
        var host = config.Host.Replace("https://", "").Replace("http://", "")
                              .Replace("wss://", "").Replace("ws://", "");

        var hostAndPort = config.Port.HasValue
            ? $"{host}:{config.Port.Value}"
            : host;

        var schemeHttp = config.Tls ? "https" : "http";
        var schemeWebSocket = config.Tls ? "wss" : "ws";

        return new Connection
        {
            Host = host,
            Port = config.Port ?? 0,
            Tls = config.Tls,
            MaxPayload = config.MaxPayload,
            AddressHttp = new Uri($"{schemeHttp}://{hostAndPort}"),
            AddressWebSocket = new Uri($"{schemeWebSocket}://{hostAndPort}")
        };
    }

    public async Task<Domain.InteractionContext> CreateInteractionContextAsync(string connectionName, StartingPointConfiguration startingPoint, ConnectionConfig connectionConfiguration)
    {
        var connection = CreateConnectionObject(connectionConfiguration);
        // var health = await GetServerHealthAsync(connection);

        // if (health.LastTipUpdate == null)
        // {
        //     throw new Exception("Server not ready.");
        // }

        try
        {

            var socket = await webSocketService.ConnectAsync(connection.AddressWebSocket, connectionConfiguration, CancellationToken.None);

            return new Domain.InteractionContext
            {
                StartingPoint = startingPoint,
                ConnectionName = connectionName,
                Connection = connection,
                Socket = socket
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
}
