# Memory Pool Monitoring

Memory pool monitoring enables real-time interaction and analysis of the Cardano node's mempool. It allows clients to acquire snapshots, query transactions, and manage system resources efficiently.

---

## Key Operations

1. **Acquire Mempool**: Use `AcquireMempoolAsync` to acquire a snapshot of the mempool. This ensures consistent data and prevents duplicate transaction processing.

2. **List Transactions**:

   - Retrieve transactions sequentially using `NextTransactionAsync`.
   - Check if a specific transaction exists using `HasTransactionAsync`.

3. **Query Mempool Details**: Fetch mempool size, number of transactions, and capacity using `SizeOfMempoolAsync`.

4. **Release Mempool**: Use `ReleaseMempoolAsync` to release the acquired snapshot and free up resources.

5. **Shutdown**: Close the WebSocket connection gracefully using `ShutdownAsync`.

---

## Key Concepts

### **Stateful Protocol**

Clients must acquire a snapshot using `AcquireMempoolAsync` before performing any queries. Operations like `HasTransactionAsync` and `SizeOfMempoolAsync` are tied to this snapshot.

### **Snapshot Lifecycle**

1. **Acquire**: Start by acquiring the snapshot (`AcquireMempoolAsync`).
2. **Query**: Perform operations such as listing transactions or checking the mempool size.
3. **Release**: Once done, release the snapshot (`ReleaseMempoolAsync`) to free resources.

---

## Error Handling

1. **Must Acquire Mempool First**: Ensure a snapshot is acquired before operations like `HasTransactionAsync` or `SizeOfMempoolAsync`.
2. **Transaction Not Found**: Validate the transaction ID if it’s missing from the mempool.
3. **Timeouts**: Increase the timeout or verify network connectivity if operations take too long.

---

## Summary of Methods

| Method                 | Purpose                        | Notes                                   |
| ---------------------- | ------------------------------ | --------------------------------------- |
| `AcquireMempoolAsync`  | Acquire a mempool snapshot.    | Required for all subsequent operations. |
| `HasTransactionAsync`  | Check if a transaction exists. | Operates on the acquired snapshot.      |
| `NextTransactionAsync` | Retrieve the next transaction. | Processes sequentially.                 |
| `SizeOfMempoolAsync`   | Get mempool size and capacity. | Requires an active snapshot.            |
| `ReleaseMempoolAsync`  | Release the acquired snapshot. | Frees resources for other clients.      |
| `ShutdownAsync`        | Gracefully close WebSocket.    | Ensure all queries are completed first. |

---

## Notes

- **Transaction Locality**: Transactions from peers or local submissions may be visible.
- **Transaction Observability**: Not all transactions are guaranteed to be observable due to race conditions.
- **Transaction Status**: Presence in the mempool indicates pending status but does not guarantee inclusion in the ledger.
