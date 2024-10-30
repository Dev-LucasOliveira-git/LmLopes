using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.MySql.Migrations
{
    /// <inheritdoc />
    public partial class update_ordem_servico_simples_add_imgAssinaturaEng : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImgAssinatura",
                table: "ordem_servico_simples",
                newName: "ImgAssinaturaEngenheiro");

            migrationBuilder.AddColumn<byte[]>(
                name: "ImgAssinaturaCliente",
                table: "ordem_servico_simples",
                type: "LONGBLOB",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgAssinaturaCliente",
                table: "ordem_servico_simples");

            migrationBuilder.RenameColumn(
                name: "ImgAssinaturaEngenheiro",
                table: "ordem_servico_simples",
                newName: "ImgAssinatura");
        }
    }
}
