using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class Contrataciones_ArchivoOrdenServicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArchivoOrdenServicio",
                table: "Contrataciones",
                type: "varchar(200)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchivoOrdenServicio",
                table: "Contrataciones");
        }
    }
}
