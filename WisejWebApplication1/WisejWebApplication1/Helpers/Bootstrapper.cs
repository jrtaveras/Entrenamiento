//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description:  Helper para instanciar el kernel de Niject 
//Fecha:5/21/2021 9:16:21 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)

namespace Common.Helpers
{
    public class Bootstrapper
    {
        private Ninject.IKernel _kernel;
        public void InitBootstrapper(params Ninject.Modules.INinjectModule[] modules)
        {
            _kernel = new Ninject.StandardKernel(modules);
        }
        public Ninject.IKernel Kernel()
        {
            return _kernel;
        }
    }
}
