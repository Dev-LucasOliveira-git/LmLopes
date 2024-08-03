using Domain.Authentication;
using Domain.Authentication.Interface;
using Domain.Services;
using Domain.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace Domain.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddDomainDependency(this IServiceCollection services)
		{


			services.AddScoped<IEmpresaDomainService, EmpresaDomainService>();
			services.AddScoped<IEngenheiroDomainService, EngenheiroDomainService>();
			services.AddScoped<IEquipamentoDomainService, EquipamentoDomainService>();
			services.AddScoped<IUsuarioDomainService, UsuarioDomainService>();
			services.AddScoped<IOrdemServicoDomainService, OrdemServicoDomainService>();
			services.AddScoped<IClienteDomainService, ClienteDomainService>();
			services.AddScoped<ILoginDomainService, LoginDomainService>();
			services.AddScoped<ITokenDomainService, TokenDomainService>();
			services.AddScoped<ITokenGenerator, TokenGenerator>();


			services.AddHttpClient();
			services.AddHttpContextAccessor();

			return services;

		}

	}
}
