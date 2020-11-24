using Microsoft.EntityFrameworkCore.Migrations;

namespace Sensor_App.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seguro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoTransito = table.Column<int>(nullable: false),
                    EstadoTransitoCargaSuelta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
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
                    SeguroId = table.Column<int>(nullable: false),
                    Activo = table.Column<bool>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Seguro_SeguroId",
                        column: x => x.SeguroId,
                        principalTable: "Seguro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ClienteID = table.Column<int>(nullable: true),
                    Permisos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_SeguroId",
                table: "Clientes",
                column: "SeguroId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ClienteID",
                table: "Users",
                column: "ClienteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Seguro");
        }
    }
}
