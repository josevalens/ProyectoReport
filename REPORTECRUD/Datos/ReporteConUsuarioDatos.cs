using REPORTECRUD.Data;
using REPORTECRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace REPORTECRUD.Datos
{
    public class ReportesConUsuarioDatos
    {
        public List<ReportesConUsuarioModel> ObtenerReportes()
        {
            var oReporte = new List<ReportesConUsuarioModel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerReportesConUsuario", conexion);


                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oReporte.Add(new ReportesConUsuarioModel()
                        {
                            IdReporte = Convert.ToInt32(dr["IdReporte"]),
                            FechaCreacion = (DateTime)dr["FechaCreacion"],
                            Problematica = dr["Problematica"].ToString(),
                            NombreUsuario = dr["NombreReporte"].ToString(),

                        });
                    }
                }
                conexion.Close();
            }
            return oReporte;

        }
    }
}
