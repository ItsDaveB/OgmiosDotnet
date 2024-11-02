using System.Net.WebSockets;
using Ogmios.Domain;

namespace Ogmios.Services.InteractionContext;

public interface IInteractionContextService
{
    Connection CreateConnectionObject(ConnectionConfig? config = null);

    Task<Domain.InteractionContext> CreateInteractionContextAsync(string connectionName, StartingPointConfiguration startingPoint, Func<Exception, Task> errorHandler, Func<WebSocketCloseStatus, string, Task> closeHandler, ConnectionConfig? config = null);
}
