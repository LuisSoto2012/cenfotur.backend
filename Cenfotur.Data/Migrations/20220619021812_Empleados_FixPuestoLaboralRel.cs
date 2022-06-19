using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class Empleados_FixPuestoLaboralRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PuestosLaborales_Empleados_EmpleadoId",
                table: "PuestosLaborales");

            migrationBuilder.DropIndex(
                name: "IX_PuestosLaborales_EmpleadoId",
                table: "PuestosLaborales");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "PuestosLaborales");

            migrationBuilder.AddColumn<int>(
                name: "PuestoLaboralId",
                table: "Empleados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PuestoLaboralId",
                table: "Empleados",
                column: "PuestoLaboralId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_PuestosLaborales_PuestoLaboralId",
                table: "Empleados",
                column: "PuestoLaboralId",
                principalTable: "PuestosLaborales",
                principalColumn: "PuestoLaboralId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_PuestosLaborales_PuestoLaboralId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_PuestoLaboralId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "PuestoLaboralId",
                table: "Empleados");

            migrationBuilder.AddColumn<int>(
                name: "EmpleadoId",
                table: "PuestosLaborales",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PuestosLaborales_EmpleadoId",
                table: "PuestosLaborales",
                column: "EmpleadoId",
                unique: true,
                filter: "[EmpleadoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PuestosLaborales_Empleados_EmpleadoId",
                table: "PuestosLaborales",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId");
        }
    }
}
