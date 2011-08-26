using System;
using NUnit.Framework;
using Tokyo_Tyrant_Console.Commands;

namespace Tokyo_Tyrant_Console.Tests.Commands
{
    [TestFixture]
    public class FindByColumnsTokyoTyrantCommandTests : CommandTestsBase
    {
        [Test]
        public void Invoke_SingleColumnCriteria_QueryContainsColumn()
        {
            var queryCommand = GetFindByColumnsTokyoTyrantCommand();

            Assert.Throws<ArgumentException>(() => queryCommand.Invoke(null));
        }

        private FindByColumnsTokyoTyrantCommand GetFindByColumnsTokyoTyrantCommand()
        {
            var queryCommand = new FindByColumnsTokyoTyrantCommand(_connectionProvier.Object, _output.Object);
            return queryCommand;
        }
    }
}