using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_Asistencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Asistencia",
                table: "Asistencia");

            migrationBuilder.AddColumn<int>(
                name: "AsistenciaId",
                table: "Asistencia",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asistencia",
                table: "Asistencia",
                column: "AsistenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_ParticipanteId",
                table: "Asistencia",
                column: "ParticipanteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Asistencia",
                table: "Asistencia");

            migrationBuilder.DropIndex(
                name: "IX_Asistencia_ParticipanteId",
                table: "Asistencia");

            migrationBuilder.DropColumn(
                name: "AsistenciaId",
                table: "Asistencia");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Asistencia",
                table: "Asistencia",
                columns: new[] { "ParticipanteId", "CapacitacionId" });
        }
    }
}
