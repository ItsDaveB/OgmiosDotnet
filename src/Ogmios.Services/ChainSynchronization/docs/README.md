# Chain Synchronization

Chain synchronization is a stateful protocol that allows clients to efficiently synchronize with the Cardano blockchain. It maintains a cursor that represents the current point of synchronization on the chain. This protocol enables clients to follow the chain's progression, handle reorganizations, and efficiently resume syncing after disconnection.

---

## Overview

The chain synchronization process involves two main operations:

1. **Finding an Intersection**: This step determines a common point between the client's local chain and the blockchain maintained by the node. The client provides a list of potential synchronization points or starts from the origin (the beginning of the blockchain).

2. **Synchronizing Blocks**: Once an intersection is found, the client either:
   - **Rolls Forward**: Processes new blocks as they are added to the blockchain.
   - **Rolls Backward**: Adjusts to a chain reorganization by reverting to a common point when a fork occurs.

---

## Key Concepts

### Finding an Intersection

The protocol enables clients to locate a starting point on the chain. If no common point is found, the cursor remains at the origin. This ensures the client can efficiently begin syncing without duplicating already-processed data.

### Rolling Forward

As the chain progresses, the protocol streams new blocks to the client. Each block includes details such as headers, transactions, and metadata, which the client processes in sequence.

### Rolling Backward

If the chain forks, the protocol provides rollback instructions to the last known common point, ensuring the client can realign with the canonical chain. This rollback mechanism guarantees synchronization consistency, even in the presence of chain reorganizations.

---

## Pipelining

Pipelining allows clients to optimize synchronization by sending multiple requests simultaneously. This reduces latency and maximizes bandwidth utilization, enabling faster block processing. Clients can dynamically adjust the number of pipelined requests to balance performance and resource usage.

---

## Points of Interest

To enable era-specific synchronization, the protocol supports specifying key points of interest, such as the last block of an era or other significant milestones. This feature is particularly useful for applications requiring data from specific parts of the blockchain.

---

## Summary

The chain synchronization protocol provides a robust and efficient mechanism for clients to keep up with the Cardano blockchain. By leveraging features like intersection finding, rolling forward, and pipelining, the protocol ensures consistent, reliable, and performant synchronization for a variety of use cases.

---

## Custom Event Handlers for Blockchain Synchronization

The `ChainSynchronizationMessageHandlers` class defines handlers for two critical blockchain events:

1. **Roll Forward Events**: Triggered when the blockchain moves forward, processing new blocks.
2. **Roll Backward Events**: Triggered when the blockchain rolls back to a previous state (e.g., block reorganization).

---

### Customization

The handlers can be extended to perform custom actions tailored to your application's requirements, such as:

- **Data Persistence**: Save block data to a database or other storage systems for further use or analysis.
- **Processing Blockchain Data**: Implement custom logic based on the incoming blockchain data.

These handlers are triggered every time a block is processed, providing a flexible way to integrate your application's logic with blockchain events.

---

## Example Code

Below is an example implementation of the `ChainSynchronizationMessageHandlers` class:

```csharp
public class ChainSynchronizationMessageHandlers : IChainSynchronizationMessageHandlers
{
    public async Task RollBackwardHandler(Generated.Ogmios.PointOrOrigin point, Generated.Ogmios.TipOrOrigin tip)
    {
        // Custom logic for rollback events
        await Task.CompletedTask;
    }

    public async Task RollForwardHandler(Block block, string blockType, Generated.Tip tip)
    {
        // Custom logic for forward events
        await Task.CompletedTask;
    }
}
```

## Key Points:

- **RollBackwardHandler**: Can be extended to handle rollback events (e.g., saving rollback data or triggering actions).
- **RollForwardHandler**: Can be extended to handle new blocks and act on the returned blockchain data (e.g., process or store block information).
