using DevExpress.Export;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Modulo_Administracion.Clases;
using Modulo_Administracion.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Modulo_Administracion.Vista
{
    public partial class frmCliente_Cuenta_Corriente : Form
    {
        cliente cliente;
        Logica_Cliente_Cuenta_Corriente logica_cliente_cuenta_corriente = new Logica_Cliente_Cuenta_Corriente();
        Logica_Factura logica_factura = new Logica_Factura();


        string valor_remito = "REMITO";
        string valor_nota_credito = "NOTA DE CREDITO";
        string valor_nota_debito = "NOTA DE DEBITO";
        string valor_factura_a = "FACTURA A";
        string valor_factura_b = "FACTURA B";

        public frmCliente_Cuenta_Corriente(cliente _cliente)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                InitializeComponent();
                cliente = _cliente;

                this.Text = cliente.nombre_fantasia;

                iniciar();

                cargar_gridControl();



                gridView1.Columns["Id"].Visible = false;
                gridView1.Columns["Id_factura"].Visible = false;

                gridView1.Columns["Fecha"].Width = 100;
                gridView1.Columns["Tipo Factura"].Width = 120;
                gridView1.Columns["Pago 1"].Width = 100;
                gridView1.Columns["Pago 2"].Width = 100;
                gridView1.Columns["Pago 3"].Width = 100;
                gridView1.Columns["Pago 4"].Width = 100;

                gridView1.Columns["S.Acum"].OptionsColumn.ReadOnly = true;
                gridView1.Columns["Observacion Factura"].OptionsColumn.ReadOnly = true;
                gridView1.Columns["Condicion Factura"].OptionsColumn.ReadOnly = true;

                gridView1.Columns["Imp Factura"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Imp Factura", "{0}");
                gridView1.Columns["Pago 1"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pago 1", "{0}");
                gridView1.Columns["Pago 2"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pago 2", "{0}");
                gridView1.Columns["Pago 3"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pago 3", "{0}");
                gridView1.Columns["Pago 4"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Pago 4", "{0}");
                gridView1.Columns["Saldo"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Saldo", "{0}");

                gridControl1.ForceInitialize();
                RepositoryItemComboBox _riEditor = new RepositoryItemComboBox();
                _riEditor.Items.AddRange(new string[] { valor_remito, valor_nota_credito, valor_nota_debito, valor_factura_a, valor_factura_b });
                gridControl1.RepositoryItems.Add(_riEditor);
                gridView1.Columns[3].ColumnEdit = _riEditor;

                gridView1.BestFitColumns();

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


        private void iniciar()
        {
            try
            {

                gridControl1.Focus();
                rdDeuda.Checked = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            frmEspere frm_Espere = new frmEspere();
            int tipo;
            try
            {


                //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + "CUENTA CORRIENTE " + cliente.nombre_fantasia + ".pdf";



                if (rdDeuda.Checked == true)
                {
                    tipo = 1;
                }
                else
                {
                    tipo = 2;
                }


                Cursor.Current = Cursors.WaitCursor;

                frm_Espere.Show();

                reporte_cliente_cuenta_corriente report = new reporte_cliente_cuenta_corriente();
                report.Parameters["id_cliente"].Value = Convert.ToInt32(cliente.id_cliente);
                report.Parameters["id_cliente"].Visible = false;

                report.Parameters["tipo"].Value = tipo;
                report.Parameters["tipo"].Visible = false;

                report.Parameters["cliente_nombre_fantasia"].Value = cliente.nombre_fantasia;
                report.Parameters["cliente_nombre_fantasia"].Visible = false;

                frm_Espere.Hide();
                Cursor.Current = Cursors.Default;

                report.ShowPreview();
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

        public void Options_CustomizeDocumentColumn(CustomizeDocumentColumnEventArgs e)
        {

            if (e.ColumnFieldName == "Fecha Pago 1")
            {
                e.DocumentColumn.WidthInPixels = 0;
            }
            if (e.ColumnFieldName == "Fecha Pago 2")
            {
                e.DocumentColumn.WidthInPixels = 0;
            }
            if (e.ColumnFieldName == "Fecha Pago 3")
            {
                e.DocumentColumn.WidthInPixels = 0;
            }
            if (e.ColumnFieldName == "Fecha Pago 4")
            {
                e.DocumentColumn.WidthInPixels = 0;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                GridView view = sender as GridView;
                if (view == null) return;
                string saldo = "0,0000";
                decimal imp_factura = 0.0000M;
                decimal pago1 = 0.0000M;
                decimal pago2 = 0.0000M;
                decimal pago3 = 0.0000M;
                decimal pago4 = 0.0000M;
                Int64 nro_factura;
                int cod_tipo_factura = 0;

                if (e.Column.FieldName == "Tipo Factura") //si la columna de la que estoy saliendo es Tipo Factura
                {
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Tipo Factura"]).ToString() != "") //si hay algo escrito en Tipo Factura
                    {

                        //voy a buscar el ultimo nro de factura vieja y pongo (ese valor + 1)  en Nro Factura  
                        //ya que cuando hago click en "agregar movimiento" y elijo el tipo de remito , necesito que en Nro Factura me cargue el ultimo nro de factura vieja +  1
                        Int64 ultimo_nro_factura_vieja = logica_cliente_cuenta_corriente.buscar_ultimo_nro_factura_vieja();
                        view.SetRowCellValue(e.RowHandle, view.Columns["Nro Factura"], ultimo_nro_factura_vieja + 1);
                    }
                }
                else if (e.Column.FieldName == "Nro Factura") //si la columna de la que estoy saliendo es Nro Factura
                {
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Nro Factura"]).ToString() != "") //si hay algo escrito en Nro Factura
                    {
                        nro_factura = Convert.ToInt64(view.GetRowCellValue(e.RowHandle, view.Columns["Nro Factura"]).ToString()); //convierto Nro Factura en INT64
                        if (view.GetRowCellValue(e.RowHandle, "Tipo Factura").ToString() != "") //si hay algo escrito en Tipo Factura , cargo cod_tipo_factura
                        {
                            if (view.GetRowCellValue(e.RowHandle, "Tipo Factura").ToString() == valor_remito)
                            {
                                cod_tipo_factura = 1;
                            }
                            else if (view.GetRowCellValue(e.RowHandle, "Tipo Factura").ToString() == valor_nota_credito)
                            {
                                cod_tipo_factura = 2;
                            }
                            else if (view.GetRowCellValue(e.RowHandle, "Tipo Factura").ToString() == valor_nota_debito)
                            {
                                cod_tipo_factura = 6;
                            }
                            else if (view.GetRowCellValue(e.RowHandle, "Tipo Factura").ToString() == valor_factura_a)
                            {
                                cod_tipo_factura = 7;
                            }
                            else if (view.GetRowCellValue(e.RowHandle, "Tipo Factura").ToString() == valor_factura_b)
                            {
                                cod_tipo_factura = 8;
                            }

                        }
                        if (cod_tipo_factura == 0) //si cod_tipo_factura es 0 , hubo un error
                        {
                            throw new Exception("Error en el tipo de factura");
                        }

                        if (cod_tipo_factura == 1) //solamente lo hago si es remito , en nota de credito y debito no
                        {

                            DataTable dt = logica_cliente_cuenta_corriente.buscar_factura_por_nro_tipo_cliente(nro_factura, cod_tipo_factura).Tables[0]; //si existe la factura con ese nro y ese cod_tipo_factura , ya sea que la factura existe en el sistema o no... alerto de un error
                            if (dt.Rows.Count > 0)
                            {
                                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                                {
                                    view.SetRowCellValue(e.RowHandle, view.Columns["Nro Factura"], "");
                                    throw new Exception("Ya existe ese nro de factura en el tipo : " + view.GetRowCellValue(e.RowHandle, "Tipo Factura").ToString());
                                }
                            }

                        }
                    }
                }
                else if (e.Column.FieldName == "Imp Factura" || e.Column.FieldName == "Pago 1" || e.Column.FieldName == "Pago 2" || e.Column.FieldName == "Pago 3" || e.Column.FieldName == "Pago 4")
                {


                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Imp Factura"]).ToString() != "")
                    {
                        imp_factura = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Imp Factura"]).ToString());
                    }

                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Pago 1"]).ToString() != "")
                    {
                        pago1 = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Pago 1"]).ToString());
                    }

                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Pago 2"]).ToString() != "")
                    {
                        pago2 = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Pago 2"]).ToString());
                    }

                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Pago 3"]).ToString() != "")
                    {
                        pago3 = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Pago 3"]).ToString());
                    }

                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Pago 4"]).ToString() != "")
                    {
                        pago4 = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, view.Columns["Pago 4"]).ToString());
                    }

                    saldo = (imp_factura - pago1 - pago2 - pago3 - pago4).ToString("N2");

                    view.SetRowCellValue(e.RowHandle, view.Columns["Saldo"], saldo);
                }
                if (e.Column.FieldName == "Fecha Pago 1")
                {
                    DateTime fecha;
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 1"]).ToString() != "")
                    {
                        fecha = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 1"]).ToString());
                        if (fecha.Date > DateTime.Now.Date)
                        {
                            view.SetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 1"], null);
                            throw new Exception("La fecha del pago 1 no puede ser mayor a hoy");
                        }
                    }
                }
                if (e.Column.FieldName == "Fecha Pago 2")
                {
                    DateTime fecha;
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 2"]).ToString() != "")
                    {
                        fecha = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 2"]).ToString());
                        if (fecha.Date > DateTime.Now.Date)
                        {
                            view.SetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 2"], null);
                            throw new Exception("La fecha del pago 2 no puede ser mayor a hoy");
                        }
                    }
                }
                if (e.Column.FieldName == "Fecha Pago 3")
                {
                    DateTime fecha;
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 3"]).ToString() != "")
                    {
                        fecha = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 3"]).ToString());
                        if (fecha.Date > DateTime.Now.Date)
                        {
                            view.SetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 3"], null);
                            throw new Exception("La fecha del pago 3 no puede ser mayor a hoy");
                        }
                    }
                }
                if (e.Column.FieldName == "Fecha Pago 4")
                {
                    DateTime fecha;
                    if (view.GetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 4"]).ToString() != "")
                    {
                        fecha = Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 4"]).ToString());
                        if (fecha.Date > DateTime.Now.Date)
                        {
                            view.SetRowCellValue(e.RowHandle, view.Columns["Fecha Pago 4"], null);
                            throw new Exception("La fecha del pago 4 no puede ser mayor a hoy");
                        }
                    }
                }
                if (e.Column.FieldName == "Observacion Movimiento Cta Cte")
                {
                    string observacion = "";
                    observacion = view.GetRowCellValue(e.RowHandle, view.Columns["Observacion Movimiento Cta Cte"]).ToString();
                    if (observacion.Length > 50)
                    {

                        view.SetRowCellValue(e.RowHandle, view.Columns["Observacion Movimiento Cta Cte"], "");
                        throw new Exception("La observacion del movimiento de cta cte tiene mas de 50 caracteres");
                    }
                }

                gridView1.BestFitColumns();

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void Valido(GridView gridView)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                //validacion
                for (int i = 0; i < gridView.DataRowCount; i++)
                {


                    if (gridView.GetRowCellValue(i, "Id_factura").ToString() == "") //si es una factura de las viejas
                    {
                        if (gridView.GetRowCellValue(i, "Fecha").ToString() == "") //y la fecha esta vacia...
                        {
                            gridView.FocusedRowHandle = i;
                            gridView.FocusedColumn = gridView.Columns["Fecha"];
                            gridView.ShowEditor();
                            throw new Exception("Debe cargar la fecha de la factura");
                        }

                        if (gridView.GetRowCellValue(i, "Tipo Factura").ToString() == "") //y el tipo de factura esta vacio...
                        {
                            gridView.FocusedRowHandle = i;
                            gridView.FocusedColumn = gridView.Columns["Tipo Factura"];
                            gridView.ShowEditor();
                            throw new Exception("Debe cargar el tipo de factura");
                        }

                        if (gridView.GetRowCellValue(i, "Nro Factura").ToString() == "") //y el nro de factura esta vacio...
                        {
                            gridView.FocusedRowHandle = i;
                            gridView.FocusedColumn = gridView.Columns["Nro Factura"];
                            gridView.ShowEditor();
                            throw new Exception("Debe cargar el nro de factura");
                        }


                    }

                    if (gridView.GetRowCellValue(i, "Pago 1").ToString() != "" && gridView.GetRowCellValue(i, "Fecha Pago 1").ToString() == "")
                    {
                        gridView.FocusedRowHandle = i;
                        gridView.FocusedColumn = gridView.Columns["Fecha Pago 1"];
                        gridView.ShowEditor();
                        throw new Exception("Debe cargar la fecha del pago 1");
                    }

                    if (gridView.GetRowCellValue(i, "Pago 2").ToString() != "" && gridView.GetRowCellValue(i, "Fecha Pago 2").ToString() == "")
                    {
                        gridView.FocusedRowHandle = i;
                        gridView.FocusedColumn = gridView.Columns["Fecha Pago 2"];
                        gridView.ShowEditor();
                        throw new Exception("Debe cargar la fecha del pago 2");
                    }

                    if (gridView.GetRowCellValue(i, "Pago 3").ToString() != "" && gridView.GetRowCellValue(i, "Fecha Pago 3").ToString() == "")
                    {

                        gridView.FocusedRowHandle = i;
                        gridView.FocusedColumn = gridView.Columns["Fecha Pago 3"];
                        gridView.ShowEditor();
                        throw new Exception("Debe cargar la fecha del pago 3");
                    }

                    if (gridView.GetRowCellValue(i, "Pago 4").ToString() != "" && gridView.GetRowCellValue(i, "Fecha Pago 4").ToString() == "")
                    {
                        gridView.FocusedRowHandle = i;
                        gridView.FocusedColumn = gridView.Columns["Fecha Pago 4"];
                        gridView.ShowEditor();
                        throw new Exception("Debe cargar la fecha del pago 4");
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<cliente_cuenta_corriente> lista_cliente_cuenta_corriente = new List<cliente_cuenta_corriente>() { };
                cliente_cuenta_corriente cliente_cuenta_corriente = null;


                Valido(gridView1);


                //grabacion
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {

                    cliente_cuenta_corriente = new cliente_cuenta_corriente();

                    if (gridView1.GetRowCellValue(i, "Id_factura").ToString() == "") //si es una factura de las viejas
                    {

                        if (gridView1.GetRowCellValue(i, "Id").ToString() != "")
                        {
                            cliente_cuenta_corriente.id_cliente_cuenta_corriente = Convert.ToInt32(gridView1.GetRowCellValue(i, "Id").ToString());
                        }

                        cliente_cuenta_corriente.id_cliente = cliente.id_cliente;

                        cliente_cuenta_corriente.id_factura = null;
                        if (gridView1.GetRowCellValue(i, "Id_factura").ToString() != "")
                        {
                            cliente_cuenta_corriente.id_factura = Convert.ToInt32(gridView1.GetRowCellValue(i, "Id_factura").ToString());
                        }

                        cliente_cuenta_corriente.fecha_factura_vieja = null;
                        if (gridView1.GetRowCellValue(i, "Fecha").ToString() != "")
                        {
                            cliente_cuenta_corriente.fecha_factura_vieja = Convert.ToDateTime(gridView1.GetRowCellValue(i, "Fecha").ToString());
                        }


                        cliente_cuenta_corriente.nro_factura_vieja = null;
                        if (gridView1.GetRowCellValue(i, "Nro Factura").ToString() != "")
                        {
                            cliente_cuenta_corriente.nro_factura_vieja = Convert.ToInt64(gridView1.GetRowCellValue(i, "Nro Factura").ToString());
                        }

                        cliente_cuenta_corriente.cod_tipo_factura_vieja = null;
                        if (gridView1.GetRowCellValue(i, "Tipo Factura").ToString() != "")
                        {
                            if (gridView1.GetRowCellValue(i, "Tipo Factura").ToString() == valor_remito)
                            {
                                cliente_cuenta_corriente.cod_tipo_factura_vieja = 1;
                            }
                            else if (gridView1.GetRowCellValue(i, "Tipo Factura").ToString() == valor_nota_credito)
                            {
                                cliente_cuenta_corriente.cod_tipo_factura_vieja = 2;
                            }
                            else if (gridView1.GetRowCellValue(i, "Tipo Factura").ToString() == valor_nota_debito)
                            {
                                cliente_cuenta_corriente.cod_tipo_factura_vieja = 6;
                            }
                            else if (gridView1.GetRowCellValue(i, "Tipo Factura").ToString() == valor_factura_a)
                            {
                                cliente_cuenta_corriente.cod_tipo_factura_vieja = 7;
                            }
                            else if (gridView1.GetRowCellValue(i, "Tipo Factura").ToString() == valor_factura_b)
                            {
                                cliente_cuenta_corriente.cod_tipo_factura_vieja = 8;
                            }




                        }

                    }
                    else
                    {
                        cliente_cuenta_corriente.id_cliente_cuenta_corriente = Convert.ToInt32(gridView1.GetRowCellValue(i, "Id").ToString());
                        cliente_cuenta_corriente.id_cliente = cliente.id_cliente;
                        cliente_cuenta_corriente.id_factura = Convert.ToInt32(gridView1.GetRowCellValue(i, "Id_factura").ToString());

                        cliente_cuenta_corriente.fecha_factura_vieja = null;
                        cliente_cuenta_corriente.nro_factura_vieja = null;
                        cliente_cuenta_corriente.cod_tipo_factura_vieja = null;
                    }

                    cliente_cuenta_corriente.imp_factura = null;
                    if (gridView1.GetRowCellValue(i, "Imp Factura").ToString() != "")
                    {
                        cliente_cuenta_corriente.imp_factura = Convert.ToDecimal(gridView1.GetRowCellValue(i, "Imp Factura").ToString());
                    }

                    cliente_cuenta_corriente.pago_1 = null;
                    if (gridView1.GetRowCellValue(i, "Pago 1").ToString() != "")
                    {
                        cliente_cuenta_corriente.pago_1 = Convert.ToDecimal(gridView1.GetRowCellValue(i, "Pago 1").ToString());
                    }

                    cliente_cuenta_corriente.pago_1_fecha = null;
                    if (gridView1.GetRowCellValue(i, "Fecha Pago 1").ToString() != "")
                    {
                        cliente_cuenta_corriente.pago_1_fecha = Convert.ToDateTime(gridView1.GetRowCellValue(i, "Fecha Pago 1").ToString());
                    }


                    cliente_cuenta_corriente.pago_2 = null;
                    if (gridView1.GetRowCellValue(i, "Pago 2").ToString() != "")
                    {
                        cliente_cuenta_corriente.pago_2 = Convert.ToDecimal(gridView1.GetRowCellValue(i, "Pago 2").ToString());
                    }

                    cliente_cuenta_corriente.pago_2_fecha = null;
                    if (gridView1.GetRowCellValue(i, "Fecha Pago 2").ToString() != "")
                    {
                        cliente_cuenta_corriente.pago_2_fecha = Convert.ToDateTime(gridView1.GetRowCellValue(i, "Fecha Pago 2").ToString());
                    }

                    cliente_cuenta_corriente.pago_3 = null;
                    if (gridView1.GetRowCellValue(i, "Pago 3").ToString() != "")
                    {
                        cliente_cuenta_corriente.pago_3 = Convert.ToDecimal(gridView1.GetRowCellValue(i, "Pago 3").ToString());
                    }

                    cliente_cuenta_corriente.pago_3_fecha = null;
                    if (gridView1.GetRowCellValue(i, "Fecha Pago 3").ToString() != "")
                    {
                        cliente_cuenta_corriente.pago_3_fecha = Convert.ToDateTime(gridView1.GetRowCellValue(i, "Fecha Pago 3").ToString());
                    }


                    cliente_cuenta_corriente.pago_4 = null;
                    if (gridView1.GetRowCellValue(i, "Pago 4").ToString() != "")
                    {
                        cliente_cuenta_corriente.pago_4 = Convert.ToDecimal(gridView1.GetRowCellValue(i, "Pago 4").ToString());
                    }

                    cliente_cuenta_corriente.pago_4_fecha = null;
                    if (gridView1.GetRowCellValue(i, "Fecha Pago 4").ToString() != "")
                    {
                        cliente_cuenta_corriente.pago_4_fecha = Convert.ToDateTime(gridView1.GetRowCellValue(i, "Fecha Pago 4").ToString());
                    }

                    cliente_cuenta_corriente.observacion = gridView1.GetRowCellValue(i, "Observacion Movimiento Cta Cte").ToString();

                    lista_cliente_cuenta_corriente.Add(cliente_cuenta_corriente);

                }


                if (logica_cliente_cuenta_corriente.modificar_movimientos_cuenta_corriente(lista_cliente_cuenta_corriente) == false)
                {
                    throw new Exception("Error al actualizar cuenta corriente");
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Actualizacíon correcta", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    cargar_gridControl();

                    gridView1.Columns["Fecha"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                }


            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void btnAgregarMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                gridView1.AddNewRow();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.RowCount > 0)
                {
                    string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Id").ToString(); //es es el id_cliente_cuenta_corriente
                    string id_factura = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Id_factura").ToString();

                    if (id_factura == "") //si no tiene id_factura , la puedo eliminar ya que no fue cargada en mi sistema
                    {
                        if (id != "")
                        {
                            int id_cliente_cuenta_corriente = Convert.ToInt32(id);
                            if (logica_cliente_cuenta_corriente.eliminar_movimiento_cuenta_corriente(id_cliente_cuenta_corriente) == false)
                            {
                                throw new Exception("Error al eliminar el movimiento de la cuenta corriente");
                            }

                        }
                        gridView1.DeleteRow(gridView1.FocusedRowHandle);
                        gridView1.Columns["Fecha"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        //gridControl1.DataSource = null;
                        //gridControl1.DataSource = logica_cliente_cuenta_corriente.buscar_movimientos_cuenta_corriente_por_id_cliente(cliente.id_cliente).Tables[0]; //cargo en gridControl1
                    }
                    else
                    {
                        throw new Exception("No se puede eliminar una factura ya generada en el sistema");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
        {
            try
            {
                string id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Id").ToString();
                string tipo_factura = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Tipo Factura").ToString();
                string fecha = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Fecha").ToString();

                if (id != "" && gridView1.FocusedColumn.FieldName == "Id")
                {
                    e.Cancel = true;
                }
                else if (id != "" && gridView1.FocusedColumn.FieldName == "Id_factura")
                {
                    e.Cancel = true;
                }
                else if (id != "" && gridView1.FocusedColumn.FieldName == "Fecha")
                {
                    e.Cancel = true;
                }
                else if (id != "" && gridView1.FocusedColumn.FieldName == "Tipo Factura")
                {
                    e.Cancel = true;
                }
                else if (id != "" && gridView1.FocusedColumn.FieldName == "Nro Factura")
                {
                    e.Cancel = true;
                }
                else if (id != "" && gridView1.FocusedColumn.FieldName == "Imp Factura" && tipo_factura == valor_remito) //NO VOY A PODER MODIFICAR "Imp Factura" SI EL TIPO DE FACTURA ES "REMITO" , PARA LOS DEMAS SI
                {
                    e.Cancel = true;
                }

                if (tipo_factura == "" && gridView1.FocusedColumn.FieldName == "Nro Factura" && fecha != "")
                {
                    e.Cancel = true;
                    throw new Exception("Debe seleccionar un tipo de factura antes de cargar el número de la misma");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCliente_Cuenta_Corriente_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdDeuda_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                cargar_gridControl();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cargar_gridControl();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargar_gridControl()
        {
            try
            {
                int tipo;
                if (rdDeuda.Checked == true)
                {
                    tipo = 1;
                }
                else
                {
                    tipo = 2;
                }

                gridControl1.DataSource = null;
                gridControl1.DataSource = logica_cliente_cuenta_corriente.buscar_movimientos_cuenta_corriente_por_id_cliente(cliente.id_cliente, tipo).Tables[0]; //cargo en gridControl1
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private void gridControl1_EditorKeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {
                GridControl grid = sender as GridControl;
                gridView1_KeyPress(grid.FocusedView, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //funcion que indica que "," y "." es lo mismo
        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.FocusedColumn.FieldName == "Imp Factura" || view.FocusedColumn.FieldName == "Pago 1" || view.FocusedColumn.FieldName == "Pago 2" || view.FocusedColumn.FieldName == "Pago 3" || view.FocusedColumn.FieldName == "Pago 4")
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
