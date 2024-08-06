using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.MySql.Migrations
{
    /// <inheritdoc />
    public partial class addOrdemSimplesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ordem_servico_material_utilizado_ordem_servico_IdOrdemServico",
                table: "ordem_servico_material_utilizado");

            migrationBuilder.AlterColumn<int>(
                name: "IdOrdemServico",
                table: "ordem_servico_material_utilizado",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdOrdemServicoSimples",
                table: "ordem_servico_material_utilizado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ordem_servico_simples",
                columns: table => new
                {
                    IdOrdem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHora = table.Column<DateTime>(type: "datetime", nullable: false),
                    Numero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroPrisma = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contato = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Colp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Equipamento = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numSerie = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoraInicio = table.Column<DateTime>(type: "datetime", nullable: true),
                    HoraFim = table.Column<DateTime>(type: "datetime", nullable: true),
                    Atividade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Defeito = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ComplementoAtividade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ComplementoDefeito = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Limpeza = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Ajuste = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Lubrificacao = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Obs = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeEngenheiro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rg_Crea = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordem_servico_simples", x => x.IdOrdem);
                    table.ForeignKey(
                        name: "FK_ordem_servico_simples_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ordem_servico_material_utilizado_IdOrdemServicoSimples",
                table: "ordem_servico_material_utilizado",
                column: "IdOrdemServicoSimples");

            migrationBuilder.CreateIndex(
                name: "IX_ordem_servico_simples_IdUsuario",
                table: "ordem_servico_simples",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_ordem_servico_material_utilizado_ordem_servico_IdOrdemServico",
                table: "ordem_servico_material_utilizado",
                column: "IdOrdemServico",
                principalTable: "ordem_servico",
                principalColumn: "IdOrdem");

            migrationBuilder.AddForeignKey(
                name: "FK_ordem_servico_material_utilizado_ordem_servico_simples_IdOrd~",
                table: "ordem_servico_material_utilizado",
                column: "IdOrdemServicoSimples",
                principalTable: "ordem_servico_simples",
                principalColumn: "IdOrdem");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ordem_servico_material_utilizado_ordem_servico_IdOrdemServico",
                table: "ordem_servico_material_utilizado");

            migrationBuilder.DropForeignKey(
                name: "FK_ordem_servico_material_utilizado_ordem_servico_simples_IdOrd~",
                table: "ordem_servico_material_utilizado");

            migrationBuilder.DropTable(
                name: "ordem_servico_simples");

            migrationBuilder.DropIndex(
                name: "IX_ordem_servico_material_utilizado_IdOrdemServicoSimples",
                table: "ordem_servico_material_utilizado");

            migrationBuilder.DropColumn(
                name: "IdOrdemServicoSimples",
                table: "ordem_servico_material_utilizado");

            migrationBuilder.AlterColumn<int>(
                name: "IdOrdemServico",
                table: "ordem_servico_material_utilizado",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ordem_servico_material_utilizado_ordem_servico_IdOrdemServico",
                table: "ordem_servico_material_utilizado",
                column: "IdOrdemServico",
                principalTable: "ordem_servico",
                principalColumn: "IdOrdem",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
