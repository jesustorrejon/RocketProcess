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
using System.Threading;
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

        public async Task<Response<PostResponse>> AgregarComentario(Estado_Detalle estado_Detalle)
        {
            var result = await _httpClient.PostAsJsonAsync<Estado_Detalle>($"api/Tareas/AgregarComentario", estado_Detalle);
            return await result.Content.ReadFromJsonAsync<Response<PostResponse>>();
        }

        public async Task<Response<PostResponse>> Create(Tarea tarea)
        {
            var result = await _httpClient.PostAsJsonAsync<Tarea>($"api/Tareas", tarea);
            return await result.Content.ReadFromJsonAsync<Response<PostResponse>>();
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

        public async Task<Response<PostResponse>> Guardar(Tarea tarea)
        {
            if (tarea.Id_Tarea > 0)
            {
                return await Update(tarea);
            }
            else
            {
                return await Create(tarea);
            }
        }

        public async Task<IEnumerable<Estado_Detalle>> ObtenerComentarios(int id_tarea)
        {
            
            using (QueryString qs = new QueryString())
            {
                qs.Add("Id_Tarea", id_tarea.ToString());
                return await _httpClient.GetFromJsonAsync<IEnumerable<Estado_Detalle>>($"api/Tareas/ObtenerComentarios{qs.ObtenerQueryString()}");
            }
        }

        public async Task<IEnumerable<SP_TAREA_GET>> Read(int Id_Tarea)
        {
            using (QueryString qs = new QueryString())
            {
                qs.Add("Id_Tarea", Id_Tarea.ToString());
                return await _httpClient.GetFromJsonAsync<IEnumerable<SP_TAREA_GET>>($"api/Tareas{qs.ObtenerQueryString()}");
            }
        }

        public async Task<Response<PostResponse>> Update(Tarea tarea)
        {
            var result = await _httpClient.PutAsJsonAsync<Tarea>($"api/Tareas", tarea);
            return await result.Content.ReadFromJsonAsync<Response<PostResponse>>();
        }
    }
}
