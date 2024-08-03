using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Domain.Authentication;
using Domain.Interfaces;
using Domain.Repositories;
using Infra;
using Infra.Application;
using Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddInfraDependency(this IServiceCollection services, DatabaseConfiguration configuration)
		{
			services.AddSingleton(configuration);
			services.AddDbContext<ApplicationContext>(options =>
													 options.UseMySql(configuration.ConnectionString,
																	  new MySqlServerVersion(new Version()),
																		mySqlOptions =>
																				mySqlOptions.MigrationsAssembly("Infra.MySql")));

			
			services.AddScoped<IAtividadeOrdemRepository, AtividadeOrdemRepository>();
			services.AddScoped<ICidadeRepository, CidadeRepository>();
			services.AddScoped<IClienteRepository, ClienteRepository>();
			services.AddScoped<IDefeitoOrdemRepository, DefeitoOrdemRepository>();
			services.AddScoped<IEmpresaRepository, EmpresaRepository>();
			services.AddScoped<IEngenheiroRepository, EngenheiroRepository>();
			services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
			services.AddScoped<IEstadoRepository, EstadoRepository>();
			services.AddScoped<IMaterialUtilizadoRepository, MaterialUtilizadoRepository>();
			services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
			services.AddScoped<IUsuarioRepository, UsuarioRepository>();

			ApplicationContext.SetConnection(configuration.ConnectionString);


			return services;

		}		
		
	}
}
