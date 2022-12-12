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
using RocketProcess.Shared.Modelos.ModelFlujo;
using RocketProcess.Shared.Modelos.ModelTarea;

namespace RocketProcess.Repositories.Repositories
{
    public class FlujoRepositories : IFlujoRepositories, ICRUD<Flujo>
    {
        private readonly IDbConnection _dbConnection;
        public FlujoRepositories(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<PostResponse> Create(Flujo Modelo)
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

        public async Task<IEnumerable<Flujo>> GetAll()
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("lista_flujo", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<Flujo>("PKG_FLUJO.SP_LISTAR_FLUJO", p, commandType: CommandType.StoredProcedure);
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

        public async Task<IEnumerable<SP_FLUJO_GETALLDETALLE>> GetAllDetalle()
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("lista_flujo", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<SP_FLUJO_GETALLDETALLE>("PKG_FLUJO.SP_FLUJO_GETALLDETALLE", p, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return Enumerable.Empty<SP_FLUJO_GETALLDETALLE> ();
            }


            //try
            //{
            //    TareasRepositories tr = new TareasRepositories(_dbConnection);
            //    EstadoRepositories er = new EstadoRepositories(_dbConnection);
            //    UsuariosRepositories ur = new UsuariosRepositories(_dbConnection);
                
            //    List<FlujoDetalle> lstFlujoDetalle = new List<FlujoDetalle>();

            //    var EnumFlujos = await GetAll();
            //    var EnumTareas = await tr.GetAll();
            //    var EnumEstados = await er.GetAll();
            //    var EnumUsuarios = await ur.GetAll();

            //    foreach (var flujo in EnumFlujos)
            //    {
            //        FlujoDetalle flujoDetalle = new FlujoDetalle();
            //        flujoDetalle.Id_Flujo = flujo.Id_Flujo;
            //        flujoDetalle.Nombre = flujo.Nombre;
            //        flujoDetalle.Descripcion = flujo.Descripcion;

            //        foreach (var tarea in EnumTareas)
            //        {
            //            if (tarea.Id_Flujo == flujo.Id_Flujo)
            //            {
            //                TareaDeFlujo tareaDeFlujo = new TareaDeFlujo();
            //                tareaDeFlujo.Id_Tarea = tarea.Id_Tarea;
            //                tareaDeFlujo.Nombre = tarea.Nombre;
            //                tareaDeFlujo.Fecha_Inicio = tarea.Fecha_Inicio;
            //                tareaDeFlujo.Fecha_Termino = tarea.Fecha_Termino;
            //                tareaDeFlujo.Descripcion_Tarea = tarea.Descripcion_Tarea;

            //                tareaDeFlujo.Dias_Plazo = (tarea.Fecha_Termino - tarea.Fecha_Inicio).Days;
            //                if (tareaDeFlujo.Dias_Plazo < 0)
            //                {
            //                    tareaDeFlujo.Dias_Plazo = 0;
            //                }

            //                if (tarea.Id_Estado != 1) // Si la tarea nNO está terminada
            //                {
            //                    var dias_retrazo = (DateTime.Now - tarea.Fecha_Termino).Days;
            //                    tareaDeFlujo.Dias_Retrazo = dias_retrazo < 0 ? 0 : dias_retrazo;

            //                    if (tareaDeFlujo.Dias_Plazo <= 0)
            //                    {
            //                        tareaDeFlujo.Progreso = 100;
            //                    }
            //                    else if (tarea.Fecha_Inicio >= DateTime.Now)
            //                    {
            //                        tareaDeFlujo.Progreso = 0;
            //                    }
            //                    else if (tarea.Fecha_Termino >= DateTime.Now)
            //                    {
            //                        int dias = (tarea.Fecha_Termino - DateTime.Now).Days;
            //                        tareaDeFlujo.Progreso = (dias * 100) / tareaDeFlujo.Dias_Plazo;
            //                    }
            //                    else if (tarea.Fecha_Termino < DateTime.Now)
            //                    {
            //                        // Significa que la tarea está atrasada si cae en esta condición
            //                        // Se actualiza el estado de la tarea.
            //                        // Solo si tiene estado Asignada o Aceptada
            //                        if (tarea.Id_Estado == 6 || tarea.Id_Estado == 5)
            //                        {
            //                            tarea.Id_Tarea = 7; // Estado Atrasada
            //                            await tr.Update(tarea);
            //                        }

            //                        tareaDeFlujo.Progreso = 100;
            //                    }
            //                    else
            //                    {
            //                        tareaDeFlujo.Progreso = 0.11111;
            //                    }
            //                }
            //                else // Si la tarea SI está terminada
            //                {
            //                    tareaDeFlujo.Dias_Retrazo = 0;
            //                    tareaDeFlujo.Progreso = 100;
            //                }

            //                tareaDeFlujo.Estado_Tarea = EnumEstados.Where(estado => estado.Id_Estado == tarea.Id_Estado).FirstOrDefault().Descripcion;
            //                tareaDeFlujo.Comentario = "";

                            

            //                ListUser xlistUser = EnumUsuarios.FirstOrDefault(usuario => usuario.Id_Usuario == tarea.Id_Usuario);
            //                ListUser xlistUserSupervisor = EnumUsuarios.FirstOrDefault(usuario => usuario.Id_Usuario == tarea.Id_Supervisor);
                            
            //                tareaDeFlujo.Usuario_Asignado.Id_Usuario = xlistUser.Id_Usuario;
            //                tareaDeFlujo.Usuario_Asignado.Nombre = xlistUser.Nombre;
            //                tareaDeFlujo.Usuario_Asignado.Apell_Paterno = xlistUser.Apell_Paterno;
            //                tareaDeFlujo.Usuario_Asignado.Apell_Materno = xlistUser.Apell_Materno;
            //                tareaDeFlujo.Usuario_Asignado.Correo = xlistUser.Correo;
            //                tareaDeFlujo.Usuario_Asignado.Telefono = xlistUser.Telefono;

            //                tareaDeFlujo.Usuario_Supervisor.Id_Usuario = xlistUserSupervisor.Id_Usuario;
            //                tareaDeFlujo.Usuario_Supervisor.Nombre = xlistUserSupervisor.Nombre;
            //                tareaDeFlujo.Usuario_Supervisor.Apell_Paterno = xlistUserSupervisor.Apell_Paterno;
            //                tareaDeFlujo.Usuario_Supervisor.Apell_Materno = xlistUserSupervisor.Apell_Materno;
            //                tareaDeFlujo.Usuario_Supervisor.Correo = xlistUserSupervisor.Correo;
            //                tareaDeFlujo.Usuario_Supervisor.Telefono = xlistUserSupervisor.Telefono;

            //                flujoDetalle.Tareas.Add(tareaDeFlujo);
            //            }
            //        }
            //        lstFlujoDetalle.Add(flujoDetalle);
            //    }


            //    return lstFlujoDetalle;
            //    //string json = JsonConvert.SerializeObject(result, Formatting.Indented);

            //    //return json;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("ERROR : " + ex.Message);
            //    string error = ex.Message;
            //    return Enumerable.Empty<FlujoDetalle>();
            //}
        }

        public async Task<IEnumerable<SP_FILTRA_USUARIO_ROL>> GetDetalle(int id_usuario)
        {
            try
            {
                var p = new OracleDynamicParameters();
                p.Add("v_id_usuario", id_usuario, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
                p.Add("ROL_V", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
                var result = await _dbConnection.QueryAsync<SP_FILTRA_USUARIO_ROL>("PKG_TAREA.SP_FILTRA_USUARIO_ROL", p, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return Enumerable.Empty<SP_FILTRA_USUARIO_ROL>();
            }
        }

        public Task<IEnumerable<Flujo>> Read(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Flujo>> Read(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<PostResponse> Update(Flujo Modelo)
        {
            throw new NotImplementedException();
        }
    }
}
