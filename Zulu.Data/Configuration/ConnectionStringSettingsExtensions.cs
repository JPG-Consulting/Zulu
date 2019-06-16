using System;
using System.Configuration;
using System.Data.Common;

namespace Zulu.Configuration
{
    public static class ConnectionStringSettingsExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStringSettings"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionStringSettings"></param>
        /// <returns></returns>
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

            // Comprobar que se ha especificado el nombre del proveedor de datos.
#if NET35
            if ((connectionStringSettings.ProviderName == null) || (connectionStringSettings.ProviderName.Trim().Length == 0))
#else
            if (String.IsNullOrWhitespace(connectionStringSettings.ProviderName))
#endif
                throw new ConfigurationErrorsException(
                    "",
                    connectionStringSettings.ElementInformation.Source,
                    connectionStringSettings.ElementInformation.LineNumber);

            // Comprobar que el nombre del proveedor de datos es válido.
            if (DbProviderFactories.GetFactoryClasses().Rows.Find(connectionStringSettings.ProviderName) == null)
                throw new ConfigurationErrorsException(
                    "",
                    connectionStringSettings.ElementInformation.Source,
                    connectionStringSettings.ElementInformation.LineNumber);

            // Obtenemos y devolvemos la factoría para el proveedor de datos.
            return DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
        }
    }
}
