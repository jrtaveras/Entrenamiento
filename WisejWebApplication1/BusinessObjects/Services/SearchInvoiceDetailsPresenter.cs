

//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad InvoiceDetails
//Fecha:2/21/2023 2:50:38 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)


using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Helpers;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
namespace BusinessObjects.Services
{
    public class SearchInvoiceDetailsPresenter : ISearchPresenter<InvoiceDetails>
    {
        private ISearch _sender;
        object id = (int) 0;
		public IContext Context { get; private set; }
        public SearchInvoiceDetailsPresenter(IContext context)
        {
            Context = context;
         
        }

        public void Search() {
         

            
            if (!HelperParser.TryParse("int", _sender.ValueToSearch,ref id))
            {
                _sender.DataGridSource = Context.InvoiceDetails.Where(a =>   a.IsActivo && (a.Creado.Contains(_sender.ValueToSearch) || a.Modificado.Contains(_sender.ValueToSearch) )).Take(100).Select(a => new {a.Id,a.InvoiceId,a.Qty,a.Price,a.TotalItbis,a.SubTotal,a.Total,a.IsActivo,a.Creado,a.FechaCreado,a.Modificado,a.FechaModificado}).ToList();
            }
            else{
                _sender.DataGridSource = Context.InvoiceDetails.Where(a =>   a.IsActivo && a.Id == (int) id).Take(1).Select(a => new {a.Id,a.InvoiceId,a.Qty,a.Price,a.TotalItbis,a.SubTotal,a.Total,a.IsActivo,a.Creado,a.FechaCreado,a.Modificado,a.FechaModificado}).ToList();
            }
        }
        
        public InvoiceDetails FindById(object id) {
            return Context.InvoiceDetails.Find(id);
        }
        
        public List<InvoiceDetails> GetAll()
        {
            return Context.InvoiceDetails.Where( a => a.IsActivo ).ToList();
        }
        
        public void DataBind(ISearch sender)
        {
            _sender = sender;
            Search();
        }
    }
}
