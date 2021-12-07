using Modulo_Administracion.Vista;
using System;
using System.Windows.Forms;

namespace Modulo_Administracion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        public const int Inicio = 0;
        public const int Alta = 1;
        public const int Modif = 2;
        public const int nro_copias = 2;
        public const string password = "123456";

        public const string ruta_guardar_factura_pdf = @"\\MAXI-PC\Compartida\FACTURAS DEL DIA\";
        //public const string ruta_guardar_factura_pdf = @"C:\Users\Martin\Desktop\";
        [STAThread]



        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
