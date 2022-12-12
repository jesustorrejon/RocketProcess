using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Shared.Entidades;

namespace RocketProcess.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaNegocioController : ControllerBase
    {
        private readonly ICRUD<Area_Negocio> _CRUD;

        public AreaNegocioController(ICRUD<Area_Negocio> cRUD)
        {
            _CRUD = cRUD;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IEnumerable<Area_Negocio>> Listar()
        {
            return await _CRUD.GetAll();
        }
    }
}
