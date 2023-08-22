using REPORTECRUD.Data;
using REPORTECRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace REPORTECRUD.Datos
{
    public class InfoReporteDatos
    {
        public List<InfoReporteModel> ObtenerReportes()
        {
            var oReporte = new List<InfoReporteModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerReportes", conexion);


                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oReporte.Add(new InfoReporteModel()
                        {
                            IdReporte = Convert.ToInt32(dr["IdReporte"]),
                            FechaCreacion = (DateTime)dr["FechaCreacion"],
                            Problematica = dr["Problematica"].ToString(),
                            NombreReporte = dr["NombreReporte"].ToString(),
                            NombreUbicacion = dr["NombreUbicacion"].ToString()
                        });
                    }
                }
                conexion.Close();
            }
            return oReporte;

        }
    }
}