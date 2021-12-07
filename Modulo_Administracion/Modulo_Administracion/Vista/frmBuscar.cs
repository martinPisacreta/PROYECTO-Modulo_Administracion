using System;
using System.Data;
using System.Windows.Forms;

namespace Modulo_Administracion
{
    public partial class frmBuscar : Form
    {

        public DataTable AuxDt; // Aca tengo q usarlo para filtrar cantidad de datos
        public int row_select;
        public frmBuscar()
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


        public void IniciarForm(DataTable dt, int de_donde_vengo)
        {

            try
            {

                AuxDt = dt;
                dgvResultados.DataSource = AuxDt;
                dgvResultados.Columns[0].Visible = false;

                if (de_donde_vengo == 1) //si vengo aca desde frmFactura
                {
                    if (dgvResultados.Columns.Count > 2)
                        dgvResultados.Columns[2].Visible = false; //oculto la columna 2
                }
                else //si vengo desde otro formulario
                {
                    if (dgvResultados.Columns.Count > 2)
                        dgvResultados.Columns[2].Visible = true; //muestro la columna 2
                }


                lblRegistros.Text = "Registros: " + dgvResultados.RowCount;
                if (dgvResultados.RowCount < 1) // si no hay resultados , bloqueo el aceptar
                    btnAceptar.Enabled = false;
                if (dgvResultados.RowCount == 1)  // si hay un solo resultado , no muestro la grilla 
                {
                    dgvResultados.Rows[0].Selected = true;
                    row_select = dgvResultados.SelectedRows[0].Index;
                    this.DialogResult = DialogResult.OK;
                    return;
                }
                AcceptButton = btnAceptar;
                CancelButton = btnCancelar;


                this.ShowDialog();
            }
            catch (Exception ex)
            {

                throw ex;
            }



        }

        private void btnAceptar_Click(System.Object sender, System.EventArgs e)
        {

            try
            {

                row_select = dgvResultados.SelectedRows[0].Index;
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnCancelar_Click(System.Object sender, System.EventArgs e)
        {

            try
            {

                this.DialogResult = DialogResult.Cancel;

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnNuevo_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                this.DialogResult = DialogResult.Yes;

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void dgvResultados_CellDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            try
            {
                row_select = dgvResultados.SelectedRows[0].Index;
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


        private void dgvResultados_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {

            try
            {
                if (e.KeyCode == Keys.Enter)
                    this.DialogResult = DialogResult.OK;

            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }


    }
}