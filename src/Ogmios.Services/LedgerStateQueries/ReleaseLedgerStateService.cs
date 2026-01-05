using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class ReleaseLedgerStateService(IWebSocketService webSocketService) : IReleaseLedgerStateService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.ReleaseLedgerStateResponse> ReleaseAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.ReleaseLedgerState? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var releaseRequest = request ?? Generated.Ogmios.ReleaseLedgerState.Create(
                jsonrpc: Generated.Ogmios.ReleaseLedgerState.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.ReleaseLedgerState.MethodEntity.EnumValues.ReleaseLedgerState,
                id: mirrorOptions?.Id ?? string.Empty);

            var message = releaseRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.ReleaseLedgerStateResponse responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.ReleaseLedgerStateResponse>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse releaseLedgerState response: " + responseMessage, ex); }

            return responseEntity;
        }
    }
}
