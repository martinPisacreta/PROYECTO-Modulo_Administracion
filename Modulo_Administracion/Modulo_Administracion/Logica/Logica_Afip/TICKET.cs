
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Modulo_Administracion.Capas.Logica_Afip
{
    public class TICKET
    {

        public string TOKEN { get; set; }
        public string SIGN { get; set; }
        public DateTime EXPIRATION_TIME { get; set; }
        public DateTime GENERATION_TIME { get; set; }
        public string XDOC_REQUEST { get; set; }

        public string XDOC_RESPONSE { get; set; }


        public bool INSERT_TICKET(string TOKEN, string SIGN, DateTime EXPIRATION_TIME, DateTime GENERATION_TIME, string XDOC_REQUEST, string XDOC_RESPONSE, string AMBIENTE) //1 HOMOLOGACION , 2 PRODUCCION
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
            {
                conn.Open();
               
                    try
                    {

                        DataSet dataSet = new DataSet("TimeRanges");
                        SqlParameter param = null;
                        bool bandera = false;
                        SqlCommand command = new SqlCommand("insert_ticket", conn);

                        param = new SqlParameter();
                        param.DbType = DbType.String;
                        param.ParameterName = "@TOKEN";
                        param.Value = TOKEN;
                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.DbType = DbType.String;
                        param.ParameterName = "@SIGN";
                        param.Value = SIGN;
                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.DbType = DbType.DateTime;
                        param.ParameterName = "@EXPIRATION_TIME";
                        param.Value = EXPIRATION_TIME;
                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.DbType = DbType.DateTime;
                        param.ParameterName = "@GENERATION_TIME";
                        param.Value = GENERATION_TIME;
                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.DbType = DbType.String;
                        param.ParameterName = "@XDOC_REQUEST";
                        param.Value = XDOC_REQUEST;
                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.DbType = DbType.String;
                        param.ParameterName = "@XDOC_RESPONSE";
                        param.Value = XDOC_RESPONSE;
                        command.Parameters.Add(param);

                        param = new SqlParameter();
                        param.DbType = DbType.String;
                        param.ParameterName = "@AMBIENTE";
                        param.Value = AMBIENTE;
                        command.Parameters.Add(param);


                        command.CommandTimeout = 0;

                        command.CommandType = CommandType.StoredProcedure;

                        command.ExecuteNonQuery();

                        bandera = true;
                        return bandera;

                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        throw ex;
                    }

                    
                

            }
        }

        public TICKET BUSCAR_TICKET(AFIP_ELECTRONICA.WS_AMBIENTE AMBIENTE) //1 HOMOLOGACION , 2 PRODUCCION
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
            {
                conn.Open();
               

                try
                {

                    DataSet dataSet = new DataSet("TimeRanges");
                    SqlDataReader reader = null;
                    SqlParameter param = null;
                    TICKET TICKET = null;

                    SqlCommand command = new SqlCommand("buscar_ticket", conn);

                    param = new SqlParameter();
                    param.DbType = DbType.String;
                    param.ParameterName = "@AMBIENTE";
                    param.Value = AMBIENTE;
                    command.Parameters.Add(param);
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        TICKET = new TICKET();
                        TICKET.TOKEN = reader.GetString(1);
                        TICKET.SIGN = reader.GetString(2);
                        TICKET.EXPIRATION_TIME = reader.GetDateTime(3);
                        TICKET.GENERATION_TIME = reader.GetDateTime(4);
                        TICKET.XDOC_REQUEST = reader.GetString(5);
                        TICKET.XDOC_RESPONSE = reader.GetString(6);
                    }


                    return TICKET;

                }
                catch (Exception ex)
                {
                    conn.Close();
                    throw ex;
                }


                

            }
        }


  
    }
}
