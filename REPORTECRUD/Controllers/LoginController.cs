using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Datos;
using REPORTECRUD.Models;
using REPORTECRUD.Recurso;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;

namespace REPORTECRUD.Controllers
{
    public class LoginController : Controller
    {
        LoginUsuario _log = new LoginUsuario();
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(UsuarioModelo model) 
        {
            if (!ModelState.IsValid) 
            { 
                return View();
            }
            model.Contraseña = Utilidades.EncriptarContraseña(model.Contraseña);
            bool crearUsuario = _log.Registro(model);
            if(!crearUsuario) 
            {
                ViewData["Mensaje"] = "El correo ingresado ya se encuentra registrado";
                return View();
            }
            else 
            {
                return RedirectToAction("Login");
            }
        }

        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Login (string Correo, string Contraseña) 
        {
            UsuarioModelo usuario = _log.ValidarUsuario(Correo, Utilidades.EncriptarContraseña(Contraseña));
            if(usuario.IdUsuario == 0)
            {
                ViewData["Mensaje"] = "El correo o la contraseña son incorrectas";
                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim (ClaimTypes.Name,usuario.Nombre)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult CambiarContraseña() 
        {
            return View();
        }
        [HttpPost]

        public IActionResult CambiarContraseña(string Correo, string Contraseña)
        {
            bool respuesta = _log.CambiarContraseña(Correo, Utilidades.EncriptarContraseña(Contraseña));
            if (!respuesta)
            {
                ViewData["Mensaje"] = "El correo no existe";
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


    }
}
