using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

using Modulo_Administracion.Clases;
using System.Data.Entity;

namespace Modulo_Administracion.Logica
{
    public class Logica_Cliente_Datos
    {

        public bool alta_dato(cliente_datos dato,int id_cliente, Modulo_AdministracionContext db)
        {
         
            bool bandera = false;
            try
            {

                cliente_datos cliente_datos_a_insertar = new cliente_datos();
                cliente_datos_a_insertar.id_cliente = id_cliente;
                cliente_datos_a_insertar.cod_tipo_dato = dato.cod_tipo_dato;
                cliente_datos_a_insertar.txt_dato_cliente = dato.txt_dato_cliente;
                cliente_datos_a_insertar.sn_activo = -1;
                cliente_datos_a_insertar.fec_ult_modif = DateTime.Now;
                cliente_datos_a_insertar.accion = "ALTA";
                db.cliente_datos.Add(cliente_datos_a_insertar);
                db.SaveChanges();

                bandera = true;

                return bandera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool modificar_dato(cliente_datos dato, Modulo_AdministracionContext db)
        {
           
            bool bandera = false;
            try
            {
                if (dato.sn_activo == 0)
                {
                    if (eliminar_dato(dato, db) == false)
                    {
                        throw new Exception("Error al eliminar un dato del cliente");
                    }
                }
                else
                {
                    cliente_datos cliente_datos_db = db.cliente_datos.FirstOrDefault(c => c.id_cliente == dato.id_cliente && c.cod_tipo_dato == dato.cod_tipo_dato);
                    if (cliente_datos_db == null)
                    {
                        if (alta_dato(dato,dato.id_cliente, db) == false)
                        {
                            throw new Exception("Error al dar de alta un dato del cliente");
                        }
                    }
                    else
                    {
                        cliente_datos_db.id_cliente = dato.id_cliente;
                        cliente_datos_db.cod_tipo_dato = dato.cod_tipo_dato;
                        cliente_datos_db.txt_dato_cliente = dato.txt_dato_cliente;
                        cliente_datos_db.fec_ult_modif = DateTime.Now;
                        cliente_datos_db.sn_activo = dato.sn_activo;
                        cliente_datos_db.accion = "MODIFICACION";

                        db.SaveChanges();
                    }
                    
                }

                bandera = true;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool eliminar_dato(cliente_datos dato, Modulo_AdministracionContext db)
        {
            
            bool bandera = false;
            try
            {

                cliente_datos cliente_datos_db = db.cliente_datos.FirstOrDefault(c => c.id_cliente == dato.id_cliente && c.cod_tipo_dato == dato.cod_tipo_dato);
                db.cliente_datos.Remove(cliente_datos_db);
                db.SaveChanges();


                bandera = true;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }



        public DataSet buscar_tipos_datos()
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;

            try
            {
                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("buscar_tipo_dato", conn);
                    command.CommandTimeout = 0;


                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    adapter.Fill(dataSet);
                }
                return dataSet;
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

        public List<cliente_datos> buscar_datos_por_id_cliente(int id_cliente)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {
      
                List<cliente_datos> datos = (from t in db.cliente_datos
                                                   where t.id_cliente == id_cliente && t.sn_activo == -1 
                                                   select t).ToList();


                return datos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db = null;
            }

           
        }

        public cliente_datos buscar_dato(int id_cliente, decimal cod_tipo_dato)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                cliente_datos dato = db.cliente_datos.FirstOrDefault(t => t.id_cliente == id_cliente && t.cod_tipo_dato == cod_tipo_dato);


                return dato;

            }
            catch (Exception ex)
            {
                // return new List<Empresa>();
                throw ex;
            }
            finally
            {
                db = null;
            }
        }
        public bool dar_de_baja_cliente_datos_por_cliente(int id_cliente, Modulo_AdministracionContext db) 
        {
            bool bandera = false;
            try
            {

                List<cliente_datos> lista_cliente_datos = (from pt in db.cliente_datos
                                                           where pt.id_cliente == id_cliente
                                                           select pt).ToList();
                foreach (cliente_datos pt in lista_cliente_datos)
                {

                    pt.sn_activo = 0;
                    pt.accion = "ELIMINACION";
                    pt.fec_ult_modif = DateTime.Now;
                  


                }

                db.SaveChanges();
                bandera = true;
                return bandera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
