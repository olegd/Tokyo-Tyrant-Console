using System;
using NUnit.Framework;
using Tokyo_Tyrant_Console.Commands;
using Tokyo_Tyrant_Console.Routing;

namespace Tokyo_Tyrant_Console.Tests
{
    [TestFixture]
    public class ArgumentRouterTests
    {
        [Test]
        public void FindByColumnsCommand_SingleColumnPairProvided_ReturnsRoute()
        {
            var args = new[] {"--findby-columns", "columnName:columnValue"};

            AssertArgumentsRoutesTo(args, typeof (FindByColumnsTokyoTyrantCommand), typeof (FindByColumnsCommandOptions));
        }

        [Test]
        public void FindByColumnsCommand_TwoColumnPairsProvided_ReturnsRoute()
        {
            var args = new[] { "--findby-columns", "columnName:columnValue", "columnName2:columnValue2" };

            AssertArgumentsRoutesTo(args, typeof(FindByColumnsTokyoTyrantCommand), typeof(FindByColumnsCommandOptions));
        }

        [Test]
        public void FindByKeyCommand_CorrectlyFormatted_ReturnsRoute()
        {
            var args = new[] { "--get-key", "key1" };

            AssertArgumentsRoutesTo(args, typeof(GetKeyTokyoTyrantCommand), typeof(GetKeyCommandOptions));
        }

        private void AssertArgumentsRoutesTo(string[] args, Type expectedCommand, Type expectedOptions)
        {
            IArgumentRouter router = new ArgumentRouter();

            var result = router.Route(args);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf(expectedCommand, result.Handler);
            Assert.IsInstanceOf(expectedOptions, result.Options);
        }
    }
}