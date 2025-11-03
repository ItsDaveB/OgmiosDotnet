using OgmiosSchema = Generated.Ogmios;

namespace Ogmios.Services.LedgerStateQueries.Contracts
{
    public interface ILedgerStateConstitutionService
    {
        Task<OgmiosSchema.QueryLedgerStateConstitutionResponseEntity> GetConstitutionAsync(OgmiosSchema.QueryLedgerStateConstitution? request = null, CancellationToken cancellationToken = default);
    }
}