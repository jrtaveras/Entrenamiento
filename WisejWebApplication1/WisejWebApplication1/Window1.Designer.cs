
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
            this.label1 = new Wisej.Web.Label();
            this.label2 = new Wisej.Web.Label();
            this.numericUpDownNumero1 = new Wisej.Web.NumericUpDown();
            this.numericUpDownNumeric2 = new Wisej.Web.NumericUpDown();
            this.numericUpDownResultado = new Wisej.Web.NumericUpDown();
            this.label3 = new Wisej.Web.Label();
            this.buttonCalcular = new Wisej.Web.Button();
            this.comboBoxOperacion = new Wisej.Web.ComboBox();
            this.button1 = new Wisej.Web.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumero1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumeric2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResultado)).BeginInit();
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
            this.button1.Location = new System.Drawing.Point(396, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Window1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
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
            this.Size = new System.Drawing.Size(1437, 803);
            this.Text = "Window1";
            this.Load += new System.EventHandler(this.Window1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumero1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumeric2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResultado)).EndInit();
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
    }
}

