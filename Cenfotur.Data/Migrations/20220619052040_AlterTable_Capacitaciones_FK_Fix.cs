using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_Capacitaciones_FK_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capacitaciones_Distritos_UbigeoDistritoId",
                table: "Capacitaciones");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "Capacitaciones");

            migrationBuilder.RenameColumn(
                name: "UbigeoDistritoId",
                table: "Capacitaciones",
                newName: "UbigueoId");

            migrationBuilder.RenameIndex(
                name: "IX_Capacitaciones_UbigeoDistritoId",
                table: "Capacitaciones",
                newName: "IX_Capacitaciones_UbigueoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitaciones_Distritos_UbigueoId",
                table: "Capacitaciones",
                column: "UbigueoId",
                principalTable: "Distritos",
                principalColumn: "DistritoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capacitaciones_Distritos_UbigueoId",
                table: "Capacitaciones");

            migrationBuilder.RenameColumn(
                name: "UbigueoId",
                table: "Capacitaciones",
                newName: "UbigeoDistritoId");

            migrationBuilder.RenameIndex(
                name: "IX_Capacitaciones_UbigueoId",
                table: "Capacitaciones",
                newName: "IX_Capacitaciones_UbigeoDistritoId");

            migrationBuilder.AddColumn<int>(
                name: "DistritoId",
                table: "Capacitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitaciones_Distritos_UbigeoDistritoId",
                table: "Capacitaciones",
                column: "UbigeoDistritoId",
                principalTable: "Distritos",
                principalColumn: "DistritoId");
        }
    }
}
