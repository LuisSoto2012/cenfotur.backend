using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class EliminaLoginEstado_03062022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoginEstado",
                table: "Empleados");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LoginEstado",
                table: "Empleados",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
