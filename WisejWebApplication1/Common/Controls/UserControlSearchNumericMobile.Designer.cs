//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: control generico base 
//Fecha:2/21/2023 9:02:54 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)

namespace Common.Controls
{
    partial class UserControlSearchNumericMobile
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
            this.buttonSearch.BackColor = System.Drawing.Color.White;
            this.buttonSearch.BackgroundImageLayout = Wisej.Web.ImageLayout.BestFit;
            this.buttonSearch.Dock = Wisej.Web.DockStyle.Right;
            this.buttonSearch.Font = new System.Drawing.Font("default", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.buttonSearch.ForeColor = System.Drawing.Color.FromName("@controlText");
            this.buttonSearch.Location = new System.Drawing.Point(312, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(83, 32);
            this.buttonSearch.TabIndex = 8;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // numericUpDownValue
            // 
            this.numericUpDownValue.Dock = Wisej.Web.DockStyle.Left;
            this.numericUpDownValue.Location = new System.Drawing.Point(0, 0);
            this.numericUpDownValue.Name = "numericUpDownValue";
            this.numericUpDownValue.Size = new System.Drawing.Size(112, 32);
            this.numericUpDownValue.TabIndex = 9;
            this.numericUpDownValue.Leave += new System.EventHandler(this.numericUpDownValue_Leave);
            this.numericUpDownValue.TextChanged += new System.EventHandler(this.numericUpDownValue_TextChanged);
            // 
            // textBoxDisplay
            // 
            this.textBoxDisplay.Dock = Wisej.Web.DockStyle.Fill;
            this.textBoxDisplay.Location = new System.Drawing.Point(112, 0);
            this.textBoxDisplay.Name = "textBoxDisplay";
            this.textBoxDisplay.Size = new System.Drawing.Size(200, 32);
            this.textBoxDisplay.TabIndex = 10;
            // 
            // UserControlSearchNumericMobile
            // 
            this.Controls.Add(this.textBoxDisplay);
            this.Controls.Add(this.numericUpDownValue);
            this.Controls.Add(this.buttonSearch);
            this.Name = "UserControlSearchNumericMobile";
            this.Size = new System.Drawing.Size(395, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Button buttonSearch;
        private Wisej.Web.TextBox numericUpDownValue;
        private Wisej.Web.TextBox textBoxDisplay;
    }
}
