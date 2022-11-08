using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;

namespace RocketProcess.Services.Servicios.Interfaces
{
    public interface IUserServices
    {
        Task<IEnumerable<ListUser>> GetAll();
        Task<Response<PostResponse>> Save(ListUser xUsuario);
        Task<Response<PostResponse>> Delete(int Id_Usuario);
        Task<IEnumerable<ListUser>> Read(int Id_Usuario);
    }
}
