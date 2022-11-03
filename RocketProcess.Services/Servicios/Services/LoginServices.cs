//using Microsoft.AspNetCore.WebUtilities;
//using Newtonsoft.Json.Linq;
using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Shared;
using RocketProcess.Shared.Modelos;
using RocketProcess.Shared.Utilidades;
using System.Net.Http.Json;
using System.Text;
using System.Web;

namespace RocketProcess.Services.Servicios.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly HttpClient _httpClient;
        //private QueryString qs = QueryString.Instanciar();

        public LoginServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Login>> LoginConnect(string username, string password)
        {
            using (QueryString qs = new QueryString())
            {
                qs.Add("correo", username);
                qs.Add("clave", password);
                return await _httpClient.GetFromJsonAsync<IEnumerable<Login>>($"api/login{qs.ObtenerQueryString()}");
            }
        }
    }
}
