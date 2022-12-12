using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Modelos.ModelFlujo;
using RocketProcess.Shared.Modelos.ModelTarea;

namespace RocketProcess.Services.Servicios.Interfaces
{
    public interface IFlujosServices
    {
        Task<IEnumerable<FlujoDetalle>> ObtenerFlujos();
        Task<IEnumerable<Flujo>> ListarFlujos();
        Task<IEnumerable<SP_FILTRA_USUARIO_ROL>> GetDetalle(int id_usuario);
    }
}