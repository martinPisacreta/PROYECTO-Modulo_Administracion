using Modulo_Administracion.Clases;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo_Administracion.Logica
{
    public class Logica_Factura_Detalle
    {

      
        public List<factura_detalle> buscar_detalle_factura_por_id_factura(int id_factura, Modulo_AdministracionContext db)
        {
            
            try
            {

                List<factura_detalle> factura_detalle = (from fd in db.factura_detalle
                                                         where fd.id_factura == id_factura && fd.fec_baja == null
                                                  select fd).ToList();


                return factura_detalle;

            }
            catch (Exception ex)
            {
                throw ex;
            }
           


        }


      

        public bool baja_item_a_factura(int id_factura_detalle)
        {

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            bool bandera = false;

            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {

                    factura_detalle factura_detalle_db = db.factura_detalle.FirstOrDefault(c => c.id_factura_detalle == id_factura_detalle);
                    factura_detalle_db.fec_baja = DateTime.Now;
                    db.SaveChanges();
                    
                    transaction.Commit();
                    bandera = true;

                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    db = null;
                }
            }
        }


    

        public bool alta_item_a_factura(factura_detalle item_factura,factura factura_db,Modulo_AdministracionContext db)
        {

            bool bandera = false;
            factura_detalle factura_detalle_a_insertar;
            try
            {
                factura_detalle_a_insertar = new factura_detalle();
                factura_detalle_a_insertar.id_factura = factura_db.id_factura;
                factura_detalle_a_insertar.cantidad = item_factura.cantidad;
                factura_detalle_a_insertar.codigo_articulo_marca = item_factura.codigo_articulo_marca;
                factura_detalle_a_insertar.codigo_articulo = item_factura.codigo_articulo;
                factura_detalle_a_insertar.descripcion_articulo = item_factura.descripcion_articulo;
                factura_detalle_a_insertar.precio_lista_x_coeficiente = item_factura.precio_lista_x_coeficiente;
                factura_detalle_a_insertar.iva = item_factura.iva;

                if (factura_db.sn_emitida == -1)
                {
                    factura_detalle_a_insertar.id_articulo = null;
                }
                else
                {
                    factura_detalle_a_insertar.id_articulo = item_factura.id_articulo;
                }

              
                factura_detalle_a_insertar.fec_baja = null;
                db.factura_detalle.Add(factura_detalle_a_insertar);
                db.SaveChanges();

                bandera = true;
                return bandera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool modificacion_item_a_factura(factura_detalle factura_detalle_db,factura_detalle item_factura_a_modificar, factura factura_db, Modulo_AdministracionContext db)
        {

            bool bandera = false;
            try
            {
                factura_detalle_db.id_factura = factura_db.id_factura;
                factura_detalle_db.cantidad = item_factura_a_modificar.cantidad;
                factura_detalle_db.codigo_articulo_marca = item_factura_a_modificar.codigo_articulo_marca;
                factura_detalle_db.codigo_articulo = item_factura_a_modificar.codigo_articulo;
                factura_detalle_db.descripcion_articulo = item_factura_a_modificar.descripcion_articulo;
                factura_detalle_db.precio_lista_x_coeficiente = item_factura_a_modificar.precio_lista_x_coeficiente;
                factura_detalle_db.iva = item_factura_a_modificar.iva;

                if (factura_db.sn_emitida == -1)
                {
                    factura_detalle_db.id_articulo = null;
                }
                else
                {
                    factura_detalle_db.id_articulo = item_factura_a_modificar.id_articulo;
                }

                
                //factura_detalle_db.fec_baja = null; no lo modifico esto
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
