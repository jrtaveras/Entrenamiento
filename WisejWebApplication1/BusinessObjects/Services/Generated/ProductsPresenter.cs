//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Busines Object  Presenter Products
//Fecha:2/22/2023 8:17:55 AM
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
    public partial class ProductsPresenter 
    {
        private readonly IContext _context;
        public ICollection<ValidationResult> ValidationResult { get; set; }
        private readonly HelperValidateEntity helperValidateEntity = new HelperValidateEntity();
        private Products products { get; set; }
        private IProducts _products;
        public event Validate BeforeSave;
        public event Validate AfterSave;
        public event RaiseRefresh OnRefresh;
        
        public object DataSource {get;set;}
        private IDataSource _dataSource;
        private IValueToSearch _valueToSearch;
                        
        private bool validateService()
        {
            return helperValidateEntity.ValidateService(products);
        }

        private void gatherFields()
        {
            
            products.Id = _products.Id;
			products.Description = _products.Description;
			products.TenantId = _products.TenantId;
			products.IsActivo = _products.IsActivo;
			if(string.IsNullOrEmpty(products.Creado)){
				products.Creado = _context.UserName;
 			}
			if(products.FechaCreado == null || products.FechaCreado.Year <= 1900) {
				products.FechaCreado = DateTime.Now;
			}
			products.Modificado = _context.UserName;
 			products.FechaModificado = DateTime.Now;
			
        }
        
        private void scatterFields()
        {
            _products.Id = products.Id;
 			_products.Description = products.Description;
 			_products.TenantId = products.TenantId;
 			_products.IsActivo = products.IsActivo;
 			_products.Creado = products.Creado;
 			_products.FechaCreado = products.FechaCreado;
 			_products.Modificado = products.Modificado;
 			_products.FechaModificado = products.FechaModificado;
 			
        }
        
        public void Add()
        {
            
            products = new Products();
            products.TenantId = _context.TenantId;
			if(string.IsNullOrEmpty(products.Creado)){
				products.Creado = _context.UserName;
 			}
			if(products.FechaCreado == null || products.FechaCreado.Year <= 1900) {
				products.FechaCreado = DateTime.Now;
			}
			products.Modificado = _context.UserName;
 			products.FechaModificado = DateTime.Now;
			
            //Inicializando el Id se necesita en los id de tipo Guid
            products.Id = 0;
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
           
            _context.Entry(this.products).State = EntityState.Detached;
             
            Add();

            products =  _context.Products.Find(Id);
            
             if (products == null) {
                
                Add();
                
                scatterFields();
                
                
				OnRefresh?.Invoke();
            
                return false;
            }

            _context.Entry(products).State = EntityState.Modified;
            
            afterSetUserAndCreateDate();

            scatterFields();
            
            
			OnRefresh?.Invoke();
            
            FillDataSource();
            
            return true;
        }  

    }
}
