using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Services.Servicios.Interfaces
{
    public interface IAreaNegocioServices
    {
        Task<IEnumerable<Area_Negocio>> ListarAreaNegocios();
    }
}
