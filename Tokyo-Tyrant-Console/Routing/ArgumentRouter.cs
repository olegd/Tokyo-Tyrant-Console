// *******************************************************************************
// * Copyright (c) 1999 - 2011.
// * Global Relay Communications Inc.
// * All rights reserved.
// *******************************************************************************

using System.Collections.Generic;
using CommandLine;
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

        private readonly IOutputReporter _outputReporter;
        private readonly ConnectionPerRequestConnectionProvider _connectionProvider;

        public ArgumentRouter(IOutputReporter outputReporter, ConnectionPerRequestConnectionProvider connectionProvider)
        {
            _outputReporter = outputReporter;
            _connectionProvider = connectionProvider;
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            RegisterRoute(new HelpCommandOptions(), new HelpCommand(_outputReporter));
            RegisterRoute(new DeleteKeyCommandOptions(), new DeleteKeyTokyoTyrantCommand(_connectionProvider, _outputReporter));
            RegisterRoute(new FindByKeyCommandOptions(), new GetKeyTokyoTyrantCommand(_connectionProvider, _outputReporter));
            RegisterRoute(new UpdateKeyCommandOptions(), new UpdateKeyTokyoTyrantCommand(_connectionProvider, _outputReporter));
            RegisterRoute(new FindByColumnsCommandOptions(), new FindByColumnsTokyoTyrantCommand(_connectionProvider, _outputReporter));
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