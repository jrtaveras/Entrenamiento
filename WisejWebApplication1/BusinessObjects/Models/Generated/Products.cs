//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad Products
//Fecha:2/22/2023 8:17:55 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)
//No toques esto por que al regenerar se sobreescribe el codigo

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using BusinessObjects.Interfaces;

namespace BusinessObjects.Models {
    [Table("Products")]
    public partial class Products  {
        [Key]
		public int Id {get; set;}
		[MaxLength(70,ErrorMessageResourceName = "MaxLengthErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public string Description {get; set;}
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
