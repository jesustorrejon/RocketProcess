using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos.ModelFlujo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Services.Servicios.Services
{
    public class EstadoServices : IEstadoServices
    {
        private readonly HttpClient _httpClient;
        public EstadoServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Estado>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Estado>>($"api/Estado");
        }
    }
}
