namespace Ogmios.Domain;

public class ConnectionConfig
{
    public string Host { get; set; } = "localhost";
    public int? Port { get; set; }
    public bool Tls { get; set; } = true;
    public int MaxPayload { get; set; } = 128 * 1024 * 1024; // 128 MB
    public int KeepAliveInterval { get; set; } = 30;
}
