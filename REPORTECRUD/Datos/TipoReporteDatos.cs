using REPORTECRUD.Models;
using REPORTECRUD.Controllers;
using REPORTECRUD.Data;
using System.Data.SqlClient;
using System.Data;

namespace REPORTECRUD.Data
{
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
}