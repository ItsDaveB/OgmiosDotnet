using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateConstitutionService(IWebSocketService webSocketService) : ILedgerStateConstitutionService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateConstitutionResponseEntity> GetConstitutionAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.QueryLedgerStateConstitution? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateConstitution.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateConstitution.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateConstitution.MethodEntity.EnumValues.QueryLedgerStateConstitution,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateConstitutionResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateConstitutionResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateConstitution response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateConstitutionResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateQueryEraMismatchException("Era mismatch: constitution is only available from Conway onwards.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state constitution: " + responseMessage, responseMessage);
        }
    }
}
