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

        private readonly IPresenter customerTypesPresenter;
        private readonly HelperControlsToValidate helperControls;
        private bool _canEdit;
        
      
        private UserControlCustomerTypes(){
             InitializeComponent();
        }
        
        public UserControlCustomerTypes(IContext context):base(context)
        {
            Title = "CustomerTypes";
            InitializeComponent();
            setControls();
            customerTypesPresenter = new CustomerTypesPresenter(context, this);
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
        
        private void fillComboBox()
        {
                    
        }
        
     
        private void toolBarButtonRecargaCombo_Click(object sender, EventArgs e)
		{
			try
			{
                
				fillComboBox();
                
                
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        
        private void setControls()
        {
            textBoxId.Tag = nameof(CustomerTypes.Id);
			textBoxDescription.Tag = nameof(CustomerTypes.Description);
			checkBoxIsActivo.Tag = nameof(CustomerTypes.IsActivo);
			
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
			textBoxDescription.ReadOnly = !CanEdit;
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
        
        
       #region Properties CustomerTypes
       
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
		
		public  long TenantId
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
            get => dataGridView1.DataSource; 
            set => dataGridView1.DataSource = value; 
        }



        #endregion

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Name)
            {
                case ToolBarButtonConstants.Nuevo:
                    customerTypesPresenter.Add();
                    CanEdit = true;
                    break;

                case ToolBarButtonConstants.Salvar:

                    try
                    {
                        if (customerTypesPresenter.Save())
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
                    customerTypesPresenter.Undo();
                    CanEdit = false;
                    break;

                case ToolBarButtonConstants.Eliminar:
                    try
                    {
                        if( customerTypesPresenter.Delete())
                        {
                            AlertBox.Show(GetMessageDeletedFields());
                            CanEdit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        customerTypesPresenter.Add();
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;

                case ToolBarButtonConstants.Buscar:
                
                    WindowSearch<CustomerTypes> search = new WindowSearch<CustomerTypes>(GeneralSearchFactory.MakeCustomerTypesSearch(_context), GetMessageFinding() + " " + GetTitle());
                    search.FormClosed += (senderX, eX) => {
                        try
                        {
                            if (search.Id != null)
                            {
                                if(this.customerTypesPresenter.Find(search.Id))
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
                        using (WorkBook wb = HelperDataTableToExcel.MakeDataTableToExcel(this.customerTypesPresenter.GetDataTable()))
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
            helperControls.ValidateMembers(customerTypesPresenter.ValidationResult);

        }

        public void ClearErrorsValidations()
        {
            helperControls.ClearErrors(customerTypesPresenter.ValidationResult);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                int id = (int) dataGridView1.SelectedRows[0][nameof(CustomerTypes.Id)].Value;
                customerTypesPresenter.Find(id);
            }
        }

    }
}
