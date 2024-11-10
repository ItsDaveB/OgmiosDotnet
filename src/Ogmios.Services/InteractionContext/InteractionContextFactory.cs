using Microsoft.Extensions.Configuration;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;

namespace Ogmios.Services.InteractionContext;

public class InteractionContextFactory(IConfiguration configuration, IWebSocketService webSocketService) : IInteractionContextFactory
{
    private readonly IConfiguration _configuration = configuration;

    public Task<Domain.InteractionContext> CreateInteractionContextAsync(string connectionName, StartingPointConfiguration startingPoint)
    {
        var ogmiosConfiguration = _configuration.GetSection("Ogmios").Get<OgmiosConfiguration>();

        if (string.IsNullOrWhiteSpace(ogmiosConfiguration?.Host))
        {
            throw new ArgumentException("OgmiosHost configuration is missing or empty.");
        }

        var config = new ConnectionConfig { Host = ogmiosConfiguration.Host, Port = ogmiosConfiguration.Port };

        var service = new InteractionContextService(webSocketService);

        return service.CreateInteractionContextAsync(connectionName, startingPoint, config);
    }
}
