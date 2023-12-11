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

        private readonly IPresenter _productsPresenter;
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

        #region Properties Products

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
            get => dataGridViewProducts.DataSource;
            set => dataGridViewProducts.DataSource = value;
        }

        #endregion


        private UserControlProducts(){
             InitializeComponent();
        }
        public UserControlProducts(IContext context)
            :base(context)
        {
            InitializeComponent();
            
            Title = "Products";
            CanEdit  = true;
            
            SetControls();
            
            _productsPresenter = new ProductsPresenter(context, this);
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
                    _productsPresenter.Add();
                    CanEdit = true;
                    break;

                case ToolBarButtonConstants.Salvar:

                    try
                    {
                        if (_productsPresenter.Save())
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
                    _productsPresenter.Undo();
                    CanEdit = false;
                    break;

                case ToolBarButtonConstants.Eliminar:
                    try
                    {
                        if( _productsPresenter.Delete())
                        {
                            AlertBox.Show(GetMessageDeletedFields());
                            CanEdit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        _productsPresenter.Add();
                        MessageBox.Show(GetMessageException() + ex.Message, GetMessageNotice(), MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;

                case ToolBarButtonConstants.Buscar:
                
                    CommonWindowSearch<Products> search = new CommonWindowSearch<Products>(GeneralSearchFactory.MakeProductsSearch(_context), GetMessageFinding() + " " + GetTitle());
                    search.FormClosed += (senderX, eX) => {
                        try
                        {
                            if (search.Id != null)
                            {
                                if(this._productsPresenter.Find(search.Id))
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
                        using (WorkBook wb = HelperDataTableToExcel.MakeDataTableToExcel(this._productsPresenter.GetDataTable()))
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

      
        private void SetControls()
        {
            textBoxId.Tag = nameof(Products.Id);
			textBoxDescription.Tag = nameof(Products.Description);
			checkBoxIsActivo.Tag = nameof(Products.IsActivo);
			
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
        public void ShowErrors()
        {
            _helperControls.ValidateMembers(_productsPresenter.ValidationResult);

        }
        public void ClearErrorsValidations()
        {
            _helperControls.ClearErrors(_productsPresenter.ValidationResult);
        }

    }

}
