using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<bool>> Agregar([FromBody]UsuarioDetalle xUsuario)
        {
            return await _usuariosRepositories.Guardar(xUsuario);
        }
        //[HttpGet]
        //[Route("login")]
        //public async Task<int> Login([FromQuery] string correo, [FromQuery] string clave)
        //{
        //    return await _usuariosRepositories.Login(correo, clave);
        //}
    }
}
