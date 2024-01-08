using Microsoft.EntityFrameworkCore;
using Proyecto.net_core.Models.Entidades;

namespace Proyecto.net_core.Models
{
    public class LibreriaContext:DbContext{
        //opciones de get set
        public LibreriaContext()
        {

        }
        //opciones de la base de datos
        public LibreriaContext(DbContextOptions<LibreriaContext> options) : base(options)
        {

        }
        //debset llama alas entidades 
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<DetalleVenta> Detalle_Ventas { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ventas> Ventas { get; set; }
        //modelo de creacion 
        //metodo para conectar la base de datos con el visual studio
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
