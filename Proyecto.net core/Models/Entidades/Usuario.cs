using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto.net_core.Models.Entidades
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id_usuario { set; get; }
        [Required(ErrorMessage ="Este campo{0} es obligatoruio")]
        public string nombre_usuario { set; get;}
        public string cedula { set; get; }
        public string correo { set; get; }
        public string telefono { set; get; }
        public string password { set; get; }
        public int id_rol { set; get; }
    }
}
