using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AgregaEmpleadoCargo_04062022_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpleadoCargo",
                table: "Empleados",
                newName: "EmpleadoCargoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmpleadoCargoId",
                table: "Empleados",
                newName: "EmpleadoCargo");
        }
    }
}
