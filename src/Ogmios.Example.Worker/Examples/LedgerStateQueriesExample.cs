using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.LedgerStateQueries.Contracts;
using Ogmios.Services.ServerHealth;

namespace Ogmios.Example.Worker.Examples;

/// <summary>
/// Demonstrates the Ledger State Query capabilities of Ogmios.
/// Shows how to acquire ledger state, query various ledger data, and release the state.
/// </summary>
public class LedgerStateQueriesExample(
    IServerHealthService serverHealthService,
    IAcquireLedgerStateService acquireLedgerStateService,
    IReleaseLedgerStateService releaseLedgerStateService,
    ILedgerStateTipService ledgerStateTipService,
    ILedgerStateProtocolParametersService ledgerStateProtocolParametersService,
    ILedgerStateTreasuryAndReservesService ledgerStateTreasuryAndReservesService,
    ILedgerStateGovernanceProposalsService ledgerStateGovernanceProposalsService,
    ILedgerStateStakePoolsService ledgerStateStakePoolsService,
    ILedgerStateEpochService ledgerStateEpochService) : IExample
{
    public string Name => "Ledger State Queries";

    public async Task ExecuteAsync(InteractionContext context, OgmiosConfiguration ogmiosConfiguration, CancellationToken cancellationToken)
    {
        Console.WriteLine();
        Console.WriteLine("\u001b[35m╔══════════════════════════════════════════════════════════════════════════════╗\u001b[0m");
        Console.WriteLine("\u001b[35m║                    OgmiosDotnet - Ledger State Query Demo                    ║\u001b[0m");
        Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  🌐 Network: Cardano MAINNET                                                 ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  🚀 Powered by: Demeter.run Hosted Ogmios Service                            ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  📦 Library: OgmiosDotnet v6.13.1.3                                          ║\u001b[0m");
        Console.WriteLine("\u001b[35m╚══════════════════════════════════════════════════════════════════════════════╝\u001b[0m");
        Console.WriteLine();
        Console.WriteLine("\u001b[33m--- Ledger State Query Demonstration ---\u001b[0m");

        // Build server URL for health check
        var serverAddress = BuildServerUri(ogmiosConfiguration);

        // Get server health and tip
        Console.WriteLine($"\u001b[36m[ServerHealth] Getting server health from Ogmios endpoint...\u001b[0m");
        var serverHealth = await serverHealthService.GetServerHealthAsync(serverAddress);
        var tip = serverHealth.LastKnownTip;
        Console.WriteLine($"\u001b[32m[ServerHealth] Server tip: Slot {tip.Slot}, Id {tip.Id}\u001b[0m");

        // Acquire ledger state at the tip
        var tipPoint = Generated.Ogmios.PointOrOrigin.Point.Create(
            id: tip.Id ?? throw new InvalidOperationException("Block ID is null"),
            slot: Generated.Slot.ParseValue(tip.Slot.ToString()));
        var acquireParams = Generated.Ogmios.AcquireLedgerState.RequiredPoint.Create(tipPoint);
        var acquireRequest = Generated.Ogmios.AcquireLedgerState.Create(
            jsonrpc: Generated.Ogmios.AcquireLedgerState.JsonrpcEntity.EnumValues.Value20,
            method: Generated.Ogmios.AcquireLedgerState.MethodEntity.EnumValues.AcquireLedgerState,
            paramsValue: acquireParams,
            id: string.Empty);

        Console.WriteLine($"\u001b[36m[AcquireLedgerState] Acquiring ledger state...\u001b[0m");
        var acquireResponse = await acquireLedgerStateService.AcquireAsync(context, acquireRequest, cancellationToken: cancellationToken);
        var acquiredPoint = acquireResponse.AsAcquireLedgerStateSuccess.Result.Point;
        Console.WriteLine($"\u001b[32m[AcquireLedgerState] Ledger state acquired at point: {acquiredPoint}\u001b[0m");

        // Query ledger state tip
        Console.WriteLine($"\u001b[36m[QueryLedgerState/Tip] Querying ledger state tip...\u001b[0m");
        var tipResponse = await ledgerStateTipService.GetTipAsync(context, cancellationToken: cancellationToken);
        var ledgerTip = tipResponse.AsQueryLedgerStateTipResponse.Result;
        Console.WriteLine($"\u001b[32m[QueryLedgerState/Tip] Ledger Tip: {ledgerTip}\u001b[0m");

        // Query current epoch
        Console.WriteLine($"\u001b[36m[QueryLedgerState/Epoch] Querying current epoch...\u001b[0m");
        var epochResponse = await ledgerStateEpochService.GetEpochAsync(context, cancellationToken: cancellationToken);
        var epoch = epochResponse.AsQueryLedgerStateEpochResponse.Result;
        Console.WriteLine($"\u001b[32m[QueryLedgerState/Epoch] Current Epoch: {epoch}\u001b[0m");

        // Query protocol parameters
        Console.WriteLine($"\u001b[36m[QueryLedgerState/ProtocolParameters] Querying protocol parameters...\u001b[0m");
        var protocolParamsResponse = await ledgerStateProtocolParametersService.GetProtocolParametersAsync(context, cancellationToken: cancellationToken);
        var protocolParams = protocolParamsResponse.AsQueryLedgerStateProtocolParametersResponse.Result;
        Console.WriteLine($"\u001b[32m[QueryLedgerState/ProtocolParameters] Min Fee Coefficient: {protocolParams.MinFeeCoefficient}, Version: {protocolParams.Version.Major}.{protocolParams.Version.Minor}\u001b[0m");

        // Query treasury and reserves
        Console.WriteLine($"\u001b[36m[QueryLedgerState/TreasuryAndReserves] Querying treasury and reserves...\u001b[0m");
        var treasuryResponse = await ledgerStateTreasuryAndReservesService.GetTreasuryAndReservesAsync(context, cancellationToken: cancellationToken);
        var treasury = treasuryResponse.AsQueryLedgerStateTreasuryAndReservesResponse.Result;
        Console.WriteLine($"\u001b[32m[QueryLedgerState/TreasuryAndReserves] Treasury: {treasury.Treasury.Ada.Lovelace} lovelace, Reserves: {treasury.Reserves.Ada.Lovelace} lovelace\u001b[0m");

        // Query governance proposals
        Console.WriteLine($"\u001b[36m[QueryLedgerState/GovernanceProposals] Querying governance proposals...\u001b[0m");
        var governanceResponse = await ledgerStateGovernanceProposalsService.GetGovernanceProposalsAsync(context, cancellationToken: cancellationToken);
        var proposals = governanceResponse.AsQueryLedgerStateGovernanceProposalsResponse.Result;
        Console.WriteLine($"\u001b[32m[QueryLedgerState/GovernanceProposals] Active Governance Proposals: {proposals.Count()}\u001b[0m");

        // Query specific stake pool
        await QueryStakePoolAsync(context, cancellationToken);

        // Release ledger state
        Console.WriteLine($"\u001b[36m[ReleaseLedgerState] Releasing ledger state...\u001b[0m");
        await releaseLedgerStateService.ReleaseAsync(context, cancellationToken: cancellationToken);
        Console.WriteLine($"\u001b[32m[ReleaseLedgerState] Ledger state released\u001b[0m");

        Console.WriteLine("\u001b[33m--- Ledger State Query Demonstration Complete ---\u001b[0m");
        Console.WriteLine();
        Console.WriteLine("\u001b[35m╔══════════════════════════════════════════════════════════════════════════════╗\u001b[0m");
        Console.WriteLine("\u001b[35m║  ✅ Demo Complete - All queries executed successfully against MAINNET        ║\u001b[0m");
        Console.WriteLine("\u001b[35m║                                                                              ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  Thank you to Demeter.run for providing the hosted Ogmios infrastructure!   ║\u001b[0m");
        Console.WriteLine("\u001b[35m║  Learn more at: https://demeter.run                                         ║\u001b[0m");
        Console.WriteLine("\u001b[35m╚══════════════════════════════════════════════════════════════════════════════╝\u001b[0m");
        Console.WriteLine();
    }

    private async Task QueryStakePoolAsync(InteractionContext context, CancellationToken cancellationToken)
    {
        var davePoolId = "pool1t6n7rysk6wzm9wqxda6zxpzmm3j6256fs3mp06dc26n6503hhj4";
        try
        {
            Console.WriteLine($"\u001b[36m[QueryLedgerState/StakePools] Querying specific stake pool by ID...\u001b[0m");

            var stakePoolIdEntity = Generated.StakePoolId.Parse($"\"{davePoolId}\"");
            var poolIdParam = Generated.Ogmios.QueryLedgerStateStakePools.ParamsEntity.RequiredIdArray.RequiredId.Create(stakePoolIdEntity);
            var poolIdArray = Generated.Ogmios.QueryLedgerStateStakePools.ParamsEntity.RequiredIdArray.FromRange([poolIdParam]);
            var paramsEntity = Generated.Ogmios.QueryLedgerStateStakePools.ParamsEntity.Create(stakePools: poolIdArray);

            var stakePoolRequest = Generated.Ogmios.QueryLedgerStateStakePools.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateStakePools.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateStakePools.MethodEntity.EnumValues.QueryLedgerStateStakePools,
                id: string.Empty,
                paramsValue: paramsEntity);

            var stakePoolResponse = await ledgerStateStakePoolsService.GetStakePoolsAsync(context, stakePoolRequest, cancellationToken: cancellationToken);
            var pools = stakePoolResponse.AsQueryLedgerStateStakePoolsResponse.Result;

            var davePoolEntry = pools.FirstOrDefault();
            if (davePoolEntry.Value.IsNotNullOrUndefined())
            {
                var davePool = davePoolEntry.Value;

                var pledgeAda = (long)davePool.Pledge.Ada.Lovelace / 1_000_000m;
                var costAda = (long)davePool.Cost.Ada.Lovelace / 1_000_000m;

                Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools] ══════════════════════════════════════════════════════════════\u001b[0m");
                Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   DAVE Stake Pool - Live Mainnet Data\u001b[0m");
                Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools] ══════════════════════════════════════════════════════════════\u001b[0m");
                Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   Pool ID:        {davePoolEntry.Key}\u001b[0m");
                Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   VRF Key Hash:   {davePool.VrfVerificationKeyHash}\u001b[0m");
                Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   Pledge:         {pledgeAda:N0} ADA\u001b[0m");
                Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   Fixed Cost:     {costAda:N0} ADA\u001b[0m");
                Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   Margin:         {davePool.Margin} ({(double)1 / 100:P0})\u001b[0m");
                Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools]   Reward Account: {davePool.RewardAccount}\u001b[0m");
                Console.WriteLine($"\u001b[32m[QueryLedgerState/StakePools] ══════════════════════════════════════════════════════════════\u001b[0m");
            }
            else
            {
                Console.WriteLine($"\u001b[33m[QueryLedgerState/StakePools] Stake pool not found in response.\u001b[0m");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\u001b[33m[QueryLedgerState/StakePools] Error: {ex.Message}\u001b[0m");
        }
    }

    private static Uri BuildServerUri(OgmiosConfiguration ogmiosConfiguration)
    {
        string baseUrl;
        if (ogmiosConfiguration.Host.StartsWith("http://") || ogmiosConfiguration.Host.StartsWith("https://"))
        {
            baseUrl = ogmiosConfiguration.Host.TrimEnd('/');
        }
        else
        {
            var scheme = ogmiosConfiguration.Tls ? "https" : "http";
            baseUrl = $"{scheme}://{ogmiosConfiguration.Host}:{ogmiosConfiguration.Port}";
        }
        return new Uri(baseUrl);
    }
}
