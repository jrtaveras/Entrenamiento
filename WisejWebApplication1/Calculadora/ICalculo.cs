using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WisejWebApplication1
{
    public interface ICalculo
    {
        Calculos Calculos { get; set; }
        decimal Numero1 { get; set; }
        decimal Numero2 { get; set; }
        decimal Calcular();
    }
}
