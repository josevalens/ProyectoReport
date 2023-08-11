using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
namespace REPORTECRUD.Models

{
    public class Reporte
    {
        public int IdReporte { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? ubicacion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? TipoReporte { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public DateTime FechaCreacion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Problematica { get; set; }
        //[Required(ErrorMessage = "El campo es obligatorio")]
        [BindNever]
        public string? IdUsuario2 { get; set; }



    }
}