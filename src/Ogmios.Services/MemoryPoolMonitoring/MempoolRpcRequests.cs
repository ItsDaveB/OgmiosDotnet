using System.Buffers;
using System.Text;

namespace Ogmios.Services.MemoryPoolMonitoring;

/// <summary>
/// Pre-serialized UTF-8 JSON-RPC request bodies for mempool hot-path calls.
/// </summary>
internal static class MempoolRpcRequests
{
    internal static ReadOnlyMemory<byte> Acquire { get; } = Encoding.UTF8.GetBytes("{\"jsonrpc\":\"2.0\",\"method\":\"acquireMempool\"}");

    internal static ReadOnlyMemory<byte> NextTransactionAllFields { get; } =
        Encoding.UTF8.GetBytes("{\"jsonrpc\":\"2.0\",\"method\":\"nextTransaction\",\"params\":{\"fields\":\"all\"}}");

    internal static ReadOnlyMemory<byte> SizeOfMempool { get; } = Encoding.UTF8.GetBytes("{\"jsonrpc\":\"2.0\",\"method\":\"sizeOfMempool\"}");

    internal static ReadOnlyMemory<byte> ReleaseMempool { get; } = Encoding.UTF8.GetBytes("{\"jsonrpc\":\"2.0\",\"method\":\"releaseMempool\"}");

    private static ReadOnlyMemory<byte> HasTransactionPrefix { get; } =
        Encoding.UTF8.GetBytes("{\"jsonrpc\":\"2.0\",\"method\":\"hasTransaction\",\"params\":{\"id\":\"");

    private static ReadOnlyMemory<byte> HasTransactionSuffix { get; } = Encoding.UTF8.GetBytes("\"}}");

    internal static byte[] BuildHasTransactionRequest(ReadOnlySpan<char> transactionId)
    {
        var idByteCount = Encoding.UTF8.GetByteCount(transactionId);
        var length = HasTransactionPrefix.Length + idByteCount + HasTransactionSuffix.Length;
        var buffer = ArrayPool<byte>.Shared.Rent(length);

        try
        {
            HasTransactionPrefix.Span.CopyTo(buffer);
            Encoding.UTF8.GetBytes(transactionId, buffer.AsSpan(HasTransactionPrefix.Length));
            HasTransactionSuffix.Span.CopyTo(buffer.AsSpan(HasTransactionPrefix.Length + idByteCount));

            var exact = new byte[length];
            buffer.AsSpan(0, length).CopyTo(exact);
            return exact;
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(buffer);
        }
    }
}
