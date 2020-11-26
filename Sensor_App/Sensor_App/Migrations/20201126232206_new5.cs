using Microsoft.EntityFrameworkCore.Migrations;

namespace Sensor_App.Migrations
{
    public partial class new5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguro_Clientes_ClienteId",
                table: "Seguro");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguro",
                table: "Seguro");

            migrationBuilder.RenameTable(
                name: "Seguro",
                newName: "Seguros");

            migrationBuilder.RenameIndex(
                name: "IX_Seguro_ClienteId",
                table: "Seguros",
                newName: "IX_Seguros_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seguros",
                table: "Seguros",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguros_Clientes_ClienteId",
                table: "Seguros",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguros_Clientes_ClienteId",
                table: "Seguros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seguros",
                table: "Seguros");

            migrationBuilder.RenameTable(
                name: "Seguros",
                newName: "Seguro");

            migrationBuilder.RenameIndex(
                name: "IX_Seguros_ClienteId",
                table: "Seguro",
                newName: "IX_Seguro_ClienteId");

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
    }
}
