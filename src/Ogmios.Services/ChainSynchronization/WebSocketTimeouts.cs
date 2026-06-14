namespace Ogmios.Services.ChainSynchronization;

/// <summary>
/// Timeout values for WebSocket request/response operations.
/// </summary>
public static class WebSocketTimeouts
{
    /// <summary>
    /// Do not apply a timeout; the operation may block indefinitely (e.g. acquireMempool).
    /// </summary>
    public const int Infinite = -1;

    /// <summary>
    /// Default timeout when callers pass <c>0</c> (use default) for standard RPC operations.
    /// </summary>
    public const int Default = 5000;

    /// <summary>
    /// acquireMempool blocks until the mempool snapshot changes; no client-side timeout.
    /// </summary>
    public const int MempoolAcquire = Infinite;

    /// <summary>
    /// Standard timeout for mempool cursor and query operations.
    /// </summary>
    public const int MempoolQuery = Default;

    public static int ResolveTimeoutMilliseconds(int timeoutMilliseconds)
    {
        if (timeoutMilliseconds == Infinite)
        {
            return Infinite;
        }

        return timeoutMilliseconds <= 0 ? Default : timeoutMilliseconds;
    }
}
