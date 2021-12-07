using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using Modulo_Administracion.Vista;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Modulo_Administracion
{
    public partial class frmCliente : Form
    {
        vendedor vendedor = null;
        cliente cliente = null;
        Logica_Vendedor logica_vendedor = new Logica_Vendedor();
        Logica_Cliente logica_cliente = new Logica_Cliente();

        int Accion;





        private void btnCliente_Datos_Click(object sender, EventArgs e)
        {
            try
            {


                frmDatos frm = new frmDatos();
                frm.InicioForm(null, cliente, 2);
                var result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {

                    if (cliente.cliente_datos == null)
                    {
                        cliente.cliente_datos = new List<cliente_datos>();
                    }


                    cliente.cliente_datos = frm.lista_aux_cliente;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }




        //--------------------------------------

        public frmCliente(vendedor _vendedor)
        {
            try
            {
                InitializeComponent();
                vendedor = _vendedor;
                Logica_Funciones_Generales.CargarComboBox("ttipo_condicion_iva", cbCondicionIVA, "txt_desc", "1=1", "txt_desc", "id_condicion_ante_iva");
                Logica_Funciones_Generales.CargarComboBox("ttipo_condicion_pago", cbCondicionPago, "txt_desc", "1=1", "txt_desc", "id_condicion_pago");
                Logica_Funciones_Generales.CargarComboBox("ttipo_cliente", cbTipoCliente, "txt_desc", "sn_activo = -1", "txt_desc", "id_tipo_cliente");
                Logica_Funciones_Generales.CargarComboBox("ttipo_condicion_factura", cbCondicionFactura, "txt_desc", "sn_activo = -1", "txt_desc", "id_condicion_factura");
                Logica_Funciones_Generales.CargarComboBox("vendedor", cbVendedor, "nombre", "sn_activo = -1", "nombre", "id_vendedor");
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
                txtNombreFantasia.Text = "";
                txtRazonSocial_Cliente.Text = "";
                cbCondicionIVA.SelectedItem = null;
                cbCondicionPago.SelectedItem = null;
                cbTipoCliente.SelectedItem = null;
                cbCondicionFactura.SelectedItem = null;


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

                txtNombreFantasia.Enabled = true;
                txtRazonSocial_Cliente.Enabled = true;
                cbCondicionIVA.Enabled = true;
                cbCondicionPago.Enabled = true;
                cbTipoCliente.Enabled = true;
                cbCondicionFactura.Enabled = true;
                cbVendedor.Enabled = true;

                btnCliente_CtaCorriente.Enabled = true;
                btnCliente_Datos.Enabled = true;
                btnCliente_Direccion.Enabled = true;


                //datagridview
                dgvCliente.Enabled = true;

                txtBusqueda.Enabled = true;




                switch (queHago)
                {
                    case Program.Inicio:
                        {

                            //limpio todo el form , excepto el datagridview
                            limpio_form();

                            //modifico  enabled - visible - text 
                            txtNombreFantasia.Enabled = false;
                            txtRazonSocial_Cliente.Enabled = false;
                            cbCondicionIVA.Enabled = false;
                            cbCondicionPago.Enabled = false;
                            cbTipoCliente.Enabled = false;
                            cbCondicionFactura.Enabled = false;
                            cbVendedor.Enabled = false;
                            cbVendedor.SelectedItem = null;

                            btnCliente_CtaCorriente.Enabled = false;
                            btnCliente_Datos.Enabled = false;
                            btnCliente_Direccion.Enabled = false;

                            btnNuevo.Enabled = true;
                            btnAgregar.Visible = false;
                            btnCancelarSeleccion.Visible = false;
                            btnEliminar.Visible = false;


                            rdCliente.Checked = true;

                            //accion
                            Accion = Program.Inicio;

                            txtBusqueda.Text = "";

                            //datagridview
                            setearDgvCliente();





                            //limpio cualquier seleccion en el datagridview
                            dgvCliente.ClearSelection();

                            dgvCliente.Focus();

                            break;
                        }

                    case Program.Alta:
                        {
                            //limpio todo el form , excepto el datagridview
                            limpio_form();

                            //modifico  enabled - visible - text 
                            btnCliente_CtaCorriente.Enabled = true;
                            btnCliente_Datos.Enabled = true;
                            btnCliente_Direccion.Enabled = true;

                            btnNuevo.Enabled = false;
                            btnAgregar.Visible = true;
                            btnCancelarSeleccion.Visible = true;
                            btnAgregar.Text = "Agregar";


                            if (vendedor == null)
                            {
                                cbVendedor.SelectedItem = null;
                                cbVendedor.Enabled = true;
                            }
                            else
                            {
                                cbVendedor.SelectedValue = vendedor.id_vendedor;
                                cbVendedor.Enabled = false;
                            }


                            //accion
                            Accion = Program.Alta;


                            //genero un cliente vacio
                            cliente = new cliente();
                            cliente.id_cliente = 0;
                            cliente.razon_social = "";
                            cliente.sn_activo = -1;
                            cliente.fec_ult_modif = DateTime.Now;
                            cliente.accion = "ALTA";
                            cliente.id_vendedor = Convert.ToInt32(cbVendedor.SelectedValue);
                            cliente.cliente_datos = null;
                            cliente.factura = null;
                            if (vendedor == null)
                            {
                                cliente.vendedor = null;
                            }
                            else
                            {
                                cliente.vendedor = vendedor;
                            }



                            //datagridview
                            dgvCliente.Enabled = false;
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

        private void setearDgvCliente()
        {
            try
            {
                //datagridview
                dgvCliente.DataSource = null;

                if (vendedor == null)
                {
                    //esto sirve para ordenar las columnas con click del usuario
                    //SortableBindingList<cliente> order = new SortableBindingList<cliente>(logica_cliente.buscar_clientes());
                    dgvCliente.DataSource = logica_cliente.buscar_clientes();

                }
                else
                {
                    //esto sirve para ordenar las columnas con click del usuario
                    //SortableBindingList<cliente> order = new SortableBindingList<cliente>(logica_cliente.buscar_clientes_activos_por_vendedor());
                    dgvCliente.DataSource = logica_cliente.buscar_clientes_activos_por_vendedor(vendedor.id_vendedor);
                }

                //seteo columnas
                seteoColumnasDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void seteoColumnasDataGridView()
        {
            try
            {


                dgvCliente.Columns[0].Width = 100;
                dgvCliente.Columns[0].HeaderText = "Id Cliente";
                dgvCliente.Columns[1].Width = 425;
                dgvCliente.Columns[1].HeaderText = "Cliente";
                dgvCliente.Columns[2].Width = 200;
                dgvCliente.Columns[2].HeaderText = "Vendedor";

                foreach (DataGridViewColumn column in dgvCliente.Columns)
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

        private void dgvCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.RowIndex >= 0)
                {
                    cliente = logica_cliente.buscar_cliente(Convert.ToInt32(dgvCliente.Rows[e.RowIndex].Cells[0].Value));

                    txtCodigo.Text = cliente.id_cliente.ToString();
                    txtNombreFantasia.Text = cliente.nombre_fantasia.ToString();
                    txtRazonSocial_Cliente.Text = cliente.razon_social == null ? "" : cliente.razon_social;
                    if (cliente.id_condicion_ante_iva != null)
                    {
                        cbCondicionIVA.SelectedValue = cliente.id_condicion_ante_iva;
                    }
                    if (cliente.id_condicion_pago != null)
                    {
                        cbCondicionPago.SelectedValue = cliente.id_condicion_pago;
                    }

                    if (cliente.id_tipo_cliente != null)
                    {
                        cbTipoCliente.SelectedValue = cliente.id_tipo_cliente;
                    }

                    if (cliente.id_condicion_factura != null)
                    {
                        cbCondicionFactura.SelectedValue = cliente.id_condicion_factura;
                    }

                    if (cliente.vendedor != null)
                    {
                        cbVendedor.SelectedValue = cliente.vendedor.id_vendedor;
                    }

                    txtNombreFantasia.Focus();
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

                    if (MessageBox.Show("¿Confirma agregar un cliente?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (logica_cliente.alta_cliente(cliente) == false)
                    {
                        MessageBox.Show("Error al grabar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Grabación exitosa del cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (Accion == 2) //Modificacion
                {

                    if (MessageBox.Show("¿Confirma modificar el cliente?", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return;
                    }

                    if (logica_cliente.modificar_cliente(cliente) == false)
                    {
                        MessageBox.Show("Error al modificar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    MessageBox.Show("Modificación exitosa", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                cliente = null;
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
            int id_cliente = 0;
            try
            {

                if (txtCodigo.Text == "" && Accion != 1)
                {
                    txtCodigo.Focus();
                    throw new Exception("Debe ingresar un código");
                }
                if (txtNombreFantasia.Text == "")
                {
                    txtNombreFantasia.Focus();
                    throw new Exception("Debe ingresar un nombre");
                }
                if (txtRazonSocial_Cliente.Text == "")
                {
                    txtRazonSocial_Cliente.Focus();
                    throw new Exception("Debe ingresar una razon social");
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

                if (cbTipoCliente.SelectedItem == null)
                {
                    cbTipoCliente.Focus();
                    throw new Exception("Debe ingresar un tipo de cliente");
                }

                if (cbCondicionFactura.SelectedItem == null)
                {
                    cbCondicionFactura.Focus();
                    throw new Exception("Debe ingresar una condición de factura");
                }

                if (txtCodigo.Text != "")
                {
                    id_cliente = Convert.ToInt32(txtCodigo.Text);

                }



                if (logica_cliente.buscar_cliente_por_nombre_fantasia_activo(txtNombreFantasia.Text, id_cliente) != null)
                {
                    txtNombreFantasia.Focus();
                    throw new Exception("Ya existe un cliente con este nombre");
                }


                if (logica_cliente.buscar_cliente_por_razon_social_activo(txtRazonSocial_Cliente.Text, id_cliente) != null)
                {
                    txtRazonSocial_Cliente.Focus();
                    throw new Exception("Ya existe un cliente con esa razon social");
                }


                if ((Convert.ToInt32(cbTipoCliente.SelectedValue)) == 1) //solamente valido esto si el cliente es CONSTANTE
                {
                    //valido CUIT
                    //if (Convert.ToInt32(cbCondicionIVA.SelectedValue) == 1 || Convert.ToInt32(cbCondicionIVA.SelectedValue) == 6)
                    //{
                    //    if (cliente.cliente_datos != null)
                    //    {
                    //        foreach (cliente_datos Dato in cliente.cliente_datos)
                    //        {
                    //            if (Dato.cod_tipo_dato == 12 && Dato.sn_activo == -1)
                    //            {
                    //                bandera_cuit = true;
                    //            }
                    //        }

                    //        if (bandera_cuit == false)
                    //        {
                    //            throw new Exception("Debe completar el CUIT del cliente ya que el mismo es " + cbCondicionIVA.Text);
                    //        }


                    //    }
                    //    else
                    //    {
                    //        throw new Exception("Debe completar el CUIT del cliente ya que el mismo es " + cbCondicionIVA.Text);
                    //    }
                    //}

                    //valido DOMICILIO COMERCIAL
                    //if (cliente.cliente_dir != null)
                    //{
                    //    foreach (cliente_dir Dir in cliente.cliente_dir)
                    //    {
                    //        if (Dir.ttipo_dir.cod_tipo_dir == 3 && Dir.sn_activo == -1)
                    //        {
                    //            bandera_domicilio_comercial = true;
                    //        }
                    //    }

                    //    if (bandera_domicilio_comercial == false)
                    //    {
                    //        throw new Exception("Debe completar el DOMICILIO COMERCIAL del cliente dentro del boton Direccion");
                    //    }
                    //}
                    //else
                    //{
                    //    throw new Exception("Debe completar el DOMICILIO COMERCIAL del cliente dentro del boton Direccion");
                    //}
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

                cliente.nombre_fantasia = txtNombreFantasia.Text;
                cliente.razon_social = txtRazonSocial_Cliente.Text;
                cliente.id_condicion_ante_iva = (Convert.ToInt32(cbCondicionIVA.SelectedValue));
                cliente.id_condicion_pago = (Convert.ToInt32(cbCondicionPago.SelectedValue));
                cliente.id_tipo_cliente = (Convert.ToInt32(cbTipoCliente.SelectedValue));
                cliente.id_condicion_factura = (Convert.ToInt32(cbCondicionFactura.SelectedValue));
                cliente.id_vendedor = Convert.ToInt32(cbVendedor.SelectedValue);
                cliente.vendedor = logica_vendedor.buscar_vendedor(cliente.id_vendedor);
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
                txtNombreFantasia.Focus();
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
            cliente cliente_eliminado = null;
            try
            {

                SeteoObjeto();
                if (MessageBox.Show("¿Confirma eliminar el cliente " + txtNombreFantasia.Text + "?\nTenga en cuenta que al eliminarlo se elimina tambien los datos y direcciones del mismo", "Atención", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (logica_cliente.eliminar_cliente(cliente) == false)
                {
                    MessageBox.Show("Error al eliminar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Elimado exitosamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cliente = null;
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
                cliente = null;
                iniciar(Program.Inicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCliente_Load(object sender, EventArgs e)
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

        private void txtNombreFantasia_Leave(object sender, EventArgs e)
        {
            try
            {
                txtNombreFantasia.Text = txtNombreFantasia.Text.ToUpper();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCliente_Direccion_Click(object sender, EventArgs e)
        {
            try
            {

                frmDireccion frm = new frmDireccion();
                frm.InicioForm(null, cliente, 2);
                var result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    if (cliente.cliente_dir == null)
                    {
                        cliente.cliente_dir = new List<cliente_dir>();
                    }

                    cliente.cliente_dir = frm.lista_aux_cliente;
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRazonSocial_Cliente_Leave(object sender, EventArgs e)
        {
            try
            {
                txtRazonSocial_Cliente.Text = txtRazonSocial_Cliente.Text.ToUpper();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCliente_CtaCorriente_Click(object sender, EventArgs e)
        {
            try
            {
                frmCliente_Cuenta_Corriente frm = new frmCliente_Cuenta_Corriente(cliente);
                var result = frm.ShowDialog();




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
                int valor_busqueda = 1; //el filtro es por cliente
                if (rdVendedor.Checked == true)
                {
                    valor_busqueda = 2; //el filtro es por vendedor
                }
                dgvCliente.DataSource = logica_cliente.filtro_cliente_nombre_fantasia(txtBusqueda.Text.Trim(), valor_busqueda);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void rdVendedor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtBusqueda.Text = "";
                setearDgvCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdCliente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtBusqueda.Text = "";
                setearDgvCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
