using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization;

public interface IWebSocketService
{
    Task<IClientWebSocket> ConnectAsync(Uri addressWebSocket, ConnectionConfig connectionConfig, CancellationToken cancellationToken = default);
    Task SendMessageAsync(string message, IClientWebSocket clientWebSocket, CancellationToken cancellationToken = default);
    Task<string> ReceiveMessageAsync(IClientWebSocket clientWebSocket, CancellationToken cancellationToken = default);
    Task<string> SendAndWaitForResponseAsync(string message, IClientWebSocket clientWebSocket, int timeoutMilliseconds = 5000, CancellationToken cancellationToken = default);
    Task CloseAsync(IClientWebSocket clientWebSocket);
}