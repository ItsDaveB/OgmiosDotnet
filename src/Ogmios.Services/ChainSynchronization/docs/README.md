# Chain Synchronization

Chain synchronization is a stateful protocol that enables clients to efficiently synchronize with the Cardano blockchain. By maintaining a cursor to track synchronization progress, clients can follow the chain, handle reorganizations, and resume syncing after disconnections.

## Key Operations

1. **Find Intersection**: Establish a common synchronization point between the client’s local chain and the blockchain node. The client can provide potential points or start from the origin.

2. **Synchronize Blocks**:
   - **Roll Forward**: Process new blocks as they are added to the chain.
   - **Roll Backward**: Handle chain reorganizations by reverting to the last known common point.

## Key Concepts

### **Finding an Intersection**

Locate a starting point on the blockchain for synchronization. If no intersection is found, synchronization begins from the origin. This ensures efficient syncing without reprocessing existing data.

### **Rolling Forward**

As new blocks are added to the chain:

- The protocol streams these blocks sequentially.
- Clients process block details such as headers, transactions, and metadata.

### **Rolling Backward**

When a chain fork occurs:

- The protocol reverts the client’s synchronization point to the last known common block.
- This guarantees alignment with the canonical chain and ensures data consistency.

## Pipelining

Pipelining optimizes synchronization by allowing clients to send multiple requests simultaneously:

- **Advantages**: Reduced latency and improved bandwidth utilization.
- **Dynamic Adjustment**: Clients can adjust the number of pipelined requests to balance resource usage and performance.

## Points of Interest

Clients can specify key synchronization points, such as:

- **Era Transitions**: Points marking the end of an era.
- **Significant Milestones**: Blocks of interest for specific applications.

This feature is particularly useful for era-specific or milestone-driven data retrieval.

## Event Handling

### **Roll Forward Events**

Triggered when the blockchain progresses to new blocks. Clients process the new block data to update their state.

### **Roll Backward Events**

Triggered when the blockchain rolls back to a previous state (e.g., due to a fork). Clients revert their synchronization point accordingly.

## Customization

The `ChainSynchronizationMessageHandlers` class provides customizable handlers for blockchain events:

- **Roll Forward**: Extend to include actions such as persisting block data or triggering application-specific workflows.
- **Roll Backward**: Implement logic to handle reorganizations, such as clearing unconfirmed transactions or realigning data.

### Example Use Cases:

1. **Data Persistence**: Save block data to a database for analytics or audits.
2. **Custom Logic**: Integrate application-specific behavior based on new or reorganized blockchain data.

## Summary

Chain synchronization offers a robust and efficient mechanism for keeping clients aligned with the Cardano blockchain. By leveraging features like intersection finding, rolling forward, rolling backward, and pipelining, clients can achieve reliable and performant synchronization tailored to their needs.

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
