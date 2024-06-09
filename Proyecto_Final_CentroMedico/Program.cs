
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity;
using Proyecto_Final_CentroMedico;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_CentroMedico.Servicios.Contrato;
using Proyecto_Final_CentroMedico.Servicios.Implementacion;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Conn") ?? throw new InvalidOperationException("Connection string 'Conn' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

try
{
    builder.Services.AddDbContext<ClinicaReumatologiaContext>(options => options.UseSqlServer("name=Conn"));
    Console.WriteLine("Conexi�n a la base de datos establecida con �xito.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
}

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddControllersWithViews(options => {
    options.Filters.Add(
            new ResponseCacheAttribute
            {
                NoStore = true,
                Location = ResponseCacheLocation.None,
            }
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=IniciarSesion}/{id?}");


app.Run();
