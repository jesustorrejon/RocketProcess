using RocketProcess.Shared;
using RocketProcess.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.Interfaces
{
    public interface IUsuariosRepositories
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<string> GetDataSet(string query, string strNomTabla);
        Task<int> Login(string correo, string clave);
        Task<bool> Guardar(UsuarioDetalle xUsuario);
    }
}
