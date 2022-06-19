using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class Empleados_AddPuestoLaboralRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
