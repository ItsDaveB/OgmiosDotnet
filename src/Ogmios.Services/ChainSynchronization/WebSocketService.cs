using System.Net.WebSockets;
using System.Text;
using Microsoft.Extensions.Logging;
using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization;

public class WebSocketService : IWebSocketService
{
    private const int BufferSize = 8192;
    private readonly ILogger<WebSocketService>? _logger;

    public WebSocketService()
    {
    }

    public WebSocketService(ILogger<WebSocketService> logger)
    {
        _logger = logger;
    }

    public async Task<IClientWebSocket> ConnectAsync(Uri addressWebSocket, ConnectionConfig connectionConfig, CancellationToken cancellationToken = default)
    {
        var hostname = addressWebSocket.Host;
        var socket = ClientWebSocketWrapper.Create(hostname, connectionConfig.SslValidation);

        // Log if SSL bypass is being used
        if (ClientWebSocketWrapper.HostnameRequiresSslBypass(hostname) &&
            connectionConfig.SslValidation != SslCertificateValidation.Strict)
        {
            _logger?.LogDebug(
                "SSL certificate validation bypassed for hostname '{Hostname}' (contains non-standard characters)",
                hostname);
        }

        socket.Options.KeepAliveInterval = TimeSpan.FromSeconds(connectionConfig.KeepAliveInterval);
        socket.Options.SetBuffer(connectionConfig.MaxPayload, connectionConfig.MaxPayload);

        try
        {
            await socket.ConnectAsync(addressWebSocket, cancellationToken);
        }
        catch (Exception)
        {
            throw;
        }

        return socket;
    }

    public async Task SendMessageAsync(string message, IClientWebSocket clientWebSocket, CancellationToken cancellationToken = default)
    {
        var buffer = Encoding.UTF8.GetBytes(message);
        var segment = new ArraySegment<byte>(buffer);
        await clientWebSocket.SendAsync(segment, WebSocketMessageType.Text, true, cancellationToken);
    }

    public async Task<string> ReceiveMessageAsync(IClientWebSocket clientWebSocket, CancellationToken cancellationToken = default)
    {
        using var memoryStream = new MemoryStream();
        var buffer = new byte[BufferSize];

        while (true)
        {
            var result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

            if (result.MessageType == WebSocketMessageType.Close)
            {
                await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", cancellationToken);
                throw new WebSocketException("Connection closed by the remote host.");
            }

            memoryStream.Write(buffer, 0, result.Count);

            if (result.EndOfMessage)
            {
                break;
            }
        }

        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }

    public async Task<string> SendAndWaitForResponseAsync(string message, IClientWebSocket clientWebSocket, int timeoutMilliseconds = 5000, CancellationToken cancellationToken = default)
    {
        try
        {
            await SendMessageAsync(message, clientWebSocket, cancellationToken);
            return await ReceiveMessageAsync(clientWebSocket, cancellationToken);
        }
        catch (WebSocketException)
        {
            throw;
        }
    }

    public async Task CloseAsync(IClientWebSocket clientWebSocket, CancellationToken cancellationToken)
    {
        if (clientWebSocket.State == WebSocketState.Open)
        {
            await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Close requested.", cancellationToken);
        }
    }

    public Task CloseAsync(IClientWebSocket clientWebSocket)
    {
        throw new NotImplementedException();
    }
}