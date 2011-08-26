using System.Collections.Generic;
using CommandLine;

namespace Tokyo_Tyrant_Console.Routing
{
    public abstract class CommandOptions
    {
    }

    //--delete-key key
    public class DeleteKeyCommandOptions : CommandOptions
    {
        [Option(null, "delete-key", Required = true)]
        public string Key;
    }

    //--findby-key key
    public class FindByKeyCommandOptions : CommandOptions
    {
        [Option(null, "findby-key", Required = true)]
        public string Key;
    }

    //--update-key key column1:value1 [column2:value2]
    public class UpdateKeyCommandOptions : CommandOptions
    {
        [Option(null, "update-key", Required = true)]
        public string Key;

        [ValueList(typeof(List<string>))]
        public IList<string> ColumnValues;
    }

    public class HelpCommandOptions : CommandOptions
    {
        [Option("h", "help", Required = true)]
        public bool Command;
    }

    //--findby-columns column1:value1
    public class FindByColumnsCommandOptions : CommandOptions
    {
        [Option(null, "findby-columns", Required = true)]
        public bool CommandRouted;

        [ValueList(typeof(List<string>))]
        public IList<string> ColumnCriteria;
    }
}