using Ogmios.Domain;

namespace Ogmios.Services.ChainSynchronization;

/// <summary>
/// A WebSocket text frame backed by an <see cref="System.Buffers.ArrayPool{T}"/> rented buffer.
/// Return the buffer via <see cref="Return"/> after processing.
/// </summary>
public readonly struct PooledWebSocketMessage(byte[] buffer, int length, Domain.InteractionContext context)
{
    public byte[] Buffer { get; } = buffer;

    public int Length { get; } = length;

    public Domain.InteractionContext Context { get; } = context;

    public ReadOnlyMemory<byte> Memory => new(Buffer, 0, Length);

    public void Return()
    {
        System.Buffers.ArrayPool<byte>.Shared.Return(Buffer);
    }
}
