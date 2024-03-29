﻿//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/20/2023 4:37:09 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Resources;

namespace BusinessObjects.Helpers
{
    public static class HelperDataTable {

        public static DataTable ToDataTable<T>(this IList<T> data, string tableName)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable(tableName);
            foreach (PropertyDescriptor prop in properties)
            {
                if (!prop.PropertyType.IsEnum)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }
                else
                {
                    table.Columns.Add(prop.Name, typeof(int));
                }
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    
                    if (!prop.PropertyType.IsEnum)
                    {
                        row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                    }
                    else 
                    {
                        row[prop.Name] = (int)prop.GetValue(item);
                    }
                }
            
                table.Rows.Add(row);
            }
            return table;
        }
        
        public static DataTable TranslateDataTable(this DataTable sender, ResourceManager resMan)
        {
            foreach (DataColumn item in sender.Columns)
            {
                item.Caption = resMan.GetString(item.ColumnName,Resource.Culture) ?? item.Caption;
            }
            return sender;
        }

    }
}
