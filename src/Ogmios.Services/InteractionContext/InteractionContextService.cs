using System.Net.WebSockets;
using Ogmios.Domain;

namespace Ogmios.Services.InteractionContext;

public class InteractionContextService : IInteractionContextService
{
    public Connection CreateConnectionObject(ConnectionConfig? config = null)
    {
        config ??= new ConnectionConfig();

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

    public async Task<Domain.InteractionContext> CreateInteractionContextAsync(string connectionName, StartingPointConfiguration startingPoint, Func<Exception, Task> errorHandler, Func<WebSocketCloseStatus, string, Task> closeHandler, ConnectionConfig? config = null)
    {
        var connection = CreateConnectionObject(config);
        // var health = await GetServerHealthAsync(connection);

        // if (health.LastTipUpdate == null)
        // {
        //     throw new Exception("Server not ready.");
        // }

        var socket = new ClientWebSocket();
        socket.Options.KeepAliveInterval = TimeSpan.FromSeconds(config?.KeepAliveInterval ?? 60);
        socket.Options.SetBuffer(connection.MaxPayload, connection.MaxPayload);

        try
        {
            await socket.ConnectAsync(connection.AddressWebSocket, CancellationToken.None);
        }
        catch (Exception ex)
        {
            await errorHandler(ex);
            throw;
        }

        return new Domain.InteractionContext
        {
            StartingPoint = startingPoint,
            ConnectionName = connectionName,
            Connection = connection,
            Socket = socket
        };
    }
}
