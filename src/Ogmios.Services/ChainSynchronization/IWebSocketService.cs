using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization;

public interface IWebSocketService
{
    Task<IClientWebSocket> ConnectAsync(Uri addressWebSocket, ConnectionConfig connectionConfig, CancellationToken cancellationToken = default);

    Task SendMessageAsync(string message, IClientWebSocket clientWebSocket, CancellationToken cancellationToken = default);

    Task SendMessageAsync(ReadOnlyMemory<byte> message, IClientWebSocket clientWebSocket, CancellationToken cancellationToken = default);

    Task<string> ReceiveMessageAsync(IClientWebSocket clientWebSocket, CancellationToken cancellationToken = default);

    Task<byte[]> ReceiveMessageBytesAsync(IClientWebSocket clientWebSocket, int timeoutMilliseconds = WebSocketTimeouts.Default, CancellationToken cancellationToken = default);

    Task<string> SendAndWaitForResponseAsync(string message, IClientWebSocket clientWebSocket, int timeoutMilliseconds = WebSocketTimeouts.Default, CancellationToken cancellationToken = default);

    Task<byte[]> SendAndWaitForResponseBytesAsync(string message, IClientWebSocket clientWebSocket, int timeoutMilliseconds = WebSocketTimeouts.Default, CancellationToken cancellationToken = default);

    Task<byte[]> SendAndWaitForResponseBytesAsync(ReadOnlyMemory<byte> message, IClientWebSocket clientWebSocket, int timeoutMilliseconds = WebSocketTimeouts.Default, CancellationToken cancellationToken = default);

    Task CloseAsync(IClientWebSocket clientWebSocket);
}
