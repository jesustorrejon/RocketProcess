using RocketProcess.Shared.Modelos;

namespace RocketProcess.Services.Servicios.Interfaces
{
    public interface ILoginServices
    {
        Task<IEnumerable<Login>> LoginConnect(string username, string password);
    }
}
