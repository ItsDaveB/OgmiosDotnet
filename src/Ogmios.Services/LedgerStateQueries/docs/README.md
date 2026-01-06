# LedgerStateQueries Services

Focused services that extract specific pieces of Cardano ledger-state information from an Ogmios AcquireLedgerState snapshot. Services are intentionally thin extractors that read from a single snapshot instance supplied by a central provider to ensure consistency and avoid duplicated snapshot parsing logic.

This document lists the services implemented under Ogmios.Services.LedgerStateQueries and the purpose of each. All services operate against an Ogmios "AcquireLedgerState" snapshot and extract specific pieces of ledger-state data (see: https://ogmios.dev/api/#operation-publish-/?AcquireLedgerState).

## Registration

Ledger state query services can be registered via dependency injection using the extension methods provided:

```csharp
// Option 1: Register all Ogmios services (includes ledger state queries)
services.AddOgmiosServices();

// Option 2: Register only ledger state query services (opt-in)
services.RegisterCoreServices();
services.AddLedgerStateQueryServices();
```

The `AddLedgerStateQueryServices()` method registers all 22 ledger state query services as singletons, allowing consumers to opt-in to just the ledger state functionality without chain synchronization or mempool monitoring.

## Usage Example

The following example demonstrates acquiring ledger state, querying stake pool details, and releasing the state:

```csharp
// Acquire ledger state at the current tip
await acquireLedgerStateService.AcquireAsync(context, cancellationToken: stoppingToken);

// Query current epoch
var epochResponse = await ledgerStateEpochService.GetEpochAsync(context, cancellationToken: stoppingToken);
Console.WriteLine($"Current Epoch: {epochResponse.AsQueryLedgerStateEpochResponse.Result}");

// Query a specific stake pool by ID
var stakePoolIdEntity = Generated.StakePoolId.Parse("\"pool1t6n7rysk6wzm9wqxda6zxpzmm3j6256fs3mp06dc26n6503hhj4\"");
var poolIdParam = Generated.Ogmios.QueryLedgerStateStakePools.ParamsEntity.RequiredIdArray.RequiredId.Create(stakePoolIdEntity);
var poolIdArray = Generated.Ogmios.QueryLedgerStateStakePools.ParamsEntity.RequiredIdArray.FromRange([poolIdParam]);
var paramsEntity = Generated.Ogmios.QueryLedgerStateStakePools.ParamsEntity.Create(stakePools: poolIdArray);

var stakePoolRequest = Generated.Ogmios.QueryLedgerStateStakePools.Create(
    jsonrpc: Generated.Ogmios.QueryLedgerStateStakePools.JsonrpcEntity.EnumValues.Value20,
    method: Generated.Ogmios.QueryLedgerStateStakePools.MethodEntity.EnumValues.QueryLedgerStateStakePools,
    id: string.Empty,
    paramsValue: paramsEntity);

var stakePoolResponse = await ledgerStateStakePoolsService.GetStakePoolsAsync(context, stakePoolRequest, cancellationToken: stoppingToken);
var pool = stakePoolResponse.AsQueryLedgerStateStakePoolsResponse.Result.FirstOrDefault();
Console.WriteLine($"Pool Pledge: {pool.Value.Pledge.Ada.Lovelace} lovelace");

// Release ledger state when done
await releaseLedgerStateService.ReleaseAsync(context, cancellationToken: stoppingToken);
```

## Available Services

- IAcquireLedgerStateService

  - Purpose: Provide access to the raw AcquireLedgerState snapshot and manage its lifecycle (acquire, cache, validate) so other services can read a consistent snapshot.
  - Notes: Centralised snapshot provider used by all extractor services; may handle caching, snapshot freshness policies and validation.

- ILedgerStateTipService

  - Purpose: Extract the ledger tip (current slot, block hash, block number) from the snapshot.
  - Notes: Useful for synchronisation and quick chain position checks.

- ILedgerStateUTxOService

  - Purpose: Query the UTxO set from the ledger snapshot.
  - Notes: Supports full or filtered UTxO inspection for transaction analysis and tooling.

- ILedgerStateEpochService

  - Purpose: Retrieve current epoch-related information present in the snapshot.
  - Notes: Includes epoch number and epoch-specific metadata needed by epoch-aware logic.

- ILedgerStateEraStartService

  - Purpose: Get era-start information (epoch/slot anchors) from the snapshot.
  - Notes: Useful for era transition logic and era-aware calculations.

- ILedgerStateEraSummariesService

  - Purpose: Provide summaries for one or more eras visible in the snapshot.
  - Notes: Summaries include high-level era metrics and boundaries.

- ILedgerStateProtocolParametersService

  - Purpose: Read the active protocol parameters from the snapshot.
  - Notes: These parameters are required by transaction builders and validators.

- ILedgerStateProposedProtocolParametersService

  - Purpose: Expose any proposed protocol-parameter changes recorded in the snapshot.
  - Notes: Useful for governance tooling and upgrade planners.

- ILedgerStateConstitutionService

  - Purpose: Retrieve the on-chain constitution or governance configuration from the snapshot.
  - Notes: Contains the rules and metadata that govern on-chain decision-making.

- ILedgerStateConstitutionalCommitteeService

  - Purpose: Obtain the current constitutional committee membership and related info.
  - Notes: Relevant for governance and privileged proposal workflows.

- ILedgerStateGovernanceProposalsService

  - Purpose: List governance proposals and their state found in the snapshot.
  - Notes: Used by governance dashboards and proposal evaluators.

- ILedgerStateDelegateRepresentativesService

  - Purpose: Provide delegation/representative mappings from the snapshot.
  - Notes: Helps determine who represents stake-holders for governance.

- ILedgerStateStakePoolsService

  - Purpose: Expose stake-pool registry information from the snapshot.
  - Notes: Includes pool metadata, owners, and registration details.

- ILedgerStateStakePoolsPerformancesService

  - Purpose: Return stake-pool performance metrics available in the snapshot.
  - Notes: Used for analytics, ranking, and reward estimations.

- ILedgerStateLiveStakeDistributionService

  - Purpose: Produce the live stake distribution across pools/accounts.
  - Notes: Critical for stake-based calculations and decentralisation metrics.

- ILedgerStateRewardAccountSummariesService

  - Purpose: Summarise reward-account balances and statuses from the snapshot.
  - Notes: Useful for wallet tooling and rewards reporting.

- ILedgerStateProjectedRewardsService

  - Purpose: Provide projected rewards information derived from the snapshot.
  - Notes: Helpful for forecasting and delegation decision support.

- ILedgerStateRewardsProvenanceService

  - Purpose: Trace the provenance/history of rewards found in the snapshot.
  - Notes: Used for auditing and historical reward analysis.

- ILedgerStateOperationalCertificatesService

  - Purpose: Expose operational certificate data (op certs) from the snapshot.
  - Notes: Important for validating pool operator status and keys.

- ILedgerStateNoncesService

  - Purpose: Retrieve evolving nonces and randomness-related state from the snapshot.
  - Notes: Relevant for consensus and randomness consumers.

- ILedgerStateTreasuryAndReservesService

  - Purpose: Report treasury and reserves balances captured in the snapshot.
  - Notes: Useful for economic dashboards and governance budgeting.

- ILedgerStateDumpService
  - Purpose: Produce a diagnostic dump of ledger-state sections for troubleshooting.
  - Notes: Intended for debugging, audits, and full-state inspections.

Notes

- Each service is a focused extractor that reads a specific part of the AcquireLedgerState snapshot rather than re-querying the node.
