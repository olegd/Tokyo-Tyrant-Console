using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Linq;

namespace Tokyo_Tyrant_Console.Tests
{
    [TestFixture]
    public class ColumnPairParserTests
    {
        [Test]
        public void ParseColumns_EmptyList_ReturnsEmptyDict()
        {
            var parser = new ColumnPairParser();
            
            var result = parser.ParseColumns(new List<string>());

            Assert.IsFalse(result.Any());
        }

        [Test]
        public void ParseColumns_OneColumnPairInValidFormat_ReturnsParsedPairInDict()
        {
            var parser = new ColumnPairParser();

            var result = parser.ParseColumns(new List<string>{"columnName:value"});

            Assert.IsTrue(result.ContainsKey("columnName"));
            Assert.AreEqual(result["columnName"], "value");
        }

        [Test]
        public void ParseColumns_OneColumnPairWithoutSeparator_ThrowsArgumentException()
        {
            var parser = new ColumnPairParser();
            
            Assert.Throws<ArgumentException>(
                () => 
                    parser.ParseColumns(new List<string> {"columnNameAndValue"})
            );
        }

        [Test]
        public void ParseColumns_OneColumnWithTwoSeparators_ThrowsArgumentException()
        {
            var parser = new ColumnPairParser();

            Assert.Throws<ArgumentException>(
                () =>
                    parser.ParseColumns(new List<string> { "columnName:Value:andValue" })
            );
        }

        [Test]
        public void ParseColumns_TwoSetsOfColumns_ReturnsDictWithTwoKeysAndValues()
        {
            var parser = new ColumnPairParser();

            var result = parser.ParseColumns(new List<string>
                                                 {
                                                     "columnName:value", 
                                                     "anotherColumn:anotherValue"
                                                 });

            Assert.IsTrue(result.ContainsKey("columnName"));
            Assert.AreEqual(result["columnName"], "value");

            Assert.IsTrue(result.ContainsKey("anotherColumn"));
            Assert.AreEqual(result["anotherColumn"], "anotherValue");
        }
     }
}