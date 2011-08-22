using System;

namespace Tokyo_Tyrant_Console.Output
{
    public class ConsoleOutputReporter : IOutputReporter
    {
        public void WriteLine(string data)
        {
            Console.WriteLine(data);
        }

        public void WriteLineFormat(string template, params object[] formatData)
        {
            Console.WriteLine(String.Format(template, formatData));
        }
    }
}