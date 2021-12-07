using Modulo_Administracion.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Modulo_Administracion.Logica
{
    public class Logica_Cliente_Direccion
    {


        public bool alta_direccion(cliente_dir direccion, int id_cliente, Modulo_AdministracionContext db)
        {

            bool bandera = false;
            try
            {



                cliente_dir cliente_dir_a_insertar = new cliente_dir();
                cliente_dir_a_insertar.id_cliente = id_cliente;
                cliente_dir_a_insertar.cod_tipo_dir = direccion.ttipo_dir.cod_tipo_dir;
                cliente_dir_a_insertar.cod_clase_dir = direccion.cod_clase_dir;
                cliente_dir_a_insertar.cod_tipo_calle = direccion.ttipo_calle.cod_tipo_calle;
                cliente_dir_a_insertar.cod_calle = direccion.cod_calle;
                cliente_dir_a_insertar.txt_numero = direccion.txt_numero;
                cliente_dir_a_insertar.txt_apto = direccion.txt_apto;
                cliente_dir_a_insertar.txt_piso = direccion.txt_piso;
                cliente_dir_a_insertar.txt_direccion = direccion.txt_direccion;
                cliente_dir_a_insertar.txt_cod_postal = direccion.txt_cod_postal;
                cliente_dir_a_insertar.cod_pais = direccion.cod_pais;
                cliente_dir_a_insertar.cod_provincia = direccion.cod_provincia;
                cliente_dir_a_insertar.cod_municipio = direccion.tmunicipio.cod_municipio;
                cliente_dir_a_insertar.sn_activo = direccion.sn_activo;
                cliente_dir_a_insertar.fec_ult_modif = DateTime.Now;
                cliente_dir_a_insertar.accion = direccion.accion;
                db.cliente_dir.Add(cliente_dir_a_insertar);
                db.SaveChanges();

                bandera = true;

                return bandera;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public bool modificar_direccion(cliente_dir direccion, Modulo_AdministracionContext db)
        {
            bool bandera = false;
            try
            {

                if (direccion.sn_activo == 0)
                {
                    if (eliminar_direccion(direccion, db) == false)
                    {
                        throw new Exception("Error al eliminar una direccion del cliente");
                    }
                }
                else
                {
                    cliente_dir direccion_db = db.cliente_dir.FirstOrDefault(p => p.id_cliente == direccion.id_cliente && p.cod_tipo_dir == direccion.cod_tipo_dir);
                    if (direccion_db == null)
                    {
                        if (alta_direccion(direccion, direccion.id_cliente, db) == false)
                        {
                            throw new Exception("Error al dar de alta una direccion del cliente");
                        }
                    }
                    else
                    {

                        direccion_db.id_cliente = direccion.id_cliente;
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
                        direccion_db.cod_municipio = direccion.tmunicipio.cod_municipio;
                        direccion_db.fec_ult_modif = DateTime.Now;
                        direccion_db.sn_activo = direccion.sn_activo;
                        direccion_db.accion = "MODIFICACION";
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

        public bool eliminar_direccion(cliente_dir direccion, Modulo_AdministracionContext db)
        {

            bool bandera = false;
            try
            {

                cliente_dir direccion_db = db.cliente_dir.FirstOrDefault(p => p.id_cliente == direccion.id_cliente && p.cod_tipo_dir == direccion.cod_tipo_dir);
                db.cliente_dir.Remove(direccion_db);
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


        public List<cliente_dir> buscar_direcciones_por_id_cliente(int id_cliente)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                List<cliente_dir> direcciones = (from d in db.cliente_dir
                                                 where d.id_cliente == id_cliente && d.sn_activo == -1
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


        public cliente_dir buscar_direccion(int id_cliente, decimal cod_tipo_dir)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                cliente_dir direccion = db.cliente_dir.FirstOrDefault(p => p.id_cliente == id_cliente && p.cod_tipo_dir == cod_tipo_dir);


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


        public bool dar_de_baja_cliente_dir_por_cliente(int id_cliente, Modulo_AdministracionContext db)
        {
            bool bandera = false;
            try
            {

                List<cliente_dir> lista_cliente_dir = (from pd in db.cliente_dir
                                                       where pd.id_cliente == id_cliente
                                                       select pd).ToList();
                foreach (cliente_dir pd in lista_cliente_dir)
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
