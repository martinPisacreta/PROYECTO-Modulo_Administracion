using DevExpress.Pdf;
using Microsoft.VisualBasic;
using Modulo_Administracion.Clases;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Modulo_Administracion.Logica
{
    static class Logica_Funciones_Generales
    {

        public static DataSet CargarComboBox(string sTablas, ComboBox cControl, string sNomCamp, string sWhere, string sOrderBy, string sValueMember)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;
            ComboBox rb = cControl;

            try
            {
                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("cargar_combo_box", conn);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@Tabla", sTablas);
                    command.Parameters.AddWithValue("@WHERE", sWhere);
                    command.Parameters.AddWithValue("@ORDERBY", sOrderBy);

                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dataSet);
                }
                set2 = dataSet;

                rb.DataSource = set2.Tables[0];
                rb.DisplayMember = sNomCamp;
                rb.ValueMember = sValueMember;
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    reader = null;
                }
                if (conn != null)
                {
                    conn.Close();
                    conn = null;
                }
            }
            return set2;
        }

        public static bool validar_cuit(string cuit)
        {
            if (string.IsNullOrEmpty(cuit)) throw new ArgumentNullException(nameof(cuit));
            if (cuit.Length != 13) throw new ArgumentException(nameof(cuit));
            bool rv = false;
            int verificador;
            int resultado = 0;
            string cuit_nro = cuit.Replace("-", string.Empty);
            string codes = "6789456789";
            long cuit_long = 0;
            if (long.TryParse(cuit_nro, out cuit_long))
            {
                verificador = int.Parse(cuit_nro[cuit_nro.Length - 1].ToString());
                int x = 0;
                while (x < 10)
                {

                    int digitoValidador = int.Parse(codes.Substring((x), 1));
                    int digito = int.Parse(cuit_nro.Substring((x), 1));
                    int digitoValidacion = digitoValidador * digito;
                    resultado += digitoValidacion;
                    x++;
                }
                resultado = resultado % 11;
                rv = (resultado == verificador);
            }
            return rv;

        }

        public static string crear_path_a_partir_de_factura(factura factura)
        {
            string FilePath = "";
            cliente cliente = null;
            Logica_Cliente logica_cliente = new Logica_Cliente();
            try
            {
                string anio = factura.fecha.ToString("yyyy", CultureInfo.CreateSpecificCulture("es"));
                if (anio == "2020")
                {
                    FilePath = Program.ruta_guardar_factura_pdf + "AÑO 2020";
                }
                else
                {
                    FilePath = Program.ruta_guardar_factura_pdf + anio;
                    if (!Directory.Exists(FilePath))
                    {
                        Directory.CreateDirectory(FilePath);
                    }
                }

                string mes_en_letras = factura.fecha.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
                string mes_en_nro = factura.fecha.ToString("MM", CultureInfo.CreateSpecificCulture("es"));
                FilePath = FilePath + @"\" + mes_en_letras;
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }

                string dia = factura.fecha.ToString("dd", CultureInfo.CreateSpecificCulture("es"));
                FilePath = FilePath + @"\" + dia + "-" + mes_en_nro + "-" + anio;
                if (!Directory.Exists(FilePath))
                {
                    Directory.CreateDirectory(FilePath);
                }

                cliente = logica_cliente.buscar_cliente(factura.id_cliente);
                FilePath = FilePath + "\\" + cliente.nombre_fantasia + " - " + factura.ttipo_factura.letra + factura.nro_factura.ToString() + ".pdf";

                return FilePath;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static string generar_Pdf(factura factura)
        {

            try
            {
                //genero 
                reporte_factura reporte = new reporte_factura();
                reporte.Parameters["id_factura"].Value = Convert.ToInt32(factura.id_factura);
                reporte.Parameters["id_factura"].Visible = false;

                //mato los procesos que sean igual a FOXITREADER
                var resultado = from item in System.Diagnostics.Process.GetProcesses()
                                where item.ProcessName.ToUpper() == "FOXITREADER"
                                select item;

                foreach (var item in resultado)
                {
                    item.Kill();
                }

                reporte.ExportToPdf(factura.path_factura);

                return factura.path_factura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool mandar_a_imprimir(string ruta, string namePrinter, short nro_copias)
        {
            bool bandera = false;
            try
            {

                var pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer();
                pdfViewer.LoadDocument(ruta);

                // If required, declare and specify the system printer settings.
                PrinterSettings printerSettings = new PrinterSettings();
                printerSettings.PrinterName = namePrinter;
                printerSettings.PrintToFile = true;
                printerSettings.Copies = nro_copias;

                // Declare the PDF printer settings.
                // If required, pass the system settings to the PDF printer settings constructor.
                PdfPrinterSettings pdfPrinterSettings = new PdfPrinterSettings(printerSettings);

                // Specify the PDF printer settings.
                pdfPrinterSettings.PageOrientation = PdfPrintPageOrientation.Auto;
                pdfPrinterSettings.ScaleMode = PdfPrintScaleMode.CustomScale;
                pdfPrinterSettings.Scale = 90;

                // Print the document using the specified printer settings.
                pdfViewer.Print(pdfPrinterSettings);
                pdfViewer.CloseDocument();


                //using (var pdfViewer = new DevExpress.XtraPdfViewer.PdfViewer())
                //{
                //    pdfViewer.LoadDocument(ruta);
                //    //var settings = reportDataContext.ApplySettings(_sessionPrinterSettings);
                //    pdfViewer.ShowPrintStatusDialog = false;
                //    pdfViewer.Print();
                //    pdfViewer.CloseDocument();
                //}


                //System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(ruta);
                //info.Arguments = "\"" + namePrinter + "\"";
                //info.CreateNoWindow = true;
                //info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                //info.UseShellExecute = true;
                //info.Verb = "PrintTo";
                //System.Diagnostics.Process.Start(info);





                bandera = true;
                return bandera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ValidarFecha(string dtfecha)
        {
            // Tiene que venir la fecha con por lo menos el día y algún separador
            // (blancos, puntos, etc.) Si recibe una fecha con el mes mayor que 12,
            // asume que es el mes y lo da vuelta con el día
            // Devuelve la fecha con barras o ""
            string ValidarFecha = "";
            try
            {

                int iLongFecha;
                int iContador;
                string sFecha;
                string sAnio;
                int position;
                sFecha = "";
                iLongFecha = Strings.Len(dtfecha);
                if (iLongFecha == 0)
                {
                    ValidarFecha = "";
                    return ValidarFecha;
                }
                iContador = 1;
                while (iContador <= iLongFecha)
                {
                    if (Information.IsNumeric(Strings.Mid(dtfecha, iContador, 1)))
                        sFecha = sFecha + Strings.Mid(dtfecha, iContador, 1);
                    else
                        sFecha = sFecha + "/";
                    iContador = iContador + 1;
                }
                position = Strings.InStr(1, sFecha, "/");
                if (position == 0)
                    sFecha = sFecha + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy");
                else
                {
                    position = Strings.InStr(position + 1, sFecha, "/");
                    if (position == 0)
                    {
                        sFecha = sFecha + "/" + DateTime.Now.ToString("yyyy");
                        position = Strings.Len(sFecha);
                    }
                    else
                    {
                        if (position + 1 > Strings.Len(sFecha))
                            sAnio = "";
                        else
                            sAnio = Strings.Mid(sFecha, position + 1, Strings.Len(sFecha) - position + 1);
                        if (sAnio == "")
                            sFecha = Strings.Left(sFecha, position) + DateTime.Now.ToString("yyyy");
                    }
                }
                if (!Information.IsNumeric(sFecha))
                    sFecha = Strings.Format(Convert.ToDateTime(sFecha), "dd/MM/yyyy"); // Format(sFecha, "c")
                if (!(Information.IsDate(sFecha)))
                    ValidarFecha = "";
                else
                    ValidarFecha = sFecha;

                return ValidarFecha;
            }
            catch (Exception ex)
            {
                ValidarFecha = "";
                return ValidarFecha;
            }
        }

        public static bool email_bien_escrito(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static decimal monto_mas_menos_un_porcentaje(int porcentaje, decimal monto, int operador)
        {
            decimal aumento_descuento;
            decimal monto_final = 0.0000M;
            try
            {
                if (operador == 1) //suma
                {
                    aumento_descuento = (porcentaje * monto) / 100;
                    monto_final = (monto + aumento_descuento);
                }
                if (operador == 2) //resta
                {
                    aumento_descuento = (porcentaje * monto) / 100;
                    monto_final = (monto - aumento_descuento);
                }
                return monto_final;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}