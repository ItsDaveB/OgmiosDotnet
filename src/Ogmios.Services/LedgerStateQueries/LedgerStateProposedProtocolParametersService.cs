using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateProposedProtocolParametersService(IWebSocketService webSocketService) : ILedgerStateProposedProtocolParametersService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateProposedProtocolParametersResponseEntity> GetProposedProtocolParametersAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.QueryLedgerStateProposedProtocolParameters? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateProposedProtocolParameters.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateProposedProtocolParameters.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateProposedProtocolParameters.MethodEntity.EnumValues.QueryLedgerStateProposedProtocolParameters,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateProposedProtocolParametersResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateProposedProtocolParametersResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateProposedProtocolParameters response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateProposedProtocolParametersResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state proposed protocol parameters: " + responseMessage, responseMessage);
        }
    }
}
