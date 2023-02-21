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
            Bind<ICalculo>().To<Suma>();
            Bind<ICalculo>().To<Resta>();
            Bind<ICalculo>().To<Multiplicacion>();
            Bind<ICalculo>().To<Division>();
        }

    }
}