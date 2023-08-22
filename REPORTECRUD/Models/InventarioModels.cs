using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace REPORTECRUD.Models
{
    public class InventarioModels
    {
        public int IdDispositivo { get; set; }
        public string? Tipo { get; set; }
        public string? Nombre { get; set; }
        public string? Modelo { get; set; }
        public string? Marca { get; set; }
    }
}


   