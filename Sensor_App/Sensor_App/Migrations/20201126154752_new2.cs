using Microsoft.EntityFrameworkCore.Migrations;

namespace Sensor_App.Migrations
{
    public partial class new2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clientes_ClienteId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Users",
                newName: "ClienteID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ClienteId",
                table: "Users",
                newName: "IX_Users_ClienteID");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteID",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clientes_ClienteID",
                table: "Users",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Clientes_ClienteID",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "ClienteID",
                table: "Users",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_ClienteID",
                table: "Users",
                newName: "IX_Users_ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Clientes_ClienteId",
                table: "Users",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
