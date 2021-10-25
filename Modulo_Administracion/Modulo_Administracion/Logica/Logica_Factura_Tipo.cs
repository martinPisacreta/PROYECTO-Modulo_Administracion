using Modulo_Administracion.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modulo_Administracion.Clases;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Modulo_Administracion.Logica
{
    public class Logica_Factura_Tipo
    {

       

        public Int32 ult_nro_factura_no_usado_en_tipo_factura(decimal cod_tipo_factura)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            int _ult_nro_factura_no_usado_en_tipo_factura = 0;
            try
            {


                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("ult_nro_factura_no_usado_en_tipo_factura", conn);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@cod_tipo_factura", cod_tipo_factura);

                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dataSet);

                    foreach (DataRow dr in dataSet.Tables[0].Rows)
                    {
                        _ult_nro_factura_no_usado_en_tipo_factura = Convert.ToInt32(dr[0].ToString());
                    }


                    return _ult_nro_factura_no_usado_en_tipo_factura;

                }
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
        }
    }
}
