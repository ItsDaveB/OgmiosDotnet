using Ogmios.Services.ChainSynchronization;

namespace Ogmios.Domain;

public class InteractionContext
{
    public string ConnectionName = string.Empty;
    public required StartingPointConfiguration StartingPoint { get; set; }
    public required Connection Connection { get; set; }
    public required IClientWebSocket Socket { get; set; }
}
