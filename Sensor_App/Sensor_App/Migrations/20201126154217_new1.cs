using Microsoft.EntityFrameworkCore.Migrations;

namespace Sensor_App.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermisoTipos_Users_UserId",
                table: "PermisoTipos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "PermisoTipos");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PermisoTipos",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PermisoTipos_Users_UserId",
                table: "PermisoTipos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermisoTipos_Users_UserId",
                table: "PermisoTipos");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PermisoTipos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "PermisoTipos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PermisoTipos_Users_UserId",
                table: "PermisoTipos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
