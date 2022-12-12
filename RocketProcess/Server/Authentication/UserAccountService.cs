using RocketProcess.Repositories.Interfaces;
using RocketProcess.Repositories.Repositories;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Seguridad;
using System.Data;

namespace RocketProcess.Server.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _userAccountList;
        private IDbConnection _dbConnection;
        private UsuariosRepositories _UsuariosRepositories;
        private LoginRepositories _loginRepositories;
        private Login _login;

        public UserAccountService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
            _loginRepositories = new LoginRepositories(_dbConnection);
            //_UsuariosRepositories = new UsuariosRepositories(dbConnection);
            //var usuarios = _UsuariosRepositories.GetAll().GetAwaiter().GetResult();

            //_userAccountList = new List<UserAccount>();

            //foreach (var usuario in usuarios)
            //{
            //    _userAccountList.Add( new UserAccount { UserName = usuario.Nombre, Password = usuario.Clave, Role = usuario.Id_Rol.ToString() });
            //}

            //_userAccountList = new List<UserAccount>()
            //{
            //    new UserAccount { UserName = "admin",  Password = "admin", Role = "Administrator" },
            //    new UserAccount { UserName = "user", Password = "user", Role = "User" }
            //};

        }

        public async Task<UserAccount>? GetUserAccountByUserName(string correo, string password)
        {
            var usuario = await _loginRepositories.Conectar(correo, password);
            _login = usuario.FirstOrDefault(x => x.correo.ToUpper() == correo.ToUpper());

            if (_login == null)
                return null;

            UserAccount userAccount = new UserAccount
            {
                Id = _login.id_usuario,
                UserName = _login.nombre,
                Password = _login.clave,
                Role = _login.rol
            };

            return userAccount;
        }
    }
}
