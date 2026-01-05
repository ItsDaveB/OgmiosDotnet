using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateEraStartService(IWebSocketService webSocketService) : ILedgerStateEraStartService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateEraStartResponseEntity> GetEraStartAsync(
            OgmiosInteractionContext context,
            Generated.Ogmios.QueryLedgerStateEraStart? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateEraStart.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateEraStart.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateEraStart.MethodEntity.EnumValues.QueryLedgerStateEraStart,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateEraStartResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateEraStartResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateEraStart response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateEraStartResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state era start: " + responseMessage, responseMessage);
        }
    }
}
