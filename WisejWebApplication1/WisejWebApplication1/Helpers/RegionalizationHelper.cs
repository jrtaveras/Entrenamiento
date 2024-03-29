﻿//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description:  Helper para traducciones , recorre el control que se le pasa como parametro y lo traduce an idioma especificado 
//Fecha:5/21/2021 9:16:21 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System.Globalization;
using System.Linq;
using System.Resources;
using System.Web;
using Wisej.Web;

namespace CommonUserControls.Helpers
{
    public class RegionalizationHelper
    {
        private ResourceManager _resMan;
        private CultureInfo _cultureInfo;
        public RegionalizationHelper(Control sender, ResourceManager resMan)
        {
            _resMan = resMan;
            _cultureInfo = Application.CurrentCulture;
            setLocalization(sender);
        }

        private void setLocalization(Control sender)
        {
            foreach (Control item in sender.Controls)
            {
                NumericUpDown numericUpDown = item as NumericUpDown;
                DateTimePicker dateTimePicker = item as DateTimePicker;
                CheckBox checkBox = item as CheckBox;
                TextBox textBox = item as TextBox;
                ToolBar toolBar = item as ToolBar;
                Button button = item as Button;
                ComboBox comboBox = item as ComboBox;
                TabPage tabPage = item as TabPage;

                Wisej.Web.Ext.NavigationBar.NavigationBarItem barItem = item as Wisej.Web.Ext.NavigationBar.NavigationBarItem;
                Wisej.Web.Ext.NavigationBar.NavigationBar navigationBar = item as Wisej.Web.Ext.NavigationBar.NavigationBar;
                if (numericUpDown != null && numericUpDown.Tag != null)
                {
                    numericUpDown.Label.Text = _resMan.GetString(numericUpDown.Tag.ToString(), _cultureInfo) ?? numericUpDown.Label.Text;
                }
                else if (dateTimePicker != null && dateTimePicker.Tag != null)
                {
                    dateTimePicker.Label.Text = _resMan.GetString(dateTimePicker.Tag.ToString(), _cultureInfo) ?? dateTimePicker.Label.Text;
                }
                else if (textBox != null && textBox.Tag != null)
                {
                    textBox.Label.Text = _resMan.GetString(textBox.Tag.ToString(), _cultureInfo) ?? textBox.Label.Text;
                }
                else if (checkBox != null && checkBox.Tag != null)
                {
                    checkBox.Text = _resMan.GetString(checkBox.Tag.ToString(), _cultureInfo) ?? checkBox.Text;
                }
                else if (navigationBar != null)
                {
                    foreach (var tempbarItem in navigationBar.Items)
                    {
                        if (tempbarItem != null)
                        {
                            tempbarItem.Text = _resMan.GetString(tempbarItem.Name, _cultureInfo) ?? tempbarItem.Text;
                            tempbarItem.ToolTipText = tempbarItem.Text;

                            if (tempbarItem.Items.Count > 0)
                                setLocalization(tempbarItem);
                        }
                    }

                }
                else if (barItem != null)
                {
                    barItem.Text = _resMan.GetString(barItem.Name, _cultureInfo) ?? barItem.Text;
                    barItem.ToolTipText = barItem.Text;

                    if (barItem.Items.Count > 0)
                        setLocalization(barItem);
                }
                else if (button != null)
                {
                    button.Text = _resMan.GetString(button.Name, _cultureInfo) ?? button.Text;
                }
                else if (comboBox != null && comboBox.Tag != null)
                {
                    comboBox.Label.Text = _resMan.GetString(comboBox.Tag.ToString(), _cultureInfo) ?? comboBox.Label.Text;
                }
                else if (tabPage != null && tabPage.Tag != null)
                {
                    tabPage.Text = _resMan.GetString(tabPage.Tag.ToString(), _cultureInfo) ?? tabPage.Text;
                }
                else if (toolBar != null)
                {
                    foreach (ToolBarButton toolBarbutton in toolBar.Buttons)
                    {
                        toolBarbutton.ToolTipText = _resMan.GetString(toolBarbutton.Name, _cultureInfo) ?? toolBarbutton.ToolTipText;
                    }

                }
                else if (item.Controls.Count > 0)
                {
                    setLocalization(item);
                }


            }
        }



    }

}