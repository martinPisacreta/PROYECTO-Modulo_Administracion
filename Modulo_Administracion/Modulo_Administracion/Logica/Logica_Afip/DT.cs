using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo_Administracion.Capas.Logica_Afip
{
    public class DT
    {
        public static decimal FormatearPMostrar(string valor , int numero_decimales)
        {
            decimal resultado = Math.Round(Convert.ToDecimal(valor), numero_decimales, MidpointRounding.AwayFromZero);
            return resultado;
        }
    }
}
