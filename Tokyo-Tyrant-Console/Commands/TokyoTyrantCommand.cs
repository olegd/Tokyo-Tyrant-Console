using TokyoTyrant.NET;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;

namespace Tokyo_Tyrant_Console.Commands
{
    public abstract class TokyoTyrantCommand : ICommand
    {
        protected readonly ITokyoTyrantConnectionProvider ConnectionProvider;
        protected readonly IOutputReporter OutputReporter;

        protected TokyoTyrantCommand(ITokyoTyrantConnectionProvider connectionProvider, IOutputReporter outputReporter)
        {
            OutputReporter = outputReporter;
            ConnectionProvider = connectionProvider;
        }

        protected ITokyoTyrantConnection GetConnection()
        {
            return null;
        }

        public abstract void Invoke(CommandOptions options);
    }
}
