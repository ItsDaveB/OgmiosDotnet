using Generated;

namespace Ogmios.Services.ChainSynchronization;

/// <summary>
/// Ordered block event dispatched to <see cref="IChainSynchronizationMessageHandlers"/>.
/// Retains the pooled WebSocket response buffer until handler execution completes.
/// </summary>
public abstract class ChainSyncBlockWork(PooledWebSocketMessage responseBuffer)
{
    public PooledWebSocketMessage ResponseBuffer { get; } = responseBuffer;
}

public sealed class ChainSyncRollForwardWork(PooledWebSocketMessage responseBuffer, Block block, string blockType, Tip tip) : ChainSyncBlockWork(responseBuffer)
{
    public Block Block { get; } = block;

    public string BlockType { get; } = blockType;

    public Tip Tip { get; } = tip;
}

public sealed class ChainSyncRollBackwardWork(PooledWebSocketMessage responseBuffer, Generated.Ogmios.PointOrOrigin point, Generated.Ogmios.TipOrOrigin tip) : ChainSyncBlockWork(responseBuffer)
{
    public Generated.Ogmios.PointOrOrigin Point { get; } = point;

    public Generated.Ogmios.TipOrOrigin Tip { get; } = tip;
}
