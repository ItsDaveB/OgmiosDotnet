# Project Close-out Report

## Name of Project and Project URL on IdeaScale/Fund

**Name:** OgmiosDotnet - Transaction & Ledger State Queries  
**URL:** [Project Catalyst - OgmiosDotnet Ledger State Queries](https://milestones.projectcatalyst.io/projects/1400090)

---

## Your Project Number

**Project Number:** 1400090

---

## Name of Project Manager

**Name:** Dave

---

## Date Project Completed

**Completion Date:** January 2026

---

## List of Challenge KPIs and How the Project Addressed Them

| Challenge KPI                             | How the Project Addressed It                                                                                                                                                                 |
| ----------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **Enhance developer tooling for Cardano** | Extended OgmiosDotnet with 2 transaction services (Submit & Evaluate) and 21 ledger state query services, providing comprehensive .NET tooling for Cardano developers.                       |
| **Improve access to blockchain data**     | Implemented all Ogmios v6.13 ledger state queries, enabling .NET developers to query epoch data, protocol parameters, treasury/reserves, governance proposals, stake pool details, and more. |
| **Support Cardano governance (CIP-1694)** | Added governance-specific queries including `governanceProposals`, `constitution`, `constitutionalCommittee`, and `delegateRepresentatives` to support the Conway era.                       |
| **Enable transaction capabilities**       | Delivered transaction evaluation (for execution unit estimation) and transaction submission services, enabling dApp developers to build complete transaction workflows in .NET.              |

---

## List of Project KPIs and How the Project Addressed Them

| Project KPI                     | Target        | Achieved                    | Evidence                                                                    |
| ------------------------------- | ------------- | --------------------------- | --------------------------------------------------------------------------- |
| **Ledger State Query Services** | 21 queries    | ✅ 21 queries implemented   | All Ogmios v6.13 ledger state queries available                             |
| **Transaction Services**        | 2 services    | ✅ 2 services implemented   | Submit and Evaluate transactions                                            |
| **Lifecycle Services**          | 2 services    | ✅ 2 services implemented   | Acquire/Release ledger state snapshots                                      |
| **Unit Test Coverage**          | Comprehensive | ✅ 33 tests, 100% pass rate | All services have serialization/deserialization tests                       |
| **Documentation**               | Complete      | ✅ Full documentation       | README, module docs, and inline code comments                               |
| **NuGet Package**               | Published     | ✅ v6.13.1.3 published      | [NuGet Package](https://www.nuget.org/packages/OgmiosDotnetClient.Services) |

---

## Key Achievements

### Technical Deliverables

- **21 Ledger State Query Services**: Complete implementation of all Ogmios v6.13 ledger state queries with typed request/response models
- **Transaction Evaluation Service**: Evaluate signed transactions to estimate execution units and detect rejections before submission
- **Transaction Submission Service**: Submit signed transactions to the Cardano node for mempool inclusion
- **Conway Era Governance Support**: Full support for CIP-1694 governance queries including proposals, constitution, and DReps
- **Typed Error Handling**: 7 custom exception types for robust error handling

### Collaboration and Engagement

- **Demeter.run Partnership**: Continued collaboration with Demeter.run for hosted Ogmios access, demonstrated in all videos
- **Open Source Contribution**: All code is open source under MIT license, encouraging community contributions
- **Community Documentation**: Comprehensive documentation for each module to support developer adoption
- **Real-World Demonstrations**: Live mainnet transactions (Minswap DEX interactions) showcased in demo videos

---

## Impact

| Metric                   | Value    | Description                                              |
| ------------------------ | -------- | -------------------------------------------------------- |
| **NuGet Downloads**      | Growing  | OgmiosDotnetClient.Services package publicly available   |
| **GitHub Repository**    | Public   | Open source repository with full commit history          |
| **Services Implemented** | 25 total | 21 ledger queries + 2 transaction + 2 lifecycle services |
| **Test Coverage**        | 100%     | 33 unit tests covering all services                      |
| **Mainnet Verified**     | Yes      | Real transactions submitted and verified on CardanoScan  |

### Measurable Outcomes

- Successfully submitted real Minswap DEX transactions to Cardano mainnet
- Evaluated smart contract execution units for Minswap validator
- Queried live mainnet data, treasury, and protocol parameters
- Retrieved DAVE stake pool details and governance proposals from mainnet

---

## Why is This Project Important?

OgmiosDotnet bridges a critical gap in the Cardano developer ecosystem by bringing first-class .NET support to Cardano node interaction. This matters because:

1. **Enterprise Adoption**: .NET is one of the most widely used enterprise development platforms. By providing native .NET tooling, we open Cardano to the vast ecosystem of .NET developers and enterprises.

2. **Complete Functionality**: With transaction submission, evaluation, and all 21 ledger state queries, .NET developers now have feature parity with other language ecosystems for interacting with Cardano.

3. **Conway Era Ready**: Full support for CIP-1694 governance queries means developers can build governance-aware applications today.

4. **Production Quality**: The library is designed with dependency injection, typed models, and comprehensive error handling—patterns that enterprise developers expect.

5. **Lowering Barriers**: Simple integration with a single line of code (`AddOgmiosServices()`) means developers can get started quickly without deep blockchain knowledge.

The Cardano community should be excited because this project significantly expands who can build on Cardano, bringing millions of .NET developers into the ecosystem with production-ready tooling.

---

## Links to Other Relevant Project Sources or Documents

### Code & Packages

| Resource                 | Link                                                            |
| ------------------------ | --------------------------------------------------------------- |
| GitHub Repository        | https://github.com/ItsDaveB/OgmiosDotnet                        |
| NuGet Package (Services) | https://www.nuget.org/packages/OgmiosDotnetClient.Services      |
| NuGet Package (Schema)   | https://www.nuget.org/packages/OgmiosDotnetClient.Schema        |
| GitHub Release v6.13.1.3 | https://github.com/ItsDaveB/OgmiosDotnet/releases/tag/v6.13.1.3 |

### Documentation

| Resource                    | Link                                                                                                        |
| --------------------------- | ----------------------------------------------------------------------------------------------------------- |
| Main README                 | https://github.com/ItsDaveB/OgmiosDotnet/blob/main/README.md                                                |
| Ledger State Queries Docs   | https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/docs/README.md    |
| Transaction Evaluation Docs | https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/TransactionEvaluation/docs/README.md |
| Transaction Submission Docs | https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/TransactionSubmission/docs/README.md |

### Reports

| Resource             | Link                                                 |
| -------------------- | ---------------------------------------------------- |
| Test Report          | [test-report.md](./test-report.md)                   |
| Proof of Achievement | [proof-of-achievement.md](./proof-of-achievement.md) |
| Demo Video           | [demo-videos.md](./demo-videos.md)                   |

### Example Code

| Example                        | Link                                                                                                                  |
| ------------------------------ | --------------------------------------------------------------------------------------------------------------------- |
| Transaction Evaluation Example | https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/Examples/TransactionEvaluationExample.cs |
| Transaction Submission Example | https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/Examples/TransactionSubmissionExample.cs |
| Ledger State Queries Example   | https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/Examples/LedgerStateQueriesExample.cs    |

---

## Link to Close-out Video

**YouTube Link:** https://youtu.be/pRiY4hZm7S4

### Video Contents (2-5 minutes)

The close-out video demonstrates:

1. **Transaction Evaluation**:

   - Evaluating a Minswap DEX Cancel Order transaction
   - Smart contract validator execution unit calculation
   - Returns CPU steps and memory units for the Plutus validator

2. **Transaction Submission**:

   - Submitting a real signed transaction to Cardano mainnet
   - DEX order placement: 5 ADA → HOSKY token swap
   - Returns transaction ID upon successful submission

3. **On-Chain Verification**:

   - Viewing the submitted transaction in CardanoScan explorer
   - Confirming the transaction was successfully included on-chain

4. **Ledger State Queries**:

   - Worker application connecting to Cardano mainnet via Demeter.run hosted Ogmios
   - Acquiring ledger state snapshot at current tip
   - Querying current epoch, protocol parameters, treasury & reserves
   - Querying governance proposals and stake pool details (DAVE pool)
   - Live mainnet data displayed in console output

5. **Project Structure & Code Walkthrough**:
   - Schema definitions and typed representations of Ogmios v6.13 functionality
   - Service interfaces and implementations
   - Example files demonstrating transaction and query usage
   - Documentation structure

---

### What Went Well

1. **Ogmios API Stability**: The Ogmios v6.13 API is well-documented and stable, making implementation straightforward
2. **Dependency Injection Design**: The modular service registration approach allows consumers to opt-in to specific functionality
3. **Test-Driven Development**: Writing tests alongside implementations caught serialization edge cases early

### Areas for Improvement

1. **Connection Pooling**: Future versions could implement WebSocket connection pooling for high-throughput scenarios
2. **Retry Policies**: Adding configurable retry policies with exponential backoff for transient failures
3. **Metrics & Observability**: Integrating with OpenTelemetry for distributed tracing and metrics

---
