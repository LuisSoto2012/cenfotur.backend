using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_Distrito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distritos_Provincias_ProvinciaId",
                table: "Distritos");

            migrationBuilder.RenameColumn(
                name: "ProvinciaId",
                table: "Distritos",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Distritos_ProvinciaId",
                table: "Distritos",
                newName: "IX_Distritos_DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Distritos_Departamentos_DepartamentoId",
                table: "Distritos",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distritos_Departamentos_DepartamentoId",
                table: "Distritos");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Distritos",
                newName: "ProvinciaId");

            migrationBuilder.RenameIndex(
                name: "IX_Distritos_DepartamentoId",
                table: "Distritos",
                newName: "IX_Distritos_ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Distritos_Provincias_ProvinciaId",
                table: "Distritos",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId");
        }
    }
}
