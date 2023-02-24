using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace VisualWebGuiInvoice.UserControls
{
    partial class UserControlInvoiceDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlInvoiceDetails));
            this.userControlToolbar1 = new FSchad.Tools.UserControls.UserControlToolbar();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.numericUpDownTotal = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.numericUpDownTotalItbis = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.numericUpDownSubTotal = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.userControlSearchProducts = new FSchad.Tools.UserControls.UserControlSearch();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxId = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.dateTimePickerFechaCreado = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dateTimePickerFechaModificado = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxCreado = new Gizmox.WebGUI.Forms.TextBox();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxModificado = new Gizmox.WebGUI.Forms.TextBox();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxTenantId = new Gizmox.WebGUI.Forms.TextBox();
            this.checkBoxIsActivo = new Gizmox.WebGUI.Forms.CheckBox();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.numericUpDownQty = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxInvoiceId = new Gizmox.WebGUI.Forms.TextBox();
            this.listViewData = new Gizmox.WebGUI.Forms.ListView();
            this.numericUpDownPrice = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalItbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubTotal)).BeginInit();
            this.textBoxId.SuspendLayout();
            this.panel2.SuspendLayout();
            this.label12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).BeginInit();
            this.label16.SuspendLayout();
            this.SuspendLayout();
            // 
            // userControlToolbar1
            // 
            this.userControlToolbar1.DragHandle = true;
            this.userControlToolbar1.DropDownArrows = true;
            this.userControlToolbar1.ForeColor = System.Drawing.Color.White;
            this.userControlToolbar1.ImageSize = new System.Drawing.Size(16, 16);
            this.userControlToolbar1.Location = new System.Drawing.Point(0, 0);
            this.userControlToolbar1.MenuHandle = true;
            this.userControlToolbar1.Name = "userControlToolbar1";
            this.userControlToolbar1.ShowToolTips = true;
            this.userControlToolbar1.Size = new System.Drawing.Size(758, 114);
            this.userControlToolbar1.TabIndex = 0;
            this.userControlToolbar1.ToolBarState = FSchad.Tools.UserControls.OnToolBarState.None;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(306, 248);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Total";
            // 
            // numericUpDownTotal
            // 
            this.numericUpDownTotal.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.numericUpDownTotal.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.numericUpDownTotal.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownTotal.Enabled = false;
            this.numericUpDownTotal.Location = new System.Drawing.Point(308, 276);
            this.numericUpDownTotal.Name = "numericUpDownTotal";
            this.numericUpDownTotal.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownTotal.TabIndex = 6;
            this.numericUpDownTotal.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // numericUpDownTotalItbis
            // 
            this.numericUpDownTotalItbis.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.numericUpDownTotalItbis.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.numericUpDownTotalItbis.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownTotalItbis.Enabled = false;
            this.numericUpDownTotalItbis.Location = new System.Drawing.Point(165, 276);
            this.numericUpDownTotalItbis.Name = "numericUpDownTotalItbis";
            this.numericUpDownTotalItbis.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownTotalItbis.TabIndex = 6;
            this.numericUpDownTotalItbis.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(163, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "TotalItbis";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 248);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "SubTotal";
            // 
            // numericUpDownSubTotal
            // 
            this.numericUpDownSubTotal.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.numericUpDownSubTotal.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.numericUpDownSubTotal.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownSubTotal.Enabled = false;
            this.numericUpDownSubTotal.Location = new System.Drawing.Point(26, 276);
            this.numericUpDownSubTotal.Name = "numericUpDownSubTotal";
            this.numericUpDownSubTotal.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownSubTotal.TabIndex = 6;
            this.numericUpDownSubTotal.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // userControlSearchProducts
            // 
            this.userControlSearchProducts.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.userControlSearchProducts.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Navy);
            this.userControlSearchProducts.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.userControlSearchProducts.CleanValueIfNotExits = true;
            this.userControlSearchProducts.ColumnOrderName = "";
            this.userControlSearchProducts.CurrentState = FSchad.Tools.UserControls.OnToolBarState.None;
            this.userControlSearchProducts.FieldToHide = ((System.Collections.Generic.List<string>)(resources.GetObject("userControlSearchProducts.FieldToHide")));
            this.userControlSearchProducts.HideButtonAdd = false;
            this.userControlSearchProducts.HideButtonFind = false;
            this.userControlSearchProducts.Location = new System.Drawing.Point(25, 129);
            this.userControlSearchProducts.Name = "userControlSearchProducts";
            this.userControlSearchProducts.NotifyOnValueChanged = false;
            this.userControlSearchProducts.OrderByItem = null;
            this.userControlSearchProducts.OrderDirection = EntitySpaces.DynamicQuery.esOrderByDirection.Unassigned;
            this.userControlSearchProducts.SetEnableButtonFind = false;
            this.userControlSearchProducts.ShowButtons = true;
            this.userControlSearchProducts.ShowTextBoxCode = true;
            this.userControlSearchProducts.Size = new System.Drawing.Size(403, 28);
            this.userControlSearchProducts.TabIndex = 5;
            this.userControlSearchProducts.TabStopInDisplay = true;
            this.userControlSearchProducts.Text = "UserControlSearch";
            this.userControlSearchProducts.TextBoxCodeText = "";
            this.userControlSearchProducts.textBoxtCodeHeight = 26;
            this.userControlSearchProducts.textBoxtCodeWidth = 50;
            this.userControlSearchProducts.TextValueSearchText = "";
            this.userControlSearchProducts.TopFilter = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 141);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(66, 31);
            this.textBox1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Id";
            // 
            // textBoxId
            // 
            this.textBoxId.Controls.Add(this.textBox1);
            this.textBoxId.Controls.Add(this.label7);
            this.textBoxId.Enabled = false;
            this.textBoxId.Location = new System.Drawing.Point(23, 46);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(66, 31);
            this.textBoxId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(481, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha de Creación";
            // 
            // dateTimePickerFechaCreado
            // 
            this.dateTimePickerFechaCreado.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.dateTimePickerFechaCreado.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerFechaCreado.Enabled = false;
            this.dateTimePickerFechaCreado.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaCreado.Location = new System.Drawing.Point(485, 101);
            this.dateTimePickerFechaCreado.Name = "dateTimePickerFechaCreado";
            this.dateTimePickerFechaCreado.Size = new System.Drawing.Size(264, 21);
            this.dateTimePickerFechaCreado.TabIndex = 3;
            // 
            // dateTimePickerFechaModificado
            // 
            this.dateTimePickerFechaModificado.Cursor = Gizmox.WebGUI.Forms.Cursors.Arrow;
            this.dateTimePickerFechaModificado.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerFechaModificado.Enabled = false;
            this.dateTimePickerFechaModificado.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFechaModificado.Location = new System.Drawing.Point(485, 239);
            this.dateTimePickerFechaModificado.Name = "dateTimePickerFechaModificado";
            this.dateTimePickerFechaModificado.Size = new System.Drawing.Size(264, 21);
            this.dateTimePickerFechaModificado.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(481, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fecha de Modificación";
            // 
            // textBoxCreado
            // 
            this.textBoxCreado.Enabled = false;
            this.textBoxCreado.Location = new System.Drawing.Point(485, 32);
            this.textBoxCreado.Name = "textBoxCreado";
            this.textBoxCreado.ReadOnly = true;
            this.textBoxCreado.Size = new System.Drawing.Size(264, 31);
            this.textBoxCreado.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(483, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Creado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(483, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Modificado";
            // 
            // textBoxModificado
            // 
            this.textBoxModificado.Enabled = false;
            this.textBoxModificado.Location = new System.Drawing.Point(485, 165);
            this.textBoxModificado.Name = "textBoxModificado";
            this.textBoxModificado.ReadOnly = true;
            this.textBoxModificado.Size = new System.Drawing.Size(264, 31);
            this.textBoxModificado.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(114, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tenant Id";
            // 
            // textBoxTenantId
            // 
            this.textBoxTenantId.Enabled = false;
            this.textBoxTenantId.Location = new System.Drawing.Point(118, 46);
            this.textBoxTenantId.Name = "textBoxTenantId";
            this.textBoxTenantId.ReadOnly = true;
            this.textBoxTenantId.Size = new System.Drawing.Size(101, 31);
            this.textBoxTenantId.TabIndex = 1;
            // 
            // checkBoxIsActivo
            // 
            this.checkBoxIsActivo.AutoSize = true;
            this.checkBoxIsActivo.Checked = true;
            this.checkBoxIsActivo.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.checkBoxIsActivo.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIsActivo.Location = new System.Drawing.Point(25, 177);
            this.checkBoxIsActivo.Name = "checkBoxIsActivo";
            this.checkBoxIsActivo.Size = new System.Drawing.Size(89, 27);
            this.checkBoxIsActivo.TabIndex = 4;
            this.checkBoxIsActivo.Text = "Activo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.numericUpDownPrice);
            this.panel2.Controls.Add(this.numericUpDownQty);
            this.panel2.Controls.Add(this.textBoxInvoiceId);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.numericUpDownTotal);
            this.panel2.Controls.Add(this.numericUpDownTotalItbis);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.numericUpDownSubTotal);
            this.panel2.Controls.Add(this.userControlSearchProducts);
            this.panel2.Controls.Add(this.textBoxId);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dateTimePickerFechaCreado);
            this.panel2.Controls.Add(this.dateTimePickerFechaModificado);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.textBoxCreado);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.textBoxModificado);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.textBoxTenantId);
            this.panel2.Controls.Add(this.checkBoxIsActivo);
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(0, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(758, 311);
            this.panel2.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Controls.Add(this.label14);
            this.label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(143, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Cantidad";
            // 
            // numericUpDownQty
            // 
            this.numericUpDownQty.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.numericUpDownQty.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.numericUpDownQty.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownQty.Location = new System.Drawing.Point(147, 214);
            this.numericUpDownQty.Name = "numericUpDownQty";
            this.numericUpDownQty.Size = new System.Drawing.Size(89, 21);
            this.numericUpDownQty.TabIndex = 6;
            this.numericUpDownQty.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(248, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Id Factura";
            // 
            // textBoxInvoiceId
            // 
            this.textBoxInvoiceId.Enabled = false;
            this.textBoxInvoiceId.Location = new System.Drawing.Point(252, 46);
            this.textBoxInvoiceId.Name = "textBoxInvoiceId";
            this.textBoxInvoiceId.ReadOnly = true;
            this.textBoxInvoiceId.Size = new System.Drawing.Size(101, 31);
            this.textBoxInvoiceId.TabIndex = 1;
            // 
            // listViewData
            // 
            this.listViewData.DataMember = null;
            this.listViewData.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listViewData.Location = new System.Drawing.Point(0, 425);
            this.listViewData.Name = "listViewData";
            this.listViewData.Size = new System.Drawing.Size(758, 333);
            this.listViewData.TabIndex = 6;
            // 
            // numericUpDownPrice
            // 
            this.numericUpDownPrice.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.numericUpDownPrice.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.numericUpDownPrice.CurrentValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDownPrice.Location = new System.Drawing.Point(274, 214);
            this.numericUpDownPrice.Name = "numericUpDownPrice";
            this.numericUpDownPrice.Size = new System.Drawing.Size(130, 21);
            this.numericUpDownPrice.TabIndex = 6;
            this.numericUpDownPrice.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(101, -12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Cantidad";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(101, -12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Cantidad";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Controls.Add(this.label15);
            this.label16.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(309, 181);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Precio";
            // 
            // UserControlInvoiceDetails
            // 
            this.Controls.Add(this.listViewData);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.userControlToolbar1);
            this.Size = new System.Drawing.Size(758, 758);
            this.Text = "UserControlInvoiceDetails";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalItbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubTotal)).EndInit();
            this.textBoxId.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.label12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrice)).EndInit();
            this.label16.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FSchad.Tools.UserControls.UserControlToolbar userControlToolbar1;
        private Label label11;
        private NumericUpDown numericUpDownTotal;
        private NumericUpDown numericUpDownTotalItbis;
        private Label label10;
        private Label label9;
        private NumericUpDown numericUpDownSubTotal;
        private FSchad.Tools.UserControls.UserControlSearch userControlSearchProducts;
        private TextBox textBox1;
        private Label label7;
        private TextBox textBoxId;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dateTimePickerFechaCreado;
        private DateTimePicker dateTimePickerFechaModificado;
        private Label label4;
        private TextBox textBoxCreado;
        private Label label5;
        private Label label6;
        private TextBox textBoxModificado;
        private Label label8;
        private TextBox textBoxTenantId;
        private CheckBox checkBoxIsActivo;
        private Panel panel2;
        private NumericUpDown numericUpDownQty;
        private Label label12;
        private TextBox textBoxInvoiceId;
        private Label label13;
        private ListView listViewData;
        private Label label16;
        private Label label15;
        private Label label14;
        private NumericUpDown numericUpDownPrice;


    }
}