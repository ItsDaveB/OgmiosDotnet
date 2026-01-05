using Corvus.Json;
using Generated;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;
using Ogmios.Services.LedgerStateQueries.Contracts;

namespace Ogmios.Services.LedgerStateQueries
{
    public class AcquireLedgerStateService(IWebSocketService webSocketService) : IAcquireLedgerStateService
    {
        private readonly IWebSocketService _webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.AcquireLedgerStateResponseEntity> AcquireAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.AcquireLedgerState? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            // Use provided request or construct one from context's starting point
            Generated.Ogmios.AcquireLedgerState acquireRequest;
            if (request.HasValue)
            {
                acquireRequest = request.Value;
            }
            else
            {
                var networkTip = await QueryNetworkTipAsync(context, cancellationToken);
                var pointOrOrigin = Generated.Ogmios.PointOrOrigin.Point.Create(
                    id: (string)networkTip.Id,
                    slot: networkTip.Slot);

                var point = Generated.Ogmios.AcquireLedgerState.RequiredPoint.Create(pointOrOrigin);
                acquireRequest = Generated.Ogmios.AcquireLedgerState.Create(
                    jsonrpc: Generated.Ogmios.AcquireLedgerState.JsonrpcEntity.EnumValues.Value20,
                    method: Generated.Ogmios.AcquireLedgerState.MethodEntity.EnumValues.AcquireLedgerState,
                    paramsValue: point,
                    id: mirrorOptions?.Id ?? string.Empty);
            }

            var message = acquireRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.AcquireLedgerStateResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.AcquireLedgerStateResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse acquireLedgerState response: " + responseMessage, ex); }

            if (responseEntity.IsAcquireLedgerStateSuccess) return responseEntity;

            throw new AcquireLedgerStateFailedException("Failed to acquire ledger state: " + responseMessage, responseMessage);
        }

        private async Task<Generated.Ogmios.PointOrOrigin.Point> QueryNetworkTipAsync(Domain.InteractionContext context, CancellationToken cancellationToken)
        {
            var queryRequest = Generated.Ogmios.QueryNetworkTip.Create(
                jsonrpc: Generated.Ogmios.QueryNetworkTip.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.QueryNetworkTip.MethodEntity.EnumValues.QueryNetworkTip);

            var message = queryRequest.AsJsonElement.ToString();

            var responseMessage = await _webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The QueryNetworkTip response message is null.");

            Generated.Ogmios.QueryNetworkTipResponse responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.QueryNetworkTipResponse>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse QueryNetworkTip response: " + responseMessage, ex); }

            var pointOrOrigin = responseEntity.Result;
            if (pointOrOrigin.IsPoint)
            {
                return pointOrOrigin.AsPoint;
            }

            throw new InvalidOperationException("Network tip returned 'origin' which cannot be used for ledger state acquisition.");
        }
    }
}
