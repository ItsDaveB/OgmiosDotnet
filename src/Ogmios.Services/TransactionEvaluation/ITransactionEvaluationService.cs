using Ogmios.Domain;

namespace Ogmios.Services.TransactionEvaluation
{
    public interface ITransactionEvaluationService
    {
        /// <summary>
        /// Evaluate a transaction on the connected Ogmios server (estimate execution units).
        /// Mirrors the ogmios "evaluateTransaction" JSON-RPC method and returns the strongly-typed response entity.
        /// </summary>
        Task<Generated.Ogmios.EvaluateTransactionResponseEntity> EvaluateTransactionAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16 signedCborBase16,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default);
    }
}
