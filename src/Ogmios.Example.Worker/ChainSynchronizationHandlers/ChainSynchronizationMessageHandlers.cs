using Generated;
using Ogmios.Services.ChainSynchronization;
namespace ChainSynchronizationWorker.ChainSynchronizationHandlers;

public class ChainSynchronizationMessageHandlers : IChainSynchronizationMessageHandlers
{
    public async Task RollBackwardHandler(Generated.Ogmios.PointOrOrigin point, Generated.Ogmios.TipOrOrigin tip)
    {
        Console.WriteLine("Roll Backward Custom Handler");
        await Task.CompletedTask;
    }

    public async Task RollForwardHandler(Block block, string blockType, Generated.Tip tip)
    {
        switch (blockType)
        {
            case "praos":
                Console.WriteLine("Handling BlockPraos");
                break;
            case "bft":
                Console.WriteLine("Handling BlockBft");
                break;
            case "ebb":
                break;
            default:
                Console.WriteLine("Unknown block type");
                break;
        }

        Console.WriteLine("Roll Forward Custom Handler");
        await Task.CompletedTask;
    }
}