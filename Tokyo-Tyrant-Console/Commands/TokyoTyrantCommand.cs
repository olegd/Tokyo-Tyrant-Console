using System;
using TokyoTyrant.NET;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Core;
using Tokyo_Tyrant_Console.Output;
using Tokyo_Tyrant_Console.Routing;

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

        protected T TryConvertToSpecificOptions<T>(CommandOptions options) where T : class
        {
            var convertedOptions = options as T;
            if (convertedOptions == null)
            {
                string message = "Can't convert to type {0} or value is null".With(typeof (T).ToString());
                throw new ArgumentException(message, "options");
            }
            return convertedOptions;
        }
    }
}
