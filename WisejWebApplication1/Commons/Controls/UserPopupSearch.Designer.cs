﻿//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: control generico base 
//Fecha:2/21/2023 9:02:54 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using BusinessObjects.Interfaces;
using System;
using Wisej.Web;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Common.Controls
{
    partial class UserPopupSearchMobile
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
            this.panel1 = new Wisej.Web.Panel();
            this.buttonSearch = new Wisej.Web.Button();
            this.textBoxSearch = new Wisej.Web.TextBox();
            this.dataGridViewResult = new Wisej.Web.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSearch);
            this.panel1.Controls.Add(this.textBoxSearch);
            this.panel1.Dock = Wisej.Web.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(949, 180);
            this.panel1.TabIndex = 73;
            this.panel1.TabStop = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.FromName("@window");
            this.buttonSearch.BackgroundImage = global::Common.Properties.Resources.search;
            this.buttonSearch.BackgroundImageLayout = Wisej.Web.ImageLayout.Stretch;
            this.buttonSearch.Location = new System.Drawing.Point(778, 15);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(150, 150);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = ((Wisej.Web.AnchorStyles)(((Wisej.Web.AnchorStyles.Top | Wisej.Web.AnchorStyles.Left) 
            | Wisej.Web.AnchorStyles.Right)));
            this.textBoxSearch.AutoSize = false;
            this.textBoxSearch.Font = new System.Drawing.Font("default", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxSearch.Label.Position = Wisej.Web.LabelPosition.Inside;
            this.textBoxSearch.LabelText = "  ";
            this.textBoxSearch.Location = new System.Drawing.Point(22, 15);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(757, 150);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.Watermark = "Ej.: Gil";
            this.textBoxSearch.KeyDown += new Wisej.Web.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.AutoSizeColumnsMode = Wisej.Web.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewResult.ColumnHeadersHeight = 75;
            this.dataGridViewResult.DefaultRowHeight = 70;
            this.dataGridViewResult.Dock = Wisej.Web.DockStyle.Fill;
            this.dataGridViewResult.Font = new System.Drawing.Font("default", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.dataGridViewResult.Location = new System.Drawing.Point(0, 180);
            this.dataGridViewResult.MultiSelect = false;
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.Size = new System.Drawing.Size(949, 517);
            this.dataGridViewResult.TabIndex = 74;
            this.dataGridViewResult.Click += new System.EventHandler(this.dataGridViewResult_Click);
            // 
            // UserPopupSearchMobile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = Wisej.Web.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridViewResult);
            this.Controls.Add(this.panel1);
            this.Name = "UserPopupSearchMobile";
            this.Size = new System.Drawing.Size(949, 697);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Panel panel1;
        private Wisej.Web.Button buttonSearch;
        private Wisej.Web.TextBox textBoxSearch;
        private Wisej.Web.DataGridView dataGridViewResult;
    }
}
