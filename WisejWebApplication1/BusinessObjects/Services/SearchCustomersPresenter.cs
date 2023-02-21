

//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad Customers
//Fecha:2/20/2023 4:37:10 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)


using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Helpers;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
namespace BusinessObjects.Services
{
    public class SearchCustomersPresenter : ISearchPresenter<Customers>
    {
        private ISearch _sender;
        object id = (int) 0;
		public IContext Context { get; private set; }
        public SearchCustomersPresenter(IContext context)
        {
            Context = context;
         
        }

        public void Search() {
         

            
            if (!HelperParser.TryParse("int", _sender.ValueToSearch,ref id))
            {
                _sender.DataGridSource = Context.Customers.Where(a =>   a.IsActivo && (a.CustName.Contains(_sender.ValueToSearch) || a.Adress.Contains(_sender.ValueToSearch) || a.Creado.Contains(_sender.ValueToSearch) || a.Modificado.Contains(_sender.ValueToSearch) )).Take(100).Select(a => new {a.Id,a.CustName,a.Adress,a.Status,a.CustomerTypeId,a.IsActivo,a.Creado,a.FechaCreado,a.Modificado,a.FechaModificado}).ToList();
            }
            else{
                _sender.DataGridSource = Context.Customers.Where(a =>   a.IsActivo && a.Id == (int) id).Take(1).Select(a => new {a.Id,a.CustName,a.Adress,a.Status,a.CustomerTypeId,a.IsActivo,a.Creado,a.FechaCreado,a.Modificado,a.FechaModificado}).ToList();
            }
        }
        
        public Customers FindById(object id) {
            return Context.Customers.Find(id);
        }
        
        public List<Customers> GetAll()
        {
            return Context.Customers.Where( a => a.IsActivo ).ToList();
        }
        
        public void DataBind(ISearch sender)
        {
            _sender = sender;
            Search();
        }
    }
}
