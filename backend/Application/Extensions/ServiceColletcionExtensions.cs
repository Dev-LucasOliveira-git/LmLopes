using AutoMapper;
using Application.Services;
using Application.Services.Interfaces;
using Dto.Mappings;
using Domain.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddApplicationDependency(this IServiceCollection services)
		{

			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new DomainToDTOMapping());
				mc.AddProfile(new DTOToDomainMapping());
				mc.DisableConstructorMapping();
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);

			services.AddDomainDependency();

			services.AddScoped<IEmpresaService, EmpresaService>();
			services.AddScoped<IEngenheiroService, EngenheiroService>();
			services.AddScoped<IEquipamentoService, EquipamentoService>();
			services.AddScoped<IUsuarioService, UsuarioService>();
			services.AddScoped<IOrdemServicoService, OrdemServicoService>();
			services.AddScoped<IClienteService, ClienteService>();
			services.AddScoped<ILoginService, LoginService>();


			return services;

		}

		public static IServiceCollection RegisterCorsPolicies(this IServiceCollection services)
		{
			string[] localHostOrigins = new string[] {
		"http://localhost:4200"};

			string[] productionHostOrigins = new string[] {
		"http://localhost:4200","http://lmlopesordermanager.online"};

			services.AddCors(options =>    // CORS middleware must precede any defined endpoints
			{
				options.AddPolicy("DevelopmentCorsPolicy", builder =>
				{
					builder.WithOrigins(localHostOrigins)
							.AllowAnyHeader().AllowAnyMethod();
				});

				options.AddPolicy("ProductionCorsPolicy", builder =>
				{
					builder.WithOrigins(productionHostOrigins)
							.AllowAnyHeader().AllowAnyMethod().AllowCredentials();
				});
			});

			return services;

		}

	}
}
