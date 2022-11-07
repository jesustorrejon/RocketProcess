using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Shared;
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
        public async Task<IEnumerable<Usuario>> GetClientes()
        {
            return await _usuariosRepositories.GetAll();
        }

        [HttpGet]
        [Route("Dataset")]
        public async Task<string> GetDataSet([FromQuery] string query, [FromQuery]string? strNomTabla = null)
        {
            return await _usuariosRepositories.GetDataSet(query, strNomTabla);
        }

        [HttpPost]
        [Route("Agregar")]
        public async Task<IActionResult> Agregar([FromBody]UsuarioDetalle xUsuario)
        {
            var result = await _usuariosRepositories.Guardar(xUsuario);
            PostResponse respuesta = new PostResponse() 
            { 
                Success = result,
                Error = result? "" : "Error al guardar." 
            };

            return Ok(new Response<PostResponse>(respuesta));
            //return JsonConvert.SerializeObject(respuesta, Formatting.Indented);

        }
        //[HttpGet]
        //[Route("login")]
        //public async Task<int> Login([FromQuery] string correo, [FromQuery] string clave)
        //{
        //    return await _usuariosRepositories.Login(correo, clave);
        //}
    }
}
