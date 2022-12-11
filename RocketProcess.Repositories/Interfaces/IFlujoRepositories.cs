using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Modelos.ModelFlujo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.Interfaces
{
    public interface IFlujoRepositories
    {
        Task<IEnumerable<SP_FLUJO_GETALLDETALLE>> GetAllDetalle();
    }
}
