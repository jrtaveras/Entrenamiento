using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;

namespace WisejWebApplication1.Modules
{
    public class CalcularModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICalculo>().To<Suma>().InSingletonScope();
            Bind<ICalculo>().To<Resta>().InSingletonScope();
            Bind<ICalculo>().To<Multiplicacion>().InSingletonScope();
            Bind<ICalculo>().To<Division>().InSingletonScope();
        }

    }
}