using Ogmios.Domain;

namespace Ogmios.Example.Worker.Examples;

public interface IExample
{
    string Name { get; }
    Task ExecuteAsync(InteractionContext context, OgmiosConfiguration ogmiosConfiguration, CancellationToken cancellationToken);
}
