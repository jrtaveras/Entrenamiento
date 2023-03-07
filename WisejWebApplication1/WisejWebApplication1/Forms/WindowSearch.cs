using System;
using Wisej.Web;
using BusinessObjects.Interfaces;
using BusinessObjects.Services;
using System.Globalization;
using Common.Helpers;


//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Formulario generico de busquedas WindowSearch
//Fecha:5/21/2021 9:16:20 AM
//Licence:Frederic Schad (Todos los derechos Reservados)

namespace Common.Forms
{
    public partial class CommonWindowSearch<T> : Form, ISearch
    {

        public object Id { get; set; }
        private readonly ISearchPresenter<T> _search;
        IContext _context;
        RegionalizationHelper _regionalizationHelper;
        CultureInfo _cultureInfo;
        public CommonWindowSearch(ISearchPresenter<T> search, string title)
        {
            InitializeComponent();
            _context = search.Context;
            _cultureInfo = Application.CurrentCulture;
            _search = search;
            this.Text = title;
            dataBind();
            this.CenterToParent();
            _regionalizationHelper = new RegionalizationHelper(this, _context.ResourceManager);
            if (Application.Browser.Device != "Desktop") 
            {
                this.Width = 650;
            }

        }

        public void dataBind()
        {
            _search.DataBind(this);
        }
        public object DataGridSource
        {
            get
            {
                return dataGridViewData.DataSource;
            }
            set
            {
                dataGridViewData.DataSource = value;
                translate();
            }
        }

        private void translate()
        {
            foreach (DataGridViewColumn item in dataGridViewData.Columns)
            {
                item.HeaderText = _context.ResourceManager.GetString(item.Name, _cultureInfo) ??  item.HeaderText;
            }
        }

        public string ValueToSearch { get { return textBoxSearch.Text; } set { textBoxSearch.Text = value; } }

       


        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewData.SelectedRows.Count > 0)
                Id = this.dataGridViewData.SelectedRows[0][0].Value;

            this.Close();

        }

        private void dataGridViewData_DoubleClick(object sender, EventArgs e)
        {
            buttonOk_Click(sender, e);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {	dataBind();
                _search.Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(getMessageException() + ex.Message, getMessageNotice(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }

        private void WindowSearch_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.textBoxSearch.KeyUp += (senderx, eX) =>
            {
                _search.Search();
            };
        }

        private string getMessageNotice()
        {
            return _context.ResourceManager.GetString(nameof(CommonConstants.MessageNotice), _cultureInfo) ?? CommonConstants.MessageNotice;
        }
        private string getMessageException()
        {
            return _context.ResourceManager.GetString(nameof(CommonConstants.MessageExcepcion), _cultureInfo) ?? CommonConstants.MessageExcepcion;
        }
    }
}
