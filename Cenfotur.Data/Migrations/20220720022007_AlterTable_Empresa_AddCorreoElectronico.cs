using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_Empresa_AddCorreoElectronico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Referencias_ReferenciaId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_ReferenciaId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "ReferenciaId",
                table: "Empresas");

            migrationBuilder.AddColumn<string>(
                name: "CorreoElectronico",
                table: "Empresas",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Referencia",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoMovil",
                table: "Empresas",
                type: "varchar(20)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorreoElectronico",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Referencia",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "TelefonoMovil",
                table: "Empresas");

            migrationBuilder.AddColumn<int>(
                name: "ReferenciaId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_ReferenciaId",
                table: "Empresas",
                column: "ReferenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Referencias_ReferenciaId",
                table: "Empresas",
                column: "ReferenciaId",
                principalTable: "Referencias",
                principalColumn: "ReferenciaId");
        }
    }
}
