//Author: Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Description: Poco de entidad IPresenter
//Fecha:2/20/2023 4:38:14 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BusinessObjects.Interfaces
{
    public interface IValidate
    {
        void ShowErrors();
        void ClearErrorsValidations();
    }
}
