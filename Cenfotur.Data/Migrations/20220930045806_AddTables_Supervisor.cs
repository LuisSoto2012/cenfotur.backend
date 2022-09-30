using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AddTables_Supervisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Programas",
                columns: table => new
                {
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.ProgramaId);
                });

            migrationBuilder.CreateTable(
                name: "TiposSupervision",
                columns: table => new
                {
                    TipoSupervisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSupervision", x => x.TipoSupervisionId);
                });

            migrationBuilder.CreateTable(
                name: "FichasSupervision",
                columns: table => new
                {
                    FichaSupervisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacitacionId = table.Column<int>(type: "int", nullable: true),
                    FechaSupervision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProgramaId = table.Column<int>(type: "int", nullable: true),
                    DepartamentoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    FacilitadorId = table.Column<int>(type: "int", nullable: true),
                    TipoSupervisionId = table.Column<int>(type: "int", nullable: true),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichasSupervision", x => x.FichaSupervisionId);
                    table.ForeignKey(
                        name: "FK_FichasSupervision_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "CapacitacionId");
                    table.ForeignKey(
                        name: "FK_FichasSupervision_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId");
                    table.ForeignKey(
                        name: "FK_FichasSupervision_Empleados_FacilitadorId",
                        column: x => x.FacilitadorId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId");
                    table.ForeignKey(
                        name: "FK_FichasSupervision_Empleados_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId");
                    table.ForeignKey(
                        name: "FK_FichasSupervision_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "ProgramaId");
                    table.ForeignKey(
                        name: "FK_FichasSupervision_TiposSupervision_TipoSupervisionId",
                        column: x => x.TipoSupervisionId,
                        principalTable: "TiposSupervision",
                        principalColumn: "TipoSupervisionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FichasSupervision_CapacitacionId",
                table: "FichasSupervision",
                column: "CapacitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasSupervision_DepartamentoId",
                table: "FichasSupervision",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasSupervision_FacilitadorId",
                table: "FichasSupervision",
                column: "FacilitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasSupervision_ProgramaId",
                table: "FichasSupervision",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasSupervision_SupervisorId",
                table: "FichasSupervision",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_FichasSupervision_TipoSupervisionId",
                table: "FichasSupervision",
                column: "TipoSupervisionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FichasSupervision");

            migrationBuilder.DropTable(
                name: "Programas");

            migrationBuilder.DropTable(
                name: "TiposSupervision");
        }
    }
}
