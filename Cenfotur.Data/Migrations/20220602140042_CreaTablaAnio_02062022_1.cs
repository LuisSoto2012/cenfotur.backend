using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class CreaTablaAnio_02062022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anios",
                columns: table => new
                {
                    AnioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false),
                    NombreOficial = table.Column<string>(type: "varchar(170)", maxLength: 170, nullable: false),
                    UIT = table.Column<int>(type: "int", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anios", x => x.AnioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anios");
        }
    }
}
