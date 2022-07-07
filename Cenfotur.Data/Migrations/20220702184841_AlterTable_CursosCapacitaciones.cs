using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_CursosCapacitaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desempenio",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "PublicoObjetivo",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Dias",
                table: "Capacitaciones");

            migrationBuilder.DropColumn(
                name: "Horas",
                table: "Capacitaciones");

            migrationBuilder.DropColumn(
                name: "PublicoObjetivo",
                table: "Capacitaciones");

            migrationBuilder.AddColumn<string>(
                name: "CertificadoEstudios",
                table: "Participantes",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CertificadoTrabajo",
                table: "Participantes",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PracticaNoAplica",
                table: "Cursos",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<decimal>(
                name: "Practica",
                table: "Cursos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "PerfilRelacionadoId",
                table: "Cursos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Practica2",
                table: "Cursos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Practica3",
                table: "Cursos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Practica4",
                table: "Cursos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Practica5",
                table: "Cursos",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PracticaNoAplica2",
                table: "Cursos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PracticaNoAplica3",
                table: "Cursos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PracticaNoAplica4",
                table: "Cursos",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PracticaNoAplica5",
                table: "Cursos",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_PerfilRelacionadoId",
                table: "Cursos",
                column: "PerfilRelacionadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_PerfilesRelacionados_PerfilRelacionadoId",
                table: "Cursos",
                column: "PerfilRelacionadoId",
                principalTable: "PerfilesRelacionados",
                principalColumn: "PerfilRelacionadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_PerfilesRelacionados_PerfilRelacionadoId",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_PerfilRelacionadoId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "CertificadoEstudios",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "CertificadoTrabajo",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "PerfilRelacionadoId",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Practica2",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Practica3",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Practica4",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "Practica5",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "PracticaNoAplica2",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "PracticaNoAplica3",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "PracticaNoAplica4",
                table: "Cursos");

            migrationBuilder.DropColumn(
                name: "PracticaNoAplica5",
                table: "Cursos");

            migrationBuilder.AlterColumn<bool>(
                name: "PracticaNoAplica",
                table: "Cursos",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Practica",
                table: "Cursos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Desempenio",
                table: "Cursos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "PublicoObjetivo",
                table: "Cursos",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Dias",
                table: "Capacitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Horas",
                table: "Capacitaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PublicoObjetivo",
                table: "Capacitaciones",
                type: "varchar(100)",
                nullable: true);
        }
    }
}
