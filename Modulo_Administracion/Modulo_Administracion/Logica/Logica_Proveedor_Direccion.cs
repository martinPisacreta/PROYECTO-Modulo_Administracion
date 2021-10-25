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
    public class Logica_Proveedor_Direccion
    {

 
        public bool alta_direccion(proveedor_dir direccion,int id_proveedor, Modulo_AdministracionContext db)
        {
          
            bool bandera = false;
            try
            {


               
                proveedor_dir proveedor_dir_a_insertar = new proveedor_dir();
                proveedor_dir_a_insertar.id_proveedor = id_proveedor;
                proveedor_dir_a_insertar.cod_tipo_dir = direccion.ttipo_dir.cod_tipo_dir;
                proveedor_dir_a_insertar.cod_clase_dir = direccion.cod_clase_dir;
                proveedor_dir_a_insertar.cod_tipo_calle = direccion.cod_tipo_calle;
                proveedor_dir_a_insertar.cod_calle = direccion.cod_calle;
                proveedor_dir_a_insertar.txt_numero = direccion.txt_numero;
                proveedor_dir_a_insertar.txt_apto = direccion.txt_apto;
                proveedor_dir_a_insertar.txt_piso = direccion.txt_piso;
                proveedor_dir_a_insertar.txt_direccion = direccion.txt_direccion;
                proveedor_dir_a_insertar.txt_cod_postal = direccion.txt_cod_postal;
                proveedor_dir_a_insertar.cod_pais = direccion.cod_pais;
                proveedor_dir_a_insertar.cod_provincia = direccion.cod_provincia;
                proveedor_dir_a_insertar.cod_municipio = direccion.tmunicipio.cod_municipio;
                proveedor_dir_a_insertar.sn_activo = direccion.sn_activo;
                proveedor_dir_a_insertar.fec_ult_modif = DateTime.Now;
                proveedor_dir_a_insertar.accion = direccion.accion;
                db.proveedor_dir.Add(proveedor_dir_a_insertar);
                db.SaveChanges();
                
                bandera = true;
                
                return bandera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }


        public bool modificar_direccion(proveedor_dir direccion, Modulo_AdministracionContext db)
        {
            bool bandera = false;
            try
            {

                if (direccion.sn_activo == 0)
                {
                    if (eliminar_direccion(direccion, db) == false)
                    {
                        throw new Exception("Error al eliminar una direccion del proveedor");
                    }
                }
                else
                {
                    proveedor_dir direccion_db = db.proveedor_dir.FirstOrDefault(p => p.id_proveedor == direccion.id_proveedor && p.cod_tipo_dir == direccion.cod_tipo_dir);
                    if (direccion_db == null)
                    {
                        if (alta_direccion(direccion, direccion.id_proveedor, db) == false)
                        {
                            throw new Exception("Error al dar de alta una direccion del proveedor");
                        }
                    }
                    else
                    {

                        direccion_db.id_proveedor = direccion.id_proveedor;
                        direccion_db.cod_tipo_dir = direccion.cod_tipo_dir;
                        direccion_db.cod_clase_dir = direccion.cod_clase_dir;
                        direccion_db.cod_tipo_calle = direccion.cod_tipo_calle;
                        direccion_db.cod_calle = direccion.cod_calle;
                        direccion_db.txt_numero = direccion.txt_numero;
                        direccion_db.txt_apto = direccion.txt_apto;
                        direccion_db.txt_piso = direccion.txt_piso;
                        direccion_db.txt_direccion = direccion.txt_direccion;
                        direccion_db.txt_cod_postal = direccion.txt_cod_postal;
                        direccion_db.cod_pais = direccion.cod_pais;
                        direccion_db.cod_provincia = direccion.cod_provincia;
                        direccion_db.cod_municipio = direccion.cod_municipio;
                        direccion_db.fec_ult_modif = DateTime.Now;
                        direccion_db.sn_activo = direccion.sn_activo;
                        direccion_db.accion = "MODIFICACION";
                        db.SaveChanges();
                    }

                }





                db.SaveChanges();

                bandera = true;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool eliminar_direccion(proveedor_dir direccion, Modulo_AdministracionContext db)
        {

            bool bandera = false;
            try
            {

                proveedor_dir direccion_db = db.proveedor_dir.FirstOrDefault(p => p.id_proveedor == direccion.id_proveedor && p.cod_tipo_dir == direccion.cod_tipo_dir);
                db.proveedor_dir.Remove(direccion_db);
                db.SaveChanges();

                bandera = true;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet buscar_calle(List<string> Calle)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;
            
            try
            {


                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("buscar_calle", conn);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@txt_desc", Calle[0]);


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

        public DataSet buscar_municipio(List<string> Municipio)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;

            try
            {
                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("buscar_municipio", conn);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@Cod_Pais", Municipio[0]);
                    command.Parameters.AddWithValue("@Cod_provincia", Municipio[1]);
                    command.Parameters.AddWithValue("@municipio", Municipio[2]);

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



        public DataSet buscar_provincia(List<string> Provincia)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;

            try
            {
                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("buscar_provincia", conn);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@Cod_Pais", Provincia[0]);
                    command.Parameters.AddWithValue("@Provincia", Provincia[1]);

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

        public DataSet buscar_pais(List<string> Pais)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;

            try
            {
                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("buscar_pais", conn);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@txt_desc", Pais[0]);


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


        public List<proveedor_dir> buscar_direcciones_por_id_proveedor(int id_proveedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {
         
                List<proveedor_dir> direcciones = (from d in db.proveedor_dir
                                  where d.id_proveedor == id_proveedor && d.sn_activo == -1
                                  select d).ToList();


                return direcciones;

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


        public proveedor_dir buscar_direccion(int id_proveedor,decimal cod_tipo_dir )
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {
       
                proveedor_dir direccion = db.proveedor_dir.FirstOrDefault(p => p.id_proveedor == id_proveedor && p.cod_tipo_dir == cod_tipo_dir);


                return direccion;

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

        public bool dar_de_baja_proveedor_dir_por_proveedor(int id_proveedor, Modulo_AdministracionContext db)
        {
            bool bandera = false;
            try
            {

                List<proveedor_dir> lista_proveedor_dir = (from pd in db.proveedor_dir
                                                where pd.id_proveedor == id_proveedor
                                                select pd).ToList();
                foreach (proveedor_dir pd in lista_proveedor_dir)
                {

                    pd.sn_activo = 0;
                    pd.accion = "ELIMINACION";
                    pd.fec_ult_modif = DateTime.Now;
                  


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
