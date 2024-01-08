using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.net_core.Models.Entidades
{
    public class Roles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_rol {set; get; }
        [Required(ErrorMessage ="Este campo {0} es obligatorio")]
        public string nombre_rol { set; get; }
    }
}
