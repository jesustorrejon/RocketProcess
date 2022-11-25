using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
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
    }
}
