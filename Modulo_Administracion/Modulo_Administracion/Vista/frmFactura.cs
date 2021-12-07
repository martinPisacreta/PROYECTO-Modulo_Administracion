using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Modulo_Administracion.Vista
{
    public partial class frmFactura : Form
    {
        factura factura;
        factura_detalle factura_detalle;
        articulo articulo;
        familia familia;

        Logica_Cliente logica_cliente = new Logica_Cliente();
        Logica_Articulo logica_articulo = new Logica_Articulo();
        Logica_Factura_Detalle logica_factura_detalle = new Logica_Factura_Detalle();
        Logica_Factura logica_factura = new Logica_Factura();
        Logica_Familia logica_familia = new Logica_Familia();

        int Accion;

        decimal precio_final_al_cargar_factura = 0;

        string PagoMenor7DiasPorcentaje1 = "20";
        string PagoMenor7DiasPorcentaje2 = "5";
        string PagoMenor30Dias = "20";
        string PagoMayor30Dias = "25";




        int index_columna_col_iva_aumento = 7;
        int cantidad_filas_a_dataGridView = 50;

        string opcion_1_dropDownButton = "Grabar";
        string opcion_2_dropDownButton = "Grabar y generar PDF";
        string opcion_3_dropDownButton = "Grabar , generar PDF e imprimir";
        int nro_redondeo = 2;

        public Form ParentForm { get; set; }



        public frmFactura(factura _factura)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                InitializeComponent();

                factura = _factura;


                gridControl1.DataSource = logica_articulo.buscar_articulos().Tables[0]; //cargo en gridControl1

                gridView3.Columns["precio_lista"].Visible = false;
                gridView3.Columns["coeficiente"].Visible = false;
                gridView3.Columns["precio_final"].Visible = false;
                gridView3.Columns["id_tabla_familia"].Visible = false;
                gridView3.Columns["sn_oferta"].Visible = false;
                gridView3.Columns["path_img"].Visible = false;
                gridView3.Columns["id_articulo"].Visible = false;
                gridView3.Columns["id_orden"].Visible = false;

                dgvFactura.Rows.Add(cantidad_filas_a_dataGridView);    //genero 50 lineas al dataGridView

                txtNroFactura.Enabled = false; //nunca se va a poder modificar el nro de factura
                txtClienteId.Enabled = false;  //nunca se va a poder modificar id_cliente

                txtClienteId.Visible = false;  //nunca se va a poder ver id_cliente
                txtPagoMayor30DiasPorcentaje.ReadOnly = true;
                txtPagoMenor7DiasPorcentaje1.ReadOnly = true;
                txtPagoMenor7DiasPorcentaje2.ReadOnly = true;
                txtPagoMenor30DiasPorcentaje.ReadOnly = true;

                txtPagoMayor30DiasPorcentaje.Text = PagoMayor30Dias;
                txtPagoMenor7DiasPorcentaje1.Text = PagoMenor7DiasPorcentaje1;
                txtPagoMenor7DiasPorcentaje2.Text = PagoMenor7DiasPorcentaje2;
                txtPagoMenor30DiasPorcentaje.Text = PagoMenor30Dias;

                //colores dataGridView
                dgvFactura.Columns["col_cantidad"].DefaultCellStyle.BackColor = Color.White;
                dgvFactura.Columns["col_marca"].DefaultCellStyle.BackColor = Color.White;
                dgvFactura.Columns["col_codigo"].DefaultCellStyle.BackColor = Color.White;
                dgvFactura.Columns["col_descripcion"].DefaultCellStyle.BackColor = Color.White;
                dgvFactura.Columns["col_precio"].DefaultCellStyle.BackColor = Color.White;
                dgvFactura.Columns["col_importe"].DefaultCellStyle.BackColor = Color.White;

                dgvFactura.Columns["col_precio_lista_x_coeficiente"].DefaultCellStyle.BackColor = Color.IndianRed;
                dgvFactura.Columns["col_iva_aumento"].DefaultCellStyle.BackColor = Color.IndianRed;

                //formato columnas dataGridView
                dgvFactura.Columns["col_precio"].DefaultCellStyle.Format = "N2";
                dgvFactura.Columns["col_importe"].DefaultCellStyle.Format = "N2";
                dgvFactura.Columns["col_precio_lista_x_coeficiente"].DefaultCellStyle.Format = "N2";
                dgvFactura.Columns["col_iva_aumento"].DefaultCellStyle.Format = "N2";

                //cargo en todas las celdas de la columna "col_iva_aumento" el valor "10.5"
                foreach (DataGridViewRow row in dgvFactura.Rows)
                {
                    row.Cells["col_iva_aumento"].Value = 10.5M;
                }

                //cargo el combo
                Logica_Funciones_Generales.CargarComboBox("ttipo_factura", cbTipoFactura, "txt_desc", "1=1", "cod_tipo_factura", "cod_tipo_factura");


                if (factura == null) //si la accion es alta
                {

                    Accion = 1;
                }
                else                        //si la accion es modificacion
                {
                    Accion = 2;
                    cbTipoFactura.Enabled = true;
                    txtNroFactura.Enabled = false;
                    txtFecha.Enabled = false;
                    txtCliente.Enabled = true;


                    //panel2.Enabled = false;
                }

                DXPopupMenu popupMenu = new DXPopupMenu();
                popupMenu.Items.Add(new DXMenuItem() { Caption = opcion_1_dropDownButton });
                popupMenu.Items.Add(new DXMenuItem() { Caption = opcion_2_dropDownButton });
                popupMenu.Items.Add(new DXMenuCheckItem() { Caption = opcion_3_dropDownButton });
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
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void cargar_formulario(factura factura)
        {
            Cursor.Current = Cursors.WaitCursor;
            decimal precio_lista_x_coeficiente;
            decimal precio_lista;
            decimal coeficiente;
            decimal ganancia;
            decimal precio;
            decimal importe;


            try
            {
                if (factura != null) //entro aca si factura tiene cargado algo
                {
                    if (factura.id_factura > 0) //entro aca si id_factura es mayor a 0
                    {
                        cbTipoFactura.SelectedValue = factura.cod_tipo_factura;
                        txtNroFactura.Text = factura.nro_factura.ToString();

                        if (factura.sn_emitida == -1) //si la factura ya la emiti , tengo que traer la fecha de la base de datos
                        {
                            txtFecha.Text = factura.fecha.ToString("dd/MM/yyyy");
                        }
                        else //si la factura no la imprimi , traigo la fecha del dia actual
                        {
                            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        }

                        txtCliente.Text = factura.cliente.nombre_fantasia;
                        txtClienteId.Text = factura.cliente.id_cliente.ToString();
                        txtObservacion.Text = factura.observacion;
                        if (factura.factura_detalle != null)
                        {
                            if (factura.factura_detalle.Count > 0)
                            {

                                int indice = 0;
                                foreach (factura_detalle factura_detalle in factura.factura_detalle)
                                {
                                    dgvFactura.Rows[indice].Cells[0].Value = factura_detalle.cantidad.ToString();
                                    dgvFactura.Rows[indice].Cells[1].Value = factura_detalle.codigo_articulo_marca;
                                    dgvFactura.Rows[indice].Cells[2].Value = factura_detalle.codigo_articulo;


                                    if (factura_detalle.id_articulo == null) //todos los datos los traigo desde la tabla  "factura_detalle"
                                    {
                                        ganancia = (factura_detalle.precio_lista_x_coeficiente * factura_detalle.iva) / 100;
                                        ganancia = Math.Round(ganancia, nro_redondeo, MidpointRounding.AwayFromZero);

                                        precio = factura_detalle.precio_lista_x_coeficiente + ganancia;
                                        precio = Math.Round(precio, nro_redondeo, MidpointRounding.AwayFromZero);

                                        dgvFactura.Rows[indice].Cells[3].Value = factura_detalle.descripcion_articulo;
                                        dgvFactura.Rows[indice].Cells[4].Value = precio == 0 ? "" : precio.ToString("N2");
                                        dgvFactura.Rows[indice].Cells[6].Value = factura_detalle.precio_lista_x_coeficiente == 0 ? "" : factura_detalle.precio_lista_x_coeficiente.ToString("N2");
                                        dgvFactura.Rows[indice].Cells[8].Value = -999;
                                    }
                                    else                                    //los datos los traigo desde la tabla "articulo"
                                    {
                                        precio_lista = (factura_detalle.articulo.precio_lista == null ? 0.00M : factura_detalle.articulo.precio_lista.Value);
                                        //precio_lista = Math.Round(precio_lista, nro_redondeo , MidpointRounding.AwayFromZero);

                                        //NO TENGO QUE REDONDEAR NUNCA
                                        coeficiente = (logica_familia.precio_coeficiente(2, factura_detalle.articulo.familia.algoritmo_1, factura_detalle.articulo.familia.algoritmo_2, factura_detalle.articulo.familia.algoritmo_3, factura_detalle.articulo.familia.algoritmo_4, factura_detalle.articulo.familia.algoritmo_5, factura_detalle.articulo.familia.algoritmo_6, factura_detalle.articulo.familia.algoritmo_7, factura_detalle.articulo.familia.algoritmo_8, factura_detalle.articulo.familia.algoritmo_9));

                                        precio_lista_x_coeficiente = (precio_lista * coeficiente);
                                        precio_lista_x_coeficiente = Math.Round(precio_lista_x_coeficiente, nro_redondeo, MidpointRounding.AwayFromZero);

                                        ganancia = (precio_lista_x_coeficiente * factura_detalle.iva) / 100;
                                        ganancia = Math.Round(ganancia, nro_redondeo, MidpointRounding.AwayFromZero);

                                        precio = precio_lista_x_coeficiente + ganancia;
                                        precio = Math.Round(precio, nro_redondeo, MidpointRounding.AwayFromZero);

                                        dgvFactura.Rows[indice].Cells[3].Value = factura_detalle.articulo.descripcion_articulo;
                                        dgvFactura.Rows[indice].Cells[4].Value = precio == 0 ? "" : precio.ToString("N2");
                                        dgvFactura.Rows[indice].Cells[6].Value = precio_lista_x_coeficiente == 0 ? "" : precio_lista_x_coeficiente.ToString("N2");
                                        dgvFactura.Rows[indice].Cells[8].Value = factura_detalle.id_articulo;
                                    }

                                    importe = precio * factura_detalle.cantidad;
                                    importe = Math.Round(importe, nro_redondeo, MidpointRounding.AwayFromZero);

                                    dgvFactura.Rows[indice].Cells[5].Value = importe == 0 ? "" : importe.ToString("N2"); //col_importe
                                    dgvFactura.Rows[indice].Cells[7].Value = factura_detalle.iva.ToString("N2"); //col_iva
                                    dgvFactura.Rows[indice].Cells[9].Value = factura_detalle.id_factura_detalle; //col_iva
                                    indice = indice + 1;
                                }
                            }

                        }

                        chkMostrarMayor30Dias.Checked = false;
                        chkMostrarMenor30Dias.Checked = false;
                        chkMostrarMenor7Dias.Checked = false;

                        if (factura.sn_mostrar_pago_mayor_30_dias == -1)
                        {
                            chkMostrarMayor30Dias.Checked = true;
                        }
                        if (factura.sn_mostrar_pago_menor_30_dias == -1)
                        {
                            chkMostrarMenor30Dias.Checked = true;
                        }
                        if (factura.sn_mostrar_pago_menor_7_dias == -1)
                        {
                            chkMostrarMenor7Dias.Checked = true;
                        }

                        precio_final_al_cargar_factura = factura.precio_final;
                        decimal _importe_total = importe_total(dgvFactura);
                        if (factura.cod_tipo_factura == 2) //si es nota de credito
                        {
                            if (factura.sn_modifica_precio_final == -1) //si el usuario modifica MANUALMENTE el precio final...
                            {
                                lblImporteTotal.Text = (-factura.precio_final).ToString("N2"); //lblImporteTotal -> va a ser el valor de "precio_final" de la bd
                            }
                            else //sino..
                            {
                                lblImporteTotal.Text = (-importe_total(dgvFactura)).ToString("N2"); //lblImporteTotal -> va a ser la suma de los items de la grilla , ya que el usuario no lo modifico MANUALMENTE.
                            }

                            lblImportePagoMayor30Dias.Text = "0.00";
                            lblImportePagoMenor7Dias.Text = "0.00";
                            lblImportePagoMenor30Dias.Text = "0.00";
                        }
                        else if (factura.cod_tipo_factura == 6) //si es nota de debito
                        {
                            if (factura.sn_modifica_precio_final == -1) //si el usuario modifica MANUALMENTE el precio final...
                            {
                                lblImporteTotal.Text = (+factura.precio_final).ToString("N2"); //lblImporteTotal -> va a ser el valor de "precio_final" de la bd
                            }
                            else //sino..
                            {
                                lblImporteTotal.Text = (+importe_total(dgvFactura)).ToString("N2"); //lblImporteTotal -> va a ser la suma de los items de la grilla , ya que el usuario no lo modifico MANUALMENTE.
                            }
                            lblImportePagoMayor30Dias.Text = "0.00";
                            lblImportePagoMenor7Dias.Text = "0.00";
                            lblImportePagoMenor30Dias.Text = "0.00";
                        }
                        else
                        {
                            if (factura.sn_modifica_precio_final == -1) //si el usuario modifica MANUALMENTE el precio final...
                            {
                                lblImporteTotal.Text = (factura.precio_final).ToString("N2"); //lblImporteTotal -> va a ser el valor de "precio_final" de la bd
                            }
                            else //sino..
                            {
                                lblImporteTotal.Text = (importe_total(dgvFactura)).ToString("N2"); //lblImporteTotal -> va a ser la suma de los items de la grilla , ya que el usuario no lo modifico MANUALMENTE.
                            }
                            lblImportePagoMayor30Dias.Text = factura.precio_final_con_pago_mayor_a_30_dias.ToString("N2");
                            lblImportePagoMenor7Dias.Text = factura.precio_final_con_pago_menor_a_7_dias.ToString("N2");
                            lblImportePagoMenor30Dias.Text = factura.precio_final_con_pago_menor_a_30_dias.ToString("N2");
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


        private void Iniciar()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                txtNroFactura.Text = "";
                txtFecha.Text = DateTime.Now.ToShortDateString();
                txtCliente.Text = "";
                txtClienteId.Text = "";
                txtObservacion.Text = "";


                lblImporteTotal.Text = "0.00";
                lblImportePagoMayor30Dias.Text = "0.00";
                lblImportePagoMenor7Dias.Text = "0.00";
                lblImportePagoMenor30Dias.Text = "0.00";

                chkMostrarMayor30Dias.Checked = false;
                chkMostrarMenor30Dias.Checked = false;
                chkMostrarMenor7Dias.Checked = false;

                txtNroCopias.Text = Program.nro_copias.ToString();

                foreach (DataGridViewRow row in dgvFactura.Rows)
                {
                    row.Cells["col_cantidad"].Value = null;
                    row.Cells["col_marca"].Value = null;
                    row.Cells["col_codigo"].Value = null;
                    row.Cells["col_descripcion"].Value = null;
                    row.Cells["col_precio"].Value = null;
                    row.Cells["col_importe"].Value = null;
                    row.Cells["col_precio_lista_x_coeficiente"].Value = null;
                    //row.Cells["col_iva_aumento"].Value = null; no borro su contenido
                    row.Cells["col_id_articulo"].Value = null;
                }

                if (Accion == 1) //si la accion es alta
                {
                    factura = null;
                    factura = new factura();
                }
                else            //si la accion es modificacion
                {
                    cargar_formulario(factura);
                }



                calcular_lblImportePagoMayor30Dias();
                calcular_lblImportePagoMenor7Dias();
                calcular_lblImportePagoMenor30Dias();
                lblTotal.Text = "Total : " + calcular_total_items_grilla(dgvFactura).ToString();


                if (factura.sn_emitida == -1) //si esta emitida la factura , ingreso aca 
                {
                    dgvFactura.ReadOnly = true;
                    btnDropDownButton.Enabled = false;
                    btnEliminar.Enabled = false;
                    txtObservacion.Enabled = false;
                    panelPorcentaje.Enabled = false;
                    lblImporteTotal.Enabled = false;
                    chkMostrarMayor30Dias.Enabled = false;
                    chkMostrarMenor7Dias.Enabled = false;
                    chkMostrarMenor30Dias.Enabled = false;

                    cbTipoFactura.Enabled = false;
                    txtNroFactura.Enabled = false;
                    txtFecha.Enabled = false;
                    txtCliente.Enabled = false;

                }
                else //si todavia no esta impresa la factura , ingreso aca 
                {
                    dgvFactura.ReadOnly = false;
                    btnDropDownButton.Enabled = true;
                    btnEliminar.Enabled = true;
                    txtObservacion.Enabled = true;
                    panelPorcentaje.Enabled = true;
                    lblImporteTotal.Enabled = true;
                    chkMostrarMayor30Dias.Enabled = true;
                    chkMostrarMenor7Dias.Enabled = true;
                    chkMostrarMenor30Dias.Enabled = true;

                    cbTipoFactura.Enabled = true;
                    txtNroFactura.Enabled = false;
                    txtFecha.Enabled = false;
                    txtCliente.Enabled = true;
                }

                txtPorcentaje.Text = "";
                txtAumento_Descuento.Text = "";

                txtCliente.Focus();

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

        private void frmFactura_Load(object sender, EventArgs e)
        {

            try
            {

                Iniciar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {

            }
        }
        private decimal importe_total(DataGridView dgvFactura)
        {
            try
            {
                decimal sum = 0.00M;
                decimal importe = 0.00M;
                //sumo la columna importe
                for (int i = 0; i < dgvFactura.Rows.Count; ++i)
                {

                    if (dgvFactura.Rows[i].Cells["col_importe"].Value != null)
                    {
                        if (dgvFactura.Rows[i].Cells["col_importe"].Value.ToString() != "")
                        {
                            importe = (Convert.ToDecimal(dgvFactura.Rows[i].Cells["col_importe"].Value));
                            sum += importe;
                        }
                    }

                }
                return sum;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvFactura_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox textbox = e.Control as TextBox;
                if (textbox != null)
                {
                    textbox.AutoCompleteMode = AutoCompleteMode.None;
                }


                e.Control.KeyPress -= new KeyPressEventHandler(columna_KeyPress_solo_decimal);
                e.Control.KeyPress -= new KeyPressEventHandler(columna_KeyPress_solo_numero);
                string codigo_articulo_marca;

                //si la columna es col_precio o col_importe o col_precio_lista_x_coeficiente o col_iva_aumento
                if (dgvFactura.CurrentCell.ColumnIndex == 4 || dgvFactura.CurrentCell.ColumnIndex == 5 || dgvFactura.CurrentCell.ColumnIndex == 6 || dgvFactura.CurrentCell.ColumnIndex == 7)
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(columna_KeyPress_solo_decimal);
                    }
                }

                //si la columna es col_cantidad
                if (dgvFactura.CurrentCell.ColumnIndex == 0)
                {
                    TextBox tb = e.Control as TextBox;
                    if (tb != null)
                    {
                        tb.KeyPress += new KeyPressEventHandler(columna_KeyPress_solo_numero);
                    }
                }





                //si la columna es col_marca
                if (dgvFactura.CurrentCell.ColumnIndex == 1)
                {
                    TextBox auto_text_marca = e.Control as TextBox;
                    if (auto_text_marca != null)
                    {
                        codigo_articulo_marca = "";
                        auto_text_marca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        auto_text_marca.AutoCompleteCustomSource = cargar_autocomplete_TextBox_DataGridView(codigo_articulo_marca);
                        auto_text_marca.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    }
                }
                //si la columna es  col_codigo
                if (dgvFactura.CurrentCell.ColumnIndex == 2)
                {
                    TextBox auto_text_codigo = e.Control as TextBox;
                    if (auto_text_codigo != null)
                    {
                        codigo_articulo_marca = "";
                        auto_text_codigo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

                        if (dgvFactura.CurrentRow.Cells["col_marca"].Value != null)
                        {
                            codigo_articulo_marca = dgvFactura.CurrentRow.Cells["col_marca"].Value.ToString();
                        }

                        if (codigo_articulo_marca != "")
                        {
                            auto_text_codigo.AutoCompleteCustomSource = cargar_autocomplete_TextBox_DataGridView(codigo_articulo_marca);
                            auto_text_codigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public AutoCompleteStringCollection cargar_autocomplete_TextBox_DataGridView(string codigo_articulo_marca)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Modulo_AdministracionContext"].ConnectionString);
                SqlCommand cmd = null;
                string campo;
                if (codigo_articulo_marca == "")
                {
                    campo = "codigo_articulo_marca";
                    cmd = new SqlCommand("Select codigo_articulo_marca from articulo where fec_baja is null", conn);
                }
                else
                {
                    campo = "codigo_articulo";
                    cmd = new SqlCommand("Select codigo_articulo from articulo where codigo_articulo_marca = '" + codigo_articulo_marca + "' and fec_baja is null", conn);
                }

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                AutoCompleteStringCollection mycoll = new AutoCompleteStringCollection();
                while (dr.Read())
                {

                    mycoll.Add(dr[campo].ToString());
                }
                return mycoll;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void columna_KeyPress_solo_numero(object sender, KeyPressEventArgs e)
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

        //funcion que indica que "," y "." es lo mismo
        private void columna_KeyPress_solo_decimal(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '.')
                {
                    if (e.KeyChar == '.') //si llego a escribir un punto , lo reemplazo por coma
                    {
                        e.KeyChar = ',';
                    }
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

        private bool Hay_Celdas_Vacias(DataGridView dataGridView)
        {
            try
            {
                bool hay_celdas_vacias = false;


                for (int i = 0; i < dataGridView.RowCount - 1; i++)
                {

                    string col_cantidad = dataGridView.Rows[i].Cells["col_cantidad"].Value == null ? "" : dataGridView.Rows[i].Cells["col_cantidad"].Value.ToString();
                    string col_marca = dataGridView.Rows[i].Cells["col_marca"].Value == null ? "" : dataGridView.Rows[i].Cells["col_marca"].Value.ToString();
                    string col_codigo = dataGridView.Rows[i].Cells["col_codigo"].Value == null ? "" : dataGridView.Rows[i].Cells["col_codigo"].Value.ToString();
                    string col_descripcion = dataGridView.Rows[i].Cells["col_descripcion"].Value == null ? "" : dataGridView.Rows[i].Cells["col_descripcion"].Value.ToString();
                    string col_precio = dataGridView.Rows[i].Cells["col_precio"].Value == null ? "" : dataGridView.Rows[i].Cells["col_precio"].Value.ToString();
                    string col_importe = dataGridView.Rows[i].Cells["col_importe"].Value == null ? "" : dataGridView.Rows[i].Cells["col_importe"].Value.ToString();
                    string col_precio_lista_x_coeficiente = dataGridView.Rows[i].Cells["col_precio_lista_x_coeficiente"].Value == null ? "" : dataGridView.Rows[i].Cells["col_precio_lista_x_coeficiente"].Value.ToString();
                    string col_iva_aumento = dataGridView.Rows[i].Cells["col_iva_aumento"].Value == null ? "" : dataGridView.Rows[i].Cells["col_iva_aumento"].Value.ToString();
                    string col_id_articulo = dataGridView.Rows[i].Cells["col_id_articulo"].Value == null ? "" : dataGridView.Rows[i].Cells["col_id_articulo"].Value.ToString();
                    string col_id_factura_detalle = dataGridView.Rows[i].Cells["col_id_factura_detalle"].Value == null ? "" : dataGridView.Rows[i].Cells["col_id_factura_detalle"].Value.ToString();

                    if (col_cantidad == "" || col_marca == "" || col_codigo == "" || col_descripcion == "" || col_precio == "" || col_importe == "" || col_precio_lista_x_coeficiente == "" || col_iva_aumento == "" || col_id_articulo == "") //SI ALGUNA DE ESTAS CELDAS ESTA VACIA
                    {
                        if (col_cantidad == "" && col_marca == "" && col_codigo == "" && col_descripcion == "" && col_precio == "" && col_importe == "" && col_precio_lista_x_coeficiente == "" && col_id_articulo == "") //... Y TODA LA FILA ESTA VACIA ... NO HAGO NADA
                        {

                        }
                        else //SINO SI...
                        {

                            hay_celdas_vacias = true;
                            return hay_celdas_vacias;
                        }
                    }
                }
                return hay_celdas_vacias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int Cantidad_Filas_Vacias(DataGridView dataGridView)
        {
            try
            {
                int cantidad_filas_vacias = 0;
                for (int i = 0; i < dataGridView.RowCount - 1; i++)
                {
                    string col_cantidad = dataGridView.Rows[i].Cells["col_cantidad"].Value == null ? "" : dataGridView.Rows[i].Cells["col_cantidad"].Value.ToString();
                    string col_marca = dataGridView.Rows[i].Cells["col_marca"].Value == null ? "" : dataGridView.Rows[i].Cells["col_marca"].Value.ToString();
                    string col_codigo = dataGridView.Rows[i].Cells["col_codigo"].Value == null ? "" : dataGridView.Rows[i].Cells["col_codigo"].Value.ToString();
                    string col_descripcion = dataGridView.Rows[i].Cells["col_descripcion"].Value == null ? "" : dataGridView.Rows[i].Cells["col_descripcion"].Value.ToString();
                    string col_precio = dataGridView.Rows[i].Cells["col_precio"].Value == null ? "" : dataGridView.Rows[i].Cells["col_precio"].Value.ToString();
                    string col_importe = dataGridView.Rows[i].Cells["col_importe"].Value == null ? "" : dataGridView.Rows[i].Cells["col_importe"].Value.ToString();
                    string col_precio_lista_x_coeficiente = dataGridView.Rows[i].Cells["col_precio_lista_x_coeficiente"].Value == null ? "" : dataGridView.Rows[i].Cells["col_precio_lista_x_coeficiente"].Value.ToString();
                    string col_iva_aumento = dataGridView.Rows[i].Cells["col_iva_aumento"].Value == null ? "" : dataGridView.Rows[i].Cells["col_iva_aumento"].Value.ToString();
                    string col_id_articulo = dataGridView.Rows[i].Cells["col_id_articulo"].Value == null ? "" : dataGridView.Rows[i].Cells["col_id_articulo"].Value.ToString();
                    string col_id_factura_detalle = dataGridView.Rows[i].Cells["col_id_factura_detalle"].Value == null ? "" : dataGridView.Rows[i].Cells["col_id_factura_detalle"].Value.ToString();

                    if
                    (
                        col_cantidad == "" &&
                        col_marca == "" &&
                        col_codigo == "" &&
                        col_descripcion == "" &&
                        col_precio == "" &&
                        col_importe == "" &&
                        col_precio_lista_x_coeficiente == "" &&
                        //col_iva_aumento == "" &&
                        col_id_articulo == ""
                    //col_id_factura_detalle == ""
                    )
                    {
                        cantidad_filas_vacias = cantidad_filas_vacias + 1;
                    }
                }

                return cantidad_filas_vacias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Validacion_General()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (cbTipoFactura.SelectedItem == null)
                {
                    cbTipoFactura.Focus();
                    throw new Exception("Debe elegir un tipo de factura");
                }
                if (txtFecha.Text == "")
                {
                    txtNroFactura.Focus();
                    throw new Exception("Debe ingresar una fecha");
                }
                if (txtCliente.Text == "" || txtClienteId.Text == "")
                {
                    txtCliente.Focus();
                    throw new Exception("Debe ingresar un cliente");
                }


                int cantidad_filas_vacias = Cantidad_Filas_Vacias(dgvFactura);
                if (cantidad_filas_vacias == cantidad_filas_a_dataGridView - 1) // le agrego el -1 porque la funcion Cantidad_Filas_Vacias(dgvFactura) arranca a contar desde 0
                {
                    throw new Exception("Debe cargar articulos en la grilla");
                }

                if (Hay_Celdas_Vacias(dgvFactura) == true)
                {
                    dgvFactura.Focus();
                    throw new Exception("No pueden haber celdas vacias");
                }

                if (Accion == 2) //osea modificacion
                {
                    if (txtNroFactura.Text == "")
                    {
                        txtNroFactura.Focus();
                        throw new Exception("Debe ingresar un número de factura");
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
        } // Valido la entrada de datos






        private void grabar(int tipo_grabacion) //1 -> GRABAR , 2 -> "GRABAR Y GENERAR PDF" , 3 -> "GRABAR , GENERAR PDF E IMPRIMIR"
        {
            frmEspere form = new frmEspere();
            bool cierro_el_modulo = false;
            Logica_Factura_Tipo logica_facura_tipo = new Logica_Factura_Tipo();
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                form.Show();

                factura _factura_insertada = null;
                factura _factura_modificada = null;
                Validacion_General();


                SeteoObjeto(tipo_grabacion);

                if (Accion == 1) //alta
                {
                    _factura_insertada = logica_factura.alta_factura(factura);
                    if (_factura_insertada == null)
                    {
                        throw new Exception("Error en el alta de la factura");
                    }
                    factura = _factura_insertada;
                }
                else if (Accion == 2) //modificacion
                {
                    _factura_modificada = logica_factura.modificar_factura(factura);
                    if (_factura_modificada == null)
                    {
                        throw new Exception("Error en la modificación de la factura");
                    }
                    factura = _factura_modificada;
                }

                if ((Accion == 1 && factura != null) || (Accion == 2 && factura != null))
                {
                    if (tipo_grabacion == 1)
                    {
                        form.Hide();
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Grabación exitosa", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (tipo_grabacion == 2)
                    {
                        string FilePath_PDF = Logica_Funciones_Generales.generar_Pdf(factura);

                        if (FilePath_PDF == "")
                        {
                            form.Hide();
                            Cursor.Current = Cursors.Default;
                            cierro_el_modulo = true;
                            throw new Exception("Factura emitida correctamente , pero error en la generación del PDF");
                        }
                        else
                        {
                            form.Hide();
                            Cursor.Current = Cursors.Default;
                            MessageBox.Show("Factura emitida correctamente \nPDF generado en " + FilePath_PDF, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else if (tipo_grabacion == 3)
                    {
                        string FilePath_PDF = Logica_Funciones_Generales.generar_Pdf(factura);
                        if (FilePath_PDF == "")
                        {
                            form.Hide();
                            Cursor.Current = Cursors.Default;
                            cierro_el_modulo = true;
                            throw new Exception("Factura emitida correctamente , pero error en la generación del PDF y por ende en la impresión tambien");
                        }
                        else
                        {
                            if (txtNroCopias.Text == "")
                            {
                                throw new Exception("Debe ingresar el nro de copias");
                            }

                            bool impresion = Logica_Funciones_Generales.mandar_a_imprimir(FilePath_PDF, cbImpresoras.Text, Convert.ToInt16(txtNroCopias.Text));
                            if (impresion == false)
                            {
                                form.Hide();
                                Cursor.Current = Cursors.Default;
                                cierro_el_modulo = true;
                                throw new Exception("Factura emitida y generacion de PDF exitosa , pero error en la impresión");
                            }
                            else
                            {
                                form.Hide();
                                Cursor.Current = Cursors.Default;
                                MessageBox.Show("Factura emitida , generacion PDF e impresión exitosa", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }


                    this.Close();

                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                form.Hide();

                if (cierro_el_modulo == true)
                {
                    MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                form.Hide();
                Cursor.Current = Cursors.Default;
            }
        }



        private void SeteoObjeto(int tipo_grabacion) //1 -> GRABAR , 2 -> "GRABAR Y GENERAR PDF" , 3 -> "GRABAR , GENERAR PDF E IMPRIMIR"
        {
            decimal? ganancia;
            decimal importe;
            decimal precio;
            List<factura_detalle> lista_detalle_factura = new List<factura_detalle>() { };
            try
            {


                //factura.id_factura  -- si es alta , no tiene y si es modificacion ya viene cargado en el objeto
                factura.cod_tipo_factura = Convert.ToInt32(cbTipoFactura.SelectedValue);
                factura.id_cliente = Convert.ToInt32(txtClienteId.Text);
                factura.fecha = Convert.ToDateTime(txtFecha.Text);
                if (txtNroFactura.Text != "")
                {
                    factura.nro_factura = Convert.ToInt64(txtNroFactura.Text);
                }


                //if (factura.cod_tipo_factura == 2) //si es nota de credito
                //{
                //    factura.precio_final = +Convert.ToDecimal(lblImporteTotal.Text);

                //    factura.precio_final_con_pago_mayor_a_30_dias = 0;
                //    factura.precio_final_con_pago_menor_a_7_dias = 0;
                //    factura.precio_final_con_pago_menor_a_30_dias = 0;
                //}
                //else if (factura.cod_tipo_factura == 6) //si es nota de debito
                //{
                //    factura.precio_final = +Convert.ToDecimal(lblImporteTotal.Text);

                //    factura.precio_final_con_pago_mayor_a_30_dias = 0;
                //    factura.precio_final_con_pago_menor_a_7_dias = 0;
                //    factura.precio_final_con_pago_menor_a_30_dias = 0;
                //}
                //else
                //{


                factura.precio_final = Convert.ToDecimal(lblImporteTotal.Text);
                if (factura.precio_final != precio_final_al_cargar_factura && factura.precio_final != importe_total(dgvFactura))
                {
                    factura.sn_modifica_precio_final = -1;
                }
                else
                {
                    factura.sn_modifica_precio_final = 0;
                }
                factura.precio_final_con_pago_mayor_a_30_dias = Convert.ToDecimal(lblImportePagoMayor30Dias.Text);
                factura.precio_final_con_pago_menor_a_7_dias = Convert.ToDecimal(lblImportePagoMenor7Dias.Text);
                factura.precio_final_con_pago_menor_a_30_dias = Convert.ToDecimal(lblImportePagoMenor30Dias.Text);
                //}

                if (tipo_grabacion == 1)
                {
                    factura.sn_emitida = 0;
                    factura.fecha = Convert.ToDateTime(txtFecha.Text);
                    factura.fecha_sn_emitida = null;
                    factura.path_factura = null;
                }
                else if (tipo_grabacion == 2 || tipo_grabacion == 3)
                {
                    factura.sn_emitida = -1;
                    factura.fecha = DateTime.Now;
                    factura.fecha_sn_emitida = DateTime.Now;

                }
                else
                {
                    throw new Exception("Error al grabar sn_impresa");
                }
                factura.observacion = txtObservacion.Text;

                //esto es para ver si muestro o no en la boleta "Pago mayor 30 dias" , "Pago menor 7 dias" , "Pago menor 30 dias"
                factura.sn_mostrar_pago_mayor_30_dias = 0;
                if (chkMostrarMayor30Dias.Checked == true)
                {
                    factura.sn_mostrar_pago_mayor_30_dias = -1;
                }

                factura.sn_mostrar_pago_menor_7_dias = 0;
                if (chkMostrarMenor7Dias.Checked == true)
                {
                    factura.sn_mostrar_pago_menor_7_dias = -1;
                }

                factura.sn_mostrar_pago_menor_30_dias = 0;
                if (chkMostrarMenor30Dias.Checked == true)
                {
                    factura.sn_mostrar_pago_menor_30_dias = -1;
                }
                //hasta aca 

                factura.factura_detalle = null;


                foreach (DataGridViewRow row in dgvFactura.Rows)
                {
                    if (row.Cells["col_cantidad"].Value == null)
                    {
                        continue;
                    }
                    factura_detalle = new factura_detalle();

                    if (row.Cells["col_id_factura_detalle"].Value != null)
                    {
                        factura_detalle.id_factura_detalle = Convert.ToInt32(row.Cells["col_id_factura_detalle"].Value.ToString());
                    }

                    //factura_detalle.id_factura -- si es alta , no tiene y si es modificacion ya viene cargado en el objeto

                    factura_detalle.cantidad = Convert.ToInt32(row.Cells["col_cantidad"].Value.ToString());
                    factura_detalle.codigo_articulo_marca = row.Cells["col_marca"].Value.ToString();
                    factura_detalle.codigo_articulo = row.Cells["col_codigo"].Value.ToString();

                    factura_detalle.descripcion_articulo = row.Cells["col_descripcion"].Value.ToString();
                    factura_detalle.precio_lista_x_coeficiente = Convert.ToDecimal(row.Cells["col_precio_lista_x_coeficiente"].Value.ToString());

                    //si el tipo de grabacion es 2-> "GRABAR Y GENERAR PDF" , 3-> "GRABAR , GENERAR PDF E IMPRIMIR" , la factura se frizza
                    if (tipo_grabacion == 2 || tipo_grabacion == 3)
                    {
                        factura_detalle.id_articulo = null; //pongo id_articulo de factura_detalle en null (en otras partes del codigo esta esta descripcion tambien)
                    }
                    else
                    {
                        if (row.Cells["col_id_articulo"].Value.ToString() == "-999")
                        {
                            factura_detalle.id_articulo = null; //pongo id_articulo de factura_detalle en null (en otras partes del codigo esta esta descripcion tambien)
                        }
                        else
                        {
                            factura_detalle.id_articulo = Convert.ToInt64(row.Cells["col_id_articulo"].Value.ToString());
                        }
                    }


                    factura_detalle.iva = Convert.ToDecimal(row.Cells["col_iva_aumento"].Value.ToString());

                    //factura_detalle.fec_baja = row.Cells["col_marca"].Value.ToString(); -- no va a ser baja nunca si doy de alta



                    lista_detalle_factura.Add(factura_detalle);
                }

                factura.factura_detalle = lista_detalle_factura;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void dgvFactura_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    lblImporteTotal.Text = importe_total(dgvFactura).ToString("N2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            int cantidad_filas_vacias = 0;
            try
            {


                cantidad_filas_vacias = Cantidad_Filas_Vacias(dgvFactura);
                if (cantidad_filas_vacias == cantidad_filas_a_dataGridView - 2) // le agrego el -2 porque la funcion Cantidad_Filas_Vacias(dgvFactura) arranca a contar desde 0 , y tengo una fila con datos
                {
                    throw new Exception("No puede eliminar el unico registro de la factura");
                }


                if (dgvFactura.SelectedRows.Count == 1)
                {


                    DataGridViewRow item = dgvFactura.SelectedRows[0];


                    if (item.Cells["col_id_factura_detalle"].Value != null) //si la columna "col_id_factura_detalle" tiene algo .. elimino el registro de la base
                    {
                        if (logica_factura_detalle.baja_item_a_factura(Convert.ToInt32(item.Cells["col_id_factura_detalle"].Value)) == true)
                        {

                            foreach (DataGridViewCell cell in item.Cells)
                            {
                                if (cell.ColumnIndex != index_columna_col_iva_aumento)
                                {
                                    cell.Value = null;
                                }

                            }
                            //dgvFactura.Rows.RemoveAt(item.Index);
                            MessageBox.Show("Eliminación exitosa", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else //sino remuevo el item de la grilla
                    {

                        foreach (DataGridViewCell cell in item.Cells)
                        {
                            if (cell.ColumnIndex != index_columna_col_iva_aumento)
                            {
                                cell.Value = null;
                            }
                            else
                            {
                                cell.Value = 10.5M;
                            }

                        }
                        //dgvFactura.Rows.RemoveAt(item.Index);
                    }
                    lblImporteTotal.Text = importe_total(dgvFactura).ToString("N2");
                    calcular_lblImportePagoMayor30Dias();
                    calcular_lblImportePagoMenor7Dias();
                    calcular_lblImportePagoMenor30Dias();
                    lblTotal.Text = "Total : " + calcular_total_items_grilla(dgvFactura).ToString();
                }
                else if (dgvFactura.SelectedRows.Count == 0)
                {
                    throw new Exception("Debe seleccionar una fila para eliminar");
                }
                else if (dgvFactura.SelectedRows.Count > 0)
                {
                    throw new Exception("Debe seleccionar una sola fila para eliminar");
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



        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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


                DataSet ds = logica_cliente.buscar_clientes(razon_social);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    frm.IniciarForm(ds.Tables[0], 1);
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("El cliente no existe , ¿desea darlo de alta?", "Atención", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        cliente cliente_a_insertar = new cliente();
                        cliente_a_insertar.razon_social = razon_social;
                        cliente_a_insertar.nombre_fantasia = razon_social;
                        cliente_a_insertar.id_condicion_ante_iva = 13;
                        cliente_a_insertar.id_condicion_pago = 1;
                        cliente_a_insertar.sn_activo = -1;
                        cliente_a_insertar.fec_ult_modif = DateTime.Now;
                        cliente_a_insertar.accion = "ALTA";
                        cliente_a_insertar.id_condicion_factura = 2;
                        cliente_a_insertar.id_tipo_cliente = 2;

                        if (logica_cliente.alta_cliente(cliente_a_insertar) == false)
                        {
                            MessageBox.Show("Error al grabar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            txtClienteId.Text = logica_cliente.buscar_cliente(txtCliente.Text).id_cliente.ToString();
                            MessageBox.Show("Grabación exitosa del cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }





                if (frm.DialogResult == DialogResult.OK)
                {
                    txtCliente.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[1].Value);
                    txtClienteId.Text = Convert.ToString(frm.dgvResultados.SelectedRows[0].Cells[0].Value);
                    if (Convert.ToInt32(frm.dgvResultados.SelectedRows[0].Cells[2].Value) == 1)
                    {
                        chkMostrarMayor30Dias.Checked = true;
                        chkMostrarMenor7Dias.Checked = true;
                        chkMostrarMenor30Dias.Checked = true;
                    }
                    else
                    {
                        chkMostrarMayor30Dias.Checked = false;
                        chkMostrarMenor7Dias.Checked = false;
                        chkMostrarMenor30Dias.Checked = false;
                    }
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



        #region KeyPress
        private void txtPagoInstantaneoPorcentaje1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPagoInstantaneoPorcentaje2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPagoMenor30DiasPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPagoMayor30DiasPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPagoInstantaneoSumaResta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '+')
            {

                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {

                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPagoMenor30DiasSumaResta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '+')
            {

                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {

                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPagoMayor30DiasSumaResta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '+')
            {

                e.Handled = false;
            }
            else if (e.KeyChar == '-')
            {

                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion KeyPress



        #region Leave
        private void txtPagoMenor7DiasPorcentaje1_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPagoMenor7DiasPorcentaje1.Text != "")
                {
                    if (Convert.ToInt32(txtPagoMenor7DiasPorcentaje1.Text) > 100)
                    {
                        txtPagoMenor7DiasPorcentaje1.Text = "";
                        txtPagoMenor7DiasPorcentaje1.Focus();
                        throw new Exception("El porcentaje no puede ser mayor a 100%");
                    }
                }

                calcular_lblImportePagoMenor7Dias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPagoMenor7DiasPorcentaje2_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPagoMenor7DiasPorcentaje2.Text != "")
                {
                    if (Convert.ToInt32(txtPagoMenor7DiasPorcentaje2.Text) > 100)
                    {
                        txtPagoMenor7DiasPorcentaje2.Text = "";
                        txtPagoMenor7DiasPorcentaje2.Focus();
                        throw new Exception("El porcentaje no puede ser mayor a 100%");
                    }

                }

                calcular_lblImportePagoMenor7Dias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPagoMenor30DiasPorcentaje_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPagoMenor30DiasPorcentaje.Text != "")
                {
                    if (Convert.ToInt32(txtPagoMenor30DiasPorcentaje.Text) > 100)
                    {
                        txtPagoMenor30DiasPorcentaje.Text = "";
                        txtPagoMenor30DiasPorcentaje.Focus();
                        throw new Exception("El porcentaje no puede ser mayor a 100%");
                    }
                }

                calcular_lblImportePagoMenor30Dias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPagoMayor30DiasPorcentaje_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPagoMayor30DiasPorcentaje.Text != "")
                {
                    if (Convert.ToInt32(txtPagoMayor30DiasPorcentaje.Text) > 100)
                    {
                        txtPagoMayor30DiasPorcentaje.Text = "";
                        txtPagoMayor30DiasPorcentaje.Focus();
                        throw new Exception("El porcentaje no puede ser mayor a 100%");
                    }
                }

                calcular_lblImportePagoMayor30Dias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion Leave

        private void calcular_lblImportePagoMenor7Dias()
        {
            try
            {

                //if (Convert.ToInt32(cbTipoFactura.SelectedValue) == 2 || Convert.ToInt32(cbTipoFactura.SelectedValue) == 6) //si es nota de credito o debito
                //{
                //    lblImportePagoMenor7Dias.Text = "0.00";
                //}
                //else
                //{
                decimal valor = Logica_Funciones_Generales.monto_mas_menos_un_porcentaje(Convert.ToInt32(txtPagoMenor7DiasPorcentaje1.Text), Convert.ToDecimal(lblImportePagoMayor30Dias.Text), 2); //aplico el primer porcentaje al importe de lblImportePagoMayor30Dias
                valor = Logica_Funciones_Generales.monto_mas_menos_un_porcentaje(Convert.ToInt32(txtPagoMenor7DiasPorcentaje2.Text), valor, 2); //aplico el segundo porcentaje al valor devuelvo de la linea de arriba
                lblImportePagoMenor7Dias.Text = valor.ToString("N2");
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void calcular_lblImportePagoMenor30Dias()
        {
            try
            {
                //if (Convert.ToInt32(cbTipoFactura.SelectedValue) == 2 || Convert.ToInt32(cbTipoFactura.SelectedValue) == 6) //si es nota de credito o debito
                //{
                //    lblImportePagoMenor30Dias.Text = "0.00";
                //}
                //else
                //{
                decimal valor = Logica_Funciones_Generales.monto_mas_menos_un_porcentaje(Convert.ToInt32(txtPagoMenor30DiasPorcentaje.Text), Convert.ToDecimal(lblImportePagoMayor30Dias.Text), 2); //aplico el primer porcentaje al importe de lblImportePagoMayor30Dias
                lblImportePagoMenor30Dias.Text = valor.ToString("N2");
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void calcular_lblImportePagoMayor30Dias()
        {
            try
            {
                //if (Convert.ToInt32(cbTipoFactura.SelectedValue) == 2 || Convert.ToInt32(cbTipoFactura.SelectedValue) == 6) //si es nota de credito o debito
                //{
                //    lblImportePagoMayor30Dias.Text = "0.00";
                //}
                //else
                //{
                decimal valor = Logica_Funciones_Generales.monto_mas_menos_un_porcentaje(Convert.ToInt32(txtPagoMayor30DiasPorcentaje.Text), Convert.ToDecimal(lblImporteTotal.Text), 1); //aplico el primer porcentaje al total
                lblImportePagoMayor30Dias.Text = valor.ToString("N2");
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private int cantidad_de_veces_que_aparece_articulo_en_grilla(string marca, string codigo)
        {
            int _cantidad_de_veces_que_aparece_articulo_en_grilla = 0;
            try
            {
                foreach (DataGridViewRow row in dgvFactura.Rows)
                {
                    if (row.Cells["col_marca"].Value != null && row.Cells["col_codigo"].Value != null)
                    {
                        if (row.Cells["col_marca"].Value.ToString() == marca && row.Cells["col_codigo"].Value.ToString() == codigo)
                        {
                            _cantidad_de_veces_que_aparece_articulo_en_grilla = _cantidad_de_veces_que_aparece_articulo_en_grilla + 1;
                        }
                    }
                }

                return _cantidad_de_veces_que_aparece_articulo_en_grilla;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (factura.sn_emitida == 0) //si todavia no esta emitida la factura , ingreso aca 
                {
                    DXMouseEventArgs ea = e as DXMouseEventArgs;
                    GridView view = sender as GridView;
                    GridHitInfo info = view.CalcHitInfo(ea.Location);

                    decimal ganancia = 0;
                    string descripcion = "";
                    decimal precio_lista_x_coeficiente = 0.00M;
                    string id_articulo = "";
                    decimal precio = 0.00M;
                    decimal importe = 0.00M;
                    decimal iva_aumento = 10.5M;

                    if (info.InRow || info.InRowCell)
                    {

                        int _ultima_fila_con_datos = ultima_fila_con_datos(dgvFactura);
                        int fila_a_insertar_datos = _ultima_fila_con_datos + 1;
                        if (fila_a_insertar_datos > -1)
                        {

                            int[] selectedRows = gridView3.GetSelectedRows();







                            int cantidad = 1;
                            dgvFactura.Rows[fila_a_insertar_datos].Cells["col_cantidad"].Value = cantidad;
                            dgvFactura.Rows[fila_a_insertar_datos].Cells["col_marca"].Value = gridView3.GetRowCellValue(selectedRows[0], "codigo_articulo_marca").ToString();
                            dgvFactura.Rows[fila_a_insertar_datos].Cells["col_codigo"].Value = gridView3.GetRowCellValue(selectedRows[0], "codigo_articulo");
                            dgvFactura.Rows[fila_a_insertar_datos].Cells["col_descripcion"].Value = gridView3.GetRowCellValue(selectedRows[0], "descripcion_articulo");

                            precio_lista_x_coeficiente = Convert.ToDecimal(gridView3.GetRowCellValue(selectedRows[0], "precio_final")); //DESDE EL STORE ESTO ES PRECIO_LISTA * COEFICIENTE
                            precio_lista_x_coeficiente = Math.Round(precio_lista_x_coeficiente, nro_redondeo, MidpointRounding.AwayFromZero);

                            ganancia = (precio_lista_x_coeficiente * iva_aumento) / 100;
                            ganancia = Math.Round(ganancia, nro_redondeo, MidpointRounding.AwayFromZero);

                            precio = (precio_lista_x_coeficiente + ganancia);
                            precio = Math.Round(precio, nro_redondeo, MidpointRounding.AwayFromZero);

                            importe = (precio * cantidad);
                            importe = Math.Round(importe, nro_redondeo, MidpointRounding.AwayFromZero);

                            dgvFactura.Rows[fila_a_insertar_datos].Cells["col_precio"].Value = precio == 0 ? "" : precio.ToString("N2");
                            dgvFactura.Rows[fila_a_insertar_datos].Cells["col_importe"].Value = importe == 0 ? "" : importe.ToString("N2");
                            dgvFactura.Rows[fila_a_insertar_datos].Cells["col_precio_lista_x_coeficiente"].Value = precio_lista_x_coeficiente == 0 ? "" : precio_lista_x_coeficiente.ToString("N2");
                            dgvFactura.Rows[fila_a_insertar_datos].Cells["col_iva_aumento"].Value = iva_aumento.ToString("N2");
                            dgvFactura.Rows[fila_a_insertar_datos].Cells["col_id_articulo"].Value = gridView3.GetRowCellValue(selectedRows[0], "id_articulo").ToString();



                            lblImporteTotal.Text = importe_total(dgvFactura).ToString("N2");
                            calcular_lblImportePagoMayor30Dias();
                            calcular_lblImportePagoMenor7Dias();
                            calcular_lblImportePagoMenor30Dias();
                            lblTotal.Text = "Total : " + calcular_total_items_grilla(dgvFactura).ToString();

                            //me fijo si "marca" - "codigo" ya existe en la grilla , si es asi , aviso
                            string marca = dgvFactura.Rows[fila_a_insertar_datos].Cells["col_marca"].Value.ToString();
                            string codigo = dgvFactura.Rows[fila_a_insertar_datos].Cells["col_codigo"].Value.ToString();

                            if (cantidad_de_veces_que_aparece_articulo_en_grilla(marca, codigo) > 1)
                            {
                                MessageBox.Show("El articulo " + marca + " - " + codigo + " ya existe en esta factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //hasta aca 
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }






        private void dgvFactura_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5 || e.ColumnIndex == 8 || e.ColumnIndex == 9)
                {
                    e.Cancel = true;
                }
                //else if (dgvFactura.Rows[e.RowIndex].Cells[9].Value != null)
                //{
                //    e.Cancel = true;
                //    MessageBox.Show("La fila en donde esta ubicado ya fue grabada,para modificarla debe eliminarla", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
                else
                {
                    dgvFactura.Tag = dgvFactura.CurrentCell.Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void dgvFactura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvFactura.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    if (e.ColumnIndex != 3) //si salgo de una columna distinta de DESCRIPCION ... entro
                    {
                        dgvFactura.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dgvFactura.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().ToUpper();
                    }
                }


                decimal ganancia = 0;
                int cantidad = 0;
                string marca = "";
                string codigo = "";
                string descripcion = "";
                decimal precio_lista_x_coeficiente = 0.00M;
                string id_articulo = "";
                decimal coeficiente = 0;
                decimal precio = 0.00M;
                decimal iva_aumento = 10.50M;
                decimal importe = 0.00M;

                if (dgvFactura.Rows[e.RowIndex].Cells["col_cantidad"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_cantidad"].Value != "")
                    cantidad = Convert.ToInt32(dgvFactura.Rows[e.RowIndex].Cells["col_cantidad"].Value);

                if (dgvFactura.Rows[e.RowIndex].Cells["col_marca"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_marca"].Value != "")
                    marca = dgvFactura.Rows[e.RowIndex].Cells["col_marca"].Value.ToString();

                if (dgvFactura.Rows[e.RowIndex].Cells["col_codigo"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_codigo"].Value != "")
                    codigo = dgvFactura.Rows[e.RowIndex].Cells["col_codigo"].Value.ToString();


                if (dgvFactura.Rows[e.RowIndex].Cells["col_descripcion"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_descripcion"].Value != "")
                    descripcion = dgvFactura.Rows[e.RowIndex].Cells["col_descripcion"].Value.ToString();


                if (dgvFactura.Rows[e.RowIndex].Cells["col_precio_lista_x_coeficiente"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_precio_lista_x_coeficiente"].Value != "")
                    precio_lista_x_coeficiente = Convert.ToDecimal(dgvFactura.Rows[e.RowIndex].Cells["col_precio_lista_x_coeficiente"].Value);


                if (dgvFactura.Rows[e.RowIndex].Cells["col_id_articulo"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_id_articulo"].Value != "")
                    id_articulo = dgvFactura.Rows[e.RowIndex].Cells["col_id_articulo"].Value.ToString();

                if (dgvFactura.Rows[e.RowIndex].Cells["col_iva_aumento"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_iva_aumento"].Value != "")
                    iva_aumento = Convert.ToDecimal(dgvFactura.Rows[e.RowIndex].Cells["col_iva_aumento"].Value);

                ganancia = (precio_lista_x_coeficiente * iva_aumento) / 100;
                ganancia = Math.Round(ganancia, nro_redondeo, MidpointRounding.AwayFromZero);

                if (dgvFactura.Rows[e.RowIndex].Cells["col_precio"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_precio"].Value != "")
                    precio = Convert.ToDecimal(dgvFactura.Rows[e.RowIndex].Cells["col_precio"].Value);

                importe = precio * cantidad;
                importe = Math.Round(importe, nro_redondeo, MidpointRounding.AwayFromZero);

                if (e.ColumnIndex == 1 || e.ColumnIndex == 2) //si salgo de CODIGO o MARCA
                {
                    if (marca != "" && codigo != "")
                    {
                        Cursor.Current = Cursors.WaitCursor;


                        DataTable dt = logica_articulo.buscar_articulo_por_codigo_articulo_marca_y_codigo_articulo(marca, codigo).Tables[0];
                        if (dt.Rows.Count > 0)
                        {


                            descripcion = dt.Rows[0]["descripcion_articulo"].ToString();
                            coeficiente = Convert.ToDecimal(dt.Rows[0]["coeficiente"].ToString()); //NO TENGO QUE REDONDEAR NUNCA

                            precio_lista_x_coeficiente = Convert.ToDecimal(Convert.ToDecimal(dt.Rows[0]["precio_lista"].ToString()) * coeficiente);
                            precio_lista_x_coeficiente = Math.Round(precio_lista_x_coeficiente, nro_redondeo, MidpointRounding.AwayFromZero);

                            ganancia = (precio_lista_x_coeficiente * iva_aumento) / 100;
                            ganancia = Math.Round(ganancia, nro_redondeo, MidpointRounding.AwayFromZero);

                            precio = Convert.ToDecimal(precio_lista_x_coeficiente + ganancia);
                            precio = Math.Round(precio, nro_redondeo, MidpointRounding.AwayFromZero);

                            importe = Convert.ToDecimal(precio * cantidad);
                            importe = Math.Round(importe, nro_redondeo, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            descripcion = "";
                            precio_lista_x_coeficiente = 0.00M;
                            ganancia = 0.00M;
                            precio = 0.00M;
                            importe = 0.00M;
                        }


                        //me fijo si "marca" - "codigo" ya existe en la grilla , si es asi , aviso
                        if (cantidad_de_veces_que_aparece_articulo_en_grilla(marca, codigo) > 1)
                        {
                            MessageBox.Show("El articulo " + marca + " - " + codigo + " ya existe en esta factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        Cursor.Current = Cursors.Default;
                    }
                    else
                    {
                        descripcion = "";
                        precio_lista_x_coeficiente = 0.00M;
                        ganancia = 0.00M;
                        precio = 0.00M;
                        importe = 0.00M;
                    }
                }
                else if (e.ColumnIndex == 4) //si salgo de PRECIO , CALCULO "PRECIO_LISTA_X_COEFICIENTE" , Y "IMPORTE" LO CALCULO MAS ARRIBA
                {

                    if (dgvFactura.CurrentCell.Value != null) //si hay algo escrito en PRECIO
                    {
                        if (dgvFactura.Tag.ToString() != dgvFactura.CurrentCell.Value.ToString()) //SI LO QUE DECIA LA CELDA ES DISTINTO A LO QUE ESTOY PONIENDO....EL ARTICULO NO EXISTE
                        {
                            if (dgvFactura.Rows[e.RowIndex].Cells["col_iva_aumento"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_iva_aumento"].Value != "")
                                iva_aumento = Convert.ToDecimal(dgvFactura.Rows[e.RowIndex].Cells["col_iva_aumento"].Value);

                            if (dgvFactura.Rows[e.RowIndex].Cells["col_precio"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_precio"].Value != "")
                                precio = Convert.ToDecimal(dgvFactura.Rows[e.RowIndex].Cells["col_precio"].Value);

                            precio_lista_x_coeficiente = (precio / ((iva_aumento / 100) + 1));
                            precio_lista_x_coeficiente = Math.Round(precio_lista_x_coeficiente, nro_redondeo, MidpointRounding.AwayFromZero);


                        }
                    }

                }
                else if (e.ColumnIndex == 6) //si salgo de PRECIO_LISTA_X_COEFICIENTE , CALCULO "PRECIO" E "IMPORTE"
                {

                    precio = ganancia + precio_lista_x_coeficiente;
                    precio = Math.Round(precio, nro_redondeo, MidpointRounding.AwayFromZero);

                    importe = precio * cantidad;
                    importe = Math.Round(importe, nro_redondeo, MidpointRounding.AwayFromZero);
                }
                else if (e.ColumnIndex == 7) //si salgo de IVA_AUMENTO , CALCULO "PRECIO" E "IMPORTE"
                {
                    if (dgvFactura.Rows[e.RowIndex].Cells["col_iva_aumento"].Value != null && dgvFactura.Rows[e.RowIndex].Cells["col_iva_aumento"].Value != "")
                        iva_aumento = Convert.ToDecimal(dgvFactura.Rows[e.RowIndex].Cells["col_iva_aumento"].Value);

                    ganancia = (precio_lista_x_coeficiente * iva_aumento) / 100;
                    ganancia = Math.Round(ganancia, nro_redondeo, MidpointRounding.AwayFromZero);

                    precio = ganancia + precio_lista_x_coeficiente;
                    precio = Math.Round(precio, nro_redondeo, MidpointRounding.AwayFromZero);

                    importe = precio * cantidad;
                    importe = Math.Round(importe, nro_redondeo, MidpointRounding.AwayFromZero);
                }

                //CALCULO "ID_ARTICULO"
                //SI NO HAY CARGADO "CODIGO_ARTICULO_MARCA" Y "CODIGO_ARTICULO" , ID_ARTICULO VA A SER VACIO
                if (marca == "" || codigo == "")
                {
                    id_articulo = "";
                }
                else
                {
                    //VOY A BUSCAR A LA BASE DE DATOS -> LOS DATOS DEL ARTICULO SEGUN "CODIGO_ARTICULO_MARCA" Y "CODIGO_ARTICULO"
                    DataTable dt_db = logica_articulo.buscar_articulo_por_codigo_articulo_marca_y_codigo_articulo(marca, codigo).Tables[0];
                    if (dt_db.Rows.Count > 0)
                    {

                        string descripcion_db = dt_db.Rows[0]["descripcion_articulo"].ToString();
                        decimal coeficiente_db = Convert.ToDecimal(dt_db.Rows[0]["coeficiente"].ToString()); //NO TENGO QUE REDONDEAR NUNCA

                        decimal precio_lista_x_coeficiente_db = Convert.ToDecimal(Convert.ToDecimal(dt_db.Rows[0]["precio_lista"].ToString()) * coeficiente_db);
                        precio_lista_x_coeficiente_db = Math.Round(precio_lista_x_coeficiente_db, nro_redondeo, MidpointRounding.AwayFromZero);

                        decimal ganancia_db = (precio_lista_x_coeficiente_db * iva_aumento) / 100;
                        ganancia_db = Math.Round(ganancia_db, nro_redondeo, MidpointRounding.AwayFromZero);

                        decimal precio_db = Convert.ToDecimal(precio_lista_x_coeficiente_db + ganancia_db);
                        precio_db = Math.Round(precio_db, nro_redondeo, MidpointRounding.AwayFromZero);

                        decimal importe_db = Convert.ToDecimal(precio_db * cantidad);
                        importe_db = Math.Round(importe_db, nro_redondeo, MidpointRounding.AwayFromZero);

                        //COMPARO LO QUE DICE EN LA FILA DE LA GRILLA , CON LO QUE VIENE DE LA BASE DE DATOS
                        //SI LA COLUMNA "DESCRIPCION" ES IGUAL A LA "DESCRIPCION" QUE DEVUELVE LA BD
                        //Y LA COLUMNA "PRECIO" ES IGUAL AL "PRECIO" QUE DEVUELVE DE LA BD
                        //Y LA COLUMNA "PRECIO_LISTA_X_COEFICIENTE" ES IGUAL A "PRECIO_LISTA_X_COEFICIENTE" DE LA BD
                        //QUIERE DECIR QUE LA FILA DE LA GRILLA TIENE LOS MISMOS DATOS QUE LA BD , POR ENDE TIENE "ID_ARTICULO"
                        if (
                            descripcion == dt_db.Rows[0]["descripcion_articulo"].ToString() &&
                            precio == precio_db &&
                            precio_lista_x_coeficiente == precio_lista_x_coeficiente_db
                         )
                        {
                            id_articulo = dt_db.Rows[0]["id_articulo"].ToString();
                        }
                        else
                        {
                            id_articulo = "-999";
                        }

                    }
                    else
                    {
                        id_articulo = "-999";
                    }
                }
                //HASTA ACA

                dgvFactura.Rows[e.RowIndex].Cells["col_descripcion"].Value = descripcion == "" ? "" : descripcion.ToString();
                dgvFactura.Rows[e.RowIndex].Cells["col_precio"].Value = precio == 0 ? "" : precio.ToString("N2");
                dgvFactura.Rows[e.RowIndex].Cells["col_importe"].Value = importe == 0 ? "" : importe.ToString("N2");
                dgvFactura.Rows[e.RowIndex].Cells["col_precio_lista_x_coeficiente"].Value = precio_lista_x_coeficiente == 0 ? "" : precio_lista_x_coeficiente.ToString("N2");
                dgvFactura.Rows[e.RowIndex].Cells["col_iva_aumento"].Value = iva_aumento == 0 ? "" : iva_aumento.ToString("N2");
                dgvFactura.Rows[e.RowIndex].Cells["col_id_articulo"].Value = id_articulo == "" ? "" : id_articulo.ToString();


                lblImporteTotal.Text = importe_total(dgvFactura).ToString("N2");
                calcular_lblImportePagoMayor30Dias();
                calcular_lblImportePagoMenor7Dias();
                calcular_lblImportePagoMenor30Dias();
                lblTotal.Text = "Total : " + calcular_total_items_grilla(dgvFactura).ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int calcular_total_items_grilla(DataGridView dataGridView)
        {
            try
            {
                int cantidad = 0;
                for (int i = 0; i < dataGridView.RowCount - 1; i++)
                {
                    string col_cantidad = dataGridView.Rows[i].Cells["col_cantidad"].Value == null ? "" : dataGridView.Rows[i].Cells["col_cantidad"].Value.ToString();
                    string col_marca = dataGridView.Rows[i].Cells["col_marca"].Value == null ? "" : dataGridView.Rows[i].Cells["col_marca"].Value.ToString();
                    string col_codigo = dataGridView.Rows[i].Cells["col_codigo"].Value == null ? "" : dataGridView.Rows[i].Cells["col_codigo"].Value.ToString();
                    string col_descripcion = dataGridView.Rows[i].Cells["col_descripcion"].Value == null ? "" : dataGridView.Rows[i].Cells["col_descripcion"].Value.ToString();
                    string col_precio = dataGridView.Rows[i].Cells["col_precio"].Value == null ? "" : dataGridView.Rows[i].Cells["col_precio"].Value.ToString();
                    string col_importe = dataGridView.Rows[i].Cells["col_importe"].Value == null ? "" : dataGridView.Rows[i].Cells["col_importe"].Value.ToString();
                    string col_precio_lista_x_coeficiente = dataGridView.Rows[i].Cells["col_precio_lista_x_coeficiente"].Value == null ? "" : dataGridView.Rows[i].Cells["col_precio_lista_x_coeficiente"].Value.ToString();
                    string col_iva_aumento = dataGridView.Rows[i].Cells["col_iva_aumento"].Value == null ? "" : dataGridView.Rows[i].Cells["col_iva_aumento"].Value.ToString();
                    string col_id_articulo = dataGridView.Rows[i].Cells["col_id_articulo"].Value == null ? "" : dataGridView.Rows[i].Cells["col_id_articulo"].Value.ToString();
                    string col_id_factura_detalle = dataGridView.Rows[i].Cells["col_id_factura_detalle"].Value == null ? "" : dataGridView.Rows[i].Cells["col_id_factura_detalle"].Value.ToString();

                    if
                    (
                        col_cantidad != "" &&
                        col_marca != "" &&
                        col_codigo != "" &&
                        col_descripcion != "" &&
                        col_precio != "" &&
                        col_importe != "" &&
                        col_precio_lista_x_coeficiente != "" &&
                        col_iva_aumento != "" &&
                        col_id_articulo != ""
                    //col_id_factura_detalle != ""
                    )
                    {
                        cantidad = cantidad + 1;
                    }
                }
                return cantidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private int ultima_fila_con_datos(DataGridView dataGridView)
        {
            try
            {
                int fila = -1;
                for (int i = 0; i < dataGridView.RowCount - 1; i++)
                {
                    string col_cantidad = dataGridView.Rows[i].Cells["col_cantidad"].Value == null ? "" : dataGridView.Rows[i].Cells["col_cantidad"].Value.ToString();
                    string col_marca = dataGridView.Rows[i].Cells["col_marca"].Value == null ? "" : dataGridView.Rows[i].Cells["col_marca"].Value.ToString();
                    string col_codigo = dataGridView.Rows[i].Cells["col_codigo"].Value == null ? "" : dataGridView.Rows[i].Cells["col_codigo"].Value.ToString();
                    string col_descripcion = dataGridView.Rows[i].Cells["col_descripcion"].Value == null ? "" : dataGridView.Rows[i].Cells["col_descripcion"].Value.ToString();
                    string col_precio = dataGridView.Rows[i].Cells["col_precio"].Value == null ? "" : dataGridView.Rows[i].Cells["col_precio"].Value.ToString();
                    string col_importe = dataGridView.Rows[i].Cells["col_importe"].Value == null ? "" : dataGridView.Rows[i].Cells["col_importe"].Value.ToString();
                    string col_precio_lista_x_coeficiente = dataGridView.Rows[i].Cells["col_precio_lista_x_coeficiente"].Value == null ? "" : dataGridView.Rows[i].Cells["col_precio_lista_x_coeficiente"].Value.ToString();
                    string col_iva_aumento = dataGridView.Rows[i].Cells["col_iva_aumento"].Value == null ? "" : dataGridView.Rows[i].Cells["col_iva_aumento"].Value.ToString();
                    string col_id_articulo = dataGridView.Rows[i].Cells["col_id_articulo"].Value == null ? "" : dataGridView.Rows[i].Cells["col_id_articulo"].Value.ToString();
                    string col_id_factura_detalle = dataGridView.Rows[i].Cells["col_id_factura_detalle"].Value == null ? "" : dataGridView.Rows[i].Cells["col_id_factura_detalle"].Value.ToString();

                    if
                    (
                        col_cantidad != "" &&
                        col_marca != "" &&
                        col_codigo != "" &&
                        col_descripcion != "" &&
                        col_precio != "" &&
                        col_importe != "" &&
                        col_precio_lista_x_coeficiente != "" &&
                        col_iva_aumento != "" &&
                        col_id_articulo != ""
                    //col_id_factura_detalle != ""
                    )
                    {
                        fila = i;
                    }
                }
                return fila;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void txtObservacion_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtObservacion.Text != "")
                {
                    txtObservacion.Text = txtObservacion.Text.ToUpper();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void itemDropDownButton_Click(object sender, EventArgs e)
        {

            try
            {

                if (((DXMenuItem)sender).Caption == opcion_1_dropDownButton)
                {
                    grabar(1);
                }
                else if (((DXMenuItem)sender).Caption == opcion_2_dropDownButton)
                {
                    grabar(2);
                }
                else if (((DXMenuItem)sender).Caption == opcion_3_dropDownButton)
                {
                    grabar(3);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            try
            {

                decimal precio_lista_x_coeficiente = 0.00M;
                decimal aumento_descuento = 0.00M;
                decimal ganancia = 0.00M;
                decimal iva_aumento = 10.50M;
                decimal precio = 0.00M;
                decimal importe = 0.00M;
                int cantidad = 0;
                decimal porcentaje = 0.00M;

                if (txtPorcentaje.Text == "")
                {
                    txtPorcentaje.Focus();
                    throw new Exception("Debe completar porcentaje");
                }
                if (txtAumento_Descuento.Text == "")
                {
                    txtAumento_Descuento.Focus();
                    throw new Exception("Debe completar aumento-descuento");
                }




                if (dgvFactura.SelectedRows.Count > 0)
                {

                    foreach (DataGridViewRow row in dgvFactura.SelectedRows)
                    {

                        if (row.Cells["col_precio_lista_x_coeficiente"].Value != null && row.Cells["col_precio_lista_x_coeficiente"].Value != "")
                            precio_lista_x_coeficiente = Convert.ToDecimal(row.Cells["col_precio_lista_x_coeficiente"].Value);

                        if (row.Cells["col_iva_aumento"].Value != null && row.Cells["col_iva_aumento"].Value != "")
                            iva_aumento = Convert.ToDecimal(row.Cells["col_iva_aumento"].Value);

                        if (row.Cells["col_cantidad"].Value != null && row.Cells["col_cantidad"].Value != "")
                            cantidad = Convert.ToInt32(row.Cells["col_cantidad"].Value);

                        porcentaje = Convert.ToDecimal(txtPorcentaje.Text);

                        aumento_descuento = (precio_lista_x_coeficiente * porcentaje) / 100;
                        aumento_descuento = Math.Round(aumento_descuento, nro_redondeo, MidpointRounding.AwayFromZero);

                        if (txtAumento_Descuento.Text == "+")
                        {
                            precio_lista_x_coeficiente = precio_lista_x_coeficiente + aumento_descuento;
                            precio_lista_x_coeficiente = Math.Round(precio_lista_x_coeficiente, nro_redondeo, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            precio_lista_x_coeficiente = precio_lista_x_coeficiente - aumento_descuento;
                            precio_lista_x_coeficiente = Math.Round(precio_lista_x_coeficiente, nro_redondeo, MidpointRounding.AwayFromZero);
                        }

                        ganancia = (precio_lista_x_coeficiente * iva_aumento) / 100;
                        ganancia = Math.Round(ganancia, nro_redondeo, MidpointRounding.AwayFromZero);

                        precio = precio_lista_x_coeficiente + ganancia;
                        precio = Math.Round(precio, nro_redondeo, MidpointRounding.AwayFromZero);

                        importe = precio * cantidad;
                        importe = Math.Round(importe, nro_redondeo, MidpointRounding.AwayFromZero);

                        row.Cells["col_precio"].Value = precio == 0 ? "" : precio.ToString("N2");
                        row.Cells["col_importe"].Value = importe == 0 ? "" : importe.ToString("N2");
                        row.Cells["col_precio_lista_x_coeficiente"].Value = precio_lista_x_coeficiente == 0 ? "" : precio_lista_x_coeficiente.ToString("N2");
                        row.Cells["col_id_articulo"].Value = -999;
                    }

                    txtPorcentaje.Text = "";
                    txtAumento_Descuento.Text = "";
                    MessageBox.Show("Actualización exitosa", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (dgvFactura.SelectedRows.Count == 0)
                {
                    throw new Exception("Debe seleccionar una fila");
                }

                lblImporteTotal.Text = importe_total(dgvFactura).ToString("N2");
                calcular_lblImportePagoMayor30Dias();
                calcular_lblImportePagoMenor7Dias();
                calcular_lblImportePagoMenor30Dias();


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

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPorcentaje_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPorcentaje.Text != "")
                {
                    if (Convert.ToInt32(txtPorcentaje.Text) > 100)
                    {
                        txtPorcentaje.Text = "";
                        txtPorcentaje.Focus();
                        throw new Exception("El porcentaje no puede ser mayor a 100%");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAumento_Descuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || char.IsControl(e.KeyChar) || e.KeyChar == '+')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void lblImporteTotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void lblImporteTotal_Leave(object sender, EventArgs e)
        {
            try
            {
                calcular_lblImportePagoMayor30Dias();
                calcular_lblImportePagoMenor7Dias();
                calcular_lblImportePagoMenor30Dias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frmFactura_FormClosing(object sender, FormClosingEventArgs e)
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

        private void cbTipoFactura_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Logica_Factura_Tipo logica_factura_tipo = new Logica_Factura_Tipo();
            try
            {
                if (factura != null) //si ya existe una factura cargada
                {
                    if (factura.id_factura > 0) //y el id_factura es mayor a 0 (eso quiere decir que algo tiene la factura)
                    {
                        if (cbTipoFactura.SelectedItem != null) //y hay algo seleccionado en cbTipoFactura 
                        {
                            if (factura.cod_tipo_factura != Convert.ToInt32(cbTipoFactura.SelectedValue)) //y el tipo de factura seleccionado es distinto al que esta cargado en "factura" (al ingresar al modulo) ...
                            {
                                txtNroFactura.Text = logica_factura_tipo.ult_nro_factura_no_usado_en_tipo_factura(Convert.ToDecimal(cbTipoFactura.SelectedValue)).ToString(); //voy a buscar el ult_nro_factura_no_usado_en_tipo_factura
                            }
                            else
                            {
                                txtNroFactura.Text = factura.nro_factura.ToString(); //en su defecto vuelvo a poner el nro que estaba
                            }
                        }
                        else
                        {
                            cbTipoFactura.Focus();
                            throw new Exception("Debe elegir un tipo de factura");
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}






