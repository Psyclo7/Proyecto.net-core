using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.net_core.Models.Entidades
{
    public class Ventas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_ventas { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal descuentos { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public decimal subtotal { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        public decimal iva { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]

        [NotMapped]
        public String fecha_venta { get; set; }
        public int id_usuario { get; set; }
        public Usuario Usuario { get; set; }

    }
}
