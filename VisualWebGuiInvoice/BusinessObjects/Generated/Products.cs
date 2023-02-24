/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 2/23/2023 11:26:55 AM
===============================================================================
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Xml.Serialization;


using EntitySpaces.Core;
using EntitySpaces.Interfaces;
using EntitySpaces.DynamicQuery;
//using FSchad.Tools.CustomClasses;
/* J. R. R. J. Se debe a gregar la referencia de FSchad.Tools para evitar error de compilacion aqui.
*/
using FSchad.Tools.CustomClasses;
using FSchad.Tools.CustomsInterfaces;
using System.Configuration;



namespace BusinessObjects
{

	[Serializable]
	abstract public class esProductsCollection : esEntityCollection
	{
		public esProductsCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "ProductsCollection";
		}

		#region Query Logic
		protected void InitQuery(esProductsQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			query.es2.Connection = ((IEntityCollection)this).Connection;
		}

		protected bool OnQueryLoaded(DataTable table)
		{
			this.PopulateCollection(table);
			return (this.RowCount > 0) ? true : false;
		}
		
		protected override void HookupQuery(esDynamicQuery query)
		{
			this.InitQuery(query as esProductsQuery);
		}
		#endregion
		
		virtual public Products DetachEntity(Products entity)
		{
			return base.DetachEntity(entity) as Products;
		}
		
		virtual public Products AttachEntity(Products entity)
		{
			return base.AttachEntity(entity) as Products;
		}
		
		virtual public void Combine(ProductsCollection collection)
		{
			base.Combine(collection);
		}
		
		new public Products this[int index]
		{
			get
			{
				return base[index] as Products;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(Products);
		}
	}



	[Serializable]
	abstract public class esProducts : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esProductsQuery GetDynamicQuery()
		{
			return null;
		}

		public esProducts()
		{

		}

		public esProducts(DataRow row)
			: base(row)
		{

		}
		//MAS 17/11/2010 para extender validaciones
		public virtual void extendedValidation(System.Collections.Hashtable sender)
		{
		
		}
		
		///genera accion exactamente antes de ejecutar el save.
		public virtual void BeforeSave()
		{
		
		}	
		
		///genera accion exactamente Despues de ejecutar el save.
		public virtual void AfterSave()
		{
		
		}
		
		#region LoadByPrimaryKey
		public virtual bool LoadByPrimaryKey(System.Int32 id)
		{
			if(this.es.Connection.SqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		public virtual bool LoadByPrimaryKey(esSqlAccessType sqlAccessType, System.Int32 id)
		{
			if (sqlAccessType == esSqlAccessType.DynamicSQL)
				return LoadByPrimaryKeyDynamic(id);
			else
				return LoadByPrimaryKeyStoredProcedure(id);
		}

		private bool LoadByPrimaryKeyDynamic(System.Int32 id)
		{
			esProductsQuery query = this.GetDynamicQuery();
			query.Where(query.Id == id);
			return query.Load();
		}

		private bool LoadByPrimaryKeyStoredProcedure(System.Int32 id)
		{
			esParameters parms = new esParameters();
			parms.Add("Id",id);
			return this.Load(esQueryType.StoredProcedure, this.es.spLoadByPrimaryKey, parms);
		}
		#endregion
		
		
		
		#region Properties
		
		
		public override void SetProperties(IDictionary values)
		{
			foreach (string propertyName in values.Keys)
			{
				this.SetProperty(propertyName, values[propertyName]);
			}
		}

		public override void SetProperty(string name, object value)
		{
			if(this.Row == null) this.AddNew();
			
			esColumnMetadata col = this.Meta.Columns.FindByPropertyName(name);
			if (col != null)
			{
				if(value == null || value is System.String)
				{				
					// Use the strongly typed property
					switch (name)
					{							
						case "Id": this.str.Id = (string)value; break;							
						case "Description": this.str.Description = (string)value; break;							
						case "TenantId": this.str.TenantId = (string)value; break;							
						case "IsActivo": this.str.IsActivo = (string)value; break;							
						case "Creado": this.str.Creado = (string)value; break;							
						case "FechaCreado": this.str.FechaCreado = (string)value; break;							
						case "Modificado": this.str.Modificado = (string)value; break;							
						case "FechaModificado": this.str.FechaModificado = (string)value; break;
					}
				}
				else
				{
					switch (name)
					{	
						case "Id":
						
							if (value == null || value is System.Int32)
								this.Id = (System.Int32?)value;
							break;
						
						case "TenantId":
						
							if (value == null || value is System.Int64)
								this.TenantId = (System.Int64?)value;
							break;
						
						case "IsActivo":
						
							if (value == null || value is System.Boolean)
								this.IsActivo = (System.Boolean?)value;
							break;
						
						case "FechaCreado":
						
							if (value == null || value is System.DateTime)
								this.FechaCreado = (System.DateTime?)value;
							break;
						
						case "FechaModificado":
						
							if (value == null || value is System.DateTime)
								this.FechaModificado = (System.DateTime?)value;
							break;
					

						default:
							break;
					}
				}
			}
			else if(this.Row.Table.Columns.Contains(name))
			{
				this.Row[name] = value;
			}
			else
			{
				throw new Exception("SetProperty Error: '" + name + "' not found");
			}
		}
		
		
		/// <summary>
		/// Maps to Products.Id
		/// </summary>
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(ProductsMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt32(ProductsMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to Products.Description
		/// </summary>
		virtual public System.String Description
		{
			get
			{
				return base.GetSystemString(ProductsMetadata.ColumnNames.Description);
			}
			
			set
			{
				base.SetSystemString(ProductsMetadata.ColumnNames.Description, value);
			}
		}
		
		/// <summary>
		/// Maps to Products.TenantId
		/// </summary>
		virtual public System.Int64? TenantId
		{
			get
			{
				return base.GetSystemInt64(ProductsMetadata.ColumnNames.TenantId);
			}
			
			set
			{
				base.SetSystemInt64(ProductsMetadata.ColumnNames.TenantId, value);
			}
		}
		
		/// <summary>
		/// Maps to Products.IsActivo
		/// </summary>
		virtual public System.Boolean? IsActivo
		{
			get
			{
				return base.GetSystemBoolean(ProductsMetadata.ColumnNames.IsActivo);
			}
			
			set
			{
				base.SetSystemBoolean(ProductsMetadata.ColumnNames.IsActivo, value);
			}
		}
		
		/// <summary>
		/// Maps to Products.Creado
		/// </summary>
		virtual public System.String Creado
		{
			get
			{
				return base.GetSystemString(ProductsMetadata.ColumnNames.Creado);
			}
			
			set
			{
				base.SetSystemString(ProductsMetadata.ColumnNames.Creado, value);
			}
		}
		
		/// <summary>
		/// Maps to Products.FechaCreado
		/// </summary>
		virtual public System.DateTime? FechaCreado
		{
			get
			{
				return base.GetSystemDateTime(ProductsMetadata.ColumnNames.FechaCreado);
			}
			
			set
			{
				base.SetSystemDateTime(ProductsMetadata.ColumnNames.FechaCreado, value);
			}
		}
		
		/// <summary>
		/// Maps to Products.Modificado
		/// </summary>
		virtual public System.String Modificado
		{
			get
			{
				return base.GetSystemString(ProductsMetadata.ColumnNames.Modificado);
			}
			
			set
			{
				base.SetSystemString(ProductsMetadata.ColumnNames.Modificado, value);
			}
		}
		
		/// <summary>
		/// Maps to Products.FechaModificado
		/// </summary>
		virtual public System.DateTime? FechaModificado
		{
			get
			{
				return base.GetSystemDateTime(ProductsMetadata.ColumnNames.FechaModificado);
			}
			
			set
			{
				base.SetSystemDateTime(ProductsMetadata.ColumnNames.FechaModificado, value);
			}
		}
		
		#endregion	

		#region String Properties


		[BrowsableAttribute( false )]
		public esStrings str
		{
			get
			{
				if (esstrings == null)
				{
					esstrings = new esStrings(this);
				}
				return esstrings;
			}
		}


		[Serializable]
		sealed public class esStrings
		{
			public esStrings(esProducts entity)
			{
				this.entity = entity;
			}
			
	
			public System.String Id
			{
				get
				{
					System.Int32? data = entity.Id;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Id = null;
					else entity.Id = Convert.ToInt32(value);
				}
			}
				
			public System.String Description
			{
				get
				{
					System.String data = entity.Description;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Description = null;
					else entity.Description = Convert.ToString(value);
				}
			}
				
			public System.String TenantId
			{
				get
				{
					System.Int64? data = entity.TenantId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TenantId = null;
					else entity.TenantId = Convert.ToInt64(value);
				}
			}
				
			public System.String IsActivo
			{
				get
				{
					System.Boolean? data = entity.IsActivo;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.IsActivo = null;
					else entity.IsActivo = Convert.ToBoolean(value);
				}
			}
				
			public System.String Creado
			{
				get
				{
					System.String data = entity.Creado;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Creado = null;
					else entity.Creado = Convert.ToString(value);
				}
			}
				
			public System.String FechaCreado
			{
				get
				{
					System.DateTime? data = entity.FechaCreado;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FechaCreado = null;
					else entity.FechaCreado = Convert.ToDateTime(value);
				}
			}
				
			public System.String Modificado
			{
				get
				{
					System.String data = entity.Modificado;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Modificado = null;
					else entity.Modificado = Convert.ToString(value);
				}
			}
				
			public System.String FechaModificado
			{
				get
				{
					System.DateTime? data = entity.FechaModificado;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.FechaModificado = null;
					else entity.FechaModificado = Convert.ToDateTime(value);
				}
			}
			

			private esProducts entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esProductsQuery query)
		{
			query.OnLoadDelegate = this.OnQueryLoaded;
			query.es2.Connection = ((IEntity)this).Connection;
		}

		[System.Diagnostics.DebuggerNonUserCode]
		protected bool OnQueryLoaded(DataTable table)
		{
			bool dataFound = this.PopulateEntity(table);

			if (this.RowCount > 1)
			{
				throw new Exception("esProducts can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class Products : esProducts
	{

				
		#region InvoiceDetailsCollectionByProductId - Zero To Many
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_InvoiceDetails_Products
		/// </summary>

		[XmlIgnore]
		public InvoiceDetailsCollection InvoiceDetailsCollectionByProductId
		{
			get
			{
				if(this._InvoiceDetailsCollectionByProductId == null)
				{
					this._InvoiceDetailsCollectionByProductId = new InvoiceDetailsCollection();
					this._InvoiceDetailsCollectionByProductId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("InvoiceDetailsCollectionByProductId", this._InvoiceDetailsCollectionByProductId);
				
					if(this.Id != null)
					{
						this._InvoiceDetailsCollectionByProductId.Query.Where(this._InvoiceDetailsCollectionByProductId.Query.ProductId == this.Id);
						this._InvoiceDetailsCollectionByProductId.Query.Load();

						// Auto-hookup Foreign Keys
						this._InvoiceDetailsCollectionByProductId.fks.Add(InvoiceDetailsMetadata.ColumnNames.ProductId, this.Id);
					}
				}

				return this._InvoiceDetailsCollectionByProductId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._InvoiceDetailsCollectionByProductId != null) 
				{ 
					this.RemovePostSave("InvoiceDetailsCollectionByProductId"); 
					this._InvoiceDetailsCollectionByProductId = null;
					
				} 
			} 			
		}

		private InvoiceDetailsCollection _InvoiceDetailsCollectionByProductId;
		#endregion

		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "InvoiceDetailsCollectionByProductId", typeof(InvoiceDetailsCollection), new InvoiceDetails()));
		
			return props;
		}	
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._InvoiceDetailsCollectionByProductId != null)
			{
				foreach(InvoiceDetails obj in this._InvoiceDetailsCollectionByProductId)
				{
					if(obj.es.IsAdded)
					{
						obj.ProductId = this.Id;
					}
				}
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostOneToOneSave.
		/// </summary>
		protected override void ApplyPostOneSaveKeys()
		{
		}
		
	}



	[Serializable]
	abstract public class esProductsQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return ProductsMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, ProductsMetadata.ColumnNames.Id, esSystemType.Int32);
			}
		} 
		
		public esQueryItem Description
		{
			get
			{
				return new esQueryItem(this, ProductsMetadata.ColumnNames.Description, esSystemType.String);
			}
		} 
		
		public esQueryItem TenantId
		{
			get
			{
				return new esQueryItem(this, ProductsMetadata.ColumnNames.TenantId, esSystemType.Int64);
			}
		} 
		
		public esQueryItem IsActivo
		{
			get
			{
				return new esQueryItem(this, ProductsMetadata.ColumnNames.IsActivo, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem Creado
		{
			get
			{
				return new esQueryItem(this, ProductsMetadata.ColumnNames.Creado, esSystemType.String);
			}
		} 
		
		public esQueryItem FechaCreado
		{
			get
			{
				return new esQueryItem(this, ProductsMetadata.ColumnNames.FechaCreado, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem Modificado
		{
			get
			{
				return new esQueryItem(this, ProductsMetadata.ColumnNames.Modificado, esSystemType.String);
			}
		} 
		
		public esQueryItem FechaModificado
		{
			get
			{
				return new esQueryItem(this, ProductsMetadata.ColumnNames.FechaModificado, esSystemType.DateTime);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("ProductsCollection")]
	public partial class ProductsCollection : esProductsCollection, IEnumerable<Products>
	{
		public ProductsCollection()
		{
			//JROMNEY y J.R.T. 2010/06/07 esto se agrego para permitir manejo de multibase de datos, ya
            //que la factoria maneja un singleton y en desarrollo web no es factible por que al 
            //intentar de cambiar de base de datos se cambia para todas la sesiones, ahora
            // estamos armando un conexion string que solo cabiamos en el objeto.
			
			if(allowToChangeDataBase())
			if(FSchad.Tools.Tool.canChangeDataBase(((IEntityCollection)this).Connection.Name)){
				string strProviderMetadataKey = this.es.Connection.ProviderMetadataKey;
				if (string.IsNullOrEmpty(this.Meta.GetProviderMetadata(strProviderMetadataKey).Catalog) && !string.IsNullOrEmpty(FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName)){
					((IEntityCollection)this).Connection.ConnectionString = esConfigSettings.ConnectionInfo.Connections[FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName].ConnectionString;
					((IEntityCollection)this).Connection.Name = esConfigSettings.ConnectionInfo.Connections[FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName].Name;
				}
			}
		}
		private bool allowToChangeDataBase() {
            string result = ConfigurationSettings.AppSettings["AllowToChangeDatabase"];
            if(!string.IsNullOrEmpty(result))
                return Convert.ToBoolean(result);
            else
                return true;
        }
		public static implicit operator List<Products>(ProductsCollection coll)
		{
			List<Products> list = new List<Products>();
			
			foreach (Products emp in coll)
			{
				list.Add(emp);
			}
			
			return list;
		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return  ProductsMetadata.Meta();
			}
		}
		
		
		override protected string GetConnectionName()
		{
			return "SQLDynamic";
		}
		
		override protected esDynamicQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ProductsQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new Products(row);
		}

		override protected esEntity CreateEntity()
		{
			return new Products();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public ProductsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductsQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(ProductsQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public Products AddNew()
		{
			Products entity = base.AddNewEntity() as Products;
			
			return entity;
		}

		public Products FindByPrimaryKey(System.Int32 id)
		{
			return base.FindByPrimaryKey(id) as Products;
		}


		#region IEnumerable<Products> Members

		IEnumerator<Products> IEnumerable<Products>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as Products;
			}
		}

		#endregion
		
		private ProductsQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Products' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("Products ({Id})")]
	[Serializable]
	public partial class Products : esProducts
	{
		private bool allowThrowExceptionOnSave = false;
        //propiedad para ver error que devuelve al grabar
        public bool AllowThrowExceptionOnSave
        {
            get { return allowThrowExceptionOnSave; }
            set { allowThrowExceptionOnSave = value; }
        }
		
		//J.R.T y RPERALTA 2016/03/31
		public IMetadata GetMeta { get {return this.Meta;} }
		
		private bool allowToChangeDataBase() {
            string result = ConfigurationSettings.AppSettings["AllowToChangeDatabase"];
            if(!string.IsNullOrEmpty(result))
                return Convert.ToBoolean(result);
            else
                return true;
        }

		#region Custom variables by FSchad
		private string _lastError = string.Empty;
		private string strError = string.Empty;
        private bool _isValid = true;
        public Hashtable oHashtableErrorList = new Hashtable();
        public event DelValidate OnValidate = null;
		#endregion
		public Products()
		{
			//JROMNEY y J.R.T. 2010/06/07 esto se agrego para permitir manejo de multibase de datos, ya
            //que la factoria maneja un singleton y en desarrollo web no es factible por que al 
            //intentar de cambiar de base de datos se cambia para todas la sesiones, ahora
            // estamos armando un conexion string que solo cabiamos en el objeto.
			if(allowToChangeDataBase())
			if(FSchad.Tools.Tool.canChangeDataBase(((IEntity)this).Connection.Name)){
				string strProviderMetadataKey = this.es.Connection.ProviderMetadataKey;
				if (string.IsNullOrEmpty(this.Meta.GetProviderMetadata(strProviderMetadataKey).Catalog) && !string.IsNullOrEmpty(FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName)){
					((IEntity)this).Connection.ConnectionString = esConfigSettings.ConnectionInfo.Connections[FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName].ConnectionString;
					((IEntity)this).Connection.Name = esConfigSettings.ConnectionInfo.Connections[FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName].Name;
				}
			}
			//J.R.T 2016/03/31
			this.Query.es.WithNoLock = true;
		}
	
		public Products(DataRow row)
			: base(row)
		{
			//JROMNEY y J.R.T. 2010/06/07 esto se agrego para permitir manejo de multibase de datos, ya
            //que la factoria maneja un singleton y en desarrollo web no es factible por que al 
            //intentar de cambiar de base de datos se cambia para todas la sesiones, ahora
            // estamos armando un conexion string que solo cabiamos en el objeto.
			if(allowToChangeDataBase())
			if(FSchad.Tools.Tool.canChangeDataBase(((IEntity)this).Connection.Name)){
				string strProviderMetadataKey = this.es.Connection.ProviderMetadataKey;
				if (string.IsNullOrEmpty(this.Meta.GetProviderMetadata(strProviderMetadataKey).Catalog) && !string.IsNullOrEmpty(FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName)){
					((IEntity)this).Connection.ConnectionString = esConfigSettings.ConnectionInfo.Connections[FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName].ConnectionString;
					((IEntity)this).Connection.Name = esConfigSettings.ConnectionInfo.Connections[FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName].Name;
				}
			}
			//J.R.T 2016/03/31
			this.Query.es.WithNoLock = true;
		}
		
		#region Housekeeping methods
		override protected IMetadata Meta
		{
			get
			{
				return ProductsMetadata.Meta();
			}
		}
		
		
		override protected string GetConnectionName()
		{
			return "SQLDynamic";
		}
		
		override protected esProductsQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new ProductsQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public ProductsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new ProductsQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(ProductsQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private ProductsQuery query;
		
		#region Custom methods by FSchad
        public string Error 
        {
            get { return _lastError; }
        
        }	
		
        public override void Save()
        {
           
            try
            {
				if (!this.es.IsDeleted) 
				{
					if (IsValid())
					{
						this.BeforeSave();
						base.Save();
						this.AfterSave();						
					}
				}
				else 
				{
					this.BeforeSave();
					base.Save();
					this.AfterSave();						
				}
			}
				
            catch (Exception objError)
            {
				oHashtableErrorList = new Hashtable();
				this._isValid = false;
                _lastError = ClassBOConst.UNSUCCESSFULL;
                oHashtableErrorList.Add(ClassBOConst.LAST_ERROR,  objError.Message +_lastError);
				if ( OnValidate != null) {
					OnValidate(oHashtableErrorList);
				}
				//Si hay un error lanza un throw para arriba
				if(AllowThrowExceptionOnSave)
                    throw new Exception(ClassBOConst.LAST_ERROR + " "+  objError.Message + _lastError );
            }
        }		

        string this[string columnName] 
        {
			get
			{
				strError = string.Empty;
				validateEntity(columnName);
				
				return strError;
			}
                 
        }
        
        
       
        public bool IsValid()
        {
            this._isValid = true;
            ValidateProperties();

            if (_isValid)
            {
                _lastError = ClassBOConst.SUCCESSFULL;
            }
            else 
            {
                _lastError = ClassBOConst.UNSUCCESSFULL;
                
            }

            oHashtableErrorList.Add(ClassBOConst.LAST_ERROR, Error);
			
			if ( OnValidate != null) {
					OnValidate(oHashtableErrorList);
			}
            
            return _isValid;
         
        }
		//MAS 17/11/2010 para extender validaciones
        public void ValidateProperties()
        {
			oHashtableErrorList = new Hashtable();
				   
						oHashtableErrorList.Add(ProductsMetadata.ColumnNames.Id, this[ProductsMetadata.ColumnNames.Id]); 
				   
						oHashtableErrorList.Add(ProductsMetadata.ColumnNames.Description, this[ProductsMetadata.ColumnNames.Description]); 
				   
						oHashtableErrorList.Add(ProductsMetadata.ColumnNames.TenantId, this[ProductsMetadata.ColumnNames.TenantId]); 
				   
						oHashtableErrorList.Add(ProductsMetadata.ColumnNames.IsActivo, this[ProductsMetadata.ColumnNames.IsActivo]); 
				   
						oHashtableErrorList.Add(ProductsMetadata.ColumnNames.Creado, this[ProductsMetadata.ColumnNames.Creado]); 
				   
						oHashtableErrorList.Add(ProductsMetadata.ColumnNames.FechaCreado, this[ProductsMetadata.ColumnNames.FechaCreado]); 
				   
						oHashtableErrorList.Add(ProductsMetadata.ColumnNames.Modificado, this[ProductsMetadata.ColumnNames.Modificado]); 
				   
						oHashtableErrorList.Add(ProductsMetadata.ColumnNames.FechaModificado, this[ProductsMetadata.ColumnNames.FechaModificado]); 
			
			extendedValidation(oHashtableErrorList);
		}	
		

		public bool HasError()
		{
				return (_lastError == ClassBOConst.UNSUCCESSFULL);
            
		}

	   #endregion
	}



    [System.Diagnostics.DebuggerDisplay("LastQuery = {es.LastQuery}")]
	[Serializable]
		
	public partial class ProductsQuery : esProductsQuery
	{
		public ProductsQuery()
		{
			//JROMNEY y J.R.T. 2010/06/07 esto se agrego para permitir manejo de multibase de datos, ya
            //que la factoria maneja un singleton y en desarrollo web no es factible por que al 
            //intentar de cambiar de base de datos se cambia para todas la sesiones, ahora
            // estamos armando un conexion string que solo cambiamos en el objeto.
			
			//JROMNEY y J.R.T. 2010/09/16
			//En los Query el catalogo llega nulo aunque se especifique
			if(allowToChangeDataBase())
			if(FSchad.Tools.Tool.canChangeDataBase(this.es2.Connection.Name)){
				string strProviderMetadataKey = this.es2.Connection.ProviderMetadataKey;
				if (string.IsNullOrEmpty(this.Meta.GetProviderMetadata(strProviderMetadataKey).Catalog) && !string.IsNullOrEmpty(FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName)){
					this.es2.Connection.ConnectionString = esConfigSettings.ConnectionInfo.Connections[FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName].ConnectionString;
					this.es2.Connection.Name = esConfigSettings.ConnectionInfo.Connections[FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName].Name;
				}
			}
			//J.R.T 2016/03/31
			this.es.WithNoLock = true;

		}		
		
		public ProductsQuery(string joinAlias)
		{
			//JROMNEY y J.R.T. 2010/06/07 esto se agrego para permitir manejo de multibase de datos, ya
            //que la factoria maneja un singleton y en desarrollo web no es factible por que al 
            //intentar de cambiar de base de datos se cambia para todas la sesiones, ahora
            // estamos armando un conexion string que solo cambiamos en el objeto.
			
			//JROMNEY y J.R.T. 2010/09/16
			//En los Query el catalogo llega nulo aunque se especifique
			if(allowToChangeDataBase())
			if(FSchad.Tools.Tool.canChangeDataBase(this.es2.Connection.Name)){
			string strProviderMetadataKey = this.es2.Connection.ProviderMetadataKey;
				if (string.IsNullOrEmpty(this.Meta.GetProviderMetadata(strProviderMetadataKey).Catalog) && !string.IsNullOrEmpty(FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName)){
					this.es2.Connection.ConnectionString = esConfigSettings.ConnectionInfo.Connections[FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName].ConnectionString;
					this.es2.Connection.Name = esConfigSettings.ConnectionInfo.Connections[FSchad.Tools.Tool.CurrentEnvironment.CurrentConnectionName].Name;
				}
		   }
			this.es.JoinAlias = joinAlias;
		}	
		private bool allowToChangeDataBase() {
            string result = ConfigurationSettings.AppSettings["AllowToChangeDatabase"];
            if(!string.IsNullOrEmpty(result))
                return Convert.ToBoolean(result);
            else
                return true;
        }
        override protected string GetQueryName()
        {
            return "ProductsQuery";
        }
		
		
		override protected string GetConnectionName()
		{
			return "SQLDynamic";
		}	
	}


	[Serializable]
	public partial class ProductsMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected ProductsMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(ProductsMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = ProductsMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.Description, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductsMetadata.PropertyNames.Description;
			c.CharacterMaxLength = 70;
			_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.TenantId, 2, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = ProductsMetadata.PropertyNames.TenantId;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.IsActivo, 3, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = ProductsMetadata.PropertyNames.IsActivo;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.Creado, 4, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductsMetadata.PropertyNames.Creado;
			c.CharacterMaxLength = 40;
			c.HasDefault = true;
			c.Default = @"('rperalta')";
			_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.FechaCreado, 5, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = ProductsMetadata.PropertyNames.FechaCreado;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.Modificado, 6, typeof(System.String), esSystemType.String);
			c.PropertyName = ProductsMetadata.PropertyNames.Modificado;
			c.CharacterMaxLength = 40;
			c.HasDefault = true;
			c.Default = @"('rperalta')";
			_columns.Add(c);
				
			c = new esColumnMetadata(ProductsMetadata.ColumnNames.FechaModificado, 7, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = ProductsMetadata.PropertyNames.FechaModificado;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			_columns.Add(c);
				
		}
		#endregion	
	
		static public ProductsMetadata Meta()
		{
			return meta;
		}	
		
		public Guid DataID
		{
			get { return base._dataID; }
		}	
		
		public bool MultiProviderMode
		{
			get { return false; }
		}		

		public esColumnMetadataCollection Columns
		{
			get	{ return base._columns; }
		}
		
		#region ColumnNames
		public class ColumnNames
		{ 
			 public const string Id = "Id";
			 public const string Description = "Description";
			 public const string TenantId = "TenantId";
			 public const string IsActivo = "IsActivo";
			 public const string Creado = "Creado";
			 public const string FechaCreado = "FechaCreado";
			 public const string Modificado = "Modificado";
			 public const string FechaModificado = "FechaModificado";
		}
		#endregion	
		
		#region PropertyNames
		public class PropertyNames
		{ 
			 public const string Id = "Id";
			 public const string Description = "Description";
			 public const string TenantId = "TenantId";
			 public const string IsActivo = "IsActivo";
			 public const string Creado = "Creado";
			 public const string FechaCreado = "FechaCreado";
			 public const string Modificado = "Modificado";
			 public const string FechaModificado = "FechaModificado";
		}
		#endregion	

		public esProviderSpecificMetadata GetProviderMetadata(string mapName)
		{
			MapToMeta mapMethod = mapDelegates[mapName];

			if (mapMethod != null)
				return mapMethod(mapName);
			else
				return null;
		}
		
		#region MAP esDefault
		
		static private int RegisterDelegateesDefault()
		{
			// This is only executed once per the life of the application
			lock (typeof(ProductsMetadata))
			{
				if(ProductsMetadata.mapDelegates == null)
				{
					ProductsMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (ProductsMetadata.meta == null)
				{
					ProductsMetadata.meta = new ProductsMetadata();
				}
				
				MapToMeta mapMethod = new MapToMeta(meta.esDefault);
				mapDelegates.Add("esDefault", mapMethod);
				mapMethod("esDefault");
			}
			return 0;
		}			

		private esProviderSpecificMetadata esDefault(string mapName)
		{
			if(!_providerMetadataMaps.ContainsKey(mapName))
			{
				esProviderSpecificMetadata meta = new esProviderSpecificMetadata();
				

				meta.AddTypeMap("Id", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Description", new esTypeMap("varchar", "System.String"));
				meta.AddTypeMap("TenantId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("IsActivo", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("Creado", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FechaCreado", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Modificado", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FechaModificado", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "Products";
				meta.Destination = "Products";
				
				meta.spInsert = "proc_ProductsInsert";				
				meta.spUpdate = "proc_ProductsUpdate";		
				meta.spDelete = "proc_ProductsDelete";
				meta.spLoadAll = "proc_ProductsLoadAll";
				meta.spLoadByPrimaryKey = "proc_ProductsLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private ProductsMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
