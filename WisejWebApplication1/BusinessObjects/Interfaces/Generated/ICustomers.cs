//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad ICustomers
//Fecha:2/21/2023 2:49:38 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)
//No toques esto por que al regenerar se sobreescribe el codigo

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessObjects.Interfaces {
    public partial interface ICustomers {
        int Id {get; set;}
		string CustName {get; set;}
		string Adress {get; set;}
		bool Status {get; set;}
		int CustomerTypeId {get; set;}
		long TenantId {get; set;}
		bool IsActivo {get; set;}
		string Creado {get; set;}
		DateTime FechaCreado {get; set;}
		string Modificado {get; set;}
		DateTime FechaModificado {get; set;}
		
    }
}
