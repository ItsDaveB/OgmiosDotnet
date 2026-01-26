using System.Net.WebSockets;

namespace Ogmios.Domain;


public class ClientWebSocketWrapper : IClientWebSocket
{
    private readonly ClientWebSocket _clientWebSocket;
    private readonly bool _bypassSslValidation;

    public ClientWebSocketWrapper() : this(bypassSslValidation: false)
    {
    }

    public ClientWebSocketWrapper(bool bypassSslValidation)
    {
        _clientWebSocket = new ClientWebSocket();
        _bypassSslValidation = bypassSslValidation;

        if (_bypassSslValidation)
        {
            ConfigureSslBypass();
        }
    }

    public static ClientWebSocketWrapper Create(string hostname, SslCertificateValidation sslValidation)
    {
        var shouldBypass = sslValidation switch
        {
            SslCertificateValidation.Bypass => true,
            SslCertificateValidation.Strict => false,
            SslCertificateValidation.Auto => HostnameRequiresSslBypass(hostname),
            _ => HostnameRequiresSslBypass(hostname)
        };

        return new ClientWebSocketWrapper(shouldBypass);
    }

    public static bool HostnameRequiresSslBypass(string hostname)
    {
        if (string.IsNullOrEmpty(hostname))
            return false;

        var cleanHostname = hostname
            .Replace("https://", "")
            .Replace("http://", "")
            .Replace("wss://", "")
            .Replace("ws://", "");

        var colonIndex = cleanHostname.IndexOf(':');
        if (colonIndex > 0)
            cleanHostname = cleanHostname.Substring(0, colonIndex);

        return cleanHostname.Contains('_');
    }

    private void ConfigureSslBypass()
    {
        _clientWebSocket.Options.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
        {
            return true;
        };
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
