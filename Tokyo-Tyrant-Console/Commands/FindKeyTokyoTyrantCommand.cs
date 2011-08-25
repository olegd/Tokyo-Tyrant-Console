using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;

namespace Tokyo_Tyrant_Console.Commands
{
    public class FindKeyTokyoTyrantCommand : TokyoTyrantCommand
    {
        public FindKeyTokyoTyrantCommand(ITokyoTyrantConnectionProvider connectionProvider, IOutputReporter outputReporter) 
            : base(connectionProvider, outputReporter)
        {
        }

        public override void Invoke(CommandOptions options)
        {
            var findOptions = TryConvertToSpecificOptions<FindKeyCommandOptions>(options);
        }
    }
}