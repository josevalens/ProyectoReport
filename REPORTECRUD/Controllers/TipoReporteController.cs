using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Models;
using REPORTECRUD.Data;
using REPORTECRUD.Controllers;
using System.Data.SqlClient;
using System.Data;

namespace REPORTECRUD.Controllers
{
    public class TipoReporteController : Controller
    {
        TipoReporteDatos _tiporeporteDatos = new TipoReporteDatos();
        public IActionResult Listar()
        {
            var lista = _tiporeporteDatos.ListarTipoReportes();
            return View(lista);
        }



    }
}
