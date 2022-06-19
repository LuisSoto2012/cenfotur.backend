using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_Capacitaciones_FixName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capacitacions_Empleados_FacilitadorId",
                table: "Capacitacions");

            migrationBuilder.DropForeignKey(
                name: "FK_Capacitacions_Empleados_GestorId",
                table: "Capacitacions");

            migrationBuilder.DropForeignKey(
                name: "FK_Capacitacions_TipoCapacitacion_TipoCapacitacionId",
                table: "Capacitacions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Capacitacions",
                table: "Capacitacions");

            migrationBuilder.RenameTable(
                name: "Capacitacions",
                newName: "Capacitaciones");

            migrationBuilder.RenameIndex(
                name: "IX_Capacitacions_TipoCapacitacionId",
                table: "Capacitaciones",
                newName: "IX_Capacitaciones_TipoCapacitacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Capacitacions_GestorId",
                table: "Capacitaciones",
                newName: "IX_Capacitaciones_GestorId");

            migrationBuilder.RenameIndex(
                name: "IX_Capacitacions_FacilitadorId",
                table: "Capacitaciones",
                newName: "IX_Capacitaciones_FacilitadorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Capacitaciones",
                table: "Capacitaciones",
                column: "CapacitacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitaciones_Empleados_FacilitadorId",
                table: "Capacitaciones",
                column: "FacilitadorId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitaciones_Empleados_GestorId",
                table: "Capacitaciones",
                column: "GestorId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitaciones_TipoCapacitacion_TipoCapacitacionId",
                table: "Capacitaciones",
                column: "TipoCapacitacionId",
                principalTable: "TipoCapacitacion",
                principalColumn: "TipoCapacitacionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capacitaciones_Empleados_FacilitadorId",
                table: "Capacitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Capacitaciones_Empleados_GestorId",
                table: "Capacitaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Capacitaciones_TipoCapacitacion_TipoCapacitacionId",
                table: "Capacitaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Capacitaciones",
                table: "Capacitaciones");

            migrationBuilder.RenameTable(
                name: "Capacitaciones",
                newName: "Capacitacions");

            migrationBuilder.RenameIndex(
                name: "IX_Capacitaciones_TipoCapacitacionId",
                table: "Capacitacions",
                newName: "IX_Capacitacions_TipoCapacitacionId");

            migrationBuilder.RenameIndex(
                name: "IX_Capacitaciones_GestorId",
                table: "Capacitacions",
                newName: "IX_Capacitacions_GestorId");

            migrationBuilder.RenameIndex(
                name: "IX_Capacitaciones_FacilitadorId",
                table: "Capacitacions",
                newName: "IX_Capacitacions_FacilitadorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Capacitacions",
                table: "Capacitacions",
                column: "CapacitacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitacions_Empleados_FacilitadorId",
                table: "Capacitacions",
                column: "FacilitadorId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitacions_Empleados_GestorId",
                table: "Capacitacions",
                column: "GestorId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitacions_TipoCapacitacion_TipoCapacitacionId",
                table: "Capacitacions",
                column: "TipoCapacitacionId",
                principalTable: "TipoCapacitacion",
                principalColumn: "TipoCapacitacionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
