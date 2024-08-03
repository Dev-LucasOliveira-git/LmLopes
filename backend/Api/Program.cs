using Microsoft.OpenApi.Models;
using Api;
using Application.CustomMiddlewares;
using Serilog;
using Infra.Application;
using Microsoft.EntityFrameworkCore;

try
{
	
	var builder = WebApplication.CreateBuilder(args);
	SerilogExtension.AddSerilogApi(builder.Configuration);
	builder.Host.UseSerilog(Log.Logger);


	builder.Services.AddControllers();

	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen(i =>
	{

		i.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
		{
			Title = "Api",
			Version = "v1",
		}
		);
		i.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
		{
			Description = @"Autenticação em JWT. \n
                Ex: Bearer {token}",
			Name = "Authorization",
			In = Microsoft.OpenApi.Models.ParameterLocation.Header,
			Scheme = "Bearer",
		});
		i.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
		{
		{
		new OpenApiSecurityScheme
		{
			Reference = new OpenApiReference
			{
				Type = ReferenceType.SecurityScheme,
				Id = "Bearer"
			},
			Scheme = "oauth",
			Name = "Bearer",
			In = ParameterLocation.Header,
		},
		new List<string>()
		}
		});
	});
	// Add services to the container.

	var startup = new Startup(builder.Configuration);
	startup.ConfigureServices(builder.Services);

	// Configure the HTTP request pipeline.
	startup.ConfigureAuthentication(builder);


	var app = builder.Build();

	app.UseSwagger();

	app.UseSwaggerUI(c =>
	{
		string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
		c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", " API v1");

	});

	app.UseHttpsRedirection();

	app.UseAuthentication();
	app.UseAuthorization();
	app.MapControllers();
	app.UseSwaggerUI();

	app.UseCors(x => { x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
	app.UseMiddleware<ExceptionHandlingMiddleware>();

	using var scope = app.Services.CreateScope();
	await using var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
	await dbContext.Database.MigrateAsync(CancellationToken.None);

	app.Run();
}
catch (Exception ex)
{
	Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
	Log.Information("Server Shutting down...");
	Log.CloseAndFlush();
}