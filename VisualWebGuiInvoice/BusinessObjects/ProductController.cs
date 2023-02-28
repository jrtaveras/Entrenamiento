using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSController;
using System.ComponentModel;
using BusinessObjects;
using VisualWebGuiInvoice.BusinessObjects.Helpers;

namespace VisualWebGuiInvoice.BusinessObjects
{
    public class ProductController : Controller, INotifyPropertyChanged
    {
        private readonly Products _productsEntity;
        public override string ConnectionString
        {
            get
            {
                return _productsEntity.es.Connection.ConnectionString;
            }
        }

        private System.Collections.Hashtable ht;
        public event RaiseErrorDelegate OnRaiseError;


        #region properties
        public int Id 
        { 
            get { 
              return _productsEntity.Id ?? 0;
            }
            set {
                _productsEntity.Id = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(ProductsMetadata.ColumnNames.Id));
            }
        }

        public string Description
        {
            get
            {
                return _productsEntity.Description;
            }
            set
            {
                _productsEntity.Description = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(ProductsMetadata.ColumnNames.Description));
            }
        }

        public long TenantId
        {
            get
            {
                return _productsEntity.TenantId ?? 0;
            }
            set
            {
                _productsEntity.TenantId = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(ProductsMetadata.ColumnNames.TenantId));
            }
        }

        public bool IsActivo
        {
            get
            {
                return _productsEntity.IsActivo ?? false;
            }
            set
            {
                _productsEntity.IsActivo = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(ProductsMetadata.ColumnNames.IsActivo));
            }
        }

        public string Creado
        {
            get
            {
                return _productsEntity.Creado;
            }
            set
            {
                _productsEntity.Creado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(ProductsMetadata.ColumnNames.Creado));
            }
        }

        public DateTime FechaCreado
        {
            get
            {
                return _productsEntity.FechaCreado ?? DateTime.Now;
            }
            set
            {
                _productsEntity.FechaCreado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(ProductsMetadata.ColumnNames.FechaCreado));
            }
        }

        public string Modificado
        {
            get
            {
                return _productsEntity.Modificado;
            }
            set
            {
                _productsEntity.Modificado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(ProductsMetadata.ColumnNames.Modificado));
            }
        }

        public DateTime FechaModificado
        {
            get
            {
                return _productsEntity.FechaModificado ?? DateTime.Now;
            }
            set
            {
                _productsEntity.FechaModificado = value;
                InvokePropertyChanged(new PropertyChangedEventArgs(ProductsMetadata.ColumnNames.FechaModificado));
            }
        }
        #endregion

        public ProductController()
        {
            _productsEntity = new Products();
            _productsEntity.AllowThrowExceptionOnSave = true;

            _productsEntity.OnValidate += new FSchad.Tools.CustomsInterfaces.DelValidate(_products_OnValidate);
            ht = new System.Collections.Hashtable();

            AddNewEntity();
        }

        void _products_OnValidate(System.Collections.Hashtable ht)
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

            _productsEntity.QueryReset();

            var value = (int)ids[0];
            var result = _productsEntity.LoadByPrimaryKey(value);
            if(result){
                Id = _productsEntity.Id.Value;
                Description = _productsEntity.Description;
                IsActivo = _productsEntity.IsActivo.Value;
                TenantId = _productsEntity.TenantId.Value;
                Creado = _productsEntity.Creado;
                FechaCreado = _productsEntity.FechaCreado.Value;
                Modificado = _productsEntity.Modificado;
                FechaModificado = _productsEntity.FechaModificado.Value;
            }

            return result;
        }


        public override bool SaveEntity()
        {
            _productsEntity.Save();

            if (OnRaiseError != null) 
            {
                OnRaiseError.Invoke(ht);
            }

            return !_productsEntity.HasError();
        }



        public override System.Data.DataTable LoadDataTable()
        {
            ProductsQuery productsQuery = new ProductsQuery("query");
            
            productsQuery.SelectAll();
            productsQuery.Where(productsQuery.IsActivo == true);
            productsQuery.OrderBy(productsQuery.Description.Ascending);

            return productsQuery.LoadDataTable();
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
