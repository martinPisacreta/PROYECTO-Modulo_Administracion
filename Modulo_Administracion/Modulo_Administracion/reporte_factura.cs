using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.Sql.DataApi;
using System.Data;

namespace Modulo_Administracion
{
    public partial class reporte_factura : DevExpress.XtraReports.UI.XtraReport
    {
        public reporte_factura()
        {
            InitializeComponent();


        }

       

        private void xrTable1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrTable1.HeightF = 145.96F;
            xrTable1.WidthF = 301.44F;
        }
    }
}
