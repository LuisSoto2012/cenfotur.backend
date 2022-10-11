using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AddTable_DirectorioEncuesta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectoriosEncuestas",
                columns: table => new
                {
                    DirectorioEncuestaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreDirector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Institucion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelefonoMovil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DistritoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    P1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P9 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    P10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectoriosEncuestas", x => x.DirectorioEncuestaId);
                    table.ForeignKey(
                        name: "FK_DirectoriosEncuestas_Distritos_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distritos",
                        principalColumn: "DistritoId");
                });

            migrationBuilder.CreateTable(
                name: "ProgramacionesInfoPFC",
                columns: table => new
                {
                    ProgramacionInfoPFCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacitacionId = table.Column<int>(type: "int", nullable: true),
                    OsFacilitador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiasViatico = table.Column<int>(type: "int", nullable: true),
                    Viaticos = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Pasajes = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalCostoFacilitador = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GestorLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OsGestor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CostoGestorLocal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Sala = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdZoom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnlaceAcceso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supervisa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaSupervision = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NroAprobados = table.Column<int>(type: "int", nullable: true),
                    NroDesaprobados = table.Column<int>(type: "int", nullable: true),
                    NroIpis = table.Column<int>(type: "int", nullable: true),
                    NroBeneficiarios = table.Column<int>(type: "int", nullable: true),
                    PorcAprobados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorcDesaprobados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PorcIpis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEmisionDiplomas = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaRecepcionDiplomas = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ContactoEnvioDiplomas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEnvioDiplomas = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NroInscritos = table.Column<int>(type: "int", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DireccionPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramacionesInfoPFC", x => x.ProgramacionInfoPFCId);
                    table.ForeignKey(
                        name: "FK_ProgramacionesInfoPFC_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "CapacitacionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectoriosEncuestas_DistritoId",
                table: "DirectoriosEncuestas",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramacionesInfoPFC_CapacitacionId",
                table: "ProgramacionesInfoPFC",
                column: "CapacitacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectoriosEncuestas");

            migrationBuilder.DropTable(
                name: "ProgramacionesInfoPFC");
        }
    }
}
