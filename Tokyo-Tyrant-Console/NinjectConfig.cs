using Ninject;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;
using Tokyo_Tyrant_Console.Routing;

namespace Tokyo_Tyrant_Console
{
    public class NinjectConfig
    {
        public static void Init()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IOutputReporter>().To<ConsoleOutputReporter>();
            
            kernel.Bind<ITokyoTyrantConnectionProvider>()
                .To<ConnectionPerRequestConnectionProvider>();

            kernel.Bind<IArgumentRouter>().To<ArgumentRouter>();
        }
    }
}
    