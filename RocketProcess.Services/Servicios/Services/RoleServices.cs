using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Services.Servicios.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly HttpClient _httpClient;
        public RoleServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<PostResponse>> Create(Rol rol)
        {
            var result = await _httpClient.PostAsJsonAsync<Rol>($"api/Role", rol);
            return await result.Content.ReadFromJsonAsync<Response<PostResponse>>();
        }

        public async Task<Response<PostResponse>> Delete(int Id_Rol)
        {
            using (QueryString qs = new QueryString())
            {
                qs.Add("Id_Rol", Id_Rol.ToString());
                var result =  await _httpClient.DeleteAsync($"api/Role{qs.ObtenerQueryString()}");
                return await result.Content.ReadFromJsonAsync<Response<PostResponse>>();
            }
        }

        public async Task<IEnumerable<Rol>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Rol>>($"api/Role/listar");
        }

        public async Task<IEnumerable<Rol>> Read(int Id_Rol)
        {
            using (QueryString qs = new QueryString())
            {
                qs.Add("Id_Rol", Id_Rol.ToString());
                return await _httpClient.GetFromJsonAsync<IEnumerable<Rol>>($"api/Role{qs.ObtenerQueryString()}");
            }
            
        }

        public async Task<Response<PostResponse>> Update(Rol rol)
        {
            var result = await _httpClient.PutAsJsonAsync<Rol>($"api/Role", rol);
            return await result.Content.ReadFromJsonAsync<Response<PostResponse>>();
        }
    }
}
