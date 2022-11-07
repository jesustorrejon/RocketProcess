using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.Interfaces
{
    public interface IRoleRepositories
    {
        Task<IEnumerable<Rol>> GetAll();
        Task<bool> Create(Rol rol);
        Task<IEnumerable<Rol>> Read(int Id_Rol);
        Task<bool> Update(Rol rol);
        Task<bool> Delete(int Id_Rol);
    }
}
