using Microsoft.EntityFrameworkCore;
using Infra.Application.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Application;
using Microsoft.Extensions.Configuration;

namespace Infra.Application
{
	public class ApplicationContext : DbContext
	{
		private static string connectionString;

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
		public ApplicationContext(string connectionString) : base(GetOptions(connectionString)) { }
		public ApplicationContext() { }

		public static ApplicationContext New() => new(connectionString);
		public static ApplicationContext New(string connectionString) => new(connectionString);
		private static DbContextOptions GetOptions(string connectionString)
		{
			return new DbContextOptionsBuilder().UseMySql(connectionString, new MySqlServerVersion(new Version())).Options;
		}
		public static void SetConnection(string connectionString) => ApplicationContext.connectionString = connectionString;

		public DbSet<AtividadeOrdemPoco> AtividadeOrdemPoco { get; set; }
		public DbSet<CidadePoco> CidadePoco { get; set; }
		public DbSet<ClientePoco> ClientePoco { get; set; }
		public DbSet<DefeitoOrdemPoco> DefeitoOrdemPoco { get; set; }
		public DbSet<EmpresaPoco> EmpresaPoco { get; set; }
		public DbSet<EngenheiroPoco> EngenheiroPoco { get; set; }
		public DbSet<EquipamentoPoco> EquipamentoPoco { get; set; }
		public DbSet<EstadoPoco> EstadoPoco { get; set; }
		public DbSet<MaterialUtilizadoPoco> MaterialUtilizadoPoco { get; set; }
		public DbSet<OrdemServicoPoco> OrdemServicoPoco { get; set; }
		public DbSet<OrdemServicoSimplesPoco> OrdemServicoSimplesPoco { get; set; }

		public DbSet<UsuarioPoco> UsuarioPoco { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.EnableDetailedErrors(true);
			optionsBuilder.EnableSensitiveDataLogging(true);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new AtividadeOrdemPocoConfiguration());
			modelBuilder.ApplyConfiguration(new CidadePocoConfiguration());
			modelBuilder.ApplyConfiguration(new ClientePocoConfiguration());
			modelBuilder.ApplyConfiguration(new DefeitoOrdemPocoConfiguration());
			modelBuilder.ApplyConfiguration(new EmpresaPocoConfiguration());
			modelBuilder.ApplyConfiguration(new EngenheiroPocoConfiguration());
			modelBuilder.ApplyConfiguration(new EquipamentoPocoConfiguration());
			modelBuilder.ApplyConfiguration(new EstadoPocoConfiguration());
			modelBuilder.ApplyConfiguration(new MaterialUtilizadoPocoConfiguration());
			modelBuilder.ApplyConfiguration(new OrdemServicoConfiguration());
			modelBuilder.ApplyConfiguration(new OrdemServicoSimplesConfiguration());
			modelBuilder.ApplyConfiguration(new UsuarioPocoConfiguration());
		}

		protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
		{
			configurationBuilder.Properties<decimal>()
				.HavePrecision(11,2);

			configurationBuilder.DefaultTypeMapping<decimal>().HasPrecision(11,2);
		}

	}
}