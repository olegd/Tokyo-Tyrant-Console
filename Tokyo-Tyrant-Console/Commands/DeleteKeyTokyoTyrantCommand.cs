using System;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;

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
            var deleteOptions = options as DeleteKeyCommandOptions;
            if (deleteOptions == null)
            {
                throw new ArgumentException("options must be of type DeleteCommandOptions and not null");
            }

            var connection = ConnectionProvider.GetConnection();
            connection.Delete(deleteOptions.Key);
        }
    }
}
