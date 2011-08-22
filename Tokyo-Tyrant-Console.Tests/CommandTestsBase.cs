using Moq;
using NUnit.Framework;
using TokyoTyrant.NET;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;

namespace Tokyo_Tyrant_Console.Tests
{
    public class CommandTestsBase
    {
        protected Mock<IOutputReporter> _output = new Mock<IOutputReporter>();
        protected Mock<ITokyoTyrantConnectionProvider> _connectionProvier = new Mock<ITokyoTyrantConnectionProvider>();
        protected Mock<ITokyoTyrantConnection> _connection = new Mock<ITokyoTyrantConnection>();

        protected const string Key1 = "key-1101";

        [SetUp]
        public void BeforeEachTest()
        {
            _output = new Mock<IOutputReporter>();
            _connectionProvier = new Mock<ITokyoTyrantConnectionProvider>();
            _connection = new Mock<ITokyoTyrantConnection>();
            _connectionProvier.Setup(x => x.GetConnection()).Returns(_connection.Object);
        }
    }
}