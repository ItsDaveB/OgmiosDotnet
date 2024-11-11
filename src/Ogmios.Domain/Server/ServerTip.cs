namespace Ogmios.Domain.Server;

public class ServerTip
{
    public string? Block { get; set; }
    public ulong Slot { get; set; }
    public ulong Epoch { get; set; }
}