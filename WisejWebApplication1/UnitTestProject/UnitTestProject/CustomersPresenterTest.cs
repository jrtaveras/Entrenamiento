//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Unit test del presenter CustomersPresenter
//Fecha:2/20/2023 3:11:58 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System.Threading;
using BusinessObjects;
using BusinessObjects.Interfaces;
using BusinessObjects.Mocks;
using BusinessObjects.Repository;
using BusinessObjects.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Net.Mime.MediaTypeNames;

namespace  UnitTestProjectBusinessObjects
{
    [TestClass]
    public class CustomersPresenterTest
    {

        IContext _context;
        IPresenter _customersPresenter = null;
        public CustomersPresenterTest()
        {
            MyContext _context = new MyContext("Entrenamiento");
            _context.LocalizationName = "es-DO";
            _context.TenantId = 1;
            _context.UserName = "Kiefer";
            var culture = new System.Globalization.CultureInfo(_context.LocalizationName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Resource.Culture = culture;
            _context.ResourceManager = Resource.ResourceManager;
        }
        
        private void tearDown()
        {
            _customersPresenter.Delete();
        }

        private void setter(ICustomers sender) 
        {
        
        }
        
        [TestMethod]
        public void TestAddAndSave()
        {

            ICustomers _customers = new MockCustomers();
            _customersPresenter = new CustomersPresenter(_context, _customers);
            _customersPresenter.Add();

            //configura las propiedades aqui
            setter(_customers);

            Assert.IsTrue( _customersPresenter.Save());
            tearDown();

        }

        [TestMethod]
        public void TestAddSaveAndDelete()
        {

            ICustomers _customers = new MockCustomers();
            _customersPresenter = new CustomersPresenter(_context, _customers);
            _customersPresenter.Add();
            
            //configura las propiedades aqui
            setter(_customers);

            Assert.IsTrue( _customersPresenter.Save());
            Assert.IsTrue( _customersPresenter.Delete());
            tearDown();
        }

        [TestMethod]
        public void TestAddSaveFindAndDelete()
        {

            ICustomers _customers = new MockCustomers();
            _customersPresenter = new CustomersPresenter(_context, _customers);
            _customersPresenter.Add();

            //configura las propiedades aqui
            setter(_customers);

            Assert.IsTrue(_customersPresenter.Save());
            Assert.IsTrue(_customersPresenter.Find(_customers.Id));
            Assert.IsTrue(_customersPresenter.Delete());
            tearDown();


        }
    }
}

