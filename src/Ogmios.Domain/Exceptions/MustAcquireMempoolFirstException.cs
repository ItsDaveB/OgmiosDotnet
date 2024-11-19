namespace Ogmios.Domain.Exceptions;

public class MustAcquireMempoolFirstException(string message, string errorCode) : InvalidOperationException($"{message} (Error Code: {errorCode})")
{
    public string ErrorCode { get; } = errorCode;
}
