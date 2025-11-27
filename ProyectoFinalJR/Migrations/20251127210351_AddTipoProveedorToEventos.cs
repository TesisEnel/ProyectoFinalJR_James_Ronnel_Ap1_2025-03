using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalJR.Migrations
{
    /// <inheritdoc />
    public partial class AddTipoProveedorToEventos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoProveedorId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_TipoProveedorId",
                table: "Eventos",
                column: "TipoProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_TiposProveedores_TipoProveedorId",
                table: "Eventos",
                column: "TipoProveedorId",
                principalTable: "TiposProveedores",
                principalColumn: "TipoProveedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_TiposProveedores_TipoProveedorId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_TipoProveedorId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "TipoProveedorId",
                table: "Eventos");
        }
    }
}
