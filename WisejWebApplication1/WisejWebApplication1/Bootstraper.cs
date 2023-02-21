using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;

namespace WisejWebApplication1
{
    public class Bootstraper
    {
        private static IKernel _kernel;
        public static void InitBootstrapper(params INinjectModule[] modules)
        {
            _kernel = new StandardKernel(modules);

        }

        public static IKernel Kernel()
        {
            return _kernel;
        }
    }
}