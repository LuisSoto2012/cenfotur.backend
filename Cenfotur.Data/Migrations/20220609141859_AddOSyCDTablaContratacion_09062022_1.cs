using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AddOSyCDTablaContratacion_09062022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContratacionDescripcion",
                table: "Contrataciones",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrdenServicio",
                table: "Contrataciones",
                type: "varchar(15)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContratacionDescripcion",
                table: "Contrataciones");

            migrationBuilder.DropColumn(
                name: "OrdenServicio",
                table: "Contrataciones");
        }
    }
}
