using Microsoft.Extensions.DependencyInjection;
using Ogmios.Domain.ChainSynchronization;
using Ogmios.Services.InteractionContext;

namespace Ogmios.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOgmiosServices(this IServiceCollection services)
        {
            services.AddSingleton<IInteractionContextService, InteractionContextService>();
            services.AddSingleton<IChainSynchronizationClientService, ChainSynchronizationClientService>();
            services.AddSingleton<IIntersectionService, IntersectionService>();
            services.AddSingleton<IInteractionContextFactory, InteractionContextFactory>();
            services.AddSingleton<BlockService>();
            return services;
        }
    }
}