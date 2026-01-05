
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateEraSummariesService
    {
        Task<OgmiosSchema.QueryLedgerStateEraSummariesResponseEntity> GetEraSummariesAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateEraSummaries? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}