//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description:  Helper para traducciones , recorre el las columnas del datagridview que se le pasa como parametro y lo traduce an idioma especificado 
//Fecha:5/21/2021 9:16:21 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using Wisej.Web;

namespace CommonUserControls.Helpers
{
    public static class DataGridViewExtension
    {
        public static void Translate(this DataGridView sender, ResourceManager resMan)
        {
            foreach (DataGridViewColumn item in sender.Columns)
            {
                item.HeaderText = resMan.GetString(item.Name, Application.CurrentCulture) ?? item.HeaderText;
            }
        }
    }
}
