using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AgregaTipoDocumento_04062022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TipoDocumentos",
                columns: table => new
                {
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    NombreAbrev = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDocumentos", x => x.TipoDocumentoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoDocumentos");
        }
    }
}
