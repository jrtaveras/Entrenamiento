//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Busines Object  Presenter Invoices
//Fecha:2/21/2023 2:50:15 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)
//No toques esto por que al regenerar se sobreescribe el codigo

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using BusinessObjects.Helpers;
using BusinessObjects.Models;
using BusinessObjects.Interfaces;
using BusinessObjects.Repository;



namespace  BusinessObjects.Services
{
    public partial class InvoicesPresenter 
    {
        private readonly IContext _context;
        public ICollection<ValidationResult> ValidationResult { get; set; }
        private readonly HelperValidateEntity helperValidateEntity = new HelperValidateEntity();
        private Invoices invoices { get; set; }
        private IInvoices _invoices;
        public event Validate BeforeSave;
        public event Validate AfterSave;
        public event RaiseRefresh OnRefresh;
        
        public object DataSource {get;set;}
        private IDataSource _dataSource;
        private IValueToSearch _valueToSearch;
                        
        private bool validateService()
        {
            return helperValidateEntity.ValidateService(invoices);
        }

        private void gatherFields()
        {
            
            invoices.Id = _invoices.Id;
			invoices.CustomerId = _invoices.CustomerId;
			invoices.TotalItbis = _invoices.TotalItbis;
			invoices.SubTotal = _invoices.SubTotal;
			invoices.Total = _invoices.Total;
			invoices.IsActivo = _invoices.IsActivo;
			if(string.IsNullOrEmpty(invoices.Creado)){
				invoices.Creado = _context.UserName;
 			}
			if(invoices.FechaCreado == null || invoices.FechaCreado.Year <= 1900) {
				invoices.FechaCreado = DateTime.Now;
			}
			invoices.Modificado = _context.UserName;
 			invoices.FechaModificado = DateTime.Now;
			
        }
        
        private void scatterFields()
        {
            _invoices.Id = invoices.Id;
 			_invoices.CustomerId = invoices.CustomerId;
 			_invoices.TotalItbis = invoices.TotalItbis;
 			_invoices.SubTotal = invoices.SubTotal;
 			_invoices.Total = invoices.Total;
 			_invoices.IsActivo = invoices.IsActivo;
 			_invoices.Creado = invoices.Creado;
 			_invoices.FechaCreado = invoices.FechaCreado;
 			_invoices.Modificado = invoices.Modificado;
 			_invoices.FechaModificado = invoices.FechaModificado;
 			
        }
        
        public void Add()
        {
            
            invoices = new Invoices();
            if(string.IsNullOrEmpty(invoices.Creado)){
				invoices.Creado = _context.UserName;
 			}
			if(invoices.FechaCreado == null || invoices.FechaCreado.Year <= 1900) {
				invoices.FechaCreado = DateTime.Now;
			}
			invoices.Modificado = _context.UserName;
 			invoices.FechaModificado = DateTime.Now;
			
            //Inicializando el Id se necesita en los id de tipo Guid
            invoices.Id = 0;
            afterSetUserAndCreateDate();
            scatterFields();
            OnRefresh?.Invoke();
            FillDataSource();

        }
        
        public void Undo()
        {
   
            afterSetUserAndCreateDate();
            scatterFields();
            OnRefresh?.Invoke();
            FillDataSource();

        }
        
        public bool Find(object Id)
        {
           
            _context.Entry(this.invoices).State = EntityState.Detached;
             
            Add();

            invoices =  _context.Invoices.Find(Id);
            
             if (invoices == null) {
                
                Add();
                
                scatterFields();
                
                
				OnRefresh?.Invoke();
            
                return false;
            }

            _context.Entry(invoices).State = EntityState.Modified;
            
            afterSetUserAndCreateDate();

            scatterFields();
            
            
			OnRefresh?.Invoke();
            
            FillDataSource();
            
            return true;
        }  

    }
}
