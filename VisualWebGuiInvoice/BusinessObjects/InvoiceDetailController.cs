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
                return _InvoiceDetailsEntity.Id ?? 0;
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
                return _InvoiceDetailsEntity.InvoiceId ?? 0;
            }
            set
            {
                _InvoiceDetailsEntity.InvoiceId = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.InvoiceId));
            }
        }

        public decimal Price
        {
            get
            {
                return _InvoiceDetailsEntity.Price ?? 0;
            }
            set
            {
                _InvoiceDetailsEntity.Price = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.Price));
                CalculateTotals();
            }
        }

        public int Qty
        {
            get
            {
                return _InvoiceDetailsEntity.Qty ?? 0;
            }
            set
            {
                _InvoiceDetailsEntity.Qty = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.Qty));
                CalculateTotals();
            }
        }

        public int ProductId
        {
            get
            {
                return _InvoiceDetailsEntity.ProductId ?? 0;
            }
            set
            {
                _InvoiceDetailsEntity.ProductId = value;
                //InvokePropertyChanged(new PropertyChangedEventArgs(InvoiceDetailsMetadata.ColumnNames.ProductId));
            }
        }

        public decimal SubTotal
        {
            get
            {
                return _InvoiceDetailsEntity.SubTotal ?? 0;
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
                return _InvoiceDetailsEntity.TotalItbis ?? 0;
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
                return _InvoiceDetailsEntity.Total ?? 0;
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
                return _InvoiceDetailsEntity.TenantId ?? 0;
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
                return _InvoiceDetailsEntity.IsActivo ?? false;
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
                return _InvoiceDetailsEntity.FechaCreado ?? DateTime.Now;
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
                return _InvoiceDetailsEntity.FechaModificado ?? DateTime.Now;
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

            Price = 0;
            Qty = 0;

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

                SubTotal = _InvoiceDetailsEntity.SubTotal.Value;
                TotalItbis = _InvoiceDetailsEntity.TotalItbis.Value;
                Total = _InvoiceDetailsEntity.Total.Value;

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


        private void CalculateTotals() 
        {
            SubTotal = (_InvoiceDetailsEntity.Qty ?? 0) * (_InvoiceDetailsEntity.Price ?? 0);
            TotalItbis = SubTotal * 0.18m;
            Total = SubTotal + TotalItbis;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
}
