//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/21/2023 2:50:38 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)
using System;
using Wisej.Web;
using BusinessObjects.Interfaces;
using BusinessObjects.Services;
using BusinessObjects.Models;
using BusinessObjects.Factories;
using Common.Forms;
using Common;
using CommonUserControls.Helpers;
using Common.Controls;
using SmartXLS;
using Common.Helpers;
using System.IO;
using Common.Constants;
using System.Linq;
using System.Collections.Generic;

namespace CommonUserControls
{
    public partial class UserControlInvoiceDetails : UserControlBase, IInvoiceDetails, IValidate, IDataSource
    {

        private readonly IPresenter _invoiceDetailsPresenter;
        private readonly HelperControlsToValidate _helperControls;
        
		private bool _canEdit;
		public bool CanEdit
		{
			get
			{
				return _canEdit;
			}
			set
			{

				_canEdit = value;

				EnableDisableControls();
			}
		}

		public Action SaveHeaderChangesAfterAction { get; set; }

		#region Properties InvoiceDetails

		private int _id;
		public int Id
		{
			get
			{
				bool result = int.TryParse(textBoxId.Text, out _id);
				if (result == false) 
				{
				  textBoxId.Text = "0";
				}
				return _id;
			}
			set
			{
				textBoxId.Text = value.ToString();
				
				toolBarButtonInfo.ToolTipText = $"{GetCreated()} : {Creado} {FechaCreado}  {GetModified()}: {Modificado} {FechaModificado}";
				panelPricipal.Text = GetTitle() + " (" + value.ToString() + ")";
			}
		}

		private int _InvoiceId;
		public int InvoiceId
		{
			get
			{
				if (textBoxInvoiceId.Text != null)
					_InvoiceId = Convert.ToInt32(textBoxInvoiceId.Text);

				return _InvoiceId;
			}
			set
			{
				_InvoiceId = value;
				textBoxInvoiceId.Text = value.ToString();
				if (_invoiceDetailsPresenter != null)
					_invoiceDetailsPresenter.FillDataSource();
			}
		}

		public int Qty
		{
			get
			{
				return (int)numericUpDownQty.Value;
			}
			set
			{
				numericUpDownQty.Value = value;
			}
		}

		public decimal Price
		{
			get
			{
				return numericUpDownPrice.Value;
			}
			set
			{
				numericUpDownPrice.Value = value;
			}
		}

		public decimal TotalItbis
		{
			get
			{
				return numericUpDownTotalItbis.Value;
			}
			set
			{
				numericUpDownTotalItbis.Value = value;
			}
		}

		public decimal SubTotal
		{
			get
			{
				return numericUpDownSubTotal.Value;
			}
			set
			{
				numericUpDownSubTotal.Value = value;
			}
		}

		public decimal Total
		{
			get
			{
				return numericUpDownTotal.Value;
			}
			set
			{
				numericUpDownTotal.Value = value;
			}
		}

		public bool IsActivo
		{
			get
			{
				return checkBoxIsActivo.Checked;
			}
			set
			{
				checkBoxIsActivo.Checked = value;
			}
		}

		public string Creado
		{
			get; set;
		}

		public DateTime FechaCreado
		{
			get; set;
		}

		public string Modificado
		{
			get; set;
		}

		public DateTime FechaModificado
		{
			get; set;
		}
		public object DataGridSource
		{
			get => dataGridViewInvoiceDetails.DataSource;
			set => dataGridViewInvoiceDetails.DataSource = value;
		}

		public int productId
		{
			get => (int)userControlSearchNumericProducts.Value;
			set => userControlSearchNumericProducts.Value = value;
		}

		public long TenantId { get; set; }


		#endregion


		public UserControlInvoiceDetails(IContext context):base(context)
        {
            InitializeComponent();
            
			Title = "InvoiceDetails";
            
			SetControls();
            
			_invoiceDetailsPresenter = new InvoiceDetailsPresenter(context, this);
			_invoiceDetailsPresenter.BeforeSave += CalcularTotales;
			_invoiceDetailsPresenter.AfterSave += CalculateInvoiceHeaderTotals;
			
			FillUsercontrolSearch();
			_helperControls = new HelperControlsToValidate(panelPricipal);
            
			toolBar1.ButtonClick += ToolBar1_ButtonClick;
            CanEdit  = true;
        }

        private void ToolBarButtonRecargaCombo_Click(object sender, EventArgs e)
		{
			try
			{

			}
			catch (Exception ex)
			{
				MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void PanelPricipal_PanelCollapsed(object sender, EventArgs e)
		{
			if (panelPricipal.Collapsed)
			{
				panelPricipal.HeaderPosition = HeaderPosition.Top;
			}
		}
		private void PanelPricipal_PanelExpanded(object sender, EventArgs e)
		{
			if (!panelPricipal.Collapsed)
			{
				panelPricipal.HeaderPosition = HeaderPosition.Left;
			}
		}
        private void ToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Name)
            {
                case ToolBarButtonConstants.Nuevo:
                    _invoiceDetailsPresenter.Add();
                    CanEdit = true;
                    break;

                case ToolBarButtonConstants.Salvar:

                    try
                    {
                        if (_invoiceDetailsPresenter.Save())
                        {
                            AlertBox.Show(GetMessageSavedFields());
                            CanEdit = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                    break;

                case ToolBarButtonConstants.Editar:
                    CanEdit =  Id != 0;
                    break;

                case ToolBarButtonConstants.Cancelar:
                    ClearErrorsValidations();
                    _invoiceDetailsPresenter.Undo();
                    CanEdit = false;
                    break;

                case ToolBarButtonConstants.Eliminar:
                    try
                    {
                        if( _invoiceDetailsPresenter.Delete())
                        {
                            AlertBox.Show(GetMessageDeletedFields());
                            CanEdit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        _invoiceDetailsPresenter.Add();
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;

                case ToolBarButtonConstants.Buscar:
                
                    CommonWindowSearch<InvoiceDetails> search = new CommonWindowSearch<InvoiceDetails>(GeneralSearchFactory.MakeInvoiceDetailsSearch(_context), GetMessageFinding() + " " + GetTitle());
                    search.FormClosed += (senderX, eX) => {
                        try
                        {
                            if (search.Id != null)
                            {
                                if(this._invoiceDetailsPresenter.Find(search.Id))
                                {
                                    CanEdit = true;
                                    ClearErrorsValidations();
                                    ToolBarButtonRecargaCombo_Click(null,null);
                                }
                            }
							
							EnableDisableControls();
                        }
                        catch (Exception ex)
                        {
                           MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }

                    };
                    search.StartPosition = FormStartPosition.CenterScreen;
                    search.ShowDialog();
                    
                    break;
             
              	case ToolBarButtonConstants.Excel:
                
                    try
                    {
                        using (WorkBook wb = HelperDataTableToExcel.MakeDataTableToExcel(this._invoiceDetailsPresenter.GetDataTable()))
                        {
                        	using (Stream stream = new MemoryStream())
                        	{

                        	    wb.writeXLSX(stream);
                        		stream.Seek(0, SeekOrigin.Begin);
                        	    Application.Download(stream, GetTitle() + ".xlsx");

                        	}
                        }                    
                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

					break;      
            }
            
            this.toolBarButtonInfo.ToolTipText =   $"{GetCreated()} : {Creado} {FechaCreado}  {GetModified()}: {Modificado} {FechaModificado}";
        }
        private void DataGridViewInvoiceDetails_DoubleClick(object sender, EventArgs e)
        {
			if(dataGridViewInvoiceDetails.SelectedRows.Count > 0)
            {
				int id = (int)dataGridViewInvoiceDetails.SelectedRows[0][nameof(InvoiceDetails.Id)].Value;
				_invoiceDetailsPresenter.Find(id);
            }
        }


		private void FillUsercontrolSearch()
		{
			userControlSearchNumericProducts.DisplayMember = nameof(Products.Description);
			userControlSearchNumericProducts.ValueMember = nameof(Products.Id);
			userControlSearchNumericProducts.SearchNumericDataType = SearchNumericDataType.Integer;
			userControlSearchNumericProducts.SetDataSource(new SearchProductsPresenter(_context));
		}
		private void CalculateInvoiceHeaderTotals()
		{
			Invoices invoice = _context.Invoices.FirstOrDefault(i => i.Id == InvoiceId);
			if (invoice != null)
			{
				invoice.SubTotal = 0;
				invoice.TotalItbis = 0;
				invoice.Total = 0;

				List<InvoiceDetails> detalles = _context.InvoiceDetails.Where(i => i.InvoiceId == invoice.Id).ToList();
				foreach (InvoiceDetails detalle in detalles)
				{
					invoice.SubTotal += detalle.SubTotal;
					invoice.TotalItbis += detalle.TotalItbis;
					invoice.Total += detalle.Total;
				}

				_context.Entry(invoice).State = System.Data.Entity.EntityState.Modified;
				_context.SaveChanges();
				
				SaveHeaderChangesAfterAction?.Invoke();
			}
		}
		private void CalcularTotales()
		{
			/*SubTotal = Qty * Price;
			TotalItbis = SubTotal * 0.18m;
			Total = SubTotal + TotalItbis;*/
		}
		private void SetControls()
		{
			textBoxId.Tag = nameof(InvoiceDetails.Id);
			textBoxInvoiceId.Tag = nameof(InvoiceDetails.InvoiceId);
			numericUpDownQty.Tag = nameof(InvoiceDetails.Qty);
			numericUpDownPrice.Tag = nameof(InvoiceDetails.Price);
			numericUpDownTotalItbis.Tag = nameof(InvoiceDetails.TotalItbis);
			numericUpDownSubTotal.Tag = nameof(InvoiceDetails.SubTotal);
			numericUpDownTotal.Tag = nameof(InvoiceDetails.Total);
			userControlSearchNumericProducts.Tag = nameof(InvoiceDetails.productId);
			checkBoxIsActivo.Tag = nameof(InvoiceDetails.IsActivo);
		}
		private void EnableDisableControls()
		{

			toolBarButtonNuevo.Enabled = !CanEdit;
			toolBarButtonSalvar.Enabled = CanEdit;
			toolBarButtonEditar.Enabled = !CanEdit;
			toolBarButtonCancelar.Enabled = CanEdit;
			toolBarButtonEliminar.Enabled = !CanEdit;

			textBoxId.ReadOnly = true;
			textBoxInvoiceId.ReadOnly = true;
			numericUpDownQty.ReadOnly = !CanEdit;
			numericUpDownPrice.ReadOnly = !CanEdit;
			numericUpDownTotalItbis.ReadOnly = !CanEdit;
			numericUpDownSubTotal.ReadOnly = !CanEdit;
			numericUpDownTotal.ReadOnly = !CanEdit;
			checkBoxIsActivo.ReadOnly = !CanEdit;

		}
		public void ShowErrors()
		{
			_helperControls.ValidateMembers(_invoiceDetailsPresenter.ValidationResult);

		}
		public void ClearErrorsValidations()
		{
			_helperControls.ClearErrors(_invoiceDetailsPresenter.ValidationResult);
		}
		
		public DataGridView GetGrid()
        {
			return dataGridViewInvoiceDetails;
		}
	}

}
