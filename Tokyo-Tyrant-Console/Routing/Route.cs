using Tokyo_Tyrant_Console.Commands;

namespace Tokyo_Tyrant_Console.Routing
{
    public class Route
    {
        public CommandOptions Options { get; set; }
        public ICommand Handler { get; set; }

        public Route(CommandOptions options, ICommand handler)
        {
            Options = options;
            Handler = handler;
        }

        public void Handle()
        {
            Handler.Invoke(Options);
        }
    }
}