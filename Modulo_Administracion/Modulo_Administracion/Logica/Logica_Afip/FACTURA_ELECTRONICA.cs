namespace Modulo_Administracion.Capas.Logica_Afip
{
    public class FACTURA_ELECTRONICA
    {
        //        AFIP_ELECTRONICA.WS_AMBIENTE AMBIENTE = AFIP_ELECTRONICA.WS_AMBIENTE.PRODUCCION;
        //        string IDCAJA = null, IDVENTA = null;
        //        public string VENTA_IDFACTURA_EMITIDA = null;

        //        //VENTA
        //        CBD.VARIABLES VENTA_COMPROBANTE_SISTEMA = 0;
        //        AFIP_ELECTRONICA.COMPROBANTES_TIPO VENTA_COMPROBANTE_AFIP = AFIP_ELECTRONICA.COMPROBANTES_TIPO.FACTURA_C;
        //        AFIP_ELECTRONICA.VENTA_CONCEPTO VENTA_CONCEPTO = AFIP_ELECTRONICA.VENTA_CONCEPTO.PRODUCTOS;
        //        ProcesoVenta.FormaPago VENTA_FORMA_PAGO = ProcesoVenta.FormaPago.EFECTIVO;
        //        DataTable DT_PRODUCTOS;
        //        DateTime F_EMISION, F_VENCIMIENTO, F_DESDE, F_HASTA;
        //        string VENTA_OBSERVACION;
        //        decimal D_NETO = 0, D_IVA = 0;
        //        decimal D_MUNICIPAL = 0, D_MUNICIPAL_PORC = 0, D_PROVINCIAL = 0, D_PROVINCIAL_PORC = 0;
        //        decimal D_NACIONAL = 0, D_NACIONAL_PORC = 0, D_INTERNO = 0, D_INTERNO_PORC = 0;
        //        decimal D_DESCUENTO = 0, D_RECARGO = 0, D_TOTAL = 0;

        //        //CLIENTE
        //        CBD.CLIENTE_DOCUMENTO_TIPO_SISTEMA CLIENTE_DOCUMENTO_TIPO_SISTEMA = CBD.CLIENTE_DOCUMENTO_TIPO_SISTEMA.CUIL;
        //        string CLIENTE_RAZON_SOCIAL, CLIENTE_DOCUMENTO_NUMERO, CLIENTE_CARACTERIZACION, CLIENTE_DOMICILIO;
        //        string CLIENTE_CONDICION, CLIENTE_TIPO_PERSONA, CLIENTE_CATEGORIA, CLIENTE_ACTIVIDADES;

        //        public FACTURA_ELECTRONICA(string IDCAJA,string IDVENTA,CBD.VARIABLES TIPO_COMPROBANTE_SISTEMA,
        //            ProcesoVenta.FormaPago FORMA_DE_PAGO,
        //            string CLIENTE_RAZON_SOCIAL,CBD.CLIENTE_CONDICION_SISTEMA CLIENTE_CONDICION,
        //            CBD.CLIENTE_DOCUMENTO_TIPO_SISTEMA CLIENTE_DOCUMENTO_TIPO ,string CLIENTE_DOCUMENTO_NUMERO,string CLIENTE_DOMICILIO,
        //            string OBSERVACION,
        //            DateTime F_EMISION,DateTime F_VENCIMIENTO,DateTime F_DESDE,DateTime F_HASTA,
        //            DataTable DTPRODUCTOS,
        //            decimal D_NETO,decimal D_IVA,decimal D_MUNICIPAL , decimal D_PROVINCIAL , decimal D_NACIONAL , decimal D_INTERNO,
        //            decimal D_DESCUENTO, decimal D_RECARGO ,decimal D_TOTAL)
        //        {
        //            InitializeComponent();
        //            this.IDCAJA = IDCAJA;
        //            this.IDVENTA = IDVENTA;
        //            this.CLIENTE_RAZON_SOCIAL = CLIENTE_RAZON_SOCIAL;
        //            this.CLIENTE_CONDICION = CLIENTE_CONDICION;
        //            this.CLIENTE_DOCUMENTO_TIPO_SISTEMA = CLIENTE_DOCUMENTO_TIPO_SISTEMA;
        //            this.CLIENTE_DOCUMENTO_NUMERO = CLIENTE_DOCUMENTO_NUMERO.Replace("-","");
        //            this.CLIENTE_DOMICILIO = CLIENTE_DOMICILIO;
        //            VENTA_COMPROBANTE_SISTEMA = TIPO_COMPROBANTE_SISTEMA;

        //            if (VENTA_COMPROBANTE_SISTEMA == CBD.VARIABLES.VENTA_ONLINE_A)
        //                CLIENTE_DOCUMENTO_TIPO_SISTEMA = CBD.CLIENTE_DOCUMENTO_TIPO_SISTEMA.CUIT;

        //            switch(VENTA_COMPROBANTE_SISTEMA)
        //            {
        //                case CBD.VARIABLES.VENTA_ONLINE_A:
        //                    VENTA_COMPROBANTE_AFIP = AFIP_ELECTRONICA.COMPROBANTES_TIPO.FACTURA_A;
        //                    break;

        //                case CBD.VARIABLES.VENTA_ONLINE_B:
        //                    VENTA_COMPROBANTE_AFIP = AFIP_ELECTRONICA.COMPROBANTES_TIPO.FACTURA_B;
        //                    break;

        //                case CBD.VARIABLES.VENTA_ONLINE_C:
        //                    VENTA_COMPROBANTE_AFIP = AFIP_ELECTRONICA.COMPROBANTES_TIPO.FACTURA_C;
        //                    break;
        //            }

        //            VENTA_FORMA_PAGO = FORMA_DE_PAGO;
        //            VENTA_OBSERVACION = OBSERVACION;

        //            this.F_EMISION = F_EMISION;
        //            this.F_VENCIMIENTO = F_VENCIMIENTO;
        //            this.F_DESDE = F_DESDE;
        //            this.F_HASTA = F_HASTA;
        //            this.DT_PRODUCTOS = DT_PRODUCTOS;

        //            this.D_NETO = D_NETO;
        //            this.D_IVA = D_IVA;
        //            this.D_MUNICIPAL = D_MUNICIPAL;
        //            this.D_PROVINCIAL = D_PROVINCIAL;
        //            this.D_NACIONAL = D_NACIONAL;
        //            this.D_INTERNO = D_INTERNO;
        //            this.D_DESCUENTO = D_DESCUENTO;
        //            this.D_RECARGO = D_RECARGO;
        //            this.D_TOTAL = D_TOTAL;


        //        }

        //        private void FACTURA_ELECTRONICA_Load(object sender, EventArgs e)
        //        {
        //            Application.DoEvents();
        //        }

        //        private void FACTURA_ELECTRONICA_Shown(object sender,EventArgs e)
        //        {
        //            FProcesado FPROC = DT.PROCESANDO_MOSTRAR();
        //            string RESPUESTA = DATOS_GET();
        //            if(!string.IsNullOrEmpty(RESPUESTA))
        //            {
        //                txt_Respuesta.Text = RESPUESTA;
        //                goto ERROR;
        //            }

        //            if(string.IsNullOrEmpty(CGLOBAL.WS_EMISOR_RAZON_SOCIAL) || 
        //                string.IsNullOrEmpty(CGLOBAL.WS_EMISOR_CONDICION.ToString()) ||
        //                string.IsNullOrEmpty(CGLOBAL.WS_EMISOR_CUIT))
        //            {
        //                RESPUESTA = EMISOR_CONSULTA_AFIP();
        //                if(!string.IsNullOrEmpty(RESPUESTA))
        //                {
        //                    txt_Respuesta.Text = RESPUESTA;
        //                    goto ERROR;
        //                }
        //            }

        //            RESPUESTA = FACTURA_EMITIR();
        //            if(!string.IsNullOrEmpty(RESPUESTA))
        //            {
        //                txt_Respuesta.Text = RESPUESTA;
        //                goto ERROR;
        //            }

        //            DT.PROCESANDO_CERRAR(FPROC);
        //            if (string.IsNullOrEmpty(RESPUESTA))
        //                this.Close();

        //            return;

        //            ERROR:
        //            {
        //                MessageBox.Show(ERROR, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }



        //        public string FACTURA_EMITIR()
        //        {

        //            DataTable DTIVA = new DataTable();
        //            DTIVA.Columns.Add("IMPORTE_NETO");
        //            DTIVA.Columns.Add("IVA_ID");
        //            DTIVA.Columns.Add("IVA_ALICUOTA");
        //            DTIVA.Columns.Add("IVA_IMPORTE");


        //            bool NUEVO = true;
        //            decimal D_NETO = 0;
        //            decimal D_IVA = 0;
        //            decimal D_NETO_TOTAL = 0;
        //            decimal D_IVA_TOTAL = 0;
        //            for(int i = 0; i < DTPRODUCTOS.Rows.Count; i++)
        //            {
        //                NUEVO = true;
        //                if (Convert.ToDecimal(DTPRODUCTOS.Rows[i]["IVA_TOTAL"].ToString()) <= 0)
        //                    continue;

        //                D_NETO_TOTAL += Convert.ToDecimal(DTPRODUCTOS.Rows[i]["NETO_TOTAL"].ToString());
        //                D_IVA_TOTAL += Convert.ToDecimal(DTPRODUCTOS.Rows[i]["IVA_TOTAL"].ToString());

        //                for(int j = 0; j < DTPRODUCTOS.Rows.Count; i++)
        //                {
        //                    if(Convert.ToDecimal(DTPRODUCTOS.Rows[i]["IVA_PORC"].ToString()) ==
        //                         Convert.ToDecimal(DTPRODUCTOS.Rows[j]["IVA_ALICUOTA"].ToString()))
        //                    {
        //                        D_NETO = Convert.ToDecimal(DTPRODUCTOS.Rows[i]["NETO_TOTAL"].ToString()) +
        //                             Convert.ToDecimal(DTPRODUCTOS.Rows[j]["IMPORTE_NETO"].ToString());

        //                        D_IVA = Convert.ToDecimal(DTPRODUCTOS.Rows[i]["IVA_TOTAL"].ToString()) +
        //                             Convert.ToDecimal(DTPRODUCTOS.Rows[j]["IVA_IMPORTE"].ToString());

        //                        DTIVA.Rows[j]["IMPORTE_NETO"] = D_NETO;
        //                        DTIVA.Rows[j]["IVA_IMPORTE"] = D_IVA;
        //                        NUEVO = false;
        //                        break;
        //                    }
        //                }

        //                if(NUEVO)
        //                {
        //                    DTIVA.Rows.Add((DTPRODUCTOS.Rows[i]["NETO_TOTAL"].ToString()),
        //                    (int)AFIP_ELECTRONICA.IVA_ALICUOTA_ID_GET(Convert.ToDecimal(DTPRODUCTOS.Rows[i]["IVA_PORC"].ToString())),
        //                    DTPRODUCTOS.Rows[i]["IVA_PORC"].ToString(),
        //                    DTPRODUCTOS.Rows[i]["IVA_TOTAL"].ToString());
        //                }
        //            }



        //            DataTable DTRIBUTOS = new DataTable();
        //            DTRIBUTOS.Columns.Add("IMPORTE_NETO");
        //            DTRIBUTOS.Columns.Add("TRIBUTO_ID");
        //            DTRIBUTOS.Columns.Add("TRIBUTO_NOMBRE");
        //            DTRIBUTOS.Columns.Add("TRIBUTO_IMPORTE");

        //            DTRIBUTOS.Rows.Add(DT.FormatearPMostrar(D_NETO_TOTAL.ToString(), 3),
        //                (int)AFIP_ELECTRONICA.TIPO_TRIBUTO.IMPUESTOS_MUNICIPALES,
        //                "T. MUNICIPAL",
        //                DT.FormatearPMostrar(D_MUNICIPAL.ToString(), 3));


        //            DTRIBUTOS.Rows.Add(DT.FormatearPMostrar(D_NETO_TOTAL.ToString(), 3),
        //                (int)AFIP_ELECTRONICA.TIPO_TRIBUTO.IMPUESTOS_PROVINCIALES,
        //                "T. PROVINCIAL",
        //                DT.FormatearPMostrar(D_PROVINCIAL.ToString(), 3));


        //            DTRIBUTOS.Rows.Add(DT.FormatearPMostrar(D_NETO_TOTAL.ToString(), 3),
        //                (int)AFIP_ELECTRONICA.TIPO_TRIBUTO.IMPUESTOS_NACIONALES,
        //                "T. NACIONAL",
        //                DT.FormatearPMostrar(D_NACIONAL.ToString(), 3));

        //            DTRIBUTOS.Rows.Add(DT.FormatearPMostrar(D_NETO_TOTAL.ToString(), 3),
        //                (int)AFIP_ELECTRONICA.TIPO_TRIBUTO.IMPUESTOS_INTERNOS,
        //                "INTERNOS",
        //                DT.FormatearPMostrar(D_INTERNO.ToString(), 3));

        //            D_TOTAL = D_NETO_TOTAL + D_IVA_TOTAL + D_MUNICIPAL + D_PROVINCIAL + D_NACIONAL + D_INTERNO + D_RECARGO - D_DESCUENTO;

        //            AFIP_ELECTRONICA.ERROR = null;

        //            if(Convert.ToDecimal(CLIENTE_DOCUMENTO_NUMERO) == 0)
        //            {
        //                CLIENTE_RAZON_SOCIAL = "CONSUMIDOR FINAL";
        //                CLIENTE_CONDICION = CBD.CLIENTE_CONDICION_SISTEMA.CONSUMIDOR_FINAL.ToString();
        //                CLIENTE_DOCUMENTO_TIPO_SISTEMA = CBD.CLIENTE_DOCUMENTO_TIPO_SISTEMA.NULO;
        //            }

        //            SP SP = new SP();

        //            int IDFACTURA = AFIP_ELECTRONICA.SP_FACTURA_SET(
        //                IDCAJA,
        //                IDVENTA,
        //                CGLOBAL.WS_EMISOR_CUIT,
        //                CGLOBAL.WS_EMISOR_RAZON_SOCIAL,
        //                CGLOBAL.WS_EMISOR_DOMICILIO,
        //                CGLOBAL.WS_EMISOR_CONDICION.ToString(),
        //                CGLOBAL.WS_EMISOR_CUIT,
        //                "",
        //                CGLOBAL.WS_EMISOR_INICIO_ACTIVIDAD,
        //                ((int)AMBIENTE).ToString(),
        //                ((int)AFIP_ELECTRONICA.WS_SERVICIO.wsfe).ToString(),
        //                CGLOBAL.WS_PV,
        //                VENTA_COMPROBANTE_AFIP,
        //                VENTA_CONCEPTO,
        //                CLIENTE_RAZON_SOCIAL,
        //                CLIENTE_CONDICION,
        //                CLIENTE_DOMICILIO,
        //                ((int)CLIENTE_DOCUMENTO_TIPO_SISTEMA).ToString(),
        //                CLIENTE_DOCUMENTO_NUMERO,
        //                F_EMISION.ToString("yyyy/MM/dd"),
        //                F_VENCIMIENTO.ToString("yyyy/MM/dd"),
        //                F_DESDE.ToString("yyyy/MM/dd"),
        //                F_HASTA.ToString("yyyy/MM/dd"),
        //                AFIP_ELECTRONICA.PESOS_ARGENTINOS,
        //                VENTA_FORMA_PAGO.ToString(),
        //                DT.FormatearPMostrar(D_NETO_TOTAL.ToString(), 3),
        //                DT.FormatearPMostrar(D_IVA_TOTAL.ToString(), 3),
        //                DT.FormatearPMostrar(D_MUNICIPAL_PORC.ToString(), 3),
        //                DT.FormatearPMostrar(D_MUNICIPAL.ToString(), 3),
        //                DT.FormatearPMostrar(D_PROVINCIAL_PORC.ToString(), 3),
        //                DT.FormatearPMostrar(D_PROVINCIAL.ToString(), 3),
        //                DT.FormatearPMostrar(D_NACIONAL_PORC.ToString(), 3),
        //                DT.FormatearPMostrar(D_NACIONAL.ToString(), 3),
        //                DT.FormatearPMostrar(D_INTERNO_PORC.ToString(), 3),
        //                DT.FormatearPMostrar(D_INTERNO.ToString(), 3),
        //                DT.FormatearPMostrar(D_DESCUENTO.ToString(), 3),
        //                DT.FormatearPMostrar(D_RECARGO.ToString(), 3),
        //                DT.FormatearPMostrar(D_TOTAL.ToString(), 3),
        //                VENTA_OBSERVACION
        //                );

        //            if (IDFACTURA == 0)
        //                return "ERROR AL GUARDAR FACTURA EN  BD";

        //            for (int i = 0; i < DTPRODUCTOS.Rows.Count; i++)
        //            {
        //                if (!(AFIP_ELECTRONICA.SP_FACTURA_LINEA_SET(CGLOBAL.MAQUINA_LOCAL_ID,
        //                        IDFACTURA.ToString(),
        //                        DTPRODUCTOS.Rows[i]["IDPRODUCTO"].ToString(),
        //                        DTPRODUCTOS.Rows[i]["CODIGO"].ToString(),
        //                        DTPRODUCTOS.Rows[i]["UNIDAD"].ToString(),
        //                        DTPRODUCTOS.Rows[i]["NETO_TOTAL"].ToString(),
        //                        DTPRODUCTOS.Rows[i]["CANTIDAD"].ToString(),
        //                        AFIP_ELECTRONICA.IVA_ALICUOTA_ID_GET(Convert.ToDecimal(DTPRODUCTOS.Rows[i]["IVA_PORC"].ToString())),
        //                        DTPRODUCTOS.Rows[i]["IVA_PORC"].ToString(),
        //                        DTPRODUCTOS.Rows[i]["IVA_TOTAL"].ToString(),
        //                        DTPRODUCTOS.Rows[i]["IMPORTE"].ToString())))
        //            }

        //            SP.Grabar();

        //            DataTable DTRETORNO = AFIP_ELECTRONICA.FACTURA_EMITIR(AMBIENTE,
        //                CGLOBAL.WS_EMISOR_CUIT,
        //                AFIP_ELECTRONICA.COMPROBANTE_TIPO_GET(VENTA_COMPROBANTE_SISTEMA),
        //                VENTA_CONCEPTO,
        //                F_EMISION,
        //                F_DESDE,
        //                F_HASTA,
        //                F_VENCIMIENTO,
        //                DT.FormatearPMostrar(D_DESCUENTO.ToString(), 3),
        //                DT.FormatearPMostrar(D_RECARGO.ToString(), 3),
        //                AFIP_ELECTRONICA.TIPO_DOCUMENTO_CLIENTE_GET(CLIENTE_DOCUMENTO_TIPO_SISTEMA),
        //                CLIENTE_DOCUMENTO_NUMERO,
        //                DTIVA,
        //                DTRIBUTOS);

        //            if (DTRETORNO == null || DTRETORNO.Rows.Count > 0)
        //            {
        //                return AFIP_ELECTRONICA.ERROR;
        //            }

        //            string CAE = DTRETORNO.Rows[0]["CAE"].ToString();
        //            string CAE_VENCIMIENTO = DTRETORNO.Rows[0]["VENCIMIENTO"].ToString();
        //            string CAE_DESDE = DTRETORNO.Rows[0]["DESDE"].ToString();
        //        }

        //        private void btn_volver_click(object sender,EventArgs e)
        //        {

        //        }
    }
}
