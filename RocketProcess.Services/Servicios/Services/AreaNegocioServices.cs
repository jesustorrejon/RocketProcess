using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Services.Servicios.Services
{
    public class AreaNegocioServices : IAreaNegocioServices
    {
        private readonly HttpClient _httpClient;

        public AreaNegocioServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Area_Negocio>> ListarAreaNegocios()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Area_Negocio>>($"api/AreaNegocio/Listar");
        }
    }
}
