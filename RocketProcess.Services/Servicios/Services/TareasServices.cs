using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Modelos.ModelFlujo;
using RocketProcess.Shared.Modelos.ModelTarea;
using RocketProcess.Shared.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Services.Servicios.Services
{
    public class TareasServices : ITareasServices
    {
        private readonly HttpClient _httpClient;

        public TareasServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Response<PostResponse>> Create(Tarea tarea)
        {
            throw new NotImplementedException();
        }

        public Task<Response<PostResponse>> Delete(int Id_Tarea)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tarea>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Tarea>>($"api/Tareas/listar");
        }

        public Task<IEnumerable<TareaDetalle>> GetAllDetalle()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SP_TAREA_GET>> Read(int Id_Tarea)
        {
            using (QueryString qs = new QueryString())
            {
                qs.Add("Id_Tarea", Id_Tarea.ToString());
                return await _httpClient.GetFromJsonAsync<IEnumerable<SP_TAREA_GET>>($"api/Tareas{qs.ObtenerQueryString()}");
            }
        }

        public Task<Response<PostResponse>> Update(Tarea tarea)
        {
            throw new NotImplementedException();
        }
    }
}
