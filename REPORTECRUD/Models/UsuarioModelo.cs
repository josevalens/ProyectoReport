using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace REPORTECRUD.Models
{
    public class UsuarioModelo
    {

        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Contraseña { get; set; }


    }

}
