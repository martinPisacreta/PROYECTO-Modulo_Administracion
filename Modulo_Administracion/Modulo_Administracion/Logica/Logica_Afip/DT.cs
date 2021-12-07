using System;

namespace Modulo_Administracion.Capas.Logica_Afip
{
    public class DT
    {
        public static decimal FormatearPMostrar(string valor, int numero_decimales)
        {
            decimal resultado = Math.Round(Convert.ToDecimal(valor), numero_decimales, MidpointRounding.AwayFromZero);
            return resultado;
        }
    }
}
