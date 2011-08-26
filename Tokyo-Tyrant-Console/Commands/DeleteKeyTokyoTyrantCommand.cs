using System;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;
using Tokyo_Tyrant_Console.Routing;

namespace Tokyo_Tyrant_Console.Commands
{
    public class DeleteKeyTokyoTyrantCommand : TokyoTyrantCommand
    {
        public DeleteKeyTokyoTyrantCommand(ITokyoTyrantConnectionProvider connectionProvider, IOutputReporter outputReporter) 
            : base(connectionProvider, outputReporter)
        {
        }

        public override void Invoke(CommandOptions options)
        {
            var deleteOptions = TryConvertToSpecificOptions<DeleteKeyCommandOptions>(options);
            var connection = ConnectionProvider.GetConnection();
            connection.Delete(deleteOptions.Key);
        }
    }
}
