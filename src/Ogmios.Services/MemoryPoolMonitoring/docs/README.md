# Memory Pool Monitoring

Memory pool monitoring enables real-time interaction and analysis of the Cardano node's mempool. It allows clients to acquire snapshots, query transactions, and manage system resources efficiently.

## Performance-first integration

For bots and low-latency consumers registered via `AddOgmiosServices()`, prefer one of these patterns:

### 1. Orchestrated monitoring (recommended)

`IMemoryPoolMonitoringClientService` runs the correct high-throughput loop for you: **acquire → drain all transactions → wait for next snapshot → repeat**. It uses only `acquireMempool` and `nextTransaction` on the hot path (no extra size/has RPCs).

```csharp
builder.Services.AddOgmiosServices();

// Pass your handler when starting the session (no extra DI registration required).
await memoryPoolMonitoringClientService.RunAsync(
    mempoolContext,
    myHandlers,
    cancellationToken,
    new MemoryPoolMonitoringClientOptions { DeduplicateTransactions = true });
```

Implement `IMemoryPoolMonitoringMessageHandlers`:

- `OnSnapshotAcquiredAsync` — snapshot changed; keep this fast (metrics/logging only).
- `OnTransactionAsync` — each new transaction; filter in memory and enqueue heavy work to background workers.

Set `DeduplicateTransactions = false` when every mempool appearance of the same transaction id must be observed.

`HandlerQueueCapacity` controls backpressure when `OnTransactionAsync` is slower than snapshot draining. `MaxDeduplicationEntries` prevents unbounded deduplication memory in long sessions.

### 2. Direct RPC with extension helpers

If you call `IMemoryPoolMonitoringService` directly, use `MemoryPoolMonitoringExtensions`:

```csharp
// Drain the current snapshot after acquire
await memoryPoolMonitoringService.DrainSnapshotAsync(context, OnTransactionAsync, cancellationToken);

// Full monitoring loop (acquire → drain → repeat)
await memoryPoolMonitoringService.MonitorAsync(context, OnTransactionAsync, cancellationToken);
```

**Always drain until `nextTransaction` returns null** before calling `acquireMempool` again. Re-acquiring early skips transactions still on the snapshot cursor.

### 3. Dedicated WebSocket

Use a **separate `InteractionContext`** for mempool monitoring. Do not share a WebSocket with chain sync — the chain sync listener and blocking mempool RPCs will steal each other's frames.

## Key Operations

1. **Acquire Mempool**: Use `AcquireMempoolAsync` to acquire a snapshot of the mempool. Blocks until the snapshot changes relative to the prior acquire.

2. **List Transactions**:

   - Retrieve transactions sequentially using `NextTransactionAsync` until the cursor is exhausted (null transaction).
   - Check if a specific transaction exists using `HasTransactionAsync` (optional; not needed when draining).

3. **Query Mempool Details**: Fetch mempool size and capacity using `SizeOfMempoolAsync` (metrics only; omit from hot paths).

4. **Release Mempool**: Use `ReleaseMempoolAsync` to release the acquired snapshot and free up resources.

5. **Shutdown**: Close the WebSocket connection gracefully using `ShutdownAsync`.

---

## Key Concepts

### **Stateful Protocol**

Clients must acquire a snapshot using `AcquireMempoolAsync` before performing any queries. Operations like `HasTransactionAsync` and `SizeOfMempoolAsync` are tied to this snapshot.

### **Snapshot Lifecycle**

1. **Acquire**: Start by acquiring the snapshot (`AcquireMempoolAsync`).
2. **Drain**: Call `NextTransactionAsync` in a loop until null.
3. **Repeat**: Acquire again to wait for the next mempool change.
4. **Release** (shutdown): `ReleaseMempoolAsync` then close the socket.

## Error Handling

1. **Must Acquire Mempool First**: Ensure a snapshot is acquired before operations like `HasTransactionAsync` or `SizeOfMempoolAsync`.
2. **Transaction Not Found**: Validate the transaction ID if it's missing from the mempool.
3. **Timeouts**: Mempool acquire uses an infinite client timeout (blocks until the snapshot changes). Query operations use `WebSocketTimeouts.MempoolQuery` (5 seconds by default).

## Summary of Methods

| Method | Purpose | Hot path? |
| ------ | ------- | --------- |
| `AcquireMempoolAsync` | Acquire a mempool snapshot | Yes |
| `NextTransactionAsync` | Advance snapshot cursor | Yes |
| `IMemoryPoolMonitoringClientService.RunAsync` | Acquire + drain loop with handlers | Yes (recommended) |
| `MemoryPoolMonitoringExtensions.MonitorAsync` | Extension-based acquire + drain loop | Yes |
| `HasTransactionAsync` | Point lookup by transaction id | No (targeted checks only) |
| `SizeOfMempoolAsync` | Mempool size/capacity metrics | No |
| `ReleaseMempoolAsync` | Release snapshot | Shutdown |
| `ShutdownAsync` | Close WebSocket | Shutdown |

## Notes

- **Transaction Locality**: Transactions from peers or local submissions may be visible.
- **Transaction Observability**: Not all transactions are guaranteed to be observable due to race conditions.
- **Transaction Status**: Presence in the mempool indicates pending status but does not guarantee inclusion in the ledger.
- **Deduplication**: The same transaction can appear in consecutive snapshots until included or evicted; enable deduplication in `MemoryPoolMonitoringClientOptions` unless you need every appearance.
