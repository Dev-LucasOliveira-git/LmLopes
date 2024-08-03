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
    public class EquipamentoPocoConfiguration : IEntityTypeConfiguration<EquipamentoPoco>
	{
		public void Configure(EntityTypeBuilder<EquipamentoPoco> builder)
		{
			builder.ToTable("ordem_servico_equipamento");

			builder.HasKey(entity => entity.IdEquipamento);
			builder.Property(entity => entity.IdEquipamento).ValueGeneratedOnAdd();

			builder.HasMany(entity => entity.OrdensServicos).WithOne();

		}
	}
}
