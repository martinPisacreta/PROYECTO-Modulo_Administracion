using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using Modulo_Administracion.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modulo_Administracion
{
    public partial class frmImportarExcel : Form
    {

        public frmImportarExcel()
        {
            try
            {
                InitializeComponent();
                btnBuscar.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarSeleccion_Click(object sender, EventArgs e)
        {
            try
            {
                limpio_form();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpio_form()
        {
            try
            {
                txtArchivoExcel.Text = "";
                txtArchivoExcel.Enabled = true;
                dgvExcel.Enabled = false;
                dgvExcel.DataSource = null;
                btnImportar.Enabled = true;
                btnBuscar.Enabled = true;
                lblCantidad.Visible = false;
                dgvExcel.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmEspere form = new frmEspere();
            try
            {
                
                string hoja = "";
                //creamos un objeto OpenDialog que es un cuadro de dialogo para buscar archivos
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Archivos de Excel (*.xls;*.xlsx;*.xlsm)|*.xls;*.xlsx;*.xlsm"; //le indicamos el tipo de filtro en este caso que busque solo los archivos excel

                dialog.Title = "Seleccione el archivo de Excel";//le damos un titulo a la ventana

                dialog.FileName = string.Empty;//inicializamos con vacio el nombre del archivo

                //si al seleccionar el archivo damos Ok
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    form.Show();
                    txtArchivoExcel.Enabled = false;
                    dgvExcel.Enabled = true;

                    //el nombre del archivo sera asignado al textbox
                    txtArchivoExcel.Text = dialog.FileName;
                    hoja = "Articulo"; //la variable hoja tendra el valor del textbox donde colocamos el nombre de la hoja
                    Llenar_DataGridView(txtArchivoExcel.Text, hoja); //se manda a llamar al metodo


                    



                    form.Hide();
                    Cursor.Current = Cursors.Default;


                }
                
            }
            catch (Exception ex)
            {
                form.Hide();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        

        private void Llenar_DataGridView(string archivo, string hoja)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                
                //declaramos las variables         
                OleDbConnection conexion = null;
                DataSet dataSet = null;
                OleDbDataAdapter dataAdapter = null;
                string consultaHojaExcel = "Select * from [" + hoja + "$]";

                //esta cadena es para archivos excel 2007 y 2010
                string cadenaConexionArchivoExcel = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + archivo + "';Extended Properties=Excel 12.0;";

                //para archivos de 97-2003 usar la siguiente cadena
                //string cadenaConexionArchivoExcel = "provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + archivo + "';Extended Properties=Excel 8.0;";

                //Validamos que el usuario ingrese el nombre de la hoja del archivo de excel a leer
                if (string.IsNullOrEmpty(hoja))
                {
                    MessageBox.Show("No hay una hoja para leer");
                }
                else
                {
                    try
                    {
                        //Si el usuario escribio el nombre de la hoja se procedera con la busqueda
                        conexion = new OleDbConnection(cadenaConexionArchivoExcel);//creamos la conexion con la hoja de excel
                        conexion.Open(); //abrimos la conexion
                        dataAdapter = new OleDbDataAdapter(consultaHojaExcel, conexion); //traemos los datos de la hoja y las guardamos en un dataSdapter
                        dataSet = new DataSet(); // creamos la instancia del objeto DataSet
                        dataAdapter.Fill(dataSet, hoja);//llenamos el dataset

                        DataTable data_table_datos = new DataTable();

                        List<DataRow> deletedRows = new List<DataRow>();
                        List<DataRow> addRows = new List<DataRow>();

                        data_table_datos = dataSet.Tables[0];

                        //elimino las columnas del data_table_datos_correctos con nro de columna mayor a 12 [stock]
                        int desiredSize = 12;
                        while (data_table_datos.Columns.Count > desiredSize)
                        {
                            data_table_datos.Columns.RemoveAt(desiredSize);
                        }

                        //elimino la columna coeficiente
                        data_table_datos.Columns.Remove("coeficiente");

                        //elimino la columna id_orden
                        data_table_datos.Columns.Remove("id_orden");

                        //genero una columna nueva id_orden , pero calculado desde c#
                        DataColumn c = new DataColumn();
                        c.DataType = System.Type.GetType("System.Int32");
                        c.ColumnName = "id_orden";
                        c.AutoIncrement = true;
                        c.AutoIncrementSeed = 2;
                        c.AutoIncrementStep = 1;
                        data_table_datos.Columns.Add(c);
                        int index = 1;
                        foreach (DataRow row in data_table_datos.Rows)
                        {
                            row.SetField(c, ++index);
                        }


                        foreach (DataRow row in data_table_datos.Rows)
                        {
                            //elimino los caracteres de mas del principio del string
                            string descripcion_articulo = row["descripcion_articulo"].ToString().TrimStart();
                            string codigo_articulo_marca = row["codigo_articulo_marca"].ToString().TrimStart();
                            string codigo_articulo = row["codigo_articulo"].ToString().TrimStart();

                            //elimino los caracteres de mas del final del string
                            descripcion_articulo = descripcion_articulo.TrimEnd();
                            codigo_articulo_marca = codigo_articulo_marca.TrimEnd();
                            codigo_articulo = codigo_articulo.TrimEnd();

                            //reemplazo ' por -
                            descripcion_articulo = descripcion_articulo.Replace("'", "-");
                            codigo_articulo_marca = codigo_articulo_marca.Replace("'", "-");
                            codigo_articulo = codigo_articulo.Replace("'", "-");

                            //elimino los espacios en blanco de mas por uno solo espacio en blanco
                            row["descripcion_articulo"] =  Regex.Replace(descripcion_articulo, @"\s+", " ");
                            row["codigo_articulo_marca"] = Regex.Replace(codigo_articulo_marca, @"\s+", " ");
                            row["codigo_articulo"] = Regex.Replace(codigo_articulo, @"\s+", " ");
                        }



                        //cargo los dataGridView
                        dgvExcel.DataSource = data_table_datos; //le asignamos al DataGridView el contenido del data_table_datos_correctos

                       

                        lblCantidad.Visible = true;
                        lblCantidad.Text = "Cantidad de registros en la grilla : " + dgvExcel.Rows.Count.ToString();

                        //pongo que todas las columnas se puedan ordenar si el usuario hace click en la columna
                        foreach (DataGridViewColumn column in dgvExcel.Columns)
                        {

                            column.SortMode = DataGridViewColumnSortMode.Automatic;
                        }

                       
                        conexion.Close();//cerramos la conexion
                        


                    }
                    catch (Exception ex)
                    {
                        //en caso de haber una excepcion que nos mande un mensaje de error
                        throw new Exception(ex.Message);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }


   

        


        private void frmImportarExcel_Load(object sender, EventArgs e)
        {
            try
            {
                limpio_form();
            }
            catch (Exception ex)
            {
                //en caso de haber una excepcion que nos mande un mensaje de error
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            frmEspere form = new frmEspere();
            try
            {
                if (dgvExcel.Rows.Count == 0)
                {
                    MessageBox.Show("No hay registros para importar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                form.Show();

                Logica_Articulo logica_articulo = new Logica_Articulo();
                dgvExcel.DataSource = logica_articulo.alta_articulos_a_tabla_articulo_por_metodo_subida_excel(GetDataGridViewAsDataTable(dgvExcel)).Tables[0];
                dgvExcel.Refresh();

                lblCantidad.Visible = true;
                lblCantidad.Text = "Cantidad de registros en la grilla : " + dgvExcel.Rows.Count.ToString();

                form.Hide();
                Cursor.Current = Cursors.Default;
                
                if(dgvExcel.Rows.Count == 0)
                {
                    MessageBox.Show("Importación de Excel correcta", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    btnImportar.Enabled = false;
                    btnBuscar.Enabled = false;
                    MessageBox.Show("Algunos articulos no se pudieron importar , en la ultima columna se explica la razon", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
               
                
            }
            catch (Exception ex)
            {
                form.Hide();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

                
                
            }
        }

     

        private DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView)
        {
            try
            {
                if (_DataGridView.ColumnCount == 0) return null;
                DataTable dtSource = new DataTable();
                //////create columns
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.ValueType == null) dtSource.Columns.Add(col.Name, typeof(string));
                    else dtSource.Columns.Add(col.Name, col.ValueType);
                    dtSource.Columns[col.Name].Caption = col.HeaderText;
                }
                ///////insert row data
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        drNewRow[col.ColumnName] = row.Cells[col.ColumnName].Value;
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                return dtSource;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

       
    }


}

