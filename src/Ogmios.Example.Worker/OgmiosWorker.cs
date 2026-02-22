using Ogmios.Domain;
using Ogmios.Example.Worker.Examples;
using Ogmios.Services.InteractionContext;

namespace Ogmios.Example.Worker;

/// <summary>
/// Background worker that orchestrates Ogmios example demonstrations.
/// Configure which examples to run by modifying the ExecuteAsync method.
/// </summary>
public class OgmiosWorker(
    ILogger<OgmiosWorker> logger,
    IInteractionContextFactory contextFactory,
    IConfiguration configuration,
    LedgerStateQueriesExample ledgerStateQueriesExample,
    ChainSynchronizationExample chainSynchronizationExample,
    TransactionEvaluationExample transactionEvaluationExample,
    TransactionSubmissionExample transactionSubmissionExample,
    MemPoolMonitoringExample memPoolMonitoringExample) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Worker starting at: {time}", DateTimeOffset.Now);

        try
        {
            var ogmiosConfiguration = configuration.GetSection("Ogmios").Get<OgmiosConfiguration>()
                ?? throw new InvalidOperationException("Ogmios configuration not found.");

            var startingPoints = configuration.GetSection("StartingPoints").Get<List<StartingPointConfiguration>>()
                ?? [];

            // Create interaction context
            var context = await CreateContextAsync(startingPoints.FirstOrDefault(), ogmiosConfiguration);

            // ================================================================================
            // Chain Synchronization Demo
            // ================================================================================

            Console.WriteLine();
            Console.WriteLine("\u001b[35m╔══════════════════════════════════════════════════════════════════════════════╗\u001b[0m");
            Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
            Console.WriteLine("\u001b[35m║              🔗 OgmiosDotnet - Chain Synchronization Demo 🔗                 ║\u001b[0m");
            Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
            Console.WriteLine("\u001b[35m╚══════════════════════════════════════════════════════════════════════════════╝\u001b[0m");
            Console.WriteLine();

            await chainSynchronizationExample.ExecuteAsync(context, ogmiosConfiguration, stoppingToken);

            Console.WriteLine();
            Console.WriteLine("\u001b[35m╔══════════════════════════════════════════════════════════════════════════════╗\u001b[0m");
            Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
            Console.WriteLine("\u001b[35m║  ✅ Chain Synchronization Demo Complete!                                      ║\u001b[0m");
            Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
            Console.WriteLine("\u001b[35m╚══════════════════════════════════════════════════════════════════════════════╝\u001b[0m");
            Console.WriteLine();
        }
        catch (OperationCanceledException ex)
        {
            logger.LogInformation(ex, "Worker cancellation requested.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred while running the worker.");
        }
        finally
        {
            logger.LogInformation("Worker stopping at: {time}.", DateTimeOffset.Now);
        }
    }

    private async Task<InteractionContext> CreateContextAsync(StartingPointConfiguration? startingPoint, OgmiosConfiguration ogmiosConfiguration)
    {
        var connectionName = "ogmios_example";
        return await contextFactory.CreateInteractionContextAsync(connectionName, startingPoint, ogmiosConfiguration);
    }
}

