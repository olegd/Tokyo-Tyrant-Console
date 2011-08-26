using System;
using System.Collections.Generic;

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

        public void OutputColumns(IDictionary<string, IDictionary<string, string>> result)
        {
            WriteLineFormat("Found {0} matching key(s)", result.Keys.Count);

            foreach (var key in result)
            {
                this.WriteLineFormat("Key: {0}", key.Key);
                foreach (var column in key.Value)
                {
                    this.WriteLineFormat("{0} - {1}", column.Key, column.Value);
                }
            }
        }
    }
}