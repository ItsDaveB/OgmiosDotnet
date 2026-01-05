using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateTreasuryAndReservesService(IWebSocketService webSocketService) : ILedgerStateTreasuryAndReservesService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateTreasuryAndReservesResponseEntity> GetTreasuryAndReservesAsync(
            OgmiosInteractionContext context,
            Generated.Ogmios.QueryLedgerStateTreasuryAndReserves? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateTreasuryAndReserves.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateTreasuryAndReserves.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateTreasuryAndReserves.MethodEntity.EnumValues.QueryLedgerStateTreasuryAndReserves,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateTreasuryAndReservesResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateTreasuryAndReservesResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateTreasuryAndReserves response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateTreasuryAndReservesResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state treasury and reserves: " + responseMessage, responseMessage);
        }
    }
}
