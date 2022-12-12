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
    public class AreaNegocioRepositories : ICRUD<Area_Negocio>
    {
        private readonly IDbConnection _dbConnection;

        public AreaNegocioRepositories(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<PostResponse> Create(Area_Negocio Modelo)
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

        public async Task<IEnumerable<Area_Negocio>> GetAll()
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("listar_area_negocio", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<Area_Negocio>("PKG_AREA_NEGOCIO.SP_LISTAR_AREA_NEGOCIO", p, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<Area_Negocio>();
            }
        }

        public Task<IEnumerable<Area_Negocio>> Read(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Area_Negocio>> Read(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> Update(Area_Negocio Modelo)
        {
            throw new NotImplementedException();
        }
    }
}
