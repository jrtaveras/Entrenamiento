//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/22/2023 8:17:55 AM
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
    public partial class UserControlProducts : UserControlBase, IProducts, IValidate, IDataSource
    {

        private readonly IPresenter productsPresenter;
        private readonly HelperControlsToValidate helperControls;
        private bool _canEdit;
        
      
        private UserControlProducts(){
             InitializeComponent();
        }
        
        public UserControlProducts(IContext context):base(context)
        {
            Title = "Products";
            InitializeComponent();
            setControls();
            productsPresenter = new ProductsPresenter(context, this);
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
            textBoxId.Tag = nameof(Products.Id);
			textBoxDescription.Tag = nameof(Products.Description);
			checkBoxIsActivo.Tag = nameof(Products.IsActivo);
			
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
        
        
       #region Properties Products
       
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
        public object DataGridSource 
        { 
            get => dataGridViewProducts.DataSource; 
            set => dataGridViewProducts.DataSource = value;
        }



        #endregion

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Name)
            {
                case ToolBarButtonConstants.Nuevo:
                    productsPresenter.Add();
                    CanEdit = true;
                    break;

                case ToolBarButtonConstants.Salvar:

                    try
                    {
                        if (productsPresenter.Save())
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
                    productsPresenter.Undo();
                    CanEdit = false;
                    break;

                case ToolBarButtonConstants.Eliminar:
                    try
                    {
                        if( productsPresenter.Delete())
                        {
                            AlertBox.Show(GetMessageDeletedFields());
                            CanEdit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        productsPresenter.Add();
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;

                case ToolBarButtonConstants.Buscar:
                
                    WindowSearch<Products> search = new WindowSearch<Products>(GeneralSearchFactory.MakeProductsSearch(_context), GetMessageFinding() + " " + GetTitle());
                    search.FormClosed += (senderX, eX) => {
                        try
                        {
                            if (search.Id != null)
                            {
                                if(this.productsPresenter.Find(search.Id))
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
                        using (WorkBook wb = HelperDataTableToExcel.MakeDataTableToExcel(this.productsPresenter.GetDataTable()))
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
            helperControls.ValidateMembers(productsPresenter.ValidationResult);

        }

        public void ClearErrorsValidations()
        {
            helperControls.ClearErrors(productsPresenter.ValidationResult);
        }

       
    }
}
