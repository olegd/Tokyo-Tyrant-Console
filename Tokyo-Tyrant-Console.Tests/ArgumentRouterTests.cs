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
            var args = new[] { "--findby-key", "key1" };

            AssertArgumentsRoutesTo(args, typeof(GetKeyTokyoTyrantCommand), typeof(FindByKeyCommandOptions));
        }

        [Test]
        public void DeleteKeyCommand_CorrectlyFormatted_ReturnsRoute()
        {
            var args = new[] { "--delete-key", "key1" };

            AssertArgumentsRoutesTo(args, typeof(DeleteKeyTokyoTyrantCommand), typeof(DeleteKeyCommandOptions));
        }

        [Test]
        public void UpdateKeyCommand_OneColumnPairProvided_ReturnsRoute()
        {
            var args = new[] { "--update-key", "key1", "column1:value1" };

            AssertArgumentsRoutesTo(args, typeof(UpdateKeyTokyoTyrantCommand), typeof(UpdateKeyCommandOptions));
        }

        [Test]
        public void UpdateKeyCommand_TwoColumnPairsProvided_ReturnsRoute()
        {
            var args = new[] { "--update-key", "key1", "column1:value1", "colunn2:value2" };

            AssertArgumentsRoutesTo(args, typeof(UpdateKeyTokyoTyrantCommand), typeof(UpdateKeyCommandOptions));
        }

        [Test]
        public void HelpCommand_LongCommandNameSpecified_ReturnsRoute()
        {
            var args = new[] { "--help" };

            AssertArgumentsRoutesTo(args, typeof(HelpCommand), typeof(HelpCommandOptions));
        }

        [Test]
        public void HelpCommand_ShortCommandNameSpecified_ReturnsRoute()
        {
            var args = new[] { "--h" };

            AssertArgumentsRoutesTo(args, typeof(HelpCommand), typeof(HelpCommandOptions));
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