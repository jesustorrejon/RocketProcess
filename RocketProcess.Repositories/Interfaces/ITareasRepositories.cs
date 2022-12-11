using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos.ModelTarea;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.Interfaces
{
    public interface ITareasRepositories
    {
        public Task<IEnumerable<TareaDetalle>> GetAllDetalle();
        public Task<IEnumerable<SP_TAREA_GET>> Read(int id);
    }
}
