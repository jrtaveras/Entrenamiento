

//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad CustomerTypes
//Fecha:2/20/2023 4:38:14 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)


using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Helpers;
using BusinessObjects.Interfaces;
using BusinessObjects.Models;
namespace BusinessObjects.Services
{
    public class SearchCustomerTypesPresenter : ISearchPresenter<CustomerTypes>
    {
        private ISearch _sender;
        object id = (int) 0;
		public IContext Context { get; private set; }
        public SearchCustomerTypesPresenter(IContext context)
        {
            Context = context;
         
        }

        public void Search() {
         

            
            if (!HelperParser.TryParse("int", _sender.ValueToSearch,ref id))
            {
                _sender.DataGridSource = Context.CustomerTypes.Where(a =>   a.IsActivo && (a.Description.Contains(_sender.ValueToSearch) || a.Creado.Contains(_sender.ValueToSearch) || a.Modificado.Contains(_sender.ValueToSearch) )).Take(100).Select(a => new {a.Id,a.Description,a.IsActivo,a.Creado,a.FechaCreado,a.Modificado,a.FechaModificado}).ToList();
            }
            else{
                _sender.DataGridSource = Context.CustomerTypes.Where(a =>   a.IsActivo && a.Id == (int) id).Take(1).Select(a => new {a.Id,a.Description,a.IsActivo,a.Creado,a.FechaCreado,a.Modificado,a.FechaModificado}).ToList();
            }
        }
        
        public CustomerTypes FindById(object id) {
            return Context.CustomerTypes.Find(id);
        }
        
        public List<CustomerTypes> GetAll()
        {
            return Context.CustomerTypes.Where( a => a.IsActivo ).ToList();
        }
        
        public void DataBind(ISearch sender)
        {
            _sender = sender;
            Search();
        }
    }
}
