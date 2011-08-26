using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tokyo_Tyrant_Console.Commands;
using System.Linq;
using Tokyo_Tyrant_Console.Routing;

namespace Tokyo_Tyrant_Console.Tests.Commands
{
    [TestFixture]
    public class GetKeyCommandTests : CommandTestsBase
    {
        [Test]
        public void Invoke_GetsColumnsFromTokyoTyrantConnection()
        {
            var command = GetCommand();
            var options = new FindByKeyCommandOptions { Key = Key1 };

            var keyData = new Dictionary<string, IDictionary<string, string>>();
            keyData[Key1] = new Dictionary<string, string> {{"login", "oleg@gr.com"}};

            _connection.Setup(x => x.GetColumns(It.IsAny<string[]>()))
                .Returns(keyData);

            command.Invoke(options);

            _connection.Verify(x => x.GetColumns(
                It.Is<string[]>(keys => keys.Any(key => key.Equals(Key1))))
            );
        }

        private GetKeyTokyoTyrantCommand GetCommand()
        {
            var command = new GetKeyTokyoTyrantCommand(_connectionProvier.Object, _output.Object);
            return command;
        }
    }
}