using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AddTable_Capacitaciones_Ubigeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoCapacitacion",
                columns: table => new
                {
                    TipoCapacitacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCapacitacion", x => x.TipoCapacitacionId);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    ProvinciaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    DepartamentoId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.ProvinciaId);
                    table.ForeignKey(
                        name: "FK_Provincias_Departamentos_DepartamentoId1",
                        column: x => x.DepartamentoId1,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId");
                });

            migrationBuilder.CreateTable(
                name: "Capacitacions",
                columns: table => new
                {
                    CapacitacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "Date", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "Date", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: true),
                    PublicoObjetivo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Dias = table.Column<int>(type: "int", nullable: false),
                    Horas = table.Column<int>(type: "int", nullable: false),
                    Ubigeo = table.Column<string>(type: "varchar(20)", nullable: true),
                    TipoCapacitacionId = table.Column<int>(type: "int", nullable: false),
                    FacilitadorId = table.Column<int>(type: "int", nullable: true),
                    GestorId = table.Column<int>(type: "int", nullable: true),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capacitacions", x => x.CapacitacionId);
                    table.ForeignKey(
                        name: "FK_Capacitacions_Empleados_FacilitadorId",
                        column: x => x.FacilitadorId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId");
                    table.ForeignKey(
                        name: "FK_Capacitacions_Empleados_GestorId",
                        column: x => x.GestorId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId");
                    table.ForeignKey(
                        name: "FK_Capacitacions_TipoCapacitacion_TipoCapacitacionId",
                        column: x => x.TipoCapacitacionId,
                        principalTable: "TipoCapacitacion",
                        principalColumn: "TipoCapacitacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Distritos",
                columns: table => new
                {
                    DistritoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false),
                    ProvinciaId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distritos", x => x.DistritoId);
                    table.ForeignKey(
                        name: "FK_Distritos_Provincias_ProvinciaId1",
                        column: x => x.ProvinciaId1,
                        principalTable: "Provincias",
                        principalColumn: "ProvinciaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capacitacions_FacilitadorId",
                table: "Capacitacions",
                column: "FacilitadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Capacitacions_GestorId",
                table: "Capacitacions",
                column: "GestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Capacitacions_TipoCapacitacionId",
                table: "Capacitacions",
                column: "TipoCapacitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Distritos_ProvinciaId1",
                table: "Distritos",
                column: "ProvinciaId1");

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_DepartamentoId1",
                table: "Provincias",
                column: "DepartamentoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capacitacions");

            migrationBuilder.DropTable(
                name: "Distritos");

            migrationBuilder.DropTable(
                name: "TipoCapacitacion");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
