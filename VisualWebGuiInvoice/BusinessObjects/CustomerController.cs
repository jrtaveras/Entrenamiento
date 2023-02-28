using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSController;
using BusinessObjects;
using System.ComponentModel;
using System.Collections;
using VisualWebGuiInvoice.BusinessObjects.Helpers;

namespace VisualWebGuiInvoice.BusinessObjects
{

    public class CustomerController : Controller, INotifyPropertyChanged
    {
        private readonly Customers _customersEntity;
        public override string ConnectionName
        {
            get
            {
                return base.ConnectionName;
            }
        }

        private Hashtable ht;
        public event RaiseErrorDelegate OnRaiseError;

        public CustomerController()
        {
            _customersEntity = new Customers();
            _customersEntity.AllowThrowExceptionOnSave = true;

            _customersEntity.OnValidate += new FSchad.Tools.CustomsInterfaces.DelValidate(_customersEntity_OnValidate);

            ht = new Hashtable();

            AddNewEntity();
        }

        #region Properties

        public int Id 
        {
            get 
            {
                return _customersEntity.Id ?? 0;
            }
            set 
            {
                _customersEntity.Id = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.Id));
            } 
        }

        public string CustName
        {
            get
            {
                return _customersEntity.CustName;
            }
            set
            {
                _customersEntity.CustName = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.CustName));
            }
        }

        public string Adress 
        {
            get
            {
                return _customersEntity.Adress;
            }
            set
            {
                _customersEntity.Adress = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.Adress));
            }
        }

        public bool Status
        {
            get
            {
                return _customersEntity.Status ?? false;
            }
            set
            {
                _customersEntity.Status = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.Status));
            }
        }

        public int CustomerTypeId
        {
            get
            {
                return _customersEntity.CustomerTypeId ?? 0;
            }
            set
            {
                _customersEntity.CustomerTypeId = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.CustomerTypeId));
            }
        }

        public long TenantId
        {
            get
            {
                return _customersEntity.TenantId ?? 0;
            }
            set
            {
                _customersEntity.TenantId = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.TenantId));
            }
        }

        public bool IsActivo
        {
            get
            {
                return _customersEntity.IsActivo ?? false;
            }
            set
            {
                _customersEntity.IsActivo = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.IsActivo));
            }
        }

        public string Creado 
        {
            get
            {
                return _customersEntity.Creado;
            }
            set
            {
                _customersEntity.Creado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.Creado));
            }
        }

        public DateTime FechaCreado 
        {
            get
            {
                return _customersEntity.FechaCreado ?? DateTime.Now;
            }
            set
            {
                _customersEntity.FechaCreado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.FechaCreado));
            }
        }

        public string Modificado 
        {
            get
            {
                return _customersEntity.Modificado;
            }
            set
            {
                _customersEntity.Modificado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.Modificado));
            }
        }

        public DateTime FechaModificado 
        {
            get
            {
                return _customersEntity.FechaModificado ?? DateTime.Now;
            }
            set
            {
                _customersEntity.FechaModificado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(CustomersMetadata.ColumnNames.FechaModificado));
            }
        }

        #endregion


        public override bool AddNewEntity()
        {
            Id = 0;
            CustName = string.Empty;
            Adress = string.Empty;
            Status = false;
            CustomerTypeId = 0;
                        
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
            if(ids.Length != 1)
            {
                throw new Exception("Los parametros enviados no son válidos");
            }

            _customersEntity.QueryReset();

            bool result = _customersEntity.LoadByPrimaryKey((int)ids[0]);
            if (result)
            {
                Id = _customersEntity.Id.Value;
                CustName = _customersEntity.CustName;
                Adress = _customersEntity.Adress;

                IsActivo = _customersEntity.IsActivo.Value;
                TenantId = _customersEntity.TenantId.Value;
                Creado = _customersEntity.Creado;
                FechaCreado = _customersEntity.FechaCreado.Value;
                Modificado = _customersEntity.Modificado;
                FechaModificado = _customersEntity.FechaModificado.Value;
            }

            return result;
        }

        public override bool SaveEntity()
        {
            _customersEntity.Save();
            if (OnRaiseError != null) 
            { 
                OnRaiseError.Invoke(ht);
            }

            return !_customersEntity.HasError();
        }

        public override System.Data.DataTable LoadDataTable()
        {
            CustomersQuery customersQuery = new CustomersQuery("query");

            customersQuery.SelectAll();
            customersQuery.Where(customersQuery.IsActivo == true);
            customersQuery.OrderBy(customersQuery.CustName.Ascending);

            return customersQuery.LoadDataTable();
        }

        public override bool DeleteEntity(params object[] ids)
        {
            SearchEntity(ids);

            IsActivo = false;
            return SaveEntity();
        }


        void _customersEntity_OnValidate(System.Collections.Hashtable ht)
        {
            this.ht = ht;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }

}
