using Ogmios.Domain.Server;

namespace Ogmios.Domain.Exceptions;

public class ServerNotReadyException(ServerHealth health) : Exception($"Server is not ready. Network synchronization at {health.NetworkSynchronization}%.")
{
}