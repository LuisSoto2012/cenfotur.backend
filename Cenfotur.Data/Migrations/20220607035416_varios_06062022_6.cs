using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class varios_06062022_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnioId",
                table: "Contrataciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MetasPresupuestales_AnioId",
                table: "MetasPresupuestales",
                column: "AnioId");

            migrationBuilder.CreateIndex(
                name: "IX_Contrataciones_AnioId",
                table: "Contrataciones",
                column: "AnioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrataciones_Anios_AnioId",
                table: "Contrataciones",
                column: "AnioId",
                principalTable: "Anios",
                principalColumn: "AnioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MetasPresupuestales_Anios_AnioId",
                table: "MetasPresupuestales",
                column: "AnioId",
                principalTable: "Anios",
                principalColumn: "AnioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrataciones_Anios_AnioId",
                table: "Contrataciones");

            migrationBuilder.DropForeignKey(
                name: "FK_MetasPresupuestales_Anios_AnioId",
                table: "MetasPresupuestales");

            migrationBuilder.DropIndex(
                name: "IX_MetasPresupuestales_AnioId",
                table: "MetasPresupuestales");

            migrationBuilder.DropIndex(
                name: "IX_Contrataciones_AnioId",
                table: "Contrataciones");

            migrationBuilder.DropColumn(
                name: "AnioId",
                table: "Contrataciones");
        }
    }
}
