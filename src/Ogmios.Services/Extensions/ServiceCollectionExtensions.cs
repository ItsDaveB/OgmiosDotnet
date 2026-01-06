using Microsoft.Extensions.DependencyInjection;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.InteractionContext;
using Ogmios.Services.LedgerStateQueries;
using Ogmios.Services.LedgerStateQueries.Contracts;
using Ogmios.Services.MemoryPoolMonitoring;
using Ogmios.Services.ServerHealth;
using Ogmios.Services.TransactionEvaluation;
using Ogmios.Services.TransactionSubmission;

namespace Ogmios.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers all Ogmios services including chain synchronization, mempool monitoring,
        /// transaction services, and ledger state queries.
        /// </summary>
        public static IServiceCollection AddOgmiosServices(this IServiceCollection services)
        {
            services.RegisterCoreServices();

            services.AddSingleton<IChainSynchronizationClientService, ChainSynchronizationClientService>();
            services.AddSingleton<IBlockService, BlockService>();
            services.AddSingleton<IMemoryPoolMonitoringService, MemoryPoolMonitoringService>();
            services.AddSingleton<ITransactionSubmissionService, TransactionSubmissionService>();
            services.AddSingleton<ITransactionEvaluationService, TransactionEvaluationService>();

            services.AddLedgerStateQueryServices();

            return services;
        }

        /// <summary>
        /// Registers all 22 ledger state query services for querying Cardano ledger state data.
        /// This includes lifecycle services (acquire/release) and query services for epoch,
        /// protocol parameters, stake pools, governance, treasury, and more.
        /// </summary>
        /// <remarks>
        /// This method is called automatically by <see cref="AddOgmiosServices"/>.
        /// Use this method directly if you only need ledger state query functionality
        /// without chain synchronization or mempool monitoring.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Option 1: Register all Ogmios services (includes ledger state queries)
        /// services.AddOgmiosServices();
        /// 
        /// // Option 2: Register only ledger state query services
        /// services.RegisterCoreServices();
        /// services.AddLedgerStateQueryServices();
        /// </code>
        /// </example>
        public static IServiceCollection AddLedgerStateQueryServices(this IServiceCollection services)
        {
            // Lifecycle Services
            services.AddSingleton<IAcquireLedgerStateService, AcquireLedgerStateService>();
            services.AddSingleton<IReleaseLedgerStateService, ReleaseLedgerStateService>();

            // Query Services
            services.AddSingleton<ILedgerStateTipService, LedgerStateTipService>();
            services.AddSingleton<ILedgerStateEpochService, LedgerStateEpochService>();
            services.AddSingleton<ILedgerStateEraStartService, LedgerStateEraStartService>();
            services.AddSingleton<ILedgerStateEraSummariesService, LedgerStateEraSummariesService>();
            services.AddSingleton<ILedgerStateLiveStakeDistributionService, LedgerStateLiveStakeDistributionService>();
            services.AddSingleton<ILedgerStateProjectedRewardsService, LedgerStateProjectedRewardsService>();
            services.AddSingleton<ILedgerStateProtocolParametersService, LedgerStateProtocolParametersService>();
            services.AddSingleton<ILedgerStateProposedProtocolParametersService, LedgerStateProposedProtocolParametersService>();
            services.AddSingleton<ILedgerStateRewardAccountSummariesService, LedgerStateRewardAccountSummariesService>();
            services.AddSingleton<ILedgerStateRewardsProvenanceService, LedgerStateRewardsProvenanceService>();
            services.AddSingleton<ILedgerStateStakePoolsService, LedgerStateStakePoolsService>();
            services.AddSingleton<ILedgerStateStakePoolsPerformancesService, LedgerStateStakePoolsPerformancesService>();
            services.AddSingleton<ILedgerStateTreasuryAndReservesService, LedgerStateTreasuryAndReservesService>();
            services.AddSingleton<ILedgerStateUTxOService, LedgerStateUTxOService>();
            services.AddSingleton<ILedgerStateConstitutionService, LedgerStateConstitutionService>();
            services.AddSingleton<ILedgerStateConstitutionalCommitteeService, LedgerStateConstitutionalCommitteeService>();
            services.AddSingleton<ILedgerStateGovernanceProposalsService, LedgerStateGovernanceProposalsService>();
            services.AddSingleton<ILedgerStateDelegateRepresentativesService, LedgerStateDelegateRepresentativesService>();
            services.AddSingleton<ILedgerStateDumpService, LedgerStateDumpService>();
            services.AddSingleton<ILedgerStateNoncesService, LedgerStateNoncesService>();
            services.AddSingleton<ILedgerStateOperationalCertificatesService, LedgerStateOperationalCertificatesService>();

            return services;
        }

        private static IServiceCollection RegisterCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IInteractionContextService, InteractionContextService>();
            services.AddSingleton<IIntersectionService, IntersectionService>();
            services.AddSingleton<IInteractionContextFactory, InteractionContextFactory>();
            services.AddSingleton<IWebSocketService, WebSocketService>();
            services.AddHttpClient<IServerHealthService, ServerHealthService>();

            return services;
        }
    }
}