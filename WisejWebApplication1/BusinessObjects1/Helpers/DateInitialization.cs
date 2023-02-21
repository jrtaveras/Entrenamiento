using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class DateInitialization : ValidationAttribute
    {
      
        public override bool IsValid(object obj)
        {
            var date = new DateTime(1900, 01, 01);
            
            return Convert.ToDateTime(obj) >= date;
        }
    }
}
