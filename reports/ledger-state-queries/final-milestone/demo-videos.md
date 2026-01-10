# Final Milestone - Video Demonstrations

## Final Closeout Video

**YouTube Link**: https://youtu.be/pRiY4hZm7S4

### Video Contents

The final closeout video demonstrates the complete functionality delivered across all milestones:

1. **Transaction Evaluation - Minswap DEX Swap Cancel**

   - Evaluates a real Minswap DEX Aggregator Cancel Order transaction
   - Demonstrates smart contract validator execution unit calculation
   - Returns CPU steps and memory units for the validator
   - Uses CBOR-encoded transaction against Cardano mainnet

2. **Transaction Submission - Minswap DEX ADA to HOSKY Swap**

   - Submits a real signed transaction to Cardano mainnet
   - DEX order placement: 5 ADA → HOSKY token swap
   - Returns transaction ID upon successful submission
   - Provides CardanoScan link for on-chain verification

3. **Ledger State Queries**

   - Worker application connecting to Cardano mainnet via Demeter.run hosted Ogmios
   - Acquiring ledger state snapshot at current tip
   - Querying current epoch, protocol parameters, treasury & reserves
   - Querying governance proposals
   - Stake pool details retrieval (DAVE pool)
   - Live mainnet data displayed in console output

4. **File Structure**
   - Schema definitions
   - Documentation
   - Examples
   - Service Interfaces & Implementations

### Example Files

The demo uses the following example implementations:

- **Transaction Evaluation**: [`TransactionEvaluationExample.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/Examples/TransactionEvaluationExample.cs)
- **Transaction Submission**: [`TransactionSubmissionExample.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/Examples/TransactionSubmissionExample.cs)
- **Ledger State Queries**: [`LedgerStateQueriesExample.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/Examples/LedgerStateQueriesExample.cs)

---
