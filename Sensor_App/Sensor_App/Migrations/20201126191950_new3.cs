using Microsoft.EntityFrameworkCore.Migrations;

namespace Sensor_App.Migrations
{
    public partial class new3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguro_Clientes_ClienteId",
                table: "Seguro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguro",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "SeguroId",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "EstadoTransito",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "EstadoTransitoCargaSuelta",
                table: "Seguro");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Seguro",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Seguro",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Uruguay_Transitos",
                table: "Seguro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Uruguay_Transitos_Carga_Suelta",
                table: "Seguro",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguro",
                table: "Seguro",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguro_Clientes_ClienteId",
                table: "Seguro",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguro_Clientes_ClienteId",
                table: "Seguro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguro",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "Uruguay_Transitos",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "Uruguay_Transitos_Carga_Suelta",
                table: "Seguro");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Seguro",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SeguroId",
                table: "Seguro",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "EstadoTransito",
                table: "Seguro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EstadoTransitoCargaSuelta",
                table: "Seguro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguro",
                table: "Seguro",
                column: "SeguroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguro_Clientes_ClienteId",
                table: "Seguro",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
