namespace Modulo_Administracion
{
    partial class frmCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.tabCliente = new System.Windows.Forms.TabControl();
            this.tabPageCliente = new System.Windows.Forms.TabPage();
            this.rdVendedor = new System.Windows.Forms.RadioButton();
            this.rdCliente = new System.Windows.Forms.RadioButton();
            this.cbVendedor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cbCondicionFactura = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipoCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNomre = new System.Windows.Forms.Label();
            this.txtRazonSocial_Cliente = new System.Windows.Forms.TextBox();
            this.cbCondicionPago = new System.Windows.Forms.ComboBox();
            this.cbCondicionIVA = new System.Windows.Forms.ComboBox();
            this.lblCondicionPago = new System.Windows.Forms.Label();
            this.lblCondicionIVA = new System.Windows.Forms.Label();
            this.btnCliente_Direccion = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelarSeleccion = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvCliente = new System.Windows.Forms.DataGridView();
            this.btnCliente_Datos = new System.Windows.Forms.Button();
            this.btnCliente_CtaCorriente = new System.Windows.Forms.Button();
            this.lblRazonSocial_Cliente = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtNombreFantasia = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnNuevo = new System.Windows.Forms.Button();
            this.tabCliente.SuspendLayout();
            this.tabPageCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
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
            // tabCliente
            // 
            this.tabCliente.Controls.Add(this.tabPageCliente);
            this.tabCliente.Location = new System.Drawing.Point(12, 26);
            this.tabCliente.Name = "tabCliente";
            this.tabCliente.SelectedIndex = 0;
            this.tabCliente.Size = new System.Drawing.Size(1143, 476);
            this.tabCliente.TabIndex = 0;
            // 
            // tabPageCliente
            // 
            this.tabPageCliente.Controls.Add(this.rdVendedor);
            this.tabPageCliente.Controls.Add(this.rdCliente);
            this.tabPageCliente.Controls.Add(this.cbVendedor);
            this.tabPageCliente.Controls.Add(this.label4);
            this.tabPageCliente.Controls.Add(this.label3);
            this.tabPageCliente.Controls.Add(this.txtBusqueda);
            this.tabPageCliente.Controls.Add(this.cbCondicionFactura);
            this.tabPageCliente.Controls.Add(this.label2);
            this.tabPageCliente.Controls.Add(this.cbTipoCliente);
            this.tabPageCliente.Controls.Add(this.label1);
            this.tabPageCliente.Controls.Add(this.lblNomre);
            this.tabPageCliente.Controls.Add(this.txtRazonSocial_Cliente);
            this.tabPageCliente.Controls.Add(this.cbCondicionPago);
            this.tabPageCliente.Controls.Add(this.cbCondicionIVA);
            this.tabPageCliente.Controls.Add(this.lblCondicionPago);
            this.tabPageCliente.Controls.Add(this.lblCondicionIVA);
            this.tabPageCliente.Controls.Add(this.btnCliente_Direccion);
            this.tabPageCliente.Controls.Add(this.btnEliminar);
            this.tabPageCliente.Controls.Add(this.btnCancelarSeleccion);
            this.tabPageCliente.Controls.Add(this.btnAgregar);
            this.tabPageCliente.Controls.Add(this.dgvCliente);
            this.tabPageCliente.Controls.Add(this.btnCliente_Datos);
            this.tabPageCliente.Controls.Add(this.btnCliente_CtaCorriente);
            this.tabPageCliente.Controls.Add(this.lblRazonSocial_Cliente);
            this.tabPageCliente.Controls.Add(this.lblCodigo);
            this.tabPageCliente.Controls.Add(this.txtNombreFantasia);
            this.tabPageCliente.Controls.Add(this.txtCodigo);
            this.tabPageCliente.Location = new System.Drawing.Point(4, 25);
            this.tabPageCliente.Name = "tabPageCliente";
            this.tabPageCliente.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCliente.Size = new System.Drawing.Size(1135, 447);
            this.tabPageCliente.TabIndex = 0;
            this.tabPageCliente.Text = "Cliente";
            this.tabPageCliente.UseVisualStyleBackColor = true;
            // 
            // rdVendedor
            // 
            this.rdVendedor.AutoSize = true;
            this.rdVendedor.Location = new System.Drawing.Point(914, 53);
            this.rdVendedor.Name = "rdVendedor";
            this.rdVendedor.Size = new System.Drawing.Size(151, 21);
            this.rdVendedor.TabIndex = 30;
            this.rdVendedor.TabStop = true;
            this.rdVendedor.Text = "Filtro por Vendedor";
            this.rdVendedor.UseVisualStyleBackColor = true;
            this.rdVendedor.CheckedChanged += new System.EventHandler(this.rdVendedor_CheckedChanged);
            // 
            // rdCliente
            // 
            this.rdCliente.AutoSize = true;
            this.rdCliente.Location = new System.Drawing.Point(716, 55);
            this.rdCliente.Name = "rdCliente";
            this.rdCliente.Size = new System.Drawing.Size(132, 21);
            this.rdCliente.TabIndex = 29;
            this.rdCliente.TabStop = true;
            this.rdCliente.Text = "Filtro por Cliente";
            this.rdCliente.UseVisualStyleBackColor = true;
            this.rdCliente.CheckedChanged += new System.EventHandler(this.rdCliente_CheckedChanged);
            // 
            // cbVendedor
            // 
            this.cbVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVendedor.FormattingEnabled = true;
            this.cbVendedor.Location = new System.Drawing.Point(152, 232);
            this.cbVendedor.Name = "cbVendedor";
            this.cbVendedor.Size = new System.Drawing.Size(280, 24);
            this.cbVendedor.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Vendedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(848, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 26;
            this.label3.Text = "Filtro";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(683, 27);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(393, 22);
            this.txtBusqueda.TabIndex = 25;
            this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
            // 
            // cbCondicionFactura
            // 
            this.cbCondicionFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondicionFactura.FormattingEnabled = true;
            this.cbCondicionFactura.Location = new System.Drawing.Point(152, 196);
            this.cbCondicionFactura.Name = "cbCondicionFactura";
            this.cbCondicionFactura.Size = new System.Drawing.Size(280, 24);
            this.cbCondicionFactura.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Condicion Factura";
            // 
            // cbTipoCliente
            // 
            this.cbTipoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCliente.FormattingEnabled = true;
            this.cbTipoCliente.Location = new System.Drawing.Point(152, 166);
            this.cbTipoCliente.Name = "cbTipoCliente";
            this.cbTipoCliente.Size = new System.Drawing.Size(280, 24);
            this.cbTipoCliente.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Tipo Cliente";
            // 
            // lblNomre
            // 
            this.lblNomre.AutoSize = true;
            this.lblNomre.Location = new System.Drawing.Point(24, 55);
            this.lblNomre.Name = "lblNomre";
            this.lblNomre.Size = new System.Drawing.Size(58, 17);
            this.lblNomre.TabIndex = 20;
            this.lblNomre.Text = "Nombre";
            // 
            // txtRazonSocial_Cliente
            // 
            this.txtRazonSocial_Cliente.Location = new System.Drawing.Point(152, 78);
            this.txtRazonSocial_Cliente.Name = "txtRazonSocial_Cliente";
            this.txtRazonSocial_Cliente.Size = new System.Drawing.Size(393, 22);
            this.txtRazonSocial_Cliente.TabIndex = 19;
            this.txtRazonSocial_Cliente.Leave += new System.EventHandler(this.txtRazonSocial_Cliente_Leave);
            // 
            // cbCondicionPago
            // 
            this.cbCondicionPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondicionPago.FormattingEnabled = true;
            this.cbCondicionPago.Location = new System.Drawing.Point(152, 136);
            this.cbCondicionPago.Name = "cbCondicionPago";
            this.cbCondicionPago.Size = new System.Drawing.Size(280, 24);
            this.cbCondicionPago.TabIndex = 18;
            // 
            // cbCondicionIVA
            // 
            this.cbCondicionIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCondicionIVA.FormattingEnabled = true;
            this.cbCondicionIVA.Location = new System.Drawing.Point(152, 106);
            this.cbCondicionIVA.Name = "cbCondicionIVA";
            this.cbCondicionIVA.Size = new System.Drawing.Size(280, 24);
            this.cbCondicionIVA.TabIndex = 17;
            // 
            // lblCondicionPago
            // 
            this.lblCondicionPago.AutoSize = true;
            this.lblCondicionPago.Location = new System.Drawing.Point(24, 143);
            this.lblCondicionPago.Name = "lblCondicionPago";
            this.lblCondicionPago.Size = new System.Drawing.Size(107, 17);
            this.lblCondicionPago.TabIndex = 16;
            this.lblCondicionPago.Text = "Condicion Pago";
            // 
            // lblCondicionIVA
            // 
            this.lblCondicionIVA.AutoSize = true;
            this.lblCondicionIVA.Location = new System.Drawing.Point(23, 113);
            this.lblCondicionIVA.Name = "lblCondicionIVA";
            this.lblCondicionIVA.Size = new System.Drawing.Size(95, 17);
            this.lblCondicionIVA.TabIndex = 14;
            this.lblCondicionIVA.Text = "Condicion IVA";
            // 
            // btnCliente_Direccion
            // 
            this.btnCliente_Direccion.BackColor = System.Drawing.Color.Firebrick;
            this.btnCliente_Direccion.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCliente_Direccion.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnCliente_Direccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnCliente_Direccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCliente_Direccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente_Direccion.ForeColor = System.Drawing.Color.White;
            this.btnCliente_Direccion.Location = new System.Drawing.Point(144, 291);
            this.btnCliente_Direccion.Name = "btnCliente_Direccion";
            this.btnCliente_Direccion.Size = new System.Drawing.Size(107, 42);
            this.btnCliente_Direccion.TabIndex = 12;
            this.btnCliente_Direccion.Text = "Dirección";
            this.btnCliente_Direccion.UseVisualStyleBackColor = false;
            this.btnCliente_Direccion.Click += new System.EventHandler(this.btnCliente_Direccion_Click);
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
            // dgvCliente
            // 
            this.dgvCliente.AllowUserToAddRows = false;
            this.dgvCliente.AllowUserToDeleteRows = false;
            this.dgvCliente.AllowUserToOrderColumns = true;
            this.dgvCliente.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.IndianRed;
            this.dgvCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCliente.GridColor = System.Drawing.Color.White;
            this.dgvCliente.Location = new System.Drawing.Point(601, 81);
            this.dgvCliente.MultiSelect = false;
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.ReadOnly = true;
            this.dgvCliente.RowHeadersVisible = false;
            this.dgvCliente.RowHeadersWidth = 51;
            this.dgvCliente.RowTemplate.Height = 24;
            this.dgvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCliente.Size = new System.Drawing.Size(525, 302);
            this.dgvCliente.TabIndex = 7;
            this.dgvCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCliente_CellClick);
            // 
            // btnCliente_Datos
            // 
            this.btnCliente_Datos.BackColor = System.Drawing.Color.Firebrick;
            this.btnCliente_Datos.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCliente_Datos.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnCliente_Datos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnCliente_Datos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCliente_Datos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente_Datos.ForeColor = System.Drawing.Color.White;
            this.btnCliente_Datos.Location = new System.Drawing.Point(24, 291);
            this.btnCliente_Datos.Name = "btnCliente_Datos";
            this.btnCliente_Datos.Size = new System.Drawing.Size(107, 42);
            this.btnCliente_Datos.TabIndex = 6;
            this.btnCliente_Datos.Text = "Datos";
            this.btnCliente_Datos.UseVisualStyleBackColor = false;
            this.btnCliente_Datos.Click += new System.EventHandler(this.btnCliente_Datos_Click);
            // 
            // btnCliente_CtaCorriente
            // 
            this.btnCliente_CtaCorriente.BackColor = System.Drawing.Color.Firebrick;
            this.btnCliente_CtaCorriente.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCliente_CtaCorriente.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnCliente_CtaCorriente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnCliente_CtaCorriente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCliente_CtaCorriente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente_CtaCorriente.ForeColor = System.Drawing.Color.White;
            this.btnCliente_CtaCorriente.Location = new System.Drawing.Point(266, 291);
            this.btnCliente_CtaCorriente.Name = "btnCliente_CtaCorriente";
            this.btnCliente_CtaCorriente.Size = new System.Drawing.Size(119, 42);
            this.btnCliente_CtaCorriente.TabIndex = 5;
            this.btnCliente_CtaCorriente.Text = "Cta. Corriente";
            this.btnCliente_CtaCorriente.UseVisualStyleBackColor = false;
            this.btnCliente_CtaCorriente.Click += new System.EventHandler(this.btnCliente_CtaCorriente_Click);
            // 
            // lblRazonSocial_Cliente
            // 
            this.lblRazonSocial_Cliente.AutoSize = true;
            this.lblRazonSocial_Cliente.Location = new System.Drawing.Point(24, 81);
            this.lblRazonSocial_Cliente.Name = "lblRazonSocial_Cliente";
            this.lblRazonSocial_Cliente.Size = new System.Drawing.Size(91, 17);
            this.lblRazonSocial_Cliente.TabIndex = 11;
            this.lblRazonSocial_Cliente.Text = "Razon Social";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(24, 27);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(52, 17);
            this.lblCodigo.TabIndex = 10;
            this.lblCodigo.Text = "Código";
            // 
            // txtNombreFantasia
            // 
            this.txtNombreFantasia.Location = new System.Drawing.Point(152, 50);
            this.txtNombreFantasia.Name = "txtNombreFantasia";
            this.txtNombreFantasia.Size = new System.Drawing.Size(393, 22);
            this.txtNombreFantasia.TabIndex = 2;
            this.txtNombreFantasia.Leave += new System.EventHandler(this.txtNombreFantasia_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(152, 22);
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
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 563);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.tabCliente);
            this.Controls.Add(this.webBrowser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.tabCliente.ResumeLayout(false);
            this.tabPageCliente.ResumeLayout(false);
            this.tabPageCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TabControl tabCliente;
        private System.Windows.Forms.TabPage tabPageCliente;
        private System.Windows.Forms.Button btnCliente_Datos;
        private System.Windows.Forms.Button btnCliente_CtaCorriente;
        private System.Windows.Forms.Label lblRazonSocial_Cliente;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtNombreFantasia;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView dgvCliente;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelarSeleccion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCliente_Direccion;
        private System.Windows.Forms.Label lblNomre;
        private System.Windows.Forms.TextBox txtRazonSocial_Cliente;
        private System.Windows.Forms.ComboBox cbCondicionPago;
        private System.Windows.Forms.ComboBox cbCondicionIVA;
        private System.Windows.Forms.Label lblCondicionPago;
        private System.Windows.Forms.Label lblCondicionIVA;
        private System.Windows.Forms.ComboBox cbCondicionFactura;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipoCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbVendedor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdVendedor;
        private System.Windows.Forms.RadioButton rdCliente;
    }
}


