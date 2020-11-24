using Microsoft.EntityFrameworkCore.Migrations;

namespace Sensor_App.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazonSocial = table.Column<string>(maxLength: 30, nullable: false),
                    NroSucursal = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(maxLength: 30, nullable: false),
                    Pais = table.Column<string>(maxLength: 30, nullable: false),
                    Ciudad = table.Column<string>(maxLength: 30, nullable: false),
                    CodPostal = table.Column<int>(nullable: false),
                    Zona = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 30, nullable: false),
                    Fax = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Web = table.Column<string>(maxLength: 30, nullable: false),
                    Activo = table.Column<bool>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Seguro",
                columns: table => new
                {
                    SeguroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoTransito = table.Column<int>(nullable: false),
                    EstadoTransitoCargaSuelta = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguro", x => x.SeguroId);
                    table.ForeignKey(
                        name: "FK_Seguro_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 50, nullable: false),
                    NombreUsuario = table.Column<string>(maxLength: 20, nullable: false),
                    Contrasenia = table.Column<string>(maxLength: 100, nullable: false),
                    ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermisoTipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permiso = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisoTipo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermisoTipo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermisoTipo_UserId",
                table: "PermisoTipo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguro_ClienteId",
                table: "Seguro",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClienteId",
                table: "Users",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermisoTipo");

            migrationBuilder.DropTable(
                name: "Seguro");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
