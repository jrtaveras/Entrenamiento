using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisejWebApplication1
{
    public class Suma:ICalculo
    {
        public decimal Numero1 { get; set; }
        public decimal Numero2 { get; set; }
        public Calculos Calculos { get; set; } = Calculos.Suma;

        public decimal Calcular() {

            return Numero1 + Numero2;
        }
    }
}