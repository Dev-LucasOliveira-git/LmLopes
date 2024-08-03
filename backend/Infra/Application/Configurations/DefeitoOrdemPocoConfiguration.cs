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
    public class DefeitoOrdemPocoConfiguration : IEntityTypeConfiguration<DefeitoOrdemPoco>
	{
		public void Configure(EntityTypeBuilder<DefeitoOrdemPoco> builder)
		{
			builder.ToTable("ordem_servico_defeito");

			builder.HasKey(entity => entity.IdDefeito);
			builder.Property(entity => entity.IdDefeito).ValueGeneratedOnAdd();
			builder.Property(entity => entity.IdOrdemServico).IsRequired();

			builder.HasOne(entity => entity.OrdemServico).WithOne(x => x.Defeito).HasForeignKey<DefeitoOrdemPoco>(x => x.IdOrdemServico);

		}
	}
}
