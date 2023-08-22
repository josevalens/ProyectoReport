using Microsoft.AspNetCore.Mvc;
using REPORTECRUD.Models;
using REPORTECRUD.Data;
using REPORTECRUD.Controllers;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace REPORTECRUD.Controllers
{
    public class ReporteController : Controller
    {


        TipoReporteModel tiporeporteDatos = new TipoReporteModel();
        TipoReporteDatos _tiporeporteDatos = new TipoReporteDatos();
        public IActionResult ListarA()
        {
            var lista = _tiporeporteDatos.ListarTipoReportes();
            return View(lista);


        }

        UbicacionModel ubicacion = new UbicacionModel();
        UbicacionDatos _ubicacionDatos = new UbicacionDatos();
        public IActionResult ListarB()
        {
            var lista = _ubicacionDatos.ListarUbicacion();
            return View(lista);
        }

        Reporte reporte = new Reporte();
        ReporteDatos __reporteDatos = new ReporteDatos();
        public IActionResult ListarC()
        {
            var listaReporte = _reporteDatos.ListarReporte();
            return View(listaReporte);
        }




        public IActionResult Guardar()
        {
            List<TipoReporteModel> listaTipoReporte = _tiporeporteDatos.ListarTipoReportes();
            List<SelectListItem> listarA = listaTipoReporte.ConvertAll(Item => new SelectListItem()
            {
                Text = Item.Nombre.ToString(),
                Value = Item.IdTipoReporte.ToString(),
                Selected = false
            });

            ViewBag.Lista = listarA;

            List<UbicacionModel> listaUbicacion = _ubicacionDatos.ListarUbicacion();
            List<SelectListItem> listarB = listaUbicacion.ConvertAll(Item => new SelectListItem()
            {
                Text = Item.Nombre.ToString(),
                Value = Item.IdUbicacion.ToString(),
                Selected = false
            });

            ViewBag.ListaB = listarB;

            return View();
        }

        [HttpPost]
        public IActionResult Guardar(Reporte model)
        {
            /*if (!ModelState.IsValid)
             {
                 return View();
             }*/

            var ReporteCreada = _reporteDatos.InsertarReporte(model);
            if (ReporteCreada)
            {
                return RedirectToAction("Listar");
            }
            else
            {

                return View();
            }
        }








        ReporteDatos _reporteDatos = new ReporteDatos();
        public IActionResult Listar()
        {
            var lista = _reporteDatos.ListarReporte();
            return View(lista);
        }
        //[HttpGet]
        //public IActionResult Guardar()
        //{
        //    return View();
        //}
        ////
        //[HttpPost]
        //public IActionResult Guardar(Reporte model)
        //{

        //    var UsuarioCreado = _reporteDatos.InsertarReporte(model);
        //    if (UsuarioCreado)
        //    {
        //        return RedirectToAction("Listar");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        public IActionResult Editar(int IdReporte)
        {
            Reporte _reporte = _reporteDatos.ObtenerReportes(IdReporte);

            List<TipoReporteModel> listaTipoReporte = _tiporeporteDatos.ListarTipoReportes();
            List<SelectListItem> listarA = listaTipoReporte.ConvertAll(Item => new SelectListItem()
            {
                Text = Item.Nombre.ToString(),
                Value = Item.IdTipoReporte.ToString(),
                Selected = false
            }
            );

            ViewBag.Lista = listarA;

            List<UbicacionModel> listaUbicacion = _ubicacionDatos.ListarUbicacion();
            List<SelectListItem> listarB = listaUbicacion.ConvertAll(Item => new SelectListItem()
            {
                Text = Item.Nombre.ToString(),
                Value = Item.IdUbicacion.ToString(),
                Selected = false
            }
            );

            ViewBag.ListaB = listarB;

            return View(_reporte); // Pasar la instalación obtenida y la lista de edificios a la vista
        }

        // Acción de edición POST para actualizar
        [HttpPost]
        public IActionResult Editar(Reporte model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = _reporteDatos.ActualizarReporte(model);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                //  redirigir a una página de error en caso de fallo
                return View();
            }
        }
        public IActionResult Eliminar(int IdReporte)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var reporte = _reporteDatos.ObtenerReportes(IdReporte);
            if (reporte == null)
            {
                return NotFound(); // Otra acción adecuada si no se encuentra el reporte
            }

            return View(reporte);
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
                return View(model);
            }
        }
        public class TipoReporteDatos
        {
            public List<TipoReporteModel> ListarTipoReportes()
            {
                //Crear Lista Vacia
                var oCrear = new List<TipoReporteModel>();

                //Crear instacia
                var cr = new Conexion();

                //Utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(cr.getCadenaSql()))
                {
                    //Abrir conexion
                    conexion.Open();

                    //Comando a ejecutar
                    SqlCommand cmd = new SqlCommand("ObtenerTipoReporte", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCrear.Add(new TipoReporteModel()
                            {
                                IdTipoReporte = Convert.ToInt32(dr["IdTipoReporte"]),
                                Nombre = dr["Nombre"].ToString(),

                            });
                        }
                    }
                }
                return oCrear;
            }
        }
        public class UbicacionDatos
        {
            public List<UbicacionModel> ListarUbicacion()
            {
                //Crear Lista Vacia
                var oCrear = new List<UbicacionModel>();

                //Crear instacia
                var cr = new Conexion();

                //Utilizar using para establecer la cadena de conexion
                using (var conexion = new SqlConnection(cr.getCadenaSql()))
                {
                    //Abrir conexion
                    conexion.Open();

                    //Comando a ejecutar
                    SqlCommand cmd = new SqlCommand("ObtenerUbicacion", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oCrear.Add(new UbicacionModel()
                            {
                                IdUbicacion = Convert.ToInt32(dr["IdUbicacion"]),
                                Nombre = dr["Nombre"].ToString(),

                            });
                        }
                    }
                }
                return oCrear;
            }
        }
    }
}