using System;
using System.Collections.Generic;
using System.Linq;

namespace Tokyo_Tyrant_Console.Core
{
    public class ColumnPairParser
    {
       public IDictionary<string, string> ParseColumns(IList<string> columnPairs)
        {
            var result = new Dictionary<string, string>();
            foreach (var columnValue in columnPairs)
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
