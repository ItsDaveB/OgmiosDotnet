using Ogmios.Example.Worker;
using Ogmios.Example.Worker.ChainSynchronizationHandlers;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.Extensions;
using Microsoft.EntityFrameworkCore;
using Ogmios.Example.Database.Infrastructure.Database.Repositories;
using Ogmios.Example.Database.Infrastructure.Database;
using Ogmios.Example.Database.Services;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddOgmiosServices();
builder.Services.AddSingleton<IChainSynchronizationMessageHandlers, ChainSynchronizationMessageHandlers>();
builder.Services.AddHostedService<OgmiosWorker>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("cardano"), ServiceLifetime.Singleton);


builder.Services.AddSingleton<ITransactionRepository, TransactionRepository>();
builder.Services.AddSingleton<ITransactionService, TransactionService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var host = builder.Build();
host.Run();
