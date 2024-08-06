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
    public class MaterialUtilizadoPocoConfiguration : IEntityTypeConfiguration<MaterialUtilizadoPoco>
	{
		public void Configure(EntityTypeBuilder<MaterialUtilizadoPoco> builder)
		{
			builder.ToTable("ordem_servico_material_utilizado");

			builder.HasKey(entity => entity.IdMaterialUtilizado);
			builder.Property(entity => entity.IdMaterialUtilizado).ValueGeneratedOnAdd();
			builder.Property(entity => entity.Quantidade).IsRequired();
			builder.Property(entity => entity.Descricao).IsRequired();

			builder.HasOne(entity => entity.OrdemServico).WithMany(x => x.MateriaisUtilizados).HasForeignKey(x => x.IdOrdemServico);
			builder.HasOne(entity => entity.OrdemServicoSimples).WithMany(x => x.MateriaisUtilizados).HasForeignKey(x => x.IdOrdemServicoSimples);

		}
	}
}
