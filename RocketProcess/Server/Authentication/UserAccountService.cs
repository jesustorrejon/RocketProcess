using RocketProcess.Repositories.Interfaces;
using RocketProcess.Repositories.Repositories;
using System.Data;

namespace RocketProcess.Server.Authentication
{
    public class UserAccountService
    {
        private List<UserAccount> _userAccountList;
        private IDbConnection _dbConnection;
        private UsuariosRepositories _UsuariosRepositories;

        public UserAccountService(IDbConnection dbConnection)
        {
            _UsuariosRepositories = new UsuariosRepositories(dbConnection);
            var usuarios = _UsuariosRepositories.GetAll().GetAwaiter().GetResult();
            _userAccountList = new List<UserAccount>();

            foreach (var usuario in usuarios)
            {
                _userAccountList.Add( new UserAccount { UserName = usuario.Nombre, Password = usuario.Clave, Role = usuario.Id_Rol.ToString() });
            }

            //_userAccountList = new List<UserAccount>()
            //{
            //    new UserAccount { UserName = "admin",  Password = "admin", Role = "Administrator" },
            //    new UserAccount { UserName = "user", Password = "user", Role = "User" }
            //};

        }

        public UserAccount? GetUserAccountByUserName(string userName)
        {
            return _userAccountList.FirstOrDefault(x => x.UserName == userName);
        }
    }
}
