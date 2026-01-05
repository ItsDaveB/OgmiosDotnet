using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateLiveStakeDistributionService(IWebSocketService webSocketService) : ILedgerStateLiveStakeDistributionService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateLiveStakeDistributionResponseEntity> GetLiveStakeDistributionAsync(
            OgmiosInteractionContext context,
            Generated.Ogmios.QueryLedgerStateLiveStakeDistribution? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateLiveStakeDistribution.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateLiveStakeDistribution.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateLiveStakeDistribution.MethodEntity.EnumValues.QueryLedgerStateLiveStakeDistribution,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateLiveStakeDistributionResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateLiveStakeDistributionResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateLiveStakeDistribution response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateLiveStakeDistributionResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state live stake distribution: " + responseMessage, responseMessage);
        }
    }
}
