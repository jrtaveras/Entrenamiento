using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace VisualWebGuiInvoice.UserControls
{
    partial class UserControlnvoices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlnvoices));
            this.userControlToolbar1 = new FSchad.Tools.UserControls.UserControlToolbar();
            this.textBox1 = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.panel2 = new Gizmox.WebGUI.Forms.Panel();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.numericUpDownTotal = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.numericUpDownTotalItbis = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.label13 = new Gizmox.WebGUI.Forms.Label();
            this.label14 = new Gizmox.WebGUI.Forms.Label();
            this.numericUpDownSubTotal = new Gizmox.WebGUI.Forms.NumericUpDown();
            this.userControlSearchCustomers = new FSchad.Tools.UserControls.UserControlSearch();
            this.textBox2 = new Gizmox.WebGUI.Forms.TextBox();
            this.label15 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxId = new Gizmox.WebGUI.Forms.TextBox();
            this.label16 = new Gizmox.WebGUI.Forms.Label();
            this.label17 = new Gizmox.WebGUI.Forms.Label();
            this.label18 = new Gizmox.WebGUI.Forms.Label();
            this.dateTimePickerFechaCreado = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dateTimePickerFechaModificado = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label19 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxCreado = new Gizmox.WebGUI.Forms.TextBox();
            this.label20 = new Gizmox.WebGUI.Forms.Label();
            this.label21 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxModificado = new Gizmox.WebGUI.Forms.TextBox();
            this.label22 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxTenantId = new Gizmox.WebGUI.Forms.TextBox();
            this.checkBoxIsActivo = new Gizmox.WebGUI.Forms.CheckBox();
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.panelInvoiceDetails = new Gizmox.WebGUI.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalItbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubTotal)).BeginInit();
            this.textBoxId.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.userControlToolbar1.Size = new System.Drawing.Size(892, 114);
            this.userControlToolbar1.TabIndex = 0;
            this.userControlToolbar1.ToolBarState = FSchad.Tools.UserControls.OnToolBarState.None;
            this.userControlToolbar1.OnAddNewEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnAddNewEntity);
            this.userControlToolbar1.OnUndoEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnUndoEntity);
            this.userControlToolbar1.OnDeleteEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnDeleteEntity);
            this.userControlToolbar1.OnSaveEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnSaveEntity);
            this.userControlToolbar1.OnSearchEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnSearchEntity);
            this.userControlToolbar1.OnEnabledDisabledControls += new FSchad.Tools.UserControls.UserControlToolbar.ToolBarStateEvent(this.userControlToolbar1_OnEnabledDisabledControls_1);
            this.userControlToolbar1.OnModifyEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnModifyEntity);
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
            this.label2.Text = "Cliente";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(485, 9);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(152, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tenant Id";
            // 
            // panel2
            // 
            this.panel2.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(892, 289);
            this.panel2.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(311, 231);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Total";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(160, 231);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "TotalItbis";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "SubTotal";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(311, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Total";
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
            this.numericUpDownTotal.DecimalPlaces = 2;
            this.numericUpDownTotal.Enabled = false;
            this.numericUpDownTotal.Location = new System.Drawing.Point(313, 258);
            this.numericUpDownTotal.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDownTotal.Name = "numericUpDownTotal";
            this.numericUpDownTotal.ReadOnly = true;
            this.numericUpDownTotal.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownTotal.TabIndex = 6;
            this.numericUpDownTotal.ThousandsSeparator = true;
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
            this.numericUpDownTotalItbis.DecimalPlaces = 2;
            this.numericUpDownTotalItbis.Enabled = false;
            this.numericUpDownTotalItbis.Location = new System.Drawing.Point(162, 258);
            this.numericUpDownTotalItbis.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDownTotalItbis.Name = "numericUpDownTotalItbis";
            this.numericUpDownTotalItbis.ReadOnly = true;
            this.numericUpDownTotalItbis.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownTotalItbis.TabIndex = 6;
            this.numericUpDownTotalItbis.ThousandsSeparator = true;
            this.numericUpDownTotalItbis.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(160, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "TotalItbis";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(21, 231);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "SubTotal";
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
            this.numericUpDownSubTotal.DecimalPlaces = 2;
            this.numericUpDownSubTotal.Enabled = false;
            this.numericUpDownSubTotal.Location = new System.Drawing.Point(23, 258);
            this.numericUpDownSubTotal.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDownSubTotal.Name = "numericUpDownSubTotal";
            this.numericUpDownSubTotal.ReadOnly = true;
            this.numericUpDownSubTotal.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownSubTotal.TabIndex = 6;
            this.numericUpDownSubTotal.ThousandsSeparator = true;
            this.numericUpDownSubTotal.UpDownAlign = Gizmox.WebGUI.Forms.LeftRightAlignment.Right;
            // 
            // userControlSearchCustomers
            // 
            this.userControlSearchCustomers.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.userControlSearchCustomers.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Navy);
            this.userControlSearchCustomers.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.userControlSearchCustomers.CleanValueIfNotExits = true;
            this.userControlSearchCustomers.ColumnOrderName = "";
            this.userControlSearchCustomers.CurrentState = FSchad.Tools.UserControls.OnToolBarState.None;
            this.userControlSearchCustomers.FieldToHide = ((System.Collections.Generic.List<string>)(resources.GetObject("userControlSearchCustomers.FieldToHide")));
            this.userControlSearchCustomers.HideButtonAdd = false;
            this.userControlSearchCustomers.HideButtonFind = false;
            this.userControlSearchCustomers.Location = new System.Drawing.Point(25, 129);
            this.userControlSearchCustomers.Name = "userControlSearchCustomers";
            this.userControlSearchCustomers.NotifyOnValueChanged = false;
            this.userControlSearchCustomers.OrderByItem = null;
            this.userControlSearchCustomers.OrderDirection = EntitySpaces.DynamicQuery.esOrderByDirection.Unassigned;
            this.userControlSearchCustomers.SetEnableButtonFind = false;
            this.userControlSearchCustomers.ShowButtons = true;
            this.userControlSearchCustomers.ShowTextBoxCode = true;
            this.userControlSearchCustomers.Size = new System.Drawing.Size(408, 28);
            this.userControlSearchCustomers.TabIndex = 5;
            this.userControlSearchCustomers.TabStopInDisplay = true;
            this.userControlSearchCustomers.Text = "UserControlSearch";
            this.userControlSearchCustomers.TextBoxCodeText = "";
            this.userControlSearchCustomers.textBoxtCodeHeight = 26;
            this.userControlSearchCustomers.textBoxtCodeWidth = 50;
            this.userControlSearchCustomers.TextValueSearchText = "";
            this.userControlSearchCustomers.TopFilter = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(25, 141);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(66, 31);
            this.textBox2.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(23, 116);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "Id";
            // 
            // textBoxId
            // 
            this.textBoxId.Controls.Add(this.textBox2);
            this.textBoxId.Controls.Add(this.label15);
            this.textBoxId.Location = new System.Drawing.Point(23, 46);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(66, 31);
            this.textBoxId.TabIndex = 1;
            this.textBoxId.TextChanged += new System.EventHandler(this.textBoxId_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(21, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Id";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(21, 99);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "Cliente";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(481, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 2;
            this.label18.Text = "Fecha de Creación";
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(481, 214);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Fecha de Modificación";
            // 
            // textBoxCreado
            // 
            this.textBoxCreado.Location = new System.Drawing.Point(486, 37);
            this.textBoxCreado.Name = "textBoxCreado";
            this.textBoxCreado.ReadOnly = true;
            this.textBoxCreado.Size = new System.Drawing.Size(264, 31);
            this.textBoxCreado.TabIndex = 1;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(485, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "Creado";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(483, 140);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 13);
            this.label21.TabIndex = 2;
            this.label21.Text = "Modificado";
            // 
            // textBoxModificado
            // 
            this.textBoxModificado.Location = new System.Drawing.Point(485, 165);
            this.textBoxModificado.Name = "textBoxModificado";
            this.textBoxModificado.ReadOnly = true;
            this.textBoxModificado.Size = new System.Drawing.Size(264, 31);
            this.textBoxModificado.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(152, 21);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 13);
            this.label22.TabIndex = 2;
            this.label22.Text = "Tenant Id";
            // 
            // textBoxTenantId
            // 
            this.textBoxTenantId.Location = new System.Drawing.Point(154, 46);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.numericUpDownTotal);
            this.panel1.Controls.Add(this.numericUpDownTotalItbis);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.numericUpDownSubTotal);
            this.panel1.Controls.Add(this.userControlSearchCustomers);
            this.panel1.Controls.Add(this.textBoxId);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.dateTimePickerFechaCreado);
            this.panel1.Controls.Add(this.dateTimePickerFechaModificado);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.textBoxCreado);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.textBoxModificado);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.textBoxTenantId);
            this.panel1.Controls.Add(this.checkBoxIsActivo);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 289);
            this.panel1.TabIndex = 5;
            // 
            // panelInvoiceDetails
            // 
            this.panelInvoiceDetails.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelInvoiceDetails.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.panelInvoiceDetails.Location = new System.Drawing.Point(0, 403);
            this.panelInvoiceDetails.Name = "panelInvoiceDetails";
            this.panelInvoiceDetails.Size = new System.Drawing.Size(892, 464);
            this.panelInvoiceDetails.TabIndex = 6;
            // 
            // UserControlnvoices
            // 
            this.Controls.Add(this.panelInvoiceDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userControlToolbar1);
            this.Location = new System.Drawing.Point(0, -7);
            this.Size = new System.Drawing.Size(892, 867);
            this.Text = "UserControlnvoices";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalItbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubTotal)).EndInit();
            this.textBoxId.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FSchad.Tools.UserControls.UserControlToolbar userControlToolbar1;
        private TextBox textBox1;
        private Label label7;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label8;
        private Panel panel2;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label12;
        private NumericUpDown numericUpDownTotal;
        private NumericUpDown numericUpDownTotalItbis;
        private Label label13;
        private Label label14;
        private NumericUpDown numericUpDownSubTotal;
        private FSchad.Tools.UserControls.UserControlSearch userControlSearchCustomers;
        private TextBox textBox2;
        private Label label15;
        private TextBox textBoxId;
        private Label label16;
        private Label label17;
        private Label label18;
        private DateTimePicker dateTimePickerFechaCreado;
        private DateTimePicker dateTimePickerFechaModificado;
        private Label label19;
        private TextBox textBoxCreado;
        private Label label20;
        private Label label21;
        private TextBox textBoxModificado;
        private Label label22;
        private TextBox textBoxTenantId;
        private CheckBox checkBoxIsActivo;
        private Panel panel1;
        private Panel panelInvoiceDetails;


    }
}