//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Busines Object  Presenter Customers
//Fecha:2/21/2023 9:15:17 AM
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
    public partial class CustomersPresenter 
    {
        private readonly IContext _context;
        public ICollection<ValidationResult> ValidationResult { get; set; }
        private readonly HelperValidateEntity helperValidateEntity = new HelperValidateEntity();
        private Customers customers { get; set; }
        private ICustomers _customers;
        public event Validate BeforeSave;
        public event Validate AfterSave;
        public event RaiseRefresh OnRefresh;
        
        public object DataSource {get;set;}
        private IDataSource _dataSource;
        private IValueToSearch _valueToSearch;
                        
        private bool validateService()
        {
            return helperValidateEntity.ValidateService(customers);
        }

        private void gatherFields()
        {
            
            customers.Id = _customers.Id;
			customers.CustName = _customers.CustName;
			customers.Adress = _customers.Adress;
			customers.Status = _customers.Status;
			customers.CustomerTypeId = _customers.CustomerTypeId;
			customers.TenantId = _customers.TenantId;
			customers.IsActivo = _customers.IsActivo;
			if(string.IsNullOrEmpty(customers.Creado)){
				customers.Creado = _context.UserName;
 			}
			if(customers.FechaCreado == null || customers.FechaCreado.Year <= 1900) {
				customers.FechaCreado = DateTime.Now;
			}
			customers.Modificado = _context.UserName;
 			customers.FechaModificado = DateTime.Now;
			
        }
        
        private void scatterFields()
        {
            _customers.Id = customers.Id;
 			_customers.CustName = customers.CustName;
 			_customers.Adress = customers.Adress;
 			_customers.Status = customers.Status;
 			_customers.CustomerTypeId = customers.CustomerTypeId;
 			_customers.TenantId = customers.TenantId;
 			_customers.IsActivo = customers.IsActivo;
 			_customers.Creado = customers.Creado;
 			_customers.FechaCreado = customers.FechaCreado;
 			_customers.Modificado = customers.Modificado;
 			_customers.FechaModificado = customers.FechaModificado;
 			
        }
        
        public void Add()
        {
            
            customers = new Customers();
            customers.TenantId = _context.TenantId;
			if(string.IsNullOrEmpty(customers.Creado)){
				customers.Creado = _context.UserName;
 			}
			if(customers.FechaCreado == null || customers.FechaCreado.Year <= 1900) {
				customers.FechaCreado = DateTime.Now;
			}
			customers.Modificado = _context.UserName;
 			customers.FechaModificado = DateTime.Now;
			
            //Inicializando el Id se necesita en los id de tipo Guid
            customers.Id = 0;
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
           
            _context.Entry(this.customers).State = EntityState.Detached;
             
            Add();

            customers =  _context.Customers.Find(Id);
            
             if (customers == null) {
                
                Add();
                
                scatterFields();
                
                
				OnRefresh?.Invoke();
            
                return false;
            }

            _context.Entry(customers).State = EntityState.Modified;
            
            afterSetUserAndCreateDate();

            scatterFields();
            
            
			OnRefresh?.Invoke();
            
            FillDataSource();
            
            return true;
        }  

    }
}
