using Generated;

namespace Ogmios.Services.ChainSynchronization;

public interface IChainSynchronizationMessageHandlers
{
    Task RollBackwardHandler(Generated.Ogmios.PointOrOrigin point, Generated.Ogmios.TipOrOrigin tip);

    Task RollForwardHandler(Block block, string blockType, Tip tip);
}