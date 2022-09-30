using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTables_AsistenciaNotas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacilitadorId",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "Notas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacilitadorId",
                table: "Asistencia",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "Asistencia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_FacilitadorId",
                table: "Notas",
                column: "FacilitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_SupervisorId",
                table: "Notas",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_FacilitadorId",
                table: "Asistencia",
                column: "FacilitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_SupervisorId",
                table: "Asistencia",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencia_Empleados_FacilitadorId",
                table: "Asistencia",
                column: "FacilitadorId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencia_Empleados_SupervisorId",
                table: "Asistencia",
                column: "SupervisorId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Empleados_FacilitadorId",
                table: "Notas",
                column: "FacilitadorId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notas_Empleados_SupervisorId",
                table: "Notas",
                column: "SupervisorId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencia_Empleados_FacilitadorId",
                table: "Asistencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Asistencia_Empleados_SupervisorId",
                table: "Asistencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Empleados_FacilitadorId",
                table: "Notas");

            migrationBuilder.DropForeignKey(
                name: "FK_Notas_Empleados_SupervisorId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_FacilitadorId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Notas_SupervisorId",
                table: "Notas");

            migrationBuilder.DropIndex(
                name: "IX_Asistencia_FacilitadorId",
                table: "Asistencia");

            migrationBuilder.DropIndex(
                name: "IX_Asistencia_SupervisorId",
                table: "Asistencia");

            migrationBuilder.DropColumn(
                name: "FacilitadorId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "FacilitadorId",
                table: "Asistencia");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Asistencia");
        }
    }
}
