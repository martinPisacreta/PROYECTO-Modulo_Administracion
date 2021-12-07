using Modulo_Administracion.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace Modulo_Administracion.Logica
{


    public class Logica_Familia
    {

        public bool alta_familia(familia familia)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {


                    familia familia_a_insertar = new familia();

                    int cantidad = db.familia.Count();
                    if (cantidad == 0)
                    {
                        familia_a_insertar.id_tabla_familia = 1;
                        familia_a_insertar.id_familia = 1;
                    }
                    else
                    {
                        familia_a_insertar.id_tabla_familia = db.familia.Max(f => f.id_tabla_familia) + 1;
                        familia_a_insertar.id_familia = db.familia.Max(f => f.id_familia) + 1;
                    }
                    familia_a_insertar.id_tabla_marca = familia.id_tabla_marca;
                    familia_a_insertar.txt_desc_familia = familia.txt_desc_familia;
                    familia_a_insertar.sn_activo = familia.sn_activo;
                    familia_a_insertar.fec_ult_modif = familia.fec_ult_modif;
                    familia_a_insertar.accion = familia.accion;
                    familia_a_insertar.path_img = familia.path_img;
                    familia_a_insertar.algoritmo_1 = familia.algoritmo_1;
                    familia_a_insertar.algoritmo_2 = familia.algoritmo_2;
                    familia_a_insertar.algoritmo_3 = familia.algoritmo_3;
                    familia_a_insertar.algoritmo_4 = familia.algoritmo_4;
                    familia_a_insertar.algoritmo_5 = familia.algoritmo_5;
                    familia_a_insertar.algoritmo_6 = familia.algoritmo_6;
                    familia_a_insertar.algoritmo_7 = familia.algoritmo_7;
                    familia_a_insertar.algoritmo_8 = familia.algoritmo_8;
                    familia_a_insertar.algoritmo_9 = familia.algoritmo_9;
                    familia_a_insertar.algoritmo_10 = familia.algoritmo_10;
                    db.familia.Add(familia_a_insertar);
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

        public bool modificar_eliminar_familia(familia familia, decimal coeficiente, int accion)
        {
            Logica_Articulo logica_articulo = new Logica_Articulo();



            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {

                try
                {
                    bool bandera = false;

                    familia familia_db = db.familia.FirstOrDefault(f => f.id_tabla_familia == familia.id_tabla_familia);

                    familia_db.id_tabla_familia = familia.id_tabla_familia;


                    if (accion == 1) //si es modificacion...
                    {
                        familia_db.id_familia = familia.id_familia;
                        familia_db.id_tabla_marca = familia.id_tabla_marca;
                        familia_db.txt_desc_familia = familia.txt_desc_familia;

                        familia_db.sn_activo = familia.sn_activo;
                        familia_db.accion = "MODIFICACION";

                        familia_db.fec_ult_modif = familia.fec_ult_modif;
                        familia_db.path_img = familia.path_img;
                        familia_db.algoritmo_1 = familia.algoritmo_1;
                        familia_db.algoritmo_2 = familia.algoritmo_2;
                        familia_db.algoritmo_3 = familia.algoritmo_3;
                        familia_db.algoritmo_4 = familia.algoritmo_4;
                        familia_db.algoritmo_5 = familia.algoritmo_5;
                        familia_db.algoritmo_6 = familia.algoritmo_6;
                        familia_db.algoritmo_7 = familia.algoritmo_7;
                        familia_db.algoritmo_8 = familia.algoritmo_8;
                        familia_db.algoritmo_9 = familia.algoritmo_9;
                        familia_db.algoritmo_10 = familia.algoritmo_10;




                    }
                    else //si es baja -> doy de baja la familia y a su vez : articulos de esa familia
                    {
                        familia_db.sn_activo = 0;
                        familia_db.accion = "ELIMINACION";

                        if (logica_articulo.dar_de_baja_articulos_por_familia(familia.id_tabla_familia, db) == false)
                        {
                            throw new Exception("Error al dar de baja articulos de familia");
                        }
                    }









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


        public decimal precio_coeficiente(int tipo_de_coeficiente, decimal algoritmo1, decimal algoritmo2, decimal algoritmo3, decimal algoritmo4, decimal algoritmo5, decimal algoritmo6, decimal algoritmo7, decimal algoritmo8, decimal algoritmo9)
        {

            try
            {
                decimal precio_coeficiente = 0.0000M;

                if (algoritmo1 == 0.0000M)
                {
                    algoritmo1 = 1;
                }

                if (algoritmo2 == 0.0000M)
                {
                    algoritmo2 = 1;
                }

                if (algoritmo3 == 0.0000M)
                {
                    algoritmo3 = 1;
                }

                if (algoritmo4 == 0.0000M)
                {
                    algoritmo4 = 1;
                }

                if (algoritmo5 == 0.0000M)
                {
                    algoritmo5 = 1;
                }

                if (algoritmo6 == 0.0000M)
                {
                    algoritmo6 = 1;
                }

                if (algoritmo7 == 0.0000M)
                {
                    algoritmo7 = 1;
                }

                if (algoritmo8 == 0.0000M)
                {
                    algoritmo8 = 1;
                }

                if (algoritmo9 == 0.0000M)
                {
                    algoritmo9 = 1;
                }

                if (tipo_de_coeficiente == 1) //el 1 -> la multiplicacion de algoritmos sin el beneficio 
                {
                    precio_coeficiente = (1 * algoritmo1 * algoritmo2 * algoritmo3 * algoritmo4 * algoritmo5 * algoritmo6 * algoritmo7 * algoritmo8);
                }
                if (tipo_de_coeficiente == 2) // el 2 -> la multiplicacion de algoritmos con el beneficio
                {

                    precio_coeficiente = (1 * algoritmo1 * algoritmo2 * algoritmo3 * algoritmo4 * algoritmo5 * algoritmo6 * algoritmo7 * algoritmo8 * algoritmo9);
                }
                return precio_coeficiente;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool dar_de_baja_familias_por_marca(int id_tabla_marca, Modulo_AdministracionContext db) //doy de baja las familias de una marca 
        {

            bool bandera = false;
            try
            {

                List<familia> lista_familias = (from f in db.familia
                                                where f.id_tabla_marca == id_tabla_marca
                                                select f).ToList();

                foreach (familia f in lista_familias)
                {
                    Logica_Articulo logica_articulo = new Logica_Articulo();
                    if (logica_articulo.dar_de_baja_articulos_por_familia(f.id_tabla_familia, db) == false)
                    {
                        throw new Exception("Error al dar de baja articulos de la familia");
                    }

                    f.sn_activo = 0;
                    f.accion = "ELIMINACION";
                    f.fec_ult_modif = DateTime.Now;



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


        public object buscar_familias_activas_por_marca(int id_tabla_marca)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                var familias = (from f in db.familia
                                join m in db.marca on f.id_tabla_marca equals m.id_tabla_marca
                                join p in db.proveedor on m.id_proveedor equals p.id_proveedor
                                where f.id_tabla_marca == id_tabla_marca && f.sn_activo == -1
                                select new
                                {
                                    f.id_tabla_familia,
                                    f.txt_desc_familia,
                                    m.txt_desc_marca,
                                    p.razon_social
                                }).ToList();

                return familias;
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

        public object buscar_familias_activas()
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                var familias = (from f in db.familia
                                join m in db.marca on f.id_tabla_marca equals m.id_tabla_marca
                                join p in db.proveedor on m.id_proveedor equals p.id_proveedor
                                where f.sn_activo == -1
                                select new
                                {
                                    f.id_tabla_familia,
                                    f.txt_desc_familia,
                                    m.txt_desc_marca,
                                    p.razon_social
                                }).ToList();

                return familias;
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

        public familia buscar_familia_por_id_tabla_familia(int id_tabla_familia)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                familia familia = db.familia.FirstOrDefault(p => p.id_tabla_familia == id_tabla_familia);

                return familia;
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


        public familia buscar_familia_por_txt_desc_familia(string txt_desc_familia)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                familia familia = db.familia.FirstOrDefault(p => p.txt_desc_familia == txt_desc_familia);

                return familia;
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

        public familia buscar_familia_por_txt_desc_activo(string txt_desc_familia, int id_tabla_familia)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                familia familia = db.familia.FirstOrDefault(f => f.txt_desc_familia.Contains(txt_desc_familia) && f.sn_activo == -1 && f.id_tabla_familia != id_tabla_familia);

                return familia;
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
