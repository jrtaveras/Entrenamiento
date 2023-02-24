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
        private int _invoiceId;
        private InvoiceDetailController _invoiceDetailsController;
        private readonly ClassError _objClassError = new ClassError();

        public int ProductId
        {
            get
            {
                if (userControlSearchProducts.Value != null && userControlSearchProducts.Value.Length > 0)
                {
                    return (int)userControlSearchProducts.Value[0];
                }
                return 0;
            }
            set
            {
                if (value != userControlSearchProducts.ExtractComboData())
                {
                    userControlSearchProducts.Value = new object[] { value };
                }
            }
        }

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
            this.DataBindings.Add(new Binding("ProductId", _invoiceDetailsController, InvoiceDetailsMetadata.ColumnNames.ProductId, false, DataSourceUpdateMode.OnPropertyChanged));

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
            
            search.Filter = new object[1,3];
            search.Filter[0, 0] = InvoiceDetailsMetadata.ColumnNames.InvoiceId;
            search.Filter[0, 1] = FSchad.CustomClasses.FSchadDynamicQuery.Igual;
            search.Filter[0, 2] = _invoiceId;

            search.FormClosed += (senderx, ex) =>
            {
                ListViewItem result = search.GetSelectedListViewItem;

                if (result != null)
                {
                    _invoiceDetailsController.SearchEntity(Convert.ToInt32(result.Text));
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


        public void SetInvoiceId(int invoiceId) 
        {
            _invoiceId = invoiceId;
            this.Enabled = _invoiceId > 0;
        }

    }

}