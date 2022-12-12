using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RocketProcess.Razor;
using RocketProcess.Razor.Authentication;
using RocketProcess.Razor.Pages.Usuarios;
using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Services.Servicios.Services;
using RocketProcess.Shared.Utilidades;
using System.Dynamic;
using System.Xml;

namespace RocketProcessDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWindowsFormsBlazorWebView();
            serviceCollection.AddBlazoredSessionStorage();
            serviceCollection.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            serviceCollection.AddAuthorizationCore();

            serviceCollection.AddScoped<ILoginServices, LoginServices>();
            serviceCollection.AddScoped<IUserServices, UserServices>();
            serviceCollection.AddScoped<IRoleServices, RoleServices>();
            serviceCollection.AddScoped<IFlujosServices, FlujosServices>();
            serviceCollection.AddScoped<ITareasServices, TareasServices>();
            serviceCollection.AddScoped<IEstadoServices, EstadoServices>();
            serviceCollection.AddScoped<IAreaNegocioServices, AreaNegocioServices>();
            serviceCollection.AddBlazoredSessionStorage();
            serviceCollection.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            serviceCollection.AddAuthorizationCore();
            string apiURL = ObtenerUriApi();
            serviceCollection.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri(apiURL) });
            //serviceCollection.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            serviceCollection.AddMudServices();
            InitializeComponent();

            blazorWebView1.HostPage = @"wwwroot\index.html";
            blazorWebView1.Services = serviceCollection.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<App>("#app");
        }

        #region 'Variables'
        string appSettingsPath;
        string archivoINI;
        dynamic _config;

        #endregion



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        string ObtenerUriApi()
        {
            string strApi = "http://jesustorrejon.cl";
            
            appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "Datos.INI");
            INI _INI = new INI(appSettingsPath);

            if (!File.Exists(appSettingsPath))
            {
                File.WriteAllText(appSettingsPath,"");
            }

            archivoINI = File.ReadAllText(appSettingsPath);


            if (string.IsNullOrEmpty(archivoINI))
            {
                if (string.IsNullOrEmpty( _INI.LeerINI("Conexiones", "ApiURL") ) )
                {
                    _INI.EscribirINI("Conexiones", "ApiURL", strApi);
                }
            }
            else
            {
                strApi = _INI.LeerINI("Conexiones", "ApiURL");
            }

            return strApi;
        }
    }
}