//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Busines Object  Presenter Invoices
//Fecha:2/21/2023 2:43:35 PM
//Frederic Schad (Todos los derechos Reservados)

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BusinessObjects.Helpers;
using BusinessObjects.Models;
using BusinessObjects.Interfaces;
using System.Data;

namespace  BusinessObjects.Services
{
    public partial class InvoicesPresenter : IPresenter
    {
        public  InvoicesPresenter(IContext context,IInvoices invoicesSender)
        {
            _context = context;
            
             Resource.Culture = new System.Globalization.CultureInfo(context.LocalizationName);
            
            _invoices = invoicesSender;
            
            _dataSource = invoicesSender as IDataSource;
            
            _valueToSearch = invoicesSender as IValueToSearch;
             
            Add();

        }
        
        private void afterSetUserAndCreateDate()
        {
            invoices.IsActivo = true;
        }
        
        private void  extendedValidations()
        {
             
            if (invoices.CustomerId  == 0)
			{
				var fields = new List<string>();
				fields.Add(nameof(Invoices.CustomerId));
				ValidationResult validationCustomerId = new ValidationResult("Debe seleccionar el CustomerId!!",fields);
				ValidationResult.Add(validationCustomerId);
			}
			
			
        }
        
        public bool Find(params object[] sender)
        {
            throw new NotImplementedException("Debe implementar este metodo para poder usarlo");
        }
        
        public void FillDataSource() 
        {
            
            if (_dataSource != null)
            {
                _dataSource.DataGridSource = _context.Invoices.Where( a => a.IsActivo).ToList();
            }
            
        }
        
        public bool Save()
        {
             
            gatherFields();

            var validate = _invoices as IValidate;
            
            if(validate == null)
            {
                throw new Exception("El control inyectado a este presenter debe implementar la interface IValidate");
            }
            
            ValidationResult = new List<ValidationResult>();
            
            validate.ClearErrorsValidations();
            
            validateService();
            
            ValidationResult = helperValidateEntity.ValidationResult;

            extendedValidations();
			 
			if (ValidationResult.Count != 0)
            {
                validate.ShowErrors();
                return false;
            }
            
            var state = _context.Entry(invoices).State;
            var found = _context.Invoices.Where(a => a.Id == invoices.Id).FirstOrDefault();
            if(found != null && found.FechaModificado >  invoices.FechaModificado)
            {
                throw new Exception("There is and update conflict with this record. The version you modified is older than the current record in the database.!!");
            }
            
            if (found == null)
            {
                _context.Invoices.Add(invoices);
            }
     
                       
            state = _context.Entry(invoices).State;
            
            BeforeSave?.Invoke();

            bool result = false;
            
            try
            {
                result = _context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                 _context.DetachAllEntities();

                throw ex;
            }
           
            if (result && state == EntityState.Deleted)
                Add();
            
            scatterFields();
            
            FillDataSource();

            if(result)
            {
                AfterSave?.Invoke();
                OnRefresh?.Invoke();
            }
                
            return result;

        }



        public bool Delete()
        {
            
            if (invoices.Id == 0)
            {
                Add();
                
                scatterFields();
                OnRefresh?.Invoke();
                return false;
            }
            
            _invoices.IsActivo = false;
            
            bool result = Save();
    
            if(result)
            {
                Add();
                OnRefresh?.Invoke();
                FillDataSource();
            }

            return result;

        }
        
        public DataTable GetDataTable()
        {
            return _context.Invoices.Where( a => a.IsActivo).ToList().ToDataTable("Invoices").TranslateDataTable(_context.ResourceManager);
        }
        
        private void translate(DataTable sender)
        {
            foreach (DataColumn item in sender.Columns)
            {
                item.Caption = _context.ResourceManager.GetString(item.ColumnName) ?? item.Caption;
            }
        }
    
    }
}

