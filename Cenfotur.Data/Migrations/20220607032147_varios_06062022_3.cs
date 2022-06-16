using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class varios_06062022_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrataciones_Anios_AnioId",
                table: "Contrataciones");

            migrationBuilder.DropIndex(
                name: "IX_Contrataciones_AnioId",
                table: "Contrataciones");
        }
    }
}
