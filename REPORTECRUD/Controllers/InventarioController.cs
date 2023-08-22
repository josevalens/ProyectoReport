using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Models;
using REPORTECRUD.Data;
using System.Data.SqlClient;
using System.Data;

namespace REPORTECRUD.Controllers
{
    public class InventarioController : Controller
    {
        InventarioDatos _inventarioDatos = new InventarioDatos();
        public IActionResult Listar()
        {
            var lista = _inventarioDatos.Listar();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(InventarioModels model)
        {

            var UsuarioCreado = _inventarioDatos.Sp_RegistrarDispositivo(model);
            if (UsuarioCreado)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }



        }
        public IActionResult Editar(int IdDispositivo)
        {
            var _inventariodatos = _inventarioDatos.Sp_ObtenerDispositivos(IdDispositivo);
            return View(_inventariodatos);

        }
        [HttpPost]
        public IActionResult Editar(InventarioModels model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _inventarioDatos.Sp_EditarDispositivo(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Eliminar(int IdDispositivo)
        {
            var dispositivo = _inventarioDatos.Sp_ObtenerDispositivos(IdDispositivo);
            if (dispositivo == null)
            {
                return NotFound(); // Manejar el caso donde no se encuentra el registro
            }

            return View(dispositivo); // Pasar el objeto SoporteTecnico a la vista
        }

        [HttpPost]
        public IActionResult Eliminar(InventarioModels model)
        {
            var respuesta = _inventarioDatos.Sp_EliminarDispositivo(model.IdDispositivo);
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