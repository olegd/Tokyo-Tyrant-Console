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

        public CommandRouter()
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            var outputReporter = new ConsoleOutputReporter();
            var connectionProvider = new ConnectionPerRequestConnectionProvider();

            _routes.Add(new HelpCommandOptions(), new HelpCommand(outputReporter));
            _routes.Add(new DeleteKeyCommandOptions(), new DeleteKeyTokyoTyrantCommand(connectionProvider, outputReporter));
            _routes.Add(new GetKeyCommandOptions(), new GetKeyTokyoTyrantCommand(connectionProvider, outputReporter));
            _routes.Add(new UpdateKeyCommandOptions(), new UpdateKeyTokyoTyrantCommand(connectionProvider, outputReporter));
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
        }
    }
}
