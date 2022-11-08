using Dapper;
using Dapper.Oracle;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using RocketProcess.Repositories.Data;
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
    public class UsuariosRepositories : IUsuariosRepositories
    {
        private readonly IDbConnection _dbConnection;
        private readonly DbHelper DB = new DbHelper(CommandType.StoredProcedure);

        public UsuariosRepositories(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<ListUser>> GetAll()
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("registros", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<ListUser>("pkg_usuario.sp_usuario_getall", p, commandType: CommandType.StoredProcedure);
                return result;
                //string json = JsonConvert.SerializeObject(result, Formatting.Indented);

                //return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<ListUser>();
            }
        }

        public async Task<string> GetDataSet(string query, string strNomTabla)
        {
            DB.AddParameters("registros", oracleDbType: OracleDbType.RefCursor, ParameterDirection.Output);
            string result = DB.GetDataTable(query, strNomTabla);

            return result;
        }

        public async Task<bool> Create(ListUser xUsuario)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_nombre", xUsuario.Nombre, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_apell_paterno", xUsuario.Apell_Paterno, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_apell_materno", xUsuario.Apell_Materno, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_rut", xUsuario.Rut, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_correo", xUsuario.Correo, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_clave", xUsuario.Clave, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_telefono", xUsuario.Telefono, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_direccion", xUsuario.Direccion, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_id_rol", xUsuario.Id_Rol, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                
                if (xUsuario.Id_Usuario == 0)
                {
                    var result = await _dbConnection.QueryAsync("PKG_USUARIO.SP_USUARIO_ADD", p, commandType: CommandType.StoredProcedure);
                }
                else
                {
                    p.Add("v_id_usuario", xUsuario.Nombre, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                    var result = await _dbConnection.QueryAsync("PKG_USUARIO.SP_ACTUALIZA_USUARIO", p, commandType: CommandType.StoredProcedure);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return false;
            }
        }

        public async Task<int> Login(string correo, string clave)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_correo", correo, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_clave", clave, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("existe", dbType: OracleMappingType.Int32, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync("SP_USUARIO_LOGIN", p, commandType: CommandType.StoredProcedure);
                var existe = p.Get<int>("existe");

                return existe;
                //string json = JsonConvert.SerializeObject(result, Formatting.Indented);

                //return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return 0;
            }
        }

        public async Task<IEnumerable<ListUser>> Read(int Id_Usuario)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_id_usuario", Id_Usuario, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("registros", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<ListUser>("PKG_USUARIO.SP_USUARIO_READ", p, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<ListUser>();
            }
        }

        public async Task<bool> Update(ListUser xUsuario)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_id_usuario", xUsuario.Id_Usuario, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_nombre", xUsuario.Nombre, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_apell_paterno", xUsuario.Apell_Paterno, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_apell_materno", xUsuario.Apell_Materno, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_rut", xUsuario.Rut, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_correo", xUsuario.Correo, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_clave", xUsuario.Clave, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_telefono", xUsuario.Telefono, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_direccion", xUsuario.Direccion, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_id_rol", xUsuario.Id_Rol, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                var result = await _dbConnection.QueryAsync("PKG_USUARIO.SP_ACTUALIZA_USUARIO", p, commandType: CommandType.StoredProcedure);

                if (result.Count() == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return false;
            }
        }

        public async Task<bool> Delete(int Id_Usuario)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_id_usuario", Id_Usuario, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                var result = await _dbConnection.QueryAsync("PKG_USUARIO.SP_ELIMINA_USUARIO", p, commandType: CommandType.StoredProcedure);

                if (result.Count() == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return false;
            }
        }
    }
}
