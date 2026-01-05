# Milestone 2 - Ledger State Query Implementations & Demonstrations

## Proof of Achievement

OgmiosDotnet now provides complete ledger state query capabilities, exposing all 21 ledger state queries from the Ogmios v6.13 API as typed .NET services.

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

**Output:** Working implementations for all 21 Ogmios ledger state queries plus lifecycle services.

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

**Example Output:**

```
--- Ledger State Query Demonstration ---
Querying acquireLedgerState...
  Ledger state acquired at point: {...}
Querying queryLedgerState/tip...
  Ledger Tip: Slot 123456789, Block ID abc123...
Querying queryLedgerState/epoch...
  Current Epoch: 530
Querying queryLedgerState/protocolParameters...
  Min Fee Coefficient: 44, Version: 10.0
Querying queryLedgerState/treasuryAndReserves...
  Treasury: 1500000000000000 lovelace, Reserves: 8000000000000000 lovelace
Querying queryLedgerState/governanceProposals...
  Active Governance Proposals: 5
Querying queryLedgerState/stakePools (filtered by DAVE pool ID)...
  [DAVE Pool]
    Pool ID: pool1t6n7rysk6wzm9wqxda6zxpzmm3j6256fs3mp06dc26n6503hhj4
    Margin: 1/50
    Pledge: 100000000000 lovelace
    Cost: 340000000 lovelace
    Owners: 1
    Relays: 2
Querying releaseLedgerState...
  Ledger state released
--- Ledger State Query Demonstration Complete ---
```

---

## 5. Unit Tests

**Output:** Tests covering ledger state query serialization/deserialization, request/response mapping, and success/failure paths.

**Evidence:**

- Ledger State Query Tests: [`LedgerStateQueryTests.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Tests/LedgerStateQueries/LedgerStateQueryTests.cs)

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

**Output:** All ledger state query services registered in the service collection for DI.

**Evidence:**

- DI Registration: [`ServiceCollectionExtensions.cs`](https://github.com/ItsDaveB/OgmiosDotnet/blob/main/src/Ogmios.Services/Extensions/ServiceCollectionExtensions.cs)

All 22 services are registered as singletons in the `RegisterLedgerStateQueryServices` extension method.

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

- **OgmiosDotnetClient.Schema**: https://www.nuget.org/packages/OgmiosDotnetClient.Schema
- **OgmiosDotnetClient.Services**: https://www.nuget.org/packages/OgmiosDotnetClient.Services

Both packages include v6.13 schema support and all 22 ledger state query services.

---

## Summary

The OgmiosDotnet library now provides complete ledger state query capabilities for the Cardano ecosystem, covering all 21 Ogmios v6.13 ledger state queries plus lifecycle management. The implementation includes:

- 22 typed service implementations with consistent patterns
- 5 custom exception types for error handling
- Comprehensive unit test coverage (25 tests)
- Worker example demonstrating 7+ queries
- Full dependency injection support
- Updated documentation

The functionality is production-ready and available via published NuGet packages.
