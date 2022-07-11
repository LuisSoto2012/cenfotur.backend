using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class CreateTable_Empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Clases",
                columns: table => new
                {
                    ClaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clases", x => x.ClaseId);
                });

            migrationBuilder.CreateTable(
                name: "Dicerturs",
                columns: table => new
                {
                    DicerturId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dicerturs", x => x.DicerturId);
                });

            migrationBuilder.CreateTable(
                name: "Referencias",
                columns: table => new
                {
                    ReferenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referencias", x => x.ReferenciaId);
                });

            migrationBuilder.CreateTable(
                name: "Rubros",
                columns: table => new
                {
                    RubroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros", x => x.RubroId);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCurso = table.Column<string>(type: "varchar(200)", nullable: true),
                    Ruc = table.Column<string>(type: "varchar(30)", nullable: true),
                    RazonSocial = table.Column<string>(type: "varchar(200)", nullable: true),
                    NombreComercial = table.Column<string>(type: "varchar(200)", nullable: true),
                    TipoContribuyente = table.Column<string>(type: "varchar(50)", nullable: true),
                    RubroId = table.Column<int>(type: "int", nullable: true),
                    DicerturId = table.Column<int>(type: "int", nullable: true),
                    ClaseId = table.Column<int>(type: "int", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    Horas = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(200)", nullable: true),
                    ReferenciaId = table.Column<int>(type: "int", nullable: true),
                    DepartamentoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProvinciaId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DistritoId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Codigo = table.Column<string>(type: "varchar(20)", nullable: true),
                    TelefonoFijo = table.Column<string>(type: "varchar(20)", nullable: true),
                    TelefonoMovil = table.Column<string>(type: "varchar(20)", nullable: true),
                    PaginaWeb = table.Column<string>(type: "varchar(50)", nullable: true),
                    WebInscrita = table.Column<string>(type: "varchar(200)", nullable: true),
                    AceptaCorreosOtros = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresaId);
                    table.ForeignKey(
                        name: "FK_Empresas_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId");
                    table.ForeignKey(
                        name: "FK_Empresas_Clases_ClaseId",
                        column: x => x.ClaseId,
                        principalTable: "Clases",
                        principalColumn: "ClaseId");
                    table.ForeignKey(
                        name: "FK_Empresas_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId");
                    table.ForeignKey(
                        name: "FK_Empresas_Dicerturs_DicerturId",
                        column: x => x.DicerturId,
                        principalTable: "Dicerturs",
                        principalColumn: "DicerturId");
                    table.ForeignKey(
                        name: "FK_Empresas_Distritos_DistritoId",
                        column: x => x.DistritoId,
                        principalTable: "Distritos",
                        principalColumn: "DistritoId");
                    table.ForeignKey(
                        name: "FK_Empresas_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "ProvinciaId");
                    table.ForeignKey(
                        name: "FK_Empresas_Referencias_ReferenciaId",
                        column: x => x.ReferenciaId,
                        principalTable: "Referencias",
                        principalColumn: "ReferenciaId");
                    table.ForeignKey(
                        name: "FK_Empresas_Rubros_RubroId",
                        column: x => x.RubroId,
                        principalTable: "Rubros",
                        principalColumn: "RubroId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CategoriaId",
                table: "Empresas",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ClaseId",
                table: "Empresas",
                column: "ClaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_DepartamentoId",
                table: "Empresas",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_DicerturId",
                table: "Empresas",
                column: "DicerturId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_DistritoId",
                table: "Empresas",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ProvinciaId",
                table: "Empresas",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ReferenciaId",
                table: "Empresas",
                column: "ReferenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_RubroId",
                table: "Empresas",
                column: "RubroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Clases");

            migrationBuilder.DropTable(
                name: "Dicerturs");

            migrationBuilder.DropTable(
                name: "Referencias");

            migrationBuilder.DropTable(
                name: "Rubros");
        }
    }
}
