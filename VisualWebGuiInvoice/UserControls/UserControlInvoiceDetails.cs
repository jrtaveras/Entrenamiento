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

#endregion

namespace VisualWebGuiInvoice.UserControls
{
    public partial class UserControlInvoiceDetails : UserControl
    {
        private InvoiceController _invoiceHeaderController;
        private InvoiceDetailController _invoiceDetailsController;
        private readonly ClassError _objClassError = new ClassError();


        public UserControlInvoiceDetails()
        {
            InitializeComponent();

            userControlToolbar1.Size = new Size(userControlToolbar1.Width, 35);

            _invoiceDetailsController = new InvoiceDetailController();

            _Bindings();
            _PrepareValidations();
            _SetUserControlSearch();
        }

        private void _Bindings()
        {
            textBoxId.DataBindings.Add(new Binding("Text", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.Id, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxInvoiceId.DataBindings.Add(new Binding("Text", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.InvoiceId, false, DataSourceUpdateMode.OnPropertyChanged));
            
            numericUpDownQty.DataBindings.Add(new Binding("Value", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.Qty, false, DataSourceUpdateMode.OnPropertyChanged));            
            numericUpDownPrice.DataBindings.Add(new Binding("Value", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.Price, false, DataSourceUpdateMode.OnPropertyChanged));

            numericUpDownSubTotal.DataBindings.Add(new Binding("Value", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.SubTotal, false, DataSourceUpdateMode.OnPropertyChanged));
            numericUpDownTotalItbis.DataBindings.Add(new Binding("Value", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.TotalItbis, false, DataSourceUpdateMode.OnPropertyChanged));
            numericUpDownTotal.DataBindings.Add(new Binding("Value", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.Total, false, DataSourceUpdateMode.OnPropertyChanged));

            textBoxCreado.DataBindings.Add(new Binding("Text", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.Creado, false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePickerFechaCreado.DataBindings.Add(new Binding("Value", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.FechaCreado, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxModificado.DataBindings.Add(new Binding("Text", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.Modificado, false, DataSourceUpdateMode.OnPropertyChanged));
            dateTimePickerFechaModificado.DataBindings.Add(new Binding("Value", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.FechaModificado, false, DataSourceUpdateMode.OnPropertyChanged));

            checkBoxIsActivo.DataBindings.Add(new Binding("Checked", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.IsActivo, false, DataSourceUpdateMode.OnPropertyChanged));
            textBoxTenantId.DataBindings.Add(new Binding("Text", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.TenantId, false, DataSourceUpdateMode.OnPropertyChanged));

            userControlToolbar1_OnEnabledDisabledControls(OnToolBarState.None);
        }

        private void _PrepareValidations()
        {
            userControlSearchProducts.Tag = InvoiceDetailsMetadata.ColumnNames.ProductId;
            numericUpDownQty.Tag = InvoiceDetailsMetadata.ColumnNames.Qty;
            numericUpDownPrice.Tag = InvoiceDetailsMetadata.ColumnNames.Price;
        }

        private void _SetUserControlSearch()
        {
            List<string> fields = new List<string>();
            fields.Add(ProductsMetadata.ColumnNames.Id);
            fields.Add(ProductsMetadata.ColumnNames.Description);

            userControlSearchProducts.ShowButtons = true;
            userControlSearchProducts.HideButtonAdd = true;
            userControlSearchProducts.NotifyOnValueChanged = true;

            userControlSearchProducts.Filter = new object[1, 3];
            userControlSearchProducts.Filter[0, 0] = ProductsMetadata.ColumnNames.IsActivo;
            userControlSearchProducts.Filter[0, 1] = FSchad.CustomClasses.FSchadDynamicQuery.Igual;
            userControlSearchProducts.Filter[0, 2] = true;

            userControlSearchProducts.SetValues("Consulta de productos", fields, new Products(), ProductsMetadata.ColumnNames.Description, ProductsMetadata.ColumnNames.Description, true);
        }

        private bool userControlToolbar1_OnSearchEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            List<string> fields = new List<string>();
            fields.Add(InvoiceDetailsMetadata.ColumnNames.Id);
            fields.Add(InvoiceDetailsMetadata.ColumnNames.ProductId);
            fields.Add(InvoiceDetailsMetadata.ColumnNames.Price);
            fields.Add(InvoiceDetailsMetadata.ColumnNames.FechaCreado);

            string _conString = _invoiceDetailsController.ConnectionString;
            var keys = InvoiceDetailsMetadata.Meta().Columns.PrimaryKeys;

            FormGenericSearch search = new FormGenericSearch("Buscar detalles de facturas", InvoiceDetailsMetadata.Meta(), fields, InvoiceDetailsMetadata.ColumnNames.Id, true, _conString);
            search.TopFilter = 20;
            
            search.Filter = new object[2,3];
            search.Filter[0, 0] = InvoiceDetailsMetadata.ColumnNames.InvoiceId;
            search.Filter[0, 1] = FSchad.CustomClasses.FSchadDynamicQuery.Igual;
            search.Filter[0, 2] = _invoiceHeaderController.Id;

            search.Filter[1, 0] = InvoiceDetailsMetadata.ColumnNames.IsActivo;
            search.Filter[1, 1] = FSchad.CustomClasses.FSchadDynamicQuery.Igual;
            search.Filter[1, 2] = true;

            search.FormClosed += (senderx, ex) =>
            {
                ListViewItem result = search.GetSelectedListViewItem;

                if (result != null)
                {
                    _invoiceDetailsController.SearchEntity(Convert.ToInt32(result.Text));
                    userControlSearchProducts.Value = new object[] { _invoiceDetailsController.ProductId };
                    this.userControlToolbar1.SetToolBarState(OnToolBarState.Edit);
                }
            };

            search.ShowDialog();

            return true;
        }

        private void userControlToolbar1_OnEnabledDisabledControls(OnToolBarState toolBarState)
        {
            bool habilitar = toolBarState != OnToolBarState.None;

            userControlSearchProducts.Enabled = habilitar;
            numericUpDownQty.Enabled = habilitar;
            numericUpDownPrice.Enabled = habilitar;
            
            checkBoxIsActivo.Enabled = habilitar;
        }


        

        private void listViewData_DoubleClick(object sender, EventArgs e)
        {
            if (listViewData.SelectedItem != null)
            {
                int id = Convert.ToInt32(listViewData.SelectedItem.Text);
                _invoiceDetailsController.SearchEntity(id);

                userControlSearchProducts.Value = new object[]{ _invoiceDetailsController.ProductId };
            }
        }

        private bool userControlToolbar1_OnAddNewEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            bool result = _invoiceDetailsController.AddNewEntity();
            _invoiceDetailsController.InvoiceId = _invoiceHeaderController.Id;

            return result;
        }

        private bool userControlToolbar1_OnDeleteEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            bool result = _invoiceDetailsController.SearchEntity(_invoiceDetailsController.Id);
            if (result) 
            {
                _invoiceDetailsController.IsActivo = false;
                result = _invoiceDetailsController.SaveEntity();

                _invoiceDetailsController.AddNewEntity();
                userControlSearchProducts.Value = new object[0];
            }

            DataTable detailsTable = _invoiceDetailsController.LoadDataTable();
            ChangeInoviceHeaderTotals(detailsTable);

            listViewData.DataSource = detailsTable;
            return result;
        }

        private bool userControlToolbar1_OnModifyEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return _invoiceDetailsController.Id > 0;
        }

        private bool userControlToolbar1_OnSaveEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {

            _invoiceDetailsController.ProductId = userControlSearchProducts.ExtractComboData() ?? 0;
            _invoiceDetailsController.Modificado = FSchad.Tools.Tool.CurrentEnvironment.CurrentUsername;
            _invoiceDetailsController.FechaModificado = DateTime.Now;

            bool result = _invoiceDetailsController.SaveEntity();
            
            DataTable detailsTable =_invoiceDetailsController.LoadDataTable();
            ChangeInoviceHeaderTotals(detailsTable);

            listViewData.DataSource = detailsTable;
            return result;
        }

        

        private bool userControlToolbar1_OnUndoEntity(ToolBar sender, ToolBarButtonClickEventArgs e)
        {
            return true;
        }

        public void SetInvoiceHeader(InvoiceController invoiceHeaderController)
        {
            _invoiceHeaderController = invoiceHeaderController;

            bool hasId = _invoiceHeaderController.Id > 0;
            this.Enabled = hasId;

            if (hasId)
            {
                _invoiceDetailsController.InvoiceId = _invoiceHeaderController.Id;
                listViewData.DataSource = _invoiceDetailsController.LoadDataTable();
            }
            else 
            {
                listViewData.DataSource = null;
            }

            _invoiceDetailsController.AddNewEntity();
        }
        private void ChangeInoviceHeaderTotals(DataTable details)
        {
            decimal subTotal = 0;
            decimal totalItbis = 0;
            decimal total = 0;

            foreach (DataRow detailRow in details.Rows)
            {
                subTotal += (decimal)detailRow[InvoiceDetailsMetadata.ColumnNames.SubTotal];
                totalItbis += (decimal)detailRow[InvoiceDetailsMetadata.ColumnNames.TotalItbis];
                total += (decimal)detailRow[InvoiceDetailsMetadata.ColumnNames.Total];
            }

            _invoiceHeaderController.SubTotal = subTotal;
            _invoiceHeaderController.TotalItbis = totalItbis;
            _invoiceHeaderController.Total = total;

            _invoiceHeaderController.Modificado = FSchad.Tools.Tool.CurrentEnvironment.CurrentUsername;
            _invoiceHeaderController.FechaModificado = DateTime.Now;

            _invoiceHeaderController.SaveEntity();
        }

    }

}