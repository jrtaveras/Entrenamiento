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
	abstract public class esInvoicesCollection : esEntityCollection
	{
		public esInvoicesCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "InvoicesCollection";
		}

		#region Query Logic
		protected void InitQuery(esInvoicesQuery query)
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
			this.InitQuery(query as esInvoicesQuery);
		}
		#endregion
		
		virtual public Invoices DetachEntity(Invoices entity)
		{
			return base.DetachEntity(entity) as Invoices;
		}
		
		virtual public Invoices AttachEntity(Invoices entity)
		{
			return base.AttachEntity(entity) as Invoices;
		}
		
		virtual public void Combine(InvoicesCollection collection)
		{
			base.Combine(collection);
		}
		
		new public Invoices this[int index]
		{
			get
			{
				return base[index] as Invoices;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(Invoices);
		}
	}



	[Serializable]
	abstract public class esInvoices : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esInvoicesQuery GetDynamicQuery()
		{
			return null;
		}

		public esInvoices()
		{

		}

		public esInvoices(DataRow row)
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
			esInvoicesQuery query = this.GetDynamicQuery();
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
						case "CustomerId": this.str.CustomerId = (string)value; break;							
						case "TotalItbis": this.str.TotalItbis = (string)value; break;							
						case "SubTotal": this.str.SubTotal = (string)value; break;							
						case "Total": this.str.Total = (string)value; break;							
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
						
						case "CustomerId":
						
							if (value == null || value is System.Int32)
								this.CustomerId = (System.Int32?)value;
							break;
						
						case "TotalItbis":
						
							if (value == null || value is System.Decimal)
								this.TotalItbis = (System.Decimal?)value;
							break;
						
						case "SubTotal":
						
							if (value == null || value is System.Decimal)
								this.SubTotal = (System.Decimal?)value;
							break;
						
						case "Total":
						
							if (value == null || value is System.Decimal)
								this.Total = (System.Decimal?)value;
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
		/// Maps to Invoices.Id
		/// </summary>
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(InvoicesMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt32(InvoicesMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to Invoices.CustomerId
		/// </summary>
		virtual public System.Int32? CustomerId
		{
			get
			{
				return base.GetSystemInt32(InvoicesMetadata.ColumnNames.CustomerId);
			}
			
			set
			{
				if(base.SetSystemInt32(InvoicesMetadata.ColumnNames.CustomerId, value))
				{
					this._UpToCustomersByCustomerId = null;
				}
			}
		}
		
		/// <summary>
		/// Maps to Invoices.TotalItbis
		/// </summary>
		virtual public System.Decimal? TotalItbis
		{
			get
			{
				return base.GetSystemDecimal(InvoicesMetadata.ColumnNames.TotalItbis);
			}
			
			set
			{
				base.SetSystemDecimal(InvoicesMetadata.ColumnNames.TotalItbis, value);
			}
		}
		
		/// <summary>
		/// Maps to Invoices.SubTotal
		/// </summary>
		virtual public System.Decimal? SubTotal
		{
			get
			{
				return base.GetSystemDecimal(InvoicesMetadata.ColumnNames.SubTotal);
			}
			
			set
			{
				base.SetSystemDecimal(InvoicesMetadata.ColumnNames.SubTotal, value);
			}
		}
		
		/// <summary>
		/// Maps to Invoices.Total
		/// </summary>
		virtual public System.Decimal? Total
		{
			get
			{
				return base.GetSystemDecimal(InvoicesMetadata.ColumnNames.Total);
			}
			
			set
			{
				base.SetSystemDecimal(InvoicesMetadata.ColumnNames.Total, value);
			}
		}
		
		/// <summary>
		/// Maps to Invoices.TenantId
		/// </summary>
		virtual public System.Int64? TenantId
		{
			get
			{
				return base.GetSystemInt64(InvoicesMetadata.ColumnNames.TenantId);
			}
			
			set
			{
				base.SetSystemInt64(InvoicesMetadata.ColumnNames.TenantId, value);
			}
		}
		
		/// <summary>
		/// Maps to Invoices.IsActivo
		/// </summary>
		virtual public System.Boolean? IsActivo
		{
			get
			{
				return base.GetSystemBoolean(InvoicesMetadata.ColumnNames.IsActivo);
			}
			
			set
			{
				base.SetSystemBoolean(InvoicesMetadata.ColumnNames.IsActivo, value);
			}
		}
		
		/// <summary>
		/// Maps to Invoices.Creado
		/// </summary>
		virtual public System.String Creado
		{
			get
			{
				return base.GetSystemString(InvoicesMetadata.ColumnNames.Creado);
			}
			
			set
			{
				base.SetSystemString(InvoicesMetadata.ColumnNames.Creado, value);
			}
		}
		
		/// <summary>
		/// Maps to Invoices.FechaCreado
		/// </summary>
		virtual public System.DateTime? FechaCreado
		{
			get
			{
				return base.GetSystemDateTime(InvoicesMetadata.ColumnNames.FechaCreado);
			}
			
			set
			{
				base.SetSystemDateTime(InvoicesMetadata.ColumnNames.FechaCreado, value);
			}
		}
		
		/// <summary>
		/// Maps to Invoices.Modificado
		/// </summary>
		virtual public System.String Modificado
		{
			get
			{
				return base.GetSystemString(InvoicesMetadata.ColumnNames.Modificado);
			}
			
			set
			{
				base.SetSystemString(InvoicesMetadata.ColumnNames.Modificado, value);
			}
		}
		
		/// <summary>
		/// Maps to Invoices.FechaModificado
		/// </summary>
		virtual public System.DateTime? FechaModificado
		{
			get
			{
				return base.GetSystemDateTime(InvoicesMetadata.ColumnNames.FechaModificado);
			}
			
			set
			{
				base.SetSystemDateTime(InvoicesMetadata.ColumnNames.FechaModificado, value);
			}
		}
		
		[CLSCompliant(false)]
		internal protected Customers _UpToCustomersByCustomerId;
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
			public esStrings(esInvoices entity)
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
				
			public System.String CustomerId
			{
				get
				{
					System.Int32? data = entity.CustomerId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.CustomerId = null;
					else entity.CustomerId = Convert.ToInt32(value);
				}
			}
				
			public System.String TotalItbis
			{
				get
				{
					System.Decimal? data = entity.TotalItbis;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.TotalItbis = null;
					else entity.TotalItbis = Convert.ToDecimal(value);
				}
			}
				
			public System.String SubTotal
			{
				get
				{
					System.Decimal? data = entity.SubTotal;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.SubTotal = null;
					else entity.SubTotal = Convert.ToDecimal(value);
				}
			}
				
			public System.String Total
			{
				get
				{
					System.Decimal? data = entity.Total;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Total = null;
					else entity.Total = Convert.ToDecimal(value);
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
			

			private esInvoices entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esInvoicesQuery query)
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
				throw new Exception("esInvoices can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class Invoices : esInvoices
	{

				
		#region InvoiceDetailsCollectionByInvoiceId - Zero To Many
		/// <summary>
		/// Zero to Many
		/// Foreign Key Name - FK_InvoiceDetails_Invoices
		/// </summary>

		[XmlIgnore]
		public InvoiceDetailsCollection InvoiceDetailsCollectionByInvoiceId
		{
			get
			{
				if(this._InvoiceDetailsCollectionByInvoiceId == null)
				{
					this._InvoiceDetailsCollectionByInvoiceId = new InvoiceDetailsCollection();
					this._InvoiceDetailsCollectionByInvoiceId.es.Connection.Name = this.es.Connection.Name;
					this.SetPostSave("InvoiceDetailsCollectionByInvoiceId", this._InvoiceDetailsCollectionByInvoiceId);
				
					if(this.Id != null)
					{
						this._InvoiceDetailsCollectionByInvoiceId.Query.Where(this._InvoiceDetailsCollectionByInvoiceId.Query.InvoiceId == this.Id);
						this._InvoiceDetailsCollectionByInvoiceId.Query.Load();

						// Auto-hookup Foreign Keys
						this._InvoiceDetailsCollectionByInvoiceId.fks.Add(InvoiceDetailsMetadata.ColumnNames.InvoiceId, this.Id);
					}
				}

				return this._InvoiceDetailsCollectionByInvoiceId;
			}
			
			set 
			{ 
				if (value != null) throw new Exception("'value' Must be null"); 
			 
				if (this._InvoiceDetailsCollectionByInvoiceId != null) 
				{ 
					this.RemovePostSave("InvoiceDetailsCollectionByInvoiceId"); 
					this._InvoiceDetailsCollectionByInvoiceId = null;
					
				} 
			} 			
		}

		private InvoiceDetailsCollection _InvoiceDetailsCollectionByInvoiceId;
		#endregion

				
		#region UpToCustomersByCustomerId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_Invoice_Customers
		/// </summary>

		[XmlIgnore]
		public Customers UpToCustomersByCustomerId
		{
			get
			{
				if(this._UpToCustomersByCustomerId == null
					&& CustomerId != null					)
				{
					this._UpToCustomersByCustomerId = new Customers();
					this._UpToCustomersByCustomerId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToCustomersByCustomerId", this._UpToCustomersByCustomerId);
					this._UpToCustomersByCustomerId.Query.Where(this._UpToCustomersByCustomerId.Query.Id == this.CustomerId);
					this._UpToCustomersByCustomerId.Query.Load();
				}

				return this._UpToCustomersByCustomerId;
			}
			
			set
			{
				this.RemovePreSave("UpToCustomersByCustomerId");
				

				if(value == null)
				{
					this.CustomerId = null;
					this._UpToCustomersByCustomerId = null;
				}
				else
				{
					this.CustomerId = value.Id;
					this._UpToCustomersByCustomerId = value;
					this.SetPreSave("UpToCustomersByCustomerId", this._UpToCustomersByCustomerId);
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
			
			props.Add(new esPropertyDescriptor(this, "InvoiceDetailsCollectionByInvoiceId", typeof(InvoiceDetailsCollection), new InvoiceDetails()));
		
			return props;
		}	
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToCustomersByCustomerId != null)
			{
				this.CustomerId = this._UpToCustomersByCustomerId.Id;
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
			if(this._InvoiceDetailsCollectionByInvoiceId != null)
			{
				foreach(InvoiceDetails obj in this._InvoiceDetailsCollectionByInvoiceId)
				{
					if(obj.es.IsAdded)
					{
						obj.InvoiceId = this.Id;
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
	abstract public class esInvoicesQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return InvoicesMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.Id, esSystemType.Int32);
			}
		} 
		
		public esQueryItem CustomerId
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.CustomerId, esSystemType.Int32);
			}
		} 
		
		public esQueryItem TotalItbis
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.TotalItbis, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem SubTotal
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.SubTotal, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem Total
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.Total, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem TenantId
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.TenantId, esSystemType.Int64);
			}
		} 
		
		public esQueryItem IsActivo
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.IsActivo, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem Creado
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.Creado, esSystemType.String);
			}
		} 
		
		public esQueryItem FechaCreado
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.FechaCreado, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem Modificado
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.Modificado, esSystemType.String);
			}
		} 
		
		public esQueryItem FechaModificado
		{
			get
			{
				return new esQueryItem(this, InvoicesMetadata.ColumnNames.FechaModificado, esSystemType.DateTime);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("InvoicesCollection")]
	public partial class InvoicesCollection : esInvoicesCollection, IEnumerable<Invoices>
	{
		public InvoicesCollection()
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
		public static implicit operator List<Invoices>(InvoicesCollection coll)
		{
			List<Invoices> list = new List<Invoices>();
			
			foreach (Invoices emp in coll)
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
				return  InvoicesMetadata.Meta();
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
				this.query = new InvoicesQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new Invoices(row);
		}

		override protected esEntity CreateEntity()
		{
			return new Invoices();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public InvoicesQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new InvoicesQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(InvoicesQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public Invoices AddNew()
		{
			Invoices entity = base.AddNewEntity() as Invoices;
			
			return entity;
		}

		public Invoices FindByPrimaryKey(System.Int32 id)
		{
			return base.FindByPrimaryKey(id) as Invoices;
		}


		#region IEnumerable<Invoices> Members

		IEnumerator<Invoices> IEnumerable<Invoices>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as Invoices;
			}
		}

		#endregion
		
		private InvoicesQuery query;
	}


	/// <summary>
	/// Encapsulates the 'Invoices' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("Invoices ({Id})")]
	[Serializable]
	public partial class Invoices : esInvoices
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
		public Invoices()
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
	
		public Invoices(DataRow row)
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
				return InvoicesMetadata.Meta();
			}
		}
		
		
		override protected string GetConnectionName()
		{
			return "SQLDynamic";
		}
		
		override protected esInvoicesQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new InvoicesQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public InvoicesQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new InvoicesQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(InvoicesQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private InvoicesQuery query;
		
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
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.Id, this[InvoicesMetadata.ColumnNames.Id]); 
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.CustomerId, this[InvoicesMetadata.ColumnNames.CustomerId]); 
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.TotalItbis, this[InvoicesMetadata.ColumnNames.TotalItbis]); 
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.SubTotal, this[InvoicesMetadata.ColumnNames.SubTotal]); 
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.Total, this[InvoicesMetadata.ColumnNames.Total]); 
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.TenantId, this[InvoicesMetadata.ColumnNames.TenantId]); 
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.IsActivo, this[InvoicesMetadata.ColumnNames.IsActivo]); 
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.Creado, this[InvoicesMetadata.ColumnNames.Creado]); 
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.FechaCreado, this[InvoicesMetadata.ColumnNames.FechaCreado]); 
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.Modificado, this[InvoicesMetadata.ColumnNames.Modificado]); 
				   
						oHashtableErrorList.Add(InvoicesMetadata.ColumnNames.FechaModificado, this[InvoicesMetadata.ColumnNames.FechaModificado]); 
			
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
		
	public partial class InvoicesQuery : esInvoicesQuery
	{
		public InvoicesQuery()
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
		
		public InvoicesQuery(string joinAlias)
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
            return "InvoicesQuery";
        }
		
		
		override protected string GetConnectionName()
		{
			return "SQLDynamic";
		}	
	}


	[Serializable]
	public partial class InvoicesMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected InvoicesMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = InvoicesMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.CustomerId, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = InvoicesMetadata.PropertyNames.CustomerId;
			c.NumericPrecision = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.TotalItbis, 2, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = InvoicesMetadata.PropertyNames.TotalItbis;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.SubTotal, 3, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = InvoicesMetadata.PropertyNames.SubTotal;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.Total, 4, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = InvoicesMetadata.PropertyNames.Total;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.TenantId, 5, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = InvoicesMetadata.PropertyNames.TenantId;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.IsActivo, 6, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = InvoicesMetadata.PropertyNames.IsActivo;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.Creado, 7, typeof(System.String), esSystemType.String);
			c.PropertyName = InvoicesMetadata.PropertyNames.Creado;
			c.CharacterMaxLength = 40;
			c.HasDefault = true;
			c.Default = @"('rperalta')";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.FechaCreado, 8, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = InvoicesMetadata.PropertyNames.FechaCreado;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.Modificado, 9, typeof(System.String), esSystemType.String);
			c.PropertyName = InvoicesMetadata.PropertyNames.Modificado;
			c.CharacterMaxLength = 40;
			c.HasDefault = true;
			c.Default = @"('rperalta')";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoicesMetadata.ColumnNames.FechaModificado, 10, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = InvoicesMetadata.PropertyNames.FechaModificado;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			_columns.Add(c);
				
		}
		#endregion	
	
		static public InvoicesMetadata Meta()
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
			 public const string CustomerId = "CustomerId";
			 public const string TotalItbis = "TotalItbis";
			 public const string SubTotal = "SubTotal";
			 public const string Total = "Total";
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
			 public const string CustomerId = "CustomerId";
			 public const string TotalItbis = "TotalItbis";
			 public const string SubTotal = "SubTotal";
			 public const string Total = "Total";
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
			lock (typeof(InvoicesMetadata))
			{
				if(InvoicesMetadata.mapDelegates == null)
				{
					InvoicesMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (InvoicesMetadata.meta == null)
				{
					InvoicesMetadata.meta = new InvoicesMetadata();
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
				meta.AddTypeMap("CustomerId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("TotalItbis", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("SubTotal", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("Total", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("TenantId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("IsActivo", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("Creado", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FechaCreado", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Modificado", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FechaModificado", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "Invoices";
				meta.Destination = "Invoices";
				
				meta.spInsert = "proc_InvoicesInsert";				
				meta.spUpdate = "proc_InvoicesUpdate";		
				meta.spDelete = "proc_InvoicesDelete";
				meta.spLoadAll = "proc_InvoicesLoadAll";
				meta.spLoadByPrimaryKey = "proc_InvoicesLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private InvoicesMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
