// *******************************************************************************
// * Copyright (c) 1999 - 2011.
// * Global Relay Communications Inc.
// * All rights reserved.
// *******************************************************************************

using Ninject;
using Tokyo_Tyrant_Console.Connection;
using Tokyo_Tyrant_Console.Output;
using Tokyo_Tyrant_Console.Routing;

namespace Tokyo_Tyrant_Console
{
    public class NinjectConfig
    {
        private static IKernel _kernel;

        public static void Init()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<IOutputReporter>().To<ConsoleOutputReporter>();

            _kernel.Bind<ITokyoTyrantConnectionProvider>()
                .To<ConnectionPerRequestConnectionProvider>();

            _kernel.Bind<IArgumentRouter>().To<ArgumentRouter>();
        }

        public static T Get<T>()
        {
            return _kernel.Get<T>();
        }
    }
}
