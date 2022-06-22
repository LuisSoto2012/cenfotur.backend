using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class CreateTable_Documentaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documentaciones",
                columns: table => new
                {
                    DocumentacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CapacitacionId = table.Column<int>(type: "int", nullable: false),
                    TdrFacilitador = table.Column<string>(type: "varchar(200)", nullable: true),
                    OsFacilitador = table.Column<string>(type: "varchar(200)", nullable: true),
                    TdrGestor = table.Column<string>(type: "varchar(200)", nullable: true),
                    OsGestor = table.Column<string>(type: "varchar(200)", nullable: true),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentaciones", x => x.DocumentacionId);
                    table.ForeignKey(
                        name: "FK_Documentaciones_Capacitaciones_CapacitacionId",
                        column: x => x.CapacitacionId,
                        principalTable: "Capacitaciones",
                        principalColumn: "CapacitacionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documentaciones_CapacitacionId",
                table: "Documentaciones",
                column: "CapacitacionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentaciones");
        }
    }
}
