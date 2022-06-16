using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class TablasContracionyReferentes_06062022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetasPresupuestales",
                columns: table => new
                {
                    MetaPresupuestalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(85)", maxLength: 85, nullable: false),
                    AnioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetasPresupuestales", x => x.MetaPresupuestalId);
                });

            migrationBuilder.CreateTable(
                name: "PuestosLaborales",
                columns: table => new
                {
                    PuestoLaboralId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuestosLaborales", x => x.PuestoLaboralId);
                });

            migrationBuilder.CreateTable(
                name: "Contratacion",
                columns: table => new
                {
                    ContratacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    FechaContratacion = table.Column<DateTime>(type: "Date", nullable: false),
                    PuestoLaboralId = table.Column<int>(type: "int", nullable: false),
                    MetaPresupuestalId = table.Column<int>(type: "int", nullable: false),
                    Remuneracion = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratacion", x => x.ContratacionId);
                    table.ForeignKey(
                        name: "FK_Contratacion_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratacion_MetasPresupuestales_MetaPresupuestalId",
                        column: x => x.MetaPresupuestalId,
                        principalTable: "MetasPresupuestales",
                        principalColumn: "MetaPresupuestalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratacion_PuestosLaborales_PuestoLaboralId",
                        column: x => x.PuestoLaboralId,
                        principalTable: "PuestosLaborales",
                        principalColumn: "PuestoLaboralId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_TipoDocumentoId",
                table: "Empleados",
                column: "TipoDocumentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratacion_EmpleadoId",
                table: "Contratacion",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratacion_MetaPresupuestalId",
                table: "Contratacion",
                column: "MetaPresupuestalId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratacion_PuestoLaboralId",
                table: "Contratacion",
                column: "PuestoLaboralId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_TipoDocumentos_TipoDocumentoId",
                table: "Empleados",
                column: "TipoDocumentoId",
                principalTable: "TipoDocumentos",
                principalColumn: "TipoDocumentoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_TipoDocumentos_TipoDocumentoId",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Contratacion");

            migrationBuilder.DropTable(
                name: "MetasPresupuestales");

            migrationBuilder.DropTable(
                name: "PuestosLaborales");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_TipoDocumentoId",
                table: "Empleados");
        }
    }
}
