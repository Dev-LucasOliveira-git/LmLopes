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
    public class EmpresaPocoConfiguration : IEntityTypeConfiguration<EmpresaPoco>
	{
		public void Configure(EntityTypeBuilder<EmpresaPoco> builder)
		{
			builder.ToTable("empresa");

			builder.HasKey(entity => entity.IdEmpresa);
			builder.Property(entity => entity.IdEmpresa).ValueGeneratedOnAdd();
			builder.Property(entity => entity.RazaoSocial).IsRequired().HasMaxLength(100);
			builder.Property(entity => entity.Cnpj).IsRequired().HasMaxLength(14);
			builder.Property(entity => entity.Bairro).HasMaxLength(100);
			builder.Property(entity => entity.Endereco).HasMaxLength(100);
			builder.Property(entity => entity.Numero).HasMaxLength(15);
			builder.Property(entity => entity.Complemento).HasMaxLength(100);

			builder.HasOne(entity => entity.Cidade).WithOne().HasForeignKey<EmpresaPoco>(x => x.IdCidade);
			builder.HasOne(entity => entity.Estado).WithOne().HasForeignKey<EmpresaPoco>(x => x.IdEstado);
		}
	}
}
