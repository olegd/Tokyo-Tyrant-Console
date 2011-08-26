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

        private void ReportFormat(ConsoleColor color, string template, params object[] formatData)
        {
            Console.ForegroundColor = color;
            ReportFormat(template, formatData);
            Console.ResetColor();
        }

        private void ReportInline(ConsoleColor color, string format, params object[] data)
        {
            Console.ForegroundColor = color;
            Console.Write(String.Format(format, data));
            Console.ResetColor();
        }

        private void LineBreak()
        {
            Console.WriteLine();
        }

        public void OutputColumns(IDictionary<string, IDictionary<string, string>> result)
        {
            ReportFormat("{0} record(s) found", result.Keys.Count);
            LineBreak();

            foreach (var key in result)
            {
                ReportFormat(ConsoleColor.DarkGreen, "Key: {0}", key.Key);
                foreach (var column in key.Value)
                {
                    ReportInline(ConsoleColor.DarkYellow, "     {0}", column.Key);
                    ReportInline(ConsoleColor.White, " : {0}", column.Value);
                    LineBreak();
                }
                LineBreak();
            }
        }
    }
}