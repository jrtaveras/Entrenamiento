//Author: Jose Roberto Taveras
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
    public partial class UserPopupSearchMobile : Wisej.Web.UserPopup, ISearch
    {
        private object _search;

        public UserPopupSearchMobile(object search)
        {
            InitializeComponent();
            _search = search;
            dataBind();
            textBoxSearch.Focus();

        }

        private UserPopupSearchMobile()
        {
        }


        public void dataBind()
        {
            Type objType = _search.GetType(); ;
            MethodInfo method = objType.GetMethod("DataBind");
            object found = method.Invoke(_search, new object[] { this });
            // _search.DataBind(this);
        }

        public object Id { get; set; }
        public object DataGridSource
        {
            get
            {
                return dataGridViewResult.DataSource;
            }
            set
            {
                dataGridViewResult.DataSource = value;
            }
        }
        public string ValueToSearch { get { return textBoxSearch.Text; } set { textBoxSearch.Text = value; } }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Type objType = _search.GetType(); ;
                MethodInfo method = objType.GetMethod("Search");
                object found = method.Invoke(_search, new object[] { });
                //   _search.Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch_Click(null, null);
            }
        }

        private void dataGridViewResult_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewResult.SelectedRows.Count > 0)
                Id = this.dataGridViewResult.SelectedRows[0][0].Value;

            this.Close();
        }
    }
}
