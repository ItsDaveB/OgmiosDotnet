using System.Text.Json;
using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;

namespace Ogmios.Services.TransactionEvaluation
{
    public class TransactionEvaluationService(IWebSocketService webSocketService) : ITransactionEvaluationService
    {
        private readonly IWebSocketService webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        /// <summary>
        /// Evaluate a transaction on the connected Ogmios server (estimate execution units).
        /// </summary>
        public async Task<Generated.Ogmios.EvaluateTransactionResponseEntity> EvaluateTransactionAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16 signedCborBase16,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var paramsValue = Generated.Ogmios.EvaluateTransaction.RequiredTransaction.Create(
                Generated.Ogmios.EvaluateTransaction.RequiredTransaction.RequiredCbor.Create(signedCborBase16));

            var request = Generated.Ogmios.EvaluateTransaction.Create(
                Generated.Ogmios.EvaluateTransaction.JsonrpcEntity.EnumValues.Value20,
                Generated.Ogmios.EvaluateTransaction.MethodEntity.EnumValues.EvaluateTransaction,
                paramsValue,
                mirrorOptions?.Id ?? string.Empty);

            var message = request.AsJsonElement.ToString();

            var responseMessage = await webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.EvaluateTransactionResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.EvaluateTransactionResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse evaluateTransaction response: " + responseMessage, ex); }

            if (responseEntity.IsEvaluateTransactionSuccess) return responseEntity;

            if (responseEntity.IsEvaluateTransactionDeserialisationError)
                throw new EvaluateTransactionDeserialisationException("The server reported a transaction deserialisation error. Response: " + responseMessage, responseMessage);

            var failure = responseEntity.AsEvaluateTransactionError.Error;
            var friendly = EvaluateTransactionFailureFormatter.Format(failure, responseMessage);
            var objectUid = ExtractObjectUidEvaluate(failure);

            if (objectUid.HasValue && EvaluateTransactionFailureFormatter.TryGetLabel(objectUid.Value, out var label))
                throw new EvaluateTransactionFailedException($"Transaction rejected ({label}): {friendly}", responseMessage, failure);

            throw new EvaluateTransactionFailedException("Transaction was rejected by the node: " + friendly, responseMessage, failure);
        }

        private static int? ExtractObjectUidEvaluate(Generated.Ogmios.EvaluateTransactionFailure failure)
        {
            try
            {
                var elem = failure.AsJsonElement;
                if (elem.ValueKind != JsonValueKind.Object) return null;
                if (elem.TryGetProperty("objectUid", out var uidProp))
                {
                    if (uidProp.ValueKind == JsonValueKind.Number && uidProp.TryGetInt32(out var n)) return n;
                    if (uidProp.ValueKind == JsonValueKind.String && int.TryParse(uidProp.GetString(), out var m)) return m;
                }

                if (elem.TryGetProperty("code", out var codeProp) && codeProp.ValueKind == JsonValueKind.Number && codeProp.TryGetInt32(out var c)) return c;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred while extracting object UID: {ex.Message}");
            }

            return null;
        }
    }
}
