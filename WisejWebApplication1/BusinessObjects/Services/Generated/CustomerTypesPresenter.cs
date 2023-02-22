//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Busines Object  Presenter CustomerTypes
//Fecha:2/22/2023 8:15:54 AM
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
    public partial class CustomerTypesPresenter 
    {
        private readonly IContext _context;
        public ICollection<ValidationResult> ValidationResult { get; set; }
        private readonly HelperValidateEntity helperValidateEntity = new HelperValidateEntity();
        private CustomerTypes customerTypes { get; set; }
        private ICustomerTypes _customerTypes;
        public event Validate BeforeSave;
        public event Validate AfterSave;
        public event RaiseRefresh OnRefresh;
        
        public object DataSource {get;set;}
        private IDataSource _dataSource;
        private IValueToSearch _valueToSearch;
                        
        private bool validateService()
        {
            return helperValidateEntity.ValidateService(customerTypes);
        }

        private void gatherFields()
        {
            
            customerTypes.Id = _customerTypes.Id;
			customerTypes.Description = _customerTypes.Description;
			customerTypes.TenantId = _customerTypes.TenantId;
			customerTypes.IsActivo = _customerTypes.IsActivo;
			if(string.IsNullOrEmpty(customerTypes.Creado)){
				customerTypes.Creado = _context.UserName;
 			}
			if(customerTypes.FechaCreado == null || customerTypes.FechaCreado.Year <= 1900) {
				customerTypes.FechaCreado = DateTime.Now;
			}
			customerTypes.Modificado = _context.UserName;
 			customerTypes.FechaModificado = DateTime.Now;
			
        }
        
        private void scatterFields()
        {
            _customerTypes.Id = customerTypes.Id;
 			_customerTypes.Description = customerTypes.Description;
 			_customerTypes.TenantId = customerTypes.TenantId;
 			_customerTypes.IsActivo = customerTypes.IsActivo;
 			_customerTypes.Creado = customerTypes.Creado;
 			_customerTypes.FechaCreado = customerTypes.FechaCreado;
 			_customerTypes.Modificado = customerTypes.Modificado;
 			_customerTypes.FechaModificado = customerTypes.FechaModificado;
 			
        }
        
        public void Add()
        {
            
            customerTypes = new CustomerTypes();
            customerTypes.TenantId = _context.TenantId;
			if(string.IsNullOrEmpty(customerTypes.Creado)){
				customerTypes.Creado = _context.UserName;
 			}
			if(customerTypes.FechaCreado == null || customerTypes.FechaCreado.Year <= 1900) {
				customerTypes.FechaCreado = DateTime.Now;
			}
			customerTypes.Modificado = _context.UserName;
 			customerTypes.FechaModificado = DateTime.Now;
			
            //Inicializando el Id se necesita en los id de tipo Guid
            customerTypes.Id = 0;
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
           
            _context.Entry(this.customerTypes).State = EntityState.Detached;
             
            Add();

            customerTypes =  _context.CustomerTypes.Find(Id);
            
             if (customerTypes == null) {
                
                Add();
                
                scatterFields();
                
                
				OnRefresh?.Invoke();
            
                return false;
            }

            _context.Entry(customerTypes).State = EntityState.Modified;
            
            afterSetUserAndCreateDate();

            scatterFields();
            
            
			OnRefresh?.Invoke();
            
            FillDataSource();
            
            return true;
        }  

    }
}
