using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;

namespace Ogmios.Example.Worker.Examples;

/// <summary>
/// Demonstrates the Chain Synchronization capabilities of Ogmios.
/// Shows how to synchronize with the Cardano blockchain from a specific point.
/// </summary>
public class ChainSynchronizationExample(
    IChainSynchronizationClientService chainSynchronizationClientService) : IExample
{
    public string Name => "Chain Synchronization";

    public async Task ExecuteAsync(InteractionContext context, OgmiosConfiguration ogmiosConfiguration, CancellationToken cancellationToken)
    {
        Console.WriteLine("\u001b[33m--- Chain Synchronization Demonstration ---\u001b[0m");

        Console.WriteLine($"\u001b[36m[ChainSync] Starting chain synchronization...\u001b[0m");
        Console.WriteLine($"\u001b[36m[ChainSync] Max blocks per second: {ogmiosConfiguration.MaxBlocksPerSecond}\u001b[0m");

        var points = await chainSynchronizationClientService.ResumeAsync(
            [context],
            maxBlocksPerSecond: ogmiosConfiguration.MaxBlocksPerSecond,
            inFlight: 100,
            cancellationToken);

        Console.WriteLine($"\u001b[32m[ChainSync] Synchronized to {points?.Count ?? 0} points\u001b[0m");

        Console.WriteLine("\u001b[33m--- Chain Synchronization Demonstration Complete ---\u001b[0m");
    }
}
