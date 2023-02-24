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
	abstract public class esInvoiceDetailsCollection : esEntityCollection
	{
		public esInvoiceDetailsCollection()
		{

		}

		protected override string GetCollectionName()
		{
			return "InvoiceDetailsCollection";
		}

		#region Query Logic
		protected void InitQuery(esInvoiceDetailsQuery query)
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
			this.InitQuery(query as esInvoiceDetailsQuery);
		}
		#endregion
		
		virtual public InvoiceDetails DetachEntity(InvoiceDetails entity)
		{
			return base.DetachEntity(entity) as InvoiceDetails;
		}
		
		virtual public InvoiceDetails AttachEntity(InvoiceDetails entity)
		{
			return base.AttachEntity(entity) as InvoiceDetails;
		}
		
		virtual public void Combine(InvoiceDetailsCollection collection)
		{
			base.Combine(collection);
		}
		
		new public InvoiceDetails this[int index]
		{
			get
			{
				return base[index] as InvoiceDetails;
			}
		}

		public override Type GetEntityType()
		{
			return typeof(InvoiceDetails);
		}
	}



	[Serializable]
	abstract public class esInvoiceDetails : esEntity
	{
		/// <summary>
		/// Used internally by the entity's DynamicQuery mechanism.
		/// </summary>
		virtual protected esInvoiceDetailsQuery GetDynamicQuery()
		{
			return null;
		}

		public esInvoiceDetails()
		{

		}

		public esInvoiceDetails(DataRow row)
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
			esInvoiceDetailsQuery query = this.GetDynamicQuery();
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
						case "InvoiceId": this.str.InvoiceId = (string)value; break;							
						case "ProductId": this.str.ProductId = (string)value; break;							
						case "Qty": this.str.Qty = (string)value; break;							
						case "Price": this.str.Price = (string)value; break;							
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
						
						case "InvoiceId":
						
							if (value == null || value is System.Int32)
								this.InvoiceId = (System.Int32?)value;
							break;
						
						case "ProductId":
						
							if (value == null || value is System.Int32)
								this.ProductId = (System.Int32?)value;
							break;
						
						case "Qty":
						
							if (value == null || value is System.Int32)
								this.Qty = (System.Int32?)value;
							break;
						
						case "Price":
						
							if (value == null || value is System.Decimal)
								this.Price = (System.Decimal?)value;
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
		/// Maps to InvoiceDetails.Id
		/// </summary>
		virtual public System.Int32? Id
		{
			get
			{
				return base.GetSystemInt32(InvoiceDetailsMetadata.ColumnNames.Id);
			}
			
			set
			{
				base.SetSystemInt32(InvoiceDetailsMetadata.ColumnNames.Id, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.InvoiceId
		/// </summary>
		virtual public System.Int32? InvoiceId
		{
			get
			{
				return base.GetSystemInt32(InvoiceDetailsMetadata.ColumnNames.InvoiceId);
			}
			
			set
			{
				if(base.SetSystemInt32(InvoiceDetailsMetadata.ColumnNames.InvoiceId, value))
				{
					this._UpToInvoicesByInvoiceId = null;
				}
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.productId
		/// </summary>
		virtual public System.Int32? ProductId
		{
			get
			{
				return base.GetSystemInt32(InvoiceDetailsMetadata.ColumnNames.ProductId);
			}
			
			set
			{
				if(base.SetSystemInt32(InvoiceDetailsMetadata.ColumnNames.ProductId, value))
				{
					this._UpToProductsByProductId = null;
				}
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.Qty
		/// </summary>
		virtual public System.Int32? Qty
		{
			get
			{
				return base.GetSystemInt32(InvoiceDetailsMetadata.ColumnNames.Qty);
			}
			
			set
			{
				base.SetSystemInt32(InvoiceDetailsMetadata.ColumnNames.Qty, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.Price
		/// </summary>
		virtual public System.Decimal? Price
		{
			get
			{
				return base.GetSystemDecimal(InvoiceDetailsMetadata.ColumnNames.Price);
			}
			
			set
			{
				base.SetSystemDecimal(InvoiceDetailsMetadata.ColumnNames.Price, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.TotalItbis
		/// </summary>
		virtual public System.Decimal? TotalItbis
		{
			get
			{
				return base.GetSystemDecimal(InvoiceDetailsMetadata.ColumnNames.TotalItbis);
			}
			
			set
			{
				base.SetSystemDecimal(InvoiceDetailsMetadata.ColumnNames.TotalItbis, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.SubTotal
		/// </summary>
		virtual public System.Decimal? SubTotal
		{
			get
			{
				return base.GetSystemDecimal(InvoiceDetailsMetadata.ColumnNames.SubTotal);
			}
			
			set
			{
				base.SetSystemDecimal(InvoiceDetailsMetadata.ColumnNames.SubTotal, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.Total
		/// </summary>
		virtual public System.Decimal? Total
		{
			get
			{
				return base.GetSystemDecimal(InvoiceDetailsMetadata.ColumnNames.Total);
			}
			
			set
			{
				base.SetSystemDecimal(InvoiceDetailsMetadata.ColumnNames.Total, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.TenantId
		/// </summary>
		virtual public System.Int64? TenantId
		{
			get
			{
				return base.GetSystemInt64(InvoiceDetailsMetadata.ColumnNames.TenantId);
			}
			
			set
			{
				base.SetSystemInt64(InvoiceDetailsMetadata.ColumnNames.TenantId, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.IsActivo
		/// </summary>
		virtual public System.Boolean? IsActivo
		{
			get
			{
				return base.GetSystemBoolean(InvoiceDetailsMetadata.ColumnNames.IsActivo);
			}
			
			set
			{
				base.SetSystemBoolean(InvoiceDetailsMetadata.ColumnNames.IsActivo, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.Creado
		/// </summary>
		virtual public System.String Creado
		{
			get
			{
				return base.GetSystemString(InvoiceDetailsMetadata.ColumnNames.Creado);
			}
			
			set
			{
				base.SetSystemString(InvoiceDetailsMetadata.ColumnNames.Creado, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.FechaCreado
		/// </summary>
		virtual public System.DateTime? FechaCreado
		{
			get
			{
				return base.GetSystemDateTime(InvoiceDetailsMetadata.ColumnNames.FechaCreado);
			}
			
			set
			{
				base.SetSystemDateTime(InvoiceDetailsMetadata.ColumnNames.FechaCreado, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.Modificado
		/// </summary>
		virtual public System.String Modificado
		{
			get
			{
				return base.GetSystemString(InvoiceDetailsMetadata.ColumnNames.Modificado);
			}
			
			set
			{
				base.SetSystemString(InvoiceDetailsMetadata.ColumnNames.Modificado, value);
			}
		}
		
		/// <summary>
		/// Maps to InvoiceDetails.FechaModificado
		/// </summary>
		virtual public System.DateTime? FechaModificado
		{
			get
			{
				return base.GetSystemDateTime(InvoiceDetailsMetadata.ColumnNames.FechaModificado);
			}
			
			set
			{
				base.SetSystemDateTime(InvoiceDetailsMetadata.ColumnNames.FechaModificado, value);
			}
		}
		
		[CLSCompliant(false)]
		internal protected Invoices _UpToInvoicesByInvoiceId;
		[CLSCompliant(false)]
		internal protected Products _UpToProductsByProductId;
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
			public esStrings(esInvoiceDetails entity)
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
				
			public System.String InvoiceId
			{
				get
				{
					System.Int32? data = entity.InvoiceId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.InvoiceId = null;
					else entity.InvoiceId = Convert.ToInt32(value);
				}
			}
				
			public System.String ProductId
			{
				get
				{
					System.Int32? data = entity.ProductId;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.ProductId = null;
					else entity.ProductId = Convert.ToInt32(value);
				}
			}
				
			public System.String Qty
			{
				get
				{
					System.Int32? data = entity.Qty;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Qty = null;
					else entity.Qty = Convert.ToInt32(value);
				}
			}
				
			public System.String Price
			{
				get
				{
					System.Decimal? data = entity.Price;
					return (data == null) ? String.Empty : Convert.ToString(data);
				}

				set
				{
					if (value == null || value.Length == 0) entity.Price = null;
					else entity.Price = Convert.ToDecimal(value);
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
			

			private esInvoiceDetails entity;
		}
		#endregion

		#region Query Logic
		protected void InitQuery(esInvoiceDetailsQuery query)
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
				throw new Exception("esInvoiceDetails can only hold one record of data");
			}

			return dataFound;
		}
		#endregion
		
		[NonSerialized]
		private esStrings esstrings;
	}


	
	public partial class InvoiceDetails : esInvoiceDetails
	{

				
		#region UpToInvoicesByInvoiceId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_InvoiceDetails_Invoices
		/// </summary>

		[XmlIgnore]
		public Invoices UpToInvoicesByInvoiceId
		{
			get
			{
				if(this._UpToInvoicesByInvoiceId == null
					&& InvoiceId != null					)
				{
					this._UpToInvoicesByInvoiceId = new Invoices();
					this._UpToInvoicesByInvoiceId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToInvoicesByInvoiceId", this._UpToInvoicesByInvoiceId);
					this._UpToInvoicesByInvoiceId.Query.Where(this._UpToInvoicesByInvoiceId.Query.Id == this.InvoiceId);
					this._UpToInvoicesByInvoiceId.Query.Load();
				}

				return this._UpToInvoicesByInvoiceId;
			}
			
			set
			{
				this.RemovePreSave("UpToInvoicesByInvoiceId");
				

				if(value == null)
				{
					this.InvoiceId = null;
					this._UpToInvoicesByInvoiceId = null;
				}
				else
				{
					this.InvoiceId = value.Id;
					this._UpToInvoicesByInvoiceId = value;
					this.SetPreSave("UpToInvoicesByInvoiceId", this._UpToInvoicesByInvoiceId);
				}
				
			}
		}
		#endregion
		

				
		#region UpToProductsByProductId - Many To One
		/// <summary>
		/// Many to One
		/// Foreign Key Name - FK_InvoiceDetails_Products
		/// </summary>

		[XmlIgnore]
		public Products UpToProductsByProductId
		{
			get
			{
				if(this._UpToProductsByProductId == null
					&& ProductId != null					)
				{
					this._UpToProductsByProductId = new Products();
					this._UpToProductsByProductId.es.Connection.Name = this.es.Connection.Name;
					this.SetPreSave("UpToProductsByProductId", this._UpToProductsByProductId);
					this._UpToProductsByProductId.Query.Where(this._UpToProductsByProductId.Query.Id == this.ProductId);
					this._UpToProductsByProductId.Query.Load();
				}

				return this._UpToProductsByProductId;
			}
			
			set
			{
				this.RemovePreSave("UpToProductsByProductId");
				

				if(value == null)
				{
					this.ProductId = null;
					this._UpToProductsByProductId = null;
				}
				else
				{
					this.ProductId = value.Id;
					this._UpToProductsByProductId = value;
					this.SetPreSave("UpToProductsByProductId", this._UpToProductsByProductId);
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
			
		
			return props;
		}	
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PreSave.
		/// </summary>
		protected override void ApplyPreSaveKeys()
		{
			if(!this.es.IsDeleted && this._UpToInvoicesByInvoiceId != null)
			{
				this.InvoiceId = this._UpToInvoicesByInvoiceId.Id;
			}
			if(!this.es.IsDeleted && this._UpToProductsByProductId != null)
			{
				this.ProductId = this._UpToProductsByProductId.Id;
			}
		}
		
		/// <summary>
		/// Used internally for retrieving AutoIncrementing keys
		/// during hierarchical PostSave.
		/// </summary>
		protected override void ApplyPostSaveKeys()
		{
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
	abstract public class esInvoiceDetailsQuery : esDynamicQuery
	{
		override protected IMetadata Meta
		{
			get
			{
				return InvoiceDetailsMetadata.Meta();
			}
		}	
		

		public esQueryItem Id
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.Id, esSystemType.Int32);
			}
		} 
		
		public esQueryItem InvoiceId
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.InvoiceId, esSystemType.Int32);
			}
		} 
		
		public esQueryItem ProductId
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.ProductId, esSystemType.Int32);
			}
		} 
		
		public esQueryItem Qty
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.Qty, esSystemType.Int32);
			}
		} 
		
		public esQueryItem Price
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.Price, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem TotalItbis
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.TotalItbis, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem SubTotal
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.SubTotal, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem Total
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.Total, esSystemType.Decimal);
			}
		} 
		
		public esQueryItem TenantId
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.TenantId, esSystemType.Int64);
			}
		} 
		
		public esQueryItem IsActivo
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.IsActivo, esSystemType.Boolean);
			}
		} 
		
		public esQueryItem Creado
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.Creado, esSystemType.String);
			}
		} 
		
		public esQueryItem FechaCreado
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.FechaCreado, esSystemType.DateTime);
			}
		} 
		
		public esQueryItem Modificado
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.Modificado, esSystemType.String);
			}
		} 
		
		public esQueryItem FechaModificado
		{
			get
			{
				return new esQueryItem(this, InvoiceDetailsMetadata.ColumnNames.FechaModificado, esSystemType.DateTime);
			}
		} 
		
	}



    [System.Diagnostics.DebuggerDisplay("Count = {Count}")]
	[Serializable]
	[XmlType("InvoiceDetailsCollection")]
	public partial class InvoiceDetailsCollection : esInvoiceDetailsCollection, IEnumerable<InvoiceDetails>
	{
		public InvoiceDetailsCollection()
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
		public static implicit operator List<InvoiceDetails>(InvoiceDetailsCollection coll)
		{
			List<InvoiceDetails> list = new List<InvoiceDetails>();
			
			foreach (InvoiceDetails emp in coll)
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
				return  InvoiceDetailsMetadata.Meta();
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
				this.query = new InvoiceDetailsQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		
		override protected esEntity CreateEntityForCollection(DataRow row)
		{
			return new InvoiceDetails(row);
		}

		override protected esEntity CreateEntity()
		{
			return new InvoiceDetails();
		}
		
		
		#endregion


		[BrowsableAttribute( false )]
		public InvoiceDetailsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new InvoiceDetailsQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}

		public bool Load(InvoiceDetailsQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		public InvoiceDetails AddNew()
		{
			InvoiceDetails entity = base.AddNewEntity() as InvoiceDetails;
			
			return entity;
		}

		public InvoiceDetails FindByPrimaryKey(System.Int32 id)
		{
			return base.FindByPrimaryKey(id) as InvoiceDetails;
		}


		#region IEnumerable<InvoiceDetails> Members

		IEnumerator<InvoiceDetails> IEnumerable<InvoiceDetails>.GetEnumerator()
		{
			System.Collections.IEnumerable enumer = this as System.Collections.IEnumerable;
			System.Collections.IEnumerator iterator = enumer.GetEnumerator();

			while(iterator.MoveNext())
			{
				yield return iterator.Current as InvoiceDetails;
			}
		}

		#endregion
		
		private InvoiceDetailsQuery query;
	}


	/// <summary>
	/// Encapsulates the 'InvoiceDetails' table
	/// </summary>

    [System.Diagnostics.DebuggerDisplay("InvoiceDetails ({Id})")]
	[Serializable]
	public partial class InvoiceDetails : esInvoiceDetails
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
		public InvoiceDetails()
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
	
		public InvoiceDetails(DataRow row)
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
				return InvoiceDetailsMetadata.Meta();
			}
		}
		
		
		override protected string GetConnectionName()
		{
			return "SQLDynamic";
		}
		
		override protected esInvoiceDetailsQuery GetDynamicQuery()
		{
			if (this.query == null)
			{
				this.query = new InvoiceDetailsQuery();
				this.InitQuery(query);
			}
			return this.query;
		}
		#endregion
		



		[BrowsableAttribute( false )]
		public InvoiceDetailsQuery Query
		{
			get
			{
				if (this.query == null)
				{
					this.query = new InvoiceDetailsQuery();
					base.InitQuery(this.query);
				}

				return this.query;
			}
		}

		public void QueryReset()
		{
			this.query = null;
		}
		

		public bool Load(InvoiceDetailsQuery query)
		{
			this.query = query;
			base.InitQuery(this.query);
			return this.Query.Load();
		}
		
		private InvoiceDetailsQuery query;
		
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
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.Id, this[InvoiceDetailsMetadata.ColumnNames.Id]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.InvoiceId, this[InvoiceDetailsMetadata.ColumnNames.InvoiceId]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.ProductId, this[InvoiceDetailsMetadata.ColumnNames.ProductId]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.Qty, this[InvoiceDetailsMetadata.ColumnNames.Qty]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.Price, this[InvoiceDetailsMetadata.ColumnNames.Price]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.TotalItbis, this[InvoiceDetailsMetadata.ColumnNames.TotalItbis]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.SubTotal, this[InvoiceDetailsMetadata.ColumnNames.SubTotal]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.Total, this[InvoiceDetailsMetadata.ColumnNames.Total]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.TenantId, this[InvoiceDetailsMetadata.ColumnNames.TenantId]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.IsActivo, this[InvoiceDetailsMetadata.ColumnNames.IsActivo]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.Creado, this[InvoiceDetailsMetadata.ColumnNames.Creado]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.FechaCreado, this[InvoiceDetailsMetadata.ColumnNames.FechaCreado]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.Modificado, this[InvoiceDetailsMetadata.ColumnNames.Modificado]); 
				   
						oHashtableErrorList.Add(InvoiceDetailsMetadata.ColumnNames.FechaModificado, this[InvoiceDetailsMetadata.ColumnNames.FechaModificado]); 
			
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
		
	public partial class InvoiceDetailsQuery : esInvoiceDetailsQuery
	{
		public InvoiceDetailsQuery()
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
		
		public InvoiceDetailsQuery(string joinAlias)
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
            return "InvoiceDetailsQuery";
        }
		
		
		override protected string GetConnectionName()
		{
			return "SQLDynamic";
		}	
	}


	[Serializable]
	public partial class InvoiceDetailsMetadata : esMetadata, IMetadata
	{
		#region Protected Constructor
		protected InvoiceDetailsMetadata()
		{
			_columns = new esColumnMetadataCollection();
			esColumnMetadata c;

			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.Id, 0, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.Id;
			c.IsInPrimaryKey = true;
			c.IsAutoIncrement = true;
			c.NumericPrecision = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.InvoiceId, 1, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.InvoiceId;
			c.NumericPrecision = 10;
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.ProductId, 2, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.ProductId;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.Qty, 3, typeof(System.Int32), esSystemType.Int32);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.Qty;
			c.NumericPrecision = 10;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.Price, 4, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.Price;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.TotalItbis, 5, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.TotalItbis;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"((0))";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.SubTotal, 6, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.SubTotal;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.Total, 7, typeof(System.Decimal), esSystemType.Decimal);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.Total;
			c.NumericPrecision = 19;
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.TenantId, 8, typeof(System.Int64), esSystemType.Int64);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.TenantId;
			c.NumericPrecision = 19;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.IsActivo, 9, typeof(System.Boolean), esSystemType.Boolean);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.IsActivo;
			c.HasDefault = true;
			c.Default = @"((1))";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.Creado, 10, typeof(System.String), esSystemType.String);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.Creado;
			c.CharacterMaxLength = 40;
			c.HasDefault = true;
			c.Default = @"('rperalta')";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.FechaCreado, 11, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.FechaCreado;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.Modificado, 12, typeof(System.String), esSystemType.String);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.Modificado;
			c.CharacterMaxLength = 40;
			c.HasDefault = true;
			c.Default = @"('rperalta')";
			_columns.Add(c);
				
			c = new esColumnMetadata(InvoiceDetailsMetadata.ColumnNames.FechaModificado, 13, typeof(System.DateTime), esSystemType.DateTime);
			c.PropertyName = InvoiceDetailsMetadata.PropertyNames.FechaModificado;
			c.HasDefault = true;
			c.Default = @"(getdate())";
			_columns.Add(c);
				
		}
		#endregion	
	
		static public InvoiceDetailsMetadata Meta()
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
			 public const string InvoiceId = "InvoiceId";
			 public const string ProductId = "productId";
			 public const string Qty = "Qty";
			 public const string Price = "Price";
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
			 public const string InvoiceId = "InvoiceId";
			 public const string ProductId = "ProductId";
			 public const string Qty = "Qty";
			 public const string Price = "Price";
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
			lock (typeof(InvoiceDetailsMetadata))
			{
				if(InvoiceDetailsMetadata.mapDelegates == null)
				{
					InvoiceDetailsMetadata.mapDelegates = new Dictionary<string,MapToMeta>();
				}
				
				if (InvoiceDetailsMetadata.meta == null)
				{
					InvoiceDetailsMetadata.meta = new InvoiceDetailsMetadata();
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
				meta.AddTypeMap("InvoiceId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("ProductId", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Qty", new esTypeMap("int", "System.Int32"));
				meta.AddTypeMap("Price", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("TotalItbis", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("SubTotal", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("Total", new esTypeMap("money", "System.Decimal"));
				meta.AddTypeMap("TenantId", new esTypeMap("bigint", "System.Int64"));
				meta.AddTypeMap("IsActivo", new esTypeMap("bit", "System.Boolean"));
				meta.AddTypeMap("Creado", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FechaCreado", new esTypeMap("datetime", "System.DateTime"));
				meta.AddTypeMap("Modificado", new esTypeMap("nvarchar", "System.String"));
				meta.AddTypeMap("FechaModificado", new esTypeMap("datetime", "System.DateTime"));			
				
				
				
				meta.Source = "InvoiceDetails";
				meta.Destination = "InvoiceDetails";
				
				meta.spInsert = "proc_InvoiceDetailsInsert";				
				meta.spUpdate = "proc_InvoiceDetailsUpdate";		
				meta.spDelete = "proc_InvoiceDetailsDelete";
				meta.spLoadAll = "proc_InvoiceDetailsLoadAll";
				meta.spLoadByPrimaryKey = "proc_InvoiceDetailsLoadByPrimaryKey";
				
				this._providerMetadataMaps["esDefault"] = meta;
			}
			
			return this._providerMetadataMaps["esDefault"];
		}

		#endregion

		static private InvoiceDetailsMetadata meta;
		static protected Dictionary<string, MapToMeta> mapDelegates;
		static private int _esDefault = RegisterDelegateesDefault();
	}
}
