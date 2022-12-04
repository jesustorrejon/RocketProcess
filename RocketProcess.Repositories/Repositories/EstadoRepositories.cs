using Dapper;
using Dapper.Oracle;
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
    public class EstadoRepositories : ICRUD<Estado>
    {
        private IDbConnection _dbConnection;

        public EstadoRepositories(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<PostResponse> Create(Estado Modelo)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Estado>> GetAll()
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("lista_estado", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<Estado>("PKG_ESTADO.SP_LISTAR_ESTADO", p, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<Estado>();
            }
        }

        public Task<IEnumerable<Estado>> Read(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Estado>> Read(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> Update(Estado Modelo)
        {
            throw new NotImplementedException();
        }
    }
}
