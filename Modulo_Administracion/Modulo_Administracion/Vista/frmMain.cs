using System;
using System.Windows.Forms;

namespace Modulo_Administracion.Vista
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAdminProveedor_Click(object sender, EventArgs e)
        {

            try
            {
                frmProveedor proveedor = new frmProveedor();
                proveedor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMaestroMarca_Click(object sender, EventArgs e)
        {
            try
            {
                frmMarca marca = new frmMarca(null);
                marca.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMaestroFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                frmFamilia familia = new frmFamilia(null);
                familia.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnMaestroArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                frmArticulo articulo = new frmArticulo(null);
                articulo.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnImportarExcel_Click(object sender, EventArgs e)
        {
            try
            {
                frmImportarExcel importar_excel = new frmImportarExcel();
                importar_excel.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {
                frmCliente form = new frmCliente(null);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGestionFacturas_Click(object sender, EventArgs e)
        {
            try
            {

                frmFacturaGestion form = new frmFacturaGestion();
                form.ParentForm = this;
                form.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImportarExcelProveedor_Click(object sender, EventArgs e)
        {
            frmImportarExcelProveedor form = new frmImportarExcelProveedor();
            form.Show();
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {


                frmFactura form = new frmFactura(null);
                form.ParentForm = this;
                form.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFacturarAFIP_Click(object sender, EventArgs e)
        {
            try
            {


                frmFacturaAFIP form = new frmFacturaAFIP(null);
                form.ParentForm = this;
                form.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVendedor_Click(object sender, EventArgs e)
        {
            try
            {
                frmVendedor form = new frmVendedor();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
