#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using EntitySpaces.Interfaces;
using VisualWebGuiInvoice.UserControls;

#endregion

namespace VisualWebGuiInvoice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            esProviderFactory.Factory = new EntitySpaces.Loader.esDataProviderFactory();
            FSchad.Tools.Tool.CurrentEnvironment.CurrentUsername = "Kiefer";

            tabControl1.Controls.Clear();
        }

        private void toolStripMenuItemTiposClientes_Click(object sender, EventArgs e)
        {
            UserControlCustomerTypes customerTypes = new UserControlCustomerTypes();

            TabPage dw = new TabPage();
            dw.Name = "customerTypes";
            dw.Text = "customerTypes";
            dw.Controls.Add(customerTypes);

            tabControl1.Controls.Add(dw);
            
            customerTypes.Dock = DockStyle.Fill;
        }

        private void toolStripMenuItemClientes_Click(object sender, EventArgs e)
        {
            UserControlCustomers customers = new UserControlCustomers();

            TabPage dw = new TabPage();
            dw.Name = "customers";
            dw.Text = "customers";
            dw.Controls.Add(customers);

            tabControl1.Controls.Add(dw);
            customers.Dock = DockStyle.Fill;
        }

        private void toolStripMenuItemProductos_Click(object sender, EventArgs e)
        {
            UserControlProducts products = new UserControlProducts();

            TabPage dw = new TabPage();
            dw.Name = "products";
            dw.Text = "products";
            dw.Controls.Add(products);

            tabControl1.Controls.Add(dw);
            products.Dock = DockStyle.Fill;
        }

    }
}