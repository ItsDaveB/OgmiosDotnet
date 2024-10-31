using Ogmios.Domain.Configuration;
using Ogmios.Services.InteractionContext;

namespace Ogmios.Domain.ChainSynchronization;

public interface IChainSynchronizationClientService
{
    Task ResumeListeningAsync(InteractionContext interactionContext, CancellationToken cancellationToken);
    Task<List<StartingPointConfiguration>> ResumeAsync(List<InteractionContext> interactionContexts, int inFlight = 100, CancellationToken cancellationToken = default);
    Task ShutdownAsync(InteractionContext interactionContext);
    Task<Generated.Ogmios.TipOrOrigin> CreatePointFromCurrentTipAsync(InteractionContext context, IEnumerable<StartingPointConfiguration> startingPoints);
}
