//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: control generico base 
//Fecha:2/21/2023 9:02:54 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)
using BusinessObjects.Interfaces;
using System;
using System.ComponentModel;
using System.Reflection;
using Wisej.Web;

namespace Common.Controls
{
    public delegate void RaiseUserControlSearchText(string senderValue);
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    public partial class UserControlSearchText : Wisej.Web.UserControl
    {
        public event RaiseUserControlSearchText OnValueChange;
        public string Label { get => textBoxDisplay.Label.Text; set => textBoxDisplay.Label.Text = value; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public LabelPosition PotitionLabel { set { textBoxDisplay.Label.Position = value; } }

        private object _search;
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string ValueMember { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string DisplayMember { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string Value
        {
            get
            {
                return textBoxValue.Text;
            }
            set
            {
                DisplayValue = string.Empty;
                textBoxValue.Text = value;
                if (!string.IsNullOrEmpty(textBoxValue.Text))
                    search();
                if (OnValueChange != null)
                    OnValueChange(value ?? string.Empty);
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string DisplayValue { get => textBoxDisplay.Text; set => textBoxDisplay.Text = value; }

        public UserControlSearchText()
        {
            InitializeComponent();
        }
        public void SetDataSource(object search)
        {
            _search = search;
        }

        private void search()
        {
            if (_search == null)
            {
                throw new Exception("Debe especificar el presenter");
            }

            if (string.IsNullOrEmpty(ValueMember))
            {
                throw new Exception("Debe especificar el value member");
            }

            if (string.IsNullOrEmpty(DisplayMember))
            {
                throw new Exception("Debe especificar el display member");
            }


            Type objType = _search.GetType(); ;

            MethodInfo method = objType.GetMethod("FindById");
            object found = method.Invoke(_search, new object[] { textBoxValue.Text ?? string.Empty });

            if (found != null)
            {
                var id = found.GetType().GetProperty(ValueMember).GetValue(found).ToString();
                textBoxDisplay.Text = found.GetType().GetProperty(DisplayMember).GetValue(found).ToString();
            }
            else
            {
                Value = string.Empty;
                DisplayValue = string.Empty;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var popop = new UserPopupSearch(_search);
            popop.Closed += (oSender, oE) => {
                if (popop.Id != null)
                    Value = popop.Id.ToString();
            };
            popop.ShowPopup(this);
        }

        private void textBoxValue_Leave(object sender, EventArgs e)
        {
            try
            {
                search();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error" + ex.Message, "AVISO!!");
            }
        }
    }
}