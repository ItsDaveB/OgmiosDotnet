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

        var sslValidation = ParseSslValidation(ogmiosConfiguration.SslValidation);

        var config = new ConnectionConfig
        {
            Host = ogmiosConfiguration.Host,
            Port = ogmiosConfiguration.Port,
            Tls = ogmiosConfiguration.Tls,
            SslValidation = sslValidation
        };

        var service = new InteractionContextService(webSocketService, serverHealthService);

        return service.CreateInteractionContextAsync(connectionName, startingPoint, config);
    }

    private static SslCertificateValidation ParseSslValidation(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return SslCertificateValidation.Auto;

        return value.ToLowerInvariant() switch
        {
            "strict" => SslCertificateValidation.Strict,
            "bypass" => SslCertificateValidation.Bypass,
            "auto" => SslCertificateValidation.Auto,
            _ => SslCertificateValidation.Auto
        };
    }
}
