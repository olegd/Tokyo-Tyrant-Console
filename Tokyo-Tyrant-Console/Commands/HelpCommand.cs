// *******************************************************************************
// * Copyright (c) 1999 - 2011.
// * Global Relay Communications Inc.
// * All rights reserved.
// *******************************************************************************

using Tokyo_Tyrant_Console.Output;

namespace Tokyo_Tyrant_Console.Commands
{
    public class HelpCommand : ICommand
    {
        private readonly IOutputReporter _outputReporter;

        public HelpCommand(IOutputReporter outputReporter)
        {
            _outputReporter = outputReporter;
        }

        public void Invoke(CommandOptions options)
        {
            _outputReporter.WriteLine("help is here");    
        }
    }
}