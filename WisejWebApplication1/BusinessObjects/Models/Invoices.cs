//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad Invoices
//Fecha:2/21/2023 2:43:35 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using BusinessObjects.Interfaces;

namespace BusinessObjects.Models {

    public partial class Invoices  {
       
        public virtual Customers Customer { get; set; }
        public virtual ICollection<InvoiceDetails> Details { get; set; }

    }
}
