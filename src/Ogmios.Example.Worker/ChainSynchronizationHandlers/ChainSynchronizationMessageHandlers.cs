using Generated;
using Ogmios.Services.ChainSynchronization;

namespace ChainSynchronizationWorker.ChainSynchronizationHandlers;

public class ChainSynchronizationMessageHandlers : IChainSynchronizationMessageHandlers
{
    public Task RollBackwardHandler(Generated.Ogmios.PointOrOrigin point, Generated.Ogmios.TipOrOrigin tip)
    {
        return Task.CompletedTask;
    }

    public Task RollForwardHandler(Block block, string blockType, Tip tip)
    {
        Console.WriteLine($"Handing block type: {blockType}.");
        return Task.CompletedTask;
    }
}