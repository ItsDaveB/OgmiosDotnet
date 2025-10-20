using Microsoft.Extensions.DependencyInjection;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.InteractionContext;
using Ogmios.Services.MemoryPoolMonitoring;
using Ogmios.Services.ServerHealth;
using Ogmios.Services.TransactionSubmission;

namespace Ogmios.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOgmiosServices(this IServiceCollection services)
        {
            services.RegisterCoreServices();

            services.AddSingleton<IChainSynchronizationClientService, ChainSynchronizationClientService>();
            services.AddSingleton<IBlockService, BlockService>();
            services.AddSingleton<IMemoryPoolMonitoringService, MemoryPoolMonitoringService>();
            services.AddSingleton<ITransactionSubmissionService, TransactionSubmissionService>();

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