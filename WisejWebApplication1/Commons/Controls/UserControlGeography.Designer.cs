﻿namespace Common.Controls
{
    partial class UserControlGeography
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
            this.textBoxLongitude = new Wisej.Web.TextBox();
            this.textBoxLatitude = new Wisej.Web.TextBox();
            this.SuspendLayout();
            // 
            // textBoxLongitude
            // 
            this.textBoxLongitude.Label.Text = "Longitud";
            this.textBoxLongitude.Location = new System.Drawing.Point(127, 5);
            this.textBoxLongitude.Name = "textBoxLongitude";
            this.textBoxLongitude.Size = new System.Drawing.Size(100, 42);
            this.textBoxLongitude.TabIndex = 3;
            this.textBoxLongitude.Watermark = "Longitud";
            this.textBoxLongitude.Leave += new System.EventHandler(this.textBoxLongitude_Leave);
            this.textBoxLongitude.TextChanged += new System.EventHandler(this.textBoxLongitude_TextChanged);
            // 
            // textBoxLatitude
            // 
            this.textBoxLatitude.Label.Text = "Latitud";
            this.textBoxLatitude.Location = new System.Drawing.Point(5, 5);
            this.textBoxLatitude.Name = "textBoxLatitude";
            this.textBoxLatitude.Size = new System.Drawing.Size(100, 42);
            this.textBoxLatitude.TabIndex = 2;
            this.textBoxLatitude.Watermark = "Latitud";
            this.textBoxLatitude.Leave += new System.EventHandler(this.textBoxLatitude_Leave);
            this.textBoxLatitude.TextChanged += new System.EventHandler(this.textBoxLatitude_TextChanged);
            // 
            // UserControlGeography
            // 
            this.Controls.Add(this.textBoxLongitude);
            this.Controls.Add(this.textBoxLatitude);
            this.Name = "UserControlGeography";
            this.Size = new System.Drawing.Size(236, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Wisej.Web.TextBox textBoxLongitude;
        private Wisej.Web.TextBox textBoxLatitude;
    }
}
