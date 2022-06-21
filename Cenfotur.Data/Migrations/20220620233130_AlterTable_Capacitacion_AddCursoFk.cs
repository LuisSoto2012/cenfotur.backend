using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_Capacitacion_AddCursoFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Capacitaciones");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Capacitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_CursoId",
                table: "Capacitaciones",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitaciones_Cursos_CursoId",
                table: "Capacitaciones",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capacitaciones_Cursos_CursoId",
                table: "Capacitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Capacitaciones_CursoId",
                table: "Capacitaciones");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Capacitaciones");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Capacitaciones",
                type: "varchar(200)",
                nullable: true);
        }
    }
}
