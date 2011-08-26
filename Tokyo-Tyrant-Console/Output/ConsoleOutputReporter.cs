using System;
using System.Collections.Generic;

namespace Tokyo_Tyrant_Console.Output
{
    public class ConsoleOutputReporter : IOutputReporter
    {
        public void Report(string data)
        {
            Console.WriteLine(data);
        }

        public void ReportFormat(string template, params object[] formatData)
        {
            Console.WriteLine(String.Format(template, formatData));
        }

        public void OutputColumns(IDictionary<string, IDictionary<string, string>> result)
        {
            ReportFormat("{0} record(s) found", result.Keys.Count);

            foreach (var key in result)
            {
                this.ReportFormat("Key: {0}", key.Key);
                foreach (var column in key.Value)
                {
                    this.ReportFormat("{0} - {1}", column.Key, column.Value);
                }
            }

            Report("------------------------------------------");
        }
    }
}