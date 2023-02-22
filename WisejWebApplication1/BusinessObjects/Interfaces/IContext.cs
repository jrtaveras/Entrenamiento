//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/20/2023 4:37:10 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using BusinessObjects.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Resources;

namespace BusinessObjects.Interfaces
{
    public interface IContext
    {
		ResourceManager ResourceManager { get; set; }
        
        void DetachAllEntities();
		
		string LocalizationName { get; set; }
		
        DbEntityEntry Entry(object entity);
		
        int SaveChanges();

        long TenantId { get; set; }
		
        string UserName { get; set; }
        DbSet<Customers> Customers { get; set; }
		DbSet<CustomerTypes> CustomerTypes { get; set; }
		DbSet<Invoices> Invoices { get; set; }
		DbSet<InvoiceDetails> InvoiceDetails { get; set; }
		DbSet<Products> Products { get; set; }
		//property no remueva esto usado por CodeSmith
    }
}
