using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Extensions
{
	public static class ILoggerExtensions
	{


		private static readonly Action<ILogger, Type, Exception> _migrationError =
			LoggerMessage.Define<Type>(LogLevel.Error, 3, "{type} threw an exception while executing migrations");


		private static readonly Action<ILogger, Exception> _applicationMigrated =
			LoggerMessage.Define(LogLevel.Information, 8, "All application migrations were successfully executed");

		private static readonly Action<ILogger, Exception> _migratingApplication =
			LoggerMessage.Define(LogLevel.Information, 9, "Starting application migrations");

		public static void MigrationError(this ILogger logger, Type contextType, Exception exception)
		{
			_migrationError(logger, contextType, exception);
		}

		public static void ApplicationMigrated(this ILogger logger)
		{
			_applicationMigrated(logger, null);
		}

		public static void MigratingApplication(this ILogger logger)
		{
			_migratingApplication(logger, null);
		}
	}
}
