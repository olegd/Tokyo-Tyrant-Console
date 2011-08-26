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
            _outputReporter.Report("Find by key: ");    
            _outputReporter.Report("--findby-key keyValue");    
            _outputReporter.Report("");

            _outputReporter.Report("Find by columns: ");
            _outputReporter.Report("--findby-columns columnName1:columnValue1 [columnName2:columnValue2]");
            _outputReporter.Report("*Note: All column/value pairs must match in order for the key to be returned");
            _outputReporter.Report("*Column values are matched using exact string equality");
            _outputReporter.Report("");


            _outputReporter.Report("Delete Key: ");
            _outputReporter.Report("--delete-key keyValue");
            _outputReporter.Report("");

            _outputReporter.Report("Update Key: ");
            _outputReporter.Report("--update-key keyValue columnName1:columnValue1 [columnName2:columnValue2]");
            _outputReporter.Report("");    
        }
    }
}