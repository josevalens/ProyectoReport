using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Models;
using REPORTECRUD.Data;
using System.Data.SqlClient;
using System.Data;

namespace REPORTECRUD.Controllers
{
    public class UbicacionController : Controller
    {
        UbicacionDatos _ubicacionDatos = new UbicacionDatos();
        public IActionResult Listar()
        {
            var lista = _ubicacionDatos.ListarUbicacion();
            return View(lista);
        }
    }
}