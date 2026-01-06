# Milestone 2 - Ledger State Query Implementations & Demonstrations

## Proof of Achievement

OgmiosDotnet now provides complete ledger state query capabilities, exposing all 21 ledger state queries from the Ogmios v6.13 API as typed .NET services, plus 2 lifecycle services for acquiring and releasing ledger state snapshots.

---

## Acceptance Criteria

| Criteria                                                                                         |
| ------------------------------------------------------------------------------------------------ |
| Every ledger state query listed has a typed service with request and response models implemented |
| All queries can be executed against mainnet and return typed results                             |
| Worker example demonstrates at least 5 queries in a running demo                                 |
| Unit tests cover serialization and deserialization across all services and pass                  |
| New OgmiosDotnet version is available with referenced functionality                              |

---

## Ledger State Query Implementations

All 21 ledger state queries from Ogmios v6.13 API are implemented:

| Ogmios Query                           | Service Implementation                         |
| -------------------------------------- | ---------------------------------------------- |
| ledgerState/constitution               | `LedgerStateConstitutionService`               |
| ledgerState/constitutionalCommittee    | `LedgerStateConstitutionalCommitteeService`    |
| ledgerState/delegateRepresentative     | `LedgerStateDelegateRepresentativesService`    |
| ledgerState/dump                       | `LedgerStateDumpService`                       |
| ledgerState/epoch                      | `LedgerStateEpochService`                      |
| ledgerState/eraStart                   | `LedgerStateEraStartService`                   |
| ledgerState/eraSummaries               | `LedgerStateEraSummariesService`               |
| ledgerState/governanceProposals        | `LedgerStateGovernanceProposalsService`        |
| ledgerState/liveStakeDistribution      | `LedgerStateLiveStakeDistributionService`      |
| ledgerState/nonces                     | `LedgerStateNoncesService`                     |
| ledgerState/operationalCertificates    | `LedgerStateOperationalCertificatesService`    |
| ledgerState/projectedRewards           | `LedgerStateProjectedRewardsService`           |
| ledgerState/protocolParameters         | `LedgerStateProtocolParametersService`         |
| ledgerState/proposedProtocolParameters | `LedgerStateProposedProtocolParametersService` |
| ledgerState/rewardAccountSummaries     | `LedgerStateRewardAccountSummariesService`     |
| ledgerState/rewardsProvenance          | `LedgerStateRewardsProvenanceService`          |
| ledgerState/stakePools                 | `LedgerStateStakePoolsService`                 |
| ledgerState/stakePoolsPerformances     | `LedgerStateStakePoolsPerformancesService`     |
| ledgerState/tip                        | `LedgerStateTipService`                        |
| ledgerState/treasuryAndReserves        | `LedgerStateTreasuryAndReservesService`        |
| ledgerState/utxo                       | `LedgerStateUTxOService`                       |

**Additional Lifecycle Services:**

| Service                     | Purpose                                      |
| --------------------------- | -------------------------------------------- |
| `AcquireLedgerStateService` | Acquire a ledger state snapshot for querying |
| `ReleaseLedgerStateService` | Release an acquired ledger state snapshot    |

---

## 1. Service Contracts

**Output:** Interfaces defined for all ledger state query services with consistent signatures and typed parameters.

**Evidence:**

**Ledger State Query Interfaces:**

- All 22 ledger query interfaces: [`LedgerStateQueries/Contracts/`](https://github.com/ItsDaveB/OgmiosDotnet/tree/main/src/Ogmios.Services/LedgerStateQueries/Contracts)

Key interfaces include:

- [`IAcquireLedgerStateService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/Contracts/IAcquireLedgerStateService.cs)
- [`IReleaseLedgerStateService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/Contracts/IReleaseLedgerStateService.cs)
- [`ILedgerStateTipService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/Contracts/ILedgerStateTipService.cs)
- [`ILedgerStateEpochService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/Contracts/ILedgerStateEpochService.cs)
- [`ILedgerStateProtocolParametersService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/Contracts/ILedgerStateProtocolParametersService.cs)
- [`ILedgerStateGovernanceProposalsService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/Contracts/ILedgerStateGovernanceProposalsService.cs)
- [`ILedgerStateTreasuryAndReservesService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/Contracts/ILedgerStateTreasuryAndReservesService.cs)

---

## 2. Ledger State Query Implementations

**Output:** Working implementations for all 22 ledger state services (20 query services + 2 lifecycle services).

**Evidence:**

- All service implementations: [`LedgerStateQueries/`](https://github.com/ItsDaveB/OgmiosDotnet/tree/main/src/Ogmios.Services/LedgerStateQueries)

**Lifecycle Services:**

| Service                                                                                                                                                  | Purpose                                      |
| -------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------- |
| [`AcquireLedgerStateService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/AcquireLedgerStateService.cs) | Acquire a ledger state snapshot for querying |
| [`ReleaseLedgerStateService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/ReleaseLedgerStateService.cs) | Release an acquired ledger state snapshot    |

**Query Services:**

| Service                                                                                                                                                                                        | Ogmios Query                                |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| [`LedgerStateTipService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateTipService.cs)                                               | queryLedgerState/tip                        |
| [`LedgerStateEpochService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateEpochService.cs)                                           | queryLedgerState/epoch                      |
| [`LedgerStateEraStartService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateEraStartService.cs)                                     | queryLedgerState/eraStart                   |
| [`LedgerStateEraSummariesService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateEraSummariesService.cs)                             | queryLedgerState/eraSummaries               |
| [`LedgerStateProtocolParametersService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateProtocolParametersService.cs)                 | queryLedgerState/protocolParameters         |
| [`LedgerStateProposedProtocolParametersService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateProposedProtocolParametersService.cs) | queryLedgerState/proposedProtocolParameters |
| [`LedgerStateConstitutionService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateConstitutionService.cs)                             | queryLedgerState/constitution               |
| [`LedgerStateConstitutionalCommitteeService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateConstitutionalCommitteeService.cs)       | queryLedgerState/constitutionalCommittee    |
| [`LedgerStateDelegateRepresentativesService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateDelegateRepresentativesService.cs)       | queryLedgerState/delegateRepresentatives    |
| [`LedgerStateGovernanceProposalsService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateGovernanceProposalsService.cs)               | queryLedgerState/governanceProposals        |
| [`LedgerStateStakePoolsService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateStakePoolsService.cs)                                 | queryLedgerState/stakePools                 |
| [`LedgerStateStakePoolsPerformancesService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateStakePoolsPerformancesService.cs)         | queryLedgerState/stakePoolsPerformances     |
| [`LedgerStateLiveStakeDistributionService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateLiveStakeDistributionService.cs)           | queryLedgerState/liveStakeDistribution      |
| [`LedgerStateRewardAccountSummariesService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateRewardAccountSummariesService.cs)         | queryLedgerState/rewardAccountSummaries     |
| [`LedgerStateProjectedRewardsService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateProjectedRewardsService.cs)                     | queryLedgerState/projectedRewards           |
| [`LedgerStateRewardsProvenanceService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateRewardsProvenanceService.cs)                   | queryLedgerState/rewardsProvenance          |
| [`LedgerStateNoncesService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateNoncesService.cs)                                         | queryLedgerState/nonces                     |
| [`LedgerStateOperationalCertificatesService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateOperationalCertificatesService.cs)       | queryLedgerState/operationalCertificates    |
| [`LedgerStateTreasuryAndReservesService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateTreasuryAndReservesService.cs)               | queryLedgerState/treasuryAndReserves        |
| [`LedgerStateUTxOService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateUTxOService.cs)                                             | queryLedgerState/utxo                       |
| [`LedgerStateDumpService.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateDumpService.cs)                                             | queryLedgerState/dump                       |

---

## 3. Typed Error Handling

**Output:** Comprehensive exception classes for ledger state query error scenarios.

**Evidence:**

- Exceptions: [`LedgerStateQueryExceptions.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/LedgerStateQueryExceptions.cs)

| Exception                              | Purpose                                                               |
| -------------------------------------- | --------------------------------------------------------------------- |
| `AcquireLedgerStateFailedException`    | Thrown when acquiring a ledger state snapshot fails                   |
| `MustAcquireLedgerStateFirstException` | Thrown when querying without an active acquisition                    |
| `LedgerStateQueryFailedException`      | Generic failure when a ledger state query returns an error            |
| `LedgerStateAcquiredExpiredException`  | Thrown when the acquired ledger state snapshot has expired            |
| `LedgerStateQueryEraMismatchException` | Thrown when querying era-specific data unavailable in the current era |

---

## 4. Worker Example Update

**Output:** Demonstrates ledger state query services in action with at least 5 queries.

**Evidence:**

- Worker: [`OgmiosWorker.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/OgmiosWorker.cs)
- Documentation: [`Worker/docs/README.md`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/docs/README.md)

The worker demonstrates the following ledger state queries:

1. **acquireLedgerState** - Acquire a ledger state snapshot
2. **queryLedgerState/tip** - Query current ledger tip (slot, block ID)
3. **queryLedgerState/epoch** - Query current epoch number
4. **queryLedgerState/protocolParameters** - Query active protocol parameters (min fee coefficient, version)
5. **queryLedgerState/treasuryAndReserves** - Query treasury and reserves balances in lovelace
6. **queryLedgerState/governanceProposals** - Query active governance proposals count
7. **queryLedgerState/stakePools** - Query stake pool details with filtering by pool ID (demonstrates `params` usage with DAVE pool: `pool1t6n7rysk6wzm9wqxda6zxpzmm3j6256fs3mp06dc26n6503hhj4`)
8. **releaseLedgerState** - Release the acquired snapshot

**Example Output (Live Mainnet - January 2026):**

```
--- Ledger State Query Demonstration ---
[ServerHealth] Server tip: Slot 176169894
[AcquireLedgerState] Ledger state acquired
[QueryLedgerState/Epoch] Current Epoch: 605
[QueryLedgerState/ProtocolParameters] Min Fee Coefficient: 44, Version: 10.0
[QueryLedgerState/TreasuryAndReserves] Treasury: 1672567635217344 lovelace
[QueryLedgerState/GovernanceProposals] Active Governance Proposals: 5
[QueryLedgerState/StakePools] ══════════════════════════════════════════════════════════════
[QueryLedgerState/StakePools]   DAVE Stake Pool - Live Mainnet Data
[QueryLedgerState/StakePools] ══════════════════════════════════════════════════════════════
[QueryLedgerState/StakePools]   Pool ID:        pool1t6n7rysk6wzm9wqxda6zxpzmm3j6256fs3mp06dc26n6503hhj4
[QueryLedgerState/StakePools]   VRF Key Hash:   103dabdae2afee7a3c345ebf1b67c834db1ad1ecfafe593ce687f9ed0d5af046
[QueryLedgerState/StakePools]   Pledge:         2,000 ADA
[QueryLedgerState/StakePools]   Fixed Cost:     170 ADA
[QueryLedgerState/StakePools]   Margin:         1/100 (1%)
[QueryLedgerState/StakePools]   Reward Account: stake1uyu3y65jfjpyg7z2ul7sdzued3lvnadt2fg4sta3spreccqac626w
[QueryLedgerState/StakePools] ══════════════════════════════════════════════════════════════
[ReleaseLedgerState] Ledger state released
--- Ledger State Query Demonstration Complete ---
```

---

## 5. Unit Tests

**Output:** Tests covering ledger state query serialization/deserialization, request/response mapping, and success/failure paths.

**Evidence:**

- Ledger State Query Tests: [`LedgerStateQueryTests.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Tests/LedgerStateQueries/LedgerStateQueryTests.cs)
- Test Report: [`test-report.md`](./test-report.md)

**Ledger State Query Test Coverage:**

| Test  | Validates                                                      | Result |
| ----- | -------------------------------------------------------------- | ------ |
| TC001 | AcquireLedgerState WebSocket connection failure                | Passed |
| TC002 | AcquireLedgerState success response parsing                    | Passed |
| TC003 | LedgerStateTip success response parsing                        | Passed |
| TC004 | LedgerStateTip MustAcquireFirst error handling                 | Passed |
| TC005 | LedgerStateEpoch success response parsing                      | Passed |
| TC006 | LedgerStateProtocolParameters success response parsing         | Passed |
| TC007 | LedgerStateTreasuryAndReserves success response parsing        | Passed |
| TC008 | LedgerStateGovernanceProposals success response parsing        | Passed |
| TC009 | LedgerStateStakePoolsPerformances success response parsing     | Passed |
| TC010 | LedgerStateConstitution success response parsing               | Passed |
| TC011 | LedgerStateConstitutionalCommittee success response parsing    | Passed |
| TC012 | LedgerStateDelegateRepresentatives success response parsing    | Passed |
| TC013 | LedgerStateDump success response parsing                       | Passed |
| TC014 | LedgerStateEraStart success response parsing                   | Passed |
| TC015 | LedgerStateEraSummaries success response parsing               | Passed |
| TC016 | LedgerStateLiveStakeDistribution success response parsing      | Passed |
| TC017 | LedgerStateNonces success response parsing                     | Passed |
| TC018 | LedgerStateOperationalCertificates success response parsing    | Passed |
| TC019 | LedgerStateProjectedRewards success response parsing           | Passed |
| TC020 | LedgerStateProposedProtocolParameters success response parsing | Passed |
| TC021 | LedgerStateRewardAccountSummaries success response parsing     | Passed |
| TC022 | LedgerStateRewardsProvenance success response parsing          | Passed |
| TC023 | LedgerStateStakePools success response parsing                 | Passed |
| TC024 | LedgerStateUTxO success response parsing                       | Passed |
| TC025 | ReleaseLedgerState success response parsing                    | Passed |

**Summary:** 25/25 tests passing. Coverage includes connection failures, response parsing, typed error handling, and successful operation scenarios for all ledger state query services.

---

## 6. Dependency Injection Registration

**Output:** All ledger state query services registered in the service collection for DI with opt-in helper method.

**Evidence:**

- DI Registration: [`ServiceCollectionExtensions.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/Extensions/ServiceCollectionExtensions.cs)

All 22 services are registered as singletons via the `AddLedgerStateQueryServices()` extension method. Consumers can opt-in to ledger state query functionality independently:

```csharp
// Option 1: Register all Ogmios services (includes ledger state queries)
services.AddOgmiosServices();

// Option 2: Register only ledger state query services (opt-in)
services.RegisterCoreServices();
services.AddLedgerStateQueryServices();
```

This modular approach allows consumers to include only the services they need, reducing overhead for applications that don't require chain synchronization or mempool monitoring.

---

## 7. Documentation

**Output:** Updated documentation covering ledger state query functionality.

**Evidence:**

- Main README: [`README.md`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/README.md)
- Module Documentation: [`LedgerStateQueries/docs/README.md`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/LedgerStateQueries/docs/README.md)

---

## 8. Published Package

**Output:** Updated packages released with ledger state query support.

**Evidence:**

- **OgmiosDotnetClient.Schema v6.13.1.3**: https://www.nuget.org/packages/OgmiosDotnetClient.Schema/6.13.1.3
- **OgmiosDotnetClient.Services v6.13.1.3**: https://www.nuget.org/packages/OgmiosDotnetClient.Services/6.13.1.3

Both packages include v6.13 schema support and all 22 ledger state query services.

---

## 9. Video Demonstration

**Output:** End-to-end recorded YouTube demo showing a worker consuming several different queries in sequence and outputting typed results.

**Evidence:**

- **YouTube Demo**: [TODO: INSERT YOUTUBE LINK HERE]

The video demonstrates:

- Worker application connecting to live Cardano mainnet via Ogmios
- Acquiring ledger state snapshot
- Executing multiple ledger state queries in sequence
- Outputting typed results including DAVE stake pool details
- Releasing ledger state snapshot
- All queries returning typed, strongly-structured .NET objects

---

## Summary

The OgmiosDotnet library now provides complete ledger state query capabilities for the Cardano ecosystem, covering all 21 Ogmios v6.13 ledger state queries plus lifecycle management. The implementation includes:

- 21 query services + 2 lifecycle services (23 total)
- 5 custom exception types for error handling
- Comprehensive unit test coverage (25 tests)
- Worker example demonstrating 7+ queries against live mainnet
- Full dependency injection support with opt-in registration
- Updated documentation

The functionality is production-ready and available via published NuGet packages.

---

## Evidence Links Summary

| Evidence Type          | Link                                                                                                              |
| ---------------------- | ----------------------------------------------------------------------------------------------------------------- |
| GitHub Repository      | https://github.com/ItsDaveB/OgmiosDotnet                                                                          |
| Worker Example         | [`OgmiosWorker.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Example.Worker/OgmiosWorker.cs) |
| Test Report            | [`test-report.md`](./test-report.md)                                                                              |
| NuGet Schema Package   | https://www.nuget.org/packages/OgmiosDotnetClient.Schema                                                          |
| NuGet Services Package | https://www.nuget.org/packages/OgmiosDotnetClient.Services                                                        |
| Milestone Report       | This document                                                                                                     |
| YouTube Demo           | [TODO: INSERT YOUTUBE LINK HERE]                                                                                  |
