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
    public class InvoiceDetailController : Controller, INotifyPropertyChanged
    {
        private readonly InvoiceDetails _InvoiceDetailsEntity;
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
                return _InvoiceDetailsEntity.Id.Value;
            }
            set
            {
                _InvoiceDetailsEntity.Id = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.Id));
            }
        }

        public int InvoiceId
        {
            get
            {
                return _InvoiceDetailsEntity.InvoiceId.Value;
            }
            set
            {
                _InvoiceDetailsEntity.ProductId = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.InvoiceId));
            }
        }

        public int ProductId
        {
            get
            {
                return _InvoiceDetailsEntity.ProductId.Value;
            }
            set
            {
                _InvoiceDetailsEntity.ProductId = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.ProductId));
            }
        }

        public decimal SubTotal
        {
            get
            {
                return _InvoiceDetailsEntity.SubTotal.Value;
            }
            set
            {
                _InvoiceDetailsEntity.SubTotal = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.SubTotal));
            }
        }

        public decimal TotalItbis
        {
            get
            {
                return _InvoiceDetailsEntity.TotalItbis.Value;
            }
            set
            {
                _InvoiceDetailsEntity.TotalItbis = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.TotalItbis));
            }
        }

        public decimal Total
        {
            get
            {
                return _InvoiceDetailsEntity.Total.Value;
            }
            set
            {
                _InvoiceDetailsEntity.Total = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.Total));
            }
        }


        public long TenantId
        {
            get
            {
                return _InvoiceDetailsEntity.TenantId.Value;
            }
            set
            {
                _InvoiceDetailsEntity.TenantId = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.TenantId));
            }
        }

        public bool IsActivo
        {
            get
            {
                return _InvoiceDetailsEntity.IsActivo.Value;
            }
            set
            {
                _InvoiceDetailsEntity.IsActivo = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.IsActivo));
            }
        }

        public string Creado
        {
            get
            {
                return _InvoiceDetailsEntity.Creado;
            }
            set
            {
                _InvoiceDetailsEntity.Creado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.Creado));
            }
        }

        public DateTime FechaCreado
        {
            get
            {
                return _InvoiceDetailsEntity.FechaCreado.Value;
            }
            set
            {
                _InvoiceDetailsEntity.FechaCreado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.FechaCreado));
            }
        }

        public string Modificado
        {
            get
            {
                return _InvoiceDetailsEntity.Modificado;
            }
            set
            {
                _InvoiceDetailsEntity.Modificado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.Modificado));
            }
        }

        public DateTime FechaModificado
        {
            get
            {
                return _InvoiceDetailsEntity.FechaModificado.Value;
            }
            set
            {
                _InvoiceDetailsEntity.FechaModificado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.FechaModificado));
            }
        }

        #endregion



        public InvoiceDetailController()
        {
            _InvoiceDetailsEntity = new InvoiceDetails();
            _InvoiceDetailsEntity.AllowThrowExceptionOnSave = true;

            _InvoiceDetailsEntity.OnValidate += new FSchad.Tools.CustomsInterfaces.DelValidate(_InvoiceDetailsEntity_OnValidate);

            ht = new Hashtable();

            AddNewEntity();
        }
        

        public override bool AddNewEntity()
        {
            Id = 0;
            ProductId = 0;

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

            _InvoiceDetailsEntity.QueryReset();

            bool result = _InvoiceDetailsEntity.LoadByPrimaryKey((int)ids[0]);
            if (result)
            {
                Id = _InvoiceDetailsEntity.Id.Value;
                ProductId = _InvoiceDetailsEntity.ProductId.Value;

                IsActivo = _InvoiceDetailsEntity.IsActivo.Value;
                TenantId = _InvoiceDetailsEntity.TenantId.Value;
                Creado = _InvoiceDetailsEntity.Creado;
                FechaCreado = _InvoiceDetailsEntity.FechaCreado.Value;
                Modificado = _InvoiceDetailsEntity.Modificado;
                FechaModificado = _InvoiceDetailsEntity.FechaModificado.Value;
            }

            return result;
        }

        public override bool SaveEntity()
        {
            _InvoiceDetailsEntity.Save();
            if (OnRaiseError != null)
            {
                OnRaiseError.Invoke(ht);
            }

            return !_InvoiceDetailsEntity.HasError();
        }


        public override System.Data.DataTable LoadDataTable()
        {
            InvoiceDetailsQuery invoiceDetailQuery = new InvoiceDetailsQuery("query");
            ProductsQuery productQuery = new ProductsQuery("products");

            invoiceDetailQuery.Select(invoiceDetailQuery.Id, productQuery.Id.As("Codigo"), productQuery.Description, invoiceDetailQuery.Qty, invoiceDetailQuery.Price, invoiceDetailQuery.SubTotal, invoiceDetailQuery.TotalItbis, invoiceDetailQuery.Total);
            invoiceDetailQuery.InnerJoin(productQuery).On(invoiceDetailQuery.ProductId == productQuery.Id);

            invoiceDetailQuery.Where(invoiceDetailQuery.InvoiceId == InvoiceId && invoiceDetailQuery.IsActivo == true);
            invoiceDetailQuery.OrderBy(invoiceDetailQuery.Id.Descending, productQuery.Id.Ascending);

            return invoiceDetailQuery.LoadDataTable();
        }

        public override bool DeleteEntity(params object[] ids)
        {
            SearchEntity(ids);

            IsActivo = false;
            return SaveEntity();
        }


        void _InvoiceDetailsEntity_OnValidate(System.Collections.Hashtable ht)
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
