using System.Collections.Generic;
using CommandLine;
using Tokyo_Tyrant_Console.Commands;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;

namespace Tokyo_Tyrant_Console
{
    public class CommandRouter
    {
        private readonly IDictionary<CommandOptions, ICommand> _routes 
            = new Dictionary<CommandOptions, ICommand>();

        private readonly IOutputReporter _outputReporter;
        private readonly ConnectionPerRequestConnectionProvider _connectionProvider;

        public CommandRouter()
        {
            _outputReporter = new ConsoleOutputReporter();
            _connectionProvider = new ConnectionPerRequestConnectionProvider();

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            _routes.Add(new HelpCommandOptions(), new HelpCommand(_outputReporter));
            _routes.Add(new DeleteKeyCommandOptions(), new DeleteKeyTokyoTyrantCommand(_connectionProvider, _outputReporter));
            _routes.Add(new GetKeyCommandOptions(), new GetKeyTokyoTyrantCommand(_connectionProvider, _outputReporter));
            _routes.Add(new UpdateKeyCommandOptions(), new UpdateKeyTokyoTyrantCommand(_connectionProvider, _outputReporter));
        }

        public void RouteArguments(string[] args)
        {
            ICommandLineParser parser = new CommandLineParser();

            foreach (var action in _routes)
            {
                if (parser.ParseArguments(args, action.Key))
                {
                    action.Value.Invoke(action.Key);
                    return;
                }
            }

            _outputReporter.WriteLine("Unknown command. Run --help for available options");
        }
    }
}
