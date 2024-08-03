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
    public class EngenheiroPocoConfiguration : IEntityTypeConfiguration<EngenheiroPoco>
	{
		public void Configure(EntityTypeBuilder<EngenheiroPoco> builder)
		{
			builder.ToTable("engenheiro");

			builder.HasKey(entity => entity.IdEngenheiro);
			builder.Property(entity => entity.IdEngenheiro).ValueGeneratedOnAdd();
			builder.Property(entity => entity.RG).IsRequired(false).HasMaxLength(14);
			builder.Property(entity => entity.CREA).IsRequired(false).HasMaxLength(14);

			builder.HasMany(entity => entity.OrdensServicos).WithOne();


		}
	}
}
