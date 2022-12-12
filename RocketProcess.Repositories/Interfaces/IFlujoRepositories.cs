using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Modelos.ModelFlujo;
using RocketProcess.Shared.Modelos.ModelTarea;
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
        Task<IEnumerable<Flujo>> GetAll();
        Task<IEnumerable<SP_FILTRA_USUARIO_ROL>> GetDetalle(int id_usuario);
    }
}
