using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class Cursos_AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", nullable: true),
                    Horas = table.Column<int>(type: "int", nullable: false),
                    Codigo = table.Column<string>(type: "varchar(20)", nullable: true),
                    HorasAprobar = table.Column<int>(type: "int", nullable: false),
                    Resolucion = table.Column<string>(type: "varchar(100)", nullable: true),
                    ExamenEntrada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublicoObjetivo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Practica = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dias = table.Column<int>(type: "int", nullable: false),
                    Desempenio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Final = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PracticaNoAplica = table.Column<bool>(type: "bit", nullable: false),
                    DesempenioNoAplica = table.Column<bool>(type: "bit", nullable: false),
                    FinalNoAplica = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
