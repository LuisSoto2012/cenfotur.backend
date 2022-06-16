using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cenfotur.Data.Migrations
{
    public partial class varios_06062022_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratacion_Empleados_EmpleadoId",
                table: "Contratacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratacion_MetasPresupuestales_MetaPresupuestalId",
                table: "Contratacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Contratacion_PuestosLaborales_PuestoLaboralId",
                table: "Contratacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contratacion",
                table: "Contratacion");

            migrationBuilder.RenameTable(
                name: "Contratacion",
                newName: "Contrataciones");

            migrationBuilder.RenameIndex(
                name: "IX_Contratacion_PuestoLaboralId",
                table: "Contrataciones",
                newName: "IX_Contrataciones_PuestoLaboralId");

            migrationBuilder.RenameIndex(
                name: "IX_Contratacion_MetaPresupuestalId",
                table: "Contrataciones",
                newName: "IX_Contrataciones_MetaPresupuestalId");

            migrationBuilder.RenameIndex(
                name: "IX_Contratacion_EmpleadoId",
                table: "Contrataciones",
                newName: "IX_Contrataciones_EmpleadoId");

            migrationBuilder.AddColumn<int>(
                name: "AnioId",
                table: "Contrataciones",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contrataciones",
                table: "Contrataciones",
                column: "ContratacionId");

            migrationBuilder.CreateIndex(
                name: "IX_MetasPresupuestales_AnioId",
                table: "MetasPresupuestales",
                column: "AnioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrataciones_Empleados_EmpleadoId",
                table: "Contrataciones",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contrataciones_MetasPresupuestales_MetaPresupuestalId",
                table: "Contrataciones",
                column: "MetaPresupuestalId",
                principalTable: "MetasPresupuestales",
                principalColumn: "MetaPresupuestalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contrataciones_PuestosLaborales_PuestoLaboralId",
                table: "Contrataciones",
                column: "PuestoLaboralId",
                principalTable: "PuestosLaborales",
                principalColumn: "PuestoLaboralId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MetasPresupuestales_Anios_AnioId",
                table: "MetasPresupuestales",
                column: "AnioId",
                principalTable: "Anios",
                principalColumn: "AnioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrataciones_Empleados_EmpleadoId",
                table: "Contrataciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Contrataciones_MetasPresupuestales_MetaPresupuestalId",
                table: "Contrataciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Contrataciones_PuestosLaborales_PuestoLaboralId",
                table: "Contrataciones");

            migrationBuilder.DropForeignKey(
                name: "FK_MetasPresupuestales_Anios_AnioId",
                table: "MetasPresupuestales");

            migrationBuilder.DropIndex(
                name: "IX_MetasPresupuestales_AnioId",
                table: "MetasPresupuestales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contrataciones",
                table: "Contrataciones");

            migrationBuilder.DropColumn(
                name: "AnioId",
                table: "Contrataciones");

            migrationBuilder.RenameTable(
                name: "Contrataciones",
                newName: "Contratacion");

            migrationBuilder.RenameIndex(
                name: "IX_Contrataciones_PuestoLaboralId",
                table: "Contratacion",
                newName: "IX_Contratacion_PuestoLaboralId");

            migrationBuilder.RenameIndex(
                name: "IX_Contrataciones_MetaPresupuestalId",
                table: "Contratacion",
                newName: "IX_Contratacion_MetaPresupuestalId");

            migrationBuilder.RenameIndex(
                name: "IX_Contrataciones_EmpleadoId",
                table: "Contratacion",
                newName: "IX_Contratacion_EmpleadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contratacion",
                table: "Contratacion",
                column: "ContratacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratacion_Empleados_EmpleadoId",
                table: "Contratacion",
                column: "EmpleadoId",
                principalTable: "Empleados",
                principalColumn: "EmpleadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratacion_MetasPresupuestales_MetaPresupuestalId",
                table: "Contratacion",
                column: "MetaPresupuestalId",
                principalTable: "MetasPresupuestales",
                principalColumn: "MetaPresupuestalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contratacion_PuestosLaborales_PuestoLaboralId",
                table: "Contratacion",
                column: "PuestoLaboralId",
                principalTable: "PuestosLaborales",
                principalColumn: "PuestoLaboralId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
