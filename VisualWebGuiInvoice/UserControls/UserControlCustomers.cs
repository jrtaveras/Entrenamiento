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
using FSchad.Tools.UserControls;
using FSchad.Tools.Forms;
using VisualWebGuiInvoice.BusinessObjects.Helpers;

#endregion

namespace VisualWebGuiInvoice.UserControls
{
    public partial class UserControlCustomers : UserControl
    {
        private readonly CustomerController _customerController;
        private readonly ClassError _objClassError = new ClassError();


        public UserControlCustomers()
        {
            InitializeComponent();

            userControlToolbar1.Size = new Size(userControlToolbar1.Width, 35);

            _customerController = new CustomerController();
            _customerController.OnRaiseError += new RaiseErrorDelegate(_customerController_OnRaiseError);

            _LoadData();
            _Bindings();
            _PrepareValidations();
            _SetUserControlSearch();
        }

        private void _SetUserControlSearch()
        {
            List<string> fields = new List<string>();
            fields.Add(CustomerTypesMetadata.ColumnNames.Id);
            fields.Add(CustomerTypesMetadata.ColumnNames.Description);

            userControlSearchCustomerType.ShowCleanButton = true;
            userControlSearchCustomerType.HideButtonAdd = true;
            userControlSearchCustomerType.NotifyOnValueChanged = true;

            userControlSearchCustomerType.Filter = new object[1,3];
            userControlSearchCustomerType.Filter[0, 0] = CustomerTypesMetadata.ColumnNames.IsActivo;
            userControlSearchCustomerType.Filter[0, 1] = FSchad.CustomClasses.FSchadDynamicQuery.Igual;
            userControlSearchCustomerType.Filter[0, 2] = true;

            userControlSearchCustomerType.SetValues("Consulta tipos de cliente", fields, new CustomerTypes(), CustomerTypesMetadata.ColumnNames.Description, CustomerTypesMetadata.ColumnNames.Description, true);

        }


        private void _LoadData()
        {
            this.listViewData.DataSource = _customerController.LoadDataTable();
        }

        private void _Bindings()
        {
            textBoxId.DataBindings.Add(new Binding("Text", _customerController, CustomersMetadata.ColumnNames.Id, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxCustName.DataBindings.Add(new Binding("Text", _customerController, CustomersMetadata.ColumnNames.CustName, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxAddress.DataBindings.Add(new Binding("Text", _customerController, CustomersMetadata.ColumnNames.Adress, false, DataSourceUpdateMode.OnPropertyChanged));

            textBoxCreado.DataBindings.Add(new Binding("Text", _customerController, CustomersMetadata.ColumnNames.Creado, false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePickerFechaCreado.DataBindings.Add(new Binding("Value", _customerController, CustomersMetadata.ColumnNames.FechaCreado, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxModificado.DataBindings.Add(new Binding("Text", _customerController, CustomersMetadata.ColumnNames.Modificado, false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePickerFechaModificado.DataBindings.Add(new Binding("Value", _customerController, CustomersMetadata.ColumnNames.FechaModificado, false, DataSourceUpdateMode.OnPropertyChanged));
            
            checkBoxIsActivo.DataBindings.Add(new Binding("Checked", _customerController, CustomersMetadata.ColumnNames.IsActivo, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxTenantId.DataBindings.Add(new Binding("Text", _customerController, CustomersMetadata.ColumnNames.TenantId, false, DataSourceUpdateMode.OnPropertyChanged));
            
            userControlToolbar1_OnEnabledDisabledControls(OnToolBarState.None);
        }

        private void _PrepareValidations()
        {
            textBoxCustName.Tag = CustomersMetadata.ColumnNames.CustName;
            textBoxAddress.Tag = CustomersMetadata.ColumnNames.Adress;
            userControlSearchCustomerType.Tag = CustomersMetadata.ColumnNames.CustomerTypeId;
        }

        void _customerController_OnRaiseError(System.Collections.Hashtable ht)
        {
            _objClassError.SetError(ht, this.Controls);
        }

        private bool userControlToolbar1_OnAddNewEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return _customerController.AddNewEntity();
        }

        private bool userControlToolbar1_OnDeleteEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            bool result = _customerController.SearchEntity(_customerController.Id);
            if (result)
            {
                _customerController.IsActivo = false;
                result = _customerController.SaveEntity();
                
                _customerController.AddNewEntity();
                userControlSearchCustomerType.Value = new object[0];
            }

            listViewData.DataSource = _customerController.LoadDataTable();
            return result;
        }

        private void userControlToolbar1_OnEnabledDisabledControls(OnToolBarState toolBarState)
        {
            bool habilitar = toolBarState != OnToolBarState.None;

            textBoxCustName.Enabled = habilitar;
            textBoxAddress.Enabled = habilitar;

            checkBoxStatus.Enabled = habilitar;
            checkBoxIsActivo.Enabled = habilitar;

            userControlSearchCustomerType.Enabled = habilitar;
        }

        private bool userControlToolbar1_OnModifyEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return _customerController.Id > 0;
        }

        private bool userControlToolbar1_OnSearchEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            List<string> fields = new List<string>();
            fields.Add(CustomersMetadata.ColumnNames.Id);
            fields.Add(CustomersMetadata.ColumnNames.CustName);
            fields.Add(CustomersMetadata.ColumnNames.Adress);

            string _conString = _customerController.ConnectionString;
            var keys = CustomersMetadata.Meta().Columns.PrimaryKeys;

            FormGenericSearch search = new FormGenericSearch("Buscar clientes", CustomersMetadata.Meta(), fields, CustomersMetadata.ColumnNames.CustName, true, _conString);
            search.TopFilter = 20;

            search.Filter = new object [1,3];
            search.Filter[0, 0] = CustomerTypesMetadata.ColumnNames.IsActivo;
            search.Filter[0, 1] = FSchad.CustomClasses.FSchadDynamicQuery.Igual;
            search.Filter[0, 2] = true;

            search.FormClosed += (senderx, ex) =>
            {
                ListViewItem result = search.GetSelectedListViewItem;

                if (result != null)
                {
                    _customerController.SearchEntity(Convert.ToInt32(result.Text));
                    userControlSearchCustomerType.Value = new object[] { _customerController.CustomerTypeId };
                    this.userControlToolbar1.SetToolBarState(OnToolBarState.Edit);
                }
            };

            search.ShowDialog();



            return true;
        }

        private bool userControlToolbar1_OnSaveEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            _customerController.CustomerTypeId = userControlSearchCustomerType.ExtractComboData() ?? 0;
            _customerController.Modificado = FSchad.Tools.Tool.CurrentEnvironment.CurrentUsername;
            _customerController.FechaModificado = DateTime.Now;

            bool result = _customerController.SaveEntity();
            listViewData.DataSource = _customerController.LoadDataTable();

            return result;
        }

        private void listViewData_DoubleClick(object sender, EventArgs e)
        {
            if (listViewData.SelectedItem != null)
            {
                int id = Convert.ToInt32(listViewData.SelectedItem.Text);
                _customerController.SearchEntity(id);

                userControlSearchCustomerType.Value = new object[] { _customerController.CustomerTypeId };
            }
        }

        private bool userControlToolbar1_OnUndoEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return true;
        }


    }

}