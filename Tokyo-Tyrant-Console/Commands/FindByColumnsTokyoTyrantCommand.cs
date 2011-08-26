using System.Collections.Generic;
using TokyoTyrant.NET;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Core;
using Tokyo_Tyrant_Console.Output;
using Tokyo_Tyrant_Console.Routing;

namespace Tokyo_Tyrant_Console.Commands
{
    public class FindByColumnsTokyoTyrantCommand : TokyoTyrantCommand
    {
        public FindByColumnsTokyoTyrantCommand(ITokyoTyrantConnectionProvider connectionProvider, IOutputReporter outputReporter) 
            : base(connectionProvider, outputReporter)
        {
        }

        public override void Invoke(CommandOptions options)
        {
            var findOptions = TryConvertToSpecificOptions<FindByColumnsCommandOptions>(options);

            var columnCriteria = GetColumnCriteria(findOptions);
            
            var query = BuildTokyoTyrantQuery(columnCriteria);

            var result = QueryRecords(query);

            OutputReporter.OutputColumns(result);
        }

        private IDictionary<string, IDictionary<string, string>> QueryRecords(TokyoQuery query)
        {
            var connection = ConnectionProvider.GetConnection();
            var result = connection.QueryRecords(query);
            return result;
        }

        private TokyoQuery BuildTokyoTyrantQuery(IDictionary<string, string> columnCriteria)
        {
            var query = new TokyoQuery();
            foreach (var columnCriterion in columnCriteria)
            {
                query = query.StringEquals(columnCriterion.Key, columnCriterion.Value);
            }
            return query;
        }

        private static IDictionary<string, string> GetColumnCriteria(FindByColumnsCommandOptions findOptions)
        {
            var columnPairParser = new ColumnPairParser();
            return columnPairParser.ParseColumns(findOptions.ColumnCriteria);
        }
    }
}