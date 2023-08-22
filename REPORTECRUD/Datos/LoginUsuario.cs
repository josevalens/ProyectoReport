using System.Data.SqlClient;
using System.Data;
using REPORTECRUD.Models;
using REPORTECRUD.Data;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;

namespace REPORTECRUD.Datos
{
    public class LoginUsuario
    {
        public bool Registro(UsuarioModelo model)
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

        public bool existeCorreo(string Correo) 
        {
            string eCorreo = "";
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql())) 
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_ValidarCorreo", conexion);
                cmd.Parameters.AddWithValue("Correo", Correo);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader()) 
                { 
                    while (dr.Read()) 
                    {
                        eCorreo = dr["Correo"].ToString();
                    }
                }
            } 
            if(eCorreo == "") 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public UsuarioModelo ValidarUsuario(string Correo, string Contraseña) 
        {
            UsuarioModelo usuario = new UsuarioModelo();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSql())) 
            { 
                conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_ValidarUsuario", conexion);
                cmd.Parameters.AddWithValue("Correo", Correo);
                cmd.Parameters.AddWithValue("Contraseña", Contraseña);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader()) 
                {
                    while (dr.Read()) 
                    {
                        usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        usuario.Nombre = dr["Nombre"].ToString();
                        usuario.Correo = dr["Correo"].ToString();
                        usuario.Contraseña = dr["Contraseña"].ToString();
                    }
                }
            }
            return usuario;
        }

        public bool CambiarContraseña(string Correo, string Contraseña) 
        {
            bool respuesta;
            try 
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSql())) 
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("Sp_CambiarContraseña", conexion);
                    cmd.Parameters.AddWithValue("Correo", Correo);
                    cmd.Parameters.AddWithValue("Contraseña", Contraseña);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch(Exception ex) 
            {
                string error = ex.Message;
                respuesta = false;
            }
            return respuesta;
        }

    }
}
