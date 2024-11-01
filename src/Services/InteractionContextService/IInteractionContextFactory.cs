
using Ogmios.Domain.Configuration;

namespace Ogmios.Services.InteractionContext;

public interface IInteractionContextFactory
{
    Task<InteractionContext> CreateInteractionContextAsync(string connectionName, StartingPointConfiguration startingPoint);
}
