using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinalJR.Migrations
{
    /// <inheritdoc />
    public partial class AddCamposTarjetaToPagos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CVV",
                table: "PagosDetalle",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaVencimiento",
                table: "PagosDetalle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroTarjeta",
                table: "PagosDetalle",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "PagosDetalle");

            migrationBuilder.DropColumn(
                name: "FechaVencimiento",
                table: "PagosDetalle");

            migrationBuilder.DropColumn(
                name: "NumeroTarjeta",
                table: "PagosDetalle");
        }
    }
}
