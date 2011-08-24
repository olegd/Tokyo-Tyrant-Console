using System;
using System.Configuration;
using TokyoTyrant.NET;

namespace Tokyo_Tyrant_Console.Connection
{
    public class ConnectionPerRequestConnectionProvider : ITokyoTyrantConnectionProvider
    {
        public ITokyoTyrantConnection GetConnection()
        {
            var server = GetServer();
            var port = GetPort();

            var connection = new TokyoTyrantConnection();
            connection.Connect(server, port);
            return connection;
        }

        private string GetServer()
        {
            return GetConfigStringOrThrowException("TTHost");
        }
        
        private int GetPort()
        {
            var portString = GetConfigStringOrThrowException("TTPort");
            return Int32.Parse(portString);
        }

        private string GetConfigStringOrThrowException(string configParameterName)
        {
            string value = ConfigurationManager.AppSettings[configParameterName];
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ConfigurationErrorsException(
                    @"Configuration parameter: {0} is not set. 
                      Edit .config file to provide it".With(configParameterName));
            }
            return null;
        }
    }
}