using NUnit.Framework;
using Tokyo_Tyrant_Console.Commands;
using Tokyo_Tyrant_Console.Routing;

namespace Tokyo_Tyrant_Console.Tests
{
    [TestFixture]
    public class RouteRegistrationTests
    {
        [Test]
        public void TESTNAME()
        {
            var routes = new RouteRegistration();

            var route = routes.Route(new[] {"--get-key 123"});

            Assert.IsNotNull(route.Handler);
            Assert.IsNotNull(route.Arguments);
        }

        public class RouteRegistration
        {
            public RouteHandler Route(string[] args)
            {
                return null;
            }
        }

        public class RouteHandler
        {
            public ICommand Handler { get; set; }
            public CommandOptions Arguments { get; set; }
        }
    }
}