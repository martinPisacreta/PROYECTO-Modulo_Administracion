using System;
using System.IO;
using System.Security;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Modulo_Administracion.Capas.Logica_Afip
{
    public class AFIP_ELECTRONICA
    {

        private static UInt32 _globalId = 0;
        private static XmlDocument XmlLoginTicketRequest;
        private static XmlDocument XmlLoginTicketResponse;

        public class LOGIN
        {
            public DateTime GENERATION_TIME { get; set; }
            public DateTime EXPIRATION_TIME { get; set; }
            public XDocument XDOC_REQUEST { get; set; }
            public XDocument XDOC_RESPONSE { get; set; }
            public string TOKEN { get; set; }
            public string SIGN { get; set; }
        }



        //ESTO VA ACA POQUE NO PUEDO PONER EN UN ENUM UN STRING 
        public static string PESOS_ARGENTINOS = "PES";
        public enum WS_AMBIENTE
        {
            HOMOLOGACION = 1,
            PRODUCCION = 2
        }


        public enum TIPO_TRIBUTO
        {
            IMPUESTOS_NACIONALES = 1,
            IMPUESTOS_PROVINCIALES = 2,
            IMPUESTOS_MUNICIPALES = 3,
            IMPUESTOS_INTERNOS = 4,
            OTRO = 99,
            PERCEPCIÓN_DE_IVA = 6,
            PERCEPCIÓN_DE_IIBB = 7,
            PERCEPCIONES_POR_IMPUESTOS_MUNICIPALES = 8,
            OTRAS_PERCEPCIONES = 9,
            PERCEPCIÓN_DE_IVA_A_NO_CATEGORIZADO = 13,
            IIBB = 5

        }
        public enum WS_SERVICIO
        {
            wsfe = 1,
            ws_sr_constancia_inscripcion = 2
        }

        public enum COMPROBANTES_TIPO
        {
            NO_DEFINIDO = -1,
            FACTURA_A = 1,
            NOTA_DE_DEBITO_A = 2,
            NOTA_DE_CREDITO_A = 3,
            FACTURA_B = 6,
            NOTA_DE_DEBITO_B = 7,
            NOTA_DE_CREDITO_B = 8,
            RECIBOS = 4,
            NOTAS_DE_VENTA_AL_CONTADO = 5,
            RECIBOS_B = 9,
            NOTAS_DE_VENTA_AL_CONTADO_B = 10,
            LIQUIDACION = 63,
            LIQUIDACION_B = 64,
            CBTES_A_DEL_ANEXO_I_AP_A = 34,
            CBTES_B_DEL_ANEXO_I_AP_A = 35,
            OTROS_COMPROBANTES_A = 39,
            OTROS_COMPROBANTES_B = 40,
            CTA_VTA_LIQ_PROD = 60,
            CTA_VTA_LIQ_PROD_B = 61,
            FACTURA_C = 11,
            NOTA_DE_DEBITO_C = 12,
            NOTA_DE_CREDITO_C = 13,
            RECIBO_C = 15,
            COMPROBANTES_DE_COMPRA_DE_BIENES_USADOS_A_CONSUMIDOR_FINAL = 49,
            FACTURA_M = 51,
            NOTA_DE_DEBITO_M = 52,
            NOTA_DE_CREDITO_M = 53,
            RECIBO_M = 54,
            FACTURA_DE_CREDITO_ELECT_MYPYMES = 54,
            NOTA_DE_DEBITO_ELECT_MYPYMES = 202,
            NOTA_DE_CREDITO_ELECT_MYPYMES = 203




        }

        public enum VENTA_CONCEPTO
        {
            PRODUCTOS = 1,
            SERVICIOS = 2,
            PRODUCTOS_SERVICIOS = 3

        }

        public enum CLIENTE_DOCUMENTO_TIPO
        {
            CUIT = 80,
            CUIL = 86,
            CDI = 87,
            LE = 89,
            LC = 90,
            CI_EXTRANJERA = 91,
            EN_TRAMITE = 92,
            ACTA_NACIMIENTO = 93,
            CI_BS_AS_RNP = 95,
            DNI = 96,
            PASAPORTE = 94,
            CI_POLICIA_FEDERAL = 0,
            CI_BSAS = 1,
            CI_CATAMARCA = 2,
            CI_CORDOBA = 3,
            CI_CORRIENTES = 4,
            CI_ENTRE_RIOS = 5,
            CI_JUJUY = 6,
            CI_MENDOZA = 7,
            CI_LA_RIOJA = 8,
            CI_SALTA = 9,
            OTRO = 99

        }

        public enum CLIENTE_CONDICION_TIPO
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

        public enum IVA_ALICUOTA_TIPO
        {
            CERO = 3,
            DIEZ_COMA_CINCO = 4,
            VENTIUNO = 5,
            VEINTISIETE = 6,
            CINCO = 8,
            DOS_COMA_CINCO = 9
        }

        public static int IVA_ALICUOTA_ID_GET(decimal iva_porcentaje)
        {
            int IVA_ALICUOTA_ID = 0;
            if (iva_porcentaje == 0.00M)
                IVA_ALICUOTA_ID = (int)IVA_ALICUOTA_TIPO.CERO;

            if (iva_porcentaje == 10.50M)
                IVA_ALICUOTA_ID = (int)IVA_ALICUOTA_TIPO.DIEZ_COMA_CINCO;

            if (iva_porcentaje == 21M)
                IVA_ALICUOTA_ID = (int)IVA_ALICUOTA_TIPO.VENTIUNO;

            if (iva_porcentaje == 27M)
                IVA_ALICUOTA_ID = (int)IVA_ALICUOTA_TIPO.VEINTISIETE;

            if (iva_porcentaje == 5M)
                IVA_ALICUOTA_ID = (int)IVA_ALICUOTA_TIPO.CINCO;

            if (iva_porcentaje == 2.50M)
                IVA_ALICUOTA_ID = (int)IVA_ALICUOTA_TIPO.DOS_COMA_CINCO;

            return IVA_ALICUOTA_ID;
        }




        public static AFIP_ELECTRONICA.COMPROBANTES_TIPO COMPROBANTE_TIPO_GET(CBD.VARIABLES COMPROBANTE_TIPO)
        {
            AFIP_ELECTRONICA.COMPROBANTES_TIPO valor = 0;
            switch (COMPROBANTE_TIPO)
            {
                case CBD.VARIABLES.VENTA_ONLINE_A:
                    valor = AFIP_ELECTRONICA.COMPROBANTES_TIPO.FACTURA_A;
                    break;

                case CBD.VARIABLES.VENTA_ONLINE_B:
                    valor = AFIP_ELECTRONICA.COMPROBANTES_TIPO.FACTURA_B;
                    break;


                case CBD.VARIABLES.VENTA_ONLINE_C:
                    valor = AFIP_ELECTRONICA.COMPROBANTES_TIPO.FACTURA_C;
                    break;

            }

            return valor;
        }


        public static bool CERTIFICADO_EXISTE(string CERTIFICADO_PATH)
        {
            try
            {
                bool existe = File.Exists(CERTIFICADO_PATH);
                return existe;
            }
            catch
            {
                return false;
            }
        }


        public static WS_SR_CONSTANCIA_INSCRIPCION.personaReturn GET_PERSON(LOGIN _LOGIN, long WS_EMISOR_CUIT, long DOC_CLIENTE)
        {
            try
            {
                WS_SR_CONSTANCIA_INSCRIPCION.PersonaServiceA5 servicio = new WS_SR_CONSTANCIA_INSCRIPCION.PersonaServiceA5();
                WS_SR_CONSTANCIA_INSCRIPCION.personaReturn PERSONA = new WS_SR_CONSTANCIA_INSCRIPCION.personaReturn();
                PERSONA = servicio.getPersona(_LOGIN.TOKEN, _LOGIN.SIGN, WS_EMISOR_CUIT, DOC_CLIENTE);



                return PERSONA;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static LOGIN GET_LOGIN(WS_AMBIENTE AMBIENTE, WS_SERVICIO SERVICIO, string CERTIFICADO_PATH, string URL_LOGIN)
        {
            try
            {
                string cmsFirmadoBase64;
                string loginTicketResponse;
                XmlNode uniqueIdNode;
                XmlNode generationTimeNode;
                XmlNode ExpirationTimeNode;
                XmlNode ServiceNode;
                TICKET TICKET = new TICKET();
                TICKET _TICKET_METODOS = new TICKET();
                LOGIN _LOGIN = new LOGIN();


                TICKET = _TICKET_METODOS.BUSCAR_TICKET(AMBIENTE);
                if (TICKET != null)
                {
                    _LOGIN.TOKEN = TICKET.TOKEN;
                    _LOGIN.SIGN = TICKET.SIGN;
                    _LOGIN.EXPIRATION_TIME = TICKET.EXPIRATION_TIME;
                    _LOGIN.GENERATION_TIME = TICKET.GENERATION_TIME;
                    _LOGIN.XDOC_REQUEST = XDocument.Parse(TICKET.XDOC_REQUEST);
                    _LOGIN.XDOC_RESPONSE = XDocument.Parse(TICKET.XDOC_RESPONSE);
                }
                else
                {
                    _globalId += 1;

                    // Preparo el XML Request
                    XmlLoginTicketRequest = new XmlDocument();
                    XMLLoader.loadTemplate(XmlLoginTicketRequest, "LoginTemplate");

                    uniqueIdNode = XmlLoginTicketRequest.SelectSingleNode("//uniqueId");
                    generationTimeNode = XmlLoginTicketRequest.SelectSingleNode("//generationTime");
                    ExpirationTimeNode = XmlLoginTicketRequest.SelectSingleNode("//expirationTime");
                    ServiceNode = XmlLoginTicketRequest.SelectSingleNode("//service");
                    generationTimeNode.InnerText = DateTime.Now.AddMinutes(-10).ToString("s");
                    ExpirationTimeNode.InnerText = DateTime.Now.AddMinutes(+10).ToString("s");
                    uniqueIdNode.InnerText = Convert.ToString(_globalId);
                    ServiceNode.InnerText = SERVICIO.ToString();

                    // Obtenemos el Cert
                    X509Certificate2 certificado = new X509Certificate2();
                    SecureString clave = new SecureString();
                    foreach (char character in CGLOBAL.WS_CERTIFICADO_CLAVE)
                        clave.AppendChar(character);
                    clave.MakeReadOnly();

                    if (clave.IsReadOnly())
                        certificado.Import(File.ReadAllBytes(CERTIFICADO_PATH), clave, X509KeyStorageFlags.PersistKeySet);
                    else
                        certificado.Import(File.ReadAllBytes(CERTIFICADO_PATH));

                    byte[] msgBytes = Encoding.UTF8.GetBytes(XmlLoginTicketRequest.OuterXml);

                    // Firmamos
                    ContentInfo infoContenido = new ContentInfo(msgBytes);
                    SignedCms cmsFirmado = new SignedCms(infoContenido);

                    CmsSigner cmsFirmante = new CmsSigner(certificado);
                    cmsFirmante.IncludeOption = X509IncludeOption.EndCertOnly;

                    cmsFirmado.ComputeSignature(cmsFirmante);

                    cmsFirmadoBase64 = Convert.ToBase64String(cmsFirmado.Encode());

                    // Hago el login
                    Modulo_Administracion.WSAA.LoginCMSService servicio = new WSAA.LoginCMSService();
                    servicio.Url = URL_LOGIN;

                    loginTicketResponse = servicio.loginCms(cmsFirmadoBase64);

                    // Analizamos la respuesta
                    XmlLoginTicketResponse = new XmlDocument();
                    XmlLoginTicketResponse.LoadXml(loginTicketResponse);

                    _LOGIN = new LOGIN();
                    _LOGIN.TOKEN = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText;
                    _LOGIN.SIGN = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText;

                    var exStr = XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText;
                    var genStr = XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText;
                    _LOGIN.EXPIRATION_TIME = DateTime.Parse(exStr);
                    _LOGIN.GENERATION_TIME = DateTime.Parse(genStr);

                    _LOGIN.XDOC_REQUEST = XDocument.Parse(XmlLoginTicketRequest.OuterXml);
                    _LOGIN.XDOC_RESPONSE = XDocument.Parse(XmlLoginTicketResponse.OuterXml);

                    bool bandera = _TICKET_METODOS.INSERT_TICKET(_LOGIN.TOKEN, _LOGIN.SIGN, _LOGIN.EXPIRATION_TIME, _LOGIN.GENERATION_TIME, XmlLoginTicketRequest.OuterXml.ToString(), XmlLoginTicketResponse.OuterXml.ToString(), AMBIENTE.ToString());
                    if (bandera == false)
                    {
                        throw new Exception("Error al generar el ticket");
                    }


                }






                return _LOGIN;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static DataTable FACTURA_EMITIR(WS_AMBIENTE AMBIENTE,
        //    string CUIT_EMISOR, AFIP_ELECTRONICA.COMPROBANTES_TIPO TIPO_COMPROBANTE,
        //    AFIP_ELECTRONICA.VENTA_CONCEPTO VENTA_CONCEPTO,
        //    DateTime FECHA_FACTURA,
        //    DateTime FECHA_DESDE, DateTime FECHA_HASTA, DateTime FECHA_VENCE,
        //    string IMPORTE_DESCUENTO, string IMPORTE_RECARGO,
        //    AFIP_ELECTRONICA.CLIENTE_DOCUMENTO_TIPO CLIENTE_TIPO_DOC,
        //    string CLIENTE_DOC, DataTable DTIVA, DataTable DTTRIBUTOS)
        //{
        //    try
        //    {
        //        string CERTIFICADO_PATH = null;
        //        string URL_LOGIN = null;
        //        if (AMBIENTE == AFIP_ELECTRONICA.WS_AMBIENTE.HOMOLOGACION)
        //        {
        //            CERTIFICADO_PATH = CGLOBAL.WS_CERTIFICADO_PATH_HOMO;
        //            URL_LOGIN = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";
        //        }
        //        else
        //        {
        //            CERTIFICADO_PATH = CGLOBAL.WS_CERTIFICADO_PATH;
        //            URL_LOGIN = "https://wsaa.afip.gov.ar/ws/services/LoginCms";
        //        }


        //        if (AMBIENTE == WS_AMBIENTE.HOMOLOGACION)
        //        {
        //            if (!CERTIFICADO_EXISTE(CGLOBAL.WS_CERTIFICADO_PATH_HOMO))
        //            {
        //                throw new Exception ("CERTIFICADO NO EXISTE\n" + CGLOBAL.WS_CERTIFICADO_PATH_HOMO + "\n");

        //            }
        //        }

        //        if (AMBIENTE == WS_AMBIENTE.PRODUCCION)
        //        {
        //            if (!CERTIFICADO_EXISTE(CGLOBAL.WS_CERTIFICADO_PATH))
        //            {
        //                throw new Exception("CERTIFICADO NO EXISTE\n" + CGLOBAL.WS_CERTIFICADO_PATH + "\n");

        //            }
        //        }


        //        LOGIN LOGIN = GET_LOGIN(AMBIENTE, WS_SERVICIO.wsfe, CERTIFICADO_PATH, URL_LOGIN);

        //        if (LOGIN == null)
        //        {
        //            throw new Exception("NO SE PUEDE OBTENER EL LOGIN\n");

        //        }

        //        string TOKEN = LOGIN.TOKEN;
        //        string SIGN = LOGIN.SIGN;

        //        double D_DESCUENTO = Convert.ToDouble(IMPORTE_DESCUENTO);
        //        double D_RECARGO = Convert.ToDouble(IMPORTE_RECARGO);
        //        double D_BRUTO = 0;

        //        for (int i = 0; i < DTIVA.Rows.Count; i++)
        //        {
        //            //NETO
        //            D_BRUTO += Convert.ToDouble(DTIVA.Rows[i]["IMPORTE_NETO"].ToString());

        //            //IVA
        //            D_BRUTO += Convert.ToDouble(DTIVA.Rows[i]["IVA_IMPORTE"].ToString());
        //        }


        //        for (int i = 0; i < DTTRIBUTOS.Rows.Count; i++)
        //        {
        //            //IMPUESTSOS
        //            D_BRUTO += Convert.ToDouble(DTIVA.Rows[i]["TRIBUTO_IMPORTE"].ToString());
        //        }

        //        if (AMBIENTE == WS_AMBIENTE.PRODUCCION)
        //        {
        //            FEAuthRequest authRequest = new FEAuthRequest();
        //            authRequest.Cuit = Convert.ToInt64(CUIT_EMISOR);
        //            authRequest.Sign = SIGN;
        //            authRequest.Token = TOKEN;

        //            Service service = new Service();
        //            service.Url = "https://servicio1.afip.gov.ar/wsfev1/service.asmx?WSDL";

        //            // Obtener el Cert
        //            X509Certificate2 CERTIFICADO = new X509Certificate2();

        //            SecureString clave = new SecureString();
        //            foreach (char character in CGLOBAL.WS_CERTIFICADO_CLAVE)
        //                clave.AppendChar(character);
        //            clave.MakeReadOnly();

        //            if (clave.IsReadOnly())
        //            {
        //                CERTIFICADO.Import(File.ReadAllBytes(CERTIFICADO_PATH), clave, X509KeyStorageFlags.PersistKeySet);
        //            }
        //            else
        //            {
        //                CERTIFICADO.Import(File.ReadAllBytes(CERTIFICADO_PATH));
        //            }

        //            service.ClientCertificates.Add(CERTIFICADO);

        //            FECAERequest req = new FECAERequest();
        //            FECAECabRequest cab = new FECAECabRequest();
        //            FECAEDetRequest det = new FECAEDetRequest();

        //            cab.CantReg = 1;
        //            cab.PtoVta = Convert.ToInt32(CGLOBAL.WS_PV);
        //            cab.CbteTipo = (int)TIPO_COMPROBANTE;
        //            req.FeCabReq = cab;

        //            var withBlock = det;
        //            withBlock.Concepto = (int)VENTA_CONCEPTO;
        //            withBlock.DocTipo = (int)CLIENTE_TIPO_DOC;
        //            if (string.IsNullOrEmpty(CLIENTE_DOC) || Convert.ToDecimal(CLIENTE_DOC) == 0)
        //            {
        //                withBlock.DocTipo = (int)CLIENTE_DOCUMENTO_TIPO.OTRO;
        //                CLIENTE_DOC = "0";
        //            }
        //            withBlock.DocNro = long.Parse(CLIENTE_DOC);

        //            FERecuperaLastCbteResponse lastRes =
        //                service.FECompUltimoAutorizado(authRequest, Convert.ToInt32(CGLOBAL.WS_PV), (int)TIPO_COMPROBANTE);
        //            int last = lastRes.CbteNro;

        //            withBlock.CbteDesde = last + 1;
        //            withBlock.CbteHasta = last + 1;

        //            withBlock.CbteFch = FECHA_FACTURA.ToString("yyyyMMdd");
        //            if (VENTA_CONCEPTO != AFIP_ELECTRONICA.VENTA_CONCEPTO.PRODUCTOS)
        //            {
        //                withBlock.FchServDesde = FECHA_DESDE.ToString("yyyyMMdd");
        //                withBlock.FchServHasta = FECHA_HASTA.ToString("yyyyMMdd");
        //                withBlock.FchVtoPago = FECHA_VENCE.ToString("yyyyMMdd");
        //            }


        //            withBlock.MonId = PESOS_ARGENTINOS.ToString();
        //            withBlock.MonCotiz = 1;

        //            if (TIPO_COMPROBANTE == COMPROBANTES_TIPO.FACTURA_C)
        //            {
        //                double D_TOTAL = Convert.ToDouble(D_BRUTO) + D_RECARGO - D_DESCUENTO;


        //                withBlock.ImpNeto = Math.Round(D_TOTAL, 2,MidpointRounding.AwayFromZero);
        //                withBlock.ImpIVA = 0;
        //                withBlock.ImpTotal = Math.Round(D_TOTAL, 2 , MidpointRounding.AwayFromZero);
        //                withBlock.ImpTotConc = 0;
        //                withBlock.ImpOpEx = 0;
        //                withBlock.ImpTrib = 0;
        //            }

        //            if (TIPO_COMPROBANTE == COMPROBANTES_TIPO.FACTURA_A || TIPO_COMPROBANTE == COMPROBANTES_TIPO.FACTURA_B)
        //            {
        //                double D_DESCUENTO_PORC = 0;
        //                double D_RECARGO_PORC = 0;

        //                if (D_DESCUENTO > 0)
        //                {
        //                    double D_TOTAL = Convert.ToDouble(D_BRUTO);
        //                    D_DESCUENTO_PORC = (D_DESCUENTO * 100) / D_TOTAL;
        //                }

        //                if (D_RECARGO > 0)
        //                {
        //                    double D_TOTAL = Convert.ToDouble(D_BRUTO);
        //                    D_RECARGO_PORC = (D_RECARGO * 100) / D_TOTAL;
        //                }

        //                double D_NETO_TOTAL = 0;
        //                double D_IVA_TOTAL = 0;

        //                if (DTIVA != null && DTIVA.Rows.Count > 0)
        //                {

        //                    AlicIva alicuota;
        //                    AlicIva[] IVA_ARREGLO = new AlicIva[DTIVA.Rows.Count];
        //                    double D_NETO = 0;
        //                    double D_IVA = 0;

        //                    for (int i = 0; i < DTIVA.Rows.Count; i++)
        //                    {
        //                        D_NETO = Convert.ToDouble(DTIVA.Rows[i]["IMPORTE_NETO"].ToString());
        //                        D_IVA = Convert.ToDouble(DTIVA.Rows[i]["IVA_IMPORTE"].ToString());

        //                        if (D_DESCUENTO_PORC > 0)
        //                        {
        //                            D_NETO = D_NETO - ((D_DESCUENTO_PORC * D_NETO) / 100);
        //                            D_IVA = D_IVA - ((D_DESCUENTO_PORC * D_IVA) / 100);
        //                        }

        //                        if (D_RECARGO_PORC > 0)
        //                        {
        //                            D_NETO = D_NETO + ((D_DESCUENTO_PORC * D_NETO) / 100);
        //                            D_IVA = D_IVA + ((D_DESCUENTO_PORC * D_IVA) / 100);
        //                        }

        //                        alicuota = new AlicIva();
        //                        alicuota.Id = Convert.ToInt32(DTIVA.Rows[i]["IVA_ID"].ToString());
        //                        alicuota.BaseImp = Math.Round(D_NETO, 2 , MidpointRounding.AwayFromZero);
        //                        alicuota.Importe = Math.Round(D_IVA, 2 , MidpointRounding.AwayFromZero);
        //                        IVA_ARREGLO[i] = alicuota;
        //                        D_IVA_TOTAL += D_IVA;
        //                        D_NETO_TOTAL += D_NETO;
        //                    }
        //                    withBlock.Iva = IVA_ARREGLO;
        //                }

        //                double D_TRIBUTO_TOTAL = 0;
        //                if (DTTRIBUTOS != null && DTTRIBUTOS.Rows.Count > 0)
        //                {

        //                    Tributo tributo;
        //                    Tributo[] TRIBUTO_ARREGLO = new Tributo[DTTRIBUTOS.Rows.Count];
        //                    double D_TRIBUTO = 0;


        //                    for (int i = 0; i < DTTRIBUTOS.Rows.Count; i++)
        //                    {
        //                        D_TRIBUTO = Convert.ToDouble(DTTRIBUTOS.Rows[i]["TRIBUTO_IMPORTE"].ToString());

        //                        if (D_DESCUENTO_PORC > 0)
        //                        {
        //                            D_TRIBUTO = D_TRIBUTO - ((D_DESCUENTO_PORC * D_TRIBUTO) / 100);
        //                        }

        //                        if (D_RECARGO_PORC > 0)
        //                        {
        //                            D_TRIBUTO = D_TRIBUTO + ((D_DESCUENTO_PORC * D_TRIBUTO) / 100);
        //                        }

        //                        tributo = new Tributo();
        //                        tributo.Id = Convert.ToInt16(DTTRIBUTOS.Rows[i]["TRIBUTO_ID"].ToString());
        //                        tributo.BaseImp = Math.Round(D_NETO_TOTAL, 2 , MidpointRounding.AwayFromZero);
        //                        tributo.Desc = DTTRIBUTOS.Rows[i]["TRIBUTO_NOMBRE"].ToString();
        //                        tributo.Importe = Math.Round(D_TRIBUTO, 2 , MidpointRounding.AwayFromZero);
        //                        TRIBUTO_ARREGLO[i] = tributo;
        //                        D_TRIBUTO_TOTAL += D_TRIBUTO;

        //                    }
        //                    withBlock.Tributos = TRIBUTO_ARREGLO;
        //                }


        //                withBlock.ImpNeto = Math.Round(D_NETO_TOTAL, 2 , MidpointRounding.AwayFromZero);
        //                withBlock.ImpIVA = Math.Round(D_IVA_TOTAL, 2 , MidpointRounding.AwayFromZero);
        //                withBlock.ImpTotal = Math.Round(D_NETO_TOTAL + D_IVA_TOTAL + D_TRIBUTO_TOTAL, 2 , MidpointRounding.AwayFromZero);
        //                withBlock.ImpTotConc = 0;
        //                withBlock.ImpOpEx = 0;
        //                withBlock.ImpTrib = Math.Round(D_TRIBUTO_TOTAL, 2 , MidpointRounding.AwayFromZero);


        //            }

        //            req.FeDetReq = new[] { det };
        //            var r = service.FECAESolicitar(authRequest, req);
        //            DataTable DRETORNO = new DataTable();
        //            DRETORNO.Columns.Add("ESTADO");
        //            DRETORNO.Columns.Add("ESTADO_ESPERADO");
        //            DRETORNO.Columns.Add("CAE");
        //            DRETORNO.Columns.Add("VENCIMIENTO");
        //            DRETORNO.Columns.Add("FECHA_DESDE");
        //            DRETORNO.Columns.Add("FECHA_HASTA");
        //            DRETORNO.Columns.Add("OBSERVACION");
        //            DRETORNO.Columns.Add("ERRORES");
        //            DRETORNO.Columns.Add("EVENTOS");


        //            DataRow DROW = DRETORNO.NewRow();
        //            DROW["ESTADO"] = r.FeCabResp.Resultado;
        //            DROW["ESTADO_ESPERADO"] = r.FeDetResp[0].Resultado;
        //            DROW["CAE"] = r.FeDetResp[0].CAE;
        //            DROW["VENCIMIENTO"] = r.FeDetResp[0].CAEFchVto;
        //            DROW["FECHA_DESDE"] = r.FeDetResp[0].CbteDesde;
        //            DROW["FECHA_HASTA"] = r.FeDetResp[0].CbteHasta;

        //            if (r.FeDetResp[0].Observaciones != null)
        //            {
        //                foreach (var o in r.FeDetResp[0].Observaciones)
        //                    DROW["OBSERVACION"] += string.Format("Obs: {0} ({1})", o.Msg, o.Code) + " ";
        //            }
        //            else
        //                DROW["OBSERVACION"] = "";

        //            if (r.Errors != null)
        //            {
        //                foreach (var er in r.Errors)
        //                    DROW["ERRORES"] += string.Format("Er: {0}: {1}", er.Code, er.Msg) + " ";
        //            }
        //            else
        //                DROW["ERRORES"] = "";

        //            if (r.Events != null)
        //            {
        //                foreach (var ev in r.Events)
        //                    DROW["EVENTOS"] += string.Format("Ev: {0}: {1}", ev.Code, ev.Msg) + " ";
        //            }
        //            else
        //                DROW["EVENTOS"] = "";

        //            DRETORNO.Rows.Add(DROW);
        //            return DRETORNO;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}
        //}
        public class XMLLoader
        {
            public static void load(XmlDocument doc, string file)
            {
                doc.Load(Path.GetFullPath(Application.StartupPath + @"\" + file + ".xml"));
            }
            public static void loadTemplate(XmlDocument doc, string file)
            {
                load(doc, @"Templates\" + file);
            }
        }
    }
}




