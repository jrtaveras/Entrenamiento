//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad IInvoices
//Fecha:2/21/2023 2:50:15 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)
//No toques esto por que al regenerar se sobreescribe el codigo

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BusinessObjects.Interfaces {
    public partial interface IInvoices {
        int Id {get; set;}
		int CustomerId {get; set;}
		decimal TotalItbis {get; set;}
		decimal SubTotal {get; set;}
		decimal Total {get; set;}
		bool IsActivo {get; set;}
		string Creado {get; set;}
		DateTime FechaCreado {get; set;}
		string Modificado {get; set;}
		DateTime FechaModificado {get; set;}
		
    }
}
