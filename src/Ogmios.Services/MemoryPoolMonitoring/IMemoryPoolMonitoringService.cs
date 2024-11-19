using Ogmios.Domain;

namespace Ogmios.Services.MemoryPoolMonitoring;

public interface IMemoryPoolMonitoringService
{
    Task<Generated.Ogmios.AcquireMempoolResponse.RequiredAcquiredAndSlot> AcquireMempoolAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default);
    Task<Generated.Ogmios.HasTransactionResponseEntity.HasTransactionResponse> HasTransactionAsync(Domain.InteractionContext context, string transactionId, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default);
    Task<Generated.Ogmios.NextTransactionResponseEntity.NextTransactionResponse.RequiredTransaction.TransactionEntity> NextTransactionAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default);
    Task<Generated.Ogmios.MempoolSizeAndCapacity> SizeOfMempoolAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default);
    Task<Generated.Ogmios.ReleaseMempoolResponseEntity.ReleaseMempoolResponse.RequiredReleased> ReleaseMempoolAsync(Domain.InteractionContext context, CancellationToken cancellationToken, MirrorOptions? mirrorOptions = default);
    Task ShutdownAsync(Domain.InteractionContext context, CancellationToken cancellationToken);
}
