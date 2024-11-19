
using ChainSynchronizationWorker.ChainSynchronizationHandlers;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.Extensions;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddOgmiosServices();
builder.Services.AddSingleton<IChainSynchronizationMessageHandlers, ChainSynchronizationMessageHandlers>();
builder.Services.AddHostedService<Ogmios.Example.Worker.ChainSynchronizationWorker>();

var host = builder.Build();
host.Run();
