using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Modulo_Administracion
{
    public partial class frmDatos : Form
    {

        int Accion;

        cliente cliente = null;
        proveedor proveedor = null;

        cliente_datos cliente_datos = null;
        proveedor_datos proveedor_datos = null;

        public List<proveedor_datos> lista_aux_proveedor = new List<proveedor_datos>();
        public List<cliente_datos> lista_aux_cliente = new List<cliente_datos>();

        Logica_Cliente_Datos logica_cliente_datos = new Logica_Cliente_Datos();
        Logica_Proveedor_Datos logica_proveedor_datos = new Logica_Proveedor_Datos();

        int tipo; //1 es proveedor , 2 es cliente



        public frmDatos()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                InitializeComponent();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        public void InicioForm(proveedor _proveedor, cliente _cliente, int _tipo)
        {
            try
            {

                tipo = _tipo;

                if (tipo == 1)
                {
                    proveedor = _proveedor;
                    this.Text = "Datos del proveedor";
                    ICollection<proveedor_datos> lista_obj_dato_proveedor = proveedor.proveedor_datos;
                    if (!(lista_obj_dato_proveedor == null))
                    {
                        lista_aux_proveedor.AddRange(lista_obj_dato_proveedor);
                        CargarGrilla(lista_aux_proveedor, null);
                    }
                }
                else if (tipo == 2)
                {
                    cliente = _cliente;
                    this.Text = "Datos del cliente";
                    ICollection<cliente_datos> lista_obj_dato_cliente = cliente.cliente_datos;
                    if (!(lista_obj_dato_cliente == null))
                    {
                        lista_aux_cliente.AddRange(lista_obj_dato_cliente);
                        CargarGrilla(null, lista_aux_cliente);
                    }
                }

                Logica_Funciones_Generales.CargarComboBox("ttipo_dato", cbTipoDato, "txt_desc", "1=1", "cod_tipo_dato", "cod_tipo_dato");

                cbTipoDato.SelectedValue = 1;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LimpioForm()
        {
            try
            {
                foreach (Control controles in this.Controls)
                {
                    if (controles is GroupBox)
                    {
                        foreach (Control cont in controles.Controls)
                        {
                            if ((cont is TextBoxBase))
                                cont.Text = "";
                        }
                    }
                }

                cbTipoDato.SelectedValue = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ConfigurarForm(int queHago)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {




                gpbDatos.Enabled = true; //pongo en true , porque puede que en consulta quedaron en false
                btnNuevo.Enabled = true; //pongo en true , porque puede que en consulta quedaron en false
                btnAceptar.Enabled = true; //pongo en true , porque puede que en consulta quedaron en false

                switch (queHago)
                {
                    case Program.Inicio:
                        {

                            LimpioForm();
                            Habilito(false);
                            btnNuevo.Enabled = true;
                            dgvDatos.Enabled = true;
                            btnAgregar.Visible = false;
                            btnCancelarSeleccion.Visible = false;
                            btnBorrar.Visible = false;

                            //seteo columnas
                            ordenarColumnasDataGridView_con_click();
                            dgvDatos.Focus();


                            Accion = Program.Inicio;
                            break;

                        }

                    case Program.Alta:
                        {

                            Habilito(true);
                            btnNuevo.Enabled = false;
                            btnAgregar.Visible = true;
                            btnBorrar.Visible = true;
                            btnCancelarSeleccion.Visible = true;
                            btnAgregar.Text = "Agregar";
                            Accion = Program.Alta;

                            if (tipo == 1)
                            {
                                //genero un dato vacio
                                proveedor_datos = new proveedor_datos();
                                proveedor_datos.id_proveedor = proveedor.id_proveedor;
                                proveedor_datos.cod_tipo_dato = 0;
                                proveedor_datos.txt_dato_proveedor = "";
                            }
                            else if (tipo == 2)
                            {
                                //genero un dato vacio
                                cliente_datos = new cliente_datos();
                                cliente_datos.id_cliente = cliente.id_cliente;
                                cliente_datos.cod_tipo_dato = 0;
                                cliente_datos.txt_dato_cliente = "";
                            }

                            cbTipoDato.Focus();
                            break;


                        }

                    case Program.Modif:
                        {
                            Habilito(true);
                            btnNuevo.Enabled = false;
                            btnAgregar.Visible = true;
                            btnBorrar.Visible = true;
                            btnCancelarSeleccion.Visible = true;
                            btnBorrar.Enabled = true;
                            btnBorrar.Visible = true;
                            btnAgregar.Text = "Modificar";
                            Accion = Program.Modif;
                            cbTipoDato.Focus();

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

        private void ordenarColumnasDataGridView_con_click()
        {
            try
            {
                //pongo que todas las columnas se puedan ordenar si el usuario hace click en la columna
                foreach (DataGridViewColumn column in dgvDatos.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void dgvDatos_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (dgvDatos.SelectedRows.Count > 0)
                {
                    if (tipo == 1)
                    {
                        txtDato.Text = lista_aux_proveedor[dgvDatos.SelectedRows[0].Index].txt_dato_proveedor;
                        cbTipoDato.SelectedValue = lista_aux_proveedor[dgvDatos.SelectedRows[0].Index].cod_tipo_dato;
                        proveedor_datos = lista_aux_proveedor[dgvDatos.SelectedRows[0].Index];
                    }
                    else if (tipo == 2)
                    {

                        txtDato.Text = lista_aux_cliente[dgvDatos.SelectedRows[0].Index].txt_dato_cliente;
                        cbTipoDato.SelectedValue = lista_aux_cliente[dgvDatos.SelectedRows[0].Index].cod_tipo_dato;
                        cliente_datos = lista_aux_cliente[dgvDatos.SelectedRows[0].Index];
                    }
                    ConfigurarForm(Program.Modif);
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
        private void btnSalir_Click(System.Object sender, System.EventArgs e)
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
        private void btnAgregar_Click(System.Object sender, System.EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                Valido();
                SeteoObjeto();
                if (Accion == 1)
                {
                    if (tipo == 1)
                    {
                        foreach (proveedor_datos Dato in lista_aux_proveedor)
                        {
                            if (Dato.cod_tipo_dato == (Convert.ToInt32(cbTipoDato.SelectedValue)) && Dato.sn_activo == -1)
                                throw new Exception("No puede ingresar dos veces el mismo tipo de dato");
                        }

                        lista_aux_proveedor.Add(proveedor_datos);
                        proveedor_datos = null;
                    }
                    else if (tipo == 2)
                    {
                        foreach (cliente_datos Dato in lista_aux_cliente)
                        {
                            if (Dato.cod_tipo_dato == (Convert.ToInt32(cbTipoDato.SelectedValue)) && Dato.sn_activo == -1)
                                throw new Exception("No puede ingresar dos veces el mismo tipo de dato");
                        }

                        lista_aux_cliente.Add(cliente_datos);
                        cliente_datos = null;
                    }
                }
                else
                {
                    if (tipo == 1)
                    {
                        lista_aux_proveedor[dgvDatos.SelectedRows[0].Index] = proveedor_datos;
                    }
                    else if (tipo == 2)
                    {
                        lista_aux_cliente[dgvDatos.SelectedRows[0].Index] = cliente_datos;
                    }
                }

                if (tipo == 1)
                {
                    CargarGrilla(lista_aux_proveedor, null);
                }
                else if (tipo == 2)
                {
                    CargarGrilla(null, lista_aux_cliente);
                }


                ConfigurarForm(Program.Inicio);

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
        private void Valido() // Valido la entrada de datos
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {


                if (txtDato.Text == "")
                {
                    txtDato.Focus();
                    throw new Exception("Debe ingresar un dato");
                }

                if (tipo == 1)
                {
                    if (proveedor_datos.cod_tipo_dato == 5) // email
                    {
                        if (Logica_Funciones_Generales.email_bien_escrito(txtDato.Text) == false)
                        {
                            throw new Exception("Email incorrecto");
                        }
                    }
                    else if (proveedor_datos.cod_tipo_dato == 12) // CUIT
                    {
                        if (txtDato.Text.Length != 0)
                        {
                            if (txtDato.Text.Length != 13)
                            {
                                txtDato.Text = "";
                                txtDato.Focus();
                                throw new Exception("Largo del cuit incorrecto");
                            }
                            if (Logica_Funciones_Generales.validar_cuit(txtDato.Text) == false)
                            {
                                txtDato.Text = "";
                                txtDato.Focus();
                                throw new Exception("Cuit incorrecto");
                            }
                        }
                    }
                    else if (proveedor_datos.cod_tipo_dato == 13) // DNI
                    {
                        if (txtDato.Text.Length != 0 && txtDato.Text.Length != 8)
                        {
                            txtDato.Focus();
                            throw new Exception("El DNI debe contener 8 numeros");
                        }
                    }
                }
                else if (tipo == 2)
                {
                    if (cliente_datos.cod_tipo_dato == 5) // email
                    {
                        if (Logica_Funciones_Generales.email_bien_escrito(txtDato.Text) == false)
                        {
                            throw new Exception("Email incorrecto");
                        }
                    }
                    else if (cliente_datos.cod_tipo_dato == 12) // CUIT
                    {
                        if (txtDato.Text.Length != 0)
                        {
                            if (txtDato.Text.Length != 13)
                            {
                                txtDato.Text = "";
                                txtDato.Focus();
                                throw new Exception("Largo del cuit incorrecto");
                            }
                            if (Logica_Funciones_Generales.validar_cuit(txtDato.Text) == false)
                            {
                                txtDato.Text = "";
                                txtDato.Focus();
                                throw new Exception("Cuit incorrecto");
                            }
                        }
                    }
                    else if (cliente_datos.cod_tipo_dato == 13) // DNI
                    {
                        if (txtDato.Text.Length != 0 && txtDato.Text.Length != 8)
                        {
                            txtDato.Focus();
                            throw new Exception("El DNI debe contener 8 numeros");
                        }
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
        private void SeteoObjeto() // Setea el objeto dato antes de grabarlo
        {
            try
            {

                if (tipo == 1)
                {
                    ttipo_dato ttipo_dato = new ttipo_dato();
                    ttipo_dato.txt_desc = cbTipoDato.Text;
                    proveedor_datos.ttipo_dato = ttipo_dato;

                    proveedor_datos.cod_tipo_dato = (Convert.ToInt32(cbTipoDato.SelectedValue));
                    proveedor_datos.txt_dato_proveedor = txtDato.Text;
                    proveedor_datos.sn_activo = -1;
                }
                else if (tipo == 2)
                {
                    ttipo_dato ttipo_dato = new ttipo_dato();
                    ttipo_dato.txt_desc = cbTipoDato.Text;
                    cliente_datos.ttipo_dato = ttipo_dato;

                    cliente_datos.cod_tipo_dato = (Convert.ToInt32(cbTipoDato.SelectedValue));
                    cliente_datos.txt_dato_cliente = txtDato.Text;
                    cliente_datos.sn_activo = -1;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnNuevo_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ConfigurarForm(Program.Alta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrilla(List<proveedor_datos> _lista_aux_proveedor, List<cliente_datos> _lista_aux_cliente)
        {
            try
            {
                if (tipo == 1)
                {
                    if (!(_lista_aux_proveedor == null))
                    {
                        dgvDatos.Rows.Clear();
                        dgvDatos.RowCount = _lista_aux_proveedor.Count(p => p.sn_activo == -1);
                        if (dgvDatos.Rows.Count > 0)
                        {
                            int indice = 0;
                            foreach (proveedor_datos Dato in _lista_aux_proveedor)
                            {
                                if (Dato.sn_activo == -1)
                                {
                                    dgvDatos.Rows[indice].Cells[0].Value = Dato.cod_tipo_dato;
                                    dgvDatos.Rows[indice].Cells[1].Value = Dato.ttipo_dato.txt_desc;
                                    dgvDatos.Rows[indice].Cells[2].Value = Dato.txt_dato_proveedor;
                                    dgvDatos.Rows[indice].Cells[3].Value = Dato.sn_activo;
                                    indice = indice + 1;
                                }
                            }
                        }
                    }
                }
                else if (tipo == 2)
                {
                    if (!(_lista_aux_cliente == null))
                    {
                        dgvDatos.Rows.Clear();
                        dgvDatos.RowCount = _lista_aux_cliente.Count(p => p.sn_activo == -1);
                        if (dgvDatos.Rows.Count > 0)
                        {
                            int indice = 0;
                            foreach (cliente_datos Dato in _lista_aux_cliente)
                            {
                                if (Dato.sn_activo == -1)
                                {
                                    dgvDatos.Rows[indice].Cells[0].Value = Dato.cod_tipo_dato;
                                    dgvDatos.Rows[indice].Cells[1].Value = Dato.ttipo_dato.txt_desc;
                                    dgvDatos.Rows[indice].Cells[2].Value = Dato.txt_dato_cliente;
                                    dgvDatos.Rows[indice].Cells[3].Value = Dato.sn_activo;
                                    indice = indice + 1;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // Carga la grilla

        private void btnEliminar_Click(System.Object sender, System.EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int indice = 0;
                if (tipo == 1)
                {
                    foreach (proveedor_datos Dato in lista_aux_proveedor)
                    {
                        if (Dato.cod_tipo_dato == (Convert.ToInt32(cbTipoDato.SelectedValue)))
                            indice = lista_aux_proveedor.IndexOf(Dato);
                    }

                    if (proveedor.id_proveedor == 0)
                    {
                        lista_aux_proveedor.RemoveAt(indice);
                    }
                    else
                    {
                        lista_aux_proveedor[indice].sn_activo = 0;
                    }
                    CargarGrilla(lista_aux_proveedor, null);
                }
                else if (tipo == 2)
                {
                    foreach (cliente_datos Dato in lista_aux_cliente)
                    {
                        if (Dato.cod_tipo_dato == (Convert.ToInt32(cbTipoDato.SelectedValue)))
                            indice = lista_aux_cliente.IndexOf(Dato);
                    }

                    if (cliente.id_cliente == 0)
                    {
                        lista_aux_cliente.RemoveAt(indice);
                    }
                    else
                    {
                        lista_aux_cliente[indice].sn_activo = 0;
                    }

                    CargarGrilla(null, lista_aux_cliente);
                }
                ConfigurarForm(Program.Inicio);

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
                if (tipo == 1)
                {
                    proveedor_datos = null;
                    proveedor_datos = new proveedor_datos();
                }
                else if (tipo == 2)
                {
                    cliente_datos = null;
                    cliente_datos = new cliente_datos();
                }
                LimpioForm();
                ConfigurarForm(Program.Inicio);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmCliente_Datos_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                ConfigurarForm(Program.Inicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Habilito(bool habilito)
        {

            try
            {
                if (habilito == true)
                {
                    foreach (Control controles in this.Controls)
                    {
                        if (controles is GroupBox)
                        {
                            foreach (Control cont in controles.Controls)
                            {
                                if (!(cont is Label))
                                    cont.Enabled = true;
                            }
                        }
                    }
                }
                else
                    foreach (Control controles in this.Controls)
                    {
                        if (controles is GroupBox)
                        {
                            foreach (Control cont in controles.Controls)
                            {
                                if (!(cont is Label))
                                    cont.Enabled = false;
                            }
                        }
                    }

                btnSalir.Enabled = true;
                btnAceptar.Enabled = true;
                btnNuevo.Enabled = false;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // Habilito los controles o no
        private void btnAceptar_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDato_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbTipoDato.SelectedValue) == 12) //si es cuit
            {
                if (txtDato.Text != "")
                {
                    txtDato.Text = txtDato.Text.Replace("-", "");
                    var t = Convert.ToInt64(txtDato.Text);
                    txtDato.Text = t.ToString("##-########-#");
                }
            }
        }

        private void KeyPress_solo_numero(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void KeyPress_cuit(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == '-')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtDato_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbTipoDato.SelectedValue) == 12) //si es cuit
                {
                    KeyPress_cuit(sender, e);
                }
                else if (Convert.ToInt32(cbTipoDato.SelectedValue) == 4 || Convert.ToInt32(cbTipoDato.SelectedValue) == 7 || Convert.ToInt32(cbTipoDato.SelectedValue) == 10 || Convert.ToInt32(cbTipoDato.SelectedValue) == 13) //si telefono1 o telefono2 o telefono3 o es dni
                {
                    KeyPress_solo_numero(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

