using System.Collections.Generic;
using CommandLine;

namespace Tokyo_Tyrant_Console
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

    //--get-key key
    public class GetKeyCommandOptions : CommandOptions
    {
        [Option(null, "get-key", Required = true)]
        public string Key;
    }

    //--update-key key column1:value1 column2:value2
    public class UpdateKeyCommandOptions : CommandOptions
    {
        [Option(null, "update-key", Required = true)]
        public string Key;

        [ValueList(typeof(List<string>))]
        public IList<string> ColumnValues = null;
    }

    
    public class HelpCommandOptions : CommandOptions
    {
        [Option("h", "help", Required = true)]
        public bool Command;
    }

    public class FindByColumnsCommandOptions : CommandOptions
    {
//        [Option(null, "findby-columns", Required = true)]
//        public string Key;

        [Option(null, "findby-columns", Required = true)]
        [ValueList(typeof(List<string>))]
        public IList<string> ColumnCriteria = null;
    }
}