using Common.Constants;

namespace CommonUserControls
{

    partial  class UserControlInvoices
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

        #region Wisej Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPricipal = new Wisej.Web.Panel();
            this.panelContenido = new Wisej.Web.Panel();
            this.panelRight = new Wisej.Web.Panel();
            this.panelLeft = new Wisej.Web.Panel();
            this.textBoxId = new Wisej.Web.TextBox();
            this.comboBoxCustomerId = new Wisej.Web.ComboBox();
            this.numericUpDownTotalItbis = new Wisej.Web.NumericUpDown();
            this.numericUpDownSubTotal = new Wisej.Web.NumericUpDown();
            this.numericUpDownTotal = new Wisej.Web.NumericUpDown();
            this.checkBoxIsActivo = new Wisej.Web.CheckBox();
            this.toolBar1 = new Wisej.Web.ToolBar();
            this.toolBarButtonNuevo = new Wisej.Web.ToolBarButton();
            this.toolBarButtonSalvar = new Wisej.Web.ToolBarButton();
            this.toolBarButtonEditar = new Wisej.Web.ToolBarButton();
            this.toolBarButtonCancelar = new Wisej.Web.ToolBarButton();
            this.toolBarButtonEliminar = new Wisej.Web.ToolBarButton();
            this.toolBarButtonBuscar = new Wisej.Web.ToolBarButton();
            this.toolBarButtonImprimir = new Wisej.Web.ToolBarButton();
            this.toolBarButtonExcel = new Wisej.Web.ToolBarButton();
            this.toolBarButtonInfo = new Wisej.Web.ToolBarButton();
            this.toolBarButtonRecargaCombo = new Wisej.Web.ToolBarButton();
            this.panelDetalles = new Wisej.Web.Panel();
            this.panelPricipal.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalItbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPricipal
            // 
            this.panelPricipal.CollapseSide = Wisej.Web.HeaderPosition.Left;
            this.panelPricipal.Controls.Add(this.panelContenido);
            this.panelPricipal.Controls.Add(this.toolBar1);
            this.panelPricipal.Dock = Wisej.Web.DockStyle.Top;
            this.panelPricipal.HeaderAlignment = Wisej.Web.HorizontalAlignment.Center;
            this.panelPricipal.HeaderPosition = Wisej.Web.HeaderPosition.Left;
            this.panelPricipal.Location = new System.Drawing.Point(0, 0);
            this.panelPricipal.Name = "panelPricipal";
            this.panelPricipal.ShowHeader = true;
            this.panelPricipal.Size = new System.Drawing.Size(650, 181);
            this.panelPricipal.TabIndex = 0;
            this.panelPricipal.TabStop = true;
            this.panelPricipal.Tag = "";
            this.panelPricipal.Text = "Invoices";
            this.panelPricipal.PanelCollapsed += new System.EventHandler(this.panelPricipal_PanelCollapsed);
            this.panelPricipal.PanelExpanded += new System.EventHandler(this.panelPricipal_PanelExpanded);
            // 
            // panelContenido
            // 
            this.panelContenido.Controls.Add(this.panelRight);
            this.panelContenido.Controls.Add(this.panelLeft);
            this.panelContenido.Dock = Wisej.Web.DockStyle.Fill;
            this.panelContenido.HeaderAlignment = Wisej.Web.HorizontalAlignment.Center;
            this.panelContenido.HeaderSize = 34;
            this.panelContenido.Location = new System.Drawing.Point(0, 33);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(622, 148);
            this.panelContenido.TabIndex = 1;
            this.panelContenido.TabStop = true;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.numericUpDownSubTotal);
            this.panelRight.Controls.Add(this.checkBoxIsActivo);
            this.panelRight.Controls.Add(this.numericUpDownTotal);
            this.panelRight.Dock = Wisej.Web.DockStyle.Left;
            this.panelRight.Location = new System.Drawing.Point(306, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(306, 148);
            this.panelRight.TabIndex = 28;
            this.panelRight.TabStop = true;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.textBoxId);
            this.panelLeft.Controls.Add(this.comboBoxCustomerId);
            this.panelLeft.Controls.Add(this.numericUpDownTotalItbis);
            this.panelLeft.Dock = Wisej.Web.DockStyle.Left;
            this.panelLeft.HeaderAlignment = Wisej.Web.HorizontalAlignment.Center;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(306, 148);
            this.panelLeft.TabIndex = 8;
            this.panelLeft.TabStop = true;
            // 
            // textBoxId
            // 
            this.textBoxId.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.textBoxId.LabelText = "Id";
            this.textBoxId.Location = new System.Drawing.Point(6, 6);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(150, 37);
            this.textBoxId.TabIndex = 2;
            // 
            // comboBoxCustomerId
            // 
            this.comboBoxCustomerId.DropDownStyle = Wisej.Web.ComboBoxStyle.DropDownList;
            this.comboBoxCustomerId.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.comboBoxCustomerId.LabelText = "CustomerId";
            this.comboBoxCustomerId.Location = new System.Drawing.Point(6, 48);
            this.comboBoxCustomerId.Name = "comboBoxCustomerId";
            this.comboBoxCustomerId.ShowToolTips = true;
            this.comboBoxCustomerId.Size = new System.Drawing.Size(265, 37);
            this.comboBoxCustomerId.TabIndex = 3;
            // 
            // numericUpDownTotalItbis
            // 
            this.numericUpDownTotalItbis.DecimalPlaces = 2;
            this.numericUpDownTotalItbis.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.numericUpDownTotalItbis.LabelText = "TotalItbis";
            this.numericUpDownTotalItbis.Location = new System.Drawing.Point(6, 90);
            this.numericUpDownTotalItbis.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.numericUpDownTotalItbis.Name = "numericUpDownTotalItbis";
            this.numericUpDownTotalItbis.Size = new System.Drawing.Size(175, 37);
            this.numericUpDownTotalItbis.TabIndex = 4;
            this.numericUpDownTotalItbis.ThousandsSeparator = true;
            // 
            // numericUpDownSubTotal
            // 
            this.numericUpDownSubTotal.DecimalPlaces = 2;
            this.numericUpDownSubTotal.Enabled = false;
            this.numericUpDownSubTotal.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.numericUpDownSubTotal.LabelText = "SubTotal";
            this.numericUpDownSubTotal.Location = new System.Drawing.Point(22, 6);
            this.numericUpDownSubTotal.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.numericUpDownSubTotal.Name = "numericUpDownSubTotal";
            this.numericUpDownSubTotal.Size = new System.Drawing.Size(175, 37);
            this.numericUpDownSubTotal.TabIndex = 5;
            this.numericUpDownSubTotal.ThousandsSeparator = true;
            // 
            // numericUpDownTotal
            // 
            this.numericUpDownTotal.DecimalPlaces = 2;
            this.numericUpDownTotal.Enabled = false;
            this.numericUpDownTotal.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.numericUpDownTotal.LabelText = "Total";
            this.numericUpDownTotal.Location = new System.Drawing.Point(22, 48);
            this.numericUpDownTotal.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this.numericUpDownTotal.Name = "numericUpDownTotal";
            this.numericUpDownTotal.Size = new System.Drawing.Size(175, 37);
            this.numericUpDownTotal.TabIndex = 6;
            this.numericUpDownTotal.ThousandsSeparator = true;
            // 
            // checkBoxIsActivo
            // 
            this.checkBoxIsActivo.Appearance = Wisej.Web.Appearance.Switch;
            this.checkBoxIsActivo.Location = new System.Drawing.Point(22, 90);
            this.checkBoxIsActivo.Name = "checkBoxIsActivo";
            this.checkBoxIsActivo.Size = new System.Drawing.Size(98, 24);
            this.checkBoxIsActivo.TabIndex = 7;
            this.checkBoxIsActivo.Text = "IsActivo";
            // 
            // toolBar1
            // 
            this.toolBar1.BorderStyle = Wisej.Web.BorderStyle.Dotted;
            this.toolBar1.Buttons.AddRange(new Wisej.Web.ToolBarButton[] {
            this.toolBarButtonNuevo,
            this.toolBarButtonSalvar,
            this.toolBarButtonEditar,
            this.toolBarButtonCancelar,
            this.toolBarButtonEliminar,
            this.toolBarButtonBuscar,
            this.toolBarButtonImprimir,
            this.toolBarButtonExcel,
            this.toolBarButtonInfo,
            this.toolBarButtonRecargaCombo});
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(622, 33);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.TabStop = false;
            // 
            // toolBarButtonNuevo
            // 
            this.toolBarButtonNuevo.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/add-button-inside-black-circle.svg?color=too" +
    "lbarText";
            this.toolBarButtonNuevo.Name = "toolBarButtonNuevo";
            this.toolBarButtonNuevo.ToolTipText = "Nuevo";
            // 
            // toolBarButtonSalvar
            // 
            this.toolBarButtonSalvar.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/tick-inside-circle.svg?color=toolbarText";
            this.toolBarButtonSalvar.Name = "toolBarButtonSalvar";
            this.toolBarButtonSalvar.ToolTipText = "Salvar";
            // 
            // toolBarButtonEditar
            // 
            this.toolBarButtonEditar.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/underline-button.svg?color=toolbarText";
            this.toolBarButtonEditar.Name = "toolBarButtonEditar";
            this.toolBarButtonEditar.ToolTipText = "Editar";
            // 
            // toolBarButtonCancelar
            // 
            this.toolBarButtonCancelar.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/do-not-disturb-rounded-sign.svg?color=toolba" +
    "rText";
            this.toolBarButtonCancelar.Name = "toolBarButtonCancelar";
            this.toolBarButtonCancelar.ToolTipText = "Cancelar";
            // 
            // toolBarButtonEliminar
            // 
            this.toolBarButtonEliminar.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/rubbish-bin-delete-button.svg?color=toolbarT" +
    "ext";
            this.toolBarButtonEliminar.Name = "toolBarButtonEliminar";
            this.toolBarButtonEliminar.ToolTipText = "Eliminar";
            // 
            // toolBarButtonBuscar
            // 
            this.toolBarButtonBuscar.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/searching-magnifying-glass.svg?color=toolbar" +
    "Text";
            this.toolBarButtonBuscar.Name = "toolBarButtonBuscar";
            this.toolBarButtonBuscar.ToolTipText = "Buscar";
            // 
            // toolBarButtonImprimir
            // 
            this.toolBarButtonImprimir.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/printer-printing-document.svg?color=toolbarT" +
    "ext";
            this.toolBarButtonImprimir.Name = "toolBarButtonImprimir";
            this.toolBarButtonImprimir.ToolTipText = "Imprimir";
            // 
            // toolBarButtonExcel
            // 
            this.toolBarButtonExcel.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/microsoft-excel-logo.svg?color=toolbarText";
            this.toolBarButtonExcel.Name = "toolBarButtonExcel";
            this.toolBarButtonExcel.ToolTipText = "Exportar a Excel";
            // 
            // toolBarButtonInfo
            // 
            this.toolBarButtonInfo.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/rounded-info-button.svg?color=toolbarText";
            this.toolBarButtonInfo.Name = "toolBarButtonInfo";
            this.toolBarButtonInfo.ToolTipText = "Creado";
            // 
            // toolBarButtonRecargaCombo
            // 
            this.toolBarButtonRecargaCombo.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/synchronization-button-with-two-arrows.svg?c" +
    "olor=toolbarText";
            this.toolBarButtonRecargaCombo.Name = "toolBarButtonRecargaCombo";
            this.toolBarButtonRecargaCombo.Click += new System.EventHandler(this.toolBarButtonRecargaCombo_Click);
            // 
            // panelDetalles
            // 
            this.panelDetalles.BackColor = System.Drawing.Color.FromName("@tabSelected");
            this.panelDetalles.Dock = Wisej.Web.DockStyle.Fill;
            this.panelDetalles.Location = new System.Drawing.Point(0, 181);
            this.panelDetalles.Name = "panelDetalles";
            this.panelDetalles.Size = new System.Drawing.Size(650, 819);
            this.panelDetalles.TabIndex = 1;
            this.panelDetalles.TabStop = true;
            // 
            // UserControlInvoices
            // 
            this.AutoScroll = true;
            this.AutoSizeMode = Wisej.Web.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panelDetalles);
            this.Controls.Add(this.panelPricipal);
            this.Name = "UserControlInvoices";
            this.Size = new System.Drawing.Size(650, 1000);
            this.panelPricipal.ResumeLayout(false);
            this.panelPricipal.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotalItbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.ToolBar toolBar1;
        private Wisej.Web.Panel panelPricipal;
        private Wisej.Web.Panel panelContenido;
        private Wisej.Web.Panel panelLeft;
        private Wisej.Web.Panel panelRight;
        private Wisej.Web.ToolBarButton toolBarButtonNuevo;
        private Wisej.Web.ToolBarButton toolBarButtonSalvar;
        private Wisej.Web.ToolBarButton toolBarButtonEditar;
        private Wisej.Web.ToolBarButton toolBarButtonCancelar;
        private Wisej.Web.ToolBarButton toolBarButtonEliminar;
        private Wisej.Web.ToolBarButton toolBarButtonBuscar;
        private Wisej.Web.ToolBarButton toolBarButtonImprimir;
        private Wisej.Web.ToolBarButton toolBarButtonInfo;
        private Wisej.Web.ToolBarButton toolBarButtonExcel;
        private Wisej.Web.ToolBarButton toolBarButtonRecargaCombo;
        private Wisej.Web.TextBox textBoxId;
		private Wisej.Web.ComboBox comboBoxCustomerId;
		private Wisej.Web.NumericUpDown numericUpDownTotalItbis;
		private Wisej.Web.NumericUpDown numericUpDownSubTotal;
		private Wisej.Web.NumericUpDown numericUpDownTotal;
		private Wisej.Web.CheckBox checkBoxIsActivo;
        private Wisej.Web.Panel panelDetalles;
    }

}
