﻿using System;
using Tokyo_Tyrant_Console.Routing;

namespace Tokyo_Tyrant_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            NinjectConfig.Init();
            
            var router = NinjectConfig.Get<CommandRouter>();

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
