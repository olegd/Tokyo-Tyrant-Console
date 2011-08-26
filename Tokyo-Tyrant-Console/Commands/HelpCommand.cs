// *******************************************************************************
// * Copyright (c) 1999 - 2011.
// * Global Relay Communications Inc.
// * All rights reserved.
// *******************************************************************************

using Tokyo_Tyrant_Console.Output;
using Tokyo_Tyrant_Console.Routing;

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
            _outputReporter.WriteLine("Get Key: ");    
            _outputReporter.WriteLine("--get-key keyValue");    
            _outputReporter.WriteLine("");

            _outputReporter.WriteLine("Delete Key: ");
            _outputReporter.WriteLine("--delete-key keyValue");
            _outputReporter.WriteLine("");

            _outputReporter.WriteLine("Update Key: ");
            _outputReporter.WriteLine("--update-key keyValue columnName1:columnValue1 [columnName2:columnValue2]");
            _outputReporter.WriteLine("");    
        }
    }
}