using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_Capcitaciones_UbigeoRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ubigeo",
                table: "Capacitaciones");

            migrationBuilder.AddColumn<string>(
                name: "UbigeoDistritoId",
                table: "Capacitaciones",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Capacitaciones_UbigeoDistritoId",
                table: "Capacitaciones",
                column: "UbigeoDistritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capacitaciones_Distritos_UbigeoDistritoId",
                table: "Capacitaciones",
                column: "UbigeoDistritoId",
                principalTable: "Distritos",
                principalColumn: "DistritoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capacitaciones_Distritos_UbigeoDistritoId",
                table: "Capacitaciones");

            migrationBuilder.DropIndex(
                name: "IX_Capacitaciones_UbigeoDistritoId",
                table: "Capacitaciones");

            migrationBuilder.DropColumn(
                name: "UbigeoDistritoId",
                table: "Capacitaciones");

            migrationBuilder.AddColumn<string>(
                name: "Ubigeo",
                table: "Capacitaciones",
                type: "varchar(20)",
                nullable: true);
        }
    }
}
