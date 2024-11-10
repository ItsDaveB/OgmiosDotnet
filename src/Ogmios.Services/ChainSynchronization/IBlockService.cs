using static Ogmios.Services.ChainSynchronization.BlockService;

namespace Ogmios.Services.ChainSynchronization;

public interface IBlockService
{
    Task GetNextBlockAsync(Domain.InteractionContext context, MirrorOptions? options = null);

    Task HandleNextBlockAsync(string response, IChainSynchronizationMessageHandlers messageHandlers);
}
