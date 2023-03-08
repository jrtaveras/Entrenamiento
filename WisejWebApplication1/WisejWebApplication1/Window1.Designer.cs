
namespace WisejWebApplication1
{
    partial class Window1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new Wisej.Web.Label();
            this.label2 = new Wisej.Web.Label();
            this.numericUpDownNumero1 = new Wisej.Web.NumericUpDown();
            this.numericUpDownNumeric2 = new Wisej.Web.NumericUpDown();
            this.numericUpDownResultado = new Wisej.Web.NumericUpDown();
            this.label3 = new Wisej.Web.Label();
            this.buttonCalcular = new Wisej.Web.Button();
            this.comboBoxOperacion = new Wisej.Web.ComboBox();
            this.button1 = new Wisej.Web.Button();
            this.button2 = new Wisej.Web.Button();
            this.button3 = new Wisej.Web.Button();
            this.button4 = new Wisej.Web.Button();
            this.tabControl = new Wisej.Web.TabControl();
            this.tabPageClientes = new Wisej.Web.TabPage();
            this.tabPageTiposClientes = new Wisej.Web.TabPage();
            this.tabPageFacturas = new Wisej.Web.TabPage();
            this.tabPageProductos = new Wisej.Web.TabPage();
            this.tabPageGoogleMaps = new Wisej.Web.TabPage();
            this.tabOrderManager1 = new Wisej.Web.TabOrderManager(this.components);
            this.buttonGoogleMap = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumero1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResultado)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Numero2";
            // 
            // numericUpDownNumero1
            // 
            this.numericUpDownNumero1.DecimalPlaces = 2;
            this.numericUpDownNumero1.Location = new System.Drawing.Point(119, 34);
            this.numericUpDownNumero1.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.numericUpDownNumero1.Name = "numericUpDownNumero1";
            this.numericUpDownNumero1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownNumero1.TabIndex = 2;
            this.numericUpDownNumero1.ThousandsSeparator = true;
            this.numericUpDownNumero1.ValueChanged += new System.EventHandler(this.numericUpDownNumero1_ValueChanged);
            // 
            // numericUpDownNumeric2
            // 
            this.numericUpDownNumeric2.DecimalPlaces = 2;
            this.numericUpDownNumeric2.Location = new System.Drawing.Point(119, 64);
            this.numericUpDownNumeric2.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.numericUpDownNumeric2.Name = "numericUpDownNumeric2";
            this.numericUpDownNumeric2.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownNumeric2.TabIndex = 3;
            this.numericUpDownNumeric2.ThousandsSeparator = true;
            // 
            // numericUpDownResultado
            // 
            this.numericUpDownResultado.DecimalPlaces = 2;
            this.numericUpDownResultado.Editable = false;
            this.numericUpDownResultado.Enabled = false;
            this.numericUpDownResultado.Location = new System.Drawing.Point(119, 93);
            this.numericUpDownResultado.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.numericUpDownResultado.Name = "numericUpDownResultado";
            this.numericUpDownResultado.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownResultado.TabIndex = 4;
            this.numericUpDownResultado.ThousandsSeparator = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Resultado";
            // 
            // buttonCalcular
            // 
            this.buttonCalcular.Location = new System.Drawing.Point(119, 190);
            this.buttonCalcular.Name = "buttonCalcular";
            this.buttonCalcular.Size = new System.Drawing.Size(120, 27);
            this.buttonCalcular.TabIndex = 6;
            this.buttonCalcular.Text = "Calcular";
            this.buttonCalcular.Click += new System.EventHandler(this.buttonCalcular_Click);
            // 
            // comboBoxOperacion
            // 
            this.comboBoxOperacion.DropDownStyle = Wisej.Web.ComboBoxStyle.DropDownList;
            this.comboBoxOperacion.Location = new System.Drawing.Point(119, 145);
            this.comboBoxOperacion.Name = "comboBoxOperacion";
            this.comboBoxOperacion.Size = new System.Drawing.Size(120, 22);
            this.comboBoxOperacion.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "Clientes";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(119, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 27);
            this.button2.TabIndex = 9;
            this.button2.Text = "Tipos de cliente";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(119, 319);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 27);
            this.button3.TabIndex = 10;
            this.button3.Text = "Facturas";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(119, 366);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 27);
            this.button4.TabIndex = 11;
            this.button4.Text = "Productos";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageClientes);
            this.tabControl.Controls.Add(this.tabPageTiposClientes);
            this.tabControl.Controls.Add(this.tabPageFacturas);
            this.tabControl.Controls.Add(this.tabPageProductos);
            this.tabControl.Controls.Add(this.tabPageGoogleMaps);
            this.tabControl.Location = new System.Drawing.Point(277, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.PageInsets = new Wisej.Web.Padding(1, 35, 1, 1);
            this.tabControl.Size = new System.Drawing.Size(900, 760);
            this.tabControl.TabIndex = 12;
            // 
            // tabPageClientes
            // 
            this.tabPageClientes.Location = new System.Drawing.Point(1, 35);
            this.tabPageClientes.Name = "tabPageClientes";
            this.tabPageClientes.Size = new System.Drawing.Size(898, 724);
            this.tabPageClientes.Text = "Clientes";
            // 
            // tabPageTiposClientes
            // 
            this.tabPageTiposClientes.Location = new System.Drawing.Point(1, 35);
            this.tabPageTiposClientes.Name = "tabPageTiposClientes";
            this.tabPageTiposClientes.Size = new System.Drawing.Size(898, 724);
            this.tabPageTiposClientes.Text = "Tipos de clientes";
            // 
            // tabPageFacturas
            // 
            this.tabPageFacturas.Location = new System.Drawing.Point(1, 35);
            this.tabPageFacturas.Name = "tabPageFacturas";
            this.tabPageFacturas.Size = new System.Drawing.Size(898, 724);
            this.tabPageFacturas.Text = "Facturas";
            // 
            // tabPageProductos
            // 
            this.tabPageProductos.Location = new System.Drawing.Point(1, 35);
            this.tabPageProductos.Name = "tabPageProductos";
            this.tabPageProductos.Size = new System.Drawing.Size(898, 724);
            this.tabPageProductos.Text = "Productos";
            // 
            // tabPageGoogleMaps
            // 
            this.tabPageGoogleMaps.Location = new System.Drawing.Point(1, 35);
            this.tabPageGoogleMaps.Name = "tabPageGoogleMaps";
            this.tabPageGoogleMaps.Size = new System.Drawing.Size(898, 724);
            this.tabPageGoogleMaps.Text = "Mapas";
            // 
            // buttonGoogleMap
            // 
            this.buttonGoogleMap.Location = new System.Drawing.Point(119, 418);
            this.buttonGoogleMap.Name = "buttonGoogleMap";
            this.buttonGoogleMap.Size = new System.Drawing.Size(120, 27);
            this.buttonGoogleMap.TabIndex = 13;
            this.buttonGoogleMap.Text = "Google Maps";
            this.buttonGoogleMap.Click += new System.EventHandler(this.buttonGoogleMap_Click);
            // 
            // Window1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.buttonGoogleMap);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxOperacion);
            this.Controls.Add(this.buttonCalcular);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDownResultado);
            this.Controls.Add(this.numericUpDownNumeric2);
            this.Controls.Add(this.numericUpDownNumero1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Window1";
            this.Size = new System.Drawing.Size(1068, 399);
            this.Text = "Window1";
            this.Load += new System.EventHandler(this.Window1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumero1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResultado)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Label label1;
        private Wisej.Web.Label label2;
        private Wisej.Web.NumericUpDown numericUpDownNumero1;
        private Wisej.Web.NumericUpDown numericUpDownNumeric2;
        private Wisej.Web.NumericUpDown numericUpDownResultado;
        private Wisej.Web.Label label3;
        private Wisej.Web.Button buttonCalcular;
        private Wisej.Web.ComboBox comboBoxOperacion;
        private Wisej.Web.Button button1;
        private Wisej.Web.Button button2;
        private Wisej.Web.Button button3;
        private Wisej.Web.Button button4;
        private Wisej.Web.TabControl tabControl;
        private Wisej.Web.TabPage tabPageClientes;
        private Wisej.Web.TabPage tabPageTiposClientes;
        private Wisej.Web.TabPage tabPageFacturas;
        private Wisej.Web.TabPage tabPageProductos;
        private Wisej.Web.TabOrderManager tabOrderManager1;
        private Wisej.Web.Button buttonGoogleMap;
        private Wisej.Web.TabPage tabPageGoogleMaps;
    }
}

