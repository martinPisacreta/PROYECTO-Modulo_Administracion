namespace Modulo_Administracion
{
    partial class frmProveedor
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabProveedor = new System.Windows.Forms.TabControl();
            this.tabPageProveedor = new System.Windows.Forms.TabPage();
            this.cbCondicionPago = new System.Windows.Forms.ComboBox();
            this.cbCondicionIVA = new System.Windows.Forms.ComboBox();
            this.lblCondicionPago = new System.Windows.Forms.Label();
            this.lblCondicionIVA = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelarSeleccion = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            this.btnProveedor_Datos = new System.Windows.Forms.Button();
            this.btnProveedor_Direccion = new System.Windows.Forms.Button();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.tabProveedor.SuspendLayout();
            this.tabPageProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1167, 563);
            this.webBrowser1.TabIndex = 0;
            // 
            // tabProveedor
            // 
            this.tabProveedor.Controls.Add(this.tabPageProveedor);
            this.tabProveedor.Location = new System.Drawing.Point(12, 26);
            this.tabProveedor.Name = "tabProveedor";
            this.tabProveedor.SelectedIndex = 0;
            this.tabProveedor.Size = new System.Drawing.Size(1143, 476);
            this.tabProveedor.TabIndex = 0;
            // 
            // tabPageProveedor
            // 
            this.tabPageProveedor.Controls.Add(this.label3);
            this.tabPageProveedor.Controls.Add(this.txtBusqueda);
            this.tabPageProveedor.Controls.Add(this.cbCondicionPago);
            this.tabPageProveedor.Controls.Add(this.cbCondicionIVA);
            this.tabPageProveedor.Controls.Add(this.lblCondicionPago);
            this.tabPageProveedor.Controls.Add(this.lblCondicionIVA);
            this.tabPageProveedor.Controls.Add(this.btnEliminar);
            this.tabPageProveedor.Controls.Add(this.btnCancelarSeleccion);
            this.tabPageProveedor.Controls.Add(this.btnAgregar);
            this.tabPageProveedor.Controls.Add(this.dgvProveedor);
            this.tabPageProveedor.Controls.Add(this.btnProveedor_Datos);
            this.tabPageProveedor.Controls.Add(this.btnProveedor_Direccion);
            this.tabPageProveedor.Controls.Add(this.lblRazonSocial);
            this.tabPageProveedor.Controls.Add(this.lblCodigo);
            this.tabPageProveedor.Controls.Add(this.txtRazonSocial);
            this.tabPageProveedor.Controls.Add(this.txtCodigo);
            this.tabPageProveedor.Location = new System.Drawing.Point(4, 25);
            this.tabPageProveedor.Name = "tabPageProveedor";
            this.tabPageProveedor.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProveedor.Size = new System.Drawing.Size(1135, 447);
            this.tabPageProveedor.TabIndex = 0;
            this.tabPageProveedor.Text = "Proveedor";
            this.tabPageProveedor.UseVisualStyleBackColor = true;
            // 
            // cbCondicionPago
            // 
            this.cbCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondicionPago.FormattingEnabled = true;
            this.cbCondicionPago.Location = new System.Drawing.Point(144, 113);
            this.cbCondicionPago.Name = "cbCondicionPago";
            this.cbCondicionPago.Size = new System.Drawing.Size(280, 24);
            this.cbCondicionPago.TabIndex = 22;
            // 
            // cbCondicionIVA
            // 
            this.cbCondicionIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondicionIVA.FormattingEnabled = true;
            this.cbCondicionIVA.Location = new System.Drawing.Point(144, 83);
            this.cbCondicionIVA.Name = "cbCondicionIVA";
            this.cbCondicionIVA.Size = new System.Drawing.Size(280, 24);
            this.cbCondicionIVA.TabIndex = 21;
            // 
            // lblCondicionPago
            // 
            this.lblCondicionPago.AutoSize = true;
            this.lblCondicionPago.Location = new System.Drawing.Point(24, 120);
            this.lblCondicionPago.Name = "lblCondicionPago";
            this.lblCondicionPago.Size = new System.Drawing.Size(107, 17);
            this.lblCondicionPago.TabIndex = 20;
            this.lblCondicionPago.Text = "Condicion Pago";
            // 
            // lblCondicionIVA
            // 
            this.lblCondicionIVA.AutoSize = true;
            this.lblCondicionIVA.Location = new System.Drawing.Point(23, 90);
            this.lblCondicionIVA.Name = "lblCondicionIVA";
            this.lblCondicionIVA.Size = new System.Drawing.Size(95, 17);
            this.lblCondicionIVA.TabIndex = 19;
            this.lblCondicionIVA.Text = "Condicion IVA";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnEliminar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(716, 398);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(107, 42);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelarSeleccion
            // 
            this.btnCancelarSeleccion.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelarSeleccion.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCancelarSeleccion.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarSeleccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarSeleccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarSeleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarSeleccion.ForeColor = System.Drawing.Color.White;
            this.btnCancelarSeleccion.Location = new System.Drawing.Point(831, 398);
            this.btnCancelarSeleccion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarSeleccion.Name = "btnCancelarSeleccion";
            this.btnCancelarSeleccion.Size = new System.Drawing.Size(107, 42);
            this.btnCancelarSeleccion.TabIndex = 9;
            this.btnCancelarSeleccion.Text = "Cancelar";
            this.btnCancelarSeleccion.UseVisualStyleBackColor = false;
            this.btnCancelarSeleccion.Click += new System.EventHandler(this.btnCancelarSeleccion_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Firebrick;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnAgregar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(601, 398);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 42);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.AllowUserToAddRows = false;
            this.dgvProveedor.AllowUserToDeleteRows = false;
            this.dgvProveedor.AllowUserToOrderColumns = true;
            this.dgvProveedor.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.IndianRed;
            this.dgvProveedor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.GridColor = System.Drawing.Color.White;
            this.dgvProveedor.Location = new System.Drawing.Point(601, 55);
            this.dgvProveedor.MultiSelect = false;
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.ReadOnly = true;
            this.dgvProveedor.RowHeadersVisible = false;
            this.dgvProveedor.RowHeadersWidth = 51;
            this.dgvProveedor.RowTemplate.Height = 24;
            this.dgvProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedor.Size = new System.Drawing.Size(525, 328);
            this.dgvProveedor.TabIndex = 7;
            this.dgvProveedor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedor_CellClick);
            this.dgvProveedor.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProveedor_CellDoubleClick);
            // 
            // btnProveedor_Datos
            // 
            this.btnProveedor_Datos.BackColor = System.Drawing.Color.Firebrick;
            this.btnProveedor_Datos.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnProveedor_Datos.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnProveedor_Datos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnProveedor_Datos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnProveedor_Datos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedor_Datos.ForeColor = System.Drawing.Color.White;
            this.btnProveedor_Datos.Location = new System.Drawing.Point(153, 169);
            this.btnProveedor_Datos.Name = "btnProveedor_Datos";
            this.btnProveedor_Datos.Size = new System.Drawing.Size(107, 42);
            this.btnProveedor_Datos.TabIndex = 6;
            this.btnProveedor_Datos.Text = "Datos";
            this.btnProveedor_Datos.UseVisualStyleBackColor = false;
            this.btnProveedor_Datos.Click += new System.EventHandler(this.btnProveedor_Datos_Click);
            // 
            // btnProveedor_Direccion
            // 
            this.btnProveedor_Direccion.BackColor = System.Drawing.Color.Firebrick;
            this.btnProveedor_Direccion.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnProveedor_Direccion.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnProveedor_Direccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnProveedor_Direccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnProveedor_Direccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedor_Direccion.ForeColor = System.Drawing.Color.White;
            this.btnProveedor_Direccion.Location = new System.Drawing.Point(24, 169);
            this.btnProveedor_Direccion.Name = "btnProveedor_Direccion";
            this.btnProveedor_Direccion.Size = new System.Drawing.Size(107, 42);
            this.btnProveedor_Direccion.TabIndex = 5;
            this.btnProveedor_Direccion.Text = "Dirección";
            this.btnProveedor_Direccion.UseVisualStyleBackColor = false;
            this.btnProveedor_Direccion.Click += new System.EventHandler(this.btnProveedor_Direccion_Click);
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Location = new System.Drawing.Point(23, 53);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(91, 17);
            this.lblRazonSocial.TabIndex = 11;
            this.lblRazonSocial.Text = "Razon Social";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(23, 22);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 10;
            this.lblCodigo.Text = "Código";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(144, 50);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(393, 22);
            this.txtRazonSocial.TabIndex = 2;
            this.txtRazonSocial.Leave += new System.EventHandler(this.txtRazonSocial_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(144, 22);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(88, 22);
            this.txtCodigo.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Firebrick;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(1022, 510);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 43);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.Firebrick;
            this.btnNuevo.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnNuevo.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(30, 511);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(107, 42);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(854, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 28;
            this.label3.Text = "Filtro";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(689, 27);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(393, 22);
            this.txtBusqueda.TabIndex = 27;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // frmProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 563);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tabProveedor);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedor";
            this.Load += new System.EventHandler(this.frmProveedor_Load);
            this.tabProveedor.ResumeLayout(false);
            this.tabPageProveedor.ResumeLayout(false);
            this.tabPageProveedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabControl tabProveedor;
        private System.Windows.Forms.TabPage tabPageProveedor;
        private System.Windows.Forms.Button btnProveedor_Datos;
        private System.Windows.Forms.Button btnProveedor_Direccion;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvProveedor;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelarSeleccion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ComboBox cbCondicionPago;
        private System.Windows.Forms.ComboBox cbCondicionIVA;
        private System.Windows.Forms.Label lblCondicionPago;
        private System.Windows.Forms.Label lblCondicionIVA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBusqueda;
    }
}


