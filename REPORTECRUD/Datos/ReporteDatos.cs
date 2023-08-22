using REPORTECRUD.Models;
using System.Data.SqlClient;
using System.Data;
using REPORTECRUD.Data;
using Microsoft.AspNetCore.Components.Forms;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace REPORTECRUD.Data
{
    public class ReporteDatos
    {
        public List<Reporte> ListarReporte()
        {
            //Crear Lista Vacia
            List<Reporte> oCrear = new List<Reporte>();

            //Crear instacia
            var cr = new Conexion();

            //Utilizar using para establecer la cadena de conexion
            using (var conexion = new SqlConnection(cr.getCadenaSql()))
            {
                //Abrir conexion
                conexion.Open();

                //Comando a ejecutar
                SqlCommand cmd = new SqlCommand("ObtenerReportef", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCrear.Add(new Reporte
                        {

                            IdReporte = Convert.ToInt32(dr["IdReporte"]),
                            refTipoReporte = new TipoReporteModel
                            {
                                IdTipoReporte = Convert.ToInt32(dr["IdTipoReporte"]),
                                Nombre = dr["TipoReporteNombre"].ToString()
                            },
                            refUbicacion = new UbicacionModel
                            {
                                IdUbicacion = Convert.ToInt32(dr["IdUbicacion"]),
                                Nombre = dr["UbicacionNombre"].ToString()
                            },

                            FechaCreacion = (DateTime)dr["FechaCreacion"],
                            Problematica = dr["Problematica"].ToString(),





                        });
                    }
                }
            }
            return oCrear;
        }

        public Reporte ObtenerReportes(int IdReporte)
        {
            var oReporte = new Reporte();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerReporteId", conexion);
                cmd.Parameters.AddWithValue("IdReporte", IdReporte);

                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oReporte.IdReporte = Convert.ToInt32(dr["IdReporte"]);

                        oReporte.Problematica = dr["Problematica"].ToString();
                        oReporte.FechaCreacion = (DateTime)dr["FechaCreacion"];
                        oReporte.Problematica = dr["Problematica"].ToString();
                    }
                }
            }
            return oReporte;
        }

        public bool InsertarReporte(Reporte model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarReportep", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetros


                    cmd.Parameters.AddWithValue("@IdTipoReporte1", model.refTipoReporte.IdTipoReporte);
                    cmd.Parameters.AddWithValue("@IdUbicacion1", model.refUbicacion.IdUbicacion);
                    cmd.Parameters.AddWithValue("@FechaCreacion", model.FechaCreacion);
                    cmd.Parameters.AddWithValue("@Problematica", model.Problematica);

                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }


        public bool InsertarUbicacion(UbicacionModel model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarUbicacion", conexion);

                    cmd.Parameters.AddWithValue("IdUbicacion1", model.IdUbicacion);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;


        }

        public bool ActualizarReporte(Reporte model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("ActualizarReporte", conexion);
                    cmd.Parameters.AddWithValue("IdReporte", model.IdReporte);
                    cmd.Parameters.AddWithValue("IdTipoReporte1", model.refTipoReporte?.IdTipoReporte);
                    cmd.Parameters.AddWithValue("IdUbicacion1", model.refUbicacion?.IdUbicacion);
                    cmd.Parameters.AddWithValue("FechaCreacion", model.FechaCreacion);
                    cmd.Parameters.AddWithValue("Problematica", model.Problematica);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool EliminarReportes(int IdReporte)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EliminarReporte", conexion);
                    cmd.Parameters.AddWithValue("IdReporte", IdReporte);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }


        public List<Reporte> ObtenerTipoReporteDatos()
        {
            List<Reporte> lista = new List<Reporte>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerTipoReporte", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Reporte
                        {
                            IdReporte = Convert.ToInt32(dr["IdReporte"]),
                            FechaCreacion = (DateTime)dr["FechaCreacion"],
                            Problematica = dr["Problematica"].ToString(),

                        });
                    }
                }
            }

            return lista;
        }

        public List<Reporte> ObtenerUbicacionDatos()
        {
            List<Reporte> lista = new List<Reporte>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerUbicacion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Reporte
                        {
                            IdReporte = Convert.ToInt32(dr["IdReporte"]),
                            FechaCreacion = (DateTime)dr["FechaCreacion"],
                            Problematica = dr["Problematica"].ToString(),

                        });
                    }
                }
            }

            return lista;
        }

    }
}