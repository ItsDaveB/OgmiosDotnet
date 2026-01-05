
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateEraStartService
    {
        Task<OgmiosSchema.QueryLedgerStateEraStartResponseEntity> GetEraStartAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateEraStart? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}