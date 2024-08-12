using Domain.Authentication;
using Infra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }
		public DatabaseConfiguration DatabaseConfiguration { get; set; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			DatabaseConfiguration = new DatabaseConfiguration(configuration);
		}

		public void ConfigureServices(IServiceCollection services) {

			services.Configure<KestrelServerOptions>(Configuration.GetSection("Kestrel"));
			services.AddApplicationDependency();
			services.AddInfraDependency(DatabaseConfiguration);
			services.AddAutoMapper(typeof(Startup));
			services.RegisterCorsPolicies();

		}

		public void ConfigureAuthentication(WebApplicationBuilder builder)
		{

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret));

			builder.Services.AddAuthentication(authOptions =>
			{
				authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

			}).AddJwtBearer("Bearer", options =>
			{
				options.RequireHttpsMetadata = false;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					ValidateLifetime = true,
					IssuerSigningKey = key,
					ValidateAudience = false,
					ValidateIssuer = false,
				};
			});
		}
	}
}
