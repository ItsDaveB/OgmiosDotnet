namespace Ogmios.Services.LedgerStateQueries
{
    public class AcquireLedgerStateFailedException(string message, string rawResponse) : Exception(message)
    {
        public string RawResponse { get; } = rawResponse;
    }

    public class MustAcquireLedgerStateFirstException(string message, string code) : Exception(message)
    {
        public string Code { get; } = code;
    }

    public class LedgerStateQueryFailedException(string message, string rawResponse) : Exception(message)
    {
        public string RawResponse { get; } = rawResponse;
    }

    public class LedgerStateAcquiredExpiredException(string message, string rawResponse) : Exception(message)
    {
        public string RawResponse { get; } = rawResponse;
    }

    public class LedgerStateQueryEraMismatchException(string message, string rawResponse) : Exception(message)
    {
        public string RawResponse { get; } = rawResponse;
    }
}
