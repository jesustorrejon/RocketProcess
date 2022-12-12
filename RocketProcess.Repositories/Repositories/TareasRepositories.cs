using Dapper.Oracle;
using Dapper;
using RocketProcess.Repositories.App;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketProcess.Shared.Modelos.ModelTarea;
using System.Reflection;

namespace RocketProcess.Repositories.Repositories
{
    public class TareasRepositories : ICRUD<Tarea>, ITareasRepositories
    {
        private readonly IDbConnection _dbConnection;
        public IEnumerable<TareaDetalle> EnumTareaDetalle { get; set; }

        public TareasRepositories(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<PostResponse> Create(Tarea Modelo)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_nombre",  Modelo.Nombre, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_fecha_inicio", Modelo.Fecha_Inicio, dbType: OracleMappingType.Date, direction: ParameterDirection.Input);
                p.Add("v_fecha_termino", Modelo.Fecha_Termino, dbType: OracleMappingType.Date, direction: ParameterDirection.Input);
                p.Add("v_descripcion", Modelo.Descripcion_Tarea, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_usuario_asignado", Modelo.Id_Usuario, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_id_usuario_supervisor", Modelo.Id_Supervisor, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_tarea_principal", Modelo.Id_Tarea_Principal, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_flujo_asignado", Modelo.Id_Flujo, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_id_estado", Modelo.Id_Estado, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_id_area", Modelo.Id_Area, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                var result = await _dbConnection.ExecuteAsync("PKG_TAREA.SP_CREAR_TAREA",p, commandType: CommandType.StoredProcedure);

                return PostResponse.CrearRespuesta(true, ClsCommon.SinErrores);
            }
            catch (Exception ex)
            {
                return PostResponse.CrearRespuesta(false, ClsCommon.MsgErrorCrear + ex.Message);
            }
        }

        public async Task<PostResponse> Delete(int Id)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_id_tarea", dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                var result = await _dbConnection.ExecuteAsync("PKG_TAREA.SP_ELIMINA_TAREA", p, commandType: CommandType.StoredProcedure);

                return PostResponse.CrearRespuesta(true, ClsCommon.SinErrores);
            }
            catch (Exception ex)
            {
                return PostResponse.CrearRespuesta(false, ClsCommon.MsgErrorEliminar + ex.Message);
            }
        }

        public Task<PostResponse> Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarea>> GetAll()
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("lista_tarea", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<Tarea>("PKG_TAREA.SP_TAREA_GETALL", p, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<Tarea>();
            }
        }

        public async Task<IEnumerable<TareaDetalle>> GetAllDetalle()
        {
            try
            {
                List<TareaDetalle> lstTareaDetalle = new List<TareaDetalle>();
                var EnumTareas = await GetAll();
                UsuariosRepositories usuariosRepositories = new UsuariosRepositories(_dbConnection);
                FlujoRepositories flujoRepositories = new FlujoRepositories(_dbConnection);

                var EnumFlujos = await flujoRepositories.GetAll();
                var EnumUsuarios = await usuariosRepositories.GetAll();

                foreach (var tarea in EnumTareas)
                {
                    var modelo = new TareaDetalle();
                    modelo.Id_Tarea = tarea.Id_Tarea;
                    modelo.Nombre = tarea.Nombre;
                    modelo.Fecha_Inicio = tarea.Fecha_Inicio;
                    modelo.Fecha_Termino = tarea.Fecha_Termino;
                    modelo.Descripcion_Tarea = tarea.Descripcion_Tarea;
                    modelo.Id_Supervisor = tarea.Id_Supervisor;
                    modelo.Id_Estado = tarea.Id_Estado;
                    modelo.Id_Usuario = tarea.Id_Usuario;
                    modelo.Id_Area = tarea.Id_Area;
                    modelo.Id_Tarea_Principal = tarea.Id_Tarea_Principal;
                    modelo.Id_Flujo = tarea.Id_Flujo;
                    modelo.flujo_asignado = EnumFlujos.Where(x => x.Id_Flujo == tarea.Id_Flujo).FirstOrDefault();
                    modelo.usuario_asignado = EnumUsuarios.Where(x => x.Id_Usuario == tarea.Id_Usuario).FirstOrDefault();
                    modelo.usuario_supervisor = EnumUsuarios.Where(x => x.Id_Usuario == tarea.Id_Supervisor).FirstOrDefault();


                    lstTareaDetalle.Add(modelo);
                }
                EnumTareaDetalle = lstTareaDetalle;


                return EnumTareaDetalle;
            }
            catch (Exception ex)
            {
                var error = ex.Message;
                return Enumerable.Empty<TareaDetalle>();
            }
        }

        public async Task<IEnumerable<SP_TAREA_GET>> Read(int Id)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_id_tarea", Id, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("lista_tarea", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<SP_TAREA_GET>("PKG_TAREA.SP_TAREA_GET", p, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<SP_TAREA_GET>();
            }
        }

        public Task<IEnumerable<Tarea>> Read(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<PostResponse> Update(Tarea Modelo)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_id_tarea", Modelo.Id_Tarea, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_nombre", Modelo.Nombre, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_fecha_inicio", Modelo.Fecha_Inicio, dbType: OracleMappingType.Date, direction: ParameterDirection.Input);
                p.Add("v_fecha_termino", Modelo.Fecha_Termino, dbType: OracleMappingType.Date, direction: ParameterDirection.Input);
                p.Add("v_descripcion", Modelo.Descripcion_Tarea, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_usuario_asignado", Modelo.Id_Usuario, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_id_usuario_supervisor", Modelo.Id_Supervisor, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_tarea_principal", Modelo.Id_Tarea_Principal, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_flujo_asignado", Modelo.Id_Flujo, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_id_estado", Modelo.Id_Estado, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_id_area", Modelo.Id_Area, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                var result = await _dbConnection.ExecuteAsync("PKG_TAREA.SP_ACTUALIZA_TAREA", p, commandType: CommandType.StoredProcedure);

                return PostResponse.CrearRespuesta(true, ClsCommon.SinErrores);
            }
            catch (Exception ex)
            {
                return PostResponse.CrearRespuesta(false, ClsCommon.MsgErrorActualizar + ex.Message);
            }
        }

        Task<IEnumerable<Tarea>> ICRUD<Tarea>.Read(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<PostResponse> AgregarComentario(Estado_Detalle estado_Detalle)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_comentario", estado_Detalle.comentario, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("v_id_tarea", estado_Detalle.id_tarea, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("v_tipo", estado_Detalle.Tipo, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                var result = await _dbConnection.ExecuteAsync("PKG_ESTADO_DETALLE.SP_CREAR_ESTADO_DETALLE", p, commandType: CommandType.StoredProcedure);

                return PostResponse.CrearRespuesta(true, ClsCommon.SinErrores);
            }
            catch (Exception ex)
            {
                return PostResponse.CrearRespuesta(false, ClsCommon.MsgErrorCrear + ex.Message);
            }
        }

        public async Task<IEnumerable<Estado_Detalle>> ObtenerComentarios(int id_tarea)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_id_tarea", id_tarea, dbType: OracleMappingType.Varchar2, direction: ParameterDirection.Input);
                p.Add("lista_estado_detalle", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<Estado_Detalle>("PKG_ESTADO_DETALLE.SP_LISTAR__1_ESTADO_DETALLE", p, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<Estado_Detalle>();
            }
        }
    }
}
