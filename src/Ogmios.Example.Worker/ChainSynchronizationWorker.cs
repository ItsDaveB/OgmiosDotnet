using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.InteractionContext;
using Ogmios.Services.MemoryPoolMonitoring;

namespace Ogmios.Example.Worker
{
    public class ChainSynchronizationWorker(ILogger<ChainSynchronizationWorker> logger, IInteractionContextFactory contextFactory, IChainSynchronizationClientService chainSynchronizationClientService, IMemoryPoolMonitoringService memoryPoolMonitoringService, IConfiguration configuration) : BackgroundService
    {
        private readonly ILogger<ChainSynchronizationWorker> _logger = logger;
        private readonly IInteractionContextFactory _contextFactory = contextFactory;
        private readonly IChainSynchronizationClientService _chainSynchronizationClientService = chainSynchronizationClientService;
        private readonly IMemoryPoolMonitoringService _memoryPoolMonitoringService = memoryPoolMonitoringService;
        private readonly IConfiguration _configuration = configuration;

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

                await PerformChainSynchronizationOperations(contexts, ogmiosConfiguration, stoppingToken);
                await PerformMemPoolMonitoringOperations(contexts, stoppingToken);

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(100, stoppingToken);
                }
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogInformation($"Worker cancellation requested. {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while running the worker.");
            }
            finally
            {
                _logger.LogInformation("Worker stopping at: {time}", DateTimeOffset.Now);
            }
        }

        private async Task PerformChainSynchronizationOperations(List<InteractionContext> contexts, OgmiosConfiguration ogmiosConfiguration, CancellationToken stoppingToken)
        {
            var points = await _chainSynchronizationClientService.ResumeAsync(contexts, maxBlocksPerSecond: ogmiosConfiguration.MaxBlocksPerSecond, inFlight: 100, stoppingToken);
        }

        private async Task PerformMemPoolMonitoringOperations(List<InteractionContext> contexts, CancellationToken stoppingToken)
        {
            var mempool = await _memoryPoolMonitoringService.AcquireMempoolAsync(contexts.First(), stoppingToken);
            var sizeOfMempool = await _memoryPoolMonitoringService.SizeOfMempoolAsync(contexts.First(), stoppingToken);
            var nextTransaction = await _memoryPoolMonitoringService.NextTransactionAsync(contexts.First(), stoppingToken);
            var hasTransaction = await _memoryPoolMonitoringService.HasTransactionAsync(contexts.First(), "eddc4a21f5da916a3f8b0a8c1dc6cbeec790d058ce8ecb9390f326489768bbf1", stoppingToken);
            var releaseMempool = await _memoryPoolMonitoringService.ReleaseMempoolAsync(contexts.First(), stoppingToken);
        }
    }
}
