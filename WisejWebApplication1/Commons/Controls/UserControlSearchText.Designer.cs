//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: control generico base 
//Fecha:2/21/2023 9:02:54 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)


namespace Common.Controls
{
    partial class UserControlSearchText
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
            this.textBoxValue = new Wisej.Web.TextBox();
            this.textBoxDisplay = new Wisej.Web.TextBox();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromName("@window");
            this.buttonSearch.Dock = Wisej.Web.DockStyle.Right;
            this.buttonSearch.Image = global::Common.Properties.Resources.search;
            this.buttonSearch.Location = new System.Drawing.Point(384, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(65, 28);
            this.buttonSearch.TabIndex = 5;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxValue
            // 
            this.textBoxValue.Dock = Wisej.Web.DockStyle.Left;
            this.textBoxValue.Location = new System.Drawing.Point(0, 0);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(62, 28);
            this.textBoxValue.TabIndex = 6;
            this.textBoxValue.Leave += new System.EventHandler(this.textBoxValue_Leave);
            // 
            // textBoxDisplay
            // 
            this.textBoxDisplay.Dock = Wisej.Web.DockStyle.Fill;
            this.textBoxDisplay.Location = new System.Drawing.Point(62, 0);
            this.textBoxDisplay.Name = "textBoxDisplay";
            this.textBoxDisplay.ReadOnly = true;
            this.textBoxDisplay.Size = new System.Drawing.Size(322, 28);
            this.textBoxDisplay.TabIndex = 7;
            // 
            // UserControlSearchText
            // 
            this.Controls.Add(this.textBoxDisplay);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.buttonSearch);
            this.Name = "UserControlSearchText";
            this.Size = new System.Drawing.Size(449, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.Button buttonSearch;
        private Wisej.Web.TextBox textBoxValue;
        private Wisej.Web.TextBox textBoxDisplay;
    }
}
