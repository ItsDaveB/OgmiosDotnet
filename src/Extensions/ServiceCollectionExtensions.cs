using Microsoft.Extensions.DependencyInjection;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.InteractionContext;
using Ogmios.Services.ServerHealth;

namespace Ogmios.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOgmiosServices(this IServiceCollection services)
        {
            services.AddSingleton<IInteractionContextService, InteractionContextService>();
            services.AddSingleton<IChainSynchronizationClientService, ChainSynchronizationClientService>();
            services.AddSingleton<IIntersectionService, IntersectionService>();
            services.AddSingleton<IInteractionContextFactory, InteractionContextFactory>();
            services.AddSingleton<IBlockService, BlockService>();
            services.AddSingleton<IWebSocketService, WebSocketService>();
            services.AddHttpClient<IServerHealthService, ServerHealthService>();

            return services;
        }
    }
}