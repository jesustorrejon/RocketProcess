using Microsoft.AspNetCore.Authorization;
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
        //[Authorize(Roles ="Administrator")]
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            

            var result = await _usuariosRepositories.Create(xUsuario);

            return Ok(new Response<PostResponse>(result));
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

            return Ok(new Response<PostResponse>(result));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int Id_Usuario)
        {
            int id = Convert.ToInt32(Id_Usuario);
            var result = await _usuariosRepositories.Delete(Id_Usuario);

            return Ok(new Response<PostResponse>(result));
        }
    }
}
