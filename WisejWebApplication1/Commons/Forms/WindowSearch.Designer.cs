﻿namespace Common.Forms
{
    partial class WindowSearch<T>
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
            this.textBoxSearch = new Wisej.Web.TextBox();
            this.buttonSearch = new Wisej.Web.Button();
            this.buttonOk = new Wisej.Web.Button();
            this.dataGridViewData = new Wisej.Web.DataGridView();
            this.panelTop = new Wisej.Web.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.textBoxSearch.Label.Text = "Buscar";
            this.textBoxSearch.Location = new System.Drawing.Point(19, 6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(302, 37);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.Tag = "textBoxSearch";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(475, 6);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(84, 37);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Tag = "buttonSearch";
            this.buttonSearch.Text = "Buscar";
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(565, 6);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(85, 37);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Tag = "buttonOk";
            this.buttonOk.Text = "Aceptar";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.Dock = Wisej.Web.DockStyle.Fill;
            this.dataGridViewData.Location = new System.Drawing.Point(0, 49);
            this.dataGridViewData.MultiSelect = false;
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.SelectionMode = Wisej.Web.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewData.Size = new System.Drawing.Size(998, 416);
            this.dataGridViewData.TabIndex = 4;
            this.dataGridViewData.DoubleClick += new System.EventHandler(this.dataGridViewData_DoubleClick);
            // 
            // panelTop
            // 
            this.panelTop.Dock = Wisej.Web.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(998, 49);
            this.panelTop.TabIndex = 5;
            this.panelTop.TabStop = true;
            // 
            // WindowSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 465);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.panelTop);
            this.Name = "WindowSearch";
            this.Text = "Window1";
            this.Load += new System.EventHandler(this.WindowSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Wisej.Web.TextBox textBoxSearch;
        private Wisej.Web.Button buttonSearch;
        private Wisej.Web.Button buttonOk;
        private Wisej.Web.DataGridView dataGridViewData;
        private Wisej.Web.Panel panelTop;
    }
}
