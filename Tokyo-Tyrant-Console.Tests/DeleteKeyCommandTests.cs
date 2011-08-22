using NUnit.Framework;
using Tokyo_Tyrant_Console.Commands;

namespace Tokyo_Tyrant_Console.Tests
{
    [TestFixture]
    public class DeleteKeyCommandTests : CommandTestsBase
    {
        [Test]
        public void Invoke_CallsDeleteOnTokyoTyrantConnection()
        {
            var command = GetCommand();
            var options = new DeleteKeyCommandOptions { Key = Key1 };

            command.Invoke(options);

            _connection.Verify(x => x.Delete(Key1));
        }

        private DeleteKeyTokyoTyrantCommand GetCommand()
        {
            var command = new DeleteKeyTokyoTyrantCommand(_connectionProvier.Object, _output.Object);
            return command;
        }
    }
}