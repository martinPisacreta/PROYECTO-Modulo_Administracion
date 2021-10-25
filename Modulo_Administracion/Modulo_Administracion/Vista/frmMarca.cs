
using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using System;
using System.Windows.Forms;

namespace Modulo_Administracion
{
    public partial class frmMarca : Form
    {
        proveedor proveedor = null;
        marca marca = null;
        Logica_Familia logica_familia = new Logica_Familia();
        Logica_Marca logica_marca = new Logica_Marca();
        Logica_Proveedor logica_proveedor = new Logica_Proveedor();
        int Accion;


        private void dgvMarca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmFamilia form = new frmFamilia(marca);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public frmMarca(proveedor _proveedor)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                InitializeComponent();

                proveedor = _proveedor;
                Logica_Funciones_Generales.CargarComboBox("proveedor", cbProveedor, "razon_social", "sn_activo = -1", "razon_social", "id_proveedor");

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

        private void limpio_form()
        {
            try
            {

                txtCodigo.Text = "";
                txtMarca.Text = "";


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void iniciar(int queHago)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                txtCodigo.Enabled = false;
                btnSalir.Enabled = true;

                txtMarca.Enabled = true;
                cbProveedor.Enabled = true;
                dgvMarca.Enabled = true;




                switch (queHago)
                {
                    case Program.Inicio:
                        {

                            //limpio todo el form , excepto el datagridview
                            limpio_form();

                            //modifico  enabled - visible - text 
                            txtMarca.Enabled = false;
                            cbProveedor.Enabled = false;


                            btnNuevo.Enabled = true;
                            btnAgregar.Visible = false;
                            btnCancelarSeleccion.Visible = false;
                            btnBorrar.Visible = false;

                            //cargo combos y lo seteo como vacio el primer item
                            cbProveedor.SelectedItem = null;

                            //datagridview
                            dgvMarca.DataSource = null;

                            if (proveedor == null)
                            {
                                //esto sirve para ordenar las columnas con click del usuario
                                //SortableBindingList<marca> order = new SortableBindingList<marca>(logica_marca.buscar_marcas());
                                dgvMarca.DataSource = logica_marca.buscar_marcas_activas();

                            }
                            else
                            {
                                //esto sirve para ordenar las columnas con click del usuario
                                //SortableBindingList<marca> order = new SortableBindingList<marca>(logica_marca.buscar_marcas_por_proveedor(proveedor.id_proveedor));
                                dgvMarca.DataSource = logica_marca.buscar_marcas_activas_por_proveedor(proveedor.id_proveedor);
                            }


                            //seteo columnas
                            seteoColumnasDataGridView();

                            //limpio cualquier seleccion en el datagridview
                            dgvMarca.ClearSelection();

                            //accion
                            Accion = Program.Inicio;

                            dgvMarca.Focus();

                            break;
                        }

                    case Program.Alta:
                        {
                            //limpio todo el form , excepto el datagridview
                            limpio_form();

                            ///modifico  enabled - visible - text 
                            btnNuevo.Enabled = false;
                            btnAgregar.Visible = true;
                            btnCancelarSeleccion.Visible = true;
                            btnAgregar.Text = "Agregar";



                            if (proveedor == null)
                            {
                                cbProveedor.SelectedItem = null;
                                cbProveedor.Enabled = true;
                            }
                            else
                            {
                                cbProveedor.SelectedValue = proveedor.id_proveedor;
                                cbProveedor.Enabled = false;
                            }


                            //accion
                            Accion = Program.Alta;

                            //genero una marca vacia
                            marca = new marca();
                            marca.id_tabla_marca = 0;
                            marca.id_marca = 0;
                            marca.id_proveedor = Convert.ToInt32(cbProveedor.SelectedValue);
                            marca.txt_desc_marca = "";
                            marca.sn_activo = -1;
                            marca.fec_ult_modif = DateTime.Now;
                            marca.accion = "ALTA";
                            marca.path_img = "";
                            marca.familia = null;
                            if (proveedor == null)
                            {
                                marca.proveedor = null;
                            }
                            else
                            {
                                marca.proveedor = proveedor;
                            }


                            //datagridview
                            dgvMarca.Enabled = false;

                            break;
                        }

                    case Program.Modif:
                        {


                            //modifico  enabled - visible - text 
                            btnNuevo.Enabled = false;
                            btnAgregar.Visible = true;
                            btnCancelarSeleccion.Visible = true;
                            btnBorrar.Enabled = true;
                            btnBorrar.Visible = true;
                            btnAgregar.Text = "Modificar";

                            //accion
                            Accion = Program.Modif;

                            break;
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



                dgvMarca.Columns[0].Width = 100; //el [0] hace referencia a id_tabla_marca
                dgvMarca.Columns[0].HeaderText = "Id Marca"; //el [0] hace referencia a id_tabla_marca
                dgvMarca.Columns[1].Width = 152;
                dgvMarca.Columns[1].HeaderText = "Marca";
                dgvMarca.Columns[2].Width = 152;
                dgvMarca.Columns[2].HeaderText = "Proveedor";

                foreach (DataGridViewColumn column in dgvMarca.Columns)
                {
                    if (column.Index > 2)
                    {
                        column.Visible = false;
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.RowIndex >= 0)
                {

                    marca = logica_marca.buscar_marca_por_id_tabla_marca(Convert.ToInt32(dgvMarca.Rows[e.RowIndex].Cells[0].Value));
                    txtCodigo.Text = marca.id_tabla_marca.ToString();
                    txtMarca.Text = marca.txt_desc_marca;
                    cbProveedor.SelectedValue = marca.proveedor.id_proveedor;
                    txtMarca.Focus();
                    iniciar(Program.Modif);
                }
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
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                Valido();
                SeteoObjeto();

                if (Accion == 1) // alta
                {

                    if (MessageBox.Show("¿Confirma agregar una marca?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (logica_marca.alta_marca(marca) == false)
                    {
                        MessageBox.Show("Error al grabar la marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Grabación Exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Accion == 2) //Modificacion
                {

                    if (MessageBox.Show("¿Confirma modificar la marca " + txtMarca.Text + " ?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (logica_marca.modificar_eliminar_marca(marca, 1) == false)
                    {
                        MessageBox.Show("Error al modificar la marca " + txtMarca.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show(txtMarca.Text + " modificación exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                marca = null;
                iniciar(Program.Inicio);


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

        private void Valido()
        {
            int id_tabla_marca = 0;
            try
            {
                if (txtCodigo.Text == "" && Accion != 1)
                {
                    txtCodigo.Focus();
                    throw new Exception("Debe ingresar un código");
                }
                if (txtMarca.Text == "")
                {
                    txtMarca.Focus();
                    throw new Exception("Debe ingresar una marca");
                }
                if (cbProveedor.SelectedValue == null)
                {
                    cbProveedor.Focus();
                    throw new Exception("Debe seleccionar un proveedor");
                }

                if (txtCodigo.Text != "")
                {
                    id_tabla_marca = Convert.ToInt32(txtCodigo.Text);
                }
                if (logica_marca.buscar_marca_por_txt_desc_activo(txtMarca.Text, id_tabla_marca) != null)
                {
                    txtMarca.Focus();
                    throw new Exception("Ya existe una marca con ese nombre");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // Valido la entrada de datos


        private void SeteoObjeto() // Creo los campos restantes del objeto
        {
            try
            {


                marca.id_proveedor = Convert.ToInt32(cbProveedor.SelectedValue);
                marca.txt_desc_marca = txtMarca.Text;
                marca.proveedor = logica_proveedor.buscar_proveedor(marca.id_proveedor);



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                txtMarca.Focus();
                iniciar(Program.Alta);
                //txtCodigo.Text = (logica_marca.ult_nro_marca() + 1).ToString();
                //SeteoObjeto();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                SeteoObjeto();
                if (MessageBox.Show("¿Confirma eliminar la marca " + txtMarca.Text + "?\nTenga en cuenta que al eliminarla se eliminan tambien las familias de la misma y todo lo asociado a esas familias", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (logica_marca.modificar_eliminar_marca(marca, 2) == false)
                {
                    MessageBox.Show("Error al eliminar la marca " + txtMarca.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(txtMarca.Text + " elimado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                marca = null;
                iniciar(Program.Inicio);
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

        private void btnCancelarSeleccion_Click(object sender, EventArgs e)
        {
            try
            {
                marca = null;
                iniciar(Program.Inicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            try
            {
                iniciar(Program.Inicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void txtMarca_Leave(object sender, EventArgs e)
        {
            try
            {
                txtMarca.Text = txtMarca.Text.ToUpper();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}

