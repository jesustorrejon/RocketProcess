using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Services.Servicios.Interfaces
{
    public interface IRoleServices
    {
        Task<IEnumerable<Rol>> GetAll();
        Task<Response<PostResponse>> Create(Rol rol);
        Task<IEnumerable<Rol>> Read(int Id_Rol);
        Task<Response<PostResponse>> Update(Rol rol);
        Task<Response<PostResponse>> Delete(int Id_Rol);
    }
}
