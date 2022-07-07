using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class AlterTable_Participante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AceptaCorreosOtros",
                table: "Participantes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlcanceId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CargoDirectivoId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CargoOperativoId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "Participantes",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ConDiscapacidad",
                table: "Participantes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DistritoId",
                table: "Participantes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DomicilioActual",
                table: "Participantes",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoCivilId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperienciaEmpresa",
                table: "Participantes",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperienciaLaboralGeneral",
                table: "Participantes",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExperienciaLaboralPerfil",
                table: "Participantes",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradoInstruccion",
                table: "Participantes",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LugarNacimiento",
                table: "Participantes",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NivelEducativoId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProvinciaId",
                table: "Participantes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Remuneracion",
                table: "Participantes",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SexoId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TelefonoFijo",
                table: "Participantes",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDiscapacidad",
                table: "Participantes",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoRemuneracionId",
                table: "Participantes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Alcances",
                columns: table => new
                {
                    AlcanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alcances", x => x.AlcanceId);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    TipoCargo = table.Column<string>(type: "varchar(1)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosCiviles",
                columns: table => new
                {
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosCiviles", x => x.EstadoCivilId);
                });

            migrationBuilder.CreateTable(
                name: "NivelesEducativos",
                columns: table => new
                {
                    NivelEducativoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelesEducativos", x => x.NivelEducativoId);
                });

            migrationBuilder.CreateTable(
                name: "TiposRemuneraciones",
                columns: table => new
                {
                    TipoRemuneracionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposRemuneraciones", x => x.TipoRemuneracionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_AlcanceId",
                table: "Participantes",
                column: "AlcanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_CargoDirectivoId",
                table: "Participantes",
                column: "CargoDirectivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_CargoOperativoId",
                table: "Participantes",
                column: "CargoOperativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_DistritoId",
                table: "Participantes",
                column: "DistritoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_EstadoCivilId",
                table: "Participantes",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_NivelEducativoId",
                table: "Participantes",
                column: "NivelEducativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_ProvinciaId",
                table: "Participantes",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_SexoId",
                table: "Participantes",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participantes_TipoRemuneracionId",
                table: "Participantes",
                column: "TipoRemuneracionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Alcances_AlcanceId",
                table: "Participantes",
                column: "AlcanceId",
                principalTable: "Alcances",
                principalColumn: "AlcanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Cargos_CargoDirectivoId",
                table: "Participantes",
                column: "CargoDirectivoId",
                principalTable: "Cargos",
                principalColumn: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Cargos_CargoOperativoId",
                table: "Participantes",
                column: "CargoOperativoId",
                principalTable: "Cargos",
                principalColumn: "CargoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Distritos_DistritoId",
                table: "Participantes",
                column: "DistritoId",
                principalTable: "Distritos",
                principalColumn: "DistritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_EstadosCiviles_EstadoCivilId",
                table: "Participantes",
                column: "EstadoCivilId",
                principalTable: "EstadosCiviles",
                principalColumn: "EstadoCivilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_NivelesEducativos_NivelEducativoId",
                table: "Participantes",
                column: "NivelEducativoId",
                principalTable: "NivelesEducativos",
                principalColumn: "NivelEducativoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Provincias_ProvinciaId",
                table: "Participantes",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Sexos_SexoId",
                table: "Participantes",
                column: "SexoId",
                principalTable: "Sexos",
                principalColumn: "SexoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_TiposRemuneraciones_TipoRemuneracionId",
                table: "Participantes",
                column: "TipoRemuneracionId",
                principalTable: "TiposRemuneraciones",
                principalColumn: "TipoRemuneracionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Alcances_AlcanceId",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Cargos_CargoDirectivoId",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Cargos_CargoOperativoId",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Distritos_DistritoId",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_EstadosCiviles_EstadoCivilId",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_NivelesEducativos_NivelEducativoId",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Provincias_ProvinciaId",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Sexos_SexoId",
                table: "Participantes");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_TiposRemuneraciones_TipoRemuneracionId",
                table: "Participantes");

            migrationBuilder.DropTable(
                name: "Alcances");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "EstadosCiviles");

            migrationBuilder.DropTable(
                name: "NivelesEducativos");

            migrationBuilder.DropTable(
                name: "TiposRemuneraciones");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_AlcanceId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_CargoDirectivoId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_CargoOperativoId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_DistritoId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_EstadoCivilId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_NivelEducativoId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_ProvinciaId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_SexoId",
                table: "Participantes");

            migrationBuilder.DropIndex(
                name: "IX_Participantes_TipoRemuneracionId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "AceptaCorreosOtros",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "AlcanceId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "CargoDirectivoId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "CargoOperativoId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "ConDiscapacidad",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "DistritoId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "DomicilioActual",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "EstadoCivilId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "ExperienciaEmpresa",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "ExperienciaLaboralGeneral",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "ExperienciaLaboralPerfil",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "GradoInstruccion",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "LugarNacimiento",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "NivelEducativoId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "Remuneracion",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "SexoId",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "TelefonoFijo",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "TipoDiscapacidad",
                table: "Participantes");

            migrationBuilder.DropColumn(
                name: "TipoRemuneracionId",
                table: "Participantes");
        }
    }
}
