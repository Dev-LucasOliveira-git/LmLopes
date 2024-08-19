using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.MySql.Migrations
{
    /// <inheritdoc />
    public partial class updateTabela_OrdemSimples_CamposCLiente_TrabalhoConcluido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TrabalhoConcluido",
                table: "ordem_servico_simples",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrabalhoConcluido",
                table: "ordem_servico_simples");
        }
    }
}
