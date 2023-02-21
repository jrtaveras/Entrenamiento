using System;
using System.Collections.Generic;
using WisejWebApplication1;


public class HelperCalculo
{


	readonly Dictionary<Calculos, ICalculo> calcular = new Dictionary<Calculos, ICalculo>();
	public HelperCalculo()
	{
		calcular.Add(Calculos.Suma, new Suma());
		calcular.Add(Calculos.Resta, new Resta());
		calcular.Add(Calculos.Multiplicacion, new Multiplicacion());
		calcular.Add(Calculos.Division, new Division());
	}

	public decimal Calcular(Calculos calculos, decimal numero1,decimal numero2) {

		ICalculo resultado = null;
		calcular.TryGetValue(calculos, out resultado);
		resultado.Numero1 = numero1;
		resultado.Numero2 = numero2;
		return resultado.Calcular();
	
	}
}
