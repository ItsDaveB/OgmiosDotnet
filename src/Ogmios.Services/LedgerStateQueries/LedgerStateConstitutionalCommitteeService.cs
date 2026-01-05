using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class LedgerStateConstitutionalCommitteeService(IWebSocketService webSocketService) : ILedgerStateConstitutionalCommitteeService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.QueryLedgerStateConstitutionalCommitteeResponseEntity> GetConstitutionalCommitteeAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.QueryLedgerStateConstitutionalCommittee? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var queryRequest = request ?? Generated.Ogmios.QueryLedgerStateConstitutionalCommittee.Create(
                jsonrpc: Generated.Ogmios.QueryLedgerStateConstitutionalCommittee.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryLedgerStateConstitutionalCommittee.MethodEntity.EnumValues.QueryLedgerStateConstitutionalCommittee,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.QueryLedgerStateConstitutionalCommitteeResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryLedgerStateConstitutionalCommitteeResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse queryLedgerStateConstitutionalCommittee response: " + responseMessage, ex); }

            if (responseEntity.IsQueryLedgerStateConstitutionalCommitteeResponse) return responseEntity;
            if (responseEntity.IsQueryLedgerStateAcquiredExpired)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateAcquiredExpiredException("The acquired ledger state has expired.", responseMessage);
            if (responseEntity.IsQueryLedgerStateEraMismatch)
                throw new LedgerStateQueryEraMismatchException("Era mismatch: constitutional committee is only available from Conway onwards.", responseMessage);

            throw new LedgerStateQueryFailedException("Failed to query ledger state constitutional committee: " + responseMessage, responseMessage);
        }
    }
}
