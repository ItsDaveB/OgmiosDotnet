using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateRewardAccountSummariesService(IWebSocketService webSocketService) : ILedgerStateRewardAccountSummariesService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateRewardAccountSummariesResponseEntity> GetRewardAccountSummariesAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.QueryLedgerStateRewardAccountSummaries? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateRewardAccountSummaries.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateRewardAccountSummaries.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateRewardAccountSummaries.MethodEntity.EnumValues.QueryLedgerStateRewardAccountSummaries,
                paramsValue: Generated.Ogmios.QueryLedgerStateRewardAccountSummaries.ParamsEntity.Create(),
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateRewardAccountSummariesResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateRewardAccountSummariesResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateRewardAccountSummaries response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateRewardAccountSummariesResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state reward account summaries: " + responseMessage, responseMessage);
        }
    }
}
