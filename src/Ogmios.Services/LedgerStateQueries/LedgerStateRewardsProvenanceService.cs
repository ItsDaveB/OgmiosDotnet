using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateRewardsProvenanceService(IWebSocketService webSocketService) : ILedgerStateRewardsProvenanceService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateRewardsProvenanceResponseEntity> GetRewardsProvenanceAsync(
            OgmiosInteractionContext context,
            Generated.Ogmios.QueryLedgerStateRewardsProvenance? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateRewardsProvenance.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateRewardsProvenance.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateRewardsProvenance.MethodEntity.EnumValues.QueryLedgerStateRewardsProvenance,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateRewardsProvenanceResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateRewardsProvenanceResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateRewardsProvenance response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateRewardsProvenanceResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state rewards provenance: " + responseMessage, responseMessage);
        }
    }
}
