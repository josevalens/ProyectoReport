using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Models;
using REPORTECRUD.Data;

namespace REPORTECRUD.Controllers
{
    public class ReporteController : Controller
    {
        ReporteDatos _reporteDatos = new ReporteDatos();
        public IActionResult Listar()
        {
            var lista = _reporteDatos.Listar();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ReporteDatos model)
        {
            var respuesta = _reporteDatos.InsertarReporte(model);
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Editar(int IdReporte)
        {
            Reporte _reportedatos = _reporteDatos.ObtenerReportes(IdReporte);
            return View(_reportedatos);

        }
        [HttpPost]
        public IActionResult Editar(Reporte model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _reporteDatos.EditarReporte(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Eliminar(int IdReporte)
        {
            var respuesta = _reporteDatos.ObtenerReportes(IdReporte);
            return View(_reporteDatos);
        }
        [HttpPost]
        public IActionResult Eliminar(Reporte model)
        {
            var respuesta = _reporteDatos.EliminarReportes(model.IdReporte);
            if (respuesta)
            {
                return RedirectToAction("Listar");

            }
            else
            {
                return View();
            }
        }
    }
}