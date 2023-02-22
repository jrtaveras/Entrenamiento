//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Unit test del presenter ProductsPresenter
//Fecha:2/22/2023 8:17:55 AM
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
    public class ProductsPresenterTest
    {

        IContext _context;
        IPresenter _productsPresenter = null;
        public ProductsPresenterTest()
        {
            _context = new MyContext(ContextName.Name);
            _context.UserName = "admin";
            _context.LocalizationName = "es-DO";
            _context.ResourceManager = Resource.ResourceManager;
        }
        
        private void tearDown()
        {
            _productsPresenter.Delete();
        }

        private void setter(IProducts sender) 
        {
        
        }
        
        [TestMethod]
        public void TestAddAndSave()
        {

            IProducts _products = new MockProducts();
            _productsPresenter = new ProductsPresenter(_context, _products);
            _productsPresenter.Add();

            //configura las propiedades aqui
            setter(_products);

            Assert.IsTrue( _productsPresenter.Save());
            tearDown();

        }

        [TestMethod]
        public void TestAddSaveAndDelete()
        {

            IProducts _products = new MockProducts();
            _productsPresenter = new ProductsPresenter(_context, _products);
            _productsPresenter.Add();
            
            //configura las propiedades aqui
            setter(_products);

            Assert.IsTrue( _productsPresenter.Save());
            Assert.IsTrue( _productsPresenter.Delete());
            tearDown();
        }

        [TestMethod]
        public void TestAddSaveFindAndDelete()
        {

            IProducts _products = new MockProducts();
            _productsPresenter = new ProductsPresenter(_context, _products);
            _productsPresenter.Add();

            //configura las propiedades aqui
            setter(_products);

            Assert.IsTrue(_productsPresenter.Save());
            Assert.IsTrue(_productsPresenter.Find(_products.Id));
            Assert.IsTrue(_productsPresenter.Delete());
            tearDown();


        }
    }
}

