using REPORTECRUD.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Components.Forms;
using System.Security.Cryptography.X509Certificates;


namespace REPORTECRUD.Data
{
    public class UsuarioDatos
    {
        public List<UsuarioModelo> Listar()
        {
            //Crear Lista Vacia
            var oCrear = new List<UsuarioModelo>();

            //Crear instacia
            var cr = new Conexion();

            //Utilizar using para establecer la cadena de conexion
            using (var conexion = new SqlConnection(cr.getCadenaSql()))
            {
                //Abrir conexion
                conexion.Open();

                //Comando a ejecutar
                SqlCommand cmd = new SqlCommand("ObtenerUsuarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCrear.Add(new UsuarioModelo()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Nombre = dr["Nombre"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Contraseña = dr["Contraseña"].ToString(),
                        });
                    }
                }
            }
            return oCrear;
        }

        public UsuarioModelo ObtenerUsuarios(int IdUsuario)
        {
            var oUsuario = new UsuarioModelo();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSql()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("ObtenerUsuariosId", conexion);
                cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oUsuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        oUsuario.Nombre = dr["Nombre"].ToString();
                        oUsuario.Correo = dr["Correo"].ToString();
                        oUsuario.Contraseña =dr["Contraseña"].ToString(); ;
                       
                    }
                }
            }
            return oUsuario;
        }

        public bool InsertarUsuario(UsuarioModelo model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("InsertarUsuario", conexion);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Contraseña", model.Contraseña);
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
        public bool ActualizarUsuario(UsuarioModelo model)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("ActualizarUsuario", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", model.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombre", model.Nombre);
                    cmd.Parameters.AddWithValue("Correo", model.Correo);
                    cmd.Parameters.AddWithValue("Contraseña", model.Contraseña);
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
        public bool EliminarUsuarios(int IdUsuario)
        {
            bool respuesta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("EliminarUsuario", conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", IdUsuario);
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
