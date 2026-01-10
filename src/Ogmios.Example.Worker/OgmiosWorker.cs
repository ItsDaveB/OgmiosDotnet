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
            // FINAL MILESTONE DEMO - Transaction Services + Ledger State Queries
            // ================================================================================
            // This demo showcases the complete OgmiosDotnet functionality:
            // 1. Transaction Evaluation - Calculate execution units for smart contract tx
            // 2. Transaction Submission - Submit signed transaction to Cardano network
            // 3. Ledger State Queries - Query live blockchain state from mainnet
            // ================================================================================

            Console.WriteLine();
            Console.WriteLine("\u001b[35m╔══════════════════════════════════════════════════════════════════════════════╗\u001b[0m");
            Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
            Console.WriteLine("\u001b[35m║              🎉 OgmiosDotnet - Final Milestone Demo 🎉                       ║\u001b[0m");
            Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
            Console.WriteLine("\u001b[35m║  Demonstrating complete Ogmios v6.13 functionality:                         ║\u001b[0m");
            Console.WriteLine("\u001b[35m║    • Transaction Evaluation (DEX swap execution units)                      ║\u001b[0m");
            Console.WriteLine("\u001b[35m║    • Transaction Submission (submit to Cardano network)                     ║\u001b[0m");
            Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
            Console.WriteLine("\u001b[35m╚══════════════════════════════════════════════════════════════════════════════╝\u001b[0m");
            Console.WriteLine();

            await transactionEvaluationExample.ExecuteAsync(context, ogmiosConfiguration, stoppingToken);

            await transactionSubmissionExample.ExecuteAsync(context, ogmiosConfiguration, stoppingToken);

            // await ledgerStateQueriesExample.ExecuteAsync(context, ogmiosConfiguration, stoppingToken);
            // await chainSynchronizationExample.ExecuteAsync(context, ogmiosConfiguration, stoppingToken);
            // await memPoolMonitoringExample.ExecuteAsync(context, ogmiosConfiguration, stoppingToken);

            Console.WriteLine();
            Console.WriteLine("\u001b[35m╔══════════════════════════════════════════════════════════════════════════════╗\u001b[0m");
            Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
            Console.WriteLine("\u001b[35m║  ✅ Final Milestone Demo Complete!                                           ║\u001b[0m");
            Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
            Console.WriteLine("\u001b[35m║  📦 NuGet: https://www.nuget.org/packages/OgmiosDotnetClient.Services        ║\u001b[0m");
            Console.WriteLine("\u001b[35m║  📂 GitHub: https://github.com/ItsDaveB/OgmiosDotnet                         ║\u001b[0m");
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

