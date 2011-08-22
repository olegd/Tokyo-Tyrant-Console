using System;

namespace Tokyo_Tyrant_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var router = new CommandRouter();
            try
            {
                router.RouteArguments(args);    
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An error occurred. Make sure the command is formed correctly");

                router.RouteArguments(new[] {"--help"});
            }
        }
    }
}
