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
    public class OrdemServicoConfiguration : IEntityTypeConfiguration<OrdemServicoPoco>
	{
		public void Configure(EntityTypeBuilder<OrdemServicoPoco> builder)
		{
			builder.ToTable("ordem_servico");

			builder.HasKey(entity => entity.IdOrdem);
			builder.Property(entity => entity.IdOrdem).ValueGeneratedOnAdd();
			builder.Property(entity => entity.Numero).IsRequired();
			builder.Property(entity => entity.NumeroPrisma).IsRequired();

			builder.Property(entity => entity.IdUsuario).IsRequired();
			builder.Property(entity => entity.DataHora).IsRequired();

			builder.HasOne(entity => entity.Usuario).WithMany(x => x.OrdensServicos).HasForeignKey(x => x.IdUsuario);
			builder.HasOne(entity => entity.Cliente).WithMany(x => x.OrdensServicos).HasForeignKey(x => x.IdCliente);
			builder.HasOne(entity => entity.Engenheiro).WithMany(x => x.OrdensServicos).HasForeignKey(x => x.IdEngenheiro);
			builder.HasOne(entity => entity.Equipamento).WithMany(x => x.OrdensServicos).HasForeignKey(x => x.idEquipamento);

		}
	}
}
