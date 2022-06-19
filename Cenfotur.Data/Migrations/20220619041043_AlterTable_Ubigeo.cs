using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_Ubigeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distritos_Provincias_ProvinciaId1",
                table: "Distritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_Departamentos_DepartamentoId1",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "IX_Provincias_DepartamentoId1",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "IX_Distritos_ProvinciaId1",
                table: "Distritos");

            migrationBuilder.DropColumn(
                name: "DepartamentoId1",
                table: "Provincias");

            migrationBuilder.DropColumn(
                name: "ProvinciaId1",
                table: "Distritos");

            migrationBuilder.AlterColumn<string>(
                name: "DepartamentoId",
                table: "Provincias",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ProvinciaId",
                table: "Distritos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_DepartamentoId",
                table: "Provincias",
                column: "DepartamentoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_Departamentos_DepartamentoId",
                table: "Provincias",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Distritos_Provincias_ProvinciaId",
                table: "Distritos");

            migrationBuilder.DropForeignKey(
                name: "FK_Provincias_Departamentos_DepartamentoId",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "IX_Provincias_DepartamentoId",
                table: "Provincias");

            migrationBuilder.DropIndex(
                name: "IX_Distritos_ProvinciaId",
                table: "Distritos");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Provincias",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartamentoId1",
                table: "Provincias",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProvinciaId",
                table: "Distritos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinciaId1",
                table: "Distritos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Provincias_DepartamentoId1",
                table: "Provincias",
                column: "DepartamentoId1");

            migrationBuilder.CreateIndex(
                name: "IX_Distritos_ProvinciaId1",
                table: "Distritos",
                column: "ProvinciaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Distritos_Provincias_ProvinciaId1",
                table: "Distritos",
                column: "ProvinciaId1",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Provincias_Departamentos_DepartamentoId1",
                table: "Provincias",
                column: "DepartamentoId1",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId");
        }
    }
}
