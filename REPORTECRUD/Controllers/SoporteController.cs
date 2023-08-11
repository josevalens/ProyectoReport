using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Models;
using REPORTECRUD.Data;
using System.Data.SqlClient;
using System.Data;

namespace REPORTECRUD.Controllers
{
    public class SoporteController : Controller
    {
        SoporteDatos _SoporteDatos = new SoporteDatos();
        public IActionResult Listar()
        {
            var lista = _SoporteDatos.Listar();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(SoporteTecnico model)
        {

            var UsuarioCreado = _SoporteDatos.InsertarSoporte(model);
            if (UsuarioCreado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }



        }
        public IActionResult Editar(int IdSoporteTec)
        {
            var _reportedatos = _SoporteDatos.ObtenerSoportes(IdSoporteTec);
            return View(_reportedatos);

        }
        [HttpPost]
        public IActionResult Editar(SoporteTecnico model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _SoporteDatos.ActualizarSoporte(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Eliminar(int IdSoporteTec)
        {
            var soporte = _SoporteDatos.ObtenerSoportes(IdSoporteTec);
            if (soporte.IdSoporteTec == null)
            {
                return NotFound(); // Manejar el caso donde no se encuentra el registro
            }

            return View(soporte); // Pasar el objeto SoporteTecnico a la vista
        }

        [HttpPost]
        public IActionResult Eliminar(SoporteTecnico model)
        {
            var respuesta = _SoporteDatos.EliminarSoporteTecnico(model.IdSoporteTec);
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