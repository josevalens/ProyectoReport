using Microsoft.VisualBasic;

namespace REPORTECRUD.Models
{
    public class InfoReporteModel
    {
        public int IdReporte { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public String? Problematica { get; set; }
        public String? NombreReporte { get; set; }

        public String? NombreUbicacion { get; set; }

    }
}