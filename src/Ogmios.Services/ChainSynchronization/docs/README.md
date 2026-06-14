# Chain Synchronization

Chain synchronization is a stateful protocol that enables clients to efficiently synchronize with the Cardano blockchain. By maintaining a cursor to track synchronization progress, clients can follow the chain, handle reorganizations, and resume syncing after disconnections.

## Performance-first integration

Consumers using `AddOgmiosServices()` receive blocks through `IChainSynchronizationMessageHandlers`. Throughput is dominated by handler latency.

### Keep handlers fast

`RollForwardHandler` and `RollBackwardHandler` run on the chain sync consumer thread. **Return quickly** — filter in memory, enqueue to a bounded `Channel`, and process DB/network work on background workers. Slow handlers cause the bounded queue (1000 blocks) to fill and the bot to fall behind.

### Pipeline stays full during slow handlers

The client replenishes pipelined `nextBlock` requests **before** invoking your handler, so the default `inFlight=100` window stays saturated even when handlers do heavy work.

### Rate limiting during catch-up

Pass `maxBlocksPerSecond` to `ResumeAsync`. Values `<= 0` mean no limit. Positive values throttle how fast new `nextBlock` requests are sent after each processed block — useful to protect downstream systems when syncing from origin.

### Dedicated WebSocket

Use one `InteractionContext` per concurrent Ogmios protocol. Do not share a socket between chain sync and mempool monitoring.

## Key Operations

1. **Find Intersection**: Establish a common synchronization point between the client's local chain and the blockchain node. The client can provide potential points or start from the origin.

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

- The protocol reverts the client's synchronization point to the last known common block.
- This guarantees alignment with the canonical chain and ensures data consistency.

## Pipelining

Pipelining optimizes synchronization by allowing clients to send multiple requests simultaneously:

- **Default `inFlight`**: 100 concurrent `nextBlock` requests primed at session start, replenished after each dequeued response.
- **Advantages**: Reduced latency and improved bandwidth utilization.
- **Dynamic Adjustment**: Pass a lower `inFlight` if memory is constrained; raise it for faster catch-up on high-bandwidth links.

## Points of Interest

Clients can specify key synchronization points, such as:

- **Era Transitions**: Points marking the end of an era.
- **Significant Milestones**: Blocks of interest for specific applications.

This feature is particularly useful for era-specific or milestone-driven data retrieval.

## Event Handling

### **Roll Forward Events**

Triggered when the blockchain progresses to new blocks. Clients process the new block data to update their state.

### **Roll Backward Events**

Triggered when the blockchain rolls back to a previous state (e.g., due to a fork). Clients revert their synchronization point accordingly. Process rollbacks on the same ordered pipeline as roll-forwards (or handle synchronously in the handler before returning).

## Customization

Register `IChainSynchronizationMessageHandlers` alongside `AddOgmiosServices()`:

```csharp
builder.Services.AddOgmiosServices();
builder.Services.AddSingleton<IChainSynchronizationMessageHandlers, ChainSynchronizationMessageHandlers>();

await chainSynchronizationClientService.ResumeAsync(
    [chainContext],
    maxBlocksPerSecond: ogmiosConfiguration.MaxBlocksPerSecond,
    inFlight: 100,
    cancellationToken);
```

### Example handler (fast path)

```csharp
public class ChainSynchronizationMessageHandlers : IChainSynchronizationMessageHandlers
{
    private readonly Channel<BlockWork> _work = Channel.CreateBounded<BlockWork>(500);

    public Task RollBackwardHandler(Generated.Ogmios.PointOrOrigin point, Generated.Ogmios.TipOrOrigin tip)
    {
        _work.Writer.TryWrite(BlockWork.Rollback(point, tip));
        return Task.CompletedTask;
    }

    public Task RollForwardHandler(Block block, string blockType, Generated.Tip tip)
    {
        _work.Writer.TryWrite(BlockWork.RollForward(block, blockType, tip));
        return Task.CompletedTask;
    }
}
```

## Summary

Chain synchronization offers a robust and efficient mechanism for keeping clients aligned with the Cardano blockchain. By leveraging pipelining, bounded queues, handler offload, and optional `maxBlocksPerSecond` throttling, clients can achieve reliable and performant synchronization tailored to their needs.

## Key Points

- **RollBackwardHandler**: Handle reorgs; keep synchronous if rollback state must be visible before the next forward.
- **RollForwardHandler**: Must return quickly; the library already parses blocks from UTF-8 and maintains the pipelined window.
- **Separate sockets**: Chain sync and mempool require different `InteractionContext` instances.
