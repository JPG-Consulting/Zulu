using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Zulu.Configuration
{
    public static class ConnectionStringSettingsExtensions
    {
        public static DbProviderFactory GetDbProviderFactory(this ConnectionStringSettings connectionStringSettings)
        {
            if (connectionStringSettings == null)
                throw new ArgumentNullException("connectionStringSettings");

            // ToDo: Validaciones

            return DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
        }

        public static DbConnection CreateConnection(this ConnectionStringSettings connectionStringSettings)
        {
            if (connectionStringSettings == null)
                throw new ArgumentNullException("connectionStringSettings");

            DbProviderFactory providerFactory = connectionStringSettings.GetDbProviderFactory();
            DbConnection connection = providerFactory.CreateConnection();


            connection.ConnectionString = connectionStringSettings.ConnectionString;

            return connection;
        }
    }
}
