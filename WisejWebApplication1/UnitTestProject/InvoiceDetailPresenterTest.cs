//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Unit test del presenter InvoiceDetailPresenter
//Fecha:2/21/2023 2:39:32 PM
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
    public class InvoiceDetailPresenterTest
    {

        IContext _context;
        IPresenter _invoiceDetailPresenter = null;
        public InvoiceDetailPresenterTest()
        {
            _context = new MyContext(ContextName.Name);
            _context.UserName = "admin";
            _context.LocalizationName = "es-DO";
            _context.ResourceManager = Resource.ResourceManager;
        }
        
        private void tearDown()
        {
            _invoiceDetailPresenter.Delete();
        }

        private void setter(IInvoiceDetail sender) 
        {
        
        }
        
        [TestMethod]
        public void TestAddAndSave()
        {

            IInvoiceDetail _invoiceDetail = new MockInvoiceDetail();
            _invoiceDetailPresenter = new InvoiceDetailPresenter(_context, _invoiceDetail);
            _invoiceDetailPresenter.Add();

            //configura las propiedades aqui
            setter(_invoiceDetail);

            Assert.IsTrue( _invoiceDetailPresenter.Save());
            tearDown();

        }

        [TestMethod]
        public void TestAddSaveAndDelete()
        {

            IInvoiceDetail _invoiceDetail = new MockInvoiceDetail();
            _invoiceDetailPresenter = new InvoiceDetailPresenter(_context, _invoiceDetail);
            _invoiceDetailPresenter.Add();
            
            //configura las propiedades aqui
            setter(_invoiceDetail);

            Assert.IsTrue( _invoiceDetailPresenter.Save());
            Assert.IsTrue( _invoiceDetailPresenter.Delete());
            tearDown();
        }

        [TestMethod]
        public void TestAddSaveFindAndDelete()
        {

            IInvoiceDetail _invoiceDetail = new MockInvoiceDetail();
            _invoiceDetailPresenter = new InvoiceDetailPresenter(_context, _invoiceDetail);
            _invoiceDetailPresenter.Add();

            //configura las propiedades aqui
            setter(_invoiceDetail);

            Assert.IsTrue(_invoiceDetailPresenter.Save());
            Assert.IsTrue(_invoiceDetailPresenter.Find(_invoiceDetail.Id));
            Assert.IsTrue(_invoiceDetailPresenter.Delete());
            tearDown();


        }
    }
}

