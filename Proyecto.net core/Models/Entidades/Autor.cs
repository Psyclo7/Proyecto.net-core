using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.net_core.Models.Entidades
{
    public class Autor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_autor { get; set; }
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string nombre_autor { get; set; }
        public string apellido_autor { get; set; }
    }
}
