using Corvus.Json;
using Generated;
using Ogmios.Domain;
using Ogmios.Domain.Exceptions;
using Ogmios.Services.ChainSynchronization;

namespace Ogmios.Services.MemoryPoolMonitoring;

public class MemoryPoolMonitoringService(IWebSocketService webSocketService) : IMemoryPoolMonitoringService
{
    public async Task<Generated.Ogmios.AcquireMempoolResponse.RequiredAcquiredAndSlot> AcquireMempoolAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default)
    {
        byte[] responseBytes;
        if (mirrorOptions?.Id is { Length: > 0 })
        {
            var message = Generated.Ogmios.AcquireMempool.Create(
                jsonrpc: Generated.Ogmios.AcquireMempool.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.AcquireMempool.MethodEntity.EnumValues.AcquireMempool,
                id: mirrorOptions.Id).AsJsonElement.ToString();
            responseBytes = await webSocketService.SendAndWaitForResponseBytesAsync(message, context.Socket, WebSocketTimeouts.MempoolAcquire, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            responseBytes = await webSocketService.SendAndWaitForResponseBytesAsync(MempoolRpcRequests.Acquire, context.Socket, WebSocketTimeouts.MempoolAcquire, cancellationToken).ConfigureAwait(false);
        }

        var responseEntity = ParsedValue<Generated.Ogmios.AcquireMempoolResponse>.Parse(responseBytes).Instance;

        if (responseEntity.Result.Acquired != Generated.Ogmios.AcquireMempoolResponse.RequiredAcquiredAndSlot.AcquiredEntity.EnumValues.Mempool)
        {
            throw new Exception("Error acquiring mempool.");
        }

        return responseEntity.Result;
    }

    public async Task<Generated.Ogmios.HasTransactionResponseEntity.HasTransactionResponse> HasTransactionAsync(Domain.InteractionContext context, string transactionId, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default)
    {
        byte[] responseBytes;
        if (mirrorOptions?.Id is { Length: > 0 })
        {
            var transactionIdEntity = TransactionId.FromAny(transactionId);
            var message = Generated.Ogmios.HasTransaction.Create(
                jsonrpc: Generated.Ogmios.HasTransaction.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.HasTransaction.MethodEntity.EnumValues.HasTransaction,
                Generated.Ogmios.HasTransaction.RequiredId.Create(transactionIdEntity),
                id: mirrorOptions.Id).AsJsonElement.ToString();
            responseBytes = await webSocketService.SendAndWaitForResponseBytesAsync(message, context.Socket, WebSocketTimeouts.MempoolQuery, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            var requestBytes = MempoolRpcRequests.BuildHasTransactionRequest(transactionId.AsSpan());
            responseBytes = await webSocketService.SendAndWaitForResponseBytesAsync(requestBytes, context.Socket, WebSocketTimeouts.MempoolQuery, cancellationToken).ConfigureAwait(false);
        }

        var responseEntity = ParsedValue<Generated.Ogmios.HasTransactionResponseEntity>.Parse(responseBytes).Instance;

        if (responseEntity.IsMustAcquireMempoolFirst)
        {
            var error = responseEntity.AsMustAcquireMempoolFirst.Error;
            throw new MustAcquireMempoolFirstException((string)error.Message.AsString, error.Code.ToString());
        }

        return responseEntity.AsHasTransactionResponse;
    }

    public async Task<Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.RequiredTransaction.TransactionEntity> NextTransactionAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default)
    {
        byte[] responseBytes;
        if (mirrorOptions?.Id is { Length: > 0 })
        {
            var message = Generated.Ogmios.NextTransaction.Create(
                jsonrpc: Generated.Ogmios.NextTransaction.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.NextTransaction.MethodEntity.EnumValues.NextTransaction,
                id: mirrorOptions.Id,
                paramsValue: Generated.Ogmios.NextTransaction.ParamsEntity.Create(Generated.Ogmios.NextTransaction.ParamsEntity.FieldsEntity.EnumValues.All)).AsJsonElement.ToString();
            responseBytes = await webSocketService.SendAndWaitForResponseBytesAsync(message, context.Socket, WebSocketTimeouts.MempoolQuery, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            responseBytes = await webSocketService.SendAndWaitForResponseBytesAsync(MempoolRpcRequests.NextTransactionAllFields, context.Socket, WebSocketTimeouts.MempoolQuery, cancellationToken).ConfigureAwait(false);
        }

        var responseEntity = ParsedValue<Generated.Ogmios.NextTransactionResponseEntity>.Parse(responseBytes).Instance;

        if (responseEntity.IsMustAcquireMempoolFirst)
        {
            var error = responseEntity.AsMustAcquireMempoolFirst.Error;
            throw new MustAcquireMempoolFirstException((string)error.Message.AsString, error.Code.ToString());
        }

        return responseEntity.AsNextTransactionResponse.Result.Transaction.AsTransaction;
    }

    public async Task<Generated.Ogmios.MempoolSizeAndCapacity> SizeOfMempoolAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default)
    {
        byte[] responseBytes;
        if (mirrorOptions?.Id is { Length: > 0 })
        {
            var message = Generated.Ogmios.SizeOfMempool.Create(
                jsonrpc: Generated.Ogmios.SizeOfMempool.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.SizeOfMempool.MethodEntity.EnumValues.SizeOfMempool,
                id: mirrorOptions.Id).AsJsonElement.ToString();
            responseBytes = await webSocketService.SendAndWaitForResponseBytesAsync(message, context.Socket, WebSocketTimeouts.MempoolQuery, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            responseBytes = await webSocketService.SendAndWaitForResponseBytesAsync(MempoolRpcRequests.SizeOfMempool, context.Socket, WebSocketTimeouts.MempoolQuery, cancellationToken).ConfigureAwait(false);
        }

        var responseEntity = ParsedValue<Generated.Ogmios.SizeOfMempoolResponseEntity>.Parse(responseBytes).Instance;

        if (responseEntity.IsMustAcquireMempoolFirst)
        {
            var error = responseEntity.AsMustAcquireMempoolFirst.Error;
            throw new MustAcquireMempoolFirstException((string)error.Message.AsString, error.Code.ToString());
        }

        return responseEntity.AsSizeOfMempoolResponse.Result;
    }

    public async Task<Generated.Ogmios.ReleaseMempoolResponseEntity.ReleaseMempoolResponse.RequiredReleased> ReleaseMempoolAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default)
    {
        byte[] responseBytes;
        if (mirrorOptions?.Id is { Length: > 0 })
        {
            var message = Generated.Ogmios.ReleaseMempool.Create(
                jsonrpc: Generated.Ogmios.ReleaseMempool.JsonrpcEntity.EnumValues.Value20,
                method: Generated.Ogmios.ReleaseMempool.MethodEntity.EnumValues.ReleaseMempool,
                id: mirrorOptions.Id).AsJsonElement.ToString();
            responseBytes = await webSocketService.SendAndWaitForResponseBytesAsync(message, context.Socket, WebSocketTimeouts.MempoolQuery, cancellationToken).ConfigureAwait(false);
        }
        else
        {
            responseBytes = await webSocketService.SendAndWaitForResponseBytesAsync(MempoolRpcRequests.ReleaseMempool, context.Socket, WebSocketTimeouts.MempoolQuery, cancellationToken).ConfigureAwait(false);
        }

        var responseEntity = ParsedValue<Generated.Ogmios.ReleaseMempoolResponseEntity>.Parse(responseBytes).Instance;

        if (responseEntity.IsMustAcquireMempoolFirst)
        {
            var error = responseEntity.AsMustAcquireMempoolFirst.Error;
            throw new MustAcquireMempoolFirstException((string)error.Message.AsString, error.Code.ToString());
        }

        return responseEntity.AsReleaseMempoolResponse.Result;
    }

    public Task ShutdownAsync(Domain.InteractionContext context, CancellationToken cancellationToken)
    {
        return context.Socket.CloseAsync(System.Net.WebSockets.WebSocketCloseStatus.NormalClosure, "Shutdown initiated by client.", cancellationToken);
    }
}
