using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.MySql.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "engenheiro",
                columns: table => new
                {
                    IdEngenheiro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RG = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CREA = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_engenheiro", x => x.IdEngenheiro);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.IdEstado);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ordem_servico_equipamento",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroSerie = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tags = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordem_servico_equipamento", x => x.IdEquipamento);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Admin = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CaminhoImagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "now()"),
                    DataHoraUltimaAlteracao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "now()"),
                    IdUsuarioCadastro = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioUltimaAlteracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_usuario_usuario_IdUsuarioCadastro",
                        column: x => x.IdUsuarioCadastro,
                        principalTable: "usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_usuario_IdUsuarioUltimaAlteracao",
                        column: x => x.IdUsuarioUltimaAlteracao,
                        principalTable: "usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cidade",
                columns: table => new
                {
                    IdCidade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cidade", x => x.IdCidade);
                    table.ForeignKey(
                        name: "FK_cidade_estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "estado",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CEP = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CpfCnpj = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCidade = table.Column<int>(type: "int", nullable: true),
                    IdEstado = table.Column<int>(type: "int", nullable: true),
                    DataHoraCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "now()"),
                    DataHoraUltimaAlteracao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "now()"),
                    IdUsuarioCadastro = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioUltimaAlteracao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_cliente_cidade_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "cidade",
                        principalColumn: "IdCidade");
                    table.ForeignKey(
                        name: "FK_cliente_estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "estado",
                        principalColumn: "IdEstado");
                    table.ForeignKey(
                        name: "FK_cliente_usuario_IdUsuarioCadastro",
                        column: x => x.IdUsuarioCadastro,
                        principalTable: "usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cliente_usuario_IdUsuarioUltimaAlteracao",
                        column: x => x.IdUsuarioUltimaAlteracao,
                        principalTable: "usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RazaoSocial = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cnpj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Endereco = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bairro = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Numero = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Complemento = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCidade = table.Column<int>(type: "int", nullable: true),
                    IdEstado = table.Column<int>(type: "int", nullable: true),
                    CaminhoImagem = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.IdEmpresa);
                    table.ForeignKey(
                        name: "FK_empresa_cidade_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "cidade",
                        principalColumn: "IdCidade");
                    table.ForeignKey(
                        name: "FK_empresa_estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "estado",
                        principalColumn: "IdEstado");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ordem_servico",
                columns: table => new
                {
                    IdOrdem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataHora = table.Column<DateTime>(type: "datetime", nullable: false),
                    Numero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroPrisma = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contato = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Limpeza = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Ajuste = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Lubrificacao = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Obs = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdEngenheiro = table.Column<int>(type: "int", nullable: false),
                    idEquipamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordem_servico", x => x.IdOrdem);
                    table.ForeignKey(
                        name: "FK_ordem_servico_cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordem_servico_engenheiro_IdEngenheiro",
                        column: x => x.IdEngenheiro,
                        principalTable: "engenheiro",
                        principalColumn: "IdEngenheiro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordem_servico_ordem_servico_equipamento_idEquipamento",
                        column: x => x.idEquipamento,
                        principalTable: "ordem_servico_equipamento",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordem_servico_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ordem_servico_atividade",
                columns: table => new
                {
                    IdAtividade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOrdemServico = table.Column<int>(type: "int", nullable: false),
                    Preventiva = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Corretiva = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Instalalacao = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Movimentacao = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Outros = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Obs = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordem_servico_atividade", x => x.IdAtividade);
                    table.ForeignKey(
                        name: "FK_ordem_servico_atividade_ordem_servico_IdOrdemServico",
                        column: x => x.IdOrdemServico,
                        principalTable: "ordem_servico",
                        principalColumn: "IdOrdem",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ordem_servico_defeito",
                columns: table => new
                {
                    IdDefeito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdOrdemServico = table.Column<int>(type: "int", nullable: false),
                    Eletrico = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Mecanico = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Optico = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Outros = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Obs = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordem_servico_defeito", x => x.IdDefeito);
                    table.ForeignKey(
                        name: "FK_ordem_servico_defeito_ordem_servico_IdOrdemServico",
                        column: x => x.IdOrdemServico,
                        principalTable: "ordem_servico",
                        principalColumn: "IdOrdem",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ordem_servico_material_utilizado",
                columns: table => new
                {
                    IdMaterialUtilizado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantidade = table.Column<decimal>(type: "decimal(11,2)", precision: 11, scale: 2, nullable: false),
                    IdOrdemServico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordem_servico_material_utilizado", x => x.IdMaterialUtilizado);
                    table.ForeignKey(
                        name: "FK_ordem_servico_material_utilizado_ordem_servico_IdOrdemServico",
                        column: x => x.IdOrdemServico,
                        principalTable: "ordem_servico",
                        principalColumn: "IdOrdem",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_cidade_IdEstado",
                table: "cidade",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdCidade",
                table: "cliente",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdEstado",
                table: "cliente",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdUsuarioCadastro",
                table: "cliente",
                column: "IdUsuarioCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_IdUsuarioUltimaAlteracao",
                table: "cliente",
                column: "IdUsuarioUltimaAlteracao");

            migrationBuilder.CreateIndex(
                name: "IX_empresa_IdCidade",
                table: "empresa",
                column: "IdCidade",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_empresa_IdEstado",
                table: "empresa",
                column: "IdEstado",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ordem_servico_IdCliente",
                table: "ordem_servico",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ordem_servico_IdEngenheiro",
                table: "ordem_servico",
                column: "IdEngenheiro");

            migrationBuilder.CreateIndex(
                name: "IX_ordem_servico_idEquipamento",
                table: "ordem_servico",
                column: "idEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_ordem_servico_IdUsuario",
                table: "ordem_servico",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ordem_servico_atividade_IdOrdemServico",
                table: "ordem_servico_atividade",
                column: "IdOrdemServico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ordem_servico_defeito_IdOrdemServico",
                table: "ordem_servico_defeito",
                column: "IdOrdemServico",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ordem_servico_material_utilizado_IdOrdemServico",
                table: "ordem_servico_material_utilizado",
                column: "IdOrdemServico");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_IdUsuarioCadastro",
                table: "usuario",
                column: "IdUsuarioCadastro");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_IdUsuarioUltimaAlteracao",
                table: "usuario",
                column: "IdUsuarioUltimaAlteracao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "ordem_servico_atividade");

            migrationBuilder.DropTable(
                name: "ordem_servico_defeito");

            migrationBuilder.DropTable(
                name: "ordem_servico_material_utilizado");

            migrationBuilder.DropTable(
                name: "ordem_servico");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "engenheiro");

            migrationBuilder.DropTable(
                name: "ordem_servico_equipamento");

            migrationBuilder.DropTable(
                name: "cidade");

            migrationBuilder.DropTable(
                name: "usuario");

            migrationBuilder.DropTable(
                name: "estado");
        }
    }
}
