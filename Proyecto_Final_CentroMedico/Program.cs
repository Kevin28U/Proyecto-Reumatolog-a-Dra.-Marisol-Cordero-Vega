using DAL;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_CentroMedico;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

try
{
    builder.Services.AddDbContext<ClinicaReumatologiaContext>(options => options.UseSqlServer("name=Conn"));
    Console.WriteLine("Conexión a la base de datos establecida con éxito.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}");
}



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
