//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/21/2023 2:50:16 PM
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


namespace CommonUserControls
{
    public partial class UserControlInvoices : UserControlBase, IInvoices, IValidate
    {

        private readonly IPresenter invoicesPresenter;
        private readonly HelperControlsToValidate helperControls;
        private readonly UserControlInvoiceDetails userControlInvoiceDetails;

        private bool _canEdit;
        private ISearchPresenter<Customers> _searchPresenterCustomerId;
		
      

        public UserControlInvoices(IContext context, UserControlInvoiceDetails userControlInvoiceDetails):base(context)
        {
            Title = "Invoices";
            InitializeComponent();

            this.userControlInvoiceDetails = userControlInvoiceDetails;

            panelDetalles.Controls.Add(userControlInvoiceDetails);
            userControlInvoiceDetails.Dock = DockStyle.Fill;
            userControlInvoiceDetails.OnRaiseHeader += refreshHeader;

            setControls();
            invoicesPresenter = new InvoicesPresenter(context, this);

            helperControls = new HelperControlsToValidate(this.panelPricipal);
            this.toolBar1.ButtonClick += toolBar1_ButtonClick;
            CanEdit  = true;

            
            try
            {
               
                fillComboBox();
                
            }
            catch(Exception ex )
            {
				MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            
        }

        private void refreshHeader()
        {
            if(Id > 0)
            {
                invoicesPresenter.Find(Id);
            }
        }

        private void fillComboBox()
        {
            _searchPresenterCustomerId = GeneralSearchFactory.MakeCustomersSearch(_context);
			comboBoxCustomerId.DisplayMember = nameof(Customers.CustName);
			comboBoxCustomerId.ValueMember = nameof(Customers.Id);
			comboBoxCustomerId.DataSource = _searchPresenterCustomerId.GetAll();
			        
        }
        
     
        private void toolBarButtonRecargaCombo_Click(object sender, EventArgs e)
		{
			try
			{
                var objCustomerId = comboBoxCustomerId.SelectedValue;
				
				fillComboBox();
                
                if(objCustomerId != null )
					comboBoxCustomerId.SelectedValue = objCustomerId;
				
				
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        
        private void setControls()
        {
            textBoxId.Tag = nameof(Invoices.Id);
			comboBoxCustomerId.Tag = nameof(Invoices.CustomerId);
			numericUpDownTotalItbis.Tag = nameof(Invoices.TotalItbis);
			numericUpDownSubTotal.Tag = nameof(Invoices.SubTotal);
			numericUpDownTotal.Tag = nameof(Invoices.Total);
			checkBoxIsActivo.Tag = nameof(Invoices.IsActivo);
			
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
			comboBoxCustomerId.ReadOnly = !CanEdit;
			numericUpDownTotalItbis.ReadOnly = !CanEdit;
			numericUpDownSubTotal.ReadOnly = !CanEdit;
			numericUpDownTotal.ReadOnly = !CanEdit;
			checkBoxIsActivo.ReadOnly = !CanEdit;

            panelDetalles.Enabled = Id > 0 && !CanEdit;
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
        
        
       #region Properties Invoices
       
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

                userControlInvoiceDetails.InvoiceId = this.Id;
            }
		}
		
		private int _CustomerId;
		public  int CustomerId
		{
			get
			{
				if(comboBoxCustomerId.SelectedValue != null)
					_CustomerId = Convert.ToInt32(comboBoxCustomerId.SelectedValue);

				return _CustomerId;
			}
			set
			{
				_CustomerId = value;
				comboBoxCustomerId.SelectedValue = value;
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
		
		
       
       #endregion

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Name)
            {
                case ToolBarButtonConstants.Nuevo:
                    invoicesPresenter.Add();
                    CanEdit = true;
                    break;

                case ToolBarButtonConstants.Salvar:

                    try
                    {
                        if (invoicesPresenter.Save())
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
                    invoicesPresenter.Undo();
                    CanEdit = false;
                    break;

                case ToolBarButtonConstants.Eliminar:
                    try
                    {
                        if( invoicesPresenter.Delete())
                        {
                            AlertBox.Show(GetMessageDeletedFields());
                            CanEdit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        invoicesPresenter.Add();
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;

                case ToolBarButtonConstants.Buscar:
                
                    WindowSearch<Invoices> search = new WindowSearch<Invoices>(GeneralSearchFactory.MakeInvoicesSearch(_context), GetMessageFinding() + " " + GetTitle());
                    search.FormClosed += (senderX, eX) => {
                        try
                        {
                            if (search.Id != null)
                            {
                                if(this.invoicesPresenter.Find(search.Id))
                                {
                                    CanEdit = false;
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
                        using (WorkBook wb = HelperDataTableToExcel.MakeDataTableToExcel(this.invoicesPresenter.GetDataTable()))
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
            helperControls.ValidateMembers(invoicesPresenter.ValidationResult);

        }

        public void ClearErrorsValidations()
        {
            helperControls.ClearErrors(invoicesPresenter.ValidationResult);
        }

       
    }
}
