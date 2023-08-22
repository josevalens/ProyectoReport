using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Models;
using REPORTECRUD.Data;
using System.Data.SqlClient;
using System.Data;

namespace REPORTECRUD.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioDatos _usuarioDatos = new UsuarioDatos();
        public IActionResult Listar()
        {
            var lista = _usuarioDatos.Listar();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(UsuarioModelo model)
        {

            var UsuarioCreado = _usuarioDatos.InsertarUsuario(model);
            if (UsuarioCreado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }



        }
        public IActionResult Editar(int IdUsuario)
        {
            UsuarioModelo _usuariodatos = _usuarioDatos.ObtenerUsuarios(IdUsuario);
            return View(_usuariodatos);

        }
        [HttpPost]
        public IActionResult Editar(UsuarioModelo model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _usuarioDatos.ActualizarUsuario(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Eliminar(int IdUsuario)
        {
            var usuario = _usuarioDatos.ObtenerUsuarios(IdUsuario);
            if (usuario == null)
            {
                return NotFound(); // Otra acción adecuada si no se encuentra el reporte
            }

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Eliminar(UsuarioModelo model)
        {
            var respuesta = _usuarioDatos.EliminarUsuarios(model.IdUsuario);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View(model);
            }
        }

    }
}