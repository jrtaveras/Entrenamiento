//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad ICustomerTypes
//Fecha:2/21/2023 9:15:49 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)
//No toques esto por que al regenerar se sobreescribe el codigo

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessObjects.Interfaces {
    public partial interface ICustomerTypes {
        int Id {get; set;}
		string Description {get; set;}
		long TenantId {get; set;}
		bool IsActivo {get; set;}
		string Creado {get; set;}
		DateTime FechaCreado {get; set;}
		string Modificado {get; set;}
		DateTime FechaModificado {get; set;}
		
    }
}
