using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infra.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infra
{
	public class DatabaseConfiguration
	{
		public DatabaseConfiguration(IConfiguration configuration)
		{
			ConnectionStringName = configuration["DefaultConnectionString"];

			ConnectionString = configuration[$"ConnectionStrings:{ConnectionStringName}"];
		}

		public string ConnectionStringName { get; }
		public string ConnectionString { get; }
	}
}
