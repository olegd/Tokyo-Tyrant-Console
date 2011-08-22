using TokyoTyrant.NET;

namespace Tokyo_Tyrant_Console.Connection
{
    public interface ITokyoTyrantConnectionProvider
    {
        ITokyoTyrantConnection GetConnection();
    }
}