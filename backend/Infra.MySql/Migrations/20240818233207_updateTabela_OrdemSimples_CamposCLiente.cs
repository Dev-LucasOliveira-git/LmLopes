using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.MySql.Migrations
{
    /// <inheritdoc />
    public partial class updateTabela_OrdemSimples_CamposCLiente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CargoCliente",
                table: "ordem_servico_simples",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "ordem_servico_simples",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RgCliente",
                table: "ordem_servico_simples",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoCliente",
                table: "ordem_servico_simples");

            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "ordem_servico_simples");

            migrationBuilder.DropColumn(
                name: "RgCliente",
                table: "ordem_servico_simples");
        }
    }
}
