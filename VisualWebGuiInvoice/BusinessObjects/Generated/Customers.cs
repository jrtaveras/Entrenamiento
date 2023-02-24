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
	abstract public class esCustomersCollection : esEntityCollection
	{
		public esCustomersCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "CustomersCollection";
		}

		#region Query Logic
		protected void InitQuery(esCustomersQuery query)
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
			this.InitQuery(query as esCustomersQuery);
		}
		#endregion
		
		virtual public Customers DetachEntity(Customers entity)
		{
			return base.DetachEntity(entity) as Customers;
		}
		
		virtual public Customers AttachEntity(Customers entity)
		{
			return base.AttachEntity(entity) as Customers;
		}
		
		virtual public void Combine(CustomersCollection collection)
		{
			base.Combine(collection);
		}
		
		new public Customers this[int index]
		{
			get
			{
				return base[index] as Customers;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(Customers);
		}
	}



	[Serializable]
	abstract public class esCustomers : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esCustomersQuery GetDynamicQuery()
		{
			return null;
		}

		public esCustomers()
		{

		}

		public esCustomers(DataRow row)
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
			esCustomersQuery query = this.GetDynamicQuery();
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
						case "CustName": this.str.CustName = (string)value; break;							
						case "Adress": this.str.Adress = (string)value; break;							
						case "Status": this.str.Status = (string)value; break;							
						case "CustomerTypeId": this.str.CustomerTypeId = (string)value; break;							
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
						
						case "Status":
						
							if (value == null || value is System.Boolean)
								this.Status = (System.Boolean?)value;
							break;
						
						case "CustomerTypeId":
						
							if (value == null || value is System.Int32)
								this.CustomerTypeId = (System.Int32?)value;
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
		/// Maps to Customers.Id
		/// </summary>
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(CustomersMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt32(CustomersMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to Customers.CustName
		/// </summary>
		virtual public System.String CustName
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.CustName);
			}
			
			set
			{
				base.SetSystemString(CustomersMetadata.ColumnNames.CustName, value);
			}
		}
		
		/// <summary>
		/// Maps to Customers.Adress
		/// </summary>
		virtual public System.String Adress
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.Adress);
			}
			
			set
			{
				base.SetSystemString(CustomersMetadata.ColumnNames.Adress, value);
			}
		}
		
		/// <summary>
		/// Maps to Customers.Status
		/// </summary>
		virtual public System.Boolean? Status
		{
			get
			{
				return base.GetSystemBoolean(CustomersMetadata.ColumnNames.Status);
			}
			
			set
			{
				base.SetSystemBoolean(CustomersMetadata.ColumnNames.Status, value);
			}
		}
		
		/// <summary>
		/// Maps to Customers.CustomerTypeId
		/// </summary>
		virtual public System.Int32? CustomerTypeId
		{
			get
			{
				return base.GetSystemInt32(CustomersMetadata.ColumnNames.CustomerTypeId);
			}
			
			set
			{
				if(base.SetSystemInt32(CustomersMetadata.ColumnNames.CustomerTypeId, value))
				{
					this._UpToCustomerTypesByCustomerTypeId = null;
				}
			}
		}
		
		/// <summary>
		/// Maps to Customers.TenantId
		/// </summary>
		virtual public System.Int64? TenantId
		{
			get
			{
				return base.GetSystemInt64(CustomersMetadata.ColumnNames.TenantId);
			}
			
			set
			{
				base.SetSystemInt64(CustomersMetadata.ColumnNames.TenantId, value);
			}
		}
		
		/// <summary>
		/// Maps to Customers.IsActivo
		/// </summary>
		virtual public System.Boolean? IsActivo
		{
			get
			{
				return base.GetSystemBoolean(CustomersMetadata.ColumnNames.IsActivo);
			}
			
			set
			{
				base.SetSystemBoolean(CustomersMetadata.ColumnNames.IsActivo, value);
			}
		}
		
		/// <summary>
		/// Maps to Customers.Creado
		/// </summary>
		virtual public System.String Creado
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.Creado);
			}
			
			set
			{
				base.SetSystemString(CustomersMetadata.ColumnNames.Creado, value);
			}
		}
		
		/// <summary>
		/// Maps to Customers.FechaCreado
		/// </summary>
		virtual public System.DateTime? FechaCreado
		{
			get
			{
				return base.GetSystemDateTime(CustomersMetadata.ColumnNames.FechaCreado);
			}
			
			set
			{
				base.SetSystemDateTime(CustomersMetadata.ColumnNames.FechaCreado, value);
			}
		}
		
		/// <summary>
		/// Maps to Customers.Modificado
		/// </summary>
		virtual public System.String Modificado
		{
			get
			{
				return base.GetSystemString(CustomersMetadata.ColumnNames.Modificado);
			}
			
			set
			{
				base.SetSystemString(CustomersMetadata.ColumnNames.Modificado, value);
			}
		}
		
		/// <summary>
		/// Maps to Customers.FechaModificado
		/// </summary>
		virtual public System.DateTime? FechaModificado
		{
			get
			{
				return base.GetSystemDateTime(CustomersMetadata.ColumnNames.FechaModificado);
			}
			
			set
			{
				base.SetSystemDateTime(CustomersMetadata.ColumnNames.FechaModificado, value);
			}
		}
		
		[CLSCompliant(false)]
		internal protected CustomerTypes _UpToCustomerTypesByCustomerTypeId;
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
			public esStrings(esCustomers entity)
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
				
			public System.String CustName
			{
				get
				{
					System.String data = entity.CustName;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustName = null;
					else entity.CustName = Convert.ToString(value);
				}
			}
				
			public System.String Adress
			{
				get
				{
					System.String data = entity.Adress;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Adress = null;
					else entity.Adress = Convert.ToString(value);
				}
			}
				
			public System.String Status
			{
				get
				{
					System.Boolean? data = entity.Status;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Status = null;
					else entity.Status = Convert.ToBoolean(value);
				}
			}
				
			public System.String CustomerTypeId
			{
				get
				{
					System.Int32? data = entity.CustomerTypeId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomerTypeId = null;
					else entity.CustomerTypeId = Convert.ToInt32(value);
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
			

			private esCustomers entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esCustomersQuery query)
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
				throw new Exception("esCustomers can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class Customers : esCustomers
	{

				
		#region InvoicesCollectionByCustomerId - Zero To Many
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_Invoice_Customers
		/// </summary>

		[XmlIgnore]
		public InvoicesCollection InvoicesCollectionByCustomerId
		{
			get
			{
				if(this._InvoicesCollectionByCustomerId == null)
				{
					this._InvoicesCollectionByCustomerId = new InvoicesCollection();
					this._InvoicesCollectionByCustomerId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("InvoicesCollectionByCustomerId", this._InvoicesCollectionByCustomerId);
				
					if(this.Id != null)
					{
						this._InvoicesCollectionByCustomerId.Query.Where(this._InvoicesCollectionByCustomerId.Query.CustomerId == this.Id);
						this._InvoicesCollectionByCustomerId.Query.Load();

						// Auto-hookup Foreign Keys
						this._InvoicesCollectionByCustomerId.fks.Add(InvoicesMetadata.ColumnNames.CustomerId, this.Id);
					}
				}

				return this._InvoicesCollectionByCustomerId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._InvoicesCollectionByCustomerId != null) 
				{ 
					this.RemovePostSave("InvoicesCollectionByCustomerId"); 
					this._InvoicesCollectionByCustomerId = null;
					
				} 
			} 			
		}

		private InvoicesCollection _InvoicesCollectionByCustomerId;
		#endregion

				
		#region UpToCustomerTypesByCustomerTypeId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Customers_CustomerTypes
		/// </summary>

		[XmlIgnore]
		public CustomerTypes UpToCustomerTypesByCustomerTypeId
		{
			get
			{
				if(this._UpToCustomerTypesByCustomerTypeId == null
					&& CustomerTypeId != null					)
				{
					this._UpToCustomerTypesByCustomerTypeId = new CustomerTypes();
					this._UpToCustomerTypesByCustomerTypeId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCustomerTypesByCustomerTypeId", this._UpToCustomerTypesByCustomerTypeId);
					this._UpToCustomerTypesByCustomerTypeId.Query.Where(this._UpToCustomerTypesByCustomerTypeId.Query.Id == this.CustomerTypeId);
					this._UpToCustomerTypesByCustomerTypeId.Query.Load();
				}

				return this._UpToCustomerTypesByCustomerTypeId;
			}
			
			set
			{
				this.RemovePreSave("UpToCustomerTypesByCustomerTypeId");
				

				if(value == null)
				{
					this.CustomerTypeId = null;
					this._UpToCustomerTypesByCustomerTypeId = null;
				}
				else
				{
					this.CustomerTypeId = value.Id;
					this._UpToCustomerTypesByCustomerTypeId = value;
					this.SetPreSave("UpToCustomerTypesByCustomerTypeId", this._UpToCustomerTypesByCustomerTypeId);
				}
				
			}
		}
		#endregion
		

		
		/// <summary>
		/// Used internally by the entity's hierarchical properties.
		/// </summary>
		protected override List<esPropertyDescriptor> GetHierarchicalProperties()
		{
			List<esPropertyDescriptor> props = new List<esPropertyDescriptor>();
			
			props.Add(new esPropertyDescriptor(this, "InvoicesCollectionByCustomerId", typeof(InvoicesCollection), new Invoices()));
		
			return props;
		}	
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToCustomerTypesByCustomerTypeId != null)
			{
				this.CustomerTypeId = this._UpToCustomerTypesByCustomerTypeId.Id;
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._InvoicesCollectionByCustomerId != null)
			{
				foreach(Invoices obj in this._InvoicesCollectionByCustomerId)
				{
					if(obj.es.IsAdded)
					{
						obj.CustomerId = this.Id;
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
	abstract public class esCustomersQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return CustomersMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.Id, esSystemType.Int32);
			}
		} 
		
		public esQueryItem CustName
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.CustName, esSystemType.String);
			}
		} 
		
		public esQueryItem Adress
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.Adress, esSystemType.String);
			}
		} 
		
		public esQueryItem Status
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.Status, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem CustomerTypeId
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.CustomerTypeId, esSystemType.Int32);
			}
		} 
		
		public esQueryItem TenantId
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.TenantId, esSystemType.Int64);
			}
		} 
		
		public esQueryItem IsActivo
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.IsActivo, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem Creado
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.Creado, esSystemType.String);
			}
		} 
		
		public esQueryItem FechaCreado
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.FechaCreado, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem Modificado
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.Modificado, esSystemType.String);
			}
		} 
		
		public esQueryItem FechaModificado
		{
			get
			{
				return new esQueryItem(this, CustomersMetadata.ColumnNames.FechaModificado, esSystemType.DateTime);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("CustomersCollection")]
	public partial class CustomersCollection : esCustomersCollection, IEnumerable<Customers>
	{
		public CustomersCollection()
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
		public static implicit operator List<Customers>(CustomersCollection coll)
		{
			List<Customers> list = new List<Customers>();
			
			foreach (Customers emp in coll)
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
				return  CustomersMetadata.Meta();
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
				this.query = new CustomersQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new Customers(row);
		}

		override protected esEntity CreateEntity()
		{
			return new Customers();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public CustomersQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomersQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(CustomersQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public Customers AddNew()
		{
			Customers entity = base.AddNewEntity() as Customers;
			
			return entity;
		}

		public Customers FindByPrimaryKey(System.Int32 id)
		{
			return base.FindByPrimaryKey(id) as Customers;
		}


		#region IEnumerable<Customers> Members

		IEnumerator<Customers> IEnumerable<Customers>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as Customers;
			}
		}

		#endregion
		
		private CustomersQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Customers' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("Customers ({Id})")]
	[Serializable]
	public partial class Customers : esCustomers
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
		public Customers()
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
	
		public Customers(DataRow row)
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
				return CustomersMetadata.Meta();
			}
		}
		
		
		override protected string GetConnectionName()
		{
			return "SQLDynamic";
		}
		
		override protected esCustomersQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new CustomersQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public CustomersQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new CustomersQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(CustomersQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private CustomersQuery query;
		
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
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.Id, this[CustomersMetadata.ColumnNames.Id]); 
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.CustName, this[CustomersMetadata.ColumnNames.CustName]); 
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.Adress, this[CustomersMetadata.ColumnNames.Adress]); 
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.Status, this[CustomersMetadata.ColumnNames.Status]); 
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.CustomerTypeId, this[CustomersMetadata.ColumnNames.CustomerTypeId]); 
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.TenantId, this[CustomersMetadata.ColumnNames.TenantId]); 
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.IsActivo, this[CustomersMetadata.ColumnNames.IsActivo]); 
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.Creado, this[CustomersMetadata.ColumnNames.Creado]); 
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.FechaCreado, this[CustomersMetadata.ColumnNames.FechaCreado]); 
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.Modificado, this[CustomersMetadata.ColumnNames.Modificado]); 
				   
						oHashtableErrorList.Add(CustomersMetadata.ColumnNames.FechaModificado, this[CustomersMetadata.ColumnNames.FechaModificado]); 
			
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
		
	public partial class CustomersQuery : esCustomersQuery
	{
		public CustomersQuery()
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
		
		public CustomersQuery(string joinAlias)
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
            return "CustomersQuery";
        }
		
		
		override protected string GetConnectionName()
		{
			return "SQLDynamic";
		}	
	}


	[Serializable]
	public partial class CustomersMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected CustomersMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(CustomersMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomersMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.CustName, 1, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.CustName;
			c.CharacterMaxLength = 70;
			_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.Adress, 2, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.Adress;
			c.CharacterMaxLength = 120;
			_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.Status, 3, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = CustomersMetadata.PropertyNames.Status;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.CustomerTypeId, 4, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = CustomersMetadata.PropertyNames.CustomerTypeId;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.TenantId, 5, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = CustomersMetadata.PropertyNames.TenantId;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.IsActivo, 6, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = CustomersMetadata.PropertyNames.IsActivo;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.Creado, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.Creado;
			c.CharacterMaxLength = 40;
			c.HasDefault = true;
			c.Default = @"('rperalta')";
			_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.FechaCreado, 8, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = CustomersMetadata.PropertyNames.FechaCreado;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.Modificado, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = CustomersMetadata.PropertyNames.Modificado;
			c.CharacterMaxLength = 40;
			c.HasDefault = true;
			c.Default = @"('rperalta')";
			_columns.Add(c);
				
			c = new esColumnMetadata(CustomersMetadata.ColumnNames.FechaModificado, 10, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = CustomersMetadata.PropertyNames.FechaModificado;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			_columns.Add(c);
				
		}
		#endregion	
	
		static public CustomersMetadata Meta()
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
			 public const string CustName = "CustName";
			 public const string Adress = "Adress";
			 public const string Status = "Status";
			 public const string CustomerTypeId = "CustomerTypeId";
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
			 public const string CustName = "CustName";
			 public const string Adress = "Adress";
			 public const string Status = "Status";
			 public const string CustomerTypeId = "CustomerTypeId";
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
			lock (typeof(CustomersMetadata))
			{
				if(CustomersMetadata.mapDelegates == null)
				{
					CustomersMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (CustomersMetadata.meta == null)
				{
					CustomersMetadata.meta = new CustomersMetadata();
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
				meta.AddTypeMap("CustName", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Adress", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("Status", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("CustomerTypeId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("TenantId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("IsActivo", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("Creado", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FechaCreado", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Modificado", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FechaModificado", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "Customers";
				meta.Destination = "Customers";
				
				meta.spInsert = "proc_CustomersInsert";				
				meta.spUpdate = "proc_CustomersUpdate";		
				meta.spDelete = "proc_CustomersDelete";
				meta.spLoadAll = "proc_CustomersLoadAll";
				meta.spLoadByPrimaryKey = "proc_CustomersLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private CustomersMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
