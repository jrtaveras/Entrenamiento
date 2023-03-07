//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/21/2023 2:49:39 PM
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
    public partial class UserControlCustomers : UserControlBase, ICustomers, IValidate, IDataSource
    {

        private readonly IPresenter _customersPresenter;
        private readonly HelperControlsToValidate _helperControls;
        private ISearchPresenter<CustomerTypes> _searchPresenterCustomerTypeId;
		
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

        #region Properties Customers

        private int _id;
        public int Id
        {
            get
            {
                bool result = int.TryParse(textBoxId.Text, out _id);
                if (result == false)
                    textBoxId.Text = "0";
                return _id;
            }
            set
            {
                textBoxId.Text = value.ToString();
                toolBarButtonInfo.ToolTipText = $"{GetCreated()} : {Creado} {FechaCreado}  {GetModified()}: {Modificado} {FechaModificado}";
                panelPricipal.Text = GetTitle() + " (" + value.ToString() + ")";
            }
        }

        public string CustName
        {
            get
            {
                return textBoxCustName.Text;
            }
            set
            {
                textBoxCustName.Text = value;
            }
        }

        public string Adress
        {
            get
            {
                return textBoxAdress.Text;
            }
            set
            {
                textBoxAdress.Text = value;
            }
        }

        public bool Status
        {
            get
            {
                return checkBoxStatus.Checked;
            }
            set
            {
                checkBoxStatus.Checked = value;
            }
        }

        private int _CustomerTypeId;
        public int CustomerTypeId
        {
            get
            {
                if (comboBoxCustomerTypeId.SelectedValue != null)
                    _CustomerTypeId = Convert.ToInt32(comboBoxCustomerTypeId.SelectedValue);

                return _CustomerTypeId;
            }
            set
            {
                _CustomerTypeId = value;
                comboBoxCustomerTypeId.SelectedValue = value;
            }
        }

        public long TenantId
        {
            get; set;
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
            get => dataGridView1.DataSource;
            set => dataGridView1.DataSource = value;
        }

        #endregion

        private UserControlCustomers(){
             InitializeComponent();
        }
        
        public UserControlCustomers(IContext context):base(context)
        {
            InitializeComponent();
            
            Title = "Customers";
            CanEdit  = true;
            
            SetControls();
            
            _customersPresenter = new CustomersPresenter(context, this);
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
                var objCustomerTypeId = comboBoxCustomerTypeId.SelectedValue;
				
				FillComboBox();
                
                if(objCustomerTypeId != null )
					comboBoxCustomerTypeId.SelectedValue = objCustomerTypeId;

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
                    _customersPresenter.Add();
                    CanEdit = true;
                    break;

                case ToolBarButtonConstants.Salvar:

                    try
                    {
                        if (_customersPresenter.Save())
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
                    _customersPresenter.Undo();
                    CanEdit = false;
                    break;

                case ToolBarButtonConstants.Eliminar:
                    try
                    {
                        if( _customersPresenter.Delete())
                        {
                            AlertBox.Show(GetMessageDeletedFields());
                            CanEdit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        _customersPresenter.Add();
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;

                case ToolBarButtonConstants.Buscar:
                
                    CommonWindowSearch<Customers> search = new CommonWindowSearch<Customers>(GeneralSearchFactory.MakeCustomersSearch(_context), GetMessageFinding() + " " + GetTitle());
                    search.FormClosed += (senderX, eX) => {
                        try
                        {
                            if (search.Id != null)
                            {
                                if(this._customersPresenter.Find(search.Id))
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
                        using (WorkBook wb = HelperDataTableToExcel.MakeDataTableToExcel(this._customersPresenter.GetDataTable()))
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
        private void DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int) dataGridView1.SelectedRows[0][nameof(Customers.Id)].Value;
                _customersPresenter.Find(id);
            }
        }
        

        private void FillComboBox()
        {
            _searchPresenterCustomerTypeId = GeneralSearchFactory.MakeCustomerTypesSearch(_context);
			comboBoxCustomerTypeId.DisplayMember = nameof(CustomerTypes.Description);
			comboBoxCustomerTypeId.ValueMember = nameof(CustomerTypes.Id);
			comboBoxCustomerTypeId.DataSource = _searchPresenterCustomerTypeId.GetAll();
			        
        }
        private void SetControls()
        {
            textBoxId.Tag = nameof(Customers.Id);
			textBoxCustName.Tag = nameof(Customers.CustName);
			textBoxAdress.Tag = nameof(Customers.Adress);
			checkBoxStatus.Tag = nameof(Customers.Status);
			comboBoxCustomerTypeId.Tag = nameof(Customers.CustomerTypeId);
			checkBoxIsActivo.Tag = nameof(Customers.IsActivo);
			
        }
        private void EnableDisableControls() {
        
			toolBarButtonNuevo.Enabled = !CanEdit;
			toolBarButtonSalvar.Enabled = CanEdit;
			toolBarButtonEditar.Enabled = !CanEdit;
			toolBarButtonCancelar.Enabled = CanEdit;
			toolBarButtonEliminar.Enabled = !CanEdit;

            textBoxId.ReadOnly = true;
			textBoxCustName.ReadOnly = !CanEdit;
			textBoxAdress.ReadOnly = !CanEdit;
			checkBoxStatus.ReadOnly = !CanEdit;
			comboBoxCustomerTypeId.ReadOnly = !CanEdit;
			checkBoxIsActivo.ReadOnly = !CanEdit;
			
        
		}
        public void ClearErrorsValidations()
        {
            _helperControls.ClearErrors(_customersPresenter.ValidationResult);
        }
        public void ShowErrors()
        {
            _helperControls.ValidateMembers(_customersPresenter.ValidationResult);

        }
    }

}
