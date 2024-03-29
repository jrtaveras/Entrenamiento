﻿using System;
using System.Data;
using System.IO;
using FastReport.Export.Pdf;
using Wisej.Web;


namespace Common.Forms
{
    public partial class WindowPdfViewer : Form
    {
        private WindowPdfViewer()
        {
            InitializeComponent();
        }

        public WindowPdfViewer(string tituloVentana, DataTable reportDataTable, string reportName)
        {
            InitializeComponent();
            this.Text = tituloVentana;
            if (!reportName.ToLower().Contains(".frx"))
            {
                reportName += ".frx";
            }

            string path = $"{AppDomain.CurrentDomain.BaseDirectory}Reports\\{reportName}";

            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"the report file {reportName} not found in the folder Reports");
            }


            FastReport.Report report = new FastReport.Report();
            report.RegisterData(reportDataTable, reportDataTable.TableName);
            report.Load(path);
            report.Prepare();
            PDFExport pdf = new PDFExport();

            Stream stream = new MemoryStream();
            report.Export(pdf, stream);
            pdfViewer1.PdfStream = stream;
        }
    }
}
