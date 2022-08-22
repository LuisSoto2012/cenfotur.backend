using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_FacilitadorArchivos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacilitadorArchivos",
                columns: table => new
                {
                    FacilitadorArchivoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilitadorId = table.Column<int>(type: "int", nullable: false),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    Archivo = table.Column<string>(type: "varchar(200)", nullable: true),
                    TipoArchivo = table.Column<string>(type: "varchar(20)", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilitadorArchivos", x => x.FacilitadorArchivoId);
                    table.ForeignKey(
                        name: "FK_FacilitadorArchivos_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "CapacitacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilitadorArchivos_Empleados_FacilitadorId",
                        column: x => x.FacilitadorId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacilitadorArchivos_CapacitacionId",
                table: "FacilitadorArchivos",
                column: "CapacitacionId");

            migrationBuilder.CreateIndex(
                name: "IX_FacilitadorArchivos_FacilitadorId",
                table: "FacilitadorArchivos",
                column: "FacilitadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacilitadorArchivos");
        }
    }
}
