//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/21/2023 2:49:58 PM
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
    public partial class UserControlCustomerTypes : UserControlBase, ICustomerTypes, IValidate, IDataSource
    {

        private readonly IPresenter _customerTypesPresenter;
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

        #region Properties CustomerTypes

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

        public string Description
        {
            get
            {
                return textBoxDescription.Text;
            }
            set
            {
                textBoxDescription.Text = value;
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

        private UserControlCustomerTypes(){
             InitializeComponent();
        }
        public UserControlCustomerTypes(IContext context):base(context)
        {
            InitializeComponent();
            
            Title = "CustomerTypes";
            CanEdit  = true;
            
            SetControls();
            
            _customerTypesPresenter = new CustomerTypesPresenter(context, this);
            _helperControls = new HelperControlsToValidate(panelPricipal);
            toolBar1.ButtonClick += ToolBar1_ButtonClick;
        }
        

        private void ToolBarButtonRecargaCombo_Click(object sender, EventArgs e)
		{

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
                    _customerTypesPresenter.Add();
                    CanEdit = true;
                    break;

                case ToolBarButtonConstants.Salvar:

                    try
                    {
                        if (_customerTypesPresenter.Save())
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
                    _customerTypesPresenter.Undo();
                    CanEdit = false;
                    break;

                case ToolBarButtonConstants.Eliminar:
                    try
                    {
                        if( _customerTypesPresenter.Delete())
                        {
                            AlertBox.Show(GetMessageDeletedFields());
                            CanEdit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        _customerTypesPresenter.Add();
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;

                case ToolBarButtonConstants.Buscar:
                
                    CommonWindowSearch<CustomerTypes> search = new CommonWindowSearch<CustomerTypes>(GeneralSearchFactory.MakeCustomerTypesSearch(_context), GetMessageFinding() + " " + GetTitle());
                    search.FormClosed += (senderX, eX) => {
                        try
                        {
                            if (search.Id != null)
                            {
                                if(this._customerTypesPresenter.Find(search.Id))
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
                        using (WorkBook wb = HelperDataTableToExcel.MakeDataTableToExcel(this._customerTypesPresenter.GetDataTable()))
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
                int id = (int) dataGridView1.SelectedRows[0][nameof(CustomerTypes.Id)].Value;
                _customerTypesPresenter.Find(id);
            }
        }


        private void SetControls()
        {
            textBoxId.Tag = nameof(CustomerTypes.Id);
			textBoxDescription.Tag = nameof(CustomerTypes.Description);
			checkBoxIsActivo.Tag = nameof(CustomerTypes.IsActivo);
        }
        private void EnableDisableControls() {
        
			toolBarButtonNuevo.Enabled = !CanEdit;
			toolBarButtonSalvar.Enabled = CanEdit;
			toolBarButtonEditar.Enabled = !CanEdit;
			toolBarButtonCancelar.Enabled = CanEdit;
			toolBarButtonEliminar.Enabled = !CanEdit;

            textBoxId.ReadOnly = true;
			textBoxDescription.ReadOnly = !CanEdit;
			checkBoxIsActivo.ReadOnly = !CanEdit;

		}
        public void ClearErrorsValidations()
        {
            _helperControls.ClearErrors(_customerTypesPresenter.ValidationResult);
        }
        public void ShowErrors()
        {
            _helperControls.ValidateMembers(_customerTypesPresenter.ValidationResult);

        }
    
    }
}
