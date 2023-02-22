//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad Invoices
//Fecha:2/22/2023 8:16:59 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)
//No toques esto por que al regenerar se sobreescribe el codigo

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using BusinessObjects.Interfaces;

namespace BusinessObjects.Models {
    [Table("Invoices")]
    public partial class Invoices  {
        [Key]
		public int Id {get; set;}
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public int CustomerId {get; set;}
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public decimal TotalItbis {get; set;}
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public decimal SubTotal {get; set;}
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public decimal Total {get; set;}
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public long TenantId {get; set;}
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public bool IsActivo {get; set;}
		[MaxLength(40,ErrorMessageResourceName = "MaxLengthErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public string Creado {get; set;}
		[DateInitialization(ErrorMessageResourceName = "DateInitialization",ErrorMessageResourceType = typeof(Resource))]
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public DateTime FechaCreado {get; set;}
		[MaxLength(40,ErrorMessageResourceName = "MaxLengthErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public string Modificado {get; set;}
		[DateInitialization(ErrorMessageResourceName = "DateInitialization",ErrorMessageResourceType = typeof(Resource))]
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public DateTime FechaModificado {get; set;}
		
    }
}
