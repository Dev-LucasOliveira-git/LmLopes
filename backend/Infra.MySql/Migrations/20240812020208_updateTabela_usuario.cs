using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.MySql.Migrations
{
    /// <inheritdoc />
    public partial class updateTabela_usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "CaminhoImagem",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "usuario");

            migrationBuilder.AddColumn<string>(
                name: "TipoUsuario",
                table: "usuario",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoUsuario",
                table: "usuario");

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "usuario",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CaminhoImagem",
                table: "usuario",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "usuario",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
