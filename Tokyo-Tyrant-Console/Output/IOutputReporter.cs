using System.Collections.Generic;

namespace Tokyo_Tyrant_Console.Output
{
    public interface IOutputReporter
    {
        void WriteLine(string data);
        void WriteLineFormat(string template, params object[] formatData);
        void OutputColumns(IDictionary<string, IDictionary<string, string>> result);
    }
}