using System;
using System.Collections.Generic;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;
using System.Linq;

namespace Tokyo_Tyrant_Console.Commands
{
    public class UpdateKeyTokyoTyrantCommand : TokyoTyrantCommand
    {
        public UpdateKeyTokyoTyrantCommand(ITokyoTyrantConnectionProvider connectionProvider, IOutputReporter outputReporter) 
            : base(connectionProvider, outputReporter)
        {
        }

        public override void Invoke(CommandOptions options)
        {
            var updateOptions = options as UpdateKeyCommandOptions;
            if (updateOptions == null)
            {
                throw new AggregateException("options must be of type UpdateKeyCommandOptions");
            }

            var parsedColumnValues = ParseColumnData(updateOptions);

            using (var conn = ConnectionProvider.GetConnection())
            {
                IDictionary<string, IDictionary<string, string>> keysColumns = conn.GetColumns(new[] {updateOptions.Key});
                foreach (var keyColumns in keysColumns)
                {
                    MergeInto(keyColumns.Value, parsedColumnValues);
                    conn.PutColumns(updateOptions.Key, keyColumns.Value, true);
                }
            }
        }

        private static void MergeInto(IDictionary<string, string> mergeDestination, 
            IDictionary<string, string> mergeSource)
        {
            foreach (var parsedColumn in mergeSource)
            {
                mergeDestination[parsedColumn.Key] = parsedColumn.Value;
            }
        }

        private IDictionary<string, string> ParseColumnData(UpdateKeyCommandOptions options)
        {
            var result = new Dictionary<string, string>();
            foreach(var columnValue in options.ColumnValues)
            {
                if (!IsValid(columnValue))
                {
                    ThrowNotValidFormat(columnValue);
                }

                var splittedData = columnValue.Split(':');
                if (splittedData.Count() != 2)
                {
                    ThrowNotValidFormat(columnValue);
                }

                result[splittedData[0]] = splittedData[1];
            }
            return result;
        }

        private static void ThrowNotValidFormat(string columnValue)
        {
            throw new ArgumentException(columnValue + "is not in a valid format");
        }

        private bool IsValid(string columnValue)
        {
            if (columnValue.Contains(":"))
            {
                return true;
            }
            return false;
        }
    }
}