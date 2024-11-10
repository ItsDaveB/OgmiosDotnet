using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;

namespace Ogmios.Services.InteractionContext;

public class InteractionContextFactory(IWebSocketService webSocketService) : IInteractionContextFactory
{
    public Task<Domain.InteractionContext> CreateInteractionContextAsync(string connectionName, StartingPointConfiguration startingPoint, OgmiosConfiguration ogmiosConfiguration)
    {
        if (string.IsNullOrWhiteSpace(ogmiosConfiguration?.Host))
        {
            throw new ArgumentException("OgmiosHost configuration is missing or empty.");
        }

        var config = new ConnectionConfig { Host = ogmiosConfiguration.Host, Port = ogmiosConfiguration.Port };

        var service = new InteractionContextService(webSocketService);

        return service.CreateInteractionContextAsync(connectionName, startingPoint, config);
    }
}
