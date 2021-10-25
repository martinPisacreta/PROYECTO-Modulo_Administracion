using Microsoft.VisualBasic;
using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using Modulo_Administracion.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modulo_Administracion
{
    public partial class frmArticulo : Form
    {

        articulo articulo = null;

        Logica_Proveedor logica_proveedor = new Logica_Proveedor();
        Logica_Marca logica_marca = new Logica_Marca();
        Logica_Familia logica_familia = new Logica_Familia();
        Logica_Articulo logica_articulo = new Logica_Articulo();

        familia familia;

        

        public frmArticulo(familia _familia)
        {
            try
            {
                InitializeComponent();
                familia = _familia;
                iniciar(familia);
     

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void iniciar(familia familia)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                dgvArticulo.DataSource = null;

                cbMarca.SelectedIndexChanged -= new EventHandler(cbMarca_SelectedIndexChanged);
                cbProveedor.SelectedIndexChanged -= new EventHandler(cbProveedor_SelectedIndexChanged);


                cbProveedor.DataSource = null;
                cbMarca.DataSource = null;
                cbFamilia.DataSource = null;

                cbProveedor.Enabled = false;
                cbMarca.Enabled = false;
                cbFamilia.Enabled = false;

                chkTodosProveedor.Checked = true;
                chkTodosMarca.Checked = false;
                chkTodosFamilia.Checked = false;

                chkTodosProveedor.Enabled = true;
                chkTodosMarca.Enabled = false;
                chkTodosFamilia.Enabled = false;

              
                txtDescripcion.Text = "";
                txtCodArticulo.Text = "";

                txtPorcentaje.Text = "";


                cargarCombos(1);

                cbProveedor.Focus();

                if (familia != null)
                {
                    if (familia.marca.proveedor.id_proveedor > 0 && familia.id_tabla_marca > 0 && familia.id_familia > 0)
                    {
                        cbProveedor.SelectedValue = familia.marca.proveedor.id_proveedor;
                        cbMarca.SelectedValue = familia.id_tabla_marca;
                        cbFamilia.SelectedValue = familia.id_tabla_familia;
                        buscar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void seteoColumnasDataGridView()
        {
            try
            {
                //pongo que todas las columnas se puedan ordenar si el usuario hace click en la columna
                foreach (DataGridViewColumn column in dgvArticulo.Columns)
                {

                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }


                dgvArticulo.Columns[0].Visible = false;
                dgvArticulo.Columns[1].Visible = false;

                dgvArticulo.Columns[2].Visible = true;
                dgvArticulo.Columns[2].Width = 100;

                dgvArticulo.Columns[3].Visible = true;
                dgvArticulo.Columns[3].Width = 300;

                dgvArticulo.Columns[4].Visible = true;
                dgvArticulo.Columns[4].Width = 100;

                dgvArticulo.Columns[5].Visible = true;
                dgvArticulo.Columns[5].Width = 100;

                dgvArticulo.Columns[6].Visible = true;
                dgvArticulo.Columns[6].Width = 100;

                dgvArticulo.Columns[7].Visible = false;
                dgvArticulo.Columns[8].Visible = false;

                dgvArticulo.Columns[9].Visible = true;
                dgvArticulo.Columns[9].Width = 200;




            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void cargarCombos(int tipo)
        {
            try
            {
                if (tipo == 1) //limpio todo y cargo los proveedores
                {
                    cbProveedor.DataSource = null;
                    cbMarca.DataSource = null;
                    cbFamilia.DataSource = null;

                    cbProveedor.Enabled = false;
                    Logica_Funciones_Generales.CargarComboBox("proveedor", cbProveedor, "razon_social", "sn_activo = -1", "razon_social", "id_proveedor");

                    cbProveedor.SelectedItem = null;
                    cbProveedor.SelectedIndexChanged += new EventHandler(cbProveedor_SelectedIndexChanged);
                }
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


        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                if (cbProveedor.SelectedItem != null) //si tengo algo elegido en el combo de proveedor , cargo el combo de marca segun lo que dice proveedor
                {
                    cbMarca.Enabled = true;
                    chkTodosMarca.Enabled = true;
                    cargarCombos(2);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {

                if (cbMarca.SelectedItem != null && cbProveedor.SelectedItem != null) //si tengo algo elegido en el combo de proveedor y marca , cargo el combo de familia segun lo que dice proveedor y marca
                {
                    cbFamilia.Enabled = true;
                    chkTodosFamilia.Enabled = true;
                    cargarCombos(3);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {

                iniciar(familia);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void chkTodosProveedor_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                cbProveedor.SelectedItem = null;
                cbMarca.SelectedItem = null;
                cbFamilia.SelectedItem = null;
                if (chkTodosProveedor.Checked == true)
                {

                    cbProveedor.Enabled = false;

                    cbMarca.Enabled = false;
                    chkTodosMarca.Checked = true;
                    chkTodosMarca.Enabled = false;

                    cbFamilia.Enabled = false;
                    chkTodosFamilia.Checked = true;
                    chkTodosFamilia.Enabled = false;
                }
                else
                {
                    cbProveedor.Enabled = true;

                    chkTodosMarca.Checked = false;

                    chkTodosFamilia.Checked = false;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTodosMarca_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                cbMarca.SelectedItem = null;
                cbFamilia.SelectedItem = null;
                if (chkTodosMarca.Checked == true)
                {
                    cbMarca.Enabled = false;


                    cbFamilia.Enabled = false;
                    chkTodosFamilia.Checked = true;
                    chkTodosFamilia.Enabled = false;

                }
                else
                {
                    cbMarca.Enabled = true;

                    chkTodosFamilia.Checked = false;

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTodosFamilia_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                cbFamilia.SelectedItem = null;
                if (chkTodosFamilia.Checked == true)
                {
                    cbFamilia.Enabled = false;
                }
                else
                {
                    cbFamilia.Enabled = true;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

     

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }


        private void buscar()
        {
            frmEspere form = new frmEspere();
            try
            {
                
                Cursor.Current = Cursors.WaitCursor;
                form.Show();
                int id_proveedor = -999;
                int id_tabla_marca = -999;
                int id_tabla_familia = -999;


                if (cbProveedor.SelectedItem != null)
                {
                    id_proveedor = Convert.ToInt32(cbProveedor.SelectedValue);
                }

                if (cbMarca.SelectedItem != null)
                {
                    id_tabla_marca = Convert.ToInt32(cbMarca.SelectedValue);
                }

                if (cbFamilia.SelectedItem != null)
                {
                    id_tabla_familia = Convert.ToInt32(cbFamilia.SelectedValue);
                }


                dgvArticulo.DataSource = null;
                dgvArticulo.DataSource = logica_articulo.buscar_articulos(id_proveedor, id_tabla_marca, id_tabla_familia, txtCodArticulo.Text, txtDescripcion.Text).Tables[0];
                seteoColumnasDataGridView();
                form.Hide();
                Cursor.Current = Cursors.Default;


            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                form.Hide();
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                buscar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                buscar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void irAProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmProveedor proveedor = new frmProveedor();
                proveedor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void irAMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmMarca marca = new frmMarca(null);
                marca.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void irAFamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmFamilia familia = new frmFamilia(null);
                familia.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //foreach (DataGridViewRow row in dtaPagos.Rows)
                //{
                //    MessageBox.Show(row.Cells["Pago"].Value.ToString());
                //    MessageBox.Show(row.Cells["Cantidad"].Value.ToString());
                //    MessageBox.Show(row.Cells["Observaciones"].Value.ToString());
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void porListaDePreciosDeProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                proveedor _proveedor = null;
                marca _marca = null;
                familia _familia = null;


                if (cbProveedor.SelectedItem != null)
                {
                    _proveedor = logica_proveedor.buscar_proveedor(Convert.ToInt32(cbProveedor.SelectedValue));
                }
                else
                {
                    cbProveedor.Focus();
                    throw new Exception("Debe seleccionar un proveedor al cual va a actualizar los precios");
                }

                if (cbMarca.SelectedItem != null)
                {
                    _marca = logica_marca.buscar_marca_por_id_tabla_marca(Convert.ToInt32(cbMarca.SelectedValue));
                }
                else
                {
                    cbMarca.Focus();
                    throw new Exception("Debe seleccionar una marca al cual va a actualizar los precios");
                }

                if (cbFamilia.SelectedItem != null)
                {
                    _familia = logica_familia.buscar_familia_por_id_tabla_familia(Convert.ToInt32(cbFamilia.SelectedValue));
                }

                //frmActualizarPrecioPorListaProveedor form = new frmActualizarPrecioPorListaProveedor(_proveedor,_marca,_familia);
                //form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPorcentaje_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPorcentaje.Text != "")
                {
                    if (Convert.ToInt32(txtPorcentaje.Text) > 100)
                    {
                        txtPorcentaje.Text = "";
                        throw new Exception("El porcentaje no puede ser mayor a 100");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try 
            { 

                Logica_Articulo logica_articulo = new Logica_Articulo();
                if (txtPorcentaje.Text == "")
                {
                    txtPorcentaje.Focus();
                    throw new Exception("Debe escribir un porcentaje");
                }
                if (dgvArticulo.Rows.Count == 0)
                {
                    throw new Exception("No hay registros para actualizar");
                   
                }
                DataTable dt = GetDataGridViewAsDataTable(dgvArticulo, Convert.ToInt32(txtPorcentaje.Text));
                if (MessageBox.Show("¿Desea actualizar un " + txtPorcentaje.Text + "% los articulos visualizados?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                logica_articulo.modificar_datos_a_tabla_articulo_por_metodo_actualizar_porcentaje(dt);
                MessageBox.Show("Actualización correcta", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buscar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private DataTable GetDataGridViewAsDataTable(DataGridView _DataGridView,int porcentaje)
        {
            try
            {
                decimal valor;
                if (_DataGridView.ColumnCount == 0) return null;
                DataTable dtSource = new DataTable();
                //////create columns
                foreach (DataGridViewColumn col in _DataGridView.Columns)
                {
                    if (col.Name == "id_articulo" || col.Name == "Precio Lista")
                    {
                        if (col.ValueType == null) dtSource.Columns.Add(col.Name, typeof(string));
                        else dtSource.Columns.Add(col.Name, col.ValueType);
                        dtSource.Columns[col.Name].Caption = col.HeaderText;
                    }
                }
                ///////insert row data
                foreach (DataGridViewRow row in _DataGridView.Rows)
                {
                    DataRow drNewRow = dtSource.NewRow();
                    foreach (DataColumn col in dtSource.Columns)
                    {
                        if (col.ColumnName == "id_articulo" || col.ColumnName == "Precio Lista")
                        {
                            if (col.ColumnName == "Precio Lista")
                            {
                                valor = ((Convert.ToDecimal(row.Cells[col.ColumnName].Value)) * porcentaje) / 100;
                                drNewRow[col.ColumnName] = (Convert.ToDecimal(row.Cells[col.ColumnName].Value)) + valor;
                            }
                            else
                            {
                                drNewRow[col.ColumnName] = (Convert.ToDecimal(row.Cells[col.ColumnName].Value));
                            }
                        }
                    }
                    dtSource.Rows.Add(drNewRow);
                }
                return dtSource;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
