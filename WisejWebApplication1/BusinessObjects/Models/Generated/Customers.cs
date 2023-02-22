//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad Customers
//Fecha:2/21/2023 2:49:38 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)
//No toques esto por que al regenerar se sobreescribe el codigo

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using BusinessObjects.Interfaces;

namespace BusinessObjects.Models {
    [Table("Customers")]
    public partial class Customers  {
        [Key]
		public int Id {get; set;}
		[MaxLength(70,ErrorMessageResourceName = "MaxLengthErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public string CustName {get; set;}
		[MaxLength(120,ErrorMessageResourceName = "MaxLengthErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public string Adress {get; set;}
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public bool Status {get; set;}
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public int CustomerTypeId {get; set;}
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
