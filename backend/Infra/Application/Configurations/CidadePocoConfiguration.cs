using Entities.Application;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Application.Configurations
{
	public class CidadePocoConfiguration : IEntityTypeConfiguration<CidadePoco>
	{
		public void Configure(EntityTypeBuilder<CidadePoco> builder)
		{
			builder.ToTable("cidade");

			builder.HasKey(entity => entity.IdCidade);
			builder.Property(entity => entity.IdCidade).ValueGeneratedOnAdd();
			builder.Property(entity => entity.Nome).IsRequired().HasMaxLength(100);
			builder.Property(entity => entity.IdEstado).IsRequired();

			builder.HasOne(entity => entity.Estado).WithMany().HasForeignKey(entity => entity.IdEstado);

		}
	}
}
