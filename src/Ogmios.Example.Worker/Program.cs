
using ChainSynchronizationWorker.ChainSynchronizationHandlers;
using Ogmios.Extensions;
using Ogmios.Services.ChainSynchronization;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddOgmiosServices();
builder.Services.AddSingleton<IChainSynchronizationMessageHandlers, ChainSynchronizationMessageHandlers>();
builder.Services.AddHostedService<Ogmios.Example.Worker.ChainSynchronizationWorker>();

var host = builder.Build();
host.Run();
