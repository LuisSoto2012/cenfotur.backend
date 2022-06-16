using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class NoUniqueRoSubModulo_06062022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RolSubModulo_RolId",
                table: "RolSubModulo");

            migrationBuilder.CreateIndex(
                name: "IX_RolSubModulo_RolId",
                table: "RolSubModulo",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RolSubModulo_RolId",
                table: "RolSubModulo");

            migrationBuilder.CreateIndex(
                name: "IX_RolSubModulo_RolId",
                table: "RolSubModulo",
                column: "RolId",
                unique: true);
        }
    }
}
