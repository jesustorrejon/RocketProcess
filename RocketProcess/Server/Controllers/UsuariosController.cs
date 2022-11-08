using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Repositories.Repositories;
using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;

namespace RocketProcess.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepositories _usuariosRepositories;

        public UsuariosController(IUsuariosRepositories usuariosRepositories)
        {
            _usuariosRepositories = usuariosRepositories;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IEnumerable<ListUser>> GetClientes()
        {
            return await _usuariosRepositories.GetAll();
        }

        //[HttpGet]
        //[Route("Dataset")]
        //public async Task<string> GetDataSet([FromQuery] string query, [FromQuery]string? strNomTabla = null)
        //{
        //    return await _usuariosRepositories.GetDataSet(query, strNomTabla);
        //}

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ListUser xUsuario)
        {
            var result = await _usuariosRepositories.Create(xUsuario);
            PostResponse respuesta = new PostResponse() 
            { 
                Success = result,
                Error = result? "" : "Error al guardar." 
            };

            return Ok(new Response<PostResponse>(respuesta));
        }

        [HttpGet]
        public async Task<IEnumerable<ListUser>> Read([FromQuery] int Id_Usuario)
        {
            return await _usuariosRepositories.Read(Id_Usuario);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ListUser xUsuario)
        {
            var result = await _usuariosRepositories.Update(xUsuario);
            PostResponse respuesta = new PostResponse()
            {
                Success = result,
                Error = result ? "" : $"Error al actualizar el usuario {xUsuario.Nombre}."
            };

            return Ok(new Response<PostResponse>(respuesta));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int Id_Usuario)
        {
            var result = await _usuariosRepositories.Delete(Id_Usuario);
            PostResponse respuesta = new PostResponse()
            {
                Success = result,
                Error = result ? "" : $"Error al eliminar el id de usuario {Id_Usuario}."
            };

            return Ok(new Response<PostResponse>(respuesta));
        }

        
    }
}
