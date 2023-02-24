/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 2/23/2023 11:26:14 AM
===============================================================================
*/

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using EntitySpaces.Interfaces;
using EntitySpaces.Core;

namespace BusinessObjects
{
	public partial class Customers : esCustomers
	{
		/*Custom by FSchad*/
		private void validateEntity(string columnName)
		{
             
            switch (columnName) 
            {
                case CustomersMetadata.ColumnNames.CustName:
                    if ((string.IsNullOrEmpty(this.CustName)))
                    {
                        _isValid = false;
                        strError = "Debe indicar el nombre del cliente";
                    }
                    break;

                case CustomersMetadata.ColumnNames.Adress:
                    if ((string.IsNullOrEmpty(this.Adress)))
                    {
                        _isValid = false;
                        strError = "Debe indicar la dirección";
                    }
                    break;

                case CustomersMetadata.ColumnNames.CustomerTypeId:
                    if (CustomerTypeId <= 0)
                    {
                        _isValid = false;
                        strError = "Debe indicar el tipo de cliente";
                    }
                    break;
            }
            
		}
		public override void extendedValidation(Hashtable sender)
		{
		
		}
		
		/*Custom by FSchad*/
	}
}
