using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using Microsoft.VisualBasic;
using System.Data;
using System.Windows.Forms;

namespace Modulo_Administracion
{
    public partial class frmPassword : Form
    {

        public DataTable AuxDt; // Aca tengo q usarlo para filtrar cantidad de datos
        public int row_select;
        public frmPassword()
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



        private void btnAceptar_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                if (txtPassword.Text == Program.password)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    throw new Exception("Password incorrecto");
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnBorrar_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                txtPassword.Text = "";
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void btnSalir_Click(System.Object sender, System.EventArgs e)
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

    }
}