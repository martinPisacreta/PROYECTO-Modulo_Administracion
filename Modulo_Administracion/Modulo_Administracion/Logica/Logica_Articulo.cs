using Modulo_Administracion.Clases;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Modulo_Administracion.Logica
{
    public class Logica_Articulo
    {
        Logica_Familia logica_familia = new Logica_Familia();

        public void modificar_datos_a_tabla_articulo_por_metodo_actualizar_porcentaje(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                    {
                        try
                        {


                            SqlCommand crear_tabla = new SqlCommand(
                                                                        "create table #tmp_articulos" +
                                                                        "(" +
                                                                            "id_articulo bigint, " +
                                                                            "precio_lista numeric(18, 4)" +
                                                                        ")", conn, transaction
                                                                    );

                            SqlCommand actualizar_precios = new SqlCommand(
                                                                            "update " +
                                                                                "art " +
                                                                            "set " +
                                                                                "art.precio_lista = tmp.precio_lista," +
                                                                                "art.fecha_ult_modif = GETDATE(),art.accion = 'MODIFICACION' " +
                                                                            "from	" +
                                                                                "articulo art inner join #tmp_articulos tmp on tmp.id_articulo = art.id_articulo", conn, transaction
                                                                            );

                            crear_tabla.ExecuteNonQuery();

                            bulkCopy.BulkCopyTimeout = 180;
                            bulkCopy.DestinationTableName = "#tmp_articulos";
                            bulkCopy.WriteToServer(dt);

                            actualizar_precios.ExecuteNonQuery();

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();

                            conn.Close();
                            throw ex;
                        }

                    }
                }

            }
        }

        //SI "busqueda" ES 1 -> BUSCO LOS ARTICULOS EXISTENTES EN LA BASE DE DATOS EN RELACION A LA TABLA #tmp_lista_precios_proveedor
        //SI "busqueda" ES 2 -> BUSCO LOS ARTICULOS INEEXISTENTES EN LA BASE DE DATOS EN RELACION A LA TABLA #tmp_lista_precios_proveedor
        public DataSet buscar_articulos_en_relacion_a_dataTable(DataTable dt, int busqueda, int id_proveedor)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                    {
                        try
                        {



                            SqlCommand crear_tabla_tmp_lista_precios_proveedor = new SqlCommand(
                                                                                 "create table #tmp_lista_precios_proveedor" +
                                                                                 "(" +

                                                                                    "codigo_articulo nvarchar(255) NULL," +
                                                                                    "descripcion_articulo nvarchar(255) NULL," +
                                                                                    "precio_lista float NULL" +
                                                                                ")", conn, transaction
                                                                               );



                            crear_tabla_tmp_lista_precios_proveedor.ExecuteNonQuery();


                            bulkCopy.BulkCopyTimeout = 180;
                            bulkCopy.DestinationTableName = "#tmp_lista_precios_proveedor";
                            bulkCopy.WriteToServer(dt);


                            DataSet dataSet = new DataSet("TimeRanges");

                            SqlCommand command = new SqlCommand("buscar_articulos_en_relacion_a_dataTable", conn, transaction);
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@busqueda";
                            param.Value = busqueda;
                            param.SqlDbType = SqlDbType.Int;
                            command.Parameters.Add(param);

                            param = new SqlParameter();
                            param.ParameterName = "@id_proveedor";
                            param.Value = id_proveedor;
                            param.SqlDbType = SqlDbType.Int;
                            command.Parameters.Add(param);

                            command.CommandTimeout = 0;

                            command.CommandType = CommandType.StoredProcedure;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = command;
                            adapter.Fill(dataSet);

                            transaction.Commit();

                            return dataSet;

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            conn.Close();
                            throw ex;
                        }

                    }
                }

            }
        }

        public DataSet alta_articulos_a_tabla_articulo_por_metodo_subida_excel(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, transaction))
                    {
                        try
                        {

                            bulkCopy.BulkCopyTimeout = 180;
                            bulkCopy.DestinationTableName = "articulo_tmp";
                            bulkCopy.WriteToServer(dt);


                            DataSet dataSet = new DataSet("TimeRanges");

                            SqlCommand command = new SqlCommand("ABM_articulos", conn, transaction);
                            command.CommandTimeout = 0;

                            command.CommandType = CommandType.StoredProcedure;

                            SqlDataAdapter adapter = new SqlDataAdapter();
                            adapter.SelectCommand = command;
                            adapter.Fill(dataSet);

                            transaction.Commit();

                            return dataSet;

                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            conn.Close();
                            throw ex;
                        }

                    }
                }

            }
        }



        public DataSet buscar_articulo_por_codigo_articulo_marca_y_codigo_articulo(string codigo_articulo_marca, string codigo_articulo)
        {

            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;

            try
            {


                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("buscar_articulos_por_codigo_articulo_marca_y_codigo_articulo", conn);
                    command.CommandTimeout = 0;

                    command.Parameters.AddWithValue("@codigo_articulo_marca", codigo_articulo_marca);
                    command.Parameters.AddWithValue("@codigo_articulo", codigo_articulo);

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




        //public articulo buscar_articulo(string codigo_articulo_marca, string codigo_articulo)
        //{
        //    Modulo_AdministracionContext db = new Modulo_AdministracionContext();
        //    try
        //    {
        //        articulo articulo = db.articulo.FirstOrDefault(a => a.codigo_articulo_marca == codigo_articulo_marca && a.codigo_articulo == codigo_articulo);

        //        return articulo;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        db = null;
        //    }


        //}

        public bool dar_de_baja_articulos_por_familia(int id_tabla_familia, Modulo_AdministracionContext db) //doy de baja los articulos de una familia
        {

            bool bandera = false;
            try
            {

                List<articulo> lista_articulos = (from p in db.articulo //listo
                                                  where p.id_tabla_familia == id_tabla_familia
                                                  select p).ToList();

                if (lista_articulos != null)
                {
                    foreach (articulo p in lista_articulos)
                    {
                        //pongo en factura_detalle NULL en el id_articulo enviado por parametro -> ya que se da de baja ese articulo , pero debe seguir figurando en el detalle de factura
                        if (modificar_id_articulo_en_factura_detalle(p.id_articulo, db) == false)
                        {
                            throw new Exception("Error al modificar id articulo en factura detalle");
                        }

                        p.fec_baja = DateTime.Today;
                        p.fecha_ult_modif = DateTime.Now;
                        p.accion = "ELIMINACION";
                    }
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


        //pongo en factura_detalle NULL en el id_articulo enviado por parametro -> ya que se da de baja ese articulo , pero debe seguir figurando en el detalle de factura
        public bool modificar_id_articulo_en_factura_detalle(long id_articulo, Modulo_AdministracionContext db)
        {

            bool bandera = false;
            try
            {

                List<factura_detalle> lista_factura_detalle = (from fd in db.factura_detalle
                                                               where fd.id_articulo == id_articulo
                                                               select fd).ToList();

                if (lista_factura_detalle != null)
                {
                    foreach (factura_detalle fd in lista_factura_detalle)
                    {
                        fd.id_articulo = null;
                    }
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

        public DataSet buscar_articulos(int id_proveedor, int id_tabla_marca, int id_tabla_familia, string cod_articulo, string descripcion)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;

            try
            {


                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("buscar_articulos_por_idProveedor_idTablaMarca_idTablaFamilia_codArticulo_descripcionArticulo", conn);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@id_proveedor", id_proveedor);
                    command.Parameters.AddWithValue("@id_tabla_marca", id_tabla_marca);
                    command.Parameters.AddWithValue("@id_tabla_familia", id_tabla_familia);
                    command.Parameters.AddWithValue("@cod_articulo", cod_articulo);
                    command.Parameters.AddWithValue("@descripcion", descripcion);


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

        public DataSet generar_listado(int nro_excel)
        {
            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;

            try
            {


                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("generar_excel_santiago", conn);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@nro_excel", nro_excel);


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


        public DataSet buscar_articulos()
        {

            SqlConnection conn = null;
            SqlDataReader reader = null;
            DataSet set2;

            try
            {


                DataSet dataSet = new DataSet("TimeRanges");
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString))
                {

                    SqlCommand command = new SqlCommand("buscar_articulos_todos", conn);
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




        public bool modificar_articulos_existentes(List<articulo> lista_articulo, Modulo_AdministracionContext db)
        {


            bool bandera = false;
            try
            {
                foreach (articulo a in lista_articulo)
                {
                    if (modificar_articulo(a, db) == false)
                    {
                        throw new Exception("Error al modificar los articulos");
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

        public bool modificar_articulo(articulo articulo, Modulo_AdministracionContext db)
        {
            try
            {

                bool bandera = false;
                articulo articulo_db = db.articulo.FirstOrDefault(f => f.id_articulo == articulo.id_articulo); //listo
                articulo_db.codigo_articulo = articulo.codigo_articulo;
                articulo_db.descripcion_articulo = articulo.descripcion_articulo;
                articulo_db.precio_lista = articulo.precio_lista;
                articulo_db.fecha_ult_modif = DateTime.Now;
                db.SaveChanges();
                bandera = true;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool alta_articulos_inexistentes(List<articulo> lista_articulo, Modulo_AdministracionContext db)
        {


            bool bandera = false;
            try
            {
                foreach (articulo articulo in lista_articulo)
                {
                    if (alta_articulo(articulo, db) == false)
                    {
                        throw new Exception("Error al dar de alta los articulos");
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

        public bool alta_articulo(articulo articulo, Modulo_AdministracionContext db)
        {
            try
            {
                bool bandera = false;
                articulo articulo_a_insertar = new articulo();
                familia familia_articulo = logica_familia.buscar_familia_por_id_tabla_familia(articulo.id_tabla_familia.Value);

                decimal algoritmo1 = 1;
                decimal algoritmo2 = 1;
                decimal algoritmo3 = 1;
                decimal algoritmo4 = 1;
                decimal algoritmo5 = 1;
                decimal algoritmo6 = 1;
                decimal algoritmo7 = 1;
                decimal algoritmo8 = 1;
                decimal algoritmo9 = 1;

                if (familia_articulo.algoritmo_1 != 0)
                {
                    algoritmo1 = familia_articulo.algoritmo_1;
                }
                if (familia_articulo.algoritmo_2 != 0)
                {
                    algoritmo2 = familia_articulo.algoritmo_2;
                }
                if (familia_articulo.algoritmo_3 != 0)
                {
                    algoritmo3 = familia_articulo.algoritmo_3;
                }
                if (familia_articulo.algoritmo_4 != 0)
                {
                    algoritmo4 = familia_articulo.algoritmo_4;
                }
                if (familia_articulo.algoritmo_5 != 0)
                {
                    algoritmo5 = familia_articulo.algoritmo_5;
                }
                if (familia_articulo.algoritmo_6 != 0)
                {
                    algoritmo6 = familia_articulo.algoritmo_6;
                }
                if (familia_articulo.algoritmo_7 != 0)
                {
                    algoritmo7 = familia_articulo.algoritmo_7;
                }
                if (familia_articulo.algoritmo_8 != 0)
                {
                    algoritmo8 = familia_articulo.algoritmo_8;
                }
                if (familia_articulo.algoritmo_9 != 0)
                {
                    algoritmo9 = familia_articulo.algoritmo_9;
                }



                //id_articulo es identity
                articulo_a_insertar.codigo_articulo_marca = familia_articulo.marca.txt_desc_marca;
                articulo_a_insertar.codigo_articulo = articulo.codigo_articulo;
                articulo_a_insertar.descripcion_articulo = articulo.descripcion_articulo;
                articulo_a_insertar.precio_lista = articulo.precio_lista;
                articulo_a_insertar.id_tabla_familia = articulo.id_tabla_familia;
                articulo_a_insertar.sn_oferta = 0;
                articulo_a_insertar.path_img = "";
                articulo_a_insertar.fecha_ult_modif = DateTime.Now;
                articulo_a_insertar.fec_baja = null;
                articulo_a_insertar.accion = "ALTA";

                int cantidad = db.articulo.Count();
                if (cantidad == 0)
                {
                    articulo_a_insertar.id_orden = 1;
                }
                else
                {
                    articulo_a_insertar.id_orden = db.articulo.Max(a => a.id_orden) + 1;
                }
                db.articulo.Add(articulo_a_insertar);
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
