using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;

namespace Tokyo_Tyrant_Console.Routing
{
    public class CommandRouter
    {
        private readonly IOutputReporter _outputReporter;
        private readonly ConnectionPerRequestConnectionProvider _connectionProvider;

        public CommandRouter(IOutputReporter outputReporter, ConnectionPerRequestConnectionProvider connectionProvider)
        {
            _outputReporter = outputReporter;
            _connectionProvider = connectionProvider;
        }

        public void RouteArguments(string[] args)
        {
            var routeHandlers = new ArgumentRouter(_outputReporter, _connectionProvider);
            var handler = routeHandlers.Route(args);
            if (handler == null)
            {
                _outputReporter.Report("Unknown command. Run --help for available options");
                return;
            }
            handler.Handle();
        }
    }
}
