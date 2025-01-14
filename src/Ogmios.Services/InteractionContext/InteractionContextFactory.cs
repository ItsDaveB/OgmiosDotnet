using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.ServerHealth;

namespace Ogmios.Services.InteractionContext;

public class InteractionContextFactory(IWebSocketService webSocketService, IServerHealthService serverHealthService) : IInteractionContextFactory
{
    public Task<Domain.InteractionContext> CreateInteractionContextAsync(string connectionName, StartingPointConfiguration startingPoint, OgmiosConfiguration ogmiosConfiguration)
    {
        if (string.IsNullOrWhiteSpace(ogmiosConfiguration?.Host))
        {
            throw new ArgumentException("Ogmios Host configuration is missing or empty.");
        }

        var config = new ConnectionConfig { Host = ogmiosConfiguration.Host, Port = ogmiosConfiguration.Port, Tls = ogmiosConfiguration.Tls };
        var service = new InteractionContextService(webSocketService, serverHealthService);

        return service.CreateInteractionContextAsync(connectionName, startingPoint, config);
    }
}
