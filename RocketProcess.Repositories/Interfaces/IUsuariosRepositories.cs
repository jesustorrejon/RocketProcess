using RocketProcess.Shared.Entidades;
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
        Task<IEnumerable<ListUser>> GetAll();
        Task<string> GetDataSet(string query, string strNomTabla);
        Task<int> Login(string correo, string clave);
        Task<bool> Create(ListUser xUsuario);
        Task<IEnumerable<ListUser>> Read(int Id_Usuario);

        Task<bool> Update(ListUser xUsuario);
        Task<bool> Delete(int Id_Usuario);

    }
}
