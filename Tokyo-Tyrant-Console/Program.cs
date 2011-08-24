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
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);

                Console.WriteLine();
                router.RouteArguments(new[] {"--help"});
            }
        }
    }
}
