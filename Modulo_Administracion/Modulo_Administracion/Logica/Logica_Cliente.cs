using Modulo_Administracion.Clases;

using System;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace Modulo_Administracion.Logica
{
    public class Logica_Cliente
    {

        Logica_Cliente_Datos logica_cliente_datos = new Logica_Cliente_Datos();
        Logica_Cliente_Direccion logica_cliente_direccion = new Logica_Cliente_Direccion();

        public bool alta_cliente(cliente cliente)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {
                    cliente cliente_a_insertar = new cliente();

                    int cantidad = db.cliente.Count();
                    if (cantidad == 0)
                    {
                        cliente_a_insertar.id_cliente = 1;
                    }
                    else
                    {
                        cliente_a_insertar.id_cliente = db.cliente.Max(c => c.id_cliente) + 1;
                    }
                    cliente_a_insertar.razon_social = cliente.razon_social;
                    cliente_a_insertar.nombre_fantasia = cliente.nombre_fantasia;
                    cliente_a_insertar.id_condicion_ante_iva = cliente.id_condicion_ante_iva;
                    cliente_a_insertar.id_condicion_pago = cliente.id_condicion_pago;
                    cliente_a_insertar.sn_activo = cliente.sn_activo;
                    cliente_a_insertar.fec_ult_modif = cliente.fec_ult_modif;
                    cliente_a_insertar.accion = cliente.accion;
                    cliente_a_insertar.id_condicion_factura = cliente.id_condicion_factura;
                    cliente_a_insertar.id_tipo_cliente = cliente.id_tipo_cliente;
                    cliente_a_insertar.id_vendedor = cliente.id_vendedor > 0 ? cliente.id_vendedor : null;
                    db.cliente.Add(cliente_a_insertar);
                    db.SaveChanges();


                    //doy de alta el/los datos del cliente
                    if (cliente.cliente_datos != null)
                    {
                        if (cliente.cliente_datos.Count > 0)
                        {
                            foreach (cliente_datos cliente_dato in cliente.cliente_datos)
                            {
                                if (logica_cliente_datos.alta_dato(cliente_dato, cliente_a_insertar.id_cliente, db) == false)
                                {
                                    throw new Exception("Error al dar de alta los datos del cliente");
                                }
                            }
                        }
                    }

                    //doy de alta la/las direcciones
                    if (cliente.cliente_dir != null)
                    {
                        if (cliente.cliente_dir.Count > 0)
                        {
                            foreach (cliente_dir cliente_dir in cliente.cliente_dir)
                            {
                                if (logica_cliente_direccion.alta_direccion(cliente_dir, cliente_a_insertar.id_cliente, db) == false)
                                {
                                    throw new Exception("Error al dar de alta las direcciones del cliente");
                                }
                            }
                        }
                    }


                    bandera = true;
                    dbContextTransaction.Commit();
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

        public bool modificar_cliente(cliente cliente)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {

                    cliente cliente_db = db.cliente.FirstOrDefault(f => f.id_cliente == cliente.id_cliente);
                    cliente_db.id_cliente = cliente.id_cliente;
                    cliente_db.razon_social = cliente.razon_social;
                    cliente_db.nombre_fantasia = cliente.nombre_fantasia;
                    cliente_db.id_condicion_ante_iva = cliente.id_condicion_ante_iva;
                    cliente_db.id_condicion_pago = cliente.id_condicion_pago;
                    cliente_db.sn_activo = cliente.sn_activo;
                    cliente_db.accion = "MODIFICACION";
                    cliente_db.fec_ult_modif = DateTime.Now;
                    cliente_db.id_condicion_factura = cliente.id_condicion_factura;
                    cliente_db.id_tipo_cliente = cliente.id_tipo_cliente;
                    cliente_db.id_vendedor = cliente.id_vendedor > 0 ? cliente.id_vendedor : null;
                    db.SaveChanges();


                    //modifico el/los datos del cliente
                    if (cliente.cliente_datos != null)
                    {
                        if (cliente.cliente_datos.Count > 0)
                        {
                            foreach (cliente_datos cliente_dato in cliente.cliente_datos)
                            {
                                if (logica_cliente_datos.modificar_dato(cliente_dato, db) == false)
                                {
                                    throw new Exception("Error al modificar los datos del cliente");
                                }
                            }
                        }
                    }

                    //modifico la/las direcciones
                    if (cliente.cliente_dir != null)
                    {
                        if (cliente.cliente_dir.Count > 0)
                        {
                            foreach (cliente_dir cliente_dir in cliente.cliente_dir)
                            {
                                if (logica_cliente_direccion.modificar_direccion(cliente_dir, db) == false)
                                {
                                    throw new Exception("Error al modificar las direcciones del cliente");
                                }
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

        public bool eliminar_cliente(cliente cliente)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {


                    cliente cliente_db = db.cliente.FirstOrDefault(f => f.id_cliente == cliente.id_cliente);
                    cliente_db.id_cliente = cliente.id_cliente;
                    cliente_db.razon_social = cliente.razon_social;
                    cliente_db.nombre_fantasia = cliente.nombre_fantasia;
                    cliente_db.id_condicion_ante_iva = cliente.id_condicion_ante_iva;
                    cliente_db.id_condicion_pago = cliente.id_condicion_pago;
                    cliente_db.sn_activo = 0;
                    cliente_db.accion = "ELIMINACION";
                    cliente_db.fec_ult_modif = DateTime.Now;
                    db.SaveChanges();


                    //elimino el/los datos del cliente
                    if (cliente.cliente_datos != null)
                    {
                        if (cliente.cliente_datos.Count > 0)
                        {
                            Logica_Cliente_Datos logica_cliente_datos = new Logica_Cliente_Datos();
                            if (logica_cliente_datos.dar_de_baja_cliente_datos_por_cliente(cliente.id_cliente, db) == false)
                            {
                                throw new Exception("Error al dar de baja dato/s del cliente");
                            }
                        }
                    }

                    //elimino la/las direcciones
                    if (cliente.cliente_dir != null)
                    {
                        if (cliente.cliente_dir.Count > 0)
                        {
                            Logica_Cliente_Direccion logica_cliente_direccion = new Logica_Cliente_Direccion();
                            if (logica_cliente_direccion.dar_de_baja_cliente_dir_por_cliente(cliente.id_cliente, db) == false)
                            {
                                throw new Exception("Error al dar de baja direccion/es del cliente");
                            }
                        }
                    }
                    //no habilite la opcion de eliminar facturas 


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

        public object buscar_clientes()
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {


                var clientes = (from p in db.cliente
                                where p.sn_activo == -1
                                select new
                                {
                                    p.id_cliente,
                                    p.nombre_fantasia,
                                    p.vendedor.nombre
                                }).ToList();


                return clientes;
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


        public cliente buscar_cliente_por_nombre_fantasia_activo(string nombre_fantasia, int id_cliente)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                cliente cliente = db.cliente.FirstOrDefault(p => p.nombre_fantasia == nombre_fantasia && p.sn_activo == -1 && p.id_cliente != id_cliente);

                return cliente;
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

        public cliente buscar_cliente_por_razon_social_activo(string razon_social, int id_cliente)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                cliente cliente = db.cliente.FirstOrDefault(p => p.razon_social == razon_social && p.sn_activo == -1 && p.id_cliente != id_cliente);

                return cliente;
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


        public cliente buscar_cliente(int id_cliente)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                cliente cliente = db.cliente.FirstOrDefault(p => p.id_cliente == id_cliente);

                return cliente;
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

        public cliente buscar_cliente(int id_cliente, Modulo_AdministracionContext db)
        {


            try
            {

                cliente cliente = db.cliente.FirstOrDefault(p => p.id_cliente == id_cliente);

                return cliente;
            }
            catch (Exception exception1)
            {
                throw exception1;
            }


        }

        public object filtro_cliente_nombre_fantasia(string txtBusqueda, int valor_busqueda)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                //si valor_busqueda es 1 , el filtro es por cliente
                //si valor_busqueda es 1 , el filtro es por vendedor
                var clientes = (from p in db.cliente
                                where
                                      p.sn_activo == -1
                                      &&
                                      (
                                          (p.nombre_fantasia.Contains(txtBusqueda) && valor_busqueda == 1)
                                          ||
                                          (p.vendedor.nombre.Contains(txtBusqueda) && valor_busqueda == 2)
                                      )
                                select new
                                {
                                    p.id_cliente,
                                    p.nombre_fantasia,
                                    p.vendedor.nombre
                                }).ToList();


                return clientes;
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

        public DataSet buscar_clientes(string razon_social)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;

            try
            {


                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("buscar_cliente", conn);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@nombre", razon_social);


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
        }

        public cliente buscar_cliente(string razon_social)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                cliente cliente = db.cliente.FirstOrDefault(p => p.razon_social == razon_social);

                return cliente;
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

        public object buscar_clientes_activos_por_vendedor(int id_vendedor)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                var clientes = (from p in db.cliente
                                where p.id_vendedor == id_vendedor && p.sn_activo == -1
                                select new
                                {
                                    p.id_cliente,
                                    p.nombre_fantasia,
                                    p.vendedor.nombre
                                }).ToList();

                return clientes;
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
