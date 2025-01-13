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
        var acquireMempoolRequest = Generated.Ogmios.AcquireMempool.Create(jsonrpc: Generated.Ogmios.AcquireMempool.JsonrpcEntity.EnumValues.Value20, method: Generated.Ogmios.AcquireMempool.MethodEntity.EnumValues.AcquireMempool, id: mirrorOptions?.Id ?? string.Empty);
        var message = acquireMempoolRequest.AsJsonElement.ToString();
        var responseMessage = await webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken);

        var responseEntity = ParsedValue<Generated.Ogmios.AcquireMempoolResponse>.Parse(responseMessage).Instance;

        if (responseEntity.Result.Acquired != Generated.Ogmios.AcquireMempoolResponse.RequiredAcquiredAndSlot.AcquiredEntity.EnumValues.Mempool)
        {
            throw new Exception("Error acquiring mempool.");
        }

        return responseEntity.Result;
    }

    public async Task<Generated.Ogmios.HasTransactionResponseEntity.HasTransactionResponse> HasTransactionAsync(Domain.InteractionContext context, string transactionId, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default)
    {
        var transactionIdEntity = TransactionId.FromAny(transactionId);
        var hasTransactionRequest = Generated.Ogmios.HasTransaction.Create(jsonrpc: Generated.Ogmios.HasTransaction.JsonrpcEntity.EnumValues.Value20, method: Generated.Ogmios.HasTransaction.MethodEntity.EnumValues.HasTransaction,
                                                                           Generated.Ogmios.HasTransaction.RequiredId.Create(transactionIdEntity), id: mirrorOptions?.Id ?? string.Empty);
        var message = hasTransactionRequest.AsJsonElement.ToString();
        var responseMessage = await webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken) ?? throw new InvalidOperationException("The response message is null.");
        var responseEntity = ParsedValue<Generated.Ogmios.HasTransactionResponseEntity>.Parse(responseMessage).Instance;

        if (responseEntity.IsMustAcquireMempoolFirst)
        {
            var error = responseEntity.AsMustAcquireMempoolFirst.Error;
            throw new MustAcquireMempoolFirstException((string)error.Message.AsString, error.Code.ToString());
        }

        return responseEntity.AsHasTransactionResponse;
    }

    public async Task<Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.RequiredTransaction.TransactionEntity> NextTransactionAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default)
    {
        var nextTransactionRequest = Generated.Ogmios.NextTransaction.Create(jsonrpc: Generated.Ogmios.NextTransaction.JsonrpcEntity.EnumValues.Value20, method: Generated.Ogmios.NextTransaction.MethodEntity.EnumValues.NextTransaction,
                                                                             id: mirrorOptions?.Id ?? string.Empty, paramsValue: Generated.Ogmios.NextTransaction.ParamsEntity.Create(Generated.Ogmios.NextTransaction.ParamsEntity.FieldsEntity.EnumValues.All));
        var message = nextTransactionRequest.AsJsonElement.ToString();
        var responseMessage = await webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken);

        var responseEntity = ParsedValue<Generated.Ogmios.NextTransactionResponseEntity>.Parse(responseMessage).Instance;

        if (responseEntity.IsMustAcquireMempoolFirst)
        {
            var error = responseEntity.AsMustAcquireMempoolFirst.Error;
            throw new MustAcquireMempoolFirstException((string)error.Message.AsString, error.Code.ToString());
        }

        return responseEntity.AsNextTransactionResponse.Result.Transaction.AsTransaction;
    }

    public async Task<Generated.Ogmios.MempoolSizeAndCapacity> SizeOfMempoolAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default)
    {
        var sizeOfMempoolRequest = Generated.Ogmios.SizeOfMempool.Create(jsonrpc: Generated.Ogmios.SizeOfMempool.JsonrpcEntity.EnumValues.Value20, method: Generated.Ogmios.SizeOfMempool.MethodEntity.EnumValues.SizeOfMempool, id: mirrorOptions?.Id ?? string.Empty);
        var message = sizeOfMempoolRequest.AsJsonElement.ToString();
        var responseMessage = await webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken);

        var responseEntity = ParsedValue<Generated.Ogmios.SizeOfMempoolResponseEntity>.Parse(responseMessage).Instance;

        if (responseEntity.IsMustAcquireMempoolFirst)
        {
            var error = responseEntity.AsMustAcquireMempoolFirst.Error;
            throw new MustAcquireMempoolFirstException((string)error.Message.AsString, error.Code.ToString());
        }

        return responseEntity.AsSizeOfMempoolResponse.Result;
    }

    public async Task<Generated.Ogmios.ReleaseMempoolResponseEntity.ReleaseMempoolResponse.RequiredReleased> ReleaseMempoolAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default)
    {
        var releaseMempoolRequest = Generated.Ogmios.ReleaseMempool.Create(jsonrpc: Generated.Ogmios.ReleaseMempool.JsonrpcEntity.EnumValues.Value20, method: Generated.Ogmios.ReleaseMempool.MethodEntity.EnumValues.ReleaseMempool, id: mirrorOptions?.Id ?? string.Empty);
        var message = releaseMempoolRequest.AsJsonElement.ToString();
        var responseMessage = await webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken);

        var responseEntity = ParsedValue<Generated.Ogmios.ReleaseMempoolResponseEntity>.Parse(responseMessage).Instance;

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