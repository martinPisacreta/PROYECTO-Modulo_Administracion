using Modulo_Administracion.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Modulo_Administracion.Logica
{
    public class Logica_Proveedor
    {

        Logica_Proveedor_Datos logica_proveedor_datos = new Logica_Proveedor_Datos();
        Logica_Proveedor_Direccion logica_proveedor_direccion = new Logica_Proveedor_Direccion();


        public bool alta_proveedor(proveedor proveedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {
                    proveedor proveedor_a_insertar = new proveedor();

                    int cantidad = db.proveedor.Count();
                    if (cantidad == 0)
                    {
                        proveedor_a_insertar.id_proveedor = 1;
                    }
                    else
                    {
                        proveedor_a_insertar.id_proveedor = db.proveedor.Max(p => p.id_proveedor) + 1;
                    }
                    proveedor_a_insertar.razon_social = proveedor.razon_social;
                    proveedor_a_insertar.id_condicion_ante_iva = proveedor.id_condicion_ante_iva;
                    proveedor_a_insertar.id_condicion_pago = proveedor.id_condicion_pago;
                    proveedor_a_insertar.sn_activo = proveedor.sn_activo;
                    proveedor_a_insertar.fec_ult_modif = proveedor.fec_ult_modif;
                    proveedor_a_insertar.accion = proveedor.accion;
                    proveedor_a_insertar.path_img = proveedor.path_img;
                    db.proveedor.Add(proveedor_a_insertar);
                    db.SaveChanges();


                    //doy de alta el/los datos del proveedor
                    if (proveedor.proveedor_datos != null)
                    {
                        foreach (proveedor_datos proveedor_dato in proveedor.proveedor_datos)
                        {
                            if (logica_proveedor_datos.alta_dato(proveedor_dato, proveedor_a_insertar.id_proveedor, db) == false)
                            {
                                throw new Exception("Error al dar de alta los datos del proveedor");
                            }
                        }
                    }

                    //doy de alta la/las direcciones
                    if (proveedor.proveedor_dir != null)
                    {
                        foreach (proveedor_dir proveedor_dir in proveedor.proveedor_dir)
                        {
                            if (logica_proveedor_direccion.alta_direccion(proveedor_dir, proveedor_a_insertar.id_proveedor, db) == false)
                            {
                                throw new Exception("Error al dar de alta las direcciones del proveedor");
                            }
                        }
                    }

                    dbContextTransaction.Commit();
                    bandera = true;

                    return bandera;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    db = null;
                }
            }
        }

        public bool modificar_proveedor(proveedor proveedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {


                    proveedor proveedor_db = db.proveedor.FirstOrDefault(f => f.id_proveedor == proveedor.id_proveedor);
                    proveedor_db.id_proveedor = proveedor.id_proveedor;
                    proveedor_db.razon_social = proveedor.razon_social;
                    proveedor_db.id_condicion_ante_iva = proveedor.id_condicion_ante_iva;
                    proveedor_db.id_condicion_pago = proveedor.id_condicion_pago;
                    proveedor_db.sn_activo = proveedor.sn_activo;
                    proveedor_db.accion = "MODIFICACION";
                    proveedor_db.fec_ult_modif = DateTime.Now;
                    proveedor_db.path_img = proveedor.path_img;
                    db.SaveChanges();

                    //modifico el/los datos del proveedor
                    if (proveedor.proveedor_datos != null)
                    {
                        foreach (proveedor_datos proveedor_dato in proveedor.proveedor_datos)
                        {
                            if (logica_proveedor_datos.modificar_dato(proveedor_dato, db) == false)
                            {
                                throw new Exception("Error al modificar los datos del proveedor");
                            }
                        }
                    }

                    //modifico la/las direcciones
                    if (proveedor.proveedor_dir != null)
                    {
                        foreach (proveedor_dir proveedor_dir in proveedor.proveedor_dir)
                        {
                            if (logica_proveedor_direccion.modificar_direccion(proveedor_dir, db) == false)
                            {
                                throw new Exception("Error al modificar las direcciones del proveedor");
                            }
                        }
                    }

                    dbContextTransaction.Commit();

                    bandera = true;
                    return bandera;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    db = null;
                }
            }
        }

        public bool eliminar_proveedor(proveedor proveedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {


                    proveedor proveedor_db = db.proveedor.FirstOrDefault(f => f.id_proveedor == proveedor.id_proveedor);
                    proveedor_db.id_proveedor = proveedor.id_proveedor;
                    proveedor_db.razon_social = proveedor.razon_social;
                    proveedor_db.id_condicion_ante_iva = proveedor.id_condicion_ante_iva;
                    proveedor_db.id_condicion_pago = proveedor.id_condicion_pago;
                    proveedor_db.sn_activo = 0;
                    proveedor_db.accion = "ELIMINACION";
                    proveedor_db.fec_ult_modif = DateTime.Now;
                    proveedor_db.path_img = proveedor.path_img;
                    db.SaveChanges();

                    if (proveedor.proveedor_dir != null)
                    {
                        if (proveedor.proveedor_dir.Count > 0)
                        {
                            Logica_Proveedor_Direccion logica_direccion = new Logica_Proveedor_Direccion();
                            if (logica_direccion.dar_de_baja_proveedor_dir_por_proveedor(proveedor.id_proveedor, db) == false)
                            {
                                throw new Exception("Error al dar de baja direccion/es del proveedor");
                            }
                        }
                    }

                    if (proveedor.proveedor_datos != null)
                    {
                        if (proveedor.proveedor_datos.Count > 0)
                        {
                            Logica_Proveedor_Datos Logica_Proveedor_Datos = new Logica_Proveedor_Datos();
                            if (Logica_Proveedor_Datos.dar_de_baja_proveedor_datos_por_proveedor(proveedor.id_proveedor, db) == false)
                            {
                                throw new Exception("Error al dar de baja dato/s del proveedor");
                            }
                        }
                    }


                    if (proveedor.marca != null)
                    {
                        if (proveedor.marca.Count > 0)
                        {
                            Logica_Marca logica_marca = new Logica_Marca();
                            if (logica_marca.dar_de_baja_marcas_por_proveedor(proveedor.id_proveedor, db) == false)
                            {
                                throw new Exception("Error al dar de baja marcas del proveedor");
                            }
                        }
                    }


                    dbContextTransaction.Commit();

                    bandera = true;
                    return bandera;
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
                finally
                {
                    db = null;
                }
            }
        }

        public List<proveedor> buscar_proveedores()
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {


                List<proveedor> proveedores = (from p in db.proveedor
                                               where p.sn_activo == -1
                                               select p).ToList();


                return proveedores;
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            finally
            {
                db = null;
            }

        }

        public proveedor buscar_proveedor(int id_proveedor)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                proveedor proveedor = db.proveedor.FirstOrDefault(p => p.id_proveedor == id_proveedor);

                return proveedor;
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            finally
            {
                db = null;
            }

        }

        public proveedor buscar_proveedor(string razon_social)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                proveedor proveedor = db.proveedor.FirstOrDefault(p => p.razon_social == razon_social);

                return proveedor;
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            finally
            {
                db = null;
            }

        }


        public DataTable filtro_proveedor_razon_social(string txtBusqueda)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    string query = "select * from proveedor where razon_social LIKE '%' + @param + '%' and accion <> 'ELIMINACION'";


                    SqlCommand cmd = new SqlCommand(query, cnx);
                    cmd.Parameters.AddWithValue("@param", txtBusqueda.Trim());

                    SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    return dt;

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public proveedor buscar_proveedor_por_razon_social_activo(string razon_social, int id_proveedor)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                proveedor proveedor = db.proveedor.FirstOrDefault(p => p.razon_social.Contains(razon_social) && p.sn_activo == -1 && p.id_proveedor != id_proveedor);

                return proveedor;
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            finally
            {
                db = null;
            }

        }
    }
}
