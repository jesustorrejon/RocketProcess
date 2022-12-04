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

        public async Task<IEnumerable<FlujoDetalle>> GetAllDetalle()
        {
            try
            {
                TareasRepositories tr = new TareasRepositories(_dbConnection);
                EstadoRepositories er = new EstadoRepositories(_dbConnection);
                UsuariosRepositories ur = new UsuariosRepositories(_dbConnection);
                
                List<FlujoDetalle> lstFlujoDetalle = new List<FlujoDetalle>();

                var EnumFlujos = await GetAll();
                var EnumTareas = await tr.GetAll();
                var EnumEstados = await er.GetAll();
                var EnumUsuarios = await ur.GetAll();

                foreach (var flujo in EnumFlujos)
                {
                    FlujoDetalle flujoDetalle = new FlujoDetalle();
                    flujoDetalle.Id_Flujo = flujo.Id_Flujo;
                    flujoDetalle.Nombre = flujo.Nombre;
                    flujoDetalle.Descripcion = flujo.Descripcion;

                    foreach (var tarea in EnumTareas)
                    {
                        if (tarea.Id_Flujo == flujo.Id_Flujo)
                        {
                            TareaDeFlujo tareaDeFlujo = new TareaDeFlujo();
                            tareaDeFlujo.Id_Tarea = tarea.Id_Tarea;
                            tareaDeFlujo.Nombre = tarea.Nombre;
                            tareaDeFlujo.Fecha_Inicio = tarea.Fecha_Inicio;
                            tareaDeFlujo.Fecha_Termino = tarea.Fecha_Termino;
                            tareaDeFlujo.Descripcion_Tarea = tarea.Descripcion_Tarea;
                            tareaDeFlujo.Estado_Tarea = EnumEstados.Where(estado => estado.Id_Estado == tarea.Id_Estado).FirstOrDefault().Descripcion;
                            tareaDeFlujo.Dias_Plazo = (tarea.Fecha_Termino - tarea.Fecha_Inicio).Days;

                            var dias_retrazo = (DateTime.Now - tarea.Fecha_Termino).Days;

                            tareaDeFlujo.Dias_Retrazo = dias_retrazo < 0 ? 0 : dias_retrazo;
                            tareaDeFlujo.Comentario = "";
                            tareaDeFlujo.Progreso = (((tarea.Fecha_Termino - DateTime.Now).Days * 100) / tareaDeFlujo.Dias_Plazo);

                            foreach (var usuario in EnumUsuarios)
                            {
                                if (usuario.Id_Usuario == tarea.Id_Usuario)
                                {
                                    tareaDeFlujo.Usuario_Asignado.Id_Usuario = usuario.Id_Usuario;
                                    tareaDeFlujo.Usuario_Asignado.Nombre = usuario.Nombre;
                                    tareaDeFlujo.Usuario_Asignado.Apell_Paterno = usuario.Apell_Paterno;
                                    tareaDeFlujo.Usuario_Asignado.Apell_Materno = usuario.Apell_Materno;
                                    tareaDeFlujo.Usuario_Asignado.Correo = usuario.Correo;
                                    tareaDeFlujo.Usuario_Asignado.Telefono = usuario.Telefono;
                                }
                                if (usuario.Id_Usuario == tarea.Id_Supervisor)
                                {
                                    tareaDeFlujo.Usuario_Supervisor.Id_Usuario = usuario.Id_Usuario;
                                    tareaDeFlujo.Usuario_Supervisor.Nombre = usuario.Nombre;
                                    tareaDeFlujo.Usuario_Supervisor.Apell_Paterno = usuario.Apell_Paterno;
                                    tareaDeFlujo.Usuario_Supervisor.Apell_Materno = usuario.Apell_Materno;
                                    tareaDeFlujo.Usuario_Supervisor.Correo = usuario.Correo;
                                    tareaDeFlujo.Usuario_Supervisor.Telefono = usuario.Telefono;
                                }
                            }

                            flujoDetalle.Tareas.Add(tareaDeFlujo);
                        }
                    }
                    lstFlujoDetalle.Add(flujoDetalle);
                }


                return lstFlujoDetalle;
                //string json = JsonConvert.SerializeObject(result, Formatting.Indented);

                //return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : " + ex.Message);
                string error = ex.Message;
                return Enumerable.Empty<FlujoDetalle>();
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
