using Microsoft.AspNetCore.ResponseCompression;
using Oracle.ManagedDataAccess.Client;
using RocketProcess.Repositories.Interfaces;
using RocketProcess.Repositories.Repositories;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();

string connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<IDbConnection>((sp) => new OracleConnection(connString));

builder.Services.AddScoped<IUsuariosRepositories, UsuariosRepositories>();
builder.Services.AddScoped<ILoginRepositories, LoginRepositories>();
builder.Services.AddScoped<IRoleRepositories, RoleRepositories>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "RocketProcess API V1");
});

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
