using System;

namespace Tokyo_Tyrant_Console.Core
{
    public static class Extensions
    {
        public static string With(this string instance, params string[] formatArguments)
        {
            return String.Format(instance, formatArguments);
        }
    }
}
