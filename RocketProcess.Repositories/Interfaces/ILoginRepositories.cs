using RocketProcess.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.Interfaces
{
    public interface ILoginRepositories
    {
        Task<IEnumerable<Login>> Conectar(string correo, string clave);
    }
}
