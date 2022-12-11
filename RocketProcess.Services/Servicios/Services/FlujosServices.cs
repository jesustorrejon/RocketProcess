using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos.ModelFlujo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Services.Servicios.Services
{
    public class FlujosServices : IFlujosServices
    {
        private readonly HttpClient _httpClient;

        public FlujosServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<FlujoDetalle>> ObtenerFlujos()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FlujoDetalle>>($"api/Flujo/Detalle");
        }
    }
}
