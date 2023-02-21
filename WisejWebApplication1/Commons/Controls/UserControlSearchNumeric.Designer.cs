//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description:  Helper para traducciones , recorre el las columnas del datagridview que se le pasa como parametro y lo traduce an idioma especificado 
//Fecha:2/21/2023 9:02:54 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)

namespace Common.Controls
{
    partial class UserControlSearchNumeric
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
            this.buttonSearch = new Wisej.Web.Button();
            this.numericUpDownValue = new Wisej.Web.TextBox();
            this.textBoxDisplay = new Wisej.Web.TextBox();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromName("@window");
            this.buttonSearch.Dock = Wisej.Web.DockStyle.Right;
            this.buttonSearch.Image = global::Common.Properties.Resources.search;
            this.buttonSearch.Location = new System.Drawing.Point(375, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(65, 35);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // numericUpDownValue
            // 
            this.numericUpDownValue.Dock = Wisej.Web.DockStyle.Left;
            this.numericUpDownValue.Location = new System.Drawing.Point(0, 0);
            this.numericUpDownValue.Name = "numericUpDownValue";
            this.numericUpDownValue.Size = new System.Drawing.Size(62, 35);
            this.numericUpDownValue.TabIndex = 7;
            this.numericUpDownValue.Leave += new System.EventHandler(this.numericUpDownValue_Leave);
            // 
            // textBoxDisplay
            // 
            this.textBoxDisplay.Dock = Wisej.Web.DockStyle.Fill;
            this.textBoxDisplay.Location = new System.Drawing.Point(62, 0);
            this.textBoxDisplay.Name = "textBoxDisplay";
            this.textBoxDisplay.ReadOnly = true;
            this.textBoxDisplay.Size = new System.Drawing.Size(313, 35);
            this.textBoxDisplay.TabIndex = 8;
            this.textBoxDisplay.Enter += new System.EventHandler(this.textBoxDisplay_Enter);
            // 
            // UserControlSearchNumeric
            // 
            this.Controls.Add(this.textBoxDisplay);
            this.Controls.Add(this.numericUpDownValue);
            this.Controls.Add(this.buttonSearch);
            this.Name = "UserControlSearchNumeric";
            this.Size = new System.Drawing.Size(440, 35);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Button buttonSearch;
        private Wisej.Web.TextBox numericUpDownValue;
        private Wisej.Web.TextBox textBoxDisplay;
    }
}
