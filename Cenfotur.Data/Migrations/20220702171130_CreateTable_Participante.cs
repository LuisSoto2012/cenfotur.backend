using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class CreateTable_Participante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApellidoPaterno = table.Column<string>(type: "varchar(200)", nullable: true),
                    ApellidoMaterno = table.Column<string>(type: "varchar(200)", nullable: true),
                    Nombres = table.Column<string>(type: "varchar(200)", nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: true),
                    NumeroDocumento = table.Column<string>(type: "varchar(25)", nullable: true),
                    Nacionalidad = table.Column<string>(type: "varchar(50)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TelefonoMovil = table.Column<string>(type: "varchar(20)", nullable: true),
                    CorreoElectronico = table.Column<string>(type: "varchar(50)", nullable: true),
                    Ruc = table.Column<string>(type: "varchar(50)", nullable: true),
                    RazonSocial = table.Column<string>(type: "varchar(200)", nullable: true),
                    NombreComercial = table.Column<string>(type: "varchar(200)", nullable: true),
                    DepartamentoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TelefonoEmpresa = table.Column<string>(type: "varchar(50)", nullable: true),
                    PerfilRelacionadoId = table.Column<int>(type: "int", nullable: true),
                    Usuario = table.Column<string>(type: "varchar(100)", nullable: true),
                    Contrasena = table.Column<string>(type: "varchar(100)", nullable: true),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.ParticipanteId);
                    table.ForeignKey(
                        name: "FK_Participantes_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId");
                    table.ForeignKey(
                        name: "FK_Participantes_PerfilesRelacionados_PerfilRelacionadoId",
                        column: x => x.PerfilRelacionadoId,
                        principalTable: "PerfilesRelacionados",
                        principalColumn: "PerfilRelacionadoId");
                    table.ForeignKey(
                        name: "FK_Participantes_TipoDocumentos_TipoDocumentoId",
                        column: x => x.TipoDocumentoId,
                        principalTable: "TipoDocumentos",
                        principalColumn: "TipoDocumentoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_DepartamentoId",
                table: "Participantes",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_PerfilRelacionadoId",
                table: "Participantes",
                column: "PerfilRelacionadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_TipoDocumentoId",
                table: "Participantes",
                column: "TipoDocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
