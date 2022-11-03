using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using RocketProcess.Razor;
using RocketProcess.Razor.Pages.Usuarios;
using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Services.Servicios.Services;

namespace RocketProcessDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWindowsFormsBlazorWebView();
            serviceCollection.AddScoped<ILoginServices, LoginServices>();
            serviceCollection.AddScoped<IUserServices, UserServices>();
            serviceCollection.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("http://jesustorrejon.cl") });
            //serviceCollection.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            serviceCollection.AddMudServices();
            InitializeComponent();

            blazorWebView1.HostPage = @"wwwroot\index.html";
            blazorWebView1.Services = serviceCollection.BuildServiceProvider();
            blazorWebView1.RootComponents.Add<App>("#app");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}