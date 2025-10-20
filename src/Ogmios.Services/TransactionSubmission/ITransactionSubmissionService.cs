using Ogmios.Domain;

namespace Ogmios.Services.TransactionSubmission
{
    /// <summary>
    /// Provides the ability to submit a signed, serialized transaction to an Ogmios server.
    /// The operation aligns with the ogmios "submitTransaction" JSON-RPC method and
    /// returns the strongly-typed response entity produced by the Ogmios.Schema.
    /// </summary>
    public interface ITransactionSubmissionService
    {
        /// <summary>
        /// Submit a signed transaction to the connected Ogmios server.
        /// </summary>
        Task<Generated.Ogmios.SubmitTransactionResponseEntity> SubmitTransactionAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16 signedCborBase16,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}
