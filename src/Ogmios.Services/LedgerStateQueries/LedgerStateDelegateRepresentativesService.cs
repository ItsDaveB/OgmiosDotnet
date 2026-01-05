using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateDelegateRepresentativesService(IWebSocketService webSocketService) : ILedgerStateDelegateRepresentativesService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateDelegateRepresentativesResponseEntity> GetDelegateRepresentativesAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.QueryLedgerStateDelegateRepresentatives? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateDelegateRepresentatives.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateDelegateRepresentatives.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateDelegateRepresentatives.MethodEntity.EnumValues.QueryLedgerStateDelegateRepresentatives,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateDelegateRepresentativesResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateDelegateRepresentativesResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateDelegateRepresentatives response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateDelegateRepresentativesResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateQueryEraMismatchException("Era mismatch: delegate representatives are only available from Conway onwards.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state delegate representatives: " + responseMessage, responseMessage);
        }
    }
}
