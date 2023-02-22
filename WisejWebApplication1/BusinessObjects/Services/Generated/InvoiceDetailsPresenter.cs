//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Busines Object  Presenter InvoiceDetails
//Fecha:2/21/2023 2:50:38 PM
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
    public partial class InvoiceDetailsPresenter 
    {
        private readonly IContext _context;
        public ICollection<ValidationResult> ValidationResult { get; set; }
        private readonly HelperValidateEntity helperValidateEntity = new HelperValidateEntity();
        private InvoiceDetails invoiceDetails { get; set; }
        private IInvoiceDetails _invoiceDetails;
        public event Validate BeforeSave;
        public event Validate AfterSave;
        public event RaiseRefresh OnRefresh;
        
        public object DataSource {get;set;}
        private IDataSource _dataSource;
        private IValueToSearch _valueToSearch;
                        
        private bool validateService()
        {
            return helperValidateEntity.ValidateService(invoiceDetails);
        }

        private void gatherFields()
        {
            
            invoiceDetails.Id = _invoiceDetails.Id;
			invoiceDetails.InvoiceId = _invoiceDetails.InvoiceId;
			invoiceDetails.Qty = _invoiceDetails.Qty;
			invoiceDetails.Price = _invoiceDetails.Price;
			invoiceDetails.TotalItbis = _invoiceDetails.TotalItbis;
			invoiceDetails.SubTotal = _invoiceDetails.SubTotal;
			invoiceDetails.Total = _invoiceDetails.Total;
			invoiceDetails.IsActivo = _invoiceDetails.IsActivo;
			if(string.IsNullOrEmpty(invoiceDetails.Creado)){
				invoiceDetails.Creado = _context.UserName;
 			}
			if(invoiceDetails.FechaCreado == null || invoiceDetails.FechaCreado.Year <= 1900) {
				invoiceDetails.FechaCreado = DateTime.Now;
			}
			invoiceDetails.Modificado = _context.UserName;
 			invoiceDetails.FechaModificado = DateTime.Now;
			
        }
        
        private void scatterFields()
        {
            _invoiceDetails.Id = invoiceDetails.Id;
 			_invoiceDetails.InvoiceId = invoiceDetails.InvoiceId;
 			_invoiceDetails.Qty = invoiceDetails.Qty;
 			_invoiceDetails.Price = invoiceDetails.Price;
 			_invoiceDetails.TotalItbis = invoiceDetails.TotalItbis;
 			_invoiceDetails.SubTotal = invoiceDetails.SubTotal;
 			_invoiceDetails.Total = invoiceDetails.Total;
 			_invoiceDetails.IsActivo = invoiceDetails.IsActivo;
 			_invoiceDetails.Creado = invoiceDetails.Creado;
 			_invoiceDetails.FechaCreado = invoiceDetails.FechaCreado;
 			_invoiceDetails.Modificado = invoiceDetails.Modificado;
 			_invoiceDetails.FechaModificado = invoiceDetails.FechaModificado;
 			
        }
        
        public void Add()
        {
            
            invoiceDetails = new InvoiceDetails();
            if(string.IsNullOrEmpty(invoiceDetails.Creado)){
				invoiceDetails.Creado = _context.UserName;
 			}
			if(invoiceDetails.FechaCreado == null || invoiceDetails.FechaCreado.Year <= 1900) {
				invoiceDetails.FechaCreado = DateTime.Now;
			}
			invoiceDetails.Modificado = _context.UserName;
 			invoiceDetails.FechaModificado = DateTime.Now;
			
            //Inicializando el Id se necesita en los id de tipo Guid
            invoiceDetails.Id = 0;
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
           
            _context.Entry(this.invoiceDetails).State = EntityState.Detached;
             
            Add();

            invoiceDetails =  _context.InvoiceDetails.Find(Id);
            
             if (invoiceDetails == null) {
                
                Add();
                
                scatterFields();
                
                
				OnRefresh?.Invoke();
            
                return false;
            }

            _context.Entry(invoiceDetails).State = EntityState.Modified;
            
            afterSetUserAndCreateDate();

            scatterFields();
            
            
			OnRefresh?.Invoke();
            
            FillDataSource();
            
            return true;
        }  

    }
}
