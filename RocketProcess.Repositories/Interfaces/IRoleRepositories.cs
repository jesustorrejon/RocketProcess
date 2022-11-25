using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
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
        Task<PostResponse> Create(Rol rol);
        Task<IEnumerable<Rol>> Read(int Id_Rol);
        Task<PostResponse> Update(Rol rol);
        Task<PostResponse> Delete(int Id_Rol);
    }
}
