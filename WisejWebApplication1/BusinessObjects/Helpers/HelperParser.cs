

//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Helper para parsear HelperParser
//Fecha:2/20/2023 4:37:10 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Helpers
{
    public class HelperParser
    {
        public static bool TryParse(string type,String senderValue,ref object id)
        {
            if (type == "Int32" || type == "int" )
            {
                int idValue = 0;
                int.TryParse(senderValue, out idValue);
                if (idValue > 0)
                {
                    id = idValue;
                }
                    
                return (idValue > 0);
            }
            else if (type == "Int64" || type == "long")
            {
                long idValue = 0;
                long.TryParse(senderValue, out idValue);
                if (idValue > 0)
                {
                    id = idValue;
                }
                return (idValue > 0);
            }
            else if (type == "Guid")
            {
                Guid idValue = Guid.Empty;
                Guid.TryParse(senderValue, out idValue);
                if (idValue != Guid.Empty)
                {
                    id = idValue;
                }

                return (idValue != Guid.Empty);

            }
            else if (type == "string")
            {
                var idValue = string.Empty;
                
                if (!string.IsNullOrEmpty(senderValue.ToString()))
                {
                    id = senderValue.ToString();
                }

                return (id != null);

            }

            return false;
        }
    }
}
