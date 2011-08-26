using System.Collections.Generic;
using CommandLine;
using Ninject;
using Tokyo_Tyrant_Console.Commands;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;

namespace Tokyo_Tyrant_Console.Routing
{
    public interface IArgumentRouter
    {
        Route Route(string[] args);
    }

    public class ArgumentRouter : IArgumentRouter
    {
        private readonly List<Route> _routes = new List<Route>();

        [Inject]
        public IOutputReporter OutputReporter { get; set; }

        [Inject]
        public ConnectionPerRequestConnectionProvider ConnectionProvider { get; set; }

        public ArgumentRouter()
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            RegisterRoute(new HelpCommandOptions(), new HelpCommand(OutputReporter));
            RegisterRoute(new DeleteKeyCommandOptions(), new DeleteKeyTokyoTyrantCommand(ConnectionProvider, OutputReporter));
            RegisterRoute(new FindByKeyCommandOptions(), new GetKeyTokyoTyrantCommand(ConnectionProvider, OutputReporter));
            RegisterRoute(new UpdateKeyCommandOptions(), new UpdateKeyTokyoTyrantCommand(ConnectionProvider, OutputReporter));
            RegisterRoute(new FindByColumnsCommandOptions(), new FindByColumnsTokyoTyrantCommand(ConnectionProvider, OutputReporter));
        }

        private void RegisterRoute(CommandOptions options, ICommand commandHandler)
        {
            _routes.Add(new Route(options, commandHandler));
        }

        public Route Route(string[] args)
        {
            ICommandLineParser parser = new CommandLineParser();

            foreach (var routeHandler in _routes)
            {
                if (parser.ParseArguments(args, routeHandler.Options))
                {
                    return routeHandler;
                }
            }

            return null;
        }
    }
}