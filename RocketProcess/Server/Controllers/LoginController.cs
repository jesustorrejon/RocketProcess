using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Shared;
using RocketProcess.Shared.Modelos;

namespace RocketProcess.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepositories _loginRepositories;

        public LoginController(ILoginRepositories loginRepositories)
        {
            _loginRepositories = loginRepositories;
        }

        [HttpGet]
        public async Task<IEnumerable<PostResponse>> GetClientes([FromQuery] string correo, [FromQuery] string clave)
        {
            return await _loginRepositories.Conectar(correo, clave);
        }
    }
}
