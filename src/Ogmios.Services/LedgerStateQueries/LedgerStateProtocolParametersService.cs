using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateProtocolParametersService(IWebSocketService webSocketService) : ILedgerStateProtocolParametersService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateProtocolParametersResponseEntity> GetProtocolParametersAsync(
            OgmiosInteractionContext context,
            Generated.Ogmios.QueryLedgerStateProtocolParameters? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateProtocolParameters.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateProtocolParameters.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateProtocolParameters.MethodEntity.EnumValues.QueryLedgerStateProtocolParameters,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateProtocolParametersResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateProtocolParametersResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateProtocolParameters response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateProtocolParametersResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state protocol parameters: " + responseMessage, responseMessage);
        }
    }
}
