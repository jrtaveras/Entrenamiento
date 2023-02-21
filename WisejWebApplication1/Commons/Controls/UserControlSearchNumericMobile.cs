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
    [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
    public partial class UserControlSearchNumericMobile : Wisej.Web.UserControl
    {
        public event RaiseUserControlSearchNumeric OnValueChange;
        public SearchNumericDataType SearchNumericDataType { get; set; }
        public string Label { get => textBoxDisplay.Label.Text; set => textBoxDisplay.Label.Text = value; }
        private object _search;
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string ValueMember { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string DisplayMember { get; set; }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]

        public object Value
        {
            get
            {
                if (SearchNumericDataType == SearchNumericDataType.Integer)
                {
                    int _value = 0;
                    int.TryParse(numericUpDownValue.Text, out _value);
                    return _value;
                }
                else
                {
                    long _value = 0;
                    long.TryParse(numericUpDownValue.Text, out _value);
                    return _value;
                }
            }
            set
            {
                DisplayValue = string.Empty;

                numericUpDownValue.Text = value.ToString();
                if (SearchNumericDataType == SearchNumericDataType.Integer)
                {
                    int _value = 0;
                    int.TryParse(numericUpDownValue.Text, out _value);
                    if (_value > 0)
                        search();
                    else
                    {
                        numericUpDownValue.Text = 0.ToString();
                        _value = 0;
                    }
                }
                else
                {
                    long _value = 0;
                    long.TryParse(numericUpDownValue.Text, out _value);
                    if (_value > 0)
                        search();
                    else
                    {
                        numericUpDownValue.Text = 0.ToString();
                        _value = 0;
                    }
                }
            }
        }
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public string DisplayValue { get => textBoxDisplay.Text; set => textBoxDisplay.Text = value; }

        public UserControlSearchNumericMobile()
        {
            InitializeComponent();
        }
        public void SetDataSource(object search)
        {
            _search = search;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            var popop = new UserPopupSearchMobile(_search);
            popop.Closed += (oSender, oE) => {
                if (popop.Id != null)
                {
                    //numericUpDownValue.Text = popop.Id.ToString();
                    Value = popop.Id.ToString();

                    search();
                }
            };

            popop.ShowPopup(this);
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
            object found = null;
            MethodInfo method = objType.GetMethod("FindById");
            if (SearchNumericDataType == SearchNumericDataType.Long)
            {
                int _value = 0;
                //int.TryParse(numericUpDownValue.Text, out _value);
                int.TryParse(Value.ToString(), out _value);

                found = method.Invoke(_search, new object[] { _value });
            }
            else
            {
                long _value = 0;
                //long.TryParse(numericUpDownValue.Text, out _value);

                long.TryParse(Value.ToString(), out _value);

                found = method.Invoke(_search, new object[] { _value });
            }

            if (found != null)
            {
                if (SearchNumericDataType == SearchNumericDataType.Long)
                {
                    var result = (long)found.GetType().GetProperty(ValueMember).GetValue(found);
                    numericUpDownValue.Text = result.ToString();

                }
                else
                {
                    var result = (int)found.GetType().GetProperty(ValueMember).GetValue(found);
                    numericUpDownValue.Text = result.ToString();
                }

                textBoxDisplay.Text = found.GetType().GetProperty(DisplayMember).GetValue(found).ToString();
            }
            else
            {
                textBoxDisplay.Text = 0.ToString();

                DisplayValue = string.Empty;
            }
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

        private void textBoxDisplay_Enter(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(textBoxDisplay.Text) && Convert.ToInt64(Value) == 0)
            // numericUpDownValue.Value = 0;
        }

        private void numericUpDownValue_Leave(object sender, EventArgs e)
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

        private void numericUpDownValue_TextChanged(object sender, EventArgs e)
        {
            OnValueChange?.Invoke(numericUpDownValue.Text);
        }
    }
}