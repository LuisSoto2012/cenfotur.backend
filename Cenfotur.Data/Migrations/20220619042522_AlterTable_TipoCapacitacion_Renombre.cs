using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_TipoCapacitacion_Renombre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capacitaciones_TipoCapacitacion_TipoCapacitacionId",
                table: "Capacitaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoCapacitacion",
                table: "TipoCapacitacion");

            migrationBuilder.RenameTable(
                name: "TipoCapacitacion",
                newName: "TipoCapacitaciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoCapacitaciones",
                table: "TipoCapacitaciones",
                column: "TipoCapacitacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitaciones_TipoCapacitaciones_TipoCapacitacionId",
                table: "Capacitaciones",
                column: "TipoCapacitacionId",
                principalTable: "TipoCapacitaciones",
                principalColumn: "TipoCapacitacionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capacitaciones_TipoCapacitaciones_TipoCapacitacionId",
                table: "Capacitaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoCapacitaciones",
                table: "TipoCapacitaciones");

            migrationBuilder.RenameTable(
                name: "TipoCapacitaciones",
                newName: "TipoCapacitacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoCapacitacion",
                table: "TipoCapacitacion",
                column: "TipoCapacitacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitaciones_TipoCapacitacion_TipoCapacitacionId",
                table: "Capacitaciones",
                column: "TipoCapacitacionId",
                principalTable: "TipoCapacitacion",
                principalColumn: "TipoCapacitacionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
