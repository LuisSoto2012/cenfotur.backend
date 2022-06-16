using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class EliminaEmpleadoCargo_09062022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadoCargos");

            migrationBuilder.DropColumn(
                name: "EmpleadoCargoId",
                table: "Empleados");

            migrationBuilder.AlterColumn<decimal>(
                name: "Remuneracion",
                table: "Contrataciones",
                type: "decimal(7,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Contrataciones",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmpleadoCargoId",
                table: "Empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Remuneracion",
                table: "Contrataciones",
                type: "decimal(7,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Contrataciones",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EmpleadoCargos",
                columns: table => new
                {
                    EmpleadoCargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoCargos", x => x.EmpleadoCargoId);
                });
        }
    }
}
