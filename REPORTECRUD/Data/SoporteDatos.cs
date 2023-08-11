using REPORTECRUD.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Components.Forms;
using System.Security.Cryptography.X509Certificates;


namespace REPORTECRUD.Data
{
    public class SoporteDatos
    {
        public List<SoporteTecnico> Listar()
        {
            //Crear Lista Vacia
            var oCrear = new List<SoporteTecnico>();

            //Crear instacia
            var cr = new Conexion();

            //Utilizar using para establecer la cadena de conexion
            using (var conexion = new SqlConnection(cr.getCadenaSql()))
            {
                //Abrir conexion
                conexion.Open();

                //Comando a ejecutar
                SqlCommand cmd = new SqlCommand("SeleccionarSoporteTecnico", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCrear.Add(new SoporteTecnico()
                        {
                            IdSoporteTec = Convert.ToInt32(dr["IdSoporteTec"]),
                            Mensaje = dr["Mensaje"].ToString(),
                            
                        });
                    }
                }
            }
            return oCrear;
        }

        public SoporteTecnico ObtenerSoportes(int IdSoporteTec)
        {
            var oSoporte = new SoporteTecnico();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerSoporteId", conexion);
                cmd.Parameters.AddWithValue("IdSoporteTec", IdSoporteTec);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oSoporte.IdSoporteTec = Convert.ToInt32(dr["IdSoporteTec"]);
                        oSoporte.Mensaje = dr["Mensaje"].ToString();
                       
                    }
                }
            }
            return oSoporte;
        }

        public bool InsertarSoporte(SoporteTecnico model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarSoporteTecnico", conexion);
                    cmd.Parameters.AddWithValue("mensaje", model.Mensaje);
                    
                    
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
        public bool ActualizarSoporte(SoporteTecnico model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("ActualizarSoporteTecnico", conexion);
                    cmd.Parameters.AddWithValue("IdSoporteTec", model.IdSoporteTec);
                    cmd.Parameters.AddWithValue("Mensaje", model.Mensaje);
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
        public bool EliminarSoporteTecnico(int IdSoporteTec)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EliminarSoporteTecnico", conexion);
                    cmd.Parameters.AddWithValue("IdSoporteTec", IdSoporteTec);
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


    }
}
