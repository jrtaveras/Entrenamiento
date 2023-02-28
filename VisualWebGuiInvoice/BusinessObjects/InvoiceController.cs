using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSController;
using System.ComponentModel;
using BusinessObjects;
using System.Collections;
using VisualWebGuiInvoice.BusinessObjects.Helpers;

namespace VisualWebGuiInvoice.BusinessObjects
{
    public class InvoiceController : Controller, INotifyPropertyChanged
    {
        private readonly Invoices _InvoiceEntity;
        public override string ConnectionName
        {
            get
            {
                return base.ConnectionName;
            }
        }

        private Hashtable ht;
        public event RaiseErrorDelegate OnRaiseError;


        #region Properties

        public int Id
        {
            get
            {
                return _InvoiceEntity.Id ?? 0;
            }
            set
            {
                _InvoiceEntity.Id = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.Id));
            }
        }

        public int CustomerId
        {
            get
            {
                return _InvoiceEntity.CustomerId ?? 0;
            }
            set
            {
                _InvoiceEntity.CustomerId = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.CustomerId));
            }
        }

        public decimal SubTotal
        {
            get
            {
                return _InvoiceEntity.SubTotal ?? 0;
            }
            set
            {
                _InvoiceEntity.SubTotal = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.SubTotal));
            }
        }

        public decimal TotalItbis
        {
            get
            {
                return _InvoiceEntity.TotalItbis ?? 0;
            }
            set
            {
                _InvoiceEntity.TotalItbis = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.TotalItbis));
            }
        }

        public decimal Total
        {
            get
            {
                return _InvoiceEntity.Total ?? 0;
            }
            set
            {
                _InvoiceEntity.Total = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.Total));
            }
        }


        public long TenantId
        {
            get
            {
                return _InvoiceEntity.TenantId ?? 0;
            }
            set
            {
                _InvoiceEntity.TenantId = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.TenantId));
            }
        }

        public bool IsActivo
        {
            get
            {
                return _InvoiceEntity.IsActivo ?? false;
            }
            set
            {
                _InvoiceEntity.IsActivo = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.IsActivo));
            }
        }

        public string Creado
        {
            get
            {
                return _InvoiceEntity.Creado;
            }
            set
            {
                _InvoiceEntity.Creado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.Creado));
            }
        }

        public DateTime FechaCreado
        {
            get
            {
                return _InvoiceEntity.FechaCreado ?? DateTime.Now;
            }
            set
            {
                _InvoiceEntity.FechaCreado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.FechaCreado));
            }
        }

        public string Modificado
        {
            get
            {
                return _InvoiceEntity.Modificado;
            }
            set
            {
                _InvoiceEntity.Modificado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.Modificado));
            }
        }

        public DateTime FechaModificado
        {
            get
            {
                return _InvoiceEntity.FechaModificado ?? DateTime.Now;
            }
            set
            {
                _InvoiceEntity.FechaModificado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoicesMetadata.ColumnNames.FechaModificado));
            }
        }

        #endregion



        public InvoiceController()
        {
            _InvoiceEntity = new Invoices();
            _InvoiceEntity.AllowThrowExceptionOnSave = true;

            _InvoiceEntity.OnValidate += new FSchad.Tools.CustomsInterfaces.DelValidate(_InvoicesEntity_OnValidate);

            ht = new Hashtable();

            AddNewEntity();
        }
        

        public override bool AddNewEntity()
        {
            Id = 0;
            CustomerId = 0;

            SubTotal = 0;
            TotalItbis = 0;
            Total = 0;

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
                throw new Exception("Los parametros enviados no son válidos");
            }

            _InvoiceEntity.QueryReset();

            bool result = _InvoiceEntity.LoadByPrimaryKey((int)ids[0]);
            if (result)
            {
                Id = _InvoiceEntity.Id.Value;
                CustomerId = _InvoiceEntity.CustomerId.Value;

                IsActivo = _InvoiceEntity.IsActivo.Value;
                TenantId = _InvoiceEntity.TenantId.Value;
                Creado = _InvoiceEntity.Creado;
                FechaCreado = _InvoiceEntity.FechaCreado.Value;
                Modificado = _InvoiceEntity.Modificado;
                FechaModificado = _InvoiceEntity.FechaModificado.Value;
            }

            return result;
        }

        public override bool SaveEntity()
        {
            _InvoiceEntity.Save();
            if (OnRaiseError != null)
            {
                OnRaiseError.Invoke(ht);
            }

            return !_InvoiceEntity.HasError();
        }


        public override bool DeleteEntity(params object[] ids)
        {
            SearchEntity(ids);

            IsActivo = false;
            return SaveEntity();
        }


        void _InvoicesEntity_OnValidate(System.Collections.Hashtable ht)
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
