using DevExpress.Utils.Menu;
using DevExpress.XtraReports.UI;
using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Modulo_Administracion.Vista
{
    public partial class frmFacturaGestion : Form
    {

        factura factura = null;
        Logica_Factura logica_factura = new Logica_Factura();
        Logica_Cliente logica_cliente = new Logica_Cliente();
        int Accion;

        string opcion_1_dropDownButton = "Nueva Factura";
        string opcion_2_dropDownButton = "Ver Factura";
        string opcion_3_dropDownButton = "Generar PDF";
        string opcion_4_dropDownButton = "Generar PDF e imprimir";

        public Form ParentForm { get; set; }


        private void dgvFacturas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.RowIndex >= 0)
                {
                    factura = logica_factura.buscar_factura_por_id_factura(Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells[0].Value));

                    if (factura == null)
                    {
                        throw new Exception("La factura no existe en el sistema , podria revisar esta factura en las carpetas donde guardaban las mismas anteriormente");
                    }


                    frmFactura form = new frmFactura(factura);
                    form.ParentForm = this;
                    this.Hide();
                    DialogResult dr = form.ShowDialog();
                    if (dr == DialogResult.OK)
                    {

                        if (rdBusqueda1.Checked == true)
                        {
                            buscar_facturas_por_fecha();
                        }
                        else if (rdBusqueda2.Checked == true)
                        {
                            buscar_facturas_por_metodo_2();
                        }
                    }

                    dgvFacturas.ClearSelection();
                    int row_index = 0;
                    if (e.RowIndex >= dgvFacturas.Rows.Count)
                    {
                        row_index = dgvFacturas.Rows.Count - 1;

                    }
                    else
                    {
                        row_index = e.RowIndex;
                    }

                    dgvFacturas.Rows[row_index].Selected = true;
                    dgvFacturas.FirstDisplayedScrollingRowIndex = row_index;

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


        public frmFacturaGestion()
        {
            try
            {
                InitializeComponent();
                Logica_Funciones_Generales.CargarComboBox("ttipo_factura", cbTipoFactura, "txt_desc", "cod_tipo_factura in (1,2,6)", "cod_tipo_factura", "cod_tipo_factura");

                txtClienteId.Visible = false;
                DXPopupMenu popupMenu = new DXPopupMenu();
                //popupMenu.Items.Add(new DXMenuItem() { Caption = opcion_1_dropDownButton });
                popupMenu.Items.Add(new DXMenuItem() { Caption = opcion_2_dropDownButton });
                popupMenu.Items.Add(new DXMenuCheckItem() { Caption = opcion_3_dropDownButton });
                popupMenu.Items.Add(new DXMenuCheckItem() { Caption = opcion_4_dropDownButton });
                btnDropDownButton.DropDownControl = popupMenu;

                foreach (DXMenuItem item in popupMenu.Items)
                    item.Click += itemDropDownButton_Click;


                String pkInstalledPrinters;
                for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
                {
                    pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                    cbImpresoras.Items.Add(pkInstalledPrinters);
                }

                PrinterSettings settings = new PrinterSettings();
                cbImpresoras.Text = settings.PrinterName;

                if (cbImpresoras.Text == "")
                {
                    cbImpresoras.SelectedIndex = 0;
                }


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

                monthCalendar1.SetDate(DateTime.Now);
                dgvFacturas.Rows.Clear();


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

                btnSalir.Enabled = true;


                //datagridview
                dgvFacturas.Enabled = true;

                txtNroCopias.Text = Program.nro_copias.ToString();

                switch (queHago)
                {
                    case Program.Inicio:
                        {

                            //limpio todo el form , excepto el datagridview
                            limpio_form();

                            buscar_facturas_por_fecha();
                            //modifico  enabled - visible - text 

                            rdBusqueda1.Checked = true;
                            monthCalendar1.Enabled = true;
                            panelBusqueda2.Enabled = false;



                            //accion
                            Accion = Program.Inicio;

                            dgvFacturas.Focus();

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


                dgvFacturas.Columns[0].Visible = false;
                dgvFacturas.Columns[1].Width = 200;
                dgvFacturas.Columns[2].Width = 200;
                dgvFacturas.Columns[3].Width = 200;
                dgvFacturas.Columns[4].Width = 200;
                dgvFacturas.Columns[5].Width = 200;
                dgvFacturas.Columns[6].Width = 250;

            }
            catch (Exception ex)
            {
                throw ex;
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










        private void frmFacturaGestion_Load(object sender, EventArgs e)
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

        private void ordenarColumnasDataGridView_con_click()
        {
            try
            {
                //pongo que todas las columnas se puedan ordenar si el usuario hace click en la columna
                foreach (DataGridViewColumn column in dgvFacturas.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenar_data_grid_view(List<factura> lista_facturas)
        {
            try
            {
                dgvFacturas.RowCount = lista_facturas.Count;
                int indice = 0;
                foreach (factura factura in lista_facturas)
                {
                    dgvFacturas.Rows[indice].Cells[0].Value = factura.id_factura;
                    dgvFacturas.Rows[indice].Cells[1].Value = factura.ttipo_factura.txt_desc;
                    dgvFacturas.Rows[indice].Cells[2].Value = factura.ttipo_factura.letra + " " + factura.nro_factura.ToString();
                    dgvFacturas.Rows[indice].Cells[3].Value = factura.fecha.ToString("dd/MM/yyyy");
                    dgvFacturas.Rows[indice].Cells[4].Value = factura.cliente.nombre_fantasia;
                    if (factura.ttipo_factura.cod_tipo_factura == 2 || factura.ttipo_factura.cod_tipo_factura == 6) //si es nota de credito o debito
                    {
                        dgvFacturas.Rows[indice].Cells[5].Value = factura.precio_final;
                    }
                    else
                    {
                        if (factura.cliente.id_condicion_factura == 1)
                        {
                            dgvFacturas.Rows[indice].Cells[5].Value = factura.precio_final_con_pago_mayor_a_30_dias;
                        }
                        else if (factura.cliente.id_condicion_factura == 2)
                        {
                            dgvFacturas.Rows[indice].Cells[5].Value = factura.precio_final_con_pago_menor_a_30_dias;
                        }
                        else if (factura.cliente.id_condicion_factura == 3)
                        {
                            dgvFacturas.Rows[indice].Cells[5].Value = factura.precio_final_con_pago_menor_a_7_dias;
                        }
                    }
                    dgvFacturas.Rows[indice].Cells[6].Value = factura.observacion == null ? "" : factura.observacion.ToString();

                    if (factura.sn_emitida == -1)
                    {
                        dgvFacturas.Rows[indice].Cells[7].Value = "SI";
                    }
                    else
                    {
                        dgvFacturas.Rows[indice].Cells[7].Value = "NO";
                    }

                    dgvFacturas.Rows[indice].Cells[8].Value = factura.ttipo_factura.cod_tipo_factura.ToString();
                    indice = indice + 1;
                }

                //seteo columnas
                seteoColumnasDataGridView();

                //seteo columnas
                ordenarColumnasDataGridView_con_click();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void buscar_facturas_por_fecha()
        {

            try
            {

                //datagridview
                dgvFacturas.Rows.Clear();
                List<factura> lista_facturas_por_fecha = logica_factura.buscar_facturas_por_fecha(monthCalendar1.SelectionRange.Start.Date);
                if (lista_facturas_por_fecha != null)
                {
                    if (lista_facturas_por_fecha.Count > 0)
                    {
                        llenar_data_grid_view(lista_facturas_por_fecha);
                    }
                    else
                    {
                        dgvFacturas.Rows.Clear();
                    }
                }
                else
                {
                    throw new Exception("Error al ir a buscar las facturas");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                buscar_facturas_por_fecha();
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


        private void limpiar_panel_filtros()
        {
            try
            {
                txtNroFactura.Text = "";
                txtCodigo_articulo.Text = "";
                txtCodigo_articulo_marca.Text = "";
                txtFechaDesde.Text = "";
                txtFechaHasta.Text = "";
                txtCliente.Text = "";
                txtClienteId.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void rdBusqueda1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdBusqueda1.Checked == true)
                {
                    panelBusqueda2.Enabled = false;
                    monthCalendar1.Enabled = true;
                    buscar_facturas_por_fecha();
                    limpiar_panel_filtros();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdBusqueda2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdBusqueda2.Checked == true)
                {
                    panelBusqueda2.Enabled = true;
                    monthCalendar1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtFechaDesde_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtFechaDesde.Text != "")
                {
                    txtFechaDesde.Text = Logica_Funciones_Generales.ValidarFecha(txtFechaDesde.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtFechaHasta_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtFechaHasta.Text != "")
                {
                    txtFechaHasta.Text = Logica_Funciones_Generales.ValidarFecha(txtFechaHasta.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buscar_facturas_por_metodo_2()
        {
            try
            {
                if (cbTipoFactura.SelectedItem == null)
                {
                    cbTipoFactura.Focus();
                    throw new Exception("Debe seleccionar un tipo de factura");
                }

                if (txtFechaDesde.Text != "" && txtFechaHasta.Text == "")
                {
                    txtFechaHasta.Focus();
                    throw new Exception("Debe completar la fecha hasta");
                }

                if (txtFechaDesde.Text == "" && txtFechaHasta.Text != "")
                {
                    txtFechaDesde.Focus();
                    throw new Exception("Debe completar la fecha desde");
                }

                if (txtFechaDesde.Text != "")
                {
                    if (Convert.ToDateTime(txtFechaDesde.Text) > DateTime.Now)
                    {
                        txtFechaDesde.Focus();
                        throw new Exception("La fecha desde no puede ser mayor a hoy");
                    }
                }

                if (txtFechaHasta.Text != "")
                {
                    if (Convert.ToDateTime(txtFechaHasta.Text) > DateTime.Now)
                    {
                        txtFechaHasta.Focus();
                        throw new Exception("La fecha hasta no puede ser mayor a hoy");
                    }
                }





                int cod_tipo_factura = -999;
                Int64 nro_factura = 0;
                string codigo_articulo = "";
                string codigo_articulo_marca = "";
                DateTime? fecha_desde = null;
                DateTime? fecha_hasta = null;
                int id_cliente = -999;


                cod_tipo_factura = Convert.ToInt32(cbTipoFactura.SelectedValue);
                if (txtNroFactura.Text != "")
                {
                    nro_factura = Convert.ToInt64(txtNroFactura.Text);
                }
                if (txtClienteId.Text != "")
                {
                    id_cliente = Convert.ToInt32(txtClienteId.Text);
                }
                if (txtCodigo_articulo.Text != "")
                {
                    codigo_articulo = txtCodigo_articulo.Text;
                }
                if (txtCodigo_articulo_marca.Text != "")
                {
                    codigo_articulo_marca = txtCodigo_articulo_marca.Text;
                }

                if (txtFechaDesde.Text != "" && txtFechaHasta.Text != "")
                {
                    fecha_desde = Convert.ToDateTime(txtFechaDesde.Text);
                    fecha_hasta = Convert.ToDateTime(txtFechaHasta.Text);
                }


                if (cod_tipo_factura == -999 && nro_factura == 0 && codigo_articulo == "" && codigo_articulo_marca == "" && fecha_desde == null && fecha_hasta == null && id_cliente == -999)
                {
                    throw new Exception("Debe aplicar algun filtro");
                }


                List<factura> lista_facturas = logica_factura.buscar_facturas(cod_tipo_factura, nro_factura, id_cliente, codigo_articulo, codigo_articulo_marca, fecha_desde, fecha_hasta);
                if (lista_facturas != null)
                {
                    if (lista_facturas.Count > 0)
                    {
                        llenar_data_grid_view(lista_facturas);
                    }
                    else
                    {
                        dgvFacturas.Rows.Clear();
                    }
                }
                else
                {
                    throw new Exception("Error al ir a buscar las facturas");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                buscar_facturas_por_metodo_2();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemDropDownButton_Click(object sender, EventArgs e)
        {
            frmEspere frm_Espere = new frmEspere();

            try
            {
                if (((DXMenuItem)sender).Caption == opcion_2_dropDownButton)
                {
                    if (dgvFacturas.SelectedRows.Count == 1)
                    {
                        //if (Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells[8].Value) == 1)
                        //{
                        Cursor.Current = Cursors.WaitCursor;
                        frm_Espere.Show();

                        reporte_factura reporte = new reporte_factura();
                        reporte.Parameters["id_factura"].Value = Convert.ToInt32(dgvFacturas.SelectedRows[0].Cells[0].Value);
                        reporte.Parameters["id_factura"].Visible = false;

                        frm_Espere.Hide();
                        Cursor.Current = Cursors.Default;

                        reporte.ShowPreview();
                        //}
                    }
                    else if (dgvFacturas.SelectedRows.Count == 0)
                    {
                        throw new Exception("Debe seleccionar una fila");
                    }
                    else if (dgvFacturas.SelectedRows.Count > 1)
                    {
                        throw new Exception("Debe seleccionar una sola fila");
                    }
                }
                else if (((DXMenuItem)sender).Caption == opcion_3_dropDownButton) //genero pdf  (si la factura no esta emitida , hago un update en la base primero)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    frm_Espere.Show();

                    int cantidad = 0;
                    if (dgvFacturas.SelectedRows.Count > 0)
                    {
                        try
                        {
                            foreach (DataGridViewRow row in dgvFacturas.SelectedRows)
                            {
                                factura factura_db = logica_factura.buscar_factura_por_id_factura(Convert.ToInt32(row.Cells[0].Value)); //voy a buscar la factura en la base de datos 
                                if (factura_db.sn_emitida == 0) //si la factura no esta emitida...
                                {
                                    //modifico ciertos datos del objeto , SI CAMBIO ACA , TAMBIEN CAMBIAR LINEA DONDE DICE "PEPE EL PISTOLERO"
                                    factura_db.sn_emitida = -1;
                                    factura_db.fecha = DateTime.Now;
                                    factura_db.fecha_sn_emitida = DateTime.Now;
                                    //hasta aca

                                    factura factura_modificada = logica_factura.modificar_factura(factura_db); //establesco el valor en la base de datos
                                    if (factura_modificada != null)
                                    {
                                        string FilePath_PDF = Logica_Funciones_Generales.generar_Pdf(factura_modificada);

                                        if (FilePath_PDF != "")
                                        {
                                            cantidad = cantidad + 1;
                                        }
                                    }

                                }
                                else //si ya esta emitida
                                {
                                    if (factura_db != null) //voy a buscar la factura que fui a buscar a la base de datos
                                    {
                                        string FilePath_PDF = Logica_Funciones_Generales.generar_Pdf(factura_db);
                                        if (FilePath_PDF != "")
                                        {
                                            cantidad = cantidad + 1;
                                        }
                                    }
                                }
                            }



                            frm_Espere.Hide();
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Generacion PDFs correctos: " + cantidad + " de " + dgvFacturas.SelectedRows.Count, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Cursor.Current = Cursors.WaitCursor;
                            rdBusqueda1.Checked = true;
                            monthCalendar1.Enabled = true;
                            panelBusqueda2.Enabled = false;
                            buscar_facturas_por_fecha();
                            Cursor.Current = Cursors.Default;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        throw new Exception("Debe seleccionar una fila");
                    }

                }
                else if (((DXMenuItem)sender).Caption == opcion_4_dropDownButton) //genero pdf e imprimo (si la factura no esta emitida , hago un update en la base primero)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    frm_Espere.Show();


                    int cantidad = 0;
                    if (dgvFacturas.SelectedRows.Count > 0)
                    {

                        try
                        {
                            foreach (DataGridViewRow row in dgvFacturas.SelectedRows)
                            {
                                factura factura_db = logica_factura.buscar_factura_por_id_factura(Convert.ToInt32(row.Cells[0].Value)); //voy a buscar la factura en la base de datos
                                if (factura_db.sn_emitida == 0) //si la factura no esta emitida...
                                {
                                    //modifico ciertos datos del objeto , SI CAMBIO ACA , TAMBIEN CAMBIAR LINEA DONDE DICE "PEPE EL PISTOLERO"
                                    factura_db.sn_emitida = -1;
                                    factura_db.fecha = DateTime.Now;
                                    factura_db.fecha_sn_emitida = DateTime.Now;
                                    //hasta aca

                                    factura factura_modificada = logica_factura.modificar_factura(factura_db); //establesco el valor en la base de datos
                                    if (factura_modificada != null)
                                    {
                                        string FilePath_PDF = Logica_Funciones_Generales.generar_Pdf(factura_modificada);
                                        if (FilePath_PDF != "")
                                        {
                                            if (txtNroCopias.Text == "")
                                            {
                                                throw new Exception("Debe ingresar el nro de copias");
                                            }

                                            bool impresion = Logica_Funciones_Generales.mandar_a_imprimir(FilePath_PDF, cbImpresoras.Text, Convert.ToInt16(txtNroCopias.Text));
                                            if (impresion == true)
                                            {
                                                cantidad = cantidad + 1;
                                            }
                                        }
                                    }

                                }
                                else //si ya esta emitida
                                {

                                    if (factura_db != null)  //voy a buscar la factura que fui a buscar a la base de datos
                                    {
                                        string FilePath_PDF = Logica_Funciones_Generales.generar_Pdf(factura_db);
                                        if (FilePath_PDF != "")
                                        {
                                            if (txtNroCopias.Text == "")
                                            {
                                                throw new Exception("Debe ingresar el nro de copias");
                                            }

                                            bool impresion = Logica_Funciones_Generales.mandar_a_imprimir(FilePath_PDF, cbImpresoras.Text, Convert.ToInt16(txtNroCopias.Text));
                                            if (impresion == true)
                                            {
                                                cantidad = cantidad + 1;
                                            }
                                        }
                                    }
                                }

                            }

                            frm_Espere.Hide();
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Generacion PDFs/Impresiones correctas: " + cantidad + " de " + dgvFacturas.SelectedRows.Count, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Cursor.Current = Cursors.WaitCursor;
                            rdBusqueda1.Checked = true;
                            monthCalendar1.Enabled = true;
                            panelBusqueda2.Enabled = false;
                            buscar_facturas_por_fecha();
                            Cursor.Current = Cursors.Default;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        throw new Exception("Debe seleccionar una fila");
                    }
                }
            }

            catch (Exception ex)
            {
                frm_Espere.Hide();
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                frm_Espere.Hide();
                Cursor.Current = Cursors.Default;
            }
        }






        private void txtCliente_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCliente.Text != "")
                {
                    txtCliente.Text = txtCliente.Text.ToUpper();
                    buscar_cliente_por_razon_social(txtCliente.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buscar_cliente_por_razon_social(string razon_social)
        {
            try
            {
                frmBuscar frm = new frmBuscar();
                frm.Text = "Buscar Cliente";
                frm.btnNuevo.Enabled = false;



                frm.IniciarForm(logica_cliente.buscar_clientes(razon_social).Tables[0], 2);



                if (frm.DialogResult == DialogResult.OK)
                {
                    txtCliente.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);
                    txtClienteId.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[0].Value);
                }
                else
                {
                    txtCliente.Text = "";
                    txtClienteId.Text = "";
                    txtCliente.Focus();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnCancelarFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                limpiar_panel_filtros();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDropDownButton_Click(object sender, EventArgs e)
        {

        }

        private void frmFacturaGestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.ParentForm.Show();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void txtNroCopias_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnEliminarFactura_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            bool bandera = false;
            int cantidad = 0;
            bool bandera_warning = false;
            try
            {
                if (dgvFacturas.SelectedRows.Count > 0)
                {

                    frmPassword frm = new frmPassword();
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }


                    DialogResult dialogResult = MessageBox.Show("¿Esta seguro que desea eliminar la/s factura/s seleccionada/s?", "Atención", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvFacturas.SelectedRows)
                        {
                            factura factura_db = logica_factura.buscar_factura_por_id_factura(Convert.ToInt32(row.Cells[0].Value)); //voy a buscar la factura en la base de datos


                            if (factura_db.path_factura != null) //si el archivo que quiero borrar , tiene path ...
                            {
                                if (sn_file_bloqueado(factura_db.path_factura) == true) //y esta abierto ....
                                {
                                    throw new Exception("Debe cerrar el PDF para que pueda ser eliminado");
                                }
                            }

                            if (factura_db != null)
                            {
                                bandera = logica_factura.eliminar_factura(factura_db);
                                if (bandera == true) //si se elimino correctamente la factura y la misma fue emitida...
                                {
                                    if (factura_db.sn_emitida == -1) //si la factura fue emitida entro aca...
                                    {


                                        if (File.Exists(factura_db.path_factura))
                                        {
                                            GC.Collect();
                                            GC.WaitForPendingFinalizers();
                                            File.Delete(factura_db.path_factura);
                                        }


                                        if (File.Exists(factura_db.path_factura))
                                        {
                                            bandera_warning = true;
                                            throw new Exception("Factura eliminada correctamente.\nPero no se pudo eliminar el PDF.\nPor favor eliminarlo manualmente.");
                                        }
                                        else
                                        {
                                            cantidad = cantidad + 1;
                                        }
                                    }
                                    else //sino sumo 1 a cantidad porque el PDF nunca fue creado y solamente debia eliminar la factura de la base de datos
                                    {
                                        cantidad = cantidad + 1;
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("Error al ir a buscar la factura a la base de datos");
                            }


                        }
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Se eliminaron : " + cantidad + " facturas de " + dgvFacturas.SelectedRows.Count, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    throw new Exception("Debe seleccionar una fila");
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, bandera_warning == false ? "Error" : "Atención", MessageBoxButtons.OK, bandera_warning == false ? MessageBoxIcon.Error : MessageBoxIcon.Warning);
            }
            finally
            {
                rdBusqueda1.Checked = true;
                monthCalendar1.Enabled = true;
                panelBusqueda2.Enabled = false;
                buscar_facturas_por_fecha();

            }
        }


        public static bool sn_file_bloqueado(string fileName)
        {
            FileStream stream = null;
            try
            {
                stream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }
    }
}
