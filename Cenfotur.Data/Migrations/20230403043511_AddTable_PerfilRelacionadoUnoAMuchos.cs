using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AddTable_PerfilRelacionadoUnoAMuchos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CursoPerfilRelacionado",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    PerfilRelacionadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoPerfilRelacionado", x => new { x.CursoId, x.PerfilRelacionadoId });
                    table.ForeignKey(
                        name: "FK_CursoPerfilRelacionado_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "CursoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoPerfilRelacionado_PerfilesRelacionados_PerfilRelacionadoId",
                        column: x => x.PerfilRelacionadoId,
                        principalTable: "PerfilesRelacionados",
                        principalColumn: "PerfilRelacionadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataSp2ODtos",
                columns: table => new
                {
                    Mejora1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mejora2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mejora3 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DataSpODtos",
                columns: table => new
                {
                    Preguntas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    _1 = table.Column<string>(name: "1", type: "nvarchar(max)", nullable: true),
                    _2 = table.Column<string>(name: "2", type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ParticipantePerfilRelacionado",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    PerfilRelacionadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantePerfilRelacionado", x => new { x.ParticipanteId, x.PerfilRelacionadoId });
                    table.ForeignKey(
                        name: "FK_ParticipantePerfilRelacionado_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantePerfilRelacionado_PerfilesRelacionados_PerfilRelacionadoId",
                        column: x => x.PerfilRelacionadoId,
                        principalTable: "PerfilesRelacionados",
                        principalColumn: "PerfilRelacionadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CursoPerfilRelacionado_PerfilRelacionadoId",
                table: "CursoPerfilRelacionado",
                column: "PerfilRelacionadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantePerfilRelacionado_PerfilRelacionadoId",
                table: "ParticipantePerfilRelacionado",
                column: "PerfilRelacionadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CursoPerfilRelacionado");

            migrationBuilder.DropTable(
                name: "DataSp2ODtos");

            migrationBuilder.DropTable(
                name: "DataSpODtos");

            migrationBuilder.DropTable(
                name: "ParticipantePerfilRelacionado");
        }
    }
}
