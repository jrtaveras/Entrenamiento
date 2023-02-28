using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSController;
using BusinessObjects;
using System.ComponentModel;
using VisualWebGuiInvoice.BusinessObjects.Helpers;

namespace VisualWebGuiInvoice.BusinessObjects
{
    public class CustomerTypeController : Controller, INotifyPropertyChanged
    {
        private readonly CustomerTypes _customerTypes;
        public override string ConnectionString
        {
            get
            {
                return _customerTypes.es.Connection.ConnectionString;
            }
        }

        private System.Collections.Hashtable ht;
        public event RaiseErrorDelegate OnRaiseError;


        #region properties
        public int Id 
        { 
            get { 
              return _customerTypes.Id ?? 0;
            }
            set {
                _customerTypes.Id = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomerTypesMetadata.ColumnNames.Id));
            }
        }

        public string Description
        {
            get
            {
                return _customerTypes.Description;
            }
            set
            {
                _customerTypes.Description = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomerTypesMetadata.ColumnNames.Description));
            }
        }

        public long TenantId
        {
            get
            {
                return _customerTypes.TenantId ?? 0;
            }
            set
            {
                _customerTypes.TenantId = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomerTypesMetadata.ColumnNames.TenantId));
            }
        }

        public bool IsActivo
        {
            get
            {
                return _customerTypes.IsActivo ?? false;
            }
            set
            {
                _customerTypes.IsActivo = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomerTypesMetadata.ColumnNames.IsActivo));
            }
        }

        public string Creado
        {
            get
            {
                return _customerTypes.Creado;
            }
            set
            {
                _customerTypes.Creado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomerTypesMetadata.ColumnNames.Creado));
            }
        }

        public DateTime FechaCreado
        {
            get
            {
                return _customerTypes.FechaCreado ?? DateTime.Now;
            }
            set
            {
                _customerTypes.FechaCreado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomerTypesMetadata.ColumnNames.FechaCreado));
            }
        }

        public string Modificado
        {
            get
            {
                return _customerTypes.Modificado;
            }
            set
            {
                _customerTypes.Modificado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomerTypesMetadata.ColumnNames.Modificado));
            }
        }

        public DateTime FechaModificado
        {
            get
            {
                return _customerTypes.FechaModificado ?? DateTime.Now;
            }
            set
            {
                _customerTypes.FechaModificado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomerTypesMetadata.ColumnNames.FechaModificado));
            }
        }
        #endregion

        public CustomerTypeController()
        {
            _customerTypes = new CustomerTypes();
            _customerTypes.AllowThrowExceptionOnSave = true;

            _customerTypes.OnValidate += new FSchad.Tools.CustomsInterfaces.DelValidate(_customerTypes_OnValidate);
            ht = new System.Collections.Hashtable();

            AddNewEntity();
        }

        void _customerTypes_OnValidate(System.Collections.Hashtable ht)
        {
            this.ht = ht;
        }

        public override bool AddNewEntity()
        {
            Id = 0; 
            Description = String.Empty;
            TenantId = 1;
            
            Creado = FSchad.Tools.Tool.CurrentEnvironment.CurrentUsername;
            FechaCreado = DateTime.Now;

            Modificado = FSchad.Tools.Tool.CurrentEnvironment.CurrentUsername;
            FechaModificado = DateTime.Now;

            IsActivo = true;

            return true;
        }


        public override bool SearchEntity(params object[] ids)
        {
            if (ids.Length != 1) 
            {
                throw new Exception("Los parametros enviados son invalidos");
            }

            _customerTypes.QueryReset();

            var value = (int)ids[0];
            var result = _customerTypes.LoadByPrimaryKey(value);
            if(result){
                Id = _customerTypes.Id.Value;
                Description = _customerTypes.Description;
                IsActivo = _customerTypes.IsActivo.Value;
                TenantId = _customerTypes.TenantId.Value;
                Creado = _customerTypes.Creado;
                FechaCreado = _customerTypes.FechaCreado.Value;
                Modificado = _customerTypes.Modificado;
                FechaModificado = _customerTypes.FechaModificado.Value;
            }

            return result;
        }


        public override bool SaveEntity()
        {
            _customerTypes.Save();

            if (OnRaiseError != null) 
            {
                OnRaiseError.Invoke(ht);
            }

            return !_customerTypes.HasError();
        }



        public override System.Data.DataTable LoadDataTable()
        {
            CustomerTypesQuery customerTypeQuery = new CustomerTypesQuery("query");
            
            customerTypeQuery.SelectAll();
            customerTypeQuery.Where(customerTypeQuery.IsActivo == true);
            customerTypeQuery.OrderBy(customerTypeQuery.Description.Ascending);

            return customerTypeQuery.LoadDataTable();
        }

        public override bool DeleteEntity(params object[] ids)
        {
            SearchEntity(ids);

            IsActivo = false;
            return SaveEntity();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
}
