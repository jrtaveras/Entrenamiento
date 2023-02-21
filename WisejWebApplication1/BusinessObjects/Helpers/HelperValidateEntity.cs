//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/20/2023 4:37:09 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessObjects.Helpers
{
    public class HelperValidateEntity
    {
        public ICollection<ValidationResult> ValidationResult { get; set; }
        public  bool ValidateService(object sender)
        {
            ValidationContext validationContext = new ValidationContext(sender);
            ValidationResult = new List<ValidationResult>();
            return Validator.TryValidateObject(sender, validationContext, ValidationResult, true);
        }
    }
}
