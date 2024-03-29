﻿//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/20/2023 3:30:59 PM
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



namespace CommonUserControls
{
    public partial class UserControlCustomers : UserControlBase, ICustomers, IValidate
    {

        private readonly IPresenter customersPresenter;
        private readonly HelperControlsToValidate helperControls;
        private bool _canEdit;
        private ISearchPresenter<CustomerTypes> _searchPresenterCustomerTypeId;
		
      
        private UserControlCustomers(){
             InitializeComponent();
        }
        
        public UserControlCustomers(IContext context):base(context)
        {
            Title = "Customers";
            InitializeComponent();
            setControls();
            customersPresenter = new CustomersPresenter(context, this);
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
            _searchPresenterCustomerTypeId = GeneralSearchFactory.MakeCustomerTypesSearch(_context);
			comboBoxCustomerTypeId.DisplayMember = nameof(CustomerTypes.Description);
			comboBoxCustomerTypeId.ValueMember = nameof(CustomerTypes.Id);
			comboBoxCustomerTypeId.DataSource = _searchPresenterCustomerTypeId.GetAll();
			        
        }
        
     
        private void toolBarButtonRecargaCombo_Click(object sender, EventArgs e)
		{
			try
			{
                var objCustomerTypeId = comboBoxCustomerTypeId.SelectedValue;
				
				fillComboBox();
                
                if(objCustomerTypeId != null )
					comboBoxCustomerTypeId.SelectedValue = objCustomerTypeId;
				
				
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
        
        private void setControls()
        {
            textBoxId.Tag = nameof(Customers.Id);
			textBoxCustName.Tag = nameof(Customers.CustName);
			textBoxAdress.Tag = nameof(Customers.Adress);
			checkBoxStatus.Tag = nameof(Customers.Status);
			comboBoxCustomerTypeId.Tag = nameof(Customers.CustomerTypeId);
			checkBoxIsActivo.Tag = nameof(Customers.IsActivo);
			
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
			textBoxCustName.ReadOnly = !CanEdit;
			textBoxAdress.ReadOnly = !CanEdit;
			checkBoxStatus.ReadOnly = !CanEdit;
			comboBoxCustomerTypeId.ReadOnly = !CanEdit;
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
        
        
       #region Properties Customers
       
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
				checkBoxStatus.Checked  = value;
			}
		}
		
		private int _CustomerTypeId;
		public  int CustomerTypeId
		{
			get
			{
				if(comboBoxCustomerTypeId.SelectedValue != null)
					_CustomerTypeId = Convert.ToInt32(comboBoxCustomerTypeId.SelectedValue);

				return _CustomerTypeId;
			}
			set
			{
				_CustomerTypeId = value;
				comboBoxCustomerTypeId.SelectedValue = value;
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
                case "toolBarButtonNuevo":
                    customersPresenter.Add();
                    CanEdit = true;
                    break;

                case "toolBarButtonSalvar":

                    try
                    {
                        if (customersPresenter.Save())
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

                case "toolBarButtonEditar":
                    CanEdit =  Id != 0;
                    break;

                case "toolBarButtonCancelar":
                    ClearErrorsValidations();
                    customersPresenter.Undo();
                    CanEdit = false;
                    break;

                case "toolBarButtonEliminar":
                    try
                    {
                        if( customersPresenter.Delete())
                        {
                            AlertBox.Show(GetMessageDeletedFields());
                            CanEdit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        customersPresenter.Add();
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;

                case "toolBarButtonBuscar":
                
                    WindowSearch<Customers> search = new WindowSearch<Customers>(GeneralSearchFactory.MakeCustomersSearch(_context), GetMessageFinding() + " " + GetTitle());
                    search.FormClosed += (senderX, eX) => {
                        try
                        {
                            if (search.Id != null)
                            {
                                if(this.customersPresenter.Find(search.Id))
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
             
              	case "toolBarButtonExcel":
                
                    try
                    {
                        using (WorkBook wb = HelperDataTableToExcel.MakeDataTableToExcel(this.customersPresenter.GetDataTable()))
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
            helperControls.ValidateMembers(customersPresenter.ValidationResult);

        }

        public void ClearErrorsValidations()
        {
            helperControls.ClearErrors(customersPresenter.ValidationResult);
        }

       
    }
}
