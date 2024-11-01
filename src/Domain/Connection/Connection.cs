namespace Ogmios.Domain;

public class Connection
{
    public required string Host { get; set; }
    public int Port { get; set; }
    public bool Tls { get; set; }
    public int MaxPayload { get; set; }
    public required Uri AddressHttp { get; set; }
    public required Uri AddressWebSocket { get; set; }
}
