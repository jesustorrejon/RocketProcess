using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Repositories.Repositories;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos.ModelFlujo;

namespace RocketProcess.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
        private readonly ICRUD<Estado> _EstadoRepositories;

        public EstadoController(ICRUD<Estado> estadoRepositories)
        {
            _EstadoRepositories = estadoRepositories;
        }

        [HttpGet]
        public async Task<IEnumerable<Estado>> GetAll()
        {
            return await _EstadoRepositories.GetAll();
        }
    }
}
