using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Example.Database.Services;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.InteractionContext;
using Ogmios.Services.MemoryPoolMonitoring;

namespace Ogmios.Example.Worker
{
    public class OgmiosWorker(ILogger<OgmiosWorker> logger, IInteractionContextFactory contextFactory, IChainSynchronizationClientService chainSynchronizationClientService, IMemoryPoolMonitoringService memoryPoolMonitoringService, IConfiguration configuration, ITransactionService transactionService) : BackgroundService
    {
        private readonly ILogger<OgmiosWorker> _logger = logger;
        private readonly IInteractionContextFactory _contextFactory = contextFactory;
        private readonly IChainSynchronizationClientService _chainSynchronizationClientService = chainSynchronizationClientService;
        private readonly IMemoryPoolMonitoringService _memoryPoolMonitoringService = memoryPoolMonitoringService;
        private readonly IConfiguration _configuration = configuration;
        private readonly ITransactionService _transactionService = transactionService;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker starting at: {time}", DateTimeOffset.Now);

            try
            {
                var contexts = new List<InteractionContext>();
                var startingPoints = _configuration.GetSection("StartingPoints").Get<List<StartingPointConfiguration>>();
                var ogmiosConfiguration = _configuration.GetSection("Ogmios").Get<OgmiosConfiguration>() ?? throw new Exception("Ogmios Configuration not found.");

                for (int i = 0; i < startingPoints?.Count; i++)
                {
                    var startingPoint = startingPoints[i];
                    var connectionName = $"connection_{i}";
                    var context = await _contextFactory.CreateInteractionContextAsync(connectionName, startingPoint, ogmiosConfiguration);
                    contexts.Add(context);
                }

                // Chain Synchronization. 
                var chainSynchronizationTask = PerformChainSynchronizationOperations(contexts, ogmiosConfiguration, stoppingToken);
                await chainSynchronizationTask;

                // Memory Pool Monitoring.
                // var memoryPoolMonitoringTask = PerformMemPoolMonitoringOperations(contexts, stoppingToken);
                // await memoryPoolMonitoringTask;

            }
            catch (OperationCanceledException ex)
            {
                _logger.LogInformation(ex, "Worker cancellation requested.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while running the worker.");
            }
            finally
            {
                _logger.LogInformation("Worker stopping at: {time}.", DateTimeOffset.Now);
            }
        }

        private async Task PerformChainSynchronizationOperations(List<InteractionContext> contexts, OgmiosConfiguration ogmiosConfiguration, CancellationToken stoppingToken)
        {
            var points = await _chainSynchronizationClientService.ResumeAsync(contexts, maxBlocksPerSecond: ogmiosConfiguration.MaxBlocksPerSecond, inFlight: 100, stoppingToken);
        }

        private async Task PerformMemPoolMonitoringOperations(List<InteractionContext> contexts, CancellationToken stoppingToken)
        {
            var context = contexts.FirstOrDefault();
            if (context is null) return;

            while (true)
            {
                Console.WriteLine("\u001b[33mWaiting for changes in the mempool snapshot...\u001b[0m");
                var mempoolAcquired = await _memoryPoolMonitoringService.AcquireMempoolAsync(context, stoppingToken);
                var mempoolSizeAndCapacity = await _memoryPoolMonitoringService.SizeOfMempoolAsync(context, stoppingToken);
                Console.WriteLine($"\u001b[32mMempool maximum capacity (bytes): {mempoolSizeAndCapacity.MaxCapacity.Bytes}\u001b[0m");
                Console.WriteLine($"\u001b[32mMempool current size (bytes): {mempoolSizeAndCapacity.CurrentSize.Bytes}\u001b[0m");

                var nextTransaction = await _memoryPoolMonitoringService.NextTransactionAsync(context, stoppingToken);
                if (nextTransaction.IsNullOrUndefined()) continue;

                var nextTransactionEntity = nextTransaction.AsTransaction;
                Console.WriteLine($"\u001b[32mTransactionId: {nextTransactionEntity.Id}\u001b[0m");
                Console.WriteLine($"\u001b[32mTransactionFee: {nextTransactionEntity.Fee}\u001b[0m");
                if (nextTransactionEntity.Metadata.IsNotNullOrUndefined())
                {
                    var formattedLabels = string.Join("\n", nextTransactionEntity.Metadata.Labels.Select(label => $"\u001b[32mKey:\n{label.Key}\nValue:\n{label.Value}\u001b[0m"));
                    Console.WriteLine($"\u001b[32mTransactionMetadata:\n{formattedLabels}\u001b[0m");
                }
                Console.WriteLine($"\u001b[32mTransactionInputs: {nextTransactionEntity.Inputs.Count()}\u001b[0m");
                Console.WriteLine($"\u001b[32mTransactionOutputs: {nextTransactionEntity.Outputs.Count()}\u001b[0m");

                var hasTransaction = await _memoryPoolMonitoringService.HasTransactionAsync(context, "eddc4a21f5da916a3f8b0a8c1dc6cbeec790d058ce8ecb9390f326489768bbf1", stoppingToken);
                Console.WriteLine($"\u001b[32mTransaction: eddc4a21f5da916a3f8b0a8c1dc6cbeec790d058ce8ecb9390f326489768bbf exists in snapshot?: {hasTransaction.Result}\u001b[0m");

                await SaveTransactionAsync(nextTransaction.AsTransaction);
                var transaction = await GetTransactionAsync((string)nextTransaction.AsTransaction.Id);


                if (stoppingToken.IsCancellationRequested)
                {
                    await _memoryPoolMonitoringService.ReleaseMempoolAsync(context, stoppingToken);
                    await _memoryPoolMonitoringService.ShutdownAsync(context, stoppingToken);
                    Console.ResetColor();
                }
            }
        }

        public async Task SaveTransactionAsync(Generated.Transaction transaction)
        {
            var doesExist = await GetTransactionAsync((string)transaction.Id) is not null;
            if (doesExist)
            {
                Console.WriteLine($"\u001b[32mTransaction Already Exists In Database.\u001b[0m");
                return;
            }

            Console.WriteLine($"\u001b[32mSaving Transaction.\u001b[0m");
            await _transactionService.CreateTransactionAsync(transaction);
            Console.WriteLine($"\u001b[32mTransaction Successfully Saved To Database.\u001b[0m");
        }

        public async Task<Generated.Transaction?> GetTransactionAsync(string transactionId)
        {
            Console.WriteLine($"\u001b[32mGetting Transaction From Database.\u001b[0m");
            var transactionEntity = await _transactionService.GetTransactionAsync(transactionId);
            Console.WriteLine($"\u001b[32mTransaction Successfully Retrieved From Database.\u001b[0m");

            return transactionEntity;
        }
    }
}
