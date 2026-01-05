using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateOperationalCertificatesService(IWebSocketService webSocketService) : ILedgerStateOperationalCertificatesService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateOperationalCertificatesResponseEntity> GetOperationalCertificatesAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.QueryLedgerStateOperationalCertificates? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateOperationalCertificates.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateOperationalCertificates.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateOperationalCertificates.MethodEntity.EnumValues.QueryLedgerStateOperationalCertificates,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateOperationalCertificatesResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateOperationalCertificatesResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateOperationalCertificates response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateOperationalCertificatesResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state operational certificates: " + responseMessage, responseMessage);
        }
    }
}
