#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using FSchad.Tools;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using VisualWebGuiInvoice.BusinessObjects;
using FSchad.Tools.Forms;
using BusinessObjects;
using FSchad.Tools.UserControls;
using FSchad.Tools.CustomClasses;
using VisualWebGuiInvoice.BusinessObjects.Helpers;

#endregion

namespace VisualWebGuiInvoice.UserControls
{
    public partial class UserControlCustomerTypes : UserControl
    {
        private readonly CustomerTypeController _customerTypeController;
        private readonly ClassError objClassError = new ClassError();

        public UserControlCustomerTypes()
        {
            InitializeComponent();
            userControlToolbar1.Size = new Size(userControlToolbar1.Width, 35);

            _customerTypeController = new CustomerTypeController();
            _customerTypeController.OnRaiseError += new RaiseErrorDelegate(_customerTypeController_OnRaiseError);

            bindings();
            LoadData();

            _PrepareValidations();
        }

        private void _PrepareValidations()
        {
            textBoxDescription.Tag = CustomerTypesMetadata.ColumnNames.Description;
        }

        void _customerTypeController_OnRaiseError(System.Collections.Hashtable ht)
        {
            objClassError.SetError(ht, this.Controls);
        }

        private void bindings()
        {

            textBoxId.DataBindings.Add(new Binding("Text", _customerTypeController, "Id", false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxDescription.DataBindings.Add(new Binding("Text", _customerTypeController, "Description", false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxCreado.DataBindings.Add(new Binding("Text", _customerTypeController, "Creado", false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePickerFechaCreado.DataBindings.Add(new Binding("Value", _customerTypeController, "FechaCreado", false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxModificado.DataBindings.Add(new Binding("Text", _customerTypeController, "Modificado", false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePickerFechaModificado.DataBindings.Add(new Binding("Value", _customerTypeController, "FechaModificado", false, DataSourceUpdateMode.OnPropertyChanged));
            checkBoxIsActivo.DataBindings.Add(new Binding("Checked", _customerTypeController, "IsActivo", false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxTenantId.DataBindings.Add(new Binding("Text", _customerTypeController, "TenantId", false, DataSourceUpdateMode.OnPropertyChanged));
            userControlToolbar1_OnEnabledDisabledControls(OnToolBarState.None);
        }

        private void LoadData()
        {
            this.listViewData.DataSource = _customerTypeController.LoadDataTable();
        }

        private bool userControlToolbar1_OnAddNewEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return _customerTypeController.AddNewEntity();
        }

        private bool userControlToolbar1_OnDeleteEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            bool result = _customerTypeController.SearchEntity(_customerTypeController.Id);
            if (result)
            {
                _customerTypeController.IsActivo = false;
                result = _customerTypeController.SaveEntity();

                _customerTypeController.AddNewEntity();
            }

            listViewData.DataSource = _customerTypeController.LoadDataTable();
            return result;
        }

        private bool userControlToolbar1_OnModifyEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return _customerTypeController.Id > 0;
        }

        private bool userControlToolbar1_OnSearchEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            List<string> fields = new List<string>();
            fields.Add(CustomerTypesMetadata.ColumnNames.Id);
            fields.Add(CustomerTypesMetadata.ColumnNames.Description);

            string _conString = _customerTypeController.ConnectionString;
            var keys = CustomerTypesMetadata.Meta().Columns.PrimaryKeys;
            FormGenericSearch search = new FormGenericSearch("Buscar tipo de cliente", CustomerTypesMetadata.Meta(), fields, CustomerTypesMetadata.ColumnNames.Description, true, _conString);
            search.TopFilter = 20;
            search.FormClosed += (senderx, ex) =>
            {
                ListViewItem result = search.GetSelectedListViewItem;

                if (result != null)
                {
                    _customerTypeController.SearchEntity(Convert.ToInt32(result.Text));
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
            _customerTypeController.Modificado = FSchad.Tools.Tool.CurrentEnvironment.CurrentUsername;
            _customerTypeController.FechaModificado = DateTime.Now;

            bool result =_customerTypeController.SaveEntity();
            listViewData.DataSource = _customerTypeController.LoadDataTable();

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
                _customerTypeController.SearchEntity(id);
               
            }
        }

    }

}