namespace Ogmios.Services.TransactionSubmission
{
    /// <summary>
    /// Thrown when an Ogmios submitTransaction response indicates the transaction failed validation
    /// or was rejected by the node.
    /// The original response JSON is available in <see cref="ResponseJson"/> for callers who need to inspect
    /// the rich failure union produced by the ogmios schema.
    /// </summary>
    public class SubmitTransactionFailedException(string message, string responseJson, Generated.Ogmios.SubmitTransactionFailure failure) : Exception(message)
    {
        public string ResponseJson { get; } = responseJson;

        // The parsed failure value from the generated Ogmios schema.
        public Generated.Ogmios.SubmitTransactionFailure Failure { get; } = failure;
    }

    /// <summary>
    /// Thrown when the server could not deserialise the submitted transaction.
    /// </summary>
    public class SubmitTransactionDeserialisationException(string message, string responseJson) : Exception(message)
    {
        public string ResponseJson { get; } = responseJson;
    }
}
