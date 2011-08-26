using Tokyo_Tyrant_Console.Routing;

namespace Tokyo_Tyrant_Console.Commands
{
    public interface ICommand
    {
        void Invoke(CommandOptions options);
    }
}