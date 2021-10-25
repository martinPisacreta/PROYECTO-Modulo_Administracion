using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using Modulo_Administracion.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.XlsIO;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Modulo_Administracion
{
    public partial class frmImportarExcelProveedor : Form
    {

        Logica_Articulo logica_articulo = new Logica_Articulo();


        public frmImportarExcelProveedor()
        {
            try
            {
                InitializeComponent();
                Logica_Funciones_Generales.CargarComboBox("proveedor", cbProveedor, "razon_social", "sn_activo = -1", "razon_social", "id_proveedor");
                cbProveedor.Focus();
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
                tabControl1.Enabled = false;

                txtArchivoExcel.Text = "";
                txtArchivoExcel.Enabled = true;

                cbProveedor.Enabled = true;
                cbProveedor.SelectedItem = null;

                dgvExcelExistentes.DataSource = null;
                dgvExcelInexistentes.DataSource = null;
                dgvDatosErroneos.DataSource = null;

                

                panelSeteoPMF.Enabled = false;

                btnImportar.Enabled = true;
                btnBuscar.Enabled = false;

                cbMarca.DataSource = null;
                cbFamilia.DataSource = null;

                tabControl1.SelectedIndex = 0;

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
                if (cbProveedor.SelectedItem == null)
                {
                    cbProveedor.Focus();
                    throw new Exception("Debe seleccionar un proveedor");
                }
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
                    cbProveedor.Enabled = false;
                    dgvExcelExistentes.Enabled = true;
                    dgvExcelInexistentes.Enabled = true;

                    //el nombre del archivo sera asignado al textbox
                    txtArchivoExcel.Text = dialog.FileName;
                    hoja = "Articulo"; //la variable hoja tendra el valor del textbox donde colocamos el nombre de la hoja
                    Llenar_DataGridView(txtArchivoExcel.Text); //se manda a llamar al metodo


                    tabControl1.Enabled = true;



                    form.Hide();
                    Cursor.Current = Cursors.Default;


                }
                
            }
            catch (Exception ex)
            {
                form.Hide();
                txtArchivoExcel.Text = "";
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        

        private void Llenar_DataGridView(string archivo)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                

                try
                {

                    DataTable data_table_datos = new DataTable();


                    using (Stream inputStream = File.OpenRead(archivo))
                    {
                        using (ExcelEngine excelEngine = new ExcelEngine())
                        {
                            IApplication application = excelEngine.Excel;
                            IWorkbook workbook = application.Workbooks.Open(inputStream);
                            IWorksheet worksheet = workbook.Worksheets[0];

                            data_table_datos = worksheet.ExportDataTable(worksheet.UsedRange, ExcelExportDataTableOptions.ColumnNames);
                        }
                    }



                    List<DataRow> deletedRows = new List<DataRow>();
                    List<DataRow> addRows = new List<DataRow>();

                   

                    //elimino las columnas del data_table_datos_correctos con nro de columna mayor a 3
                    int desiredSize = 3;
                    while (data_table_datos.Columns.Count > desiredSize)
                    {
                        data_table_datos.Columns.RemoveAt(desiredSize);
                    }


                    foreach (DataRow row in data_table_datos.Rows)
                    {
                        //elimino los caracteres de mas del principio del string
                        string descripcion_articulo = row["descripcion_articulo"].ToString().TrimStart();
                        string codigo_articulo = row["codigo_articulo"].ToString().TrimStart();

                        //elimino los caracteres de mas del final del string
                        descripcion_articulo = descripcion_articulo.TrimEnd();
                        codigo_articulo = codigo_articulo.TrimEnd();

                        //reemplazo ' por -
                        descripcion_articulo = descripcion_articulo.Replace("'", "-");

                        codigo_articulo = codigo_articulo.Replace("'", "-");

                        //elimino los espacios en blanco de mas por uno solo espacio en blanco
                        row["descripcion_articulo"] = Regex.Replace(descripcion_articulo, @"\s+", " ");
                        row["codigo_articulo"] = Regex.Replace(codigo_articulo, @"\s+", " ");
                    }


                    //cargo los dataGridView
                    dgvExcelExistentes.DataSource = logica_articulo.buscar_articulos_en_relacion_a_dataTable(data_table_datos,1,Convert.ToInt32(cbProveedor.SelectedValue)).Tables[0];
                    dgvExcelInexistentes.DataSource = logica_articulo.buscar_articulos_en_relacion_a_dataTable(data_table_datos, 2, Convert.ToInt32(cbProveedor.SelectedValue)).Tables[0];
                    dgvDatosErroneos.DataSource = logica_articulo.buscar_articulos_en_relacion_a_dataTable(data_table_datos, 3, Convert.ToInt32(cbProveedor.SelectedValue)).Tables[0];
                       

                    if (dgvExcelInexistentes.Rows.Count > 0)
                    {
                        panelSeteoPMF.Enabled = true;
                        cbMarca.Enabled = true;
                        cargarCombos(2);
                    }

                    
                }
                catch (Exception ex)
                {
                    //en caso de haber una excepcion que nos mande un mensaje de error
                    throw new Exception(ex.Message);

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

        


        private void cargarCombos(int tipo)
        {
            try
            {
                if (tipo == 2) //limpio marca y familia y cargo las marcas
                {

                    cbMarca.DataSource = null;
                    cbFamilia.DataSource = null;
                    Logica_Funciones_Generales.CargarComboBox("marca", cbMarca, "txt_desc_marca", "id_proveedor = " + cbProveedor.SelectedValue + "and sn_activo = -1", "txt_desc_marca", "id_tabla_marca");

                    cbMarca.SelectedItem = null;
                    cbMarca.SelectedIndexChanged += new EventHandler(cbMarca_SelectedIndexChanged);

                }
                if (tipo == 3) // limpio familia y cargo familia 
                {
                    cbFamilia.DataSource = null;
                    Logica_Funciones_Generales.CargarComboBox("familia", cbFamilia, "txt_desc_familia", "id_tabla_marca = " + cbMarca.SelectedValue + "and sn_activo = -1", "txt_desc_familia", "id_tabla_familia");
                    cbFamilia.SelectedItem = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                if (cbMarca.SelectedItem != null && cbProveedor.SelectedItem != null) //si tengo algo elegido en el combo de proveedor y marca , cargo el combo de familia segun lo que dice proveedor y marca
                {
                    cbFamilia.Enabled = true;
                    cargarCombos(3);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private bool Hay_Celdas_Vacias(DataGridView dataGridView)
        {
            bool hay_celdas_vacias = false;
            int cantidad = 0;
            if (dataGridView.RowCount == 1)
            {
                cantidad = 1;
            }
            else
            {
                cantidad = dataGridView.RowCount - 1;
            }

            for (int i = 0; i < cantidad; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value == null || dataGridView.Rows[i].Cells[j].Value == "")
                    {
                        hay_celdas_vacias = true;
      
                    }
                }
            }
            return hay_celdas_vacias;
        }


        private void btnImportar_Click(object sender, EventArgs e)
        {
            frmEspere form = new frmEspere();
            articulo articulo = null;
            List<articulo> lista_articulos = null;
            Modulo_AdministracionContext db = new Modulo_AdministracionContext();
            Cursor.Current = Cursors.WaitCursor;
            form.Show();
            using (DbContextTransaction dbContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    if (dgvExcelExistentes.Rows.Count == 0 && dgvExcelInexistentes.Rows.Count == 0)
                    {
                        throw new Exception("No hay registros para importar");
                    }

                   



                    if (dgvExcelExistentes.Rows.Count != 0)
                    {
                        lista_articulos = new List<articulo>() { };
                        foreach (DataGridViewRow row in dgvExcelExistentes.Rows)
                        {
                            articulo = new articulo();
                            articulo.codigo_articulo = row.Cells[0].Value.ToString();
                            articulo.descripcion_articulo = row.Cells[1].Value.ToString();
                            articulo.precio_lista = Convert.ToDecimal(row.Cells[2].Value);
                            articulo.id_articulo = Convert.ToInt32(row.Cells[3].Value);
                            lista_articulos.Add(articulo);
                        }


                        if (logica_articulo.modificar_articulos_existentes(lista_articulos,db) == false)
                        {
                            throw new Exception("Error al actualizar los articulos EXISTENTES");
                        }

                        lista_articulos = null;

                    }

                    if (dgvExcelInexistentes.Rows.Count != 0)
                    {

                        if (Hay_Celdas_Vacias(dgvExcelInexistentes) == true)
                        {
                            tabControl1.SelectedIndex = 1;
                            dgvExcelInexistentes.Focus();
                            throw new Exception("No puede haber celdas vacias en articulos INEXISTENTES");
                        }

                        lista_articulos = new List<articulo>() { };
                        foreach (DataGridViewRow row in dgvExcelInexistentes.Rows)
                        {
                            articulo = new articulo();
                            articulo.codigo_articulo = row.Cells[0].Value.ToString();
                            articulo.descripcion_articulo = row.Cells[1].Value.ToString();
                            articulo.precio_lista = Convert.ToDecimal(row.Cells[2].Value);
                            articulo.id_tabla_familia = Convert.ToInt32(row.Cells[3].Value);
                            articulo.id_articulo = Convert.ToInt32(row.Cells[4].Value);
                            lista_articulos.Add(articulo);
                        }


                        if (logica_articulo.alta_articulos_inexistentes(lista_articulos,db) == false)
                        {
                            throw new Exception("Error al actualizar los articulos INEXISTENTES");
                        }

                        lista_articulos = null;

                    }

                    MessageBox.Show("Importación de articulos correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dbContextTransaction.Commit();
                    limpio_form();
                    form.Hide();
                    Cursor.Current = Cursors.Default;

                    
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    form.Hide();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db = null;
                    form.Hide();
                    Cursor.Current = Cursors.Default;
                }
            }


            
           
        }

     

        private void btnCancelarPMF_Click(object sender, EventArgs e)
        {
            try
            {
                cbMarca.SelectedIndexChanged -= new EventHandler(cbMarca_SelectedIndexChanged);

                
                cbMarca.SelectedItem = null;
                cbFamilia.SelectedItem = null;

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            try
            {

                if (dgvExcelInexistentes.SelectedRows.Count > 0)
                {

                    if (cbProveedor.SelectedItem == null)
                    {
                        cbProveedor.Focus();
                        throw new Exception("Debe seleccionar un proveedor");
                    }

                    if (cbMarca.SelectedItem == null)
                    {
                        cbMarca.Focus();
                        throw new Exception("Debe seleccionar una marca");
                    }

                    if (cbFamilia.SelectedItem == null)
                    {
                        cbFamilia.Focus();
                        throw new Exception("Debe seleccionar una familia");
                    }

                    foreach (DataGridViewRow row in dgvExcelInexistentes.SelectedRows)
                    {
                        row.Cells["id_tabla_familia"].Value = Convert.ToInt32(cbFamilia.SelectedValue);
                    }

                    MessageBox.Show("Acción realizada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    throw new Exception("Debe seleccionar al menos una fila");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string origen = Path.Combine(Application.StartupPath, @"Documento\Libro1.xlsx");
                string destino = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Libro1.xlsx" ;
                System.IO.File.Copy(origen, destino, true);

                Process.Start(destino);

                btnBuscar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbProveedor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                
                btnBuscar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarFilas_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            try
            {

                if (dgvExcelInexistentes.SelectedRows.Count > 0)
                {

                    foreach (DataGridViewRow row in dgvExcelInexistentes.SelectedRows)
                    {
                        dgvExcelInexistentes.Rows.RemoveAt(row.Index);
                    }

                    if (dgvExcelInexistentes.SelectedRows.Count == 1)
                    {
                        MessageBox.Show("Fila realizada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dgvExcelInexistentes.SelectedRows.Count > 1)
                    {
                        MessageBox.Show("Filas realizada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    throw new Exception("Debe seleccionar al menos una fila");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }
        }
    }


}

