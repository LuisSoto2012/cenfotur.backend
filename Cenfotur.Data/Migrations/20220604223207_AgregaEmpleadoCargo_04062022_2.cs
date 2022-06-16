using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AgregaEmpleadoCargo_04062022_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpleadoCargo",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpleadoCargo",
                table: "Empleados");
        }
    }
}
