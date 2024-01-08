using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.net_core.Models.Entidades
{

    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_categoria { get; set; }
        [Required(ErrorMessage = "El campon {0} es obligatorio")]
        public string nombre_categoria { get; set; }
        public string descripcion { get; set; }
    }
}
