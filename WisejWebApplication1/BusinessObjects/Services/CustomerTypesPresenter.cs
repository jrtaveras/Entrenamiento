//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Busines Object  Presenter CustomerTypes
//Fecha:2/20/2023 4:38:14 PM
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
    public partial class CustomerTypesPresenter : IPresenter
    {
        public  CustomerTypesPresenter(IContext context,ICustomerTypes customerTypesSender)
        {
            _context = context;
            
             Resource.Culture = new System.Globalization.CultureInfo(context.LocalizationName);
            
            _customerTypes = customerTypesSender;
            
            _dataSource = customerTypesSender as IDataSource;
            
            _valueToSearch = customerTypesSender as IValueToSearch;
             
            Add();

        }
        
        private void afterSetUserAndCreateDate()
        {
            customerTypes.IsActivo = true;
        }
        
        private void  extendedValidations()
        {
             
            
        }
        
        public bool Find(params object[] sender)
        {
            throw new NotImplementedException("Debe implementar este metodo para poder usarlo");
        }
        
        public void FillDataSource() 
        {
            
            if (_dataSource != null)
            {
                _dataSource.DataGridSource = _context.CustomerTypes.Where( a => a.IsActivo).ToList();
            }
            
        }
        
        public bool Save()
        {
             
            gatherFields();

            var validate = _customerTypes as IValidate;
            
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
            
            var state = _context.Entry(customerTypes).State;
            var found = _context.CustomerTypes.Where(a => a.Id == customerTypes.Id).FirstOrDefault();
            if(found != null && found.FechaModificado >  customerTypes.FechaModificado)
            {
                throw new Exception("There is and update conflict with this record. The version you modified is older than the current record in the database.!!");
            }
            
            if (found == null)
            {
                _context.CustomerTypes.Add(customerTypes);
            }
     
                       
            state = _context.Entry(customerTypes).State;
            
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
            
            if (customerTypes.Id == 0)
            {
                Add();
                
                scatterFields();
                OnRefresh?.Invoke();
                return false;
            }
            
            _customerTypes.IsActivo = false;
            
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
            return _context.CustomerTypes.Where( a => a.IsActivo).ToList().ToDataTable("CustomerTypes").TranslateDataTable(_context.ResourceManager);
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

