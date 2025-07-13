
<div align="center">
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/LICENSE)
</div>

# OgmiosDotnetClient: A Cardano Node Integration Library

## Overview

**OgmiosDotnetClient** is a .NET client library designed to facilitate communication with a Cardano Node via the Ogmios WebSocket interface. It enables developers to synchronize blockchain data from a specific point, retrieve block information, and handle real-time blockchain events effortlessly.

## Modules

This project is divided into the following modules:

- [Chain Synchronization](src/Ogmios.Services/ChainSynchronization/docs/README.md): Covers the chain synchronization process, including real-time updates and blockchain data handling.
- [Memory Pool Monitoring](src/Ogmios.Services/MemoryPoolMonitoring/docs/README.md): Provides an overview of mempool monitoring for tracking transactions and querying mempool details.
- [Ogmios Schema](src/Ogmios.Schema/docs/README.md): Contains the auto-generated strongly-typed C# classes based on the Ogmios JSON schema for the version in question.
- [Ogmios Worker Example](src/Ogmios.Example.Worker/docs/README.md): Demonstrates the capabilities of the Ogmios Client package through a fully functional worker application. This example showcases chain synchronization, mempool monitoring, and custom handler implementations, along with in-memory database operations for data persistence and flexibility.

## Requirements

To use **OgmiosDotnetClient**, you need:

- A Cardano Node running Ogmios, or
- Access to an Ogmios service, such as [Demeter](https://demeter.run), which provides instant access to Ogmios with a free tier sponsored by the Cardano Foundation. (I recommend this option due to ease of use, flexibility & it's backed by a great team ensuring stability and responsiveness.)

### Current Version

Ogmios v6.12.0

## Integration Steps

### 1. Install OgmiosDotnetClient

First, add the **OgmiosDotnetClient** package to your .NET project:

```bash
dotnet add package OgmiosDotnetClient.Services
```

### 2. Add Ogmios Services

In your .NET application, register the necessary services by adding the `AddOgmiosServices()` method in your `Program.cs`:

```csharp
using ChainSynchronization;
using ChainSynchronization.ChainSynchronizationHandlers;
using Ogmios.Domain.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddOgmiosServices();
builder.Services.AddSingleton<IChainSynchronizationMessageHandlers, ChainSynchronizationMessageHandlers>();
builder.Services.AddHostedService<OgmiosWorker>();

var host = builder.Build();
host.Run();
```

### 3. Chain Synchronization Worker Example Application

The `OgmiosWorker` is a background service that demonstrates how **OgmiosDotnetClient** operates. It functions as follows:

- **Initializes interaction contexts**: Sets up the necessary WebSocket connections to communicate with the Cardano node.
- **Resumes blockchain synchronization**: Starts synchronizing from the last known point in the blockchain.
- **Continuously listens for updates**: Monitors the Cardano node for real-time updates and processes new blocks as they are received.

### Services Used by OgmiosWorker:

- **IInteractionContextFactory**: Responsible for establishing and managing WebSocket connections to the Cardano node.
- **IChainSynchronizationClientService**: Handles the synchronization of blockchain data, ensuring that the latest blocks and chain state are processed based on the starting point configuration.
- **IMemoryPoolMonitoringService**: Provides functionality to monitor and read memory pool transaction data.

### 4. Saving Data to an In-Memory PostgreSQL Database

The `OgmiosWorker` also demonstrates the use of **Entity Framework Core** with an **in-memory PostgreSQL database** to persist blockchain data, this implementation is siutated within the `Ogmios.Example.Database` project. This process leverages the following components:

- **Entity Framework Core**: For defining the database context and managing persistence.
- **AutoMapper**: To map the Ogmios JSON schema types to corresponding Entity Framework Core models.
- **JSON Serialization**: Data is stored in the database as JSON for flexibility and simplicity.
- **Validation of Mapping**: Data is read back from the database to ensure it can be accurately mapped back to schema-specific idiomatic types.
  [Ogmios Worker Example](src/Ogmios.Example.Worker/docs/README.md):

### 5. Configuration

To properly configure **OgmiosDotnetClient** for blockchain synchronization, you need to specify starting points in your application's configuration file (e.g., `appsettings.json`). Each starting point represents a position on the blockchain from which the synchronization will begin, and **OgmiosDotnetClient** will treat each as a separate WebSocket connection.

- **StartingId**: The block ID where synchronization will start.
- **StartingSlot**: The specific slot number in the blockchain at which synchronization will begin.

#### Example `appsettings.json` configuration:

```json
{
  "StartingPoints": [
    {
      "StartingId": "4e58bb36837b32f894c8a57006e24b64c2d77bf4fc13b3b2c428fee8871e2491",
      "StartingSlot": "115545883"
    }
  ]
}
```

### 6. Running the Worker

Once everything is set up, run your application. The `OgmiosWorker` will handle the chain synchronization and process incoming blockchain updates.

---

This guide covers the basic steps needed to integrate **OgmiosDotnetClient** and start synchronizing Cardano blockchain data in your .NET application, whilst explaining the functionality and reasoning behind its design.

#### Tips

While this example uses an in-memory PostgreSQL database for demonstration purposes, Entity Framework Core supports a wide range of database providers (e.g., SQL Server, MySQL, SQLite). You can easily switch to a different provider by updating your application's dependency injection setup.

```csharp
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("cardano"), ServiceLifetime.Singleton);
```

### Useful Links

- [Ogmios Documentation](https://ogmios.dev)
- [Demeter.run](https://demeter.run)
- [Cardano Foundation](https://cardanofoundation.org)

## Contributing

Contributions are welcome! Feel free to open an issue or submit a pull request if you have suggestions or improvements.

## License

This project is licensed under the MIT License.

## Funding and Support

This project was funded through a successful proposal in **Cardano Project Catalyst Fund 12** under the Developer category. The proposal received overwhelming support, with **126 million ADA** voting in favor. As a result, the project was funded by the **Cardano Project Catalyst Innovation Fund**.
