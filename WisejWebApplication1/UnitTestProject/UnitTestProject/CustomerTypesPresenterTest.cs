//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Unit test del presenter CustomerTypesPresenter
//Fecha:2/20/2023 4:14:55 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System.Threading;
using BusinessObjects;
using BusinessObjects.Interfaces;
using BusinessObjects.Mocks;
using BusinessObjects.Repository;
using BusinessObjects.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace  UnitTestProjectBusinessObjects
{
    [TestClass]
    public class CustomerTypesPresenterTest
    {

        IContext _context;
        IPresenter _customerTypesPresenter = null;
        public CustomerTypesPresenterTest()
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
            _customerTypesPresenter.Delete();
        }

        private void setter(ICustomerTypes sender) 
        {
            
        }
        
        [TestMethod]
        public void TestAddAndSave()
        {

            ICustomerTypes _customerTypes = new MockCustomerTypes();
            _customerTypesPresenter = new CustomerTypesPresenter(_context, _customerTypes);
            _customerTypesPresenter.Add();

            //configura las propiedades aqui
            setter(_customerTypes);

            Assert.IsTrue( _customerTypesPresenter.Save());
            tearDown();

        }

        [TestMethod]
        public void TestAddSaveAndDelete()
        {

            ICustomerTypes _customerTypes = new MockCustomerTypes();
            _customerTypesPresenter = new CustomerTypesPresenter(_context, _customerTypes);
            _customerTypesPresenter.Add();
            
            //configura las propiedades aqui
            setter(_customerTypes);

            Assert.IsTrue( _customerTypesPresenter.Save());
            Assert.IsTrue( _customerTypesPresenter.Delete());
            tearDown();
        }

        [TestMethod]
        public void TestAddSaveFindAndDelete()
        {

            ICustomerTypes _customerTypes = new MockCustomerTypes();
            _customerTypesPresenter = new CustomerTypesPresenter(_context, _customerTypes);
            _customerTypesPresenter.Add();

            //configura las propiedades aqui
            setter(_customerTypes);

            Assert.IsTrue(_customerTypesPresenter.Save());
            Assert.IsTrue(_customerTypesPresenter.Find(_customerTypes.Id));
            Assert.IsTrue(_customerTypesPresenter.Delete());
            tearDown();


        }
    }
}

