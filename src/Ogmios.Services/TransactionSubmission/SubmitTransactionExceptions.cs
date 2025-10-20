namespace Ogmios.Services.TransactionSubmission
{
    /// <summary>
    /// Thrown when an Ogmios submitTransaction response indicates the transaction failed validation
    /// or was rejected by the node.
    /// The original response JSON is available in <see cref="ResponseJson"/> for callers who need to inspect
    /// the rich failure union produced by the ogmios schema.
    /// </summary>
    public class SubmitTransactionFailedException : Exception
    {
        public string ResponseJson { get; }

        // The parsed failure value from the generated Ogmios schema.
        public Generated.Ogmios.SubmitTransactionFailure Failure { get; }

        public SubmitTransactionFailedException(string message, string responseJson, Generated.Ogmios.SubmitTransactionFailure failure)
            : base(message)
        {
            this.ResponseJson = responseJson;
            this.Failure = failure;
        }
    }

    /// <summary>
    /// Thrown when the server could not deserialise the submitted transaction.
    /// </summary>
    public class SubmitTransactionDeserialisationException : Exception
    {
        public string ResponseJson { get; }

        public SubmitTransactionDeserialisationException(string message, string responseJson)
            : base(message)
        {
            this.ResponseJson = responseJson;
        }
    }

    /// <summary>
    /// Thrown when an Ogmios evaluateTransaction response indicates the transaction failed evaluation
    /// or was rejected by the node. The original response JSON is available in <see cref="ResponseJson"/>.
    /// </summary>
    public class EvaluateTransactionFailedException : Exception
    {
        public string ResponseJson { get; }

        // The parsed failure value from the generated Ogmios schema.
        public Generated.Ogmios.EvaluateTransactionFailure Failure { get; }

        public EvaluateTransactionFailedException(string message, string responseJson, Generated.Ogmios.EvaluateTransactionFailure failure)
            : base(message)
        {
            this.ResponseJson = responseJson;
            this.Failure = failure;
        }
    }

    /// <summary>
    /// Thrown when the server could not deserialise the transaction for evaluation.
    /// </summary>
    public class EvaluateTransactionDeserialisationException : Exception
    {
        public string ResponseJson { get; }

        public EvaluateTransactionDeserialisationException(string message, string responseJson)
            : base(message)
        {
            this.ResponseJson = responseJson;
        }
    }
}
