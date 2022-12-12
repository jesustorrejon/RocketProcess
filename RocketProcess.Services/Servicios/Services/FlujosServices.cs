using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos.ModelFlujo;
using RocketProcess.Shared.Modelos.ModelTarea;
using RocketProcess.Shared.Utilidades;
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

        public async Task<IEnumerable<SP_FILTRA_USUARIO_ROL>> GetDetalle(int id_usuario)
        {
            using (QueryString qs = new QueryString())
            {
                qs.Add("id_usuario", id_usuario.ToString());
                return await _httpClient.GetFromJsonAsync<IEnumerable<SP_FILTRA_USUARIO_ROL>>($"api/Flujo{qs.ObtenerQueryString()}");
            }
        }

        public async Task<IEnumerable<Flujo>> ListarFlujos()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Flujo>>($"api/Flujo/Listar");
        }

        public async Task<IEnumerable<FlujoDetalle>> ObtenerFlujos()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<FlujoDetalle>>($"api/Flujo/Detalle");
        }
    }
}
