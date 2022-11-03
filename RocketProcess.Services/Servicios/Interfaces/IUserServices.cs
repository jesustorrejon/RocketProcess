using RocketProcess.Shared;
using RocketProcess.Shared.Modelos;

namespace RocketProcess.Services.Servicios.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<bool> Guardar(UsuarioDetalle xUsuario);
    }
}
