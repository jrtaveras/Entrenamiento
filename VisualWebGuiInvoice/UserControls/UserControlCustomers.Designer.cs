using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace VisualWebGuiInvoice.UserControls
{
    partial class UserControlCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlCustomers));
            this.userControlToolbar1 = new FSchad.Tools.UserControls.UserControlToolbar();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxId = new Gizmox.WebGUI.Forms.TextBox();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.label2 = new Gizmox.WebGUI.Forms.Label();
            this.textBoxCustName = new Gizmox.WebGUI.Forms.TextBox();
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
            this.panel1 = new Gizmox.WebGUI.Forms.Panel();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.userControlSearchCustomerType = new FSchad.Tools.UserControls.UserControlSearch();
            this.checkBoxStatus = new Gizmox.WebGUI.Forms.CheckBox();
            this.textBoxAddress = new Gizmox.WebGUI.Forms.TextBox();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.listViewData = new Gizmox.WebGUI.Forms.ListView();
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
            this.userControlToolbar1.Size = new System.Drawing.Size(801, 114);
            this.userControlToolbar1.TabIndex = 0;
            this.userControlToolbar1.ToolBarState = FSchad.Tools.UserControls.OnToolBarState.None;
            this.userControlToolbar1.OnAddNewEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnAddNewEntity);
            this.userControlToolbar1.OnUndoEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnUndoEntity);
            this.userControlToolbar1.OnDeleteEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnDeleteEntity);
            this.userControlToolbar1.OnSaveEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnSaveEntity);
            this.userControlToolbar1.OnSearchEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnSearchEntity);
            this.userControlToolbar1.OnEnabledDisabledControls += new FSchad.Tools.UserControls.UserControlToolbar.ToolBarStateEvent(this.userControlToolbar1_OnEnabledDisabledControls);
            this.userControlToolbar1.OnModifyEntity += new FSchad.Tools.UserControls.UserControlToolbar.ToolbarEvent(this.userControlToolbar1_OnModifyEntity);
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
            this.textBoxId.Controls.Add(this.label7);
            this.textBoxId.Location = new System.Drawing.Point(23, 75);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(66, 31);
            this.textBoxId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre del cliente";
            // 
            // textBoxCustName
            // 
            this.textBoxCustName.Location = new System.Drawing.Point(23, 149);
            this.textBoxCustName.Name = "textBoxCustName";
            this.textBoxCustName.Size = new System.Drawing.Size(381, 31);
            this.textBoxCustName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(466, 105);
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
            this.dateTimePickerFechaCreado.Location = new System.Drawing.Point(470, 130);
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
            this.dateTimePickerFechaModificado.Location = new System.Drawing.Point(470, 268);
            this.dateTimePickerFechaModificado.Name = "dateTimePickerFechaModificado";
            this.dateTimePickerFechaModificado.Size = new System.Drawing.Size(264, 21);
            this.dateTimePickerFechaModificado.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(466, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Fecha de Modificación";
            // 
            // textBoxCreado
            // 
            this.textBoxCreado.Location = new System.Drawing.Point(470, 61);
            this.textBoxCreado.Name = "textBoxCreado";
            this.textBoxCreado.ReadOnly = true;
            this.textBoxCreado.Size = new System.Drawing.Size(264, 26);
            this.textBoxCreado.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(468, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Creado";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(468, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Modificado";
            // 
            // textBoxModificado
            // 
            this.textBoxModificado.Location = new System.Drawing.Point(470, 194);
            this.textBoxModificado.Name = "textBoxModificado";
            this.textBoxModificado.ReadOnly = true;
            this.textBoxModificado.Size = new System.Drawing.Size(264, 31);
            this.textBoxModificado.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(152, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Tenant Id";
            // 
            // textBoxTenantId
            // 
            this.textBoxTenantId.Location = new System.Drawing.Point(154, 75);
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
            this.checkBoxIsActivo.Location = new System.Drawing.Point(154, 340);
            this.checkBoxIsActivo.Name = "checkBoxIsActivo";
            this.checkBoxIsActivo.Size = new System.Drawing.Size(89, 27);
            this.checkBoxIsActivo.TabIndex = 4;
            this.checkBoxIsActivo.Text = "Activo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.userControlSearchCustomerType);
            this.panel1.Controls.Add(this.checkBoxStatus);
            this.panel1.Controls.Add(this.textBoxAddress);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.textBoxId);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBoxCustName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dateTimePickerFechaCreado);
            this.panel1.Controls.Add(this.dateTimePickerFechaModificado);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.textBoxCreado);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.textBoxModificado);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textBoxTenantId);
            this.panel1.Controls.Add(this.checkBoxIsActivo);
            this.panel1.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 395);
            this.panel1.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 266);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Tipo de cliente";
            // 
            // userControlSearchCustomerType
            // 
            this.userControlSearchCustomerType.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.userControlSearchCustomerType.BorderColor = new Gizmox.WebGUI.Forms.BorderColor(System.Drawing.Color.Navy);
            this.userControlSearchCustomerType.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
            this.userControlSearchCustomerType.CleanValueIfNotExits = true;
            this.userControlSearchCustomerType.ColumnOrderName = "";
            this.userControlSearchCustomerType.CurrentState = FSchad.Tools.UserControls.OnToolBarState.None;
            this.userControlSearchCustomerType.FieldToHide = ((System.Collections.Generic.List<string>)(resources.GetObject("userControlSearchCustomerType.FieldToHide")));
            this.userControlSearchCustomerType.HideButtonAdd = false;
            this.userControlSearchCustomerType.HideButtonFind = false;
            this.userControlSearchCustomerType.Location = new System.Drawing.Point(23, 295);
            this.userControlSearchCustomerType.Name = "userControlSearchCustomerType";
            this.userControlSearchCustomerType.NotifyOnValueChanged = false;
            this.userControlSearchCustomerType.OrderByItem = null;
            this.userControlSearchCustomerType.OrderDirection = EntitySpaces.DynamicQuery.esOrderByDirection.Unassigned;
            this.userControlSearchCustomerType.SetEnableButtonFind = false;
            this.userControlSearchCustomerType.ShowButtons = true;
            this.userControlSearchCustomerType.ShowTextBoxCode = true;
            this.userControlSearchCustomerType.Size = new System.Drawing.Size(381, 28);
            this.userControlSearchCustomerType.TabIndex = 5;
            this.userControlSearchCustomerType.TabStopInDisplay = true;
            this.userControlSearchCustomerType.Text = "UserControlSearch";
            this.userControlSearchCustomerType.TextBoxCodeText = "";
            this.userControlSearchCustomerType.textBoxtCodeHeight = 26;
            this.userControlSearchCustomerType.textBoxtCodeWidth = 50;
            this.userControlSearchCustomerType.TextValueSearchText = "";
            this.userControlSearchCustomerType.TopFilter = 5;
            // 
            // checkBoxStatus
            // 
            this.checkBoxStatus.AutoSize = true;
            this.checkBoxStatus.Checked = true;
            this.checkBoxStatus.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
            this.checkBoxStatus.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxStatus.Location = new System.Drawing.Point(23, 340);
            this.checkBoxStatus.Name = "checkBoxStatus";
            this.checkBoxStatus.Size = new System.Drawing.Size(94, 27);
            this.checkBoxStatus.TabIndex = 4;
            this.checkBoxStatus.Text = "Estado";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(23, 219);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(381, 31);
            this.textBoxAddress.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(21, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Dirección";
            // 
            // listViewData
            // 
            this.listViewData.DataMember = null;
            this.listViewData.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.listViewData.Location = new System.Drawing.Point(0, 509);
            this.listViewData.Name = "listViewData";
            this.listViewData.Size = new System.Drawing.Size(801, 279);
            this.listViewData.TabIndex = 6;
            this.listViewData.DoubleClick += new System.EventHandler(this.listViewData_DoubleClick);
            // 
            // UserControlCustomers
            // 
            this.Controls.Add(this.listViewData);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userControlToolbar1);
            this.Size = new System.Drawing.Size(801, 788);
            this.Text = "UserControlCustomers";
            this.textBoxId.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FSchad.Tools.UserControls.UserControlToolbar userControlToolbar1;
        private Label label7;
        private TextBox textBoxId;
        private Label label1;
        private Label label2;
        private TextBox textBoxCustName;
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
        private Panel panel1;
        private CheckBox checkBoxStatus;
        private TextBox textBoxAddress;
        private Label label9;
        private Label label10;
        private FSchad.Tools.UserControls.UserControlSearch userControlSearchCustomerType;
        private ListView listViewData;


    }
}