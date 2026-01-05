using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateTipService(IWebSocketService webSocketService) : ILedgerStateTipService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateTipResponseEntity> GetTipAsync(
            OgmiosInteractionContext context,
            Generated.Ogmios.QueryLedgerStateTip? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateTip.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateTip.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateTip.MethodEntity.EnumValues.QueryLedgerStateTip,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateTipResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateTipResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateTip response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateTipResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateQueryEraMismatchException("Era mismatch: the requested data is not available in the current era.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state tip: " + responseMessage, responseMessage);
        }
    }
}
