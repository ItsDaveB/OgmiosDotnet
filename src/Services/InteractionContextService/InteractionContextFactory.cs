using Microsoft.Extensions.Configuration;
using Ogmios.Domain.Configuration;

namespace Ogmios.Services.InteractionContext;

public class InteractionContextFactory(IConfiguration configuration) : IInteractionContextFactory
{
    private readonly IConfiguration _configuration = configuration;

    public async Task<InteractionContext> CreateInteractionContextAsync(string connectionName, StartingPointConfiguration startingPoint)
    {
        var ogmiosConfiguration = _configuration.GetSection("Ogmios").Get<OgmiosConfiguration>();

        if (string.IsNullOrWhiteSpace(ogmiosConfiguration?.Host))
        {
            throw new ArgumentException("OgmiosHost configuration is missing or empty.");
        }

        var config = new ConnectionConfig { Host = ogmiosConfiguration.Host, Port = ogmiosConfiguration.Port };

        var service = new InteractionContextService();

        return await service.CreateInteractionContextAsync(connectionName, startingPoint,
            err =>
            {
                Console.Error.WriteLine(err);
                return Task.CompletedTask;
            },
            (status, reason) =>
            {
                Console.WriteLine("Connection closed.");
                return Task.CompletedTask;
            },
            config
        );
    }
}
