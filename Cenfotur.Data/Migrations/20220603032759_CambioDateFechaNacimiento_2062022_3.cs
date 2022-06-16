using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class CambioDateFechaNacimiento_2062022_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Empleados",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Empleados",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");
        }
    }
}
