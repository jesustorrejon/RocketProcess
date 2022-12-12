using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Repositories.Repositories;
using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Modelos.ModelTarea;

namespace RocketProcess.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {
        private readonly ICRUD<Tarea> CRUD;
        private readonly ITareasRepositories _tareasRepositories;

        public TareasController(ICRUD<Tarea> cRUD, ITareasRepositories tareasRepositories)
        {
            CRUD = cRUD;
            _tareasRepositories = tareasRepositories;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Tarea tarea)
        {
            var result = await CRUD.Create(tarea);
            
            return Ok(new Response<PostResponse>(result));
        }

        [HttpPost]
        [Route("AgregarComentario")]
        public async Task<IActionResult> AgregarComentario([FromBody] Estado_Detalle estado_Detalle)
        {
            var result = await _tareasRepositories.AgregarComentario(estado_Detalle);

            return Ok(new Response<PostResponse>(result));
        }

        [HttpGet]
        public async Task<IEnumerable<SP_TAREA_GET>> Read([FromQuery] int Id_Tarea)
        {
            var re = Request;
            var headers = re.Headers;

            return await _tareasRepositories.Read(Id_Tarea);
        }

        [HttpGet]
        [Route("ObtenerComentarios")]
        public async Task<IEnumerable<Estado_Detalle>> ObtenerComentarios([FromQuery] int Id_Tarea)
        {
            var re = Request;
            var headers = re.Headers;

            return await _tareasRepositories.ObtenerComentarios(Id_Tarea);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IEnumerable<Tarea>> GetAll()
        {
            return await CRUD.GetAll();
        }

        [HttpGet]
        [Route("detalle")]
        public async Task<IEnumerable<TareaDetalle>> GetAllDetalle()
        {
            return await _tareasRepositories.GetAllDetalle();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Tarea tarea)
        {
            var result = await CRUD.Update(tarea);

            return Ok(new Response<PostResponse>(result));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int Id_Tarea)
        {
            int id = Convert.ToInt32(Id_Tarea);
            var result = await CRUD.Delete(Id_Tarea);

            return Ok(new Response<PostResponse>(result));
        }
    }
}
