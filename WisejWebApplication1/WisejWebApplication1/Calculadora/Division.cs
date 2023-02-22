using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WisejWebApplication1
{
    public class Division : ICalculo
    {
        public decimal Numero1 { get; set; }
        public decimal Numero2 { get; set; }
        public Calculos Calculos { get; set; } = Calculos.Division;

        public decimal Calcular()
        {
            if (Numero2 == 0) {
                throw new Exception("La division por cero no esta admitida!!");
            }
            return Numero1 / Numero2;
        }
    }
}