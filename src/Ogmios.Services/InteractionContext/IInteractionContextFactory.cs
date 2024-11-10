
using Ogmios.Domain;

namespace Ogmios.Services.InteractionContext;

public interface IInteractionContextFactory
{
    Task<Domain.InteractionContext> CreateInteractionContextAsync(string connectionName, StartingPointConfiguration startingPoint, OgmiosConfiguration ogmiosConfiguration);
}
