//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Busines Object  Presenter InvoiceDetails
//Fecha:2/21/2023 2:50:38 PM
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
    public partial class InvoiceDetailsPresenter : IPresenter
    {
        public  InvoiceDetailsPresenter(IContext context,IInvoiceDetails invoiceDetailsSender)
        {
            _context = context;
            
             Resource.Culture = new System.Globalization.CultureInfo(context.LocalizationName);
            
            _invoiceDetails = invoiceDetailsSender;
            
            _dataSource = invoiceDetailsSender as IDataSource;
            
            _valueToSearch = invoiceDetailsSender as IValueToSearch;
             
            Add();

        }
        
        private void afterSetUserAndCreateDate()
        {
            invoiceDetails.IsActivo = true;
        }
        
        private void  extendedValidations()
        {
             
            if (invoiceDetails.InvoiceId  == 0)
			{
				var fields = new List<string>();
				fields.Add(nameof(InvoiceDetails.InvoiceId));
				ValidationResult validationInvoiceId = new ValidationResult("Debe seleccionar el InvoiceId!!",fields);
				ValidationResult.Add(validationInvoiceId);
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
                _dataSource.DataGridSource = _context.InvoiceDetails.Where( a => a.IsActivo && a.InvoiceId == this._invoiceDetails.InvoiceId).ToList();
            }
            
        }
        
        public bool Save()
        {
            Calcular();
            gatherFields();

            var validate = _invoiceDetails as IValidate;
            
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
            
            var state = _context.Entry(invoiceDetails).State;
            var found = _context.InvoiceDetails.Where(a => a.Id == invoiceDetails.Id).FirstOrDefault();
            if(found != null && found.FechaModificado >  invoiceDetails.FechaModificado)
            {
                throw new Exception("There is and update conflict with this record. The version you modified is older than the current record in the database.!!");
            }
            
            if (found == null)
            {
                _context.InvoiceDetails.Add(invoiceDetails);
            }
     
                       
            state = _context.Entry(invoiceDetails).State;
            
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

        private void Calcular()
        {
            _invoiceDetails.SubTotal = _invoiceDetails.Qty * _invoiceDetails.Price;
            _invoiceDetails.TotalItbis = _invoiceDetails.SubTotal * 0.18m;
            _invoiceDetails.Total = _invoiceDetails.SubTotal + _invoiceDetails.TotalItbis;
        }

        public bool Delete()
        {
            
            if (invoiceDetails.Id == 0)
            {
                Add();
                
                scatterFields();
                OnRefresh?.Invoke();
                return false;
            }
            
            _invoiceDetails.IsActivo = false;
            
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
            return _context.InvoiceDetails.Where( a => a.IsActivo).ToList().ToDataTable("InvoiceDetails").TranslateDataTable(_context.ResourceManager);
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

