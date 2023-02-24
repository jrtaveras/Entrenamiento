namespace VisualWebGuiInvoice
{
    partial class Form1
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new Gizmox.WebGUI.Forms.MenuStrip();
            this.toolStripMenuItemFiles = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClientes = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTiposClientes = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProductos = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTransacciones = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.toolStripMenuItemFacturas = new Gizmox.WebGUI.Forms.ToolStripMenuItem();
            this.splitContainer1 = new Gizmox.WebGUI.Forms.SplitContainer();
            this.tabControl1 = new Gizmox.WebGUI.Forms.TabControl();
            this.tabPage1 = new Gizmox.WebGUI.Forms.TabPage();
            this.tabPage2 = new Gizmox.WebGUI.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.DockPadding.Bottom = 2;
            this.menuStrip1.DockPadding.Left = 6;
            this.menuStrip1.DockPadding.Top = 2;
            this.menuStrip1.Items.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.toolStripMenuItemFiles,
            this.toolStripMenuItemTransacciones});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(650, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemFiles
            // 
            this.toolStripMenuItemFiles.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.toolStripMenuItemClientes,
            this.toolStripMenuItemTiposClientes,
            this.toolStripMenuItemProductos});
            this.toolStripMenuItemFiles.Name = "toolStripMenuItemFiles";
            this.toolStripMenuItemFiles.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.toolStripMenuItemFiles.Size = new System.Drawing.Size(32, 17);
            this.toolStripMenuItemFiles.Text = "Files";
            // 
            // toolStripMenuItemClientes
            // 
            this.toolStripMenuItemClientes.Name = "toolStripMenuItemClientes";
            this.toolStripMenuItemClientes.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.toolStripMenuItemClientes.Size = new System.Drawing.Size(112, 20);
            this.toolStripMenuItemClientes.Text = "Clientes";
            this.toolStripMenuItemClientes.Click += new System.EventHandler(this.toolStripMenuItemClientes_Click);
            // 
            // toolStripMenuItemTiposClientes
            // 
            this.toolStripMenuItemTiposClientes.Name = "toolStripMenuItemTiposClientes";
            this.toolStripMenuItemTiposClientes.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.toolStripMenuItemTiposClientes.Size = new System.Drawing.Size(153, 20);
            this.toolStripMenuItemTiposClientes.Text = "Tipos de clientes";
            this.toolStripMenuItemTiposClientes.Click += new System.EventHandler(this.toolStripMenuItemTiposClientes_Click);
            // 
            // toolStripMenuItemProductos
            // 
            this.toolStripMenuItemProductos.Name = "toolStripMenuItemProductos";
            this.toolStripMenuItemProductos.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.toolStripMenuItemProductos.Size = new System.Drawing.Size(153, 20);
            this.toolStripMenuItemProductos.Text = "Productos";
            this.toolStripMenuItemProductos.Click += new System.EventHandler(this.toolStripMenuItemProductos_Click);
            // 
            // toolStripMenuItemTransacciones
            // 
            this.toolStripMenuItemTransacciones.DropDownItems.AddRange(new Gizmox.WebGUI.Forms.ToolStripItem[] {
            this.toolStripMenuItemFacturas});
            this.toolStripMenuItemTransacciones.Name = "toolStripMenuItemTransacciones";
            this.toolStripMenuItemTransacciones.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.toolStripMenuItemTransacciones.Size = new System.Drawing.Size(79, 17);
            this.toolStripMenuItemTransacciones.Text = "Transacciones";
            // 
            // toolStripMenuItemFacturas
            // 
            this.toolStripMenuItemFacturas.Name = "toolStripMenuItemFacturas";
            this.toolStripMenuItemFacturas.Padding = new Gizmox.WebGUI.Forms.Padding(0, 0, 0, 0);
            this.toolStripMenuItemFacturas.Size = new System.Drawing.Size(116, 20);
            this.toolStripMenuItemFacturas.Text = "Facturas";
            this.toolStripMenuItemFacturas.Click += new System.EventHandler(this.toolStripMenuItemFacturas_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.AutoValidate = Gizmox.WebGUI.Forms.AutoValidate.EnablePreventFocusChange;
            this.splitContainer1.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.splitContainer1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.None;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = Gizmox.WebGUI.Forms.Orientation.Vertical;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1069, 615);
            this.splitContainer1.SplitterDistance = 25;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = Gizmox.WebGUI.Forms.TabAlignment.Top;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1240, 715);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1228, 689);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1232, 689);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            // 
            // Form1
            // 
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Size = new System.Drawing.Size(1269, 739);
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.MenuStrip menuStrip1;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem toolStripMenuItemFiles;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem toolStripMenuItemClientes;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem toolStripMenuItemTiposClientes;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem toolStripMenuItemProductos;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem toolStripMenuItemTransacciones;
        private Gizmox.WebGUI.Forms.ToolStripMenuItem toolStripMenuItemFacturas;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer1;
        private Gizmox.WebGUI.Forms.TabControl tabControl1;
        private Gizmox.WebGUI.Forms.TabPage tabPage1;
        private Gizmox.WebGUI.Forms.TabPage tabPage2;

    }
}