
using ChainSynchronizationWorker.ChainSynchronizationHandlers;
using Ogmios.Domain.Extensions;
using static Ogmios.Services.ChainSynchronization.BlockService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddOgmiosServices();
builder.Services.AddSingleton<IChainSynchronizationMessageHandlers, ChainSynchronizationMessageHandlers>();
builder.Services.AddHostedService<Ogmios.Example.Worker.ChainSynchronizationWorker>();

var host = builder.Build();
host.Run();
