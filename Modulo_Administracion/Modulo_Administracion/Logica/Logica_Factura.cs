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
    public class Logica_Factura
    {

        Logica_Cliente logica_cliente = new Logica_Cliente();
        Logica_Factura_Detalle logica_factura_detalle = new Logica_Factura_Detalle();
        Logica_Cliente_Cuenta_Corriente logica_cliente_cuenta_corriente = new Logica_Cliente_Cuenta_Corriente();
        Logica_Factura_Tipo logica_factura_tipo = new Logica_Factura_Tipo();

        public factura alta_factura(factura factura)
        {

            int id_factura = 0;
            bool bandera = false;
            Int64 nro_factura;

            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {
                ttipo_factura ttipo_factura_bd = db.ttipo_factura.FirstOrDefault(f => f.cod_tipo_factura == factura.cod_tipo_factura);
                nro_factura = logica_factura_tipo.ult_nro_factura_no_usado_en_tipo_factura(factura.cod_tipo_factura); //voy a buscar el ult_nro_factura_no_usado_en_tipo_factura

                try
                {
                    factura factura_a_insertar = new factura();
                    //id_factura -- es identity
                    factura_a_insertar.id_cliente = factura.id_cliente;
                    factura_a_insertar.cod_tipo_factura = factura.cod_tipo_factura;
                    factura_a_insertar.ttipo_factura = ttipo_factura_bd;

                    factura_a_insertar.nro_factura = Convert.ToInt64(nro_factura.ToString());


                    factura_a_insertar.precio_final = factura.precio_final;
                    factura_a_insertar.sn_modifica_precio_final = factura.sn_modifica_precio_final;
                    factura_a_insertar.precio_final_con_pago_mayor_a_30_dias = factura.precio_final_con_pago_mayor_a_30_dias;
                    factura_a_insertar.precio_final_con_pago_menor_a_30_dias = factura.precio_final_con_pago_menor_a_30_dias;
                    factura_a_insertar.precio_final_con_pago_menor_a_7_dias = factura.precio_final_con_pago_menor_a_7_dias;

                    factura_a_insertar.sn_emitida = factura.sn_emitida;
                    factura_a_insertar.observacion = factura.observacion;
                    factura_a_insertar.sn_mostrar_pago_mayor_30_dias = factura.sn_mostrar_pago_mayor_30_dias;
                    factura_a_insertar.sn_mostrar_pago_menor_30_dias = factura.sn_mostrar_pago_menor_30_dias;
                    factura_a_insertar.sn_mostrar_pago_menor_7_dias = factura.sn_mostrar_pago_menor_7_dias;
                    factura_a_insertar.id_condicion_factura = logica_cliente.buscar_cliente(factura.id_cliente, db).id_condicion_factura;

                    if (factura_a_insertar.sn_emitida == -1)
                    {
                        factura_a_insertar.fecha = Convert.ToDateTime(factura.fecha.ToString("yyyy-MM-dd"));
                        factura_a_insertar.fecha_sn_emitida = factura.fecha_sn_emitida;
                        factura_a_insertar.path_factura = Logica_Funciones_Generales.crear_path_a_partir_de_factura(factura_a_insertar);
                    }
                    else
                    {
                        factura_a_insertar.fecha = Convert.ToDateTime(factura.fecha.ToString("yyyy-MM-dd"));
                        factura_a_insertar.fecha_sn_emitida = factura.fecha_sn_emitida;
                        factura_a_insertar.path_factura = factura.path_factura;
                    }

                    db.factura.Add(factura_a_insertar);
                    db.SaveChanges();


                    foreach (factura_detalle item_factura in factura.factura_detalle)
                    {
                        if (logica_factura_detalle.alta_item_a_factura(item_factura, factura_a_insertar, db) == false)
                        {
                            throw new Exception("Error al dar de alta el item a la factura");
                        }
                    }

                    if (factura.sn_emitida == -1)
                    {
                        if (logica_cliente_cuenta_corriente.alta_movimiento_cuenta_corriente(factura_a_insertar, db) == false)
                        {
                            throw new Exception("Error al dar de alta movimiento en cuenta corriente");
                        }
                    }

                    db.SaveChanges();


                    dbContextTransaction.Commit();
                    return factura_a_insertar;
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

        public factura modificar_factura(factura factura)
        {
            bool bandera = false;
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {

                    factura factura_db = db.factura.FirstOrDefault(c => c.id_factura == factura.id_factura);
                    factura_db.id_cliente = factura.id_cliente;
                    factura_db.cod_tipo_factura = factura.cod_tipo_factura;
                    //factura_db.fecha = factura.fecha;
                    factura_db.nro_factura = factura.nro_factura;

                    factura_db.precio_final = factura.precio_final;
                    factura_db.sn_modifica_precio_final = factura.sn_modifica_precio_final;
                    factura_db.precio_final_con_pago_mayor_a_30_dias = factura.precio_final_con_pago_mayor_a_30_dias;
                    factura_db.precio_final_con_pago_menor_a_30_dias = factura.precio_final_con_pago_menor_a_30_dias;

                    factura_db.precio_final_con_pago_menor_a_7_dias = factura.precio_final_con_pago_menor_a_7_dias;

                    factura_db.sn_emitida = factura.sn_emitida;
                    factura_db.observacion = factura.observacion;


                    factura_db.sn_mostrar_pago_mayor_30_dias = factura.sn_mostrar_pago_mayor_30_dias;
                    factura_db.sn_mostrar_pago_menor_30_dias = factura.sn_mostrar_pago_menor_30_dias;
                    factura_db.sn_mostrar_pago_menor_7_dias = factura.sn_mostrar_pago_menor_7_dias;
                    factura_db.id_condicion_factura = logica_cliente.buscar_cliente(factura.id_cliente, db).id_condicion_factura;



                    //SI CAMBIO ACA , TAMBIEN CAMBIAR LINEA DONDE DICE "PEPE EL PISTOLERO"
                    if (factura_db.sn_emitida == -1)
                    {
                        factura_db.fecha = Convert.ToDateTime(factura.fecha.ToString("yyyy-MM-dd"));
                        factura_db.fecha_sn_emitida = factura.fecha_sn_emitida;
                        factura_db.path_factura = Logica_Funciones_Generales.crear_path_a_partir_de_factura(factura_db);
                    }
                    else
                    {
                        factura_db.fecha_sn_emitida = null;
                        factura_db.path_factura = null;
                    }
                    //HASTA ACA




                    db.SaveChanges();

                    foreach (factura_detalle item_factura in factura.factura_detalle)
                    {
                        factura_detalle factura_detalle_db = db.factura_detalle.FirstOrDefault(c => c.id_factura_detalle == item_factura.id_factura_detalle);
                        if (factura_detalle_db != null) //es modificacion
                        {
                            if (logica_factura_detalle.modificacion_item_a_factura(factura_detalle_db, item_factura, factura_db, db) == false)
                            {
                                throw new Exception("Error al modificar el item a la factura");
                            }

                        }
                        else
                        {
                            if (logica_factura_detalle.alta_item_a_factura(item_factura, factura_db, db) == false)
                            {
                                throw new Exception("Error al dar de alta el item a la factura");
                            }
                        }


                    }

                    if (factura.sn_emitida == -1 && factura.cod_tipo_factura == 1) //solamente si es remito guardo el movimiento en la cuenta corriente
                    {
                        if (logica_cliente_cuenta_corriente.alta_movimiento_cuenta_corriente(factura, db) == false)
                        {
                            throw new Exception("Error al dar de alta movimiento en cuenta corriente");
                        }
                    }

                    dbContextTransaction.Commit();
                    return factura_db;
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






        public factura buscar_factura_por_id_factura(int id_factura)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                factura factura = db.factura.FirstOrDefault(t => t.id_factura == id_factura);
                factura.factura_detalle.Clear();
                factura.factura_detalle = logica_factura_detalle.buscar_detalle_factura_por_id_factura(factura.id_factura, db);

                return factura;

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

        public List<factura> buscar_facturas_por_id_cliente(int id_cliente)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                List<factura> facturas = (from t in db.factura
                                          where t.id_cliente == id_cliente
                                          select t).ToList();


                return facturas;

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

        public List<factura> buscar_facturas_por_fecha(DateTime fecha)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                List<factura> facturas = (from t in db.factura
                                          where t.fecha == fecha
                                          select t).ToList();


                return facturas;

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

        public List<factura> buscar_facturas(int cod_tipo_factura, Int64 nro_factura, int id_cliente, string codigo_articulo, string codigo_articulo_marca, DateTime? fecha_desde, DateTime? fecha_hasta)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                List<factura> facturas = ((from f in db.factura
                                           join fd in db.factura_detalle on f.id_factura equals fd.id_factura
                                           where
                                                 (f.cod_tipo_factura == cod_tipo_factura || cod_tipo_factura == -999) &&
                                                 (f.nro_factura == nro_factura || nro_factura == 0) &&
                                                 (f.id_cliente == id_cliente || id_cliente == -999) &&
                                                 (fd.codigo_articulo == codigo_articulo || codigo_articulo == "") &&
                                                 (fd.codigo_articulo_marca == codigo_articulo_marca || codigo_articulo_marca == "") &&
                                                 ((f.fecha >= fecha_desde && f.fecha <= fecha_hasta) || (fecha_desde == null && fecha_hasta == null))
                                           select f).Distinct()).ToList();


                return facturas;

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





        public factura buscar_factura(Int64 nro_factura)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                factura factura = db.factura.FirstOrDefault(t => t.nro_factura == nro_factura);


                return factura;

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

        public factura buscar_factura(int id_cliente, decimal id_factura)
        {
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            try
            {

                factura factura = db.factura.FirstOrDefault(t => t.id_cliente == id_cliente && t.id_factura == id_factura);


                return factura;

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


        public bool eliminar_factura(factura factura)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("delete_factura", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_factura", SqlDbType.Int).Value = factura.id_factura;

                        conn.Open();
                        using (SqlTransaction trans = conn.BeginTransaction())
                        {
                            cmd.Transaction = trans;
                            try
                            {
                                cmd.ExecuteNonQuery();
                                trans.Commit();
                                return true;
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }

                        }


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
