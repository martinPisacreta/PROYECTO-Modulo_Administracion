
using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using System;
using System.Windows.Forms;

namespace Modulo_Administracion
{
    public partial class frmFamilia : Form
    {


        marca marca = null;
        familia familia = null;
        Logica_Marca logica_marca = new Logica_Marca();
        Logica_Familia logica_familia = new Logica_Familia();
        int Accion;

        decimal algoritmo1;
        decimal algoritmo2;
        decimal algoritmo3;
        decimal algoritmo4;
        decimal algoritmo5;
        decimal algoritmo6;
        decimal algoritmo7;
        decimal algoritmo8;
        decimal algoritmo9;
        decimal algoritmo10;


        private void dgvFamilia_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmArticulo form = new frmArticulo(familia);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmFamilia(marca _marca)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                InitializeComponent();
                marca = _marca;

                if (marca == null)
                {
                    Logica_Funciones_Generales.CargarComboBox("proveedor", cbProveedor, "razon_social", "sn_activo = -1", "razon_social", "id_proveedor");
                }
                else
                {
                    Logica_Funciones_Generales.CargarComboBox("proveedor", cbProveedor, "razon_social", "id_proveedor = " + marca.id_proveedor + "and sn_activo = -1", "razon_social", "id_proveedor");
                    Logica_Funciones_Generales.CargarComboBox("marca", cbMarca, "txt_desc_marca", "id_proveedor = " + marca.id_proveedor + "and sn_activo = -1", "txt_desc_marca", "id_tabla_marca");
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

        private void limpio_form()
        {
            try
            {

                txtCodigo.Text = "";
                txtFamilia.Text = "";

                cbMarca.DataSource = null;

                txtAlgoritmo_1.Text = Convert.ToDecimal("0,0000").ToString("N4");
                txtAlgoritmo_2.Text = Convert.ToDecimal("0,0000").ToString("N4");
                txtAlgoritmo_3.Text = Convert.ToDecimal("0,0000").ToString("N4");
                txtAlgoritmo_4.Text = Convert.ToDecimal("0,0000").ToString("N4");
                txtAlgoritmo_5.Text = Convert.ToDecimal("0,0000").ToString("N4");
                txtAlgoritmo_6.Text = Convert.ToDecimal("0,0000").ToString("N4");
                txtAlgoritmo_7.Text = Convert.ToDecimal("0,0000").ToString("N4");
                txtAlgoritmo_8.Text = Convert.ToDecimal("0,0000").ToString("N4");
                txtAlgoritmo_9.Text = Convert.ToDecimal("0,0000").ToString("N4");
                txtAlgoritmo_10.Text = Convert.ToDecimal("0,0000").ToString("N4");

                lblCoeficiente_sin_beneficio.Text = "";
                lblCoeficiente_con_beneficio.Text = "";

                algoritmo1 = 1;
                algoritmo2 = 1;
                algoritmo3 = 1;
                algoritmo4 = 1;
                algoritmo5 = 1;
                algoritmo6 = 1;
                algoritmo7 = 1;
                algoritmo8 = 1;
                algoritmo9 = 1;
                algoritmo10 = 1;

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


                txtFamilia.Enabled = true;
                cbMarca.Enabled = true;
                dgvFamilia.Enabled = true;


                txtAlgoritmo_1.Enabled = true;
                txtAlgoritmo_2.Enabled = true;
                txtAlgoritmo_3.Enabled = true;
                txtAlgoritmo_4.Enabled = true;
                txtAlgoritmo_5.Enabled = true;
                txtAlgoritmo_6.Enabled = true;
                txtAlgoritmo_7.Enabled = true;
                txtAlgoritmo_8.Enabled = true;
                txtAlgoritmo_9.Enabled = true;
                txtAlgoritmo_10.Enabled = true;

                switch (queHago)
                {
                    case Program.Inicio:
                        {

                            //limpio todo el form , excepto el datagridview
                            limpio_form();

                            //modifico  enabled - visible - text 
                            txtFamilia.Enabled = false;
                            cbProveedor.Enabled = false;
                            cbMarca.Enabled = false;

                            txtAlgoritmo_1.Enabled = false;
                            txtAlgoritmo_2.Enabled = false;
                            txtAlgoritmo_3.Enabled = false;
                            txtAlgoritmo_4.Enabled = false;
                            txtAlgoritmo_5.Enabled = false;
                            txtAlgoritmo_6.Enabled = false;
                            txtAlgoritmo_7.Enabled = false;
                            txtAlgoritmo_8.Enabled = false;
                            txtAlgoritmo_9.Enabled = false;
                            txtAlgoritmo_10.Enabled = false;

                            btnNuevo.Enabled = true;
                            btnAgregar.Visible = false;
                            btnCancelarSeleccion.Visible = false;
                            btnBorrar.Visible = false;
                            tabFamilia.SelectedIndex = 0;

                            // seteo como vacio el primer item
                            cbProveedor.SelectedItem = null;
                            cbMarca.SelectedItem = null;

                            //datagridview
                            dgvFamilia.DataSource = null;
                            if (marca == null)
                            {
                                //esto sirve para ordenar las columnas con click del usuario
                                //SortableBindingList<familia> order = new SortableBindingList<familia>(logica_familia.buscar_familias());
                                dgvFamilia.DataSource = logica_familia.buscar_familias_activas();
                            }
                            else
                            {
                                //esto sirve para ordenar las columnas con click del usuario
                                //SortableBindingList<familia> order = new SortableBindingList<familia>(logica_familia.buscar_familias_por_marca(marca.id_tabla_marca));
                                dgvFamilia.DataSource = logica_familia.buscar_familias_activas_por_marca(marca.id_tabla_marca);
                            }

                            //seteo columnas
                            seteoColumnasDataGridView();


                            //limpio cualquier seleccion en el datagridview
                            dgvFamilia.ClearSelection();

                            //accion
                            Accion = Program.Inicio;



                            //genero el evento una vez que se cargo todo , para evitar errores 
                            cbProveedor.SelectedIndexChanged += new EventHandler(cbProveedor_SelectedIndexChanged);

                            dgvFamilia.Focus();


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
                            tabFamilia.SelectedIndex = 0;

                            //cargo combos y lo seteo como vacio el primer item
                            if (marca == null)
                            {
                                cbProveedor.SelectedValue = 0;
                                cbMarca.SelectedValue = 0;
                                cbMarca.Enabled = true;
                                cbProveedor.Enabled = true;

                            }
                            else
                            {
                                cbProveedor.SelectedValue = marca.id_proveedor;
                                cbMarca.SelectedValue = marca.id_tabla_marca;
                                cbMarca.Enabled = false;
                                cbProveedor.Enabled = false;

                            }



                            //accion
                            Accion = Program.Alta;

                            familia = new familia();
                            familia.id_tabla_familia = 0;
                            familia.id_familia = 0;
                            familia.id_tabla_marca = Convert.ToInt32(cbMarca.SelectedValue);
                            familia.txt_desc_familia = "";
                            familia.sn_activo = -1;
                            familia.fec_ult_modif = DateTime.Now;
                            familia.accion = "ALTA";
                            familia.path_img = "";
                            familia.algoritmo_1 = Convert.ToDecimal("0,0000");
                            familia.algoritmo_2 = Convert.ToDecimal("0,0000");
                            familia.algoritmo_3 = Convert.ToDecimal("0,0000");
                            familia.algoritmo_4 = Convert.ToDecimal("0,0000");
                            familia.algoritmo_5 = Convert.ToDecimal("0,0000");
                            familia.algoritmo_6 = Convert.ToDecimal("0,0000");
                            familia.algoritmo_7 = Convert.ToDecimal("0,0000");
                            familia.algoritmo_8 = Convert.ToDecimal("0,0000");
                            familia.algoritmo_9 = Convert.ToDecimal("0,0000");
                            familia.algoritmo_10 = Convert.ToDecimal("0,0000");
                            if (marca == null)
                            {
                                familia.marca = null;
                            }
                            else
                            {
                                familia.marca = marca;
                            }

                            //datagridview
                            dgvFamilia.Enabled = false;

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

                            lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                            lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");

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



                dgvFamilia.Columns[0].Width = 100; //el [0] hace referencia a id_tabla_familia
                dgvFamilia.Columns[0].HeaderText = "Id Familia"; //el [0] hace referencia a id_tabla_familia
                dgvFamilia.Columns[1].Width = 150;
                dgvFamilia.Columns[1].HeaderText = "Familia";
                dgvFamilia.Columns[2].Width = 150;
                dgvFamilia.Columns[2].HeaderText = "Marca";
                dgvFamilia.Columns[3].Width = 150;
                dgvFamilia.Columns[3].HeaderText = "Proveedor";

                foreach (DataGridViewColumn column in dgvFamilia.Columns)
                {
                    if (column.Index > 3)
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

        private void dgvFamilia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.RowIndex >= 0)
                {

                    familia = logica_familia.buscar_familia_por_id_tabla_familia(Convert.ToInt32(dgvFamilia.Rows[e.RowIndex].Cells[0].Value));
                    txtCodigo.Text = familia.id_tabla_familia.ToString();
                    txtFamilia.Text = familia.txt_desc_familia;
                    cbProveedor.SelectedValue = familia.marca.id_proveedor;
                    cbMarca.SelectedValue = familia.marca.id_tabla_marca;
                    txtAlgoritmo_1.Text = familia.algoritmo_1.ToString();
                    txtAlgoritmo_2.Text = familia.algoritmo_2.ToString();
                    txtAlgoritmo_3.Text = familia.algoritmo_3.ToString();
                    txtAlgoritmo_4.Text = familia.algoritmo_4.ToString();
                    txtAlgoritmo_5.Text = familia.algoritmo_5.ToString();
                    txtAlgoritmo_6.Text = familia.algoritmo_6.ToString();
                    txtAlgoritmo_7.Text = familia.algoritmo_7.ToString();
                    txtAlgoritmo_8.Text = familia.algoritmo_8.ToString();
                    txtAlgoritmo_9.Text = familia.algoritmo_9.ToString();
                    txtAlgoritmo_10.Text = familia.algoritmo_10.ToString();

                    txtFamilia.Focus();
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

                    if (MessageBox.Show("¿Confirma agregar una familia?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (logica_familia.alta_familia(familia) == false)
                    {
                        MessageBox.Show("Error al grabar la familia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Grabación Exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Accion == 2) //Modificacion
                {

                    if (MessageBox.Show("¿Confirma modificar la familia " + txtFamilia.Text + " ?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (logica_familia.modificar_eliminar_familia(familia, Convert.ToDecimal(lblCoeficiente_con_beneficio.Text), 1) == false)
                    {
                        MessageBox.Show("Error al modificar la familia " + txtFamilia.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show(txtFamilia.Text + " modificación exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                familia = null;
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
            int id_tabla_familia = 0;
            try
            {
                if (txtCodigo.Text == "" && Accion != 1) // si accion no es alta...
                {
                    txtCodigo.Focus();
                    throw new Exception("Debe ingresar un código");
                }
                if (txtFamilia.Text == "")
                {
                    txtFamilia.Focus();
                    throw new Exception("Debe ingresar una familia");
                }
                if (cbProveedor.SelectedValue == null)
                {
                    cbProveedor.Focus();
                    throw new Exception("Debe seleccionar un proveedor");
                }
                if (cbMarca.SelectedValue == null)
                {
                    cbMarca.Focus();
                    throw new Exception("Debe seleccionar una marca");
                }

                if (lblCoeficiente_sin_beneficio.Text == "")
                {
                    tabFamilia.SelectedIndex = 1;
                    throw new Exception("Debe completar un coeficiente");
                }

                if (txtCodigo.Text != "")
                {
                    id_tabla_familia = Convert.ToInt32(txtCodigo.Text);
                }
                if (logica_familia.buscar_familia_por_txt_desc_activo(txtFamilia.Text, id_tabla_familia) != null)
                {
                    txtFamilia.Focus();
                    throw new Exception("Ya existe una familia con ese nombre");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // Valido la entrada de datos

        private void SeteoObjeto() // Creo los campos restantes del objeto
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                familia.txt_desc_familia = txtFamilia.Text;
                familia.id_tabla_marca = Convert.ToInt32(cbMarca.SelectedValue);

                familia.algoritmo_1 = txtAlgoritmo_1.Text == "" ? Convert.ToDecimal("0,0000") : Convert.ToDecimal(txtAlgoritmo_1.Text);
                familia.algoritmo_2 = txtAlgoritmo_2.Text == "" ? Convert.ToDecimal("0,0000") : Convert.ToDecimal(txtAlgoritmo_2.Text);
                familia.algoritmo_3 = txtAlgoritmo_3.Text == "" ? Convert.ToDecimal("0,0000") : Convert.ToDecimal(txtAlgoritmo_3.Text);
                familia.algoritmo_4 = txtAlgoritmo_4.Text == "" ? Convert.ToDecimal("0,0000") : Convert.ToDecimal(txtAlgoritmo_4.Text);
                familia.algoritmo_5 = txtAlgoritmo_5.Text == "" ? Convert.ToDecimal("0,0000") : Convert.ToDecimal(txtAlgoritmo_5.Text);
                familia.algoritmo_6 = txtAlgoritmo_6.Text == "" ? Convert.ToDecimal("0,0000") : Convert.ToDecimal(txtAlgoritmo_6.Text);
                familia.algoritmo_7 = txtAlgoritmo_7.Text == "" ? Convert.ToDecimal("0,0000") : Convert.ToDecimal(txtAlgoritmo_7.Text);
                familia.algoritmo_8 = txtAlgoritmo_8.Text == "" ? Convert.ToDecimal("0,0000") : Convert.ToDecimal(txtAlgoritmo_8.Text);
                familia.algoritmo_9 = txtAlgoritmo_9.Text == "" ? Convert.ToDecimal("0,0000") : Convert.ToDecimal(txtAlgoritmo_9.Text);
                familia.algoritmo_10 = txtAlgoritmo_10.Text == "" ? Convert.ToDecimal("0,0000") : Convert.ToDecimal(txtAlgoritmo_10.Text);
                familia.marca = logica_marca.buscar_marca_por_id_tabla_marca(familia.id_tabla_marca);





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



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                txtFamilia.Focus();
                iniciar(Program.Alta);
                //txtCodigo.Text = (logica_familia.ult_nro_familia() + 1).ToString();
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
                if (MessageBox.Show("¿Confirma eliminar la familia " + txtFamilia.Text + "?\nTenga en cuenta que al eliminarla se eliminan tambien los articulos de la misma", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (logica_familia.modificar_eliminar_familia(familia, 0, 2) == false)
                {
                    MessageBox.Show("Error al eliminar la familia " + txtFamilia.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show(txtFamilia.Text + " elimado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                familia = null;
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
                familia = null;
                iniciar(Program.Inicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFamilia_Load(object sender, EventArgs e)
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


        private void txtFamilia_Leave(object sender, EventArgs e)
        {
            try
            {
                txtFamilia.Text = txtFamilia.Text.ToUpper();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string precio_coeficiente(int tipo_de_coeficiente) //el 1 -> la multiplicacion de algoritmos sin el beneficio // el 2 -> la multiplicacion de algoritmos con el beneficio
        {
            Cursor.Current = Cursors.WaitCursor;
            string precio_coeficiente = "";
            try
            {
                if (txtAlgoritmo_1.Text == "")
                {
                    txtAlgoritmo_1.Text = Convert.ToDecimal("0,0000").ToString("N4");
                }
                else
                {
                    txtAlgoritmo_1.Text = Convert.ToDecimal(txtAlgoritmo_1.Text).ToString("N4");
                }

                if (txtAlgoritmo_2.Text == "")
                {
                    txtAlgoritmo_2.Text = Convert.ToDecimal("0,0000").ToString("N4");
                }
                else
                {
                    txtAlgoritmo_2.Text = Convert.ToDecimal(txtAlgoritmo_2.Text).ToString("N4");
                }

                if (txtAlgoritmo_3.Text == "")
                {
                    txtAlgoritmo_3.Text = Convert.ToDecimal("0,0000").ToString("N4");
                }
                else
                {
                    txtAlgoritmo_3.Text = Convert.ToDecimal(txtAlgoritmo_3.Text).ToString("N4");
                }

                if (txtAlgoritmo_4.Text == "")
                {
                    txtAlgoritmo_4.Text = Convert.ToDecimal("0,0000").ToString("N4");
                }
                else
                {
                    txtAlgoritmo_4.Text = Convert.ToDecimal(txtAlgoritmo_4.Text).ToString("N4");
                }

                if (txtAlgoritmo_5.Text == "")
                {
                    txtAlgoritmo_5.Text = Convert.ToDecimal("0,0000").ToString("N4");
                }
                else
                {
                    txtAlgoritmo_5.Text = Convert.ToDecimal(txtAlgoritmo_5.Text).ToString("N4");
                }

                if (txtAlgoritmo_6.Text == "")
                {
                    txtAlgoritmo_6.Text = Convert.ToDecimal("0,0000").ToString("N4");
                }
                else
                {
                    txtAlgoritmo_6.Text = Convert.ToDecimal(txtAlgoritmo_6.Text).ToString("N4");
                }

                if (txtAlgoritmo_7.Text == "")
                {
                    txtAlgoritmo_7.Text = Convert.ToDecimal("0,0000").ToString("N4");
                }
                else
                {
                    txtAlgoritmo_7.Text = Convert.ToDecimal(txtAlgoritmo_7.Text).ToString("N4");
                }

                if (txtAlgoritmo_8.Text == "")
                {
                    txtAlgoritmo_8.Text = Convert.ToDecimal("0,0000").ToString("N4");
                }
                else
                {
                    txtAlgoritmo_8.Text = Convert.ToDecimal(txtAlgoritmo_8.Text).ToString("N4");
                }

                if (txtAlgoritmo_9.Text == "")
                {
                    txtAlgoritmo_9.Text = Convert.ToDecimal("0,0000").ToString("N4");
                }
                else
                {
                    txtAlgoritmo_9.Text = Convert.ToDecimal(txtAlgoritmo_9.Text).ToString("N4");
                }

                if (Convert.ToDecimal(txtAlgoritmo_1.Text) > 0) { algoritmo1 = Convert.ToDecimal(txtAlgoritmo_1.Text); } else { algoritmo1 = 1; }
                if (Convert.ToDecimal(txtAlgoritmo_2.Text) > 0) { algoritmo2 = Convert.ToDecimal(txtAlgoritmo_2.Text); } else { algoritmo2 = 1; }
                if (Convert.ToDecimal(txtAlgoritmo_3.Text) > 0) { algoritmo3 = Convert.ToDecimal(txtAlgoritmo_3.Text); } else { algoritmo3 = 1; }
                if (Convert.ToDecimal(txtAlgoritmo_4.Text) > 0) { algoritmo4 = Convert.ToDecimal(txtAlgoritmo_4.Text); } else { algoritmo4 = 1; }
                if (Convert.ToDecimal(txtAlgoritmo_5.Text) > 0) { algoritmo5 = Convert.ToDecimal(txtAlgoritmo_5.Text); } else { algoritmo5 = 1; }
                if (Convert.ToDecimal(txtAlgoritmo_6.Text) > 0) { algoritmo6 = Convert.ToDecimal(txtAlgoritmo_6.Text); } else { algoritmo6 = 1; }
                if (Convert.ToDecimal(txtAlgoritmo_7.Text) > 0) { algoritmo7 = Convert.ToDecimal(txtAlgoritmo_7.Text); } else { algoritmo7 = 1; }
                if (Convert.ToDecimal(txtAlgoritmo_8.Text) > 0) { algoritmo8 = Convert.ToDecimal(txtAlgoritmo_8.Text); } else { algoritmo8 = 1; }
                if (Convert.ToDecimal(txtAlgoritmo_9.Text) > 0 && txtAlgoritmo_9.Text != "") { algoritmo9 = Convert.ToDecimal(txtAlgoritmo_9.Text); } else { algoritmo9 = 1; }

                precio_coeficiente = logica_familia.precio_coeficiente(tipo_de_coeficiente, algoritmo1, algoritmo2, algoritmo3, algoritmo4, algoritmo5, algoritmo6, algoritmo7, algoritmo8, algoritmo9).ToString();

                return precio_coeficiente;
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


        private void txtAlgoritmo_1_Leave(object sender, EventArgs e)
        {
            try
            {
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
            }
            catch (Exception ex)
            {
                txtAlgoritmo_1.Text = Convert.ToDecimal("0,0000").ToString("N4");
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtAlgoritmo_2_Leave(object sender, EventArgs e)
        {
            try
            {


                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
            }
            catch (Exception ex)
            {
                txtAlgoritmo_2.Text = Convert.ToDecimal("0,0000").ToString("N4");
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAlgoritmo_3_Leave(object sender, EventArgs e)
        {
            try
            {

                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
            }
            catch (Exception ex)
            {
                txtAlgoritmo_3.Text = Convert.ToDecimal("0,0000").ToString("N4");
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAlgoritmo_4_Leave(object sender, EventArgs e)
        {
            try
            {
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
            }
            catch (Exception ex)
            {
                txtAlgoritmo_4.Text = Convert.ToDecimal("0,0000").ToString("N4");
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAlgoritmo_5_Leave(object sender, EventArgs e)
        {
            try
            {

                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
            }
            catch (Exception ex)
            {
                txtAlgoritmo_5.Text = Convert.ToDecimal("0,0000").ToString("N4");
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAlgoritmo_6_Leave(object sender, EventArgs e)
        {
            try
            {
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
            }
            catch (Exception ex)
            {
                txtAlgoritmo_6.Text = Convert.ToDecimal("0,0000").ToString("N4");
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAlgoritmo_7_Leave(object sender, EventArgs e)
        {
            try
            {
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
            }
            catch (Exception ex)
            {
                txtAlgoritmo_7.Text = Convert.ToDecimal("0,0000").ToString("N4");
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAlgoritmo_8_Leave(object sender, EventArgs e)
        {
            try
            {
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
            }
            catch (Exception ex)
            {
                txtAlgoritmo_8.Text = Convert.ToDecimal("0,0000").ToString("N4");
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAlgoritmo_9_Leave(object sender, EventArgs e)
        {
            try
            {
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
            }
            catch (Exception ex)
            {
                txtAlgoritmo_9.Text = Convert.ToDecimal("0,0000").ToString("N4");
                lblCoeficiente_sin_beneficio.Text = Convert.ToDecimal(precio_coeficiente(1)).ToString("N4");
                lblCoeficiente_con_beneficio.Text = Convert.ToDecimal(precio_coeficiente(2)).ToString("N4");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAlgoritmo_1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAlgoritmo_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAlgoritmo_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAlgoritmo_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAlgoritmo_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAlgoritmo_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAlgoritmo_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAlgoritmo_8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAlgoritmo_9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtAlgoritmo_10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',')
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cbProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (cbProveedor.SelectedItem != null) //si tengo algo elegido en el combo de proveedor y marca , cargo el combo de familia segun lo que dice proveedor y marca
                {
                    Logica_Funciones_Generales.CargarComboBox("marca", cbMarca, "txt_desc_marca", "id_proveedor = " + cbProveedor.SelectedValue + "and sn_activo = -1", "txt_desc_marca", "id_tabla_marca");
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




    }


}

