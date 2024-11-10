using Ogmios.Domain;

namespace Ogmios.Services.InteractionContext;

public interface IInteractionContextService
{
    Connection CreateConnectionObject(ConnectionConfig config);
    Task<Domain.InteractionContext> CreateInteractionContextAsync(string connectionName, StartingPointConfiguration startingPoint, ConnectionConfig config);
}
