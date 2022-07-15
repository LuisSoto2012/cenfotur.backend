using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AkterTable_ParticipanteEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreComercial",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "RazonSocial",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "Ruc",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "TelefonoFijo",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "TelefonoMovil",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "TipoContribuyente",
                table: "Empresas");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoContribuyenteId",
                table: "Empresas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TiposContribuyentes",
                columns: table => new
                {
                    TipoContribuyenteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposContribuyentes", x => x.TipoContribuyenteId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_EmpresaId",
                table: "Participantes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_TipoContribuyenteId",
                table: "Empresas",
                column: "TipoContribuyenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_TiposContribuyentes_TipoContribuyenteId",
                table: "Empresas",
                column: "TipoContribuyenteId",
                principalTable: "TiposContribuyentes",
                principalColumn: "TipoContribuyenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Empresas_EmpresaId",
                table: "Participantes",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_TiposContribuyentes_TipoContribuyenteId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Empresas_EmpresaId",
                table: "Participantes");

            migrationBuilder.DropTable(
                name: "TiposContribuyentes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_EmpresaId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_TipoContribuyenteId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "TipoContribuyenteId",
                table: "Empresas");

            migrationBuilder.AddColumn<string>(
                name: "NombreComercial",
                table: "Participantes",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazonSocial",
                table: "Participantes",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ruc",
                table: "Participantes",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoFijo",
                table: "Participantes",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoMovil",
                table: "Empresas",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoContribuyente",
                table: "Empresas",
                type: "varchar(50)",
                nullable: true);
        }
    }
}
