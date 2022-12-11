using RocketProcess.Shared.Modelos.ModelFlujo;

namespace RocketProcess.Services.Servicios.Interfaces
{
    public interface IFlujosServices
    {
        Task<IEnumerable<FlujoDetalle>> ObtenerFlujos();
    }
}