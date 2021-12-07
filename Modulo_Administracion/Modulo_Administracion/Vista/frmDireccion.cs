using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Modulo_Administracion
{
    public partial class frmDireccion : Form
    {




        int Accion;
        proveedor proveedor = null;
        cliente cliente = null;

        proveedor_dir proveedor_direccion = null;
        cliente_dir cliente_direccion = null;

        public List<proveedor_dir> lista_aux_proveedor = new List<proveedor_dir>();
        public List<cliente_dir> lista_aux_cliente = new List<cliente_dir>();

        Logica_Proveedor_Direccion logica_proveedor_direccion = new Logica_Proveedor_Direccion();
        Logica_Cliente_Direccion logica_cliente_direccion = new Logica_Cliente_Direccion();

        int tipo; //1 es proveedor , 2 es cliente
        public frmDireccion()
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                    this.Text = "Direcciones del proveedor";
                    ICollection<proveedor_dir> lista_obj_direccion_proveedor = proveedor.proveedor_dir;
                    if (!(lista_obj_direccion_proveedor == null))
                    {
                        lista_aux_proveedor.AddRange(lista_obj_direccion_proveedor);
                        CargarGrilla(lista_aux_proveedor, null);
                    }
                }
                else if (tipo == 2)
                {
                    cliente = _cliente;
                    this.Text = "Direcciones del cliente";
                    ICollection<cliente_dir> lista_obj_direccion_cliente = cliente.cliente_dir;
                    if (!(lista_obj_direccion_cliente == null))
                    {
                        lista_aux_cliente.AddRange(lista_obj_direccion_cliente);
                        CargarGrilla(null, lista_aux_cliente);
                    }
                }

                Logica_Funciones_Generales.CargarComboBox("ttipo_dir", cbTipoDir, "txt_desc", "1=1", "cod_tipo_dir", "cod_tipo_dir");
                Logica_Funciones_Generales.CargarComboBox("ttipo_calle", cbTipoCalle, "txt_desc", "1=1", "cod_tipo_calle", "cod_tipo_calle");

                cbTipoDir.SelectedValue = 1;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        } // inicializa el form



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

                cbTipoCalle.SelectedValue = 1;
                cbTipoDir.SelectedValue = 1;
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
                            dgvDirecciones.Enabled = true;
                            btnAgregar.Visible = false;
                            btnCancelarSeleccion.Visible = false;
                            btnBorrar.Visible = false;

                            //seteo columnas
                            ordenarColumnasDataGridView_con_click();
                            dgvDirecciones.Focus();


                            Accion = Program.Inicio;
                            break;
                        }

                    case Program.Alta:
                        {

                            Habilito(true);
                            btnNuevo.Enabled = false;
                            btnAgregar.Visible = true;
                            btnCancelarSeleccion.Visible = true;
                            btnAgregar.Text = "Agregar";
                            Accion = Program.Alta;

                            if (tipo == 1)
                            {
                                //genero una direccion vacia
                                proveedor_direccion = new proveedor_dir();
                                proveedor_direccion.id_proveedor = proveedor.id_proveedor;
                                proveedor_direccion.cod_tipo_dir = 0;
                                proveedor_direccion.cod_clase_dir = 1;
                                proveedor_direccion.cod_tipo_calle = 0;
                                proveedor_direccion.cod_calle = 0;
                                proveedor_direccion.txt_numero = "";
                                proveedor_direccion.txt_apto = "";
                                proveedor_direccion.txt_piso = "";
                                proveedor_direccion.txt_direccion = "";
                                proveedor_direccion.txt_cod_postal = "";
                                proveedor_direccion.cod_pais = 0;
                                proveedor_direccion.cod_provincia = 0;
                                proveedor_direccion.cod_municipio = 0;
                                proveedor_direccion.sn_activo = -1;
                                proveedor_direccion.fec_ult_modif = DateTime.Now;
                                proveedor_direccion.accion = "ALTA";
                                proveedor_direccion.proveedor = proveedor;
                                proveedor_direccion.ttipo_dir = new ttipo_dir();
                                proveedor_direccion.tpais = new tpais();
                                proveedor_direccion.tprovincia = new tprovincia();
                                proveedor_direccion.tcalle = new tcalle();
                                proveedor_direccion.tmunicipio = new tmunicipio();
                                proveedor_direccion.ttipo_calle = new ttipo_calle();
                            }
                            else if (tipo == 2)
                            {
                                //genero una direccion vacia
                                cliente_direccion = new cliente_dir();
                                cliente_direccion.id_cliente = cliente.id_cliente;
                                cliente_direccion.cod_tipo_dir = 0;
                                cliente_direccion.cod_clase_dir = 1;
                                cliente_direccion.cod_tipo_calle = 0;
                                cliente_direccion.cod_calle = 0;
                                cliente_direccion.txt_numero = "";
                                cliente_direccion.txt_apto = "";
                                cliente_direccion.txt_piso = "";
                                cliente_direccion.txt_direccion = "";
                                cliente_direccion.txt_cod_postal = "";
                                cliente_direccion.cod_pais = 0;
                                cliente_direccion.cod_provincia = 0;
                                cliente_direccion.cod_municipio = 0;
                                cliente_direccion.sn_activo = -1;
                                cliente_direccion.fec_ult_modif = DateTime.Now;
                                cliente_direccion.accion = "ALTA";
                                cliente_direccion.cliente = cliente;
                                cliente_direccion.ttipo_dir = new ttipo_dir();
                                cliente_direccion.tpais = new tpais();
                                cliente_direccion.tprovincia = new tprovincia();
                                cliente_direccion.tcalle = new tcalle();
                                cliente_direccion.tmunicipio = new tmunicipio();
                                cliente_direccion.ttipo_calle = new ttipo_calle();
                            }

                            cbTipoDir.Focus();
                            break;
                        }

                    case Program.Modif:
                        {
                            Habilito(true);
                            btnNuevo.Enabled = false;
                            btnAgregar.Visible = true;
                            btnCancelarSeleccion.Visible = true;
                            btnBorrar.Enabled = true;
                            btnBorrar.Visible = true;
                            btnAgregar.Text = "Modificar";
                            Accion = Program.Modif;
                            cbTipoDir.Focus();

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
                foreach (DataGridViewColumn column in dgvDirecciones.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void dgvDirecciones_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (dgvDirecciones.SelectedRows.Count > 0)
                {
                    if (tipo == 1)
                    {
                        txtPais.Text = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index].tpais.txt_desc;
                        txtProvincia.Text = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index].tprovincia.txt_desc;
                        txtLocalidad.Text = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index].tmunicipio.txt_desc;
                        txtCodPostal.Text = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index].txt_cod_postal;
                        txtCalle.Text = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index].txt_direccion;
                        txtNumero.Text = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index].txt_numero;
                        txtApto.Text = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index].txt_apto;
                        txtPiso.Text = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index].txt_piso;
                        cbTipoDir.SelectedValue = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index].ttipo_dir.cod_tipo_dir;
                        cbTipoCalle.SelectedValue = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index].cod_tipo_calle;
                        proveedor_direccion = lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index];
                    }
                    else if (tipo == 2)
                    {
                        txtPais.Text = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index].tpais.txt_desc;
                        txtProvincia.Text = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index].tprovincia.txt_desc;
                        txtLocalidad.Text = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index].tmunicipio.txt_desc;
                        txtCodPostal.Text = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index].txt_cod_postal;
                        txtCalle.Text = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index].txt_direccion;
                        txtNumero.Text = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index].txt_numero;
                        txtApto.Text = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index].txt_apto;
                        txtPiso.Text = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index].txt_piso;
                        cbTipoDir.SelectedValue = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index].ttipo_dir.cod_tipo_dir;
                        cbTipoCalle.SelectedValue = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index].cod_tipo_calle;
                        cliente_direccion = lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index];
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
                        foreach (proveedor_dir Dir in lista_aux_proveedor)
                        {
                            if (Dir.cod_tipo_dir == (Convert.ToInt32(cbTipoDir.SelectedValue)) && Dir.sn_activo == -1)
                                throw new Exception("No puede ingresar dos veces el mismo tipo de dirección");
                        }

                        lista_aux_proveedor.Add(proveedor_direccion);
                        proveedor_direccion = null;
                    }
                    else if (tipo == 2)
                    {
                        foreach (cliente_dir Dir in lista_aux_cliente)
                        {
                            if (Dir.cod_tipo_dir == (Convert.ToInt32(cbTipoDir.SelectedValue)) && Dir.sn_activo == -1)
                                throw new Exception("No puede ingresar dos veces el mismo tipo de dirección");
                        }

                        lista_aux_cliente.Add(cliente_direccion);
                        cliente_direccion = null;
                    }
                }
                else
                {
                    if (tipo == 1)
                    {
                        lista_aux_proveedor[dgvDirecciones.SelectedRows[0].Index] = proveedor_direccion;
                    }
                    else if (tipo == 2)
                    {
                        lista_aux_cliente[dgvDirecciones.SelectedRows[0].Index] = cliente_direccion;
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

                if (txtCalle.Text == "")
                {
                    txtCalle.Focus();
                    throw new Exception("Debe ingresar una calle");
                }
                if (txtNumero.Text == "")
                {
                    txtNumero.Focus();
                    throw new Exception("Debe ingresar un numero de dirección");
                }
                if (txtPais.Text == "")
                {
                    txtPais.Focus();
                    throw new Exception("Debe ingresar un pais");
                }
                if (txtProvincia.Text == "")
                {
                    txtProvincia.Focus();
                    throw new Exception("Debe ingresar una provincia");
                }
                if (txtLocalidad.Text == "")
                {
                    txtLocalidad.Focus();
                    throw new Exception("Debe ingresar una localidad");
                }
                if (txtCodPostal.Text == "")
                {
                    txtCodPostal.Focus();
                    throw new Exception("Debe buscar una localidad que tenga código postal");
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
        private void SeteoObjeto() // Setea el objeto direccion antes de grabarlo
        {
            try
            {
                if (tipo == 1)
                {
                    ttipo_dir ttipo_dir = new ttipo_dir();
                    ttipo_dir.cod_tipo_dir = (Convert.ToInt32(cbTipoDir.SelectedValue));
                    ttipo_dir.txt_desc = cbTipoDir.Text;
                    proveedor_direccion.ttipo_dir = ttipo_dir;

                    ttipo_calle ttipo_calle = new ttipo_calle();
                    ttipo_calle.txt_desc = cbTipoCalle.Text;
                    proveedor_direccion.ttipo_calle = ttipo_calle;

                    proveedor_direccion.cod_tipo_calle = (Convert.ToInt32(cbTipoCalle.SelectedValue));
                    proveedor_direccion.txt_cod_postal = txtCodPostal.Text;
                    proveedor_direccion.txt_numero = txtNumero.Text;
                    proveedor_direccion.txt_piso = txtPiso.Text;
                    proveedor_direccion.txt_apto = txtApto.Text;

                }
                else if (tipo == 2)
                {
                    ttipo_dir ttipo_dir = new ttipo_dir();
                    ttipo_dir.cod_tipo_dir = (Convert.ToInt32(cbTipoDir.SelectedValue));
                    ttipo_dir.txt_desc = cbTipoDir.Text;
                    cliente_direccion.ttipo_dir = ttipo_dir;

                    ttipo_calle ttipo_calle = new ttipo_calle();
                    ttipo_calle.cod_tipo_calle = (Convert.ToInt32(cbTipoCalle.SelectedValue));
                    ttipo_calle.txt_desc = cbTipoCalle.Text;
                    cliente_direccion.ttipo_calle = ttipo_calle;

                    cliente_direccion.txt_cod_postal = txtCodPostal.Text;
                    cliente_direccion.txt_numero = txtNumero.Text;
                    cliente_direccion.txt_piso = txtPiso.Text;
                    cliente_direccion.txt_apto = txtApto.Text;
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


        private void CargarGrilla(List<proveedor_dir> _lista_aux_proveedor, List<cliente_dir> _lista_aux_cliente)
        {
            try
            {
                if (tipo == 1)
                {
                    if (!(_lista_aux_proveedor == null))
                    {
                        dgvDirecciones.Rows.Clear();
                        dgvDirecciones.RowCount = _lista_aux_proveedor.Count(p => p.sn_activo == -1);
                        if (dgvDirecciones.Rows.Count > 0)
                        {
                            int indice = 0;
                            foreach (proveedor_dir Dir in _lista_aux_proveedor)
                            {
                                if (Dir.sn_activo == -1)
                                {
                                    dgvDirecciones.Rows[indice].Cells[0].Value = Dir.ttipo_dir.txt_desc;
                                    dgvDirecciones.Rows[indice].Cells[1].Value = Dir.ttipo_calle.txt_desc;
                                    dgvDirecciones.Rows[indice].Cells[2].Value = Dir.txt_direccion;
                                    dgvDirecciones.Rows[indice].Cells[3].Value = Dir.txt_numero;
                                    dgvDirecciones.Rows[indice].Cells[4].Value = Dir.txt_apto;
                                    dgvDirecciones.Rows[indice].Cells[5].Value = Dir.txt_piso;
                                    dgvDirecciones.Rows[indice].Cells[6].Value = Dir.tpais.txt_desc;
                                    dgvDirecciones.Rows[indice].Cells[7].Value = Dir.tprovincia.txt_desc;
                                    dgvDirecciones.Rows[indice].Cells[8].Value = Dir.tmunicipio.txt_desc;
                                    dgvDirecciones.Rows[indice].Cells[9].Value = Dir.txt_cod_postal;
                                    dgvDirecciones.Rows[indice].Cells[10].Value = Dir.ttipo_dir.cod_tipo_dir;
                                    dgvDirecciones.Rows[indice].Cells[11].Value = Dir.sn_activo;
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
                        dgvDirecciones.Rows.Clear();
                        dgvDirecciones.RowCount = _lista_aux_cliente.Count(p => p.sn_activo == -1);
                        if (dgvDirecciones.Rows.Count > 0)
                        {
                            int indice = 0;
                            foreach (cliente_dir Dir in _lista_aux_cliente)
                            {
                                if (Dir.sn_activo == -1)
                                {
                                    dgvDirecciones.Rows[indice].Cells[0].Value = Dir.ttipo_dir.txt_desc;
                                    dgvDirecciones.Rows[indice].Cells[1].Value = Dir.ttipo_calle.txt_desc;
                                    dgvDirecciones.Rows[indice].Cells[2].Value = Dir.txt_direccion;
                                    dgvDirecciones.Rows[indice].Cells[3].Value = Dir.txt_numero;
                                    dgvDirecciones.Rows[indice].Cells[4].Value = Dir.txt_apto;
                                    dgvDirecciones.Rows[indice].Cells[5].Value = Dir.txt_piso;
                                    dgvDirecciones.Rows[indice].Cells[6].Value = Dir.tpais.txt_desc;
                                    dgvDirecciones.Rows[indice].Cells[7].Value = Dir.tprovincia.txt_desc;
                                    dgvDirecciones.Rows[indice].Cells[8].Value = Dir.tmunicipio.txt_desc;
                                    dgvDirecciones.Rows[indice].Cells[9].Value = Dir.txt_cod_postal;
                                    dgvDirecciones.Rows[indice].Cells[10].Value = Dir.ttipo_dir.cod_tipo_dir;
                                    dgvDirecciones.Rows[indice].Cells[11].Value = Dir.sn_activo;
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
                    foreach (proveedor_dir Dir in lista_aux_proveedor)
                    {
                        if (Dir.cod_tipo_dir == (Convert.ToInt32(cbTipoDir.SelectedValue)))
                            indice = lista_aux_proveedor.IndexOf(Dir);
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
                    foreach (cliente_dir Dir in lista_aux_cliente)
                    {
                        if (Dir.cod_tipo_dir == (Convert.ToInt32(cbTipoDir.SelectedValue)))
                            indice = lista_aux_cliente.IndexOf(Dir);
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
                    proveedor_direccion = null;
                    proveedor_direccion = new proveedor_dir();
                }
                else if (tipo == 2)
                {
                    cliente_direccion = null;
                    cliente_direccion = new cliente_dir();
                }
                LimpioForm();
                ConfigurarForm(Program.Inicio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmDireccion_Load(System.Object sender, System.EventArgs e)
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
                txtCodPostal.Enabled = false;
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

        #region calle - pais - provincia - localidad

        private void Buscar(List<string> Valores, TextBox txt, object sender) // Busco calle, pais, dpto, y localidad
        {
            try // Este metodo me busca segun el textbox q lo llame
            {

                frmBuscar frm = new frmBuscar();
                frm.Text = "Buscar Dirección";
                frm.btnNuevo.Enabled = false;
                string txtName = ((Button)sender).Name;

                switch (txtName)
                {
                    case "btnBuscarCalle":
                        {
                            frm.Text = "Buscar Calle";
                            if (tipo == 1)
                            {
                                frm.IniciarForm(logica_proveedor_direccion.buscar_calle(Valores).Tables[0], 2);
                            }
                            else if (tipo == 2)
                            {
                                frm.IniciarForm(logica_cliente_direccion.buscar_calle(Valores).Tables[0], 2);
                            }
                            break;
                        }

                    case "btnBuscarProvincia":
                        {
                            frm.Text = "Buscar Provincia";
                            if (tipo == 1)
                            {
                                frm.IniciarForm(logica_proveedor_direccion.buscar_provincia(Valores).Tables[0], 2);
                            }
                            else if (tipo == 2)
                            {
                                frm.IniciarForm(logica_cliente_direccion.buscar_provincia(Valores).Tables[0], 2);
                            }
                            break;
                        }

                    case "btnBuscarPais":
                        {
                            frm.Text = "Buscar Pais";
                            if (tipo == 1)
                            {
                                frm.IniciarForm(logica_proveedor_direccion.buscar_pais(Valores).Tables[0], 2);
                            }
                            else if (tipo == 2)
                            {
                                frm.IniciarForm(logica_cliente_direccion.buscar_pais(Valores).Tables[0], 2);
                            }
                            break;
                        }

                    case "btnBuscarLoc":
                        {
                            frm.Text = "Buscar Municipio";
                            if (tipo == 1)
                            {
                                frm.IniciarForm(logica_proveedor_direccion.buscar_municipio(Valores).Tables[0], 2);
                            }
                            else if (tipo == 2)
                            {
                                frm.IniciarForm(logica_cliente_direccion.buscar_municipio(Valores).Tables[0], 2);
                            }
                            break;
                        }
                }
                string txtName1 = ((Button)sender).Name;
                if (frm.DialogResult == DialogResult.OK)
                {
                    switch (txtName1)
                    {
                        case "btnBuscarCalle":
                            {

                                if (tipo == 1)
                                {
                                    proveedor_direccion.cod_calle = Convert.ToInt32(frm.dgvResultados.SelectedRows[0].Cells[0].Value);
                                    proveedor_direccion.txt_direccion = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);

                                    txt.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);

                                }
                                else if (tipo == 2)
                                {
                                    cliente_direccion.cod_calle = Convert.ToInt32(frm.dgvResultados.SelectedRows[0].Cells[0].Value);
                                    cliente_direccion.txt_direccion = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);

                                    txt.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);

                                }
                                break;

                            }

                        case "btnBuscarProvincia":
                            {

                                if (tipo == 1)
                                {

                                    proveedor_direccion.cod_provincia = Convert.ToInt32(frm.dgvResultados.SelectedRows[0].Cells[0].Value);
                                    proveedor_direccion.tprovincia.txt_desc = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);
                                    txt.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);

                                }
                                else if (tipo == 2)
                                {

                                    cliente_direccion.cod_provincia = Convert.ToInt32(frm.dgvResultados.SelectedRows[0].Cells[0].Value);
                                    cliente_direccion.tprovincia.txt_desc = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);
                                    txt.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);

                                }
                                break;

                            }

                        case "btnBuscarPais":
                            {

                                if (tipo == 1)
                                {

                                    proveedor_direccion.cod_pais = Convert.ToInt32(frm.dgvResultados.SelectedRows[0].Cells[0].Value);
                                    proveedor_direccion.tpais.txt_desc = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);
                                    txt.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);

                                }
                                else if (tipo == 2)
                                {

                                    cliente_direccion.cod_pais = Convert.ToInt32(frm.dgvResultados.SelectedRows[0].Cells[0].Value);
                                    cliente_direccion.tpais.txt_desc = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);
                                    txt.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);

                                }

                                break;

                            }

                        case "btnBuscarLoc":
                            {
                                if (tipo == 1)
                                {
                                    proveedor_direccion.tmunicipio.cod_municipio = Convert.ToInt32(frm.dgvResultados.SelectedRows[0].Cells[0].Value);
                                    proveedor_direccion.tmunicipio.txt_desc = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);

                                    txtLocalidad.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);
                                    txtCodPostal.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[2].Value);

                                }
                                else if (tipo == 2)
                                {

                                    cliente_direccion.tmunicipio.cod_municipio = Convert.ToInt32(frm.dgvResultados.SelectedRows[0].Cells[0].Value);
                                    cliente_direccion.tmunicipio.txt_desc = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);

                                    txtLocalidad.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);
                                    txtCodPostal.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[2].Value);

                                }

                                break;

                            }
                    }
                    //SelectNextControl((Button)sender, true, true, true, true);
                }
                else
                {
                    txt.Text = "";
                    txt.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void txtCalle_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                if (txtCalle.Text != "")
                    BuscarCalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocalidad.Text = "";
            }
        }
        private void txtPais_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                if (txtPais.Text != "")
                    BuscarPais(btnBuscarPais);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocalidad.Text = "";
            }
        }
        private void txtProvincia_LostFocus(object sender, System.EventArgs e)
        {
            try
            {
                if (txtProvincia.Text != "")
                    BuscarProvincia(btnBuscarProvincia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocalidad.Text = "";
            }
        }
        private void txtLocalidad_LostFocus(object sender, System.EventArgs e)
        {

            try
            {
                if (txtLocalidad.Text != "")
                    BuscarLocalidad(btnBuscarLoc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLocalidad.Text = "";
            }
        }

        private void BuscarCalle()
        {
            try
            {
                if (txtCalle.Text != "")
                {
                    List<string> lista = new List<string>();
                    lista.Add((txtCalle.Text));
                    Buscar(lista, txtCalle, btnBuscarCalle);
                }
            }
            catch (Exception ex)
            {

                txtCalle.Text = "";
                throw ex;
            }
        }
        private void BuscarPais(System.Object sender)
        {
            try
            {
                if (txtPais.Text != "")
                {
                    List<string> lista = new List<string>();
                    lista.Add((txtPais.Text));
                    Buscar(lista, txtPais, sender);
                }
            }
            catch (Exception ex)
            {

                txtPais.Text = "";
                throw ex;
            }
        }
        private void BuscarProvincia(System.Object sender)
        {
            try
            {
                if (txtProvincia.Text != "" & txtPais.Text != "")
                {
                    List<string> lista = new List<string>();
                    // lista.Add((txtPais.Text)) --esto esta mal, si ya tengo el codigo tengo que buscar por codigo, no por txt
                    if (tipo == 1)
                    {
                        lista.Add(proveedor_direccion.cod_pais.ToString());
                    }
                    else if (tipo == 2)
                    {
                        lista.Add(cliente_direccion.cod_pais.ToString());
                    }
                    lista.Add((txtProvincia.Text));
                    Buscar(lista, txtProvincia, sender);
                }
                else if (txtProvincia.Text != "" & txtPais.Text == "")
                {
                    MessageBox.Show("Tiene que elegir primero un Pais", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtProvincia.Text = "";
                    txtPais.Focus();
                }
            }
            catch (Exception ex)
            {

                txtProvincia.Text = "";
                throw ex;
            }
        }
        private void BuscarLocalidad(System.Object sender)
        {
            try
            {
                // PEB 16/02/2012 se corrigio practimanente toda la funcion.
                // ahora se pasan el Cod_pais y cod_provincia y se agregaron los msg de error
                if (txtLocalidad.Text != "" & txtPais.Text != "" & txtProvincia.Text != "")
                {
                    List<string> lista = new List<string>();
                    // lista.Add((txtPais.Text))
                    // lista.Add((txtProvincia.Text))
                    if (tipo == 1)
                    {
                        lista.Add(proveedor_direccion.cod_pais.ToString());
                        lista.Add(proveedor_direccion.cod_provincia.ToString());
                    }
                    else if (tipo == 2)
                    {
                        lista.Add(cliente_direccion.cod_pais.ToString());
                        lista.Add(cliente_direccion.cod_provincia.ToString());
                    }
                    lista.Add((txtLocalidad.Text));
                    Buscar(lista, txtLocalidad, sender);
                }
                else if (txtLocalidad.Text != "" & txtPais.Text == "")
                {
                    MessageBox.Show("El País no puede estar vacío", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLocalidad.Text = "";
                    txtPais.Focus();
                }
                else if (txtLocalidad.Text != "" & txtProvincia.Text == "")
                {
                    MessageBox.Show("La provincia no puede estar vacía", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLocalidad.Text = "";
                    txtProvincia.Focus();
                }
            }
            catch (Exception ex)
            {

                txtLocalidad.Text = "";
                throw ex;
            }
        }
        private void btnBuscarCalle_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarCalle();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscarProvincia_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                BuscarProvincia(btnBuscarProvincia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscarPais_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                BuscarPais(btnBuscarPais);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscarLoc_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                BuscarLocalidad(btnBuscarLoc);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion calle - pais - provincia - localidad


    }
}

