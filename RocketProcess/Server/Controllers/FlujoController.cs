using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Repositories.Repositories;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Modelos.ModelFlujo;

namespace RocketProcess.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlujoController : ControllerBase
    {
        private readonly IFlujoRepositories _flujoRepositories;

        public FlujoController(IFlujoRepositories flujoRepositories)
        {
            _flujoRepositories = flujoRepositories;
        }

        [HttpGet]
        [Route("Detalle")]
        public async Task<IEnumerable<FlujoDetalle>> GetFlujoDetalle()
        {
            return await _flujoRepositories.GetAllDetalle();
        }
    }
}
