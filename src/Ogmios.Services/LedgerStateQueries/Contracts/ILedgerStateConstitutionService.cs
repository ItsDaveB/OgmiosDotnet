
namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateConstitutionService
    {
        Task<OgmiosSchema.QueryLedgerStateConstitutionResponseEntity> GetConstitutionAsync(
            OgmiosInteractionContext context,
            OgmiosSchema.QueryLedgerStateConstitution? request = null,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}