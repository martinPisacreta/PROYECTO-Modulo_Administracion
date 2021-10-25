
using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Modulo_Administracion
{
    public partial class frmProveedor : Form
    {

        proveedor proveedor = null;
        Logica_Proveedor logica_proveedor = new Logica_Proveedor();
        Logica_Proveedor_Direccion logica_proveedor_direccion = new Logica_Proveedor_Direccion();
        Logica_Proveedor_Datos logica_proveedor_datos = new Logica_Proveedor_Datos();
        int Accion;



        private void btnProveedor_Direccion_Click(object sender, EventArgs e)
        {

            try
            {
                

                    frmDireccion frm = new frmDireccion();
                    frm.InicioForm(proveedor, null, 1);
                    var result = frm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (proveedor.proveedor_dir == null)
                        {
                            proveedor.proveedor_dir = new List<proveedor_dir>();
                        }

                        proveedor.proveedor_dir = frm.lista_aux_proveedor;
                    }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProveedor_Datos_Click(object sender, EventArgs e)
        {
            try
            {
                    frmDatos frm = new frmDatos();
                    frm.InicioForm(proveedor, null, 1);
                    var result = frm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        if (proveedor.proveedor_datos == null)
                        {
                            proveedor.proveedor_datos = new List<proveedor_datos>();
                        }

                        proveedor.proveedor_datos = frm.lista_aux_proveedor;
                    }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                frmMarca form = new frmMarca(proveedor);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------------------------

        public frmProveedor()
        {
            try
            {
                InitializeComponent();
                Logica_Funciones_Generales.CargarComboBox("ttipo_condicion_iva", cbCondicionIVA, "txt_desc", "1=1", "txt_desc", "id_condicion_ante_iva");
                Logica_Funciones_Generales.CargarComboBox("ttipo_condicion_pago", cbCondicionPago, "txt_desc", "1=1", "txt_desc", "id_condicion_pago");

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
                txtRazonSocial.Text = "";
                cbCondicionIVA.SelectedItem = null;
                cbCondicionPago.SelectedItem = null;


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

                txtRazonSocial.Enabled = true;
                cbCondicionIVA.Enabled = true;
                cbCondicionPago.Enabled = true;
                btnProveedor_Direccion.Enabled = true;
                btnProveedor_Datos.Enabled = true;

                //datagridview
                dgvProveedor.Enabled = true;

                txtBusqueda.Enabled = true;

                switch (queHago)
                {
                    case Program.Inicio:
                        {

                            //limpio todo el form , excepto el datagridview
                            limpio_form();

                            //modifico  enabled - visible - text 
                            txtRazonSocial.Enabled = false;
                            cbCondicionIVA.Enabled = false;
                            cbCondicionPago.Enabled = false;
                            btnProveedor_Direccion.Enabled = false;
                            btnProveedor_Datos.Enabled = false;

                            btnNuevo.Enabled = true;
                            btnAgregar.Visible = false;
                            btnCancelarSeleccion.Visible = false;
                            btnEliminar.Visible = false;


                            txtBusqueda.Text = "";

                            //accion
                            Accion = Program.Inicio;

                            //datagridview
                            dgvProveedor.DataSource = null;

                            //esto sirve para ordenar las columnas con click del usuario
                            //SortableBindingList<proveedor> order = new SortableBindingList<proveedor>(logica_proveedor.buscar_proveedores());
                            dgvProveedor.DataSource = logica_proveedor.buscar_proveedores();
                            
                            //seteo columnas
                            seteoColumnasDataGridView();

                            //limpio cualquier seleccion en el datagridview
                            dgvProveedor.ClearSelection();

                            dgvProveedor.Focus();

                            break;
                        }

                    case Program.Alta:
                        {
                            //limpio todo el form , excepto el datagridview
                            limpio_form();

                            //modifico  enabled - visible - text 
                            btnProveedor_Direccion.Enabled = true;
                            btnProveedor_Datos.Enabled = true; 

                            btnNuevo.Enabled = false;
                            btnAgregar.Visible = true;
                            btnCancelarSeleccion.Visible = true;
                            btnAgregar.Text = "Agregar";

                            //accion
                            Accion = Program.Alta;


                            //genero un proveedor vacio
                            proveedor = new proveedor();
                            proveedor.id_proveedor = 0;
                            proveedor.razon_social = "";
                            proveedor.sn_activo = -1;
                            proveedor.fec_ult_modif = DateTime.Now;
                            proveedor.accion = "ALTA";
                            proveedor.path_img = "";
                            proveedor.marca = null;
                            proveedor.proveedor_dir = null;
                            proveedor.proveedor_datos = null;

                            //datagridview
                            dgvProveedor.Enabled = false;
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
                

                dgvProveedor.Columns[0].Width = 100;
                dgvProveedor.Columns[0].HeaderText = "Id Proveedor";
                dgvProveedor.Columns[1].Width = 425;
                dgvProveedor.Columns[1].HeaderText = "Razon Social";



                foreach (DataGridViewColumn column in dgvProveedor.Columns)
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

        private void dgvProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.RowIndex >= 0)
                {
                    proveedor = logica_proveedor.buscar_proveedor(Convert.ToInt32(dgvProveedor.Rows[e.RowIndex].Cells[0].Value));

                    txtCodigo.Text = proveedor.id_proveedor.ToString();
                    txtRazonSocial.Text = proveedor.razon_social.ToString();
                    if (proveedor.id_condicion_ante_iva != null)
                    {
                        cbCondicionIVA.SelectedValue = proveedor.id_condicion_ante_iva;
                    }
                    if (proveedor.id_condicion_pago != null)
                    {
                        cbCondicionPago.SelectedValue = proveedor.id_condicion_pago;
                    }

                    txtRazonSocial.Focus();
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

                    if (MessageBox.Show("¿Confirma agregar un proveedor?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (logica_proveedor.alta_proveedor(proveedor) == false)
                    {
                        MessageBox.Show("Error al grabar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Grabación Exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else if (Accion == 2) //Modificacion
                {

                    if (MessageBox.Show("¿Confirma modificar el proveedor?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (logica_proveedor.modificar_proveedor(proveedor) == false)
                    {
                        MessageBox.Show("Error al modificar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Modificación exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                proveedor = null;
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
            bool bandera_cuit = false;
            bool bandera_domicilio_comercial = false;
            int id_proveedor = 0;
            try
            {

                if (txtCodigo.Text == "" && Accion != 1)
                {
                    txtCodigo.Focus();
                    throw new Exception("Debe ingresar un código");
                }
                if (txtRazonSocial.Text == "")
                {
                    txtRazonSocial.Focus();
                    throw new Exception("Debe ingresar una razón social");
                }

                if (cbCondicionIVA.SelectedItem == null)
                {
                    cbCondicionIVA.Focus();
                    throw new Exception("Debe ingresar una condicion IVA");
                }
                if (cbCondicionPago.SelectedItem == null)
                {
                    cbCondicionPago.Focus();
                    throw new Exception("Debe ingresar una condicion Pago");
                }

                if (txtCodigo.Text != "")
                {
                    id_proveedor = Convert.ToInt32(txtCodigo.Text);
                }
                if (logica_proveedor.buscar_proveedor_por_razon_social_activo(txtRazonSocial.Text, id_proveedor) != null)
                {
                    txtRazonSocial.Focus();
                    throw new Exception("Ya existe un proveedor con esa razon social");
                }


                //valido CUIT
                //if (Convert.ToInt32(cbCondicionIVA.SelectedValue) == 1 || Convert.ToInt32(cbCondicionIVA.SelectedValue) == 6)
                //{
                //    if (proveedor.proveedor_datos != null)
                //    {
                //        foreach (proveedor_datos Dato in proveedor.proveedor_datos)
                //        {
                //            if (Dato.cod_tipo_dato == 12 && Dato.sn_activo == -1)
                //            {
                //                bandera_cuit = true;
                //            }
                //        }

                //        if (bandera_cuit == false)
                //        {
                //            throw new Exception("Debe completar el CUIT del proveedor ya que el mismo es " + cbCondicionIVA.Text);
                //        }


                //    }
                //    else
                //    {
                //        throw new Exception("Debe completar el CUIT del proveedor ya que el mismo es " + cbCondicionIVA.Text);
                //    }
                //}

                //valido DOMICILIO COMERCIAL
                //if (proveedor.proveedor_dir != null)
                //{
                //    foreach (proveedor_dir Dir in proveedor.proveedor_dir)
                //    {
                //        if (Dir.ttipo_dir.cod_tipo_dir == 3 && Dir.sn_activo == -1)
                //        {
                //            bandera_domicilio_comercial = true;
                //        }
                //    }

                //    if (bandera_domicilio_comercial == false)
                //    {
                //        throw new Exception("Debe completar el DOMICILIO COMERCIAL del proveedor dentro del boton Direccion");
                //    }
                //}
                //else
                //{
                //    throw new Exception("Debe completar el DOMICILIO COMERCIAL del proveedor dentro del boton Direccion");
                //}

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
                
                proveedor.razon_social = txtRazonSocial.Text;
                proveedor.id_condicion_ante_iva = (Convert.ToInt32(cbCondicionIVA.SelectedValue));
                proveedor.id_condicion_pago = (Convert.ToInt32(cbCondicionPago.SelectedValue));
                //proveedor.sn_activo = txtSnActivo.Text == "" ? -1 : Convert.ToInt32(txtSnActivo.Text);
                //proveedor.fec_ult_modif = DateTime.Now;
                //proveedor.accion = txtAccion.Text == "" ? "ALTA" :  txtAccion.Text;
                //proveedor.path_img = txtPathImg.Text;


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
                txtRazonSocial.Focus();
                iniciar(Program.Alta);
                //txtCodigo.Text = (logica_proveedor.ult_nro_proveedor() + 1).ToString();
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
            proveedor proveedor_eliminado = null;
            try
            {

                SeteoObjeto();
                if (MessageBox.Show("¿Confirma eliminar el proveedor " + txtRazonSocial.Text + "?\nTenga en cuenta que al eliminarlo se eliminan tambien los datos, direcciones , marcas del mismo y todo lo asociado a esas marcas", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (logica_proveedor.eliminar_proveedor(proveedor) == false)
                {
                    MessageBox.Show("Error al eliminar el proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Elimado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                proveedor = null;
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
                proveedor = null;
                iniciar(Program.Inicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProveedor_Load(object sender, EventArgs e)
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

        private void txtRazonSocial_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRazonSocial.Text = txtRazonSocial.Text.ToUpper();

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
                dgvProveedor.DataSource = logica_proveedor.filtro_proveedor_razon_social(txtBusqueda.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
