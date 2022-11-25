using Dapper.Oracle;
using Dapper;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.Repositories
{
    public class FlujoRepositories : IFlujoRepositories
    {
        private readonly IDbConnection _dbConnection;
        public FlujoRepositories(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public Task<PostResponse> Create(Flujo flujo)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> Delete(int Id_Flujo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Flujo>> GetAll()
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("lista_flujos", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<Flujo>("PKG_FLUJO.SP_FLUJO_GETALL", p, commandType: CommandType.StoredProcedure);
                return result;
                //string json = JsonConvert.SerializeObject(result, Formatting.Indented);

                //return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<Flujo>();
            }
        }

        public Task<IEnumerable<Flujo>> Read(int Id_Flujo)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> Update(Flujo flujo)
        {
            throw new NotImplementedException();
        }
    }
}
