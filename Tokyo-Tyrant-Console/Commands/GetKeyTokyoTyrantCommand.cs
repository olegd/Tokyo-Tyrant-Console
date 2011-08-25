using System.Collections.Generic;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;

namespace Tokyo_Tyrant_Console.Commands
{
    public class GetKeyTokyoTyrantCommand : TokyoTyrantCommand
    {
        public GetKeyTokyoTyrantCommand(ITokyoTyrantConnectionProvider connectionProvider, IOutputReporter outputReporter) 
            : base(connectionProvider, outputReporter)
        {
        }

        public override void Invoke(CommandOptions options)
        {
            var getKeyCommandOptions = TryConvertToSpecificOptions<GetKeyCommandOptions>(options);
            
            IDictionary<string, IDictionary<string, string>> result;
            using (var conn  = ConnectionProvider.GetConnection())
            {
               result = conn.GetColumns(new[] {getKeyCommandOptions.Key});
            }

            OutputData(result);
        }

        private void OutputData(IDictionary<string, IDictionary<string, string>> result)
        {
            OutputReporter.WriteLineFormat("Found {0} matching key(s)", result.Keys.Count);

            foreach (var key in result)
            {
                OutputReporter.WriteLineFormat("Key: {0}", key.Key);
                foreach (var column in key.Value)
                {
                    OutputReporter.WriteLineFormat("{0} - {1}", column.Key, column.Value);
                }
            }
        }
    }
}