//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/20/2023 4:37:10 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Resources;

namespace BusinessObjects.Repository
{
    public class MyContext : DbContext, IContext
    {
		public ResourceManager ResourceManager { get; set; }
        
        public void DetachAllEntities()
		{
			var changedEntriesCopy = this.ChangeTracker.Entries()
				.Where(e => e.State == EntityState.Added ||
							e.State == EntityState.Modified ||
							e.State == EntityState.Deleted)
				.ToList();

			foreach (var entry in changedEntriesCopy)
				entry.State = EntityState.Detached;
		}
		
		public string LocalizationName { get; set; }
		
        public MyContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
			this.Database.CommandTimeout = 360;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>();
			modelBuilder.Entity<CustomerTypes>();
			modelBuilder.Entity<Invoices>();
			modelBuilder.Entity<InvoiceDetails>();
			modelBuilder.Entity<Products>();
			//modelBuider no remueva esto usado por CodeSmith
            base.OnModelCreating(modelBuilder);
            
        }
        
        
        public string UserName { get; set; }
		
        public long TenantId { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
		public virtual DbSet<CustomerTypes> CustomerTypes { get; set; }
		public virtual DbSet<Invoices> Invoices { get; set; }
		public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
		public virtual DbSet<Products> Products { get; set; }
		//property no remueva esto usado por CodeSmith
    }
}
