using Generated;

namespace Ogmios.Services.ChainSynchronization;

/// <summary>
/// Ordered block event dispatched to <see cref="IChainSynchronizationMessageHandlers"/>.
/// </summary>
public abstract class ChainSyncBlockWork;

public sealed class ChainSyncRollForwardWork(Block block, string blockType, Tip tip) : ChainSyncBlockWork
{
    public Block Block { get; } = block;

    public string BlockType { get; } = blockType;

    public Tip Tip { get; } = tip;
}

public sealed class ChainSyncRollBackwardWork(Generated.Ogmios.PointOrOrigin point, Generated.Ogmios.TipOrOrigin tip) : ChainSyncBlockWork
{
    public Generated.Ogmios.PointOrOrigin Point { get; } = point;

    public Generated.Ogmios.TipOrOrigin Tip { get; } = tip;
}
