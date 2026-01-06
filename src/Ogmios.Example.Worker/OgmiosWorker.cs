using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Example.Database.Services;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.InteractionContext;
using Ogmios.Services.LedgerStateQueries.Contracts;
using Ogmios.Services.MemoryPoolMonitoring;
using Ogmios.Services.ServerHealth;
using Ogmios.Services.TransactionEvaluation;
using Ogmios.Services.TransactionSubmission;

namespace Ogmios.Example.Worker
{
    public class OgmiosWorker(
        ILogger<OgmiosWorker> logger,
        IInteractionContextFactory contextFactory,
        IChainSynchronizationClientService chainSynchronizationClientService,
        IMemoryPoolMonitoringService memoryPoolMonitoringService,
        IConfiguration configuration,
        ITransactionService transactionService,
        ITransactionSubmissionService transactionSubmissionService,
        ITransactionEvaluationService transactionEvaluationService,
        IServerHealthService serverHealthService,
        IAcquireLedgerStateService acquireLedgerStateService,
        IReleaseLedgerStateService releaseLedgerStateService,
        ILedgerStateTipService ledgerStateTipService,
        ILedgerStateProtocolParametersService ledgerStateProtocolParametersService,
        ILedgerStateTreasuryAndReservesService ledgerStateTreasuryAndReservesService,
        ILedgerStateGovernanceProposalsService ledgerStateGovernanceProposalsService,
        ILedgerStateStakePoolsPerformancesService ledgerStateStakePoolsPerformancesService,
        ILedgerStateStakePoolsService ledgerStateStakePoolsService,
        ILedgerStateEpochService ledgerStateEpochService) : BackgroundService
    {

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Worker starting at: {time}", DateTimeOffset.Now);

            try
            {
                var contexts = new List<InteractionContext>();
                var startingPoints = configuration.GetSection("StartingPoints").Get<List<StartingPointConfiguration>>();
                var ogmiosConfiguration = configuration.GetSection("Ogmios").Get<OgmiosConfiguration>() ?? throw new Exception("Ogmios Configuration not found.");

                for (int i = 0; i < startingPoints?.Count; i++)
                {
                    var startingPoint = startingPoints[i];
                    var connectionName = $"connection_{i}";
                    var context = await contextFactory.CreateInteractionContextAsync(connectionName, startingPoint, ogmiosConfiguration);
                    contexts.Add(context);
                }

                await PerformLedgerStateQueryOperations(contexts, ogmiosConfiguration, stoppingToken);
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

        private async Task PerformLedgerStateQueryOperations(List<InteractionContext> contexts, OgmiosConfiguration ogmiosConfiguration, CancellationToken stoppingToken)
        {
            var context = contexts.FirstOrDefault();
            if (context is null) return;

            Console.WriteLine("\u001b[33m--- Ledger State Query Demonstration ---\u001b[0m");

            string baseUrl;
            if (ogmiosConfiguration.Host.StartsWith("http://") || ogmiosConfiguration.Host.StartsWith("https://"))
            {
                baseUrl = ogmiosConfiguration.Host.TrimEnd('/');
            }
            else
            {
                var scheme = ogmiosConfiguration.Tls ? "https" : "http";
                baseUrl = $"{scheme}://{ogmiosConfiguration.Host}:{ogmiosConfiguration.Port}";
            }
            var serverAddress = new Uri(baseUrl);
            Console.WriteLine($"\u001b[36m[ServerHealth] Getting server health from {serverAddress}...\u001b[0m");
            var serverHealth = await serverHealthService.GetServerHealthAsync(serverAddress);
            var tip = serverHealth.LastKnownTip;
            Console.WriteLine($"\u001b[32m[ServerHealth] Server tip: Slot {tip.Slot}, Block {tip.Block}\u001b[0m");

            var tipPoint = Generated.Ogmios.PointOrOrigin.Point.Create(
                id: tip.Block ?? throw new InvalidOperationException("Block ID is null"),
                slot: Generated.Slot.ParseValue(tip.Slot.ToString()));
            var acquireParams = Generated.Ogmios.AcquireLedgerState.RequiredPoint.Create(tipPoint);
            var acquireRequest = Generated.Ogmios.AcquireLedgerState.Create(
                jsonrpc: Generated.Ogmios.AcquireLedgerState.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.AcquireLedgerState.MethodEntity.EnumValues.AcquireLedgerState,
                paramsValue: acquireParams,
                id: string.Empty);

            Console.WriteLine($"\u001b[36m[AcquireLedgerState] Acquiring ledger state...\u001b[0m");
            var acquireResponse = await acquireLedgerStateService.AcquireAsync(context, acquireRequest, cancellationToken: stoppingToken);
            var acquiredPoint = acquireResponse.AsAcquireLedgerStateSuccess.Result.Point;
            Console.WriteLine($"\u001b[32m[AcquireLedgerState] Ledger state acquired at point: {acquiredPoint}\u001b[0m");

            Console.WriteLine($"\u001b[36m[QueryLedgerState/Tip] Querying ledger state tip...\u001b[0m");
            var tipResponse = await ledgerStateTipService.GetTipAsync(context, cancellationToken: stoppingToken);
            var ledgerTip = tipResponse.AsQueryLedgerStateTipResponse.Result;
            Console.WriteLine($"\u001b[32m[QueryLedgerState/Tip] Ledger Tip: {ledgerTip}\u001b[0m");

            Console.WriteLine($"\u001b[36m[QueryLedgerState/Epoch] Querying current epoch...\u001b[0m");
            var epochResponse = await ledgerStateEpochService.GetEpochAsync(context, cancellationToken: stoppingToken);
            var epoch = epochResponse.AsQueryLedgerStateEpochResponse.Result;
            Console.WriteLine($"\u001b[32m[QueryLedgerState/Epoch] Current Epoch: {epoch}\u001b[0m");

            Console.WriteLine($"\u001b[36m[QueryLedgerState/ProtocolParameters] Querying protocol parameters...\u001b[0m");
            var protocolParamsResponse = await ledgerStateProtocolParametersService.GetProtocolParametersAsync(context, cancellationToken: stoppingToken);
            var protocolParams = protocolParamsResponse.AsQueryLedgerStateProtocolParametersResponse.Result;
            Console.WriteLine($"\u001b[32m[QueryLedgerState/ProtocolParameters] Min Fee Coefficient: {protocolParams.MinFeeCoefficient}, Version: {protocolParams.Version.Major}.{protocolParams.Version.Minor}\u001b[0m");

            Console.WriteLine($"\u001b[36m[QueryLedgerState/TreasuryAndReserves] Querying treasury and reserves...\u001b[0m");
            var treasuryResponse = await ledgerStateTreasuryAndReservesService.GetTreasuryAndReservesAsync(context, cancellationToken: stoppingToken);
            var treasury = treasuryResponse.AsQueryLedgerStateTreasuryAndReservesResponse.Result;
            Console.WriteLine($"\u001b[32m[QueryLedgerState/TreasuryAndReserves] Treasury: {treasury.Treasury.Ada.Lovelace} lovelace, Reserves: {treasury.Reserves.Ada.Lovelace} lovelace\u001b[0m");

            Console.WriteLine($"\u001b[36m[QueryLedgerState/GovernanceProposals] Querying governance proposals...\u001b[0m");
            var governanceResponse = await ledgerStateGovernanceProposalsService.GetGovernanceProposalsAsync(context, cancellationToken: stoppingToken);
            var proposals = governanceResponse.AsQueryLedgerStateGovernanceProposalsResponse.Result;
            Console.WriteLine($"\u001b[32m[QueryLedgerState/GovernanceProposals] Active Governance Proposals: {proposals.Count()}\u001b[0m");

            var davePoolId = "pool1t6n7rysk6wzm9wqxda6zxpzmm3j6256fs3mp06dc26n6503hhj4";
            try
            {
                Console.WriteLine($"\u001b[36m[QueryLedgerState/StakePools] Querying specific stake pool by ID...\u001b[0m");

                var stakePoolIdEntity = Generated.StakePoolId.Parse($"\"{davePoolId}\"");
                var poolIdParam = Generated.Ogmios.QueryLedgerStateStakePools.ParamsEntity.RequiredIdArray.RequiredId.Create(stakePoolIdEntity);
                var poolIdArray = Generated.Ogmios.QueryLedgerStateStakePools.ParamsEntity.RequiredIdArray.FromRange([poolIdParam]);
                var paramsEntity = Generated.Ogmios.QueryLedgerStateStakePools.ParamsEntity.Create(stakePools: poolIdArray);

                var stakePoolRequest = Generated.Ogmios.QueryLedgerStateStakePools.Create(
                    jsonrpc: Generated.Ogmios.QueryLedgerStateStakePools.JsonrpcEntity.EnumValues.Value20,
                    method: Generated.Ogmios.QueryLedgerStateStakePools.MethodEntity.EnumValues.QueryLedgerStateStakePools,
                    id: string.Empty,
                    paramsValue: paramsEntity);

                var stakePoolResponse = await ledgerStateStakePoolsService.GetStakePoolsAsync(context, stakePoolRequest, cancellationToken: stoppingToken);
                var pools = stakePoolResponse.AsQueryLedgerStateStakePoolsResponse.Result;

                var davePoolEntry = pools.FirstOrDefault();
                if (davePoolEntry.Value.IsNotNullOrUndefined())
                {
                    var davePool = davePoolEntry.Value;

                    var pledgeAda = (long)davePool.Pledge.Ada.Lovelace / 1_000_000m;
                    var costAda = (long)davePool.Cost.Ada.Lovelace / 1_000_000m;

                    Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools] ══════════════════════════════════════════════════════════════\u001b[0m");
                    Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   DAVE Stake Pool - Live Mainnet Data\u001b[0m");
                    Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools] ══════════════════════════════════════════════════════════════\u001b[0m");
                    Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   Pool ID:        {davePoolEntry.Key}\u001b[0m");
                    Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   VRF Key Hash:   {davePool.VrfVerificationKeyHash}\u001b[0m");
                    Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   Pledge:         {pledgeAda:N0} ADA\u001b[0m");
                    Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   Fixed Cost:     {costAda:N0} ADA\u001b[0m");
                    Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   Margin:         {davePool.Margin} ({(double)1 / 100:P0})\u001b[0m");
                    Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   Reward Account: {davePool.RewardAccount}\u001b[0m");
                    Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools] ══════════════════════════════════════════════════════════════\u001b[0m");
                }
                else
                {
                    Console.WriteLine($"\u001b[33m[QueryLedgerState/StakePools] Stake pool not found in response.\u001b[0m");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\u001b[33m[QueryLedgerState/StakePools] Error: {ex.Message}\u001b[0m");
            }

            Console.WriteLine($"\u001b[36m[ReleaseLedgerState] Releasing ledger state...\u001b[0m");
            await releaseLedgerStateService.ReleaseAsync(context, cancellationToken: stoppingToken);
            Console.WriteLine($"\u001b[32m[ReleaseLedgerState] Ledger state released\u001b[0m");

            Console.WriteLine("\u001b[33m--- Ledger State Query Demonstration Complete ---\u001b[0m");
        }

        private async Task PerformChainSynchronizationOperations(List<InteractionContext> contexts, OgmiosConfiguration ogmiosConfiguration, CancellationToken stoppingToken)
        {
            var points = await chainSynchronizationClientService.ResumeAsync(contexts, maxBlocksPerSecond: ogmiosConfiguration.MaxBlocksPerSecond, inFlight: 100, stoppingToken);
        }

        private async Task PerformTransactionEvaluationOperations(List<InteractionContext> contexts, CancellationToken stoppingToken)
        {
            var context = contexts.FirstOrDefault();
            if (context is null) return;

            var cborRawForEvaluation = "CBORHex";
            var cborToEvaluate = Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.Create(
                Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.FromAny(cborRawForEvaluation));

            var evaluationResponse = await transactionEvaluationService.EvaluateTransactionAsync(context, cborToEvaluate.Cbor, cancellationToken: stoppingToken);
            var successResponse = evaluationResponse.AsEvaluateTransactionSuccess.Result;

            var budget = successResponse.FirstOrDefault().Budget;
            var validator = successResponse.FirstOrDefault().Validator;
            logger.LogInformation("Budget: {budget}, Validator: {validator}", budget, validator);
        }

        private async Task PerformTransactionSubmissionOperations(List<InteractionContext> contexts, CancellationToken stoppingToken)
        {
            var context = contexts.FirstOrDefault();
            if (context is null) return;

            var cborRawForSubmission = "CBORHex";
            var transactionToSubmit = Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.Create(
                Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16.FromAny(cborRawForSubmission));

            var transactionSubmissionResult = await transactionSubmissionService.SubmitTransactionAsync(context, transactionToSubmit.Cbor, cancellationToken: stoppingToken);
            logger.LogInformation("Transaction Id: {transactionId}", (string)transactionSubmissionResult.AsSubmitTransactionSuccess.Id.AsString);
        }

        private async Task PerformMemPoolMonitoringOperations(List<InteractionContext> contexts, CancellationToken stoppingToken)
        {
            var context = contexts.FirstOrDefault();
            if (context is null) return;

            while (true)
            {
                Console.WriteLine("\u001b[33mWaiting for changes in the mempool snapshot...\u001b[0m");
                var mempoolAcquired = await memoryPoolMonitoringService.AcquireMempoolAsync(context, stoppingToken);
                var mempoolSizeAndCapacity = await memoryPoolMonitoringService.SizeOfMempoolAsync(context, stoppingToken);
                Console.WriteLine($"\u001b[32mMempool maximum capacity (bytes): {mempoolSizeAndCapacity.MaxCapacity.Bytes}\u001b[0m");
                Console.WriteLine($"\u001b[32mMempool current size (bytes): {mempoolSizeAndCapacity.CurrentSize.Bytes}\u001b[0m");

                var nextTransaction = await memoryPoolMonitoringService.NextTransactionAsync(context, stoppingToken);
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

                var hasTransaction = await memoryPoolMonitoringService.HasTransactionAsync(context, "eddc4a21f5da916a3f8b0a8c1dc6cbeec790d058ce8ecb9390f326489768bbf1", stoppingToken);
                Console.WriteLine($"\u001b[32mTransaction: eddc4a21f5da916a3f8b0a8c1dc6cbeec790d058ce8ecb9390f326489768bbf exists in snapshot?: {hasTransaction.Result}\u001b[0m");

                await SaveTransactionAsync(nextTransaction.AsTransaction);
                var transaction = await GetTransactionAsync((string)nextTransaction.AsTransaction.Id);


                if (stoppingToken.IsCancellationRequested)
                {
                    await memoryPoolMonitoringService.ReleaseMempoolAsync(context, stoppingToken);
                    await memoryPoolMonitoringService.ShutdownAsync(context, stoppingToken);
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
            await transactionService.CreateTransactionAsync(transaction);
            Console.WriteLine($"\u001b[32mTransaction Successfully Saved To Database.\u001b[0m");
        }

        public async Task<Generated.Transaction?> GetTransactionAsync(string transactionId)
        {
            Console.WriteLine($"\u001b[32mGetting Transaction From Database.\u001b[0m");
            var transactionEntity = await transactionService.GetTransactionAsync(transactionId);
            Console.WriteLine($"\u001b[32mTransaction Successfully Retrieved From Database.\u001b[0m");

            return transactionEntity;
        }
    }
}
