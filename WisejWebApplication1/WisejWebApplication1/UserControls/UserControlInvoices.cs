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
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using BusinessObjects.Helpers;
using System.Data;

namespace CommonUserControls
{
    public partial class UserControlInvoices : UserControlBase, IInvoices, IValidate
    {

        private readonly IPresenter _invoicesPresenter;
        private readonly HelperControlsToValidate _helperControls;
        private readonly UserControlInvoiceDetails _userControlInvoiceDetails;
        private ISearchPresenter<Customers> _searchPresenterCustomerId;

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

        #region Properties Invoices

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

                _userControlInvoiceDetails.InvoiceId = Id;
            }
        }

        private int _CustomerId;
        public int CustomerId
        {
            get
            {
                if (comboBoxCustomerId.SelectedValue != null)
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
                return (decimal)numericUpDownTotalItbis.Value;
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
                return (decimal)numericUpDownSubTotal.Value;
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
                return (decimal)numericUpDownTotal.Value;
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

        public long TenantId { get; set; }

        #endregion



        public UserControlInvoices(IContext context, UserControlInvoiceDetails userControlInvoiceDetails)
            :base(context)
        {
            InitializeComponent();
            
            Title = "Invoices";
            CanEdit  = true;

            SetControls();
            
            _userControlInvoiceDetails = userControlInvoiceDetails;
            panelDetalles.Controls.Add(userControlInvoiceDetails);
            userControlInvoiceDetails.Dock = DockStyle.Fill;
            userControlInvoiceDetails.SaveHeaderChangesAfterAction = RefreshHeader;

            _invoicesPresenter = new InvoicesPresenter(context, this);
            _helperControls = new HelperControlsToValidate(panelPricipal);

            toolBar1.ButtonClick += ToolBar1_ButtonClick;

            try
            {
                FillComboBox();
            }
            catch(Exception ex )
            {
				MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        

        private void ToolBarButtonRecargaCombo_Click(object sender, EventArgs e)
		{
			try
			{
                var objCustomerId = comboBoxCustomerId.SelectedValue;
				
				FillComboBox();
                
                if(objCustomerId != null )
					comboBoxCustomerId.SelectedValue = objCustomerId;
				
				
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        private void PanelPricipal_PanelCollapsed(object sender, EventArgs e)
		{
			if (this.panelPricipal.Collapsed)
			{
				this.panelPricipal.HeaderPosition = HeaderPosition.Top;
			}
		}
		private void PanelPricipal_PanelExpanded(object sender, EventArgs e)
		{
			if (!this.panelPricipal.Collapsed)
			{
				this.panelPricipal.HeaderPosition = HeaderPosition.Left;
			}
		}
        private void ToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Name)
            {
                case ToolBarButtonConstants.Nuevo:
                    _invoicesPresenter.Add();
                    CanEdit = true;
                    break;

                case ToolBarButtonConstants.Salvar:

                    try
                    {
                        if (_invoicesPresenter.Save())
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
                    _invoicesPresenter.Undo();
                    CanEdit = false;
                    break;

                case ToolBarButtonConstants.Eliminar:
                    try
                    {
                        if( _invoicesPresenter.Delete())
                        {
                            AlertBox.Show(GetMessageDeletedFields());
                            CanEdit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        _invoicesPresenter.Add();
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;

                case ToolBarButtonConstants.Buscar:
                
                    CommonWindowSearch<Invoices> search = new CommonWindowSearch<Invoices>(GeneralSearchFactory.MakeInvoicesSearch(_context), GetMessageFinding() + " " + GetTitle());
                    search.FormClosed += (senderX, eX) => {
                        try
                        {
                            if (search.Id != null)
                            {
                                if(this._invoicesPresenter.Find(search.Id))
                                {
                                    CanEdit = false;
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
                        using (WorkBook wb = HelperDataTableToExcel.MakeDataTableToExcel(this._invoicesPresenter.GetDataTable()))
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
                case ToolBarButtonConstants.Imprimir:
                    PrintInvoiceDetails();
                    break;
            }
            
            this.toolBarButtonInfo.ToolTipText =   $"{GetCreated()} : {Creado} {FechaCreado}  {GetModified()}: {Modificado} {FechaModificado}";
        }

        private void PrintInvoiceDetails()
        {
            string invoiceDetailReport = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\Factura.frx");
            FastReport.Report report = FastReport.Report.FromFile(invoiceDetailReport);

            DataTable data = _context.InvoiceDetails
                .Include(i => i.Invoice)
                .Include(i => i.Invoice.Customer)
                .Include(i => i.Product)
                .AsEnumerable()
                .Select(i => new ViewInvoices() 
                {
                    Id = i.Id,
                    ProductId = i.productId,
                    Description = i.Product.Description,
                    CustName = i.Invoice.Customer.CustName,
                    Adress = i.Invoice.Customer.Adress,
                    FechaCreado = i.FechaCreado,
                    Price = i.Price,
                    Qty = i.Qty,
                    SubTotal = i.SubTotal,
                    TotalItbis = i.TotalItbis,
                    Total = i.Total
                })
                .OrderBy(i => i.Id)
                .ThenBy(i => i.ProductId)
                .ToDataTable(nameof(ViewInvoices));

            DataSet ds = new DataSet("ds");
            ds.Tables.Add(data);
            //_userControlInvoiceDetails.GetGrid().DataSource = data;

            report.RegisterData(ds, data.TableName);
            report.Prepare();
            report.Print();
        }

        private void SetControls()
        {
            textBoxId.Tag = nameof(Invoices.Id);
            comboBoxCustomerId.Tag = nameof(Invoices.CustomerId);
            numericUpDownTotalItbis.Tag = nameof(Invoices.TotalItbis);
            numericUpDownSubTotal.Tag = nameof(Invoices.SubTotal);
            numericUpDownTotal.Tag = nameof(Invoices.Total);
            checkBoxIsActivo.Tag = nameof(Invoices.IsActivo);

        }
        private void RefreshHeader()
        {
            if (Id > 0)
            {
                _invoicesPresenter.Find(Id);
            }
        }
        private void FillComboBox()
        {
            _searchPresenterCustomerId = GeneralSearchFactory.MakeCustomersSearch(_context);
            comboBoxCustomerId.DisplayMember = nameof(Customers.CustName);
            comboBoxCustomerId.ValueMember = nameof(Customers.Id);
            comboBoxCustomerId.DataSource = _searchPresenterCustomerId.GetAll();

        }
        private void EnableDisableControls()
        {

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
        public void ShowErrors()
        {
            _helperControls.ValidateMembers(_invoicesPresenter.ValidationResult);

        }
        public void ClearErrorsValidations()
        {
            _helperControls.ClearErrors(_invoicesPresenter.ValidationResult);
        }
       
    }

}
