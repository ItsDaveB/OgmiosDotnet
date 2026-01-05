using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateEraSummariesService(IWebSocketService webSocketService) : ILedgerStateEraSummariesService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateEraSummariesResponseEntity> GetEraSummariesAsync(
            OgmiosInteractionContext context,
            Generated.Ogmios.QueryLedgerStateEraSummaries? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateEraSummaries.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateEraSummaries.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateEraSummaries.MethodEntity.EnumValues.QueryLedgerStateEraSummaries,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateEraSummariesResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateEraSummariesResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateEraSummaries response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateEraSummariesResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state era summaries: " + responseMessage, responseMessage);
        }
    }
}
