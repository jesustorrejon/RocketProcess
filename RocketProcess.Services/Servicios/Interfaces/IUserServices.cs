using RocketProcess.Shared;
using RocketProcess.Shared.Modelos;

namespace RocketProcess.Services.Servicios.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Response<PostResponse>> Guardar(UsuarioDetalle xUsuario);
    }
}
