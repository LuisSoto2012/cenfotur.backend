using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class CreateTable_MaterialAcademico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialesAcademicos",
                columns: table => new
                {
                    MaterialAcademicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    FichaParticipante = table.Column<string>(type: "varchar(200)", nullable: true),
                    FichaEmpresa = table.Column<string>(type: "varchar(200)", nullable: true),
                    GesInstructivos = table.Column<string>(type: "varchar(200)", nullable: true),
                    GesFormatoInforme = table.Column<string>(type: "varchar(200)", nullable: true),
                    Sillabus = table.Column<string>(type: "varchar(200)", nullable: true),
                    Ppt = table.Column<string>(type: "varchar(200)", nullable: true),
                    Evaluaciones = table.Column<string>(type: "varchar(200)", nullable: true),
                    FacInstructivos = table.Column<string>(type: "varchar(200)", nullable: true),
                    FacFormatoInforme = table.Column<string>(type: "varchar(200)", nullable: true),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialesAcademicos", x => x.MaterialAcademicoId);
                    table.ForeignKey(
                        name: "FK_MaterialesAcademicos_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "CapacitacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesAcademicos_CapacitacionId",
                table: "MaterialesAcademicos",
                column: "CapacitacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialesAcademicos");
        }
    }
}
