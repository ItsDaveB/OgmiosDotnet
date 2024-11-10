using System.Net.WebSockets;

namespace Ogmios.Services.ChainSynchronization;

public interface IClientWebSocket
{
    WebSocketState State { get; }
    Task ConnectAsync(Uri uri, CancellationToken cancellationToken);

    Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken);

    Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken);
    Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken);
}

public class ClientWebSocketWrapper : IClientWebSocket
{
    private readonly ClientWebSocket _clientWebSocket;

    public ClientWebSocketWrapper()
    {
        _clientWebSocket = new ClientWebSocket();
    }

    public WebSocketState State => _clientWebSocket.State;

    public ClientWebSocketOptions Options => _clientWebSocket.Options;

    public Task ConnectAsync(Uri uri, CancellationToken cancellationToken) =>
        _clientWebSocket.ConnectAsync(uri, cancellationToken);

    public async Task SendAsync(ArraySegment<byte> buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken) => await _clientWebSocket.SendAsync(buffer, messageType, endOfMessage, cancellationToken);

    public Task CloseAsync(WebSocketCloseStatus closeStatus, string statusDescription, CancellationToken cancellationToken) =>
        _clientWebSocket.CloseAsync(closeStatus, statusDescription, cancellationToken);

    public Task<WebSocketReceiveResult> ReceiveAsync(ArraySegment<byte> buffer, CancellationToken cancellationToken) =>
        _clientWebSocket.ReceiveAsync(buffer, cancellationToken);
}
