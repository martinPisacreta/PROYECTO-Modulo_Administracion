using Modulo_Administracion.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Modulo_Administracion.Logica
{
    public class Logica_Marca
    {

        public bool alta_marca(marca marca)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    marca marca_a_insertar = new marca();

                    int cantidad = db.marca.Count();
                    if (cantidad == 0)
                    {
                        marca_a_insertar.id_tabla_marca = 1;
                        marca_a_insertar.id_marca = 1;
                    }
                    else
                    {
                        marca_a_insertar.id_tabla_marca = db.marca.Max(m => m.id_tabla_marca) + 1;
                        marca_a_insertar.id_marca = db.marca.Max(m => m.id_marca) + 1;
                    }
                    marca_a_insertar.id_proveedor = marca.id_proveedor;
                    marca_a_insertar.txt_desc_marca = marca.txt_desc_marca;
                    marca_a_insertar.sn_activo = marca.sn_activo;
                    marca_a_insertar.fec_ult_modif = marca.fec_ult_modif;
                    marca_a_insertar.accion = marca.accion;
                    marca_a_insertar.path_img = marca.path_img;
                    db.marca.Add(marca_a_insertar);
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

        public bool modificar_eliminar_marca(marca marca, int accion)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {

                    bool bandera = false;
                    marca marca_db = db.marca.FirstOrDefault(f => f.id_tabla_marca == marca.id_tabla_marca);
                    marca_db.id_tabla_marca = marca.id_tabla_marca;
                    marca_db.id_marca = marca.id_marca;
                    marca_db.id_proveedor = marca.id_proveedor;
                    marca_db.txt_desc_marca = marca.txt_desc_marca;
                    if (accion == 1) //si es modificacion...
                    {
                        marca_db.sn_activo = marca.sn_activo;
                        marca_db.accion = "MODIFICACION";
                    }
                    else //si es baja -> doy de baja la marca y a su vez :  familas y articulos de esa marca
                    {
                        marca_db.sn_activo = 0;
                        marca_db.accion = "ELIMINACION";

                        Logica_Familia logica_familia = new Logica_Familia();
                        if (logica_familia.dar_de_baja_familias_por_marca(marca.id_tabla_marca, db) == false)
                        {
                            throw new Exception("Error al dar de baja familias de la marca");
                        }
                    }

                    marca_db.fec_ult_modif = DateTime.Now;
                    marca_db.path_img = marca.path_img;

                    db.SaveChanges();
                    dbContextTransaction.Commit();
                    bandera = true;

                    return true;
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

        public bool dar_de_baja_marcas_por_proveedor(int id_proveedor, Modulo_AdministracionContext db) //doy de baja las marcas de un proveedor
        {

            bool bandera = false;
            try
            {

                List<marca> lista_marcas = (from m in db.marca
                                            where m.id_proveedor == id_proveedor
                                            select m).ToList();

                foreach (marca m in lista_marcas)
                {
                    Logica_Familia logica_familia = new Logica_Familia();
                    if (logica_familia.dar_de_baja_familias_por_marca(m.id_tabla_marca, db) == false)
                    {
                        throw new Exception("Error al dar de baja familias de la marca");
                    }

                    m.sn_activo = 0;
                    m.accion = "ELIMINACION";
                    m.fec_ult_modif = DateTime.Now;



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



        public object buscar_marcas_activas_por_proveedor(int id_proveedor)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                var marcas = (from m in db.marca
                              where m.id_proveedor == id_proveedor && m.sn_activo == -1
                              select new
                              {
                                  m.id_tabla_marca,
                                  m.txt_desc_marca,
                                  m.proveedor.razon_social
                              }).ToList();

                return marcas;
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


        public object buscar_marcas_activas()
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                var marcas = (from m in db.marca
                              where m.sn_activo == -1
                              select new
                              {
                                  m.id_tabla_marca,
                                  m.txt_desc_marca,
                                  m.proveedor.razon_social
                              }).ToList();

                return marcas;

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

        public marca buscar_marca_por_id_tabla_marca(int id_tabla_marca)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                marca marca = db.marca.FirstOrDefault(p => p.id_tabla_marca == id_tabla_marca);

                return marca;
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

        public marca buscar_marca_por_txt_desc_marca(string txt_desc_marca)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                marca marca = db.marca.FirstOrDefault(p => p.txt_desc_marca == txt_desc_marca);

                return marca;
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

        public marca buscar_marca_por_txt_desc_activo(string txt_desc_marca, int id_tabla_marca)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                marca marca = db.marca.FirstOrDefault(m => m.txt_desc_marca.Contains(txt_desc_marca) && m.sn_activo == -1 && m.id_tabla_marca != id_tabla_marca);

                return marca;
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
