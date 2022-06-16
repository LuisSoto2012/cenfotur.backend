using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class ChangeOSyCDTablaContratacion_09062022_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrdenServicio",
                table: "Contrataciones",
                type: "varchar(40)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContratacionDescripcion",
                table: "Contrataciones",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrdenServicio",
                table: "Contrataciones",
                type: "varchar(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContratacionDescripcion",
                table: "Contrataciones",
                type: "varchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);
        }
    }
}
