using System.Buffers;
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
            byte[] rented = ArrayPool<byte>.Shared.Rent(BufferSize);
            var length = 0;

            try
            {
                var scratch = ArrayPool<byte>.Shared.Rent(BufferSize);

                try
                {
                    while (true)
                    {
                        if (length == rented.Length)
                        {
                            var larger = ArrayPool<byte>.Shared.Rent(rented.Length * 2);
                            Buffer.BlockCopy(rented, 0, larger, 0, length);
                            ArrayPool<byte>.Shared.Return(rented);
                            rented = larger;
                        }

                        var available = rented.Length - length;
                        var toCopy = Math.Min(available, scratch.Length);
                        var result = await clientWebSocket.ReceiveAsync(new ArraySegment<byte>(scratch, 0, toCopy), receiveToken).ConfigureAwait(false);

                        if (result.MessageType == WebSocketMessageType.Close)
                        {
                            await clientWebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None).ConfigureAwait(false);
                            throw new WebSocketException("Connection closed by the remote host.");
                        }

                        Buffer.BlockCopy(scratch, 0, rented, length, result.Count);
                        length += result.Count;

                        if (result.EndOfMessage)
                        {
                            break;
                        }
                    }
                }
                finally
                {
                    ArrayPool<byte>.Shared.Return(scratch);
                }

                var exact = new byte[length];
                Buffer.BlockCopy(rented, 0, exact, 0, length);
                return exact;
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(rented);
            }
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

    public Task<byte[]> SendAndWaitForResponseBytesAsync(ReadOnlyMemory<byte> message, IClientWebSocket clientWebSocket, int timeoutMilliseconds = WebSocketTimeouts.Default, CancellationToken cancellationToken = default)
    {
        try
        {
            return SendAndWaitForResponseBytesCoreAsync(message, clientWebSocket, timeoutMilliseconds, cancellationToken);
        }
        catch (WebSocketException)
        {
            throw;
        }
    }

    public async Task<byte[]> SendAndWaitForResponseBytesAsync(string message, IClientWebSocket clientWebSocket, int timeoutMilliseconds = WebSocketTimeouts.Default, CancellationToken cancellationToken = default)
    {
        try
        {
            await SendMessageAsync(message, clientWebSocket, cancellationToken).ConfigureAwait(false);
            return await ReceiveMessageBytesAsync(clientWebSocket, timeoutMilliseconds, cancellationToken).ConfigureAwait(false);
        }
        catch (WebSocketException)
        {
            throw;
        }
    }

    private async Task<byte[]> SendAndWaitForResponseBytesCoreAsync(ReadOnlyMemory<byte> message, IClientWebSocket clientWebSocket, int timeoutMilliseconds, CancellationToken cancellationToken)
    {
        await SendMessageAsync(message, clientWebSocket, cancellationToken).ConfigureAwait(false);
        return await ReceiveMessageBytesAsync(clientWebSocket, timeoutMilliseconds, cancellationToken).ConfigureAwait(false);
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
