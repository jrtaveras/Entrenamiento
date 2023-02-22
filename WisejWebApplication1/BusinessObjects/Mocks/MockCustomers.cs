//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/21/2023 2:49:38 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BusinessObjects.Interfaces;

namespace BusinessObjects.Mocks
{
    public class MockCustomers : ICustomers , IValidate  {
    
        public int Id {get; set;}
		public string CustName {get; set;}
		public string Adress {get; set;}
		public bool Status {get; set;}
		public int CustomerTypeId {get; set;}
		public long TenantId {get; set;}
		public bool IsActivo {get; set;}
		public string Creado {get; set;}
		public DateTime FechaCreado {get; set;}
		public string Modificado {get; set;}
		public DateTime FechaModificado {get; set;}
		     
        public void ClearErrorsValidations()
        {
           
        }

        public void ShowErrors()
        {
           
        }

    } 
}
