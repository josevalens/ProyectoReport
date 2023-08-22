using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
namespace REPORTECRUD.Models

{
    public class Reporte
    {
        public int IdReporte { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public DateTime FechaCreacion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Problematica { get; set; }
        //[Required(ErrorMessage = "El campo es obligatorio")]
        [BindNever]
        public string? IdUsuario2 { get; set; }

        public TipoReporteModel? refTipoReporte { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]



        public UbicacionModel? refUbicacion { get; set; }




    }
}