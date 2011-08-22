using System;
using System.Configuration;
using TokyoTyrant.NET;

namespace Tokyo_Tyrant_Console.Connection
{
    public class ConnectionPerRequestConnectionProvider : ITokyoTyrantConnectionProvider
    {
        public ITokyoTyrantConnection GetConnection()
        {
            var connection = new TokyoTyrantConnection();
            var server = GetServer();
            var port = GetPort();
            connection.Connect(server, port);
            return connection;
        }

        private string GetServer()
        {
            return ConfigurationManager.AppSettings["TTHost"];
        }

        private int GetPort()
        {
            var portString = ConfigurationManager.AppSettings["TTPort"];
            return Int32.Parse(portString);
        }

        
    }
}