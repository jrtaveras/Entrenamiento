#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using VisualWebGuiInvoice.BusinessObjects;
using FSchad.Tools.CustomClasses;
using BusinessObjects;
using VisualWebGuiInvoice.BusinessObjects.Helpers;
using System.Collections;
using FSchad.Tools.UserControls;
using FSchad.Tools.Forms;

#endregion

namespace VisualWebGuiInvoice.UserControls
{
    public partial class UserControlProducts : UserControl
    {
        private readonly ProductController _productController;
        private readonly ClassError objClassError = new ClassError();

        public UserControlProducts()
        {
            InitializeComponent();

            userControlToolbar1.Size = new Size(userControlToolbar1.Width, 35);

            _productController = new ProductController();
            _productController.OnRaiseError += new RaiseErrorDelegate(_ProductsController_OnRaiseError);

            _Bindings();
            _LoadData();

            _PrepareValidations();
        }

        private void _ProductsController_OnRaiseError(Hashtable ht)
        {
            objClassError.SetError(ht, this.Controls);
        }
        
        private void _PrepareValidations()
        {
            textBoxDescription.Tag = ProductsMetadata.ColumnNames.Description;
        }

        private void _LoadData()
        {
            listViewData.DataSource = _productController.LoadDataTable();
        }

        private void _Bindings()
        {
            textBoxId.DataBindings.Add(new Binding("Text", _productController, ProductsMetadata.ColumnNames.Id, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxDescription.DataBindings.Add(new Binding("Text", _productController, ProductsMetadata.ColumnNames.Description, false, DataSourceUpdateMode.OnPropertyChanged));
            
            textBoxCreado.DataBindings.Add(new Binding("Text", _productController, ProductsMetadata.ColumnNames.Creado, false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePickerFechaCreado.DataBindings.Add(new Binding("Value", _productController, ProductsMetadata.ColumnNames.FechaCreado, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxModificado.DataBindings.Add(new Binding("Text", _productController, ProductsMetadata.ColumnNames.Modificado, false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePickerFechaModificado.DataBindings.Add(new Binding("Value", _productController, ProductsMetadata.ColumnNames.FechaModificado, false, DataSourceUpdateMode.OnPropertyChanged));
            checkBoxIsActivo.DataBindings.Add(new Binding("Checked", _productController, ProductsMetadata.ColumnNames.IsActivo, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxTenantId.DataBindings.Add(new Binding("Text", _productController, ProductsMetadata.ColumnNames.TenantId, false, DataSourceUpdateMode.OnPropertyChanged));
            
            userControlToolbar1_OnEnabledDisabledControls(OnToolBarState.None);
        }

        private bool userControlToolbar1_OnAddNewEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return _productController.AddNewEntity();
        }

        private bool userControlToolbar1_OnDeleteEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            bool result = _productController.SearchEntity(_productController.Id);
            if (result)
            {
                _productController.IsActivo = false;
                result = _productController.SaveEntity();

                _productController.AddNewEntity();
            }

            listViewData.DataSource = _productController.LoadDataTable();
            return result;
        }

        private bool userControlToolbar1_OnModifyEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return _productController.Id > 0;
        }

        private bool userControlToolbar1_OnSearchEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            List<string> fields = new List<string>();
            fields.Add(ProductsMetadata.ColumnNames.Id);
            fields.Add(ProductsMetadata.ColumnNames.Description);

            string _conString = _productController.ConnectionString;
            var keys = ProductsMetadata.Meta().Columns.PrimaryKeys;
            
            FormGenericSearch search = new FormGenericSearch("Buscar productos", ProductsMetadata.Meta(), fields, ProductsMetadata.ColumnNames.Description, true, _conString);
            search.TopFilter = 20;

            search.Filter = new object[1, 3];
            search.Filter[0, 0] = ProductsMetadata.ColumnNames.IsActivo;
            search.Filter[0, 1] = FSchad.CustomClasses.FSchadDynamicQuery.Igual;
            search.Filter[0, 2] = true;

            search.FormClosed += (senderx, ex) =>
            {
                ListViewItem result = search.GetSelectedListViewItem;

                if (result != null)
                {
                    _productController.SearchEntity(Convert.ToInt32(result.Text));
                    this.userControlToolbar1.SetToolBarState(OnToolBarState.Edit);
                }
            };

            search.ShowDialog();

            return true;
        }

        private bool userControlToolbar1_OnUndoEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return true;
        }

        private bool userControlToolbar1_OnSaveEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            _productController.Modificado = FSchad.Tools.Tool.CurrentEnvironment.CurrentUsername;
            _productController.FechaModificado = DateTime.Now;

            bool result = _productController.SaveEntity();
            listViewData.DataSource = _productController.LoadDataTable();

            return result;
        }

        private void userControlToolbar1_OnEnabledDisabledControls(OnToolBarState toolBarState)
        {
            bool habilitar = toolBarState != OnToolBarState.None;
            textBoxDescription.Enabled = habilitar;
            checkBoxIsActivo.Enabled = habilitar;

        }

        private void listViewData_DoubleClick(object sender, EventArgs e)
        {
            if (listViewData.SelectedItem != null)
            {
                int id = Convert.ToInt32(listViewData.SelectedItem.Text);
                _productController.SearchEntity(id);

            }
        }

    }
}