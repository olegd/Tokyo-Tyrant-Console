using Ninject;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;

namespace Tokyo_Tyrant_Console.Routing
{
    public class CommandRouter
    {
        [Inject]
        public IOutputReporter OutputReporter { get; set; }

        [Inject]
        public ConnectionPerRequestConnectionProvider ConnectionProvider { get; set; }
       
        public void RouteArguments(string[] args)
        {
            var routeHandlers = new ArgumentRouter();
            var handler = routeHandlers.Route(args);
            if (handler == null)
            {
                OutputReporter.WriteLine("Unknown command. Run --help for available options");
                return;
            }
            handler.Handle();
        }
    }
}
