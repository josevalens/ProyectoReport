using REPORTECRUD.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Components.Forms;
using System.Security.Cryptography.X509Certificates;

namespace REPORTECRUD.Data
{
    public class InventarioDatos
    {
        public List<InventarioModels> Listar()
        {
            var oCrear = new List<InventarioModels>();

            var cr = new Conexion();

            using (var conexion = new SqlConnection(cr.getCadenaSql()))
            {
                conexion.Open();

                SqlCommand cmd = new SqlCommand("Sp_ObtenerDispositivos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCrear.Add(new InventarioModels()
                        {
                            IdDispositivo = Convert.ToInt32(dr["IdDispositivo"]),
                            Tipo = dr["Tipo"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Modelo = dr["Modelo"].ToString(),
                            Marca = dr["Marca"].ToString(),
                        });
                    }
                }
            }
            return oCrear;
        }

        public InventarioModels Sp_ObtenerDispositivos(int IdDispositivo)
        {
            var oDispositivo = new InventarioModels();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_ObtenerDispositivoId", conexion);
                cmd.Parameters.AddWithValue("IdDispositivo", IdDispositivo);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oDispositivo.IdDispositivo = Convert.ToInt32(dr["IdDispositivo"]);
                        oDispositivo.Tipo = dr["Tipo"].ToString();
                        oDispositivo.Nombre = dr["Nombre"].ToString();
                        oDispositivo.Modelo = dr["Modelo"].ToString();
                        oDispositivo.Marca = dr["Marca"].ToString();
                    }
                }
            }
            return oDispositivo;
        }

        public bool Sp_RegistrarDispositivo(InventarioModels model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_RegistrarDispositivo", conexion);
                    cmd.Parameters.AddWithValue("Tipo", model.Tipo);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Modelo", model.Modelo);
                    cmd.Parameters.AddWithValue("Marca", model.Marca);
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
        public bool Sp_EditarDispositivo(InventarioModels model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_EditarDispositivo", conexion);
                    cmd.Parameters.AddWithValue("IdDispositivo", model.IdDispositivo);
                    cmd.Parameters.AddWithValue("Tipo", model.Tipo);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Modelo", model.Modelo);
                    cmd.Parameters.AddWithValue("Marca", model.Marca);
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
        public bool Sp_EliminarDispositivo(int IdDispositivo)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_EliminarDispositivo", conexion);
                    cmd.Parameters.AddWithValue("IdDispositivo", IdDispositivo);
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