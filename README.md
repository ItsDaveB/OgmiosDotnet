# OgmiosDotnetClient: A Cardano Node Integration Library

## Overview

**OgmiosDotnetClient** is a .NET client library designed to facilitate communication with a Cardano Node via the Ogmios WebSocket interface. It enables developers to synchronize blockchain data from a specific point, retrieve block information, and handle real-time blockchain events effortlessly.

## Requirements

To use **OgmiosDotnetClient**, you need:

- A Cardano Node running Ogmios, or
- Access to an Ogmios service, such as [Demeter](https://demeter.run), which provides instant access to Ogmios with a free tier sponsored by the Cardano Foundation. (I recommend this optio due to ease of use, flexibility & it's backed by a great team ensuring stability and responsiveness.)

## Integration Steps

### 1. Install OgmiosDotnetClient

First, add the **OgmiosDotnetClient** package to your .NET project:

```bash
dotnet add package OgmiosDotnetClient
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
builder.Services.AddHostedService<ChainSynchronizationWorker>();

var host = builder.Build();
host.Run();
```

### 3. Chain Synchronization Worker Example Application

The `ChainSynchronizationWorker` is a background service that demonstrates how **OgmiosDotnetClient** operates. It functions as follows:

- **Initializes interaction contexts**: Sets up the necessary WebSocket connections to communicate with the Cardano node.
- **Resumes blockchain synchronization**: Starts synchronizing from the last known point in the blockchain.
- **Continuously listens for updates**: Monitors the Cardano node for real-time updates and processes new blocks as they are received.

### Services Used by ChainSynchronizationWorker:

- **IInteractionContextFactory**: Responsible for establishing and managing WebSocket connections to the Cardano node.
- **IChainSynchronizationClientService**: Handles the synchronization of blockchain data, ensuring that the latest blocks and chain state are processed.

## Custom Event Handlers for Blockchain Synchronization

The `ChainSynchronizationMessageHandlers` class defines basic handlers for two key blockchain events:

- **Roll Forward Events**: Occurs when the blockchain moves forward, processing new blocks.
- **Roll Backward Events**: Occurs when the blockchain rolls back to a previous state (e.g., when blocks are reorganized).

### Customization:

These handlers can be extended to perform custom actions such as:

- **Data Persistence**: Saving block data to a database or other storage systems.
- **Processing Blockchain Data**: Executing additional logic based on the blockchain data being processed.

The handlers are triggered every time a block is processed, allowing developers to define actions specific to their application's requirements.

## Example Code:

```csharp
public class ChainSynchronizationMessageHandlers : IChainSynchronizationMessageHandlers
{
    public async Task RollBackwardHandler(Generated.Ogmios.PointOrOrigin point, Generated.Ogmios.TipOrOrigin tip)
    {
        await Task.CompletedTask;
    }

    public async Task RollForwardHandler(Block block, string blockType, Generated.Tip tip)
    {
        await Task.CompletedTask;
    }
}
```

## Key Points:

- **RollBackwardHandler**: Can be extended to handle rollback events (e.g., saving rollback data or triggering actions).
- **RollForwardHandler**: Can be extended to handle new blocks and act on the returned blockchain data (e.g., process or store block information).

### 4. Configuration

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

### 5. Running the Worker

Once everything is set up, run your application. The `ChainSynchronizationWorker` will handle the chain synchronization and process incoming blockchain updates.

---

This guide covers the basic steps needed to integrate **OgmiosDotnetClient** and start synchronizing Cardano blockchain data in your .NET application, whilst explaining the functionality and reasoning behind its design.

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
