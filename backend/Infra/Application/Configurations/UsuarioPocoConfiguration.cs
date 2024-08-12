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
    public class UsuarioPocoConfiguration : IEntityTypeConfiguration<UsuarioPoco>
	{
		public void Configure(EntityTypeBuilder<UsuarioPoco> builder)
		{
			builder.ToTable("usuario");

			builder.HasKey(entity => entity.IdUsuario);
			builder.Property(entity => entity.IdUsuario).ValueGeneratedOnAdd();
			builder.Property(entity => entity.Nome).IsRequired().HasMaxLength(60);
			builder.Property(entity => entity.Email).IsRequired().HasMaxLength(100);
			builder.Property(entity => entity.Senha).IsRequired();
			builder.Property(entity => entity.DataHoraCadastro).IsRequired().HasDefaultValueSql("now()");
			builder.Property(entity => entity.DataHoraUltimaAlteracao).HasDefaultValueSql("now()");


			builder.HasOne(entity => entity.UsuarioCadastro).WithMany().HasForeignKey(x => x.IdUsuarioCadastro);
			builder.HasOne(entity => entity.UsuarioUltimaAlteracao).WithMany().HasForeignKey(x => x.IdUsuarioUltimaAlteracao);
		}
	}
}
