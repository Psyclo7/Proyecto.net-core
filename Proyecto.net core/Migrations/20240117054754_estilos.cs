using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.net_core.Migrations
{
    /// <inheritdoc />
    public partial class estilos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    id_autor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido_autor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.id_autor);
                });

            migrationBuilder.CreateTable(
                name: "categorias",
                columns: table => new
                {
                    id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorias", x => x.id_categoria);
                });

            migrationBuilder.CreateTable(
                name: "Editoriales",
                columns: table => new
                {
                    id_editorial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_editorial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editoriales", x => x.id_editorial);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    id_rol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.id_rol);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URLFotoPerfil = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Libros",
                columns: table => new
                {
                    id_libro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    año = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    url_libro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    id_autor = table.Column<int>(type: "int", nullable: false),
                    Autorid_autor = table.Column<int>(type: "int", nullable: false),
                    id_editorial = table.Column<int>(type: "int", nullable: false),
                    Editorialid_editorial = table.Column<int>(type: "int", nullable: false),
                    id_categoria = table.Column<int>(type: "int", nullable: false),
                    categoriaid_categoria = table.Column<int>(type: "int", nullable: false),
                    URLImagen = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libros", x => x.id_libro);
                    table.ForeignKey(
                        name: "FK_Libros_Autores_Autorid_autor",
                        column: x => x.Autorid_autor,
                        principalTable: "Autores",
                        principalColumn: "id_autor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_Editoriales_Editorialid_editorial",
                        column: x => x.Editorialid_editorial,
                        principalTable: "Editoriales",
                        principalColumn: "id_editorial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libros_categorias_categoriaid_categoria",
                        column: x => x.categoriaid_categoria,
                        principalTable: "categorias",
                        principalColumn: "id_categoria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    id_ventas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descuentos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    iva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    Usuarioid_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.id_ventas);
                    table.ForeignKey(
                        name: "FK_Ventas_Usuarios_Usuarioid_usuario",
                        column: x => x.Usuarioid_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle_Ventas",
                columns: table => new
                {
                    id_detalleVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_venta = table.Column<int>(type: "int", nullable: false),
                    Ventasid_ventas = table.Column<int>(type: "int", nullable: false),
                    id_libro = table.Column<int>(type: "int", nullable: false),
                    Libroid_libro = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle_Ventas", x => x.id_detalleVenta);
                    table.ForeignKey(
                        name: "FK_Detalle_Ventas_Libros_Libroid_libro",
                        column: x => x.Libroid_libro,
                        principalTable: "Libros",
                        principalColumn: "id_libro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalle_Ventas_Ventas_Ventasid_ventas",
                        column: x => x.Ventasid_ventas,
                        principalTable: "Ventas",
                        principalColumn: "id_ventas",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Ventas_Libroid_libro",
                table: "Detalle_Ventas",
                column: "Libroid_libro");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Ventas_Ventasid_ventas",
                table: "Detalle_Ventas",
                column: "Ventasid_ventas");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_Autorid_autor",
                table: "Libros",
                column: "Autorid_autor");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_categoriaid_categoria",
                table: "Libros",
                column: "categoriaid_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_Libros_Editorialid_editorial",
                table: "Libros",
                column: "Editorialid_editorial");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_Usuarioid_usuario",
                table: "Ventas",
                column: "Usuarioid_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle_Ventas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Libros");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Autores");

            migrationBuilder.DropTable(
                name: "Editoriales");

            migrationBuilder.DropTable(
                name: "categorias");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
