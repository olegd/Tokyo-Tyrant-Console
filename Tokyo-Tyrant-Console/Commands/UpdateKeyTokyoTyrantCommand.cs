using System.Collections.Generic;
using System.Linq;
using TokyoTyrant.NET;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;
using Tokyo_Tyrant_Console.Routing;

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
            var updateOptions = TryConvertToSpecificOptions<UpdateKeyCommandOptions>(options);
            
            IDictionary<string, string> parsedColumnValues = ParseColumnData(updateOptions);

            using (var conn = ConnectionProvider.GetConnection())
            {
                IDictionary<string, IDictionary<string, string>> keysColumns = conn.GetColumns(new[] {updateOptions.Key});
                if (keysColumns.Any())
                {
                    UpdateExistingColumns(parsedColumnValues, conn, updateOptions, keysColumns);    
                }
                else
                {
                    conn.PutColumns(updateOptions.Key, parsedColumnValues, true);
                }
            }
        }

        private void UpdateExistingColumns(IDictionary<string, string> parsedColumnValues, ITokyoTyrantConnection conn,
                                           UpdateKeyCommandOptions updateOptions, IDictionary<string, IDictionary<string, string>> keysColumns)
        {
            foreach (var keyColumns in keysColumns)
            {
                var mergedColumns = MergeInto(keyColumns.Value, parsedColumnValues);
                conn.PutColumns(updateOptions.Key, mergedColumns, true);
            }
        }

        private IDictionary<string, string> MergeInto(IDictionary<string, string> mergeDestination, 
            IDictionary<string, string> mergeSource)
        {
            foreach (var parsedColumn in mergeSource)
            {
                mergeDestination[parsedColumn.Key] = parsedColumn.Value;
            }
            return mergeDestination;
        }

        private IDictionary<string, string> ParseColumnData(UpdateKeyCommandOptions options)
        {
            var columnPariParser = new ColumnPairParser();
            return columnPariParser.ParseColumns(options.ColumnValues);
        }
     }
}