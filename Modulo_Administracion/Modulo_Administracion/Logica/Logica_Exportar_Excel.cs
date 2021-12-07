using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using ficheros = System.IO;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace Modulo_Administracion.Logica
{
    public class Logica_Exportar_Excel
    {


        public static void Export(string Titol, string ExcelName, string sheets, DataSet DS, bool bGrabar)
        {

            // Prevenir conflicto de idiomas. Si no se pone genera :
            // Old format or invalid type library. (Exception from HRESULT: 0x80028018 (TYPE_E_INVDATAREAD))
            string sTMP = System.Threading.Thread.CurrentThread.CurrentCulture.Name;

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");



            try
            {
                Microsoft.Office.Interop.Excel.Application _excel = new Microsoft.Office.Interop.Excel.Application();
                Workbook _wBook = _excel.Workbooks.Add(Missing.Value);

                int idx = 0;
                while (idx < DS.Tables.Count)
                {


                    Worksheet _sheet = (Worksheet)_wBook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    _sheet.Name = sheets.ToString();


                    //montamos las cabeceras de las columnas y les damos formato
                    int r = 1;
                    Range rng = (Range)_sheet.Cells[r, 1];
                    var k = 0;
                    while (k < DS.Tables[idx].Columns.Count)
                    {
                        _sheet.Cells[r, k + 1] = DS.Tables[idx].Columns[k].ColumnName.ToString();
                        System.Math.Max(System.Threading.Interlocked.Increment(ref k), k - 1);
                    }
                    rng = (Range)_sheet.Cells[r, DS.Tables[idx].Columns.Count];
                    rng.EntireRow.Font.Bold = true;
                    rng.EntireRow.Interior.ColorIndex = 30;
                    rng.EntireRow.Font.ColorIndex = 40;
                    rng.EntireRow.ColumnWidth = 15;
                    // Y a partir de ahí, montamos todos los datos del DataSet
                    r = 0;
                    while (r < DS.Tables[idx].Rows.Count)
                    {
                        k = 0;
                        while (k < DS.Tables[idx].Columns.Count)
                        {
                            var a = DS.Tables[idx].Columns[k].ColumnName.ToString();
                            if ((a.Contains("Fecha") || a.Contains("fecha")) && DS.Tables[idx].Rows[r].ItemArray[k].ToString() != "")
                            {
                                string result = DateTime.ParseExact(DS.Tables[idx].Rows[r].ItemArray[k].ToString(), "dd/MM/yyyy",
                                CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                                _sheet.Cells[r + 9, k + 1] = result;

                            }
                            else
                            {

                                if (DS.Tables[idx].Columns[k].ColumnName.ToString() == "Prima + Aporte" | DS.Tables[idx].Columns[k].ColumnName.ToString() == "Imp.Prima Total" | DS.Tables[idx].Columns[k].ColumnName.ToString() == "Aporte Total" | DS.Tables[idx].Columns[k].ColumnName.ToString() == "Premio" | DS.Tables[idx].Columns[k].ColumnName.ToString() == "Importe" | DS.Tables[idx].Columns[k].ColumnName.ToString() == "Importe IVA")
                                    _sheet.Cells[r + 9, k + 1] = System.Convert.ToDouble(DS.Tables[idx].Rows[r].ItemArray[k]).ToString("N4");
                                else
                                    _sheet.Cells[r + 9, k + 1] = DS.Tables[idx].Rows[r].ItemArray[k];
                            }
                            System.Math.Max(System.Threading.Interlocked.Increment(ref k), k - 1);
                        }
                        System.Math.Max(System.Threading.Interlocked.Increment(ref r), r - 1);


                    }
                    System.Math.Max(System.Threading.Interlocked.Increment(ref idx), idx - 1);
                }

                if (bGrabar == true)
                {
                    if (ficheros.File.Exists(ExcelName))
                        ficheros.File.Delete(ExcelName);

                    // Salimos del Excel 
                    _excel.ActiveCell.Worksheet.SaveAs(ExcelName, XlFileFormat.xlOpenXMLWorkbook, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    _excel.Quit();

                    // Mostrar el excel
                    _excel.Visible = false;

                    // Matamos el proceso
                    deleteProcess();
                }
                else
                    _excel.Visible = true;


                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(sTMP);
            }
            catch (Exception ex)
            {
                string ss = ex.Message;
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture(sTMP);

                MessageBox.Show(ss);
            }
        }

        private static void deleteProcess()
        {
            System.Diagnostics.Process[] miproceso = System.Diagnostics.Process.GetProcessesByName("EXCEL");

            foreach (System.Diagnostics.Process pc in miproceso)
                pc.Kill();
        }
    }
}
