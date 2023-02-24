/*
===============================================================================
                    EntitySpaces 2009 by EntitySpaces, LLC
             Persistence Layer and Business Objects for Microsoft .NET
             EntitySpaces(TM) is a legal trademark of EntitySpaces, LLC
                          http://www.entityspaces.net
===============================================================================
EntitySpaces Version : 2009.2.1214.0
EntitySpaces Driver  : SQL
Date Generated       : 2/23/2023 11:26:15 AM
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
	public partial class InvoiceDetails : esInvoiceDetails
	{
		/*Custom by FSchad*/
		private void validateEntity(string columnName)
		{
				/*
                Regex matchRegex = new Regex(@"[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,5}");
                
                switch (columnName) 
                {
                    case LineMetadata.ColumnNames.Code:
                        if ((string.IsNullOrEmpty(this.Code)))
                        {
                            _isValid = false;
                            strError = "Debe indicar el Codigo";
                        }
                        break;
                    
                    case LineMetadata.ColumnNames.Email:
                        if (!matchRegex.IsMatch(this.Email))
                        {
                            _isValid = false;
                            strError = "Direcci�n del e-mail incorrecta";
                        }
                        break;
                    
                    case LineMetadata.ColumnNames.IsConsolidator:
                        if (this.IsConsolidator == null)
                        {
                            _isValid = false;
                            strError = "El isconsolidator no puede ser nulo";
                        }
                        break;
                }
				*/
		}
		public override void extendedValidation(Hashtable sender)
		{
		
		}
		
		/*Custom by FSchad*/
	}
}
