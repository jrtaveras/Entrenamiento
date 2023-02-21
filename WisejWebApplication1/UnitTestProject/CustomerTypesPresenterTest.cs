//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Unit test del presenter CustomerTypesPresenter
//Fecha:2/20/2023 4:14:55 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

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
            _context = new MyContext(ContextName.Name);
            _context.UserName = "admin";
            _context.LocalizationName = "es-DO";
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

