//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/20/2023 2:23:15 PM
//Licencia:Frederic Schad (Todos los derechos Reservados)
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Wisej.Web;


namespace CommonUserControls.Helpers
{
    public class HelperControlsToValidate
    {
        private ErrorProvider errorProvider1 = new ErrorProvider();
        public Dictionary<string,Control> dic = new Dictionary<string,Control>();

        public  HelperControlsToValidate(Control sender)
        {
            addControlsToDictionary(sender);
        }

        protected void addControlsToDictionary(Control sender)
        {
            foreach (Control item in sender.Controls)
            {
                if(item.Tag != null)
                    addItemToDictionary(item);

                if (item.Controls.Count > 0)
                    addControlsToDictionary(item);
            }
        }

        private void addItemToDictionary(Control sender)
        {
            if (sender.Tag != null)
            {

                if (!dic.ContainsKey(sender.Tag.ToString()))
                {
                    dic.Add(sender.Tag.ToString(), sender);
                }
            }
        }

        public void ValidateMembers(ICollection<ValidationResult> sender) {


            foreach (var item in sender)
            {
                foreach (var memberName in item.MemberNames)
                {
                    var found = dic.Where(a => a.Key == memberName).FirstOrDefault();
                    if (!string.IsNullOrEmpty(found.Key))
                        errorProvider1.SetError(found.Value, item.ErrorMessage);

                }

            }
        }

        public void ClearErrors(ICollection<ValidationResult> sender)
        {
            foreach (var item in dic)
            {
                 errorProvider1.SetError(item.Value, null);

            }
        }
    }
}
