using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.net_core.Models.Entidades
{
    public class DetalleVenta 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_detalleVenta { get; set; }
        [Required(ErrorMessage = "El campo{0 es obligatorio}")]
        public int id_venta { get; set; }
        public Ventas Ventas { get; set; }
        public int id_libro { get; set; }
        public Libro Libro { get; set; }
        public int cantidad { get; set; }
    }
}
