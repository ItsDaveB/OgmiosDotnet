using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization;

public interface IChainSynchronizationClientService
{
    Task ResumeListeningAsync(Domain.InteractionContext interactionContext, CancellationToken cancellationToken);
    Task<List<StartingPointConfiguration>> ResumeAsync(List<Domain.InteractionContext> interactionContexts, int inFlight = 100, CancellationToken cancellationToken = default);
    Task ShutdownAsync(Domain.InteractionContext interactionContext);
    Task<Generated.Ogmios.TipOrOrigin> CreatePointFromCurrentTipAsync(Domain.InteractionContext context, IEnumerable<StartingPointConfiguration> startingPoints);
}
