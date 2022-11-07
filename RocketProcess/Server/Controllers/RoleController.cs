using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MudBlazor;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Repositories.Repositories;
using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;

namespace RocketProcess.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepositories _roleRepositories;
        private PostResponse pr = new PostResponse();

        public RoleController(IRoleRepositories roleRepositories)
        {
            _roleRepositories = roleRepositories;
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IEnumerable<Rol>> GetAll()
        {
            return await _roleRepositories.GetAll();
        }

        [HttpGet]
        public async Task<IEnumerable<Rol>> Read([FromQuery]int Id_Rol)
        {
            return await _roleRepositories.Read(Id_Rol);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int Id_Rol)
        {
            var result = await _roleRepositories.Delete(Id_Rol);
            pr.Success = result;
            pr.Error = result ? "" : $"Problema al eliminar el rol con id {Id_Rol}";

            return Ok(new Response<PostResponse>(pr));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Rol rol)
        {
            var result = await _roleRepositories.Update(rol);

            pr.Success = result;
            pr.Error = result? "" : $"Problema al actualizar el rol {rol.Nombre_Rol}";

            return Ok(new Response<PostResponse>(pr));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Rol rol)
        {
            var result = await _roleRepositories.Create(rol);

            pr.Success = result;
            pr.Error = result ? "" : $"Problema al crear el rol {rol.Nombre_Rol}";

            return Ok(new Response<PostResponse>(pr));

        }
    }
}
