using Dapper.Oracle;
using Dapper;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketProcess.Shared.Modelos;
using RocketProcess.Repositories.App;

namespace RocketProcess.Repositories.Repositories
{
    public class RoleRepositories : IRoleRepositories
    {
        private readonly IDbConnection _dbConnection;

        public RoleRepositories(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<PostResponse> Create(Rol rol)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_nombre_rol", rol.Nombre_Rol, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_descripcion", rol.Descripcion, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);

                var result = await _dbConnection.QueryAsync("PKG_ROL.SP_CREA_ROL", p, commandType: CommandType.StoredProcedure);

                return PostResponse.CrearRespuesta(true, ClsCommon.SinErrores);
            }
            catch (Exception ex)
            {
                return PostResponse.CrearRespuesta(false, ClsCommon.MsgErrorCrear + ex.Message);
            }
        }

        public async Task<PostResponse> Delete(int Id_Rol)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_id_rol", Id_Rol, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
               
                var result = await _dbConnection.QueryAsync("PKG_ROL.SP_ELIMINA_ROL", p, commandType: CommandType.StoredProcedure);

                return PostResponse.CrearRespuesta(true, ClsCommon.SinErrores);
            }
            catch (Exception ex)
            {
                return PostResponse.CrearRespuesta(false, ClsCommon.MsgErrorEliminar + ex.Message);
            }
        }

        public async Task<IEnumerable<Rol>> GetAll()
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("registros_ROL", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<Rol>("PKG_ROL.SP_LISTAR_ROL", p, commandType: CommandType.StoredProcedure);
                return result;
                //string json = JsonConvert.SerializeObject(result, Formatting.Indented);

                //return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<Rol>();
            }
        }

        public async Task<IEnumerable<Rol>> Read(int Id_Rol)
        {
            try
            {
                var result = await _dbConnection.QueryAsync<Rol>($"select id_rol, nombre_rol, descripcion from rol where id_rol = {Id_Rol}");
                return result;
                //string json = JsonConvert.SerializeObject(result, Formatting.Indented);

                //return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<Rol>();
            }
        }

        public async Task<PostResponse> Update(Rol rol)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_id_rol", rol.Id_Rol, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_nombre_rol", rol.Nombre_Rol, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_descripcion", rol.Descripcion, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);

                var result = await _dbConnection.QueryAsync("PKG_ROL.SP_ACTUALIZA_ROL", p, commandType: CommandType.StoredProcedure);

                return PostResponse.CrearRespuesta(true, ClsCommon.SinErrores);
            }
            catch (Exception ex)
            {
                return PostResponse.CrearRespuesta(false, ClsCommon.MsgErrorActualizar + ex.Message);
            }
        }
    }
}
