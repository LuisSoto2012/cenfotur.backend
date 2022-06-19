using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_DistritoRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProvinciaId",
                table: "Distritos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Distritos_ProvinciaId",
                table: "Distritos",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Distritos_Provincias_ProvinciaId",
                table: "Distritos",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distritos_Provincias_ProvinciaId",
                table: "Distritos");

            migrationBuilder.DropIndex(
                name: "IX_Distritos_ProvinciaId",
                table: "Distritos");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Distritos");
        }
    }
}
