using Dapper.Oracle;
using Dapper;
using RocketProcess.Repositories.Data;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Shared;
using RocketProcess.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.Repositories
{
    public class LoginRepositories : ILoginRepositories
    {
        private readonly IDbConnection _dbConnection;
        private readonly DbHelper DB = new DbHelper(CommandType.StoredProcedure);

        public LoginRepositories(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Login>> Conectar(string correo, string clave)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_correo", correo, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_clave", clave, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("registros", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<Login>("SP_USUARIO_LOGIN", p, commandType: CommandType.StoredProcedure);

                return result;
                //string json = JsonConvert.SerializeObject(result, Formatting.Indented);

                //return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<Login>();
            }
        }
    }
}
