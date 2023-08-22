using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore = true,
            Location = ResponseCacheLocation.None,
        });
});

// Add services to the container.
builder.Services.AddControllersWithViews();

//Configuracion para la autentificacion

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.LoginPath = "/LoginController/Login/";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
});

var app = builder.Build();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");



// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); */

app.Run();
    
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller:ReporteController}/{action=Guardar}/{id?}");
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller:SoporteController}/{action=Guardar}/{id?}");
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller:UsuarioController}/{action=Guardar}/{id?}");
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller:InventarioController}/{action=Guardar}/{id?}");
//services

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
var apl = builder.Build();
