using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using RocketProcess.Razor.Authentication;
using RocketProcess.Services.Servicios.Interfaces;
using RocketProcess.Services.Servicios.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<RocketProcess.Razor.App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddAuthorizationCore();

builder.Services.AddMudServices();
builder.Services.AddScoped<ILoginServices, LoginServices>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IRoleServices, RoleServices>();
builder.Services.AddScoped<IFlujosServices, FlujosServices>();
builder.Services.AddScoped<ITareasServices, TareasServices>();
builder.Services.AddScoped<IEstadoServices, EstadoServices>();
builder.Services.AddScoped<IAreaNegocioServices, AreaNegocioServices>();

await builder.Build().RunAsync();
