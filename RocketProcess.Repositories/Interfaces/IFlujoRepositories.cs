using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.Interfaces
{
    public interface IFlujoRepositories
    {
        Task<IEnumerable<Flujo>> GetAll();
        Task<PostResponse> Create(Flujo flujo);
        Task<IEnumerable<Flujo>> Read(int Id_Flujo);
        Task<PostResponse> Update(Flujo flujo);
        Task<PostResponse> Delete(int Id_Flujo);
    }
}
