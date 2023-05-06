using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AddNewColumnsOnNotasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EP",
                table: "Notas",
                newName: "EP5");

            migrationBuilder.RenameColumn(
                name: "ED",
                table: "Notas",
                newName: "EP4");

            migrationBuilder.AddColumn<string>(
                name: "EP1",
                table: "Notas",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EP2",
                table: "Notas",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EP3",
                table: "Notas",
                type: "varchar(20)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EP1",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "EP2",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "EP3",
                table: "Notas");

            migrationBuilder.RenameColumn(
                name: "EP5",
                table: "Notas",
                newName: "EP");

            migrationBuilder.RenameColumn(
                name: "EP4",
                table: "Notas",
                newName: "ED");
        }
    }
}
