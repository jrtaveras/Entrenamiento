

//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad Products
//Fecha:2/22/2023 8:17:55 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)


using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Helpers;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
namespace BusinessObjects.Services
{
    public class SearchProductsPresenter : ISearchPresenter<Products>
    {
        private ISearch _sender;
        object id = (int) 0;
		public IContext Context { get; private set; }
        public SearchProductsPresenter(IContext context)
        {
            Context = context;
         
        }

        public void Search() {
         

            
            if (!HelperParser.TryParse("int", _sender.ValueToSearch,ref id))
            {
                _sender.DataGridSource = Context.Products.Where(a => a.TenantId == Context.TenantId && a.IsActivo && (a.Description.Contains(_sender.ValueToSearch) || a.Creado.Contains(_sender.ValueToSearch) || a.Modificado.Contains(_sender.ValueToSearch) )).Take(100).Select(a => new {a.Id,a.Description,a.TenantId,a.IsActivo,a.Creado,a.FechaCreado,a.Modificado,a.FechaModificado}).ToList();
            }
            else{
                _sender.DataGridSource = Context.Products.Where(a =>  a.TenantId == Context.TenantId &&   a.IsActivo && a.Id == (int) id).Take(1).Select(a => new {a.Id,a.Description,a.TenantId,a.IsActivo,a.Creado,a.FechaCreado,a.Modificado,a.FechaModificado}).ToList();
            }
        }
        
        public Products FindById(object id) {
            return Context.Products.Find(id);
        }
        
        public List<Products> GetAll()
        {
            return Context.Products.Where( a => a.IsActivo  && a.TenantId == Context.TenantId ).ToList();
        }
        
        public void DataBind(ISearch sender)
        {
            _sender = sender;
            Search();
        }
    }
}
