namespace Ogmios.Services.TransactionEvaluation
{
    /// <summary>
    /// Thrown when an Ogmios evaluateTransaction response indicates the transaction failed evaluation
    /// or was rejected by the node. The original response JSON is available in <see cref="ResponseJson"/>.
    /// </summary>
    public class EvaluateTransactionFailedException(string message, string responseJson, Generated.Ogmios.EvaluateTransactionFailure failure) : Exception(message)
    {
        public string ResponseJson { get; } = responseJson;

        // The parsed failure value from the generated Ogmios schema.
        public Generated.Ogmios.EvaluateTransactionFailure Failure { get; } = failure;
    }

    /// <summary>
    /// Thrown when the server could not deserialise the transaction for evaluation.
    /// </summary>
    public class EvaluateTransactionDeserialisationException(string message, string responseJson) : Exception(message)
    {
        public string ResponseJson { get; } = responseJson;
    }
}