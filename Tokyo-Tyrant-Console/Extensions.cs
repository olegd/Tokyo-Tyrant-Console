using System;

namespace Tokyo_Tyrant_Console
{
    public static class Extensions
    {
        public static string With(this string instance, params string[] formatArguments)
        {
            return String.Format(instance, formatArguments);
        }
    }
}
