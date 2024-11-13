# Memory Pool Monitoring

Memory pool monitoring provides a robust mechanism for interacting with and analyzing the Cardano node's mempool. By acquiring snapshots, querying transactions, and utilizing consistent data handling, clients can effectively manage transactions in real-time while optimizing bandwidth and system resources.

---

## Overview

The memory pool monitoring protocol facilitates the following key operations:

1. **Acquire Mempool Snapshot**: Clients must acquire a snapshot of the mempool to perform any subsequent queries. Once acquired, the snapshot ensures consistent data, preventing duplicate transactions in the same snapshot.
2. **List Transactions**: Transactions in the mempool can be retrieved sequentially using `nextTransaction`, or checked for existence with `hasTransaction`.

3. **Query Mempool Details**: The protocol also provides details about the mempool, such as:

   - Current size (in bytes).
   - Number of transactions.
   - Total capacity (defined by network parameters).

4. **Retrieve Full Transactions**: Optionally, clients can request complete transaction data, including all details, instead of just transaction IDs.

---

## Key Concepts

### **Stateful Protocol**

The mempool monitoring protocol maintains an explicit state managed by the client. Clients must acquire a snapshot to perform any actions. Subsequent queries, like `nextTransaction` or `sizeOfMempool`, operate on this snapshot, ensuring consistent results.

### **Transaction Queries**

- **Sequential Listing**: Use `nextTransaction` repeatedly to retrieve all transactions in the snapshot.
- **Specific Check**: Use `hasTransaction` to check for the presence of a specific transaction.

### **Snapshot Acquisition**

The `acquireMempool` operation blocks until a new snapshot becomes available. This eliminates the need for active polling and ensures clients only retrieve updated mempool states.

### **Size and Capacity**

The protocol provides information on:

- Current mempool size (in bytes).
- Number of transactions.
- Capacity, which is dynamically defined (e.g., twice the block size).

---

## Important Notes

1. **Transaction Locality**: The protocol allows access to transactions submitted locally by the client or from peers in block-producing nodes.

2. **Transaction Observability**: The protocol cannot guarantee observation of all transactions. Race conditions may result in missed transactions during snapshot updates.

3. **Transaction Status**: The presence of a transaction in the mempool means it is pending, but its absence does not guarantee ledger inclusion. Transactions can be discarded or lost due to reorganization.

---
