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
    public class Logica_Proveedor_Datos
    {

        public bool alta_dato(proveedor_datos dato,int id_proveedor, Modulo_AdministracionContext db)
        {
           
            bool bandera = false;
            try
            {

                proveedor_datos proveedor_datos_a_insertar = new proveedor_datos();
                proveedor_datos_a_insertar.id_proveedor = id_proveedor;
                proveedor_datos_a_insertar.cod_tipo_dato = dato.cod_tipo_dato;
                proveedor_datos_a_insertar.txt_dato_proveedor = dato.txt_dato_proveedor;
                proveedor_datos_a_insertar.sn_activo = -1;
                proveedor_datos_a_insertar.fec_ult_modif = DateTime.Now;
                proveedor_datos_a_insertar.accion = "ALTA";
                db.proveedor_datos.Add(proveedor_datos_a_insertar);
                db.SaveChanges();

                bandera = true;

                return bandera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public bool modificar_dato(proveedor_datos dato, Modulo_AdministracionContext db)
        {

            bool bandera = false;
            try
            {
                if (dato.sn_activo == 0)
                {
                    if (eliminar_dato(dato, db) == false)
                    {
                        throw new Exception("Error al eliminar un dato del proveedor");
                    }
                }
                else
                {
                    proveedor_datos proveedor_datos_db = db.proveedor_datos.FirstOrDefault(c => c.id_proveedor == dato.id_proveedor && c.cod_tipo_dato == dato.cod_tipo_dato);
                    if (proveedor_datos_db == null)
                    {
                        if (alta_dato(dato, dato.id_proveedor, db) == false)
                        {
                            throw new Exception("Error al dar de alta un dato del proveedor");
                        }
                    }
                    else
                    {
                        proveedor_datos_db.id_proveedor = dato.id_proveedor;
                        proveedor_datos_db.cod_tipo_dato = dato.cod_tipo_dato;
                        proveedor_datos_db.txt_dato_proveedor = dato.txt_dato_proveedor;
                        proveedor_datos_db.fec_ult_modif = DateTime.Now;
                        proveedor_datos_db.sn_activo = dato.sn_activo;
                        proveedor_datos_db.accion = "MODIFICACION";

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

        public bool eliminar_dato(proveedor_datos dato, Modulo_AdministracionContext db)
        {

            bool bandera = false;
            try
            {

                proveedor_datos proveedor_datos_db = db.proveedor_datos.FirstOrDefault(c => c.id_proveedor == dato.id_proveedor && c.cod_tipo_dato == dato.cod_tipo_dato);
                db.proveedor_datos.Remove(proveedor_datos_db);
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

        public List<proveedor_datos> buscar_datos_por_id_proveedor(int id_proveedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {
      
                List<proveedor_datos> datos = (from t in db.proveedor_datos
                                                   where t.id_proveedor == id_proveedor && t.sn_activo == -1 
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

        public proveedor_datos buscar_dato(int id_proveedor, decimal cod_tipo_dato)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                proveedor_datos dato = db.proveedor_datos.FirstOrDefault(t => t.id_proveedor == id_proveedor && t.cod_tipo_dato == cod_tipo_dato);


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
        public bool dar_de_baja_proveedor_datos_por_proveedor(int id_proveedor, Modulo_AdministracionContext db) 
        {
            bool bandera = false;
            try
            {

                List<proveedor_datos> lista_proveedor_datos = (from pt in db.proveedor_datos
                                                           where pt.id_proveedor == id_proveedor
                                                           select pt).ToList();
                foreach (proveedor_datos pt in lista_proveedor_datos)
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
