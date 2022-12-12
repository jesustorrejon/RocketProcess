using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketProcess.Shared.Modelos.ModelTarea;

namespace RocketProcess.Services.Servicios.Interfaces
{
    public interface ITareasServices
    {
        Task<IEnumerable<Tarea>> GetAll();
        Task<IEnumerable<TareaDetalle>> GetAllDetalle();
        Task<Response<PostResponse>> Create(Tarea tarea);
        Task<IEnumerable<SP_TAREA_GET>> Read(int Id_Tarea);
        Task<Response<PostResponse>> Update(Tarea tarea);
        Task<Response<PostResponse>> Guardar(Tarea tarea);
        Task<Response<PostResponse>> Delete(int Id_Tarea);
    }
}
