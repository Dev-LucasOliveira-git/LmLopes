using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Application;

namespace Infra.Application.Configurations
{
    public class ClientePocoConfiguration : IEntityTypeConfiguration<ClientePoco>
	{
		public void Configure(EntityTypeBuilder<ClientePoco> builder)
		{
			builder.ToTable("cliente");

			builder.HasKey(entity => entity.IdCliente);
			builder.Property(entity => entity.IdCliente).ValueGeneratedOnAdd();
			builder.Property(entity => entity.Nome).IsRequired().HasMaxLength(60);
			builder.Property(entity => entity.Email).HasMaxLength(60);
			builder.Property(entity => entity.CpfCnpj).HasMaxLength(11);
			builder.Property(entity => entity.Telefone).IsRequired().HasMaxLength(11);
			builder.Property(entity => entity.Bairro).HasMaxLength(100);
			builder.Property(entity => entity.Endereco).HasMaxLength(100);
			builder.Property(entity => entity.Numero).HasMaxLength(15);
			builder.Property(entity => entity.Complemento).HasMaxLength(100);
			builder.Property(entity => entity.IdUsuarioCadastro).IsRequired();
			builder.Property(entity => entity.DataHoraCadastro).IsRequired().HasDefaultValueSql("now()");
			builder.Property(entity => entity.DataHoraUltimaAlteracao).IsRequired().HasDefaultValueSql("now()");

			builder.HasOne(entity => entity.UsuarioCadastro).WithMany(x => x.ClientesCadastrados).HasForeignKey(x => x.IdUsuarioCadastro);
			builder.HasOne(entity => entity.UsuarioUltimaAlteracao).WithMany(x => x.ClientesUltimaAlteracao).HasForeignKey(x => x.IdUsuarioUltimaAlteracao);
			builder.HasMany(entity => entity.OrdensServicos).WithOne();
			builder.HasOne(entity => entity.Cidade).WithMany().HasForeignKey(x => x.IdCidade);
			builder.HasOne(entity => entity.Estado).WithMany().HasForeignKey(x => x.IdEstado);

		}
	}
}
