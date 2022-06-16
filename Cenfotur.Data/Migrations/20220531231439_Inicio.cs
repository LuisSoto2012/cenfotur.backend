using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApellidoPaterno = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Nombres = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    TelefMovil = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    Correo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    TipoDocumentoId = table.Column<int>(type: "int", nullable: false),
                    NumDoc = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Usuario = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Contrasena = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    LoginEstado = table.Column<bool>(type: "bit", nullable: false),
                    FechaNacimiento = table.Column<string>(type: "varchar(8)", nullable: true),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    ModuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Icono = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.ModuloId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "SubModulos",
                columns: table => new
                {
                    SubModuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Ruta = table.Column<string>(type: "varchar(200)", nullable: true),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubModulos", x => x.SubModuloId);
                    table.ForeignKey(
                        name: "FK_SubModulos_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "ModuloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpleadoRol",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpleadoRol", x => new { x.EmpleadoId, x.RolId });
                    table.ForeignKey(
                        name: "FK_EmpleadoRol_Empleados_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpleadoRol_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolSubModulo",
                columns: table => new
                {
                    RolSubModuloId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    SubModuloId = table.Column<int>(type: "int", nullable: false),
                    Ver = table.Column<bool>(type: "bit", nullable: false),
                    Agregar = table.Column<bool>(type: "bit", nullable: false),
                    Editar = table.Column<bool>(type: "bit", nullable: false),
                    Eliminar = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioModificacionId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolSubModulo", x => x.RolSubModuloId);
                    table.ForeignKey(
                        name: "FK_RolSubModulo_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolSubModulo_SubModulos_SubModuloId",
                        column: x => x.SubModuloId,
                        principalTable: "SubModulos",
                        principalColumn: "SubModuloId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmpleadoRol_RolId",
                table: "EmpleadoRol",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_RolSubModulo_RolId",
                table: "RolSubModulo",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_RolSubModulo_SubModuloId",
                table: "RolSubModulo",
                column: "SubModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_SubModulos_ModuloId",
                table: "SubModulos",
                column: "ModuloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpleadoRol");

            migrationBuilder.DropTable(
                name: "RolSubModulo");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SubModulos");

            migrationBuilder.DropTable(
                name: "Modulos");
        }
    }
}
