using REPORTECRUD.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Components.Forms;
using System.Security.Cryptography.X509Certificates;


namespace REPORTECRUD.Data
{
    public class ReporteDatos
    {
        public List<Reporte> Listar()
        {
            //Crear Lista Vacia
            var oCrear = new List<Reporte>();

            //Crear instacia
            var cr = new Conexion();

            //Utilizar using para establecer la cadena de conexion
            using (var conexion = new SqlConnection(cr.getCadenaSql()))
            {
                //Abrir conexion
                conexion.Open();

                //Comando a ejecutar
                SqlCommand cmd = new SqlCommand("ObtenerReportes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCrear.Add(new Reporte()
                        {
                            IdReporte = Convert.ToInt32(dr["IdReporte"]),
                            ubicacion = dr["ubicacion"].ToString(),
                            TipoReporte = dr["TipoReporte"].ToString(),
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
                SqlCommand cmd = new SqlCommand("ObtenerRepoteId", conexion);
                cmd.Parameters.AddWithValue("IdReporte", IdReporte);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oReporte.IdReporte = Convert.ToInt32(dr["IdReporte0"]);
                        oReporte.ubicacion = dr["ubicacion"].ToString();
                        oReporte.TipoReporte = dr["TipoReporte"].ToString();
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
                    SqlCommand cmd = new SqlCommand("InsertarReporte", conexion);
                    cmd.Parameters.AddWithValue("Ubicacion", model.ubicacion);
                    cmd.Parameters.AddWithValue("TipoReporte", model.TipoReporte);
                    cmd.Parameters.AddWithValue("FechaCreacion", model.FechaCreacion);
                    cmd.Parameters.AddWithValue("Problematica", model.Problematica);
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
        public bool EditarReporte(Reporte model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarReporte", conexion);
                    cmd.Parameters.AddWithValue("IdReporte", model.IdReporte);
                    cmd.Parameters.AddWithValue("Ubicacion", model.ubicacion);
                    cmd.Parameters.AddWithValue("TipoReporte", model.TipoReporte);
                    cmd.Parameters.AddWithValue("FechaCreacion", model.FechaCreacion);
                    cmd.Parameters.AddWithValue("Problematica", model.Problematica);
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

        internal bool InsertarReporte(ReporteDatos model)
        {
            throw new NotImplementedException();
        }
    }
}
