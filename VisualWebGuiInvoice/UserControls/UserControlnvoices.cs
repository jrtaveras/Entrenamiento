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
using VisualWebGuiInvoice.BusinessObjects.Helpers;
using System.Collections;
using BusinessObjects;
using FSchad.Tools.UserControls;
using FSchad.Tools.Forms;

#endregion

namespace VisualWebGuiInvoice.UserControls
{
    public partial class UserControlnvoices : UserControl
    {
        private readonly InvoiceController _invoiceController;
        private readonly ClassError _objClassError = new ClassError();

        private UserControlInvoiceDetails _invoiceDetailControl;

        public int CustomerId
        {
            get
            {
                if (userControlSearchCustomers.Value != null && userControlSearchCustomers.Value.Length > 0)
                {
                    return (int)userControlSearchCustomers.Value[0];
                }
                return 0;
            }
            set
            {
                if (value != userControlSearchCustomers.ExtractComboData()) 
                {
                  userControlSearchCustomers.Value = new object[] { value };
                }
            }
        }

        public UserControlnvoices()
        {
            InitializeComponent();

            userControlToolbar1.Size = new Size(userControlToolbar1.Width, 35);

            _invoiceController = new InvoiceController();
            _invoiceController.OnRaiseError += new RaiseErrorDelegate(_invoiceController_OnRaiseError);

           
            _invoiceDetailControl = new UserControlInvoiceDetails();
            panelInvoiceDetails.Controls.Add(_invoiceDetailControl);
            _invoiceDetailControl.Dock = DockStyle.Fill;

            _Bindings();
            _PrepareValidations();
            _SetUserControlSearch();
        }



        private void _Bindings()
        {
            textBoxId.DataBindings.Add(new Binding("Text", _invoiceController, InvoicesMetadata.ColumnNames.Id, false, DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new Binding("CustomerId", _invoiceController, InvoicesMetadata.ColumnNames.CustomerId, false, DataSourceUpdateMode.OnPropertyChanged));

            numericUpDownSubTotal.DataBindings.Add(new Binding("Value", _invoiceController, InvoicesMetadata.ColumnNames.SubTotal, false, DataSourceUpdateMode.OnPropertyChanged));
            numericUpDownTotalItbis.DataBindings.Add(new Binding("Value", _invoiceController, InvoicesMetadata.ColumnNames.TotalItbis, false, DataSourceUpdateMode.OnPropertyChanged));
            numericUpDownTotal.DataBindings.Add(new Binding("Value", _invoiceController, InvoicesMetadata.ColumnNames.Total, false, DataSourceUpdateMode.OnPropertyChanged));

            textBoxCreado.DataBindings.Add(new Binding("Text", _invoiceController, InvoicesMetadata.ColumnNames.Creado, false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePickerFechaCreado.DataBindings.Add(new Binding("Value", _invoiceController, InvoicesMetadata.ColumnNames.FechaCreado, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxModificado.DataBindings.Add(new Binding("Text", _invoiceController, InvoicesMetadata.ColumnNames.Modificado, false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePickerFechaModificado.DataBindings.Add(new Binding("Value", _invoiceController, InvoicesMetadata.ColumnNames.FechaModificado, false, DataSourceUpdateMode.OnPropertyChanged));

            checkBoxIsActivo.DataBindings.Add(new Binding("Checked", _invoiceController, InvoicesMetadata.ColumnNames.IsActivo, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxTenantId.DataBindings.Add(new Binding("Text", _invoiceController, InvoicesMetadata.ColumnNames.TenantId, false, DataSourceUpdateMode.OnPropertyChanged));

            userControlToolbar1_OnEnabledDisabledControls(OnToolBarState.None);
        }

        private void _PrepareValidations()
        {
            userControlSearchCustomers.Tag = InvoicesMetadata.ColumnNames.CustomerId;
        }

        private void _SetUserControlSearch()
        {
            List<string> fields = new List<string>();
            fields.Add(CustomersMetadata.ColumnNames.Id);
            fields.Add(CustomersMetadata.ColumnNames.CustName);
            fields.Add(CustomersMetadata.ColumnNames.Adress);

            userControlSearchCustomers.ShowButtons = true;
            userControlSearchCustomers.HideButtonAdd = true;
            userControlSearchCustomers.NotifyOnValueChanged = true;

            userControlSearchCustomers.SetValues("Consulta de clientes", fields, new Customers(), CustomersMetadata.ColumnNames.CustName, CustomersMetadata.ColumnNames.CustName, true);
        }

        
        private void _invoiceController_OnRaiseError(Hashtable ht) 
        {
            _objClassError.SetError(ht, this.Controls);
        }

        private void userControlToolbar1_OnEnabledDisabledControls(OnToolBarState toolBarState)
        {
            bool habilitar = toolBarState != OnToolBarState.None;

            userControlSearchCustomers.Enabled = habilitar;
            checkBoxIsActivo.Enabled = habilitar;
        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {
            _invoiceDetailControl.SetInvoiceId(_invoiceController.Id);
        }

        
        private bool userControlToolbar1_OnAddNewEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return _invoiceController.AddNewEntity();
        }

        private void userControlToolbar1_OnEnabledDisabledControls_1(OnToolBarState toolBarState)
        {
            bool habilitar = toolBarState != OnToolBarState.None;

            userControlSearchCustomers.Enabled = habilitar;
            checkBoxIsActivo.Enabled = habilitar;

            _invoiceDetailControl.Enabled = !habilitar;
        }

        private bool userControlToolbar1_OnDeleteEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return default(bool);
        }

        private bool userControlToolbar1_OnModifyEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return _invoiceController.Id > 0;
        }

        private bool userControlToolbar1_OnSaveEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            _invoiceController.CustomerId = userControlSearchCustomers.ExtractComboData() ?? 0;
            _invoiceController.Modificado = FSchad.Tools.Tool.CurrentEnvironment.CurrentUsername;
            _invoiceController.FechaModificado = DateTime.Now;

            return _invoiceController.SaveEntity();
        }

        private bool userControlToolbar1_OnSearchEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            List<string> fields = new List<string>();
            fields.Add(InvoicesMetadata.ColumnNames.Id);
            fields.Add(InvoicesMetadata.ColumnNames.CustomerId);
            fields.Add(InvoicesMetadata.ColumnNames.FechaCreado);

            string _conString = _invoiceController.ConnectionString;
            var keys = InvoicesMetadata.Meta().Columns.PrimaryKeys;

            FormGenericSearch search = new FormGenericSearch("Buscar facturas", InvoicesMetadata.Meta(), fields, InvoicesMetadata.ColumnNames.Id, true, _conString);
            search.TopFilter = 20;
            search.FormClosed += (senderx, ex) =>
            {
                ListViewItem result = search.GetSelectedListViewItem;

                if (result != null)
                {
                    _invoiceController.SearchEntity(Convert.ToInt32(result.Text));
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

        

    }

}