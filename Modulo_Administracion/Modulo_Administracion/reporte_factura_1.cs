namespace Modulo_Administracion
{
    public partial class reporte_factura_1 : DevExpress.XtraReports.UI.XtraReport
    {
        public reporte_factura_1()
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
