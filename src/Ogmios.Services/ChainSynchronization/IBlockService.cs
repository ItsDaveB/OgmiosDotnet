using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization;

public interface IBlockService
{
    Task GetNextBlockAsync(Domain.InteractionContext context, MirrorOptions? options = null);

    Task HandleNextBlockAsync(string response, IChainSynchronizationMessageHandlers messageHandlers);

    Task HandleNextBlockAsync(ReadOnlyMemory<byte> utf8Response, IChainSynchronizationMessageHandlers messageHandlers);

    ValueTask EnqueueBlockHandlersAsync(ReadOnlyMemory<byte> utf8Response, System.Threading.Channels.ChannelWriter<ChainSyncBlockWork> writer, CancellationToken cancellationToken = default);
}
