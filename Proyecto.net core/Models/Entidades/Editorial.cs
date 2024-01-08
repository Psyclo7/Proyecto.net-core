using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.net_core.Models.Entidades
{
    public class Editorial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_editorial {get; set;}
        [Required(ErrorMessage ="El campo{0} es obligatorio")]
        public string nombre_editorial { get; set;}
    }
}
