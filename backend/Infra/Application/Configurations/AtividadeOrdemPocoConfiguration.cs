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
    public class AtividadeOrdemPocoConfiguration : IEntityTypeConfiguration<AtividadeOrdemPoco>
	{
		public void Configure(EntityTypeBuilder<AtividadeOrdemPoco> builder)
		{
			builder.ToTable("ordem_servico_atividade");

			builder.HasKey(entity => entity.IdAtividade);
			builder.Property(entity => entity.IdAtividade).ValueGeneratedOnAdd();
			builder.Property(entity => entity.IdOrdemServico).IsRequired();
			builder.Property(entity => entity.Obs).IsRequired(false);


			builder.HasOne(entity => entity.OrdemServico).WithOne(x => x.Atividade).HasForeignKey<AtividadeOrdemPoco>(x => x.IdOrdemServico);

		}
	}
}
