using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo_Administracion.Capas.Logica_Afip
{
    public class CBD
    {
        public enum VARIABLES
        {
            VENTA_ONLINE_A = 1,
            VENTA_ONLINE_B = 6,
            VENTA_ONLINE_C = 11
        }

        public enum CLIENTE_DOCUMENTO_TIPO_SISTEMA
        {
            CUIT = 80,
            NULO = 99
        }

        public enum CLIENTE_CONDICION_SISTEMA
        {
            IVA_RESPONSABLE_NO_INSCRIPTO = 1,
            IVA_SUJETO_EXENTO = 4,
            CONSUMIDOR_FINAL = 5,
            RESPONSABLE_MONOTRIBUTO = 6,
            PROVEEDOR_DEL_EXTERIOR = 8,
            CLIENTE_DEL_EXTERIOR = 9,
            MONOTRIBUTISTA_SOCIAL = 13,
            IVA_NO_ALCANZADO = 15
        }
    }
}
