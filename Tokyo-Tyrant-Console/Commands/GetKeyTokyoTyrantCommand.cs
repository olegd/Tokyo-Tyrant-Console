using System.Collections.Generic;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;
using Tokyo_Tyrant_Console.Routing;

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

            OutputReporter.OutputColumns(result);
        }

        
    }
}