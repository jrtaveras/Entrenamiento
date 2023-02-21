using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisejWebApplication1
{
    public class Multiplicacion : ICalculo
    {
        public decimal Numero1 { get; set; }
        public decimal Numero2 { get; set; }
        public Calculos Calculos { get; set; } = Calculos.Multiplicacion;
        public decimal Calcular()
        {

            return Numero1 * Numero2;
        }
    }
}