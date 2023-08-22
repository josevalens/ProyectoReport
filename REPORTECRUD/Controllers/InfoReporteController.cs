using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Data;
using REPORTECRUD.Datos;

namespace REPORTECRUD.Controllers
{
    public class InfoReporteController : Controller
    {
        InfoReporteDatos _inforeporteDatos = new InfoReporteDatos();
        public IActionResult Index()
        {
            var lista = _inforeporteDatos.ObtenerReportes();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();
        }
    }
}