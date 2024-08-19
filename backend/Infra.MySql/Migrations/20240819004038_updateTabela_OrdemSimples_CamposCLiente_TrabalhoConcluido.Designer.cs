﻿// <auto-generated />
using System;
using Infra.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.MySql.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240819004038_updateTabela_OrdemSimples_CamposCLiente_TrabalhoConcluido")]
    partial class updateTabela_OrdemSimples_CamposCLiente_TrabalhoConcluido
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Entities.Application.AtividadeOrdemPoco", b =>
                {
                    b.Property<int>("IdAtividade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Corretiva")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("IdOrdemServico")
                        .HasColumnType("int");

                    b.Property<bool>("Instalalacao")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Movimentacao")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Obs")
                        .HasColumnType("longtext");

                    b.Property<bool>("Outros")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Preventiva")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IdAtividade");

                    b.HasIndex("IdOrdemServico")
                        .IsUnique();

                    b.ToTable("ordem_servico_atividade", (string)null);
                });

            modelBuilder.Entity("Entities.Application.CidadePoco", b =>
                {
                    b.Property<int>("IdCidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdCidade");

                    b.HasIndex("IdEstado");

                    b.ToTable("cidade", (string)null);
                });

            modelBuilder.Entity("Entities.Application.ClientePoco", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CEP")
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CpfCnpj")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataHoraCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("DataHoraUltimaAlteracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Endereco")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IdCidade")
                        .HasColumnType("int");

                    b.Property<int?>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioCadastro")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioUltimaAlteracao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Numero")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.HasKey("IdCliente");

                    b.HasIndex("IdCidade");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdUsuarioCadastro");

                    b.HasIndex("IdUsuarioUltimaAlteracao");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("Entities.Application.DefeitoOrdemPoco", b =>
                {
                    b.Property<int>("IdDefeito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Eletrico")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("IdOrdemServico")
                        .HasColumnType("int");

                    b.Property<bool>("Mecanico")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Obs")
                        .HasColumnType("longtext");

                    b.Property<bool>("Optico")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Outros")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("IdDefeito");

                    b.HasIndex("IdOrdemServico")
                        .IsUnique();

                    b.ToTable("ordem_servico_defeito", (string)null);
                });

            modelBuilder.Entity("Entities.Application.EmpresaPoco", b =>
                {
                    b.Property<int>("IdEmpresa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CaminhoImagem")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IdCidade")
                        .HasColumnType("int");

                    b.Property<int?>("IdEstado")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.HasKey("IdEmpresa");

                    b.HasIndex("IdCidade")
                        .IsUnique();

                    b.HasIndex("IdEstado")
                        .IsUnique();

                    b.ToTable("empresa", (string)null);
                });

            modelBuilder.Entity("Entities.Application.EngenheiroPoco", b =>
                {
                    b.Property<int>("IdEngenheiro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CREA")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RG")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.HasKey("IdEngenheiro");

                    b.ToTable("engenheiro", (string)null);
                });

            modelBuilder.Entity("Entities.Application.EquipamentoPoco", b =>
                {
                    b.Property<int>("IdEquipamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdEquipamento");

                    b.ToTable("ordem_servico_equipamento", (string)null);
                });

            modelBuilder.Entity("Entities.Application.EstadoPoco", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("IdEstado");

                    b.ToTable("estado", (string)null);
                });

            modelBuilder.Entity("Entities.Application.MaterialUtilizadoPoco", b =>
                {
                    b.Property<int>("IdMaterialUtilizado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("IdOrdemServico")
                        .HasColumnType("int");

                    b.Property<int?>("IdOrdemServicoSimples")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantidade")
                        .HasPrecision(11, 2)
                        .HasColumnType("decimal(11,2)");

                    b.HasKey("IdMaterialUtilizado");

                    b.HasIndex("IdOrdemServico");

                    b.HasIndex("IdOrdemServicoSimples");

                    b.ToTable("ordem_servico_material_utilizado", (string)null);
                });

            modelBuilder.Entity("Entities.Application.OrdemServicoPoco", b =>
                {
                    b.Property<int>("IdOrdem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Ajuste")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEngenheiro")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("Limpeza")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Lubrificacao")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroPrisma")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Obs")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("idEquipamento")
                        .HasColumnType("int");

                    b.HasKey("IdOrdem");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEngenheiro");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("idEquipamento");

                    b.ToTable("ordem_servico", (string)null);
                });

            modelBuilder.Entity("Entities.Application.OrdemServicoSimplesPoco", b =>
                {
                    b.Property<int>("IdOrdem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool?>("Ajuste")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Atividade")
                        .HasColumnType("longtext");

                    b.Property<string>("CargoCliente")
                        .HasColumnType("longtext");

                    b.Property<string>("Colp")
                        .HasColumnType("longtext");

                    b.Property<string>("ComplementoAtividade")
                        .HasColumnType("longtext");

                    b.Property<string>("ComplementoDefeito")
                        .HasColumnType("longtext");

                    b.Property<string>("Contato")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime");

                    b.Property<string>("Defeito")
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .HasColumnType("longtext");

                    b.Property<string>("Equipamento")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("HoraFim")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("HoraInicio")
                        .HasColumnType("datetime");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool?>("Limpeza")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool?>("Lubrificacao")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("NomeCliente")
                        .HasColumnType("longtext");

                    b.Property<string>("NomeEngenheiro")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumeroPrisma")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Obs")
                        .HasColumnType("longtext");

                    b.Property<string>("RgCliente")
                        .HasColumnType("longtext");

                    b.Property<string>("Rg_Crea")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .HasColumnType("longtext");

                    b.Property<string>("TrabalhoConcluido")
                        .HasColumnType("longtext");

                    b.Property<string>("numSerie")
                        .HasColumnType("longtext");

                    b.HasKey("IdOrdem");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ordem_servico_simples", (string)null);
                });

            modelBuilder.Entity("Entities.Application.UsuarioPoco", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataHoraCadastro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("now()");

                    b.Property<DateTime>("DataHoraUltimaAlteracao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdUsuarioCadastro")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioUltimaAlteracao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoUsuario")
                        .HasColumnType("longtext");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdUsuarioCadastro");

                    b.HasIndex("IdUsuarioUltimaAlteracao");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("Entities.Application.AtividadeOrdemPoco", b =>
                {
                    b.HasOne("Entities.Application.OrdemServicoPoco", "OrdemServico")
                        .WithOne("Atividade")
                        .HasForeignKey("Entities.Application.AtividadeOrdemPoco", "IdOrdemServico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdemServico");
                });

            modelBuilder.Entity("Entities.Application.CidadePoco", b =>
                {
                    b.HasOne("Entities.Application.EstadoPoco", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Entities.Application.ClientePoco", b =>
                {
                    b.HasOne("Entities.Application.CidadePoco", "Cidade")
                        .WithMany()
                        .HasForeignKey("IdCidade");

                    b.HasOne("Entities.Application.EstadoPoco", "Estado")
                        .WithMany()
                        .HasForeignKey("IdEstado");

                    b.HasOne("Entities.Application.UsuarioPoco", "UsuarioCadastro")
                        .WithMany("ClientesCadastrados")
                        .HasForeignKey("IdUsuarioCadastro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Application.UsuarioPoco", "UsuarioUltimaAlteracao")
                        .WithMany("ClientesUltimaAlteracao")
                        .HasForeignKey("IdUsuarioUltimaAlteracao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");

                    b.Navigation("Estado");

                    b.Navigation("UsuarioCadastro");

                    b.Navigation("UsuarioUltimaAlteracao");
                });

            modelBuilder.Entity("Entities.Application.DefeitoOrdemPoco", b =>
                {
                    b.HasOne("Entities.Application.OrdemServicoPoco", "OrdemServico")
                        .WithOne("Defeito")
                        .HasForeignKey("Entities.Application.DefeitoOrdemPoco", "IdOrdemServico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrdemServico");
                });

            modelBuilder.Entity("Entities.Application.EmpresaPoco", b =>
                {
                    b.HasOne("Entities.Application.CidadePoco", "Cidade")
                        .WithOne()
                        .HasForeignKey("Entities.Application.EmpresaPoco", "IdCidade");

                    b.HasOne("Entities.Application.EstadoPoco", "Estado")
                        .WithOne()
                        .HasForeignKey("Entities.Application.EmpresaPoco", "IdEstado");

                    b.Navigation("Cidade");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Entities.Application.MaterialUtilizadoPoco", b =>
                {
                    b.HasOne("Entities.Application.OrdemServicoPoco", "OrdemServico")
                        .WithMany("MateriaisUtilizados")
                        .HasForeignKey("IdOrdemServico");

                    b.HasOne("Entities.Application.OrdemServicoSimplesPoco", "OrdemServicoSimples")
                        .WithMany("MateriaisUtilizados")
                        .HasForeignKey("IdOrdemServicoSimples");

                    b.Navigation("OrdemServico");

                    b.Navigation("OrdemServicoSimples");
                });

            modelBuilder.Entity("Entities.Application.OrdemServicoPoco", b =>
                {
                    b.HasOne("Entities.Application.ClientePoco", "Cliente")
                        .WithMany("OrdensServicos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Application.EngenheiroPoco", "Engenheiro")
                        .WithMany("OrdensServicos")
                        .HasForeignKey("IdEngenheiro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Application.UsuarioPoco", "Usuario")
                        .WithMany("OrdensServicos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Application.EquipamentoPoco", "Equipamento")
                        .WithMany("OrdensServicos")
                        .HasForeignKey("idEquipamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Engenheiro");

                    b.Navigation("Equipamento");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Application.OrdemServicoSimplesPoco", b =>
                {
                    b.HasOne("Entities.Application.UsuarioPoco", "Usuario")
                        .WithMany("OrdensServicosSimples")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entities.Application.UsuarioPoco", b =>
                {
                    b.HasOne("Entities.Application.UsuarioPoco", "UsuarioCadastro")
                        .WithMany()
                        .HasForeignKey("IdUsuarioCadastro")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Application.UsuarioPoco", "UsuarioUltimaAlteracao")
                        .WithMany()
                        .HasForeignKey("IdUsuarioUltimaAlteracao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioCadastro");

                    b.Navigation("UsuarioUltimaAlteracao");
                });

            modelBuilder.Entity("Entities.Application.ClientePoco", b =>
                {
                    b.Navigation("OrdensServicos");
                });

            modelBuilder.Entity("Entities.Application.EngenheiroPoco", b =>
                {
                    b.Navigation("OrdensServicos");
                });

            modelBuilder.Entity("Entities.Application.EquipamentoPoco", b =>
                {
                    b.Navigation("OrdensServicos");
                });

            modelBuilder.Entity("Entities.Application.OrdemServicoPoco", b =>
                {
                    b.Navigation("Atividade");

                    b.Navigation("Defeito");

                    b.Navigation("MateriaisUtilizados");
                });

            modelBuilder.Entity("Entities.Application.OrdemServicoSimplesPoco", b =>
                {
                    b.Navigation("MateriaisUtilizados");
                });

            modelBuilder.Entity("Entities.Application.UsuarioPoco", b =>
                {
                    b.Navigation("ClientesCadastrados");

                    b.Navigation("ClientesUltimaAlteracao");

                    b.Navigation("OrdensServicos");

                    b.Navigation("OrdensServicosSimples");
                });
#pragma warning restore 612, 618
        }
    }
}
