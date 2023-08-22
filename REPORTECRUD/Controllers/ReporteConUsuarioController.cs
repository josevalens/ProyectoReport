using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Datos;

namespace REPORTECRUD.Controllers
{
    public class ReportesConUsuarioController : Controller
    {
        ReportesConUsuarioDatos _reportesconusuarioDatos = new ReportesConUsuarioDatos();
        public IActionResult Index()
        {
            var lista = _reportesconusuarioDatos.ObtenerReportes();
            return View(lista);
        }
        [HttpGet]
        public IActionResult Guardar()
        {
            return View();
        }
    }
}