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
    public class OrdemServicoSimplesConfiguration : IEntityTypeConfiguration<OrdemServicoSimplesPoco>
	{
		public void Configure(EntityTypeBuilder<OrdemServicoSimplesPoco> builder)
		{
			builder.ToTable("ordem_servico_simples");

			builder.HasKey(entity => entity.IdOrdem);
			builder.Property(entity => entity.IdOrdem).ValueGeneratedOnAdd();
			builder.Property(entity => entity.Numero).IsRequired();
			builder.Property(entity => entity.NumeroPrisma).IsRequired();
			builder.Property(entity => entity.ImgAssinatura).HasColumnType("LONGBLOB").IsRequired(false);

			builder.Property(entity => entity.IdUsuario).IsRequired();
			builder.Property(entity => entity.DataHora).IsRequired();

			builder.HasOne(entity => entity.Usuario).WithMany(x => x.OrdensServicosSimples).HasForeignKey(x => x.IdUsuario);
		}
	}
}
