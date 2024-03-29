﻿//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad CustomerTypes
//Fecha:2/20/2023 4:38:14 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)
//No toques esto por que al regenerar se sobreescribe el codigo

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using BusinessObjects.Interfaces;

namespace BusinessObjects.Models {
    [Table("CustomerTypes")]
    public partial class CustomerTypes  {
        [Key]
		public int Id {get; set;}
		[MaxLength(70,ErrorMessageResourceName = "MaxLengthErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		[Required(ErrorMessageResourceName = "RequiredErrorMessage",ErrorMessageResourceType = typeof(Resource))]
		public string Description {get; set;}
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
