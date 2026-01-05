using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateProjectedRewardsService(IWebSocketService webSocketService) : ILedgerStateProjectedRewardsService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateProjectedRewardsResponseEntity> GetProjectedRewardsAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.QueryLedgerStateProjectedRewards? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateProjectedRewards.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateProjectedRewards.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateProjectedRewards.MethodEntity.EnumValues.QueryLedgerStateProjectedRewards,
                paramsValue: Generated.Ogmios.QueryLedgerStateProjectedRewards.ParamsEntity.Create(),
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateProjectedRewardsResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateProjectedRewardsResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateProjectedRewards response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateProjectedRewardsResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state projected rewards: " + responseMessage, responseMessage);
        }
    }
}
