using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Shared;
using RocketProcess.Shared.Modelos;
using System.Net.Http.Json;

namespace RocketProcess.Services.Servicios.Services
{
    public class UserServices : IUserServices
    {
        private readonly HttpClient _httpClient;

        public UserServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Usuario>>($"api/Usuarios/listar");
        }

        public async Task<bool> Guardar(UsuarioDetalle xUsuario)
        {
            var result = await _httpClient.PostAsJsonAsync<UsuarioDetalle>($"api/Usuarios/agregar", xUsuario);
            return result.IsSuccessStatusCode;
        }
    }
}
