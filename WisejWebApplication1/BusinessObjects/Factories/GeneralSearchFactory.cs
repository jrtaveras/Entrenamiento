//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/20/2023 4:37:10 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Services;
namespace BusinessObjects.Factories
{
    public class GeneralSearchFactory
    {

        public static ISearchPresenter<Customers> MakeCustomersSearch(IContext context)
		{
			ISearchPresenter<Customers> instance = new SearchCustomersPresenter(context);
			return instance;
		}
		
		public static ISearchPresenter<CustomerTypes> MakeCustomerTypesSearch(IContext context)
		{
			ISearchPresenter<CustomerTypes> instance = new SearchCustomerTypesPresenter(context);
			return instance;
		}
				
		public static ISearchPresenter<Invoices> MakeInvoicesSearch(IContext context)
		{
			ISearchPresenter<Invoices> instance = new SearchInvoicesPresenter(context);
			return instance;
		}
		
		public static ISearchPresenter<InvoiceDetails> MakeInvoiceDetailsSearch(IContext context)
		{
			ISearchPresenter<InvoiceDetails> instance = new SearchInvoiceDetailsPresenter(context);
			return instance;
		}
		
		public static ISearchPresenter<Products> MakeProductsSearch(IContext context)
		{
			ISearchPresenter<Products> instance = new SearchProductsPresenter(context);
			return instance;
		}
		
		//Requerido por el generador de CodeSmith no modifique esto

    }
}
