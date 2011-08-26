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
            _outputReporter.Report("--findby-key keyValue");
            _outputReporter.Report("Returns all columns for a given key.");
            _outputReporter.Report("");

            _outputReporter.Report("--findby-columns columnName1:columnValue1 [columnName2:columnValue2]");
            _outputReporter.Report("Returns all keys and columns that have columns with values that match exactly to columnValue AND columnValue2");
            _outputReporter.Report("");

            _outputReporter.Report("--delete-key keyValue");
            _outputReporter.Report("Deletes a key and all columns assosiated with it.");
            _outputReporter.Report("");

            _outputReporter.Report("--update-key keyValue columnName1:columnValue1 [columnName2:columnValue2]");
            _outputReporter.Report("Updates column valus for a given key. If column does not exist it is created. If column already has data, it is overwritten.");
            _outputReporter.Report("");
        }
    }
}