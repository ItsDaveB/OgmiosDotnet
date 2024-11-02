using System.Net.WebSockets;

namespace Ogmios.Domain;

public class InteractionContext
{
    public string ConnectionName = string.Empty;
    public required StartingPointConfiguration StartingPoint { get; set; }
    public required Connection Connection { get; set; }
    public required ClientWebSocket Socket { get; set; }
}
