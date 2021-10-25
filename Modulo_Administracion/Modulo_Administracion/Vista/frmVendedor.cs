using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using Modulo_Administracion.Vista;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Modulo_Administracion
{
    public partial class frmVendedor : Form
    {

        vendedor vendedor = null;
        Logica_Vendedor logica_vendedor = new Logica_Vendedor();
        int Accion;




        public frmVendedor()
        {
            try
            {
                InitializeComponent();
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

                txtCodigo.Text = "";
                txtNombre.Text = "";
               


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

                txtNombre.Enabled = true;
               

              
                //datagridview
                dgvVendedor.Enabled = true;

                txtBusqueda.Enabled = true;

               


                switch (queHago)
                {
                    case Program.Inicio:
                        {

                            //limpio todo el form , excepto el datagridview
                            limpio_form();

                            //modifico  enabled - visible - text 
                            txtNombre.Enabled = false;
                           

                            btnNuevo.Enabled = true;
                            btnAgregar.Visible = false;
                            btnCancelarSeleccion.Visible = false;
                            btnEliminar.Visible = false;

                            //accion
                            Accion = Program.Inicio;

                            txtBusqueda.Text = "";

                            //datagridview
                            dgvVendedor.DataSource = null;

                            //esto sirve para ordenar las columnas con click del usuario
                            //SortableBindingList<vendedor> order = new SortableBindingList<vendedor>(logica_vendedor.buscar_vendedores());
                            dgvVendedor.DataSource = logica_vendedor.buscar_vendedores();
                            
                            //seteo columnas
                            seteoColumnasDataGridView();

                            //limpio cualquier seleccion en el datagridview
                            dgvVendedor.ClearSelection();

                            dgvVendedor.Focus();

                            break;
                        }

                    case Program.Alta:
                        {
                            //limpio todo el form , excepto el datagridview
                            limpio_form();

                         
                            btnNuevo.Enabled = false;
                            btnAgregar.Visible = true;
                            btnCancelarSeleccion.Visible = true;
                            btnAgregar.Text = "Agregar";

                            //accion
                            Accion = Program.Alta;


                            //genero un vendedor vacio
                            vendedor = new vendedor();
                            vendedor.id_vendedor = 0;
                            vendedor.nombre = "";
                            vendedor.sn_activo = -1;
                            vendedor.fec_ult_modif = DateTime.Now;
                            vendedor.accion = "ALTA";
                           

                            //datagridview
                            dgvVendedor.Enabled = false;
                            txtBusqueda.Enabled = false;
                            break;
                        }

                    case Program.Modif:
                        {
                            //modifico  enabled - visible - text 
                            btnNuevo.Enabled = false;
                            btnAgregar.Visible = true;
                            btnCancelarSeleccion.Visible = true;
                            btnEliminar.Enabled = true;
                            btnEliminar.Visible = true;
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
                

                dgvVendedor.Columns[0].Width = 100;
                dgvVendedor.Columns[0].HeaderText = "Id Vendedor";
                dgvVendedor.Columns[1].Width = 425;
                dgvVendedor.Columns[1].HeaderText = "Vendedor";

                foreach (DataGridViewColumn column in dgvVendedor.Columns)
                {
                    if (column.Index > 1)
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

        private void dgvVendedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.RowIndex >= 0)
                {
                    vendedor = logica_vendedor.buscar_vendedor(Convert.ToInt32(dgvVendedor.Rows[e.RowIndex].Cells[0].Value));

                    txtCodigo.Text = vendedor.id_vendedor.ToString();
                    txtNombre.Text = vendedor.nombre.ToString();
                 


                    txtNombre.Focus();
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

                    if (MessageBox.Show("¿Confirma agregar un vendedor?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (logica_vendedor.alta_vendedor(vendedor) == false) 
                    {
                        MessageBox.Show("Error al grabar el vendedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Grabación exitosa del vendedor", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Accion == 2) //Modificacion
                {

                    if (MessageBox.Show("¿Confirma modificar el vendedor?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (logica_vendedor.modificar_vendedor(vendedor) == false)
                    {
                        MessageBox.Show("Error al modificar el vendedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Modificación exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  

                }
                vendedor = null;
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
            Cursor.Current = Cursors.WaitCursor;
            int id_vendedor = 0;
            try
            {

                if (txtCodigo.Text == "" && Accion != 1)
                {
                    txtCodigo.Focus();
                    throw new Exception("Debe ingresar un código");
                }
                if (txtNombre.Text == "")
                {
                    txtNombre.Focus();
                    throw new Exception("Debe ingresar un nombre");
                }
              
                if (txtCodigo.Text != "")
                {
                    id_vendedor = Convert.ToInt32(txtCodigo.Text);
                   
                }
                
                if (logica_vendedor.buscar_vendedor_por_nombre_activo(txtNombre.Text, id_vendedor) != null)
                {
                    txtNombre.Focus();
                    throw new Exception("Ya existe un vendedor con este nombre");
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
        } // Valido la entrada de datos

        private void SeteoObjeto() // Creo los campos restantes del objeto
        {
            try
            {
                
                vendedor.nombre = txtNombre.Text;
               

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
                txtNombre.Focus();
                iniciar(Program.Alta);
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            vendedor vendedor_eliminado = null;
            try
            {

                SeteoObjeto();
                if (MessageBox.Show("¿Confirma eliminar el vendedor " + txtNombre.Text + "?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (logica_vendedor.eliminar_vendedor(vendedor) == false)
                {
                    MessageBox.Show("Error al eliminar el vendedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Elimado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vendedor = null;
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
                vendedor = null;
                iniciar(Program.Inicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmVendedor_Load(object sender, EventArgs e)
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

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            try
            {
                txtNombre.Text = txtNombre.Text.ToUpper();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
     
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {

                    dgvVendedor.DataSource = logica_vendedor.filtro_vendedor_nombre(txtBusqueda.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
        }

        private void dgvVendedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmCliente form = new frmCliente(vendedor);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
