using REPORTECRUD.Models;
using System.Data.SqlClient;
using System.Data;

namespace REPORTECRUD.Data
{
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