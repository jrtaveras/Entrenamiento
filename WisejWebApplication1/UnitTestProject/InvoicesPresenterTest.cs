//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Unit test del presenter InvoicesPresenter
//Fecha:2/21/2023 2:43:35 PM
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
    public class InvoicesPresenterTest
    {

        IContext _context;
        IPresenter _invoicesPresenter = null;
        public InvoicesPresenterTest()
        {
            _context = new MyContext(ContextName.Name);
            _context.UserName = "admin";
            _context.LocalizationName = "es-DO";
            _context.ResourceManager = Resource.ResourceManager;
        }
        
        private void tearDown()
        {
            _invoicesPresenter.Delete();
        }

        private void setter(IInvoices sender) 
        {
        
        }
        
        [TestMethod]
        public void TestAddAndSave()
        {

            IInvoices _invoices = new MockInvoices();
            _invoicesPresenter = new InvoicesPresenter(_context, _invoices);
            _invoicesPresenter.Add();

            //configura las propiedades aqui
            setter(_invoices);

            Assert.IsTrue( _invoicesPresenter.Save());
            tearDown();

        }

        [TestMethod]
        public void TestAddSaveAndDelete()
        {

            IInvoices _invoices = new MockInvoices();
            _invoicesPresenter = new InvoicesPresenter(_context, _invoices);
            _invoicesPresenter.Add();
            
            //configura las propiedades aqui
            setter(_invoices);

            Assert.IsTrue( _invoicesPresenter.Save());
            Assert.IsTrue( _invoicesPresenter.Delete());
            tearDown();
        }

        [TestMethod]
        public void TestAddSaveFindAndDelete()
        {

            IInvoices _invoices = new MockInvoices();
            _invoicesPresenter = new InvoicesPresenter(_context, _invoices);
            _invoicesPresenter.Add();

            //configura las propiedades aqui
            setter(_invoices);

            Assert.IsTrue(_invoicesPresenter.Save());
            Assert.IsTrue(_invoicesPresenter.Find(_invoices.Id));
            Assert.IsTrue(_invoicesPresenter.Delete());
            tearDown();


        }
    }
}

