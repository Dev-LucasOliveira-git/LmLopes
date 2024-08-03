using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microsoft.EntityFrameworkCore
{
	public static class DatabaseFacadeExtensions
	{
		public static Task MigrateAsync(this DatabaseFacade database, string? targetMigration = null, CancellationToken cancellationToken = default)
		{
			var migrator = (database as IInfrastructure<IServiceProvider>).GetService<IMigrator>();

			return migrator.MigrateAsync(targetMigration, cancellationToken);
		}
	}
}
