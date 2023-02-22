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
	public delegate void RaiseHeader();
    public partial class UserControlInvoiceDetails : UserControlBase, IInvoiceDetails, IValidate, IDataSource
    {

        private readonly IPresenter invoiceDetailsPresenter;
        private readonly HelperControlsToValidate helperControls;
        private bool _canEdit;
        private ISearchPresenter<Invoices> _searchPresenterInvoiceId;

		public event RaiseHeader OnRaiseHeader;
      
        private UserControlInvoiceDetails(){
             InitializeComponent();
        }
        
        public UserControlInvoiceDetails(IContext context):base(context)
        {
            Title = "InvoiceDetails";
            InitializeComponent();
            setControls();
            invoiceDetailsPresenter = new InvoiceDetailsPresenter(context, this);
			invoiceDetailsPresenter.BeforeSave += calcularTotales;
			invoiceDetailsPresenter.AfterSave += calcularTotalesHeader;

			helperControls = new HelperControlsToValidate(this.panelPricipal);
            this.toolBar1.ButtonClick += toolBar1_ButtonClick;
            CanEdit  = true;
        }

        private void calcularTotalesHeader()
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
				OnRaiseHeader?.Invoke();
			}
		}

        private void calcularTotales()
        {
			/*SubTotal = Qty * Price;
			TotalItbis = SubTotal * 0.18m;
			Total = SubTotal + TotalItbis;*/
        }

        private void toolBarButtonRecargaCombo_Click(object sender, EventArgs e)
		{
			try
			{

			}
			catch (Exception ex)
			{
				MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        
        private void setControls()
        {
            textBoxId.Tag = nameof(InvoiceDetails.Id);
			textBoxInvoiceId.Tag = nameof(InvoiceDetails.InvoiceId);
			numericUpDownQty.Tag = nameof(InvoiceDetails.Qty);
			numericUpDownPrice.Tag = nameof(InvoiceDetails.Price);
			numericUpDownTotalItbis.Tag = nameof(InvoiceDetails.TotalItbis);
			numericUpDownSubTotal.Tag = nameof(InvoiceDetails.SubTotal);
			numericUpDownTotal.Tag = nameof(InvoiceDetails.Total);
			checkBoxIsActivo.Tag = nameof(InvoiceDetails.IsActivo);
			
        }


        public  bool CanEdit
        {
            get
            {
                return _canEdit;
            }
            set {
            
                _canEdit = value;
                
                enableDisableControls();
            }
        } 
        
        private void enableDisableControls() {
        
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
        
      
        
        private void panelPricipal_PanelCollapsed(object sender, EventArgs e)
		{
			if (this.panelPricipal.Collapsed)
			{
				this.panelPricipal.HeaderPosition = HeaderPosition.Top;
			}
		}

		private void panelPricipal_PanelExpanded(object sender, EventArgs e)
		{
			if (!this.panelPricipal.Collapsed)
			{
				this.panelPricipal.HeaderPosition = HeaderPosition.Left;
			}
		}
        
        
       #region Properties InvoiceDetails
       
       private int _Id;
		public  int Id
		{
			get
			{
				bool result = int.TryParse(textBoxId.Text, out _Id);
			    if (!result)
			         textBoxId.Text = "0";
				return _Id;
			}
			set
			{
				textBoxId.Text = value.ToString();
				this.toolBarButtonInfo.ToolTipText =   $"{GetCreated()} : {Creado} {FechaCreado}  {GetModified()}: {Modificado} {FechaModificado}";
				this.panelPricipal.Text = GetTitle() + " (" + value.ToString() + ")";
			}
		}
		
		private int _InvoiceId;
		public  int InvoiceId
		{
			get
			{
				if(textBoxInvoiceId.Text != null)
					_InvoiceId = Convert.ToInt32(textBoxInvoiceId.Text);

				return _InvoiceId;
			}
			set
			{
				_InvoiceId = value;
				textBoxInvoiceId.Text = value.ToString();
				if(invoiceDetailsPresenter != null)
					invoiceDetailsPresenter.FillDataSource();
			}
		}
		
		public int Qty
		{
			get
			{
				 return (int) numericUpDownQty.Value;
			}
			set
			{
				numericUpDownQty.Value  = value;
			}
		}
		
		public decimal Price
		{
			get
			{
				 return (decimal) numericUpDownPrice.Value;
			}
			set
			{
				numericUpDownPrice.Value  = value;
			}
		}
		
		public decimal TotalItbis
		{
			get
			{
				 return (decimal) numericUpDownTotalItbis.Value;
			}
			set
			{
				numericUpDownTotalItbis.Value  = value;
			}
		}
		
		public decimal SubTotal
		{
			get
			{
				 return (decimal) numericUpDownSubTotal.Value;
			}
			set
			{
				numericUpDownSubTotal.Value  = value;
			}
		}
		
		public decimal Total
		{
			get
			{
				 return (decimal) numericUpDownTotal.Value;
			}
			set
			{
				numericUpDownTotal.Value  = value;
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
				checkBoxIsActivo.Checked  = value;
			}
		}
		
		public  string Creado
		{
			get; set;
		}
		
		public  DateTime FechaCreado
		{
			get; set;
		}
		
		public  string Modificado
		{
			get; set;
		}
		
		public  DateTime FechaModificado
		{
			get; set;
		}
        public object DataGridSource { 
			get => dataGridViewInvoiceDetails.DataSource; 
			set => dataGridViewInvoiceDetails.DataSource = value; 
		}



        #endregion

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Name)
            {
                case ToolBarButtonConstants.Nuevo:
                    invoiceDetailsPresenter.Add();
                    CanEdit = true;
                    break;

                case ToolBarButtonConstants.Salvar:

                    try
                    {
                        if (invoiceDetailsPresenter.Save())
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
                    invoiceDetailsPresenter.Undo();
                    CanEdit = false;
                    break;

                case ToolBarButtonConstants.Eliminar:
                    try
                    {
                        if( invoiceDetailsPresenter.Delete())
                        {
                            AlertBox.Show(GetMessageDeletedFields());
                            CanEdit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        invoiceDetailsPresenter.Add();
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;

                case ToolBarButtonConstants.Buscar:
                
                    WindowSearch<InvoiceDetails> search = new WindowSearch<InvoiceDetails>(GeneralSearchFactory.MakeInvoiceDetailsSearch(_context), GetMessageFinding() + " " + GetTitle());
                    search.FormClosed += (senderX, eX) => {
                        try
                        {
                            if (search.Id != null)
                            {
                                if(this.invoiceDetailsPresenter.Find(search.Id))
                                {
                                    CanEdit = true;
                                    ClearErrorsValidations();
                                    toolBarButtonRecargaCombo_Click(null,null);
                                }
                            }
							
							enableDisableControls();
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
                        using (WorkBook wb = HelperDataTableToExcel.MakeDataTableToExcel(this.invoiceDetailsPresenter.GetDataTable()))
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

      

        public void ShowErrors()
        {
            helperControls.ValidateMembers(invoiceDetailsPresenter.ValidationResult);

        }

        public void ClearErrorsValidations()
        {
            helperControls.ClearErrors(invoiceDetailsPresenter.ValidationResult);
        }

        private void dataGridViewInvoiceDetails_DoubleClick(object sender, EventArgs e)
        {
			if(dataGridViewInvoiceDetails.SelectedRows.Count > 0)
            {
				int id = (int)dataGridViewInvoiceDetails.SelectedRows[0][nameof(InvoiceDetails.Id)].Value;
				invoiceDetailsPresenter.Find(id);
            }
        }
    }
}
