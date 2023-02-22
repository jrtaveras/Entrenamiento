//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Unit test del presenter InvoiceDetailsPresenter
//Fecha:2/21/2023 2:50:38 PM
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
    public class InvoiceDetailsPresenterTest
    {

        IContext _context;
        IPresenter _invoiceDetailsPresenter = null;
        public InvoiceDetailsPresenterTest()
        {
            _context = new MyContext(ContextName.Name);
            _context.UserName = "admin";
            _context.LocalizationName = "es-DO";
            _context.ResourceManager = Resource.ResourceManager;
        }
        
        private void tearDown()
        {
            _invoiceDetailsPresenter.Delete();
        }

        private void setter(IInvoiceDetails sender) 
        {
        
        }
        
        [TestMethod]
        public void TestAddAndSave()
        {

            IInvoiceDetails _invoiceDetails = new MockInvoiceDetails();
            _invoiceDetailsPresenter = new InvoiceDetailsPresenter(_context, _invoiceDetails);
            _invoiceDetailsPresenter.Add();

            //configura las propiedades aqui
            setter(_invoiceDetails);

            Assert.IsTrue( _invoiceDetailsPresenter.Save());
            tearDown();

        }

        [TestMethod]
        public void TestAddSaveAndDelete()
        {

            IInvoiceDetails _invoiceDetails = new MockInvoiceDetails();
            _invoiceDetailsPresenter = new InvoiceDetailsPresenter(_context, _invoiceDetails);
            _invoiceDetailsPresenter.Add();
            
            //configura las propiedades aqui
            setter(_invoiceDetails);

            Assert.IsTrue( _invoiceDetailsPresenter.Save());
            Assert.IsTrue( _invoiceDetailsPresenter.Delete());
            tearDown();
        }

        [TestMethod]
        public void TestAddSaveFindAndDelete()
        {

            IInvoiceDetails _invoiceDetails = new MockInvoiceDetails();
            _invoiceDetailsPresenter = new InvoiceDetailsPresenter(_context, _invoiceDetails);
            _invoiceDetailsPresenter.Add();

            //configura las propiedades aqui
            setter(_invoiceDetails);

            Assert.IsTrue(_invoiceDetailsPresenter.Save());
            Assert.IsTrue(_invoiceDetailsPresenter.Find(_invoiceDetails.Id));
            Assert.IsTrue(_invoiceDetailsPresenter.Delete());
            tearDown();


        }
    }
}

