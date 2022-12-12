using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Repositories.Repositories;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Modelos.ModelFlujo;
using RocketProcess.Shared.Modelos.ModelTarea;

namespace RocketProcess.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlujoController : ControllerBase
    {
        private readonly IFlujoRepositories _flujoRepositories;
        private readonly ICRUD<Flujo> _CRUD;

        public FlujoController(IFlujoRepositories flujoRepositories, ICRUD<Flujo> cRUD)
        {
            _flujoRepositories = flujoRepositories;
            _CRUD = cRUD;
        }

        [HttpGet]
        public async Task<IEnumerable<SP_FILTRA_USUARIO_ROL>> GetDetalle([FromQuery]string id_usuario)
        {
            int id = Convert.ToInt32(id_usuario);
            return await _flujoRepositories.GetDetalle(id);
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<Flujo>> Listar()
        {
            return await _CRUD.GetAll();
        }

        [HttpGet]
        [Route("Detalle")]
        public async Task<IEnumerable<FlujoDetalle>> GetFlujoDetalle()
        {
            var IEnumSP_FLUJO_GETALLDETALLES = await _flujoRepositories.GetAllDetalle();
            List<FlujoDetalle> ListflujoDetalles = new List<FlujoDetalle>();
            FlujoDetalle flujoDetalle = new FlujoDetalle(); ;
            TareaDeFlujo tareaDeFlujo = new TareaDeFlujo();
            UsuarioDeFlujo usuario_asignado;
            UsuarioDeFlujo usuario_supervisor;

            int id_Flujo = 0;

            foreach (var flujo in IEnumSP_FLUJO_GETALLDETALLES)
            {
                if (id_Flujo != flujo.id_flujo)
                {
                    flujoDetalle = new FlujoDetalle();
                    flujoDetalle.Id_Flujo = flujo.id_flujo;
                    flujoDetalle.Nombre = flujo.nombre;
                    flujoDetalle.Descripcion = flujo.descripcion;

                    id_Flujo = flujo.id_flujo;

                    foreach (var tarea in IEnumSP_FLUJO_GETALLDETALLES.Where(x => x.id_flujo == flujo.id_flujo))
                    {
                        //Tarea
                        tareaDeFlujo = new TareaDeFlujo();

                        tareaDeFlujo.Id_Tarea = tarea.tarea_id_tarea;
                        tareaDeFlujo.Nombre = tarea.tarea_nombre;
                        tareaDeFlujo.Fecha_Inicio = tarea.tarea_fecha_inicio;
                        tareaDeFlujo.Fecha_Termino = tarea.tarea_fecha_termino;
                        tareaDeFlujo.Descripcion_Tarea = tarea.tarea_descripcion_tarea;
                        tareaDeFlujo.Estado_Tarea = tarea.tarea_estado_tarea;
                        tareaDeFlujo.Dias_Plazo = tarea.tarea_dias_plazo;
                        tareaDeFlujo.Dias_Retrazo = tarea.tarea_dias_retrazo;
                        tareaDeFlujo.Progreso = tarea.tarea_progreso;
                        tareaDeFlujo.Comentario = "";

                        //Usuario asignado
                        usuario_asignado = new UsuarioDeFlujo();

                        usuario_asignado.Id_Usuario = tarea.usuario_id_usuario;
                        usuario_asignado.Nombre = tarea.usuario_nombre;
                        usuario_asignado.Apell_Paterno = tarea.usuario_apell_paterno;
                        usuario_asignado.Apell_Materno = tarea.usuario_apell_materno;
                        usuario_asignado.Correo = tarea.usuario_correo;
                        usuario_asignado.Telefono = tarea.usuario_telefono;
                        tareaDeFlujo.Usuario_Asignado = usuario_asignado;

                        //Usuario Supervisor
                        usuario_supervisor = new UsuarioDeFlujo();

                        usuario_supervisor.Id_Usuario = tarea.supervisor_id_usuario;
                        usuario_supervisor.Nombre = tarea.supervisor_nombre;
                        usuario_supervisor.Apell_Paterno = tarea.supervisor_apell_paterno;
                        usuario_supervisor.Apell_Materno = tarea.supervisor_apell_materno;
                        usuario_supervisor.Correo = tarea.supervisor_correo;
                        usuario_supervisor.Telefono = tarea.supervisor_telefono;
                        tareaDeFlujo.Usuario_Supervisor = usuario_supervisor;

                        flujoDetalle.Tareas.Add(tareaDeFlujo);
                    }

                    ListflujoDetalles.Add(flujoDetalle);
                }
            }

            return ListflujoDetalles;
        }
    }
}
