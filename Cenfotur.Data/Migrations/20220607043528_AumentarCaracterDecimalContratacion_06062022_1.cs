using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AumentarCaracterDecimalContratacion_06062022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Remuneracion",
                table: "Contrataciones",
                type: "decimal(7,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Remuneracion",
                table: "Contrataciones",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(7,2)");
        }
    }
}
