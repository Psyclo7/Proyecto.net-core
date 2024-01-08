using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.net_core.Models.Entidades
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int id_libro { get; set; }
        public string titulo { get; set; }
        public int año { get; set; }
        public bool estado { get; set; }
        public decimal precio { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:c2}")]
        [NotMapped]
        public String fecha_registro { get; set; }   
        public string url_libro { get; set; }
        //Aqui se hace para crear las relaciones
        public int id_autor { get; set; }
        public Autor Autor { get; set; }
        public int id_editorial { get; set; }
        public Editorial Editorial { get; set; }
        public int id_categoria { get; set; }
        public Categoria categoria { get; set; }
    }
}
