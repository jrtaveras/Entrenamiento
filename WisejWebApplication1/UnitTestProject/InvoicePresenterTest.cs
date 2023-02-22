//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Unit test del presenter InvoicePresenter
//Fecha:2/21/2023 2:39:06 PM
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
    public class InvoicePresenterTest
    {

        IContext _context;
        IPresenter _invoicePresenter = null;
        public InvoicePresenterTest()
        {
            _context = new MyContext(ContextName.Name);
            _context.UserName = "admin";
            _context.LocalizationName = "es-DO";
            _context.ResourceManager = Resource.ResourceManager;
        }
        
        private void tearDown()
        {
            _invoicePresenter.Delete();
        }

        private void setter(IInvoice sender) 
        {
        
        }
        
        [TestMethod]
        public void TestAddAndSave()
        {

            IInvoice _invoice = new MockInvoice();
            _invoicePresenter = new InvoicePresenter(_context, _invoice);
            _invoicePresenter.Add();

            //configura las propiedades aqui
            setter(_invoice);

            Assert.IsTrue( _invoicePresenter.Save());
            tearDown();

        }

        [TestMethod]
        public void TestAddSaveAndDelete()
        {

            IInvoice _invoice = new MockInvoice();
            _invoicePresenter = new InvoicePresenter(_context, _invoice);
            _invoicePresenter.Add();
            
            //configura las propiedades aqui
            setter(_invoice);

            Assert.IsTrue( _invoicePresenter.Save());
            Assert.IsTrue( _invoicePresenter.Delete());
            tearDown();
        }

        [TestMethod]
        public void TestAddSaveFindAndDelete()
        {

            IInvoice _invoice = new MockInvoice();
            _invoicePresenter = new InvoicePresenter(_context, _invoice);
            _invoicePresenter.Add();

            //configura las propiedades aqui
            setter(_invoice);

            Assert.IsTrue(_invoicePresenter.Save());
            Assert.IsTrue(_invoicePresenter.Find(_invoice.Id));
            Assert.IsTrue(_invoicePresenter.Delete());
            tearDown();


        }
    }
}

