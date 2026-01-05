using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateStakePoolsService(IWebSocketService webSocketService) : ILedgerStateStakePoolsService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateStakePoolsResponseEntity> GetStakePoolsAsync(
            OgmiosInteractionContext context,
            Generated.Ogmios.QueryLedgerStateStakePools? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateStakePools.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateStakePools.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateStakePools.MethodEntity.EnumValues.QueryLedgerStateStakePools,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateStakePoolsResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateStakePoolsResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateStakePools response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateStakePoolsResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state stake pools: " + responseMessage, responseMessage);
        }
    }
}
