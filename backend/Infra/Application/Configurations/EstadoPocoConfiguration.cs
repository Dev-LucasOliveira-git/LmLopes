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
	public class EstadoPocoConfiguration : IEntityTypeConfiguration<EstadoPoco>
	{
		public void Configure(EntityTypeBuilder<EstadoPoco> builder)
		{
			builder.ToTable("estado");

			builder.HasKey(entity => entity.IdEstado);
			builder.Property(entity => entity.IdEstado).ValueGeneratedOnAdd();
			builder.Property(entity => entity.Nome).IsRequired().HasMaxLength(100);
			builder.Property(entity => entity.UF).IsRequired();
		}
	}
}
