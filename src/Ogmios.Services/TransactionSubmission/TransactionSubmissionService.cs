using System.Text.Json;
using Corvus.Json;
using Ogmios.Domain;
using Ogmios.Services.ChainSynchronization;

namespace Ogmios.Services.TransactionSubmission
{
    public class TransactionSubmissionService(IWebSocketService webSocketService) : ITransactionSubmissionService
    {
        private readonly IWebSocketService webSocketService = webSocketService ?? throw new ArgumentNullException(nameof(webSocketService));

        public async Task<Generated.Ogmios.SubmitTransactionResponseEntity> SubmitTransactionAsync(
            Domain.InteractionContext context,
            Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.CborSerializedSignedTransactionBase16 signedCborBase16,
            MirrorOptions? mirrorOptions = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(context);

            var paramsValue = Generated.Ogmios.SubmitTransaction.RequiredTransaction.Create(
                Generated.Ogmios.SubmitTransaction.RequiredTransaction.RequiredCbor.Create(signedCborBase16));

            var request = Generated.Ogmios.SubmitTransaction.Create(
                Generated.Ogmios.SubmitTransaction.JsonrpcEntity.EnumValues.Value20,
                Generated.Ogmios.SubmitTransaction.MethodEntity.EnumValues.SubmitTransaction,
                paramsValue,
                mirrorOptions?.Id ?? string.Empty);

            var message = request.AsJsonElement.ToString();

            var responseMessage = await webSocketService.SendAndWaitForResponseAsync(message, context.Socket, timeoutMilliseconds: default, cancellationToken)
                ?? throw new InvalidOperationException("The response message is null.");

            Generated.Ogmios.SubmitTransactionResponseEntity responseEntity;
            try { responseEntity = ParsedValue<Generated.Ogmios.SubmitTransactionResponseEntity>.Parse(responseMessage).Instance; }
            catch (Exception ex) { throw new InvalidOperationException("Failed to parse submitTransaction response: " + responseMessage, ex); }

            if (responseEntity.IsSubmitTransactionSuccess) return responseEntity;

            if (responseEntity.IsSubmitTransactionDeserialisationError)
                throw new SubmitTransactionDeserialisationException("The server reported a transaction deserialisation error. Response: " + responseMessage, responseMessage);

            var failure = responseEntity.AsSubmitTransactionError.Error;
            var friendly = SubmitTransactionFailureFormatter.Format(failure, responseMessage);
            var objectUid = ExtractObjectUid(failure);

            if (objectUid.HasValue && SubmitTransactionFailureFormatter.TryGetLabel(objectUid.Value, out var label))
                throw new SubmitTransactionFailedException($"Transaction rejected ({label}): {friendly}", responseMessage, failure);

            throw new SubmitTransactionFailedException("Transaction was rejected by the node: " + friendly, responseMessage, failure);
        }

        private static int? ExtractObjectUid(Generated.Ogmios.SubmitTransactionFailure failure)
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
            catch { }

            return null;
        }
    }
}
