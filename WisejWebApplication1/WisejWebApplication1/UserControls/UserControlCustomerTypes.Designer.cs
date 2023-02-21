using Common.Constants;

namespace CommonUserControls
{

    partial  class UserControlCustomerTypes
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
            this.panelLeft = new Wisej.Web.Panel();
            this.panelRight = new Wisej.Web.Panel();
            this.toolBar1 = new Wisej.Web.ToolBar();
            this.toolBarButtonNuevo = new Wisej.Web.ToolBarButton();
            this.toolBarButtonSalvar = new Wisej.Web.ToolBarButton();
            this.toolBarButtonEditar = new Wisej.Web.ToolBarButton();
            this.toolBarButtonCancelar = new Wisej.Web.ToolBarButton();
            this.toolBarButtonEliminar = new Wisej.Web.ToolBarButton();
            this.toolBarButtonBuscar = new Wisej.Web.ToolBarButton();
            this.toolBarButtonImprimir = new Wisej.Web.ToolBarButton();
            this.toolBarButtonInfo = new Wisej.Web.ToolBarButton();
            this.toolBarButtonExcel = new Wisej.Web.ToolBarButton();
            this.toolBarButtonRecargaCombo = new Wisej.Web.ToolBarButton();
            this.panelPricipal.SuspendLayout();
            this.panelContenido.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelLeft.SuspendLayout();
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
            this.panelPricipal.Size = new System.Drawing.Size(674, 573);
            this.panelPricipal.TabIndex = 0;
            this.panelPricipal.TabStop = true;
            this.panelPricipal.Tag = "";
            this.panelPricipal.Text = "CustomerTypes";
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
            this.panelContenido.Size = new System.Drawing.Size(646, 540);
            this.panelContenido.TabIndex = 1;
            this.panelContenido.TabStop = true;
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
            this.toolBar1.Size = new System.Drawing.Size(1223, 28);
            this.toolBar1.TabIndex =  1;
            this.toolBar1.TabStop = false;
            // 
            // toolBarButtonNuevo
            // 
            this.toolBarButtonNuevo.Name = ToolBarButtonConstants.Nuevo;
            this.toolBarButtonNuevo.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/add-button-inside-black-circle.svg?color=too" +
    "lbarText";
            this.toolBarButtonNuevo.ToolTipText = "Nuevo";
            // 
            // toolBarButtonSalvar
            // 
            this.toolBarButtonSalvar.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/tick-inside-circle.svg?color=toolbarText";
            this.toolBarButtonSalvar.Name = ToolBarButtonConstants.Salvar;
            this.toolBarButtonSalvar.ToolTipText = "Salvar";
            // 
            // toolBarButtonEditar
            // 
            this.toolBarButtonEditar.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/underline-button.svg?color=toolbarText";
            this.toolBarButtonEditar.Name = ToolBarButtonConstants.Editar;
            this.toolBarButtonEditar.ToolTipText = "Editar";
            // 
            // toolBarButtonCancelar
            // 
            this.toolBarButtonCancelar.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/do-not-disturb-rounded-sign.svg?color=toolba" +
    "rText";
            this.toolBarButtonCancelar.Name = ToolBarButtonConstants.Cancelar;
            this.toolBarButtonCancelar.ToolTipText = "Cancelar";
            // 
            // toolBarButtonEliminar
            // 
            this.toolBarButtonEliminar.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/rubbish-bin-delete-button.svg?color=toolbarT" +
    "ext";
            this.toolBarButtonEliminar.Name = ToolBarButtonConstants.Eliminar;
            this.toolBarButtonEliminar.ToolTipText = "Eliminar";
            // 
            // toolBarButtonBuscar
            // 
            this.toolBarButtonBuscar.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/searching-magnifying-glass.svg?color=toolbar" +
    "Text";
            this.toolBarButtonBuscar.Name = ToolBarButtonConstants.Buscar;
            this.toolBarButtonBuscar.ToolTipText = "Buscar";
            // 
            // toolBarButtonImprimir
            // 
           this.toolBarButtonImprimir.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/printer-printing-document.svg?color=toolbarT" +
    "ext";
            this.toolBarButtonImprimir.Name = ToolBarButtonConstants.Imprimir;
            this.toolBarButtonImprimir.ToolTipText = "Imprimir";
            // 
            // toolBarButtonExcel
            // 
            this.toolBarButtonExcel.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/microsoft-excel-logo.svg?color=toolbarText";
            this.toolBarButtonExcel.Name = ToolBarButtonConstants.Excel;
            this.toolBarButtonExcel.ToolTipText = "Exportar a Excel";
            // 
            // toolBarButtonInfo
            // 
            this.toolBarButtonInfo.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/rounded-info-button.svg?color=toolbarText";
            this.toolBarButtonInfo.Name = ToolBarButtonConstants.Info;
            this.toolBarButtonInfo.ToolTipText = "Creado";
            // 
            // toolBarButtonRecargaCombo
            // 
            this.toolBarButtonRecargaCombo.ImageSource = "resource.wx/Wisej.Ext.MaterialDesign/synchronization-button-with-two-arrows.svg?color=toolbarText";
            this.toolBarButtonRecargaCombo.Name = ToolBarButtonConstants.RecargaCombo;
            this.toolBarButtonRecargaCombo.Click += new System.EventHandler(this.toolBarButtonRecargaCombo_Click);
            // 
            // UserControlCustomerTypes
            // 
            this.textBoxId = new  Wisej.Web.TextBox();
			this.textBoxDescription = new  Wisej.Web.TextBox();
			this.checkBoxIsActivo = new  Wisej.Web.CheckBox();
			
             // 
            // panelLeft
            // 
            //
			// textBoxId
			//
			this.textBoxId.Label.Position = Wisej.Web.LabelPosition.Inside;
			this.textBoxId.Label.Text = "Id";
			this.textBoxId.Location = new System.Drawing.Point(6,6);
			this.textBoxId.Name = "textBoxId";
			this.textBoxId.Size = new System.Drawing.Size(150, 22);
			this.textBoxId.TabIndex = 2;
			//
			// textBoxDescription
			//
			this.textBoxDescription.Label.Position = Wisej.Web.LabelPosition.Inside;
			this.textBoxDescription.Label.Text = "Description";
			this.textBoxDescription.Location = new System.Drawing.Point(6,48);
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.Size = new System.Drawing.Size(265, 22);
			this.textBoxDescription.TabIndex = 3;
			//
			// checkBoxIsActivo
			//
			this.checkBoxIsActivo.Appearance = Wisej.Web.Appearance.Switch;
			this.checkBoxIsActivo.Location = new System.Drawing.Point(6,90);
			this.checkBoxIsActivo.Name = "IsActivo";
			this.checkBoxIsActivo.Size = new System.Drawing.Size(42, 24);
			this.checkBoxIsActivo.TabIndex = 4;
			this.checkBoxIsActivo.Text = "IsActivo";
			
            this.panelLeft.Dock = Wisej.Web.DockStyle.Top;
            this.panelLeft.HeaderAlignment = Wisej.Web.HorizontalAlignment.Center;
            this.panelLeft.Dock = Wisej.Web.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(306, 550);
            this.panelLeft.TabIndex = 5;
            this.panelLeft.TabStop = true;
            this.panelLeft.Controls.Add(this.textBoxId);
			this.panelLeft.Controls.Add(this.textBoxDescription);
			this.panelLeft.Controls.Add(this.checkBoxIsActivo);
			
            // 
            // panelRight
            // 
            this.panelRight.Location = new System.Drawing.Point(306, 0);
            this.panelRight.Dock = Wisej.Web.DockStyle.Left;
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(306, 540);
            this.panelRight.TabIndex = 28;
            this.panelRight.TabStop = true;
            // 
            // UserControlCustomerTypes
            //
            this.AutoScroll = true;
            this.AutoSizeMode = Wisej.Web.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panelPricipal);
            this.Name =  "CustomerTypes";
            this.Size = new System.Drawing.Size(650, 1000);
            this.panelPricipal.ResumeLayout(false);
            this.panelPricipal.PerformLayout();
            this.panelContenido.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
		private Wisej.Web.TextBox textBoxDescription;
		private Wisej.Web.CheckBox checkBoxIsActivo;
		
       
    }

}
