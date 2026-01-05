using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateGovernanceProposalsService(IWebSocketService webSocketService) : ILedgerStateGovernanceProposalsService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateGovernanceProposalsResponseEntity> GetGovernanceProposalsAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.QueryLedgerStateGovernanceProposals? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateGovernanceProposals.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateGovernanceProposals.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateGovernanceProposals.MethodEntity.EnumValues.QueryLedgerStateGovernanceProposals,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateGovernanceProposalsResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateGovernanceProposalsResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateGovernanceProposals response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateGovernanceProposalsResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateQueryEraMismatchException("Era mismatch: governance proposals are only available from Conway onwards.", responseMessage);

            try
            {
                var jsonDoc = System.Text.Json.JsonDocument.Parse(responseMessage);
                if (jsonDoc.RootElement.TryGetProperty("result", out var resultElement) && resultElement.ValueKind == System.Text.Json.JsonValueKind.Array)
                {
                    return responseEntity;
                }
            }
            catch { }

            throw new LedgerStateQueryFailedException("Failed to query ledger state governance proposals: " + responseMessage, responseMessage);
        }
    }
}
