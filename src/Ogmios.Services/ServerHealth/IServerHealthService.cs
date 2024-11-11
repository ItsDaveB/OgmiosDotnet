namespace Ogmios.Services.ServerHealth;

public interface IServerHealthService
{
    Task<Domain.Server.ServerHealth> GetServerHealthAsync(Uri serverAddress);
}
