using Modulo_Administracion.Clases;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo_Administracion.Logica
{
    public class Logica_Vendedor
    {

       

        public bool alta_vendedor(vendedor vendedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {

                    vendedor vendedor_a_insertar = new vendedor();
                    int cantidad = db.vendedor.Count();
                    if (cantidad == 0)
                    {
                        vendedor_a_insertar.id_vendedor = 1;
                    }
                    else
                    {
                        vendedor_a_insertar.id_vendedor = db.vendedor.Max(v => v.id_vendedor) + 1;
                    }
                    vendedor_a_insertar.nombre = vendedor.nombre;
                    vendedor_a_insertar.sn_activo = vendedor.sn_activo;
                    vendedor_a_insertar.fec_ult_modif = vendedor.fec_ult_modif;
                    vendedor_a_insertar.accion = vendedor.accion;
                
                    db.vendedor.Add(vendedor_a_insertar);
                    db.SaveChanges();


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

        public bool modificar_vendedor(vendedor vendedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {

                    vendedor vendedor_db = db.vendedor.FirstOrDefault(f => f.id_vendedor == vendedor.id_vendedor);
                    vendedor_db.id_vendedor = vendedor.id_vendedor;
                    vendedor_db.nombre = vendedor.nombre; 
                    vendedor_db.sn_activo = vendedor.sn_activo;
                    vendedor_db.accion = "MODIFICACION";
                    vendedor_db.fec_ult_modif = DateTime.Now;
                    db.SaveChanges();


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

        public bool eliminar_vendedor(vendedor vendedor)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {


                    vendedor vendedor_db = db.vendedor.FirstOrDefault(f => f.id_vendedor == vendedor.id_vendedor);
                    vendedor_db.id_vendedor = vendedor.id_vendedor;
                    vendedor_db.nombre = vendedor.nombre;
                    vendedor_db.sn_activo = 0;
                    vendedor_db.accion = "ELIMINACION";
                    vendedor_db.fec_ult_modif = DateTime.Now;
                    db.SaveChanges();


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

        public List<vendedor> buscar_vendedores()
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {
             

                List<vendedor> vendedores = (from v in db.vendedor
                                               where v.sn_activo == -1
                                              select v).ToList();


                return vendedores;
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


        public vendedor buscar_vendedor_por_nombre_activo(string nombre,int id_vendedor)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                vendedor vendedor = db.vendedor.FirstOrDefault(p => p.nombre == nombre && p.sn_activo == -1 && p.id_vendedor != id_vendedor);

                return vendedor;
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


        public vendedor buscar_vendedor(int? id_vendedor)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {
       
                vendedor vendedor = db.vendedor.FirstOrDefault(p => p.id_vendedor == id_vendedor);

                return vendedor;
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

      

        public DataTable filtro_vendedor_nombre(string txtBusqueda)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    string query = "select * from vendedor where nombre LIKE '%' + @param + '%' and accion <> 'ELIMINACION' ";


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

  

        public vendedor buscar_vendedor(string nombre)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                vendedor vendedor = db.vendedor.FirstOrDefault(p => p.nombre == nombre);

                return vendedor;
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
