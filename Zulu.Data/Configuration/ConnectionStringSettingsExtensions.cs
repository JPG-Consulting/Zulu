using System;
using System.Configuration;
using System.Data.Common;

namespace Zulu.Configuration
{
    public static class ConnectionStringSettingsExtensions
    {
        public static DbCommand CreateDbCommand(this ConnectionStringSettings connectionStringSettings)
        {
            if (connectionStringSettings == null)
                throw new ArgumentNullException("connectionStringSettings");

            DbConnection connection = connectionStringSettings.CreateDbConnection();
            DbCommand command = connection.CreateCommand();

            if (command.Connection == null)
            {
                command.Connection = connection;
            }

            return command;
        }

        public static DbConnection CreateDbConnection(this ConnectionStringSettings connectionStringSettings)
        {
            if (connectionStringSettings == null)
                throw new ArgumentNullException("connectionStringSettings");

            DbProviderFactory providerFactory = connectionStringSettings.GetDbProviderFactory();
            DbConnection connection = providerFactory.CreateConnection();

            // Establecemos la cadena de conexión.
#if NET35
            if ((connectionStringSettings.ConnectionString != null) && (connectionStringSettings.ConnectionString.Trim().Length > 0))
#else
            if (!String.IsNullOrWhitespace(connectionStringSettings.ConnectionString))
#endif
                connection.ConnectionString = connectionStringSettings.ConnectionString;

            return connection;
        }

        /// <summary>
        ///   Obtiene la factoría del proveedor de datos especificado en la cadena de conexión.
        /// </summary>
        /// <param name="connectionStringSettings">La configuración de la cadena de conexión.</param>
        /// <returns><see cref="DbProviderFactory"/> relacionado con la cadena de conexión.</returns>
        public static DbProviderFactory GetDbProviderFactory(this ConnectionStringSettings connectionStringSettings)
        {
            if (connectionStringSettings == null)
                throw new ArgumentNullException("connectionStringSettings");

            // ToDo: Validaciones
#if NET35
            if ((connectionStringSettings.ProviderName == null) || (connectionStringSettings.ProviderName.Trim().Length == 0))
#else
            if (String.IsNullOrWhitespace(connectionStringSettings.ProviderName))
#endif
                throw new ConfigurationErrorsException(
                    "",
                    connectionStringSettings.ElementInformation.Source,
                    connectionStringSettings.ElementInformation.LineNumber);

            if (DbProviderFactories.GetFactoryClasses().Rows.Find(connectionStringSettings.ProviderName) == null)
                throw new ConfigurationErrorsException(
                    "",
                    connectionStringSettings.ElementInformation.Source,
                    connectionStringSettings.ElementInformation.LineNumber);

            return DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
        }
    }
}
