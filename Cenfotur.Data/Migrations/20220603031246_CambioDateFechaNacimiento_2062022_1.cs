using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class CambioDateFechaNacimiento_2062022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FechaNacimiento",
                table: "Empleados",
                type: "varchar(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(8)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FechaNacimiento",
                table: "Empleados",
                type: "varchar(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)");
        }
    }
}
