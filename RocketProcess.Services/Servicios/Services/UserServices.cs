using Microsoft.AspNetCore.Components.Authorization;
using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Shared;
using RocketProcess.Shared.Entidades;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Utilidades;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RocketProcess.Services.Servicios.Services
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        string? token;

        public UserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response<PostResponse>> Delete(int Id_Usuario)
        {
            using (QueryString qs = new QueryString())
            {
                qs.Add("Id_Usuario", Id_Usuario.ToString());
                var result = await _httpClient.DeleteAsync($"api/Usuarios{qs.ObtenerQueryString()}");
                return await result.Content.ReadFromJsonAsync<Response<PostResponse>>();
            }
            
        }

        public async Task<IEnumerable<ListUser>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ListUser>>($"api/Usuarios/listar");
        }

        public async Task<IEnumerable<ListUser>> Read(int Id_Usuario)
        {
            using (QueryString qs = new QueryString())
            {
                qs.Add("Id_Usuario", Id_Usuario.ToString());
                return await _httpClient.GetFromJsonAsync<IEnumerable<ListUser>>($"api/Usuarios{qs.ObtenerQueryString()}");
            }
        }

        public async Task<Response<PostResponse>> Save(ListUser xUsuario)
        {
            if (xUsuario.Id_Usuario > 0)
            {
                var result = await _httpClient.PutAsJsonAsync<ListUser>($"api/Usuarios", xUsuario);
                return await result.Content.ReadFromJsonAsync<Response<PostResponse>>();
            }
            else
            {
                var result = await _httpClient.PostAsJsonAsync<ListUser>($"api/Usuarios", xUsuario);
                return await result.Content.ReadFromJsonAsync<Response<PostResponse>>();
            }
            
        }
    }
}
