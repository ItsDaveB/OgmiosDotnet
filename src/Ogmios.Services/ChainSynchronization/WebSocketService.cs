using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Extensions.Logging;
using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization;

public class WebSocketService : IWebSocketService
{
    private const int BufferSize = 65536;
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

        if (ClientWebSocketWrapper.HostnameRequiresSslBypass(hostname) &&
            connectionConfig.SslValidation != SslCertificateValidation.Strict)
        {
            _logger?.LogDebug(
                "SSL certificate validation bypassed for hostname '{Hostname}' (contains non-standard characters)",
                hostname);
        }

        socket.Options.KeepAliveInterval = TimeSpan.FromSeconds(connectionConfig.KeepAliveInterval);
        socket.Options.SetBuffer(connectionConfig.MaxPayload, connectionConfig.MaxPayload);

        await socket.ConnectAsync(addressWebSocket, cancellationToken);

        return socket;
    }

    public Task SendMessageAsync(string message, IClientWebSocket clientWebSocket, CancellationToken cancellationToken = default)
    {
        var buffer = Encoding.UTF8.GetBytes(message);
        return SendMessageAsync(buffer, clientWebSocket, cancellationToken);
    }

    public Task SendMessageAsync(ReadOnlyMemory<byte> message, IClientWebSocket clientWebSocket, CancellationToken cancellationToken = default)
    {
        ArraySegment<byte> segment;
        if (MemoryMarshal.TryGetArray(message, out var arraySegment))
        {
            segment = new ArraySegment<byte>(arraySegment.Array!, arraySegment.Offset, arraySegment.Count);
        }
        else
        {
            segment = new ArraySegment<byte>(message.ToArray());
        }

        return clientWebSocket.SendAsync(segment, WebSocketMessageType.Text, true, cancellationToken);
    }

    public async Task<string> ReceiveMessageAsync(IClientWebSocket clientWebSocket, CancellationToken cancellationToken = default)
    {
        var bytes = await ReceiveMessageBytesAsync(clientWebSocket, WebSocketTimeouts.Default, cancellationToken);
        return Encoding.UTF8.GetString(bytes);
    }

    public async Task<byte[]> ReceiveMessageBytesAsync(IClientWebSocket clientWebSocket, int timeoutMilliseconds = WebSocketTimeouts.Default, CancellationToken cancellationToken = default)
    {
        var timeoutTokenSource = CreateTimeoutTokenSource(timeoutMilliseconds, cancellationToken, out var receiveToken);

        try
        {
            using var memoryStream = new MemoryStream();
            var buffer = new byte[BufferSize];

            while (true)
            {
                var result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(buffer), receiveToken);

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
                    throw new WebSocketException("Connection closed by the remote host.");
                }

                memoryStream.Write(buffer, 0, result.Count);

                if (result.EndOfMessage)
                {
                    break;
                }
            }

            return memoryStream.ToArray();
        }
        finally
        {
            timeoutTokenSource?.Dispose();
        }
    }

    public async Task<string> SendAndWaitForResponseAsync(string message, IClientWebSocket clientWebSocket, int timeoutMilliseconds = WebSocketTimeouts.Default, CancellationToken cancellationToken = default)
    {
        var bytes = await SendAndWaitForResponseBytesAsync(message, clientWebSocket, timeoutMilliseconds, cancellationToken);
        return Encoding.UTF8.GetString(bytes);
    }

    public async Task<byte[]> SendAndWaitForResponseBytesAsync(string message, IClientWebSocket clientWebSocket, int timeoutMilliseconds = WebSocketTimeouts.Default, CancellationToken cancellationToken = default)
    {
        try
        {
            await SendMessageAsync(message, clientWebSocket, cancellationToken);
            return await ReceiveMessageBytesAsync(clientWebSocket, timeoutMilliseconds, cancellationToken);
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

    private static CancellationTokenSource? CreateTimeoutTokenSource(
        int timeoutMilliseconds,
        CancellationToken cancellationToken,
        out CancellationToken effectiveToken)
    {
        var resolvedTimeout = WebSocketTimeouts.ResolveTimeoutMilliseconds(timeoutMilliseconds);

        if (resolvedTimeout == WebSocketTimeouts.Infinite)
        {
            effectiveToken = cancellationToken;
            return null;
        }

        var linked = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        linked.CancelAfter(TimeSpan.FromMilliseconds(resolvedTimeout));
        effectiveToken = linked.Token;
        return linked;
    }
}
