using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AddTable_Encuesta_Asistencia_Notas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asistencia",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    FechaAsistencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Asistio = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistencia", x => new { x.ParticipanteId, x.CapacitacionId });
                    table.ForeignKey(
                        name: "FK_Asistencia_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "CapacitacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asistencia_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaSatisfaccion",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    FacilitadorId = table.Column<int>(type: "int", nullable: true),
                    DistritoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Eva1 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva2 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva3 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva4 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva5 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva6 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva7 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva8 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva9 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva10 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva11 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva12 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Eva13 = table.Column<string>(type: "varchar(1)", nullable: false),
                    Mejora1 = table.Column<string>(type: "varchar(200)", nullable: false),
                    Mejora2 = table.Column<string>(type: "varchar(200)", nullable: false),
                    Mejora3 = table.Column<string>(type: "varchar(200)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaSatisfaccion", x => new { x.ParticipanteId, x.CapacitacionId });
                    table.ForeignKey(
                        name: "FK_EncuestaSatisfaccion_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "CapacitacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaSatisfaccion_Distritos_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distritos",
                        principalColumn: "DistritoId");
                    table.ForeignKey(
                        name: "FK_EncuestaSatisfaccion_Empleados_FacilitadorId",
                        column: x => x.FacilitadorId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId");
                    table.ForeignKey(
                        name: "FK_EncuestaSatisfaccion_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "int", nullable: false),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    EE = table.Column<string>(type: "varchar(20)", nullable: true),
                    EP = table.Column<string>(type: "varchar(20)", nullable: true),
                    ED = table.Column<string>(type: "varchar(20)", nullable: true),
                    EF = table.Column<string>(type: "varchar(20)", nullable: true),
                    NF = table.Column<string>(type: "varchar(20)", nullable: true),
                    Letras = table.Column<string>(type: "varchar(20)", nullable: true),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => new { x.ParticipanteId, x.CapacitacionId });
                    table.ForeignKey(
                        name: "FK_Notas_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "CapacitacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Participantes_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participantes",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asistencia_CapacitacionId",
                table: "Asistencia",
                column: "CapacitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaSatisfaccion_CapacitacionId",
                table: "EncuestaSatisfaccion",
                column: "CapacitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaSatisfaccion_DistritoId",
                table: "EncuestaSatisfaccion",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaSatisfaccion_FacilitadorId",
                table: "EncuestaSatisfaccion",
                column: "FacilitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_CapacitacionId",
                table: "Notas",
                column: "CapacitacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asistencia");

            migrationBuilder.DropTable(
                name: "EncuestaSatisfaccion");

            migrationBuilder.DropTable(
                name: "Notas");
        }
    }
}
