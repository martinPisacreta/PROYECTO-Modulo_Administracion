namespace Modulo_Administracion.Vista
{
    partial class frmFacturaGestion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelBusqueda2 = new System.Windows.Forms.Panel();
            this.btnCancelarFiltro = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtClienteId = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTipoFactura = new System.Windows.Forms.ComboBox();
            this.lblFechaHasta = new System.Windows.Forms.Label();
            this.lblFechaDesde = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.lblNroFactura = new System.Windows.Forms.Label();
            this.txtFechaHasta = new System.Windows.Forms.TextBox();
            this.txtFechaDesde = new System.Windows.Forms.TextBox();
            this.txtCodigo_articulo_marca = new System.Windows.Forms.TextBox();
            this.txtCodigo_articulo = new System.Windows.Forms.TextBox();
            this.txtNroFactura = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.rdBusqueda1 = new System.Windows.Forms.RadioButton();
            this.rdBusqueda2 = new System.Windows.Forms.RadioButton();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label20 = new System.Windows.Forms.Label();
            this.cbImpresoras = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNroCopias = new System.Windows.Forms.TextBox();
            this.btnEliminarFactura = new System.Windows.Forms.Button();
            this.btnDropDownButton = new DevExpress.XtraEditors.DropDownButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.panelBusqueda2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.AllowUserToResizeRows = false;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column3,
            this.Column6,
            this.Column4,
            this.Column7,
            this.Column9,
            this.Column8});
            this.dgvFacturas.Location = new System.Drawing.Point(13, 348);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.RowHeadersWidth = 51;
            this.dgvFacturas.RowTemplate.Height = 24;
            this.dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas.Size = new System.Drawing.Size(1180, 304);
            this.dgvFacturas.TabIndex = 11;
            this.dgvFacturas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFacturas_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id Factura";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tipo Factura";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nro Factura";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Fecha";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Cliente";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Importe";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Observación";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 125;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Emitida";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Id Tipo Factura";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            this.Column8.Width = 125;
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
            this.btnSalir.Location = new System.Drawing.Point(1086, 680);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 43);
            this.btnSalir.TabIndex = 15;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panelBusqueda2
            // 
            this.panelBusqueda2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBusqueda2.Controls.Add(this.btnCancelarFiltro);
            this.panelBusqueda2.Controls.Add(this.label4);
            this.panelBusqueda2.Controls.Add(this.txtClienteId);
            this.panelBusqueda2.Controls.Add(this.txtCliente);
            this.panelBusqueda2.Controls.Add(this.label1);
            this.panelBusqueda2.Controls.Add(this.cbTipoFactura);
            this.panelBusqueda2.Controls.Add(this.lblFechaHasta);
            this.panelBusqueda2.Controls.Add(this.lblFechaDesde);
            this.panelBusqueda2.Controls.Add(this.lblMarca);
            this.panelBusqueda2.Controls.Add(this.lblArticulo);
            this.panelBusqueda2.Controls.Add(this.lblNroFactura);
            this.panelBusqueda2.Controls.Add(this.txtFechaHasta);
            this.panelBusqueda2.Controls.Add(this.txtFechaDesde);
            this.panelBusqueda2.Controls.Add(this.txtCodigo_articulo_marca);
            this.panelBusqueda2.Controls.Add(this.txtCodigo_articulo);
            this.panelBusqueda2.Controls.Add(this.txtNroFactura);
            this.panelBusqueda2.Controls.Add(this.btnBuscar);
            this.panelBusqueda2.Location = new System.Drawing.Point(553, 58);
            this.panelBusqueda2.Name = "panelBusqueda2";
            this.panelBusqueda2.Size = new System.Drawing.Size(570, 236);
            this.panelBusqueda2.TabIndex = 107;
            // 
            // btnCancelarFiltro
            // 
            this.btnCancelarFiltro.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelarFiltro.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCancelarFiltro.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarFiltro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarFiltro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarFiltro.ForeColor = System.Drawing.Color.White;
            this.btnCancelarFiltro.Location = new System.Drawing.Point(275, 183);
            this.btnCancelarFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarFiltro.Name = "btnCancelarFiltro";
            this.btnCancelarFiltro.Size = new System.Drawing.Size(107, 42);
            this.btnCancelarFiltro.TabIndex = 122;
            this.btnCancelarFiltro.Text = "Cancelar";
            this.btnCancelarFiltro.UseVisualStyleBackColor = false;
            this.btnCancelarFiltro.Click += new System.EventHandler(this.btnCancelarFiltro_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(350, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 119;
            this.label4.Text = "Cliente";
            // 
            // txtClienteId
            // 
            this.txtClienteId.Location = new System.Drawing.Point(562, 32);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.Size = new System.Drawing.Size(18, 22);
            this.txtClienteId.TabIndex = 121;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(353, 32);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(203, 22);
            this.txtCliente.TabIndex = 120;
            this.txtCliente.Leave += new System.EventHandler(this.txtCliente_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 117;
            this.label1.Text = "Tipo Factura";
            // 
            // cbTipoFactura
            // 
            this.cbTipoFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoFactura.FormattingEnabled = true;
            this.cbTipoFactura.Location = new System.Drawing.Point(12, 30);
            this.cbTipoFactura.Name = "cbTipoFactura";
            this.cbTipoFactura.Size = new System.Drawing.Size(208, 24);
            this.cbTipoFactura.TabIndex = 118;
            // 
            // lblFechaHasta
            // 
            this.lblFechaHasta.AutoSize = true;
            this.lblFechaHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHasta.Location = new System.Drawing.Point(231, 120);
            this.lblFechaHasta.Name = "lblFechaHasta";
            this.lblFechaHasta.Size = new System.Drawing.Size(99, 17);
            this.lblFechaHasta.TabIndex = 116;
            this.lblFechaHasta.Text = "Fecha Hasta";
            // 
            // lblFechaDesde
            // 
            this.lblFechaDesde.AutoSize = true;
            this.lblFechaDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaDesde.Location = new System.Drawing.Point(9, 120);
            this.lblFechaDesde.Name = "lblFechaDesde";
            this.lblFechaDesde.Size = new System.Drawing.Size(103, 17);
            this.lblFechaDesde.TabIndex = 115;
            this.lblFechaDesde.Text = "Fecha Desde";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMarca.Location = new System.Drawing.Point(231, 65);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(52, 17);
            this.lblMarca.TabIndex = 114;
            this.lblMarca.Text = "Marca";
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticulo.Location = new System.Drawing.Point(9, 65);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(63, 17);
            this.lblArticulo.TabIndex = 113;
            this.lblArticulo.Text = "Artículo";
            // 
            // lblNroFactura
            // 
            this.lblNroFactura.AutoSize = true;
            this.lblNroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNroFactura.Location = new System.Drawing.Point(228, 12);
            this.lblNroFactura.Name = "lblNroFactura";
            this.lblNroFactura.Size = new System.Drawing.Size(94, 17);
            this.lblNroFactura.TabIndex = 112;
            this.lblNroFactura.Text = "Nro Factura";
            // 
            // txtFechaHasta
            // 
            this.txtFechaHasta.Location = new System.Drawing.Point(234, 140);
            this.txtFechaHasta.MaxLength = 10;
            this.txtFechaHasta.Name = "txtFechaHasta";
            this.txtFechaHasta.Size = new System.Drawing.Size(208, 22);
            this.txtFechaHasta.TabIndex = 111;
            this.txtFechaHasta.Leave += new System.EventHandler(this.txtFechaHasta_Leave);
            // 
            // txtFechaDesde
            // 
            this.txtFechaDesde.Location = new System.Drawing.Point(12, 140);
            this.txtFechaDesde.MaxLength = 10;
            this.txtFechaDesde.Name = "txtFechaDesde";
            this.txtFechaDesde.Size = new System.Drawing.Size(208, 22);
            this.txtFechaDesde.TabIndex = 110;
            this.txtFechaDesde.Leave += new System.EventHandler(this.txtFechaDesde_Leave);
            // 
            // txtCodigo_articulo_marca
            // 
            this.txtCodigo_articulo_marca.Location = new System.Drawing.Point(234, 85);
            this.txtCodigo_articulo_marca.MaxLength = 30;
            this.txtCodigo_articulo_marca.Name = "txtCodigo_articulo_marca";
            this.txtCodigo_articulo_marca.Size = new System.Drawing.Size(322, 22);
            this.txtCodigo_articulo_marca.TabIndex = 109;
            // 
            // txtCodigo_articulo
            // 
            this.txtCodigo_articulo.Location = new System.Drawing.Point(12, 85);
            this.txtCodigo_articulo.MaxLength = 50;
            this.txtCodigo_articulo.Name = "txtCodigo_articulo";
            this.txtCodigo_articulo.Size = new System.Drawing.Size(208, 22);
            this.txtCodigo_articulo.TabIndex = 108;
            // 
            // txtNroFactura
            // 
            this.txtNroFactura.Location = new System.Drawing.Point(231, 32);
            this.txtNroFactura.Name = "txtNroFactura";
            this.txtNroFactura.Size = new System.Drawing.Size(116, 22);
            this.txtNroFactura.TabIndex = 107;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Firebrick;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnBuscar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(160, 183);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(107, 42);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // rdBusqueda1
            // 
            this.rdBusqueda1.AutoSize = true;
            this.rdBusqueda1.Location = new System.Drawing.Point(254, 31);
            this.rdBusqueda1.Name = "rdBusqueda1";
            this.rdBusqueda1.Size = new System.Drawing.Size(105, 21);
            this.rdBusqueda1.TabIndex = 109;
            this.rdBusqueda1.TabStop = true;
            this.rdBusqueda1.Text = "Busqueda 1";
            this.rdBusqueda1.UseVisualStyleBackColor = true;
            this.rdBusqueda1.CheckedChanged += new System.EventHandler(this.rdBusqueda1_CheckedChanged);
            // 
            // rdBusqueda2
            // 
            this.rdBusqueda2.AutoSize = true;
            this.rdBusqueda2.Location = new System.Drawing.Point(769, 31);
            this.rdBusqueda2.Name = "rdBusqueda2";
            this.rdBusqueda2.Size = new System.Drawing.Size(105, 21);
            this.rdBusqueda2.TabIndex = 110;
            this.rdBusqueda2.TabStop = true;
            this.rdBusqueda2.Text = "Busqueda 2";
            this.rdBusqueda2.UseVisualStyleBackColor = true;
            this.rdBusqueda2.CheckedChanged += new System.EventHandler(this.rdBusqueda2_CheckedChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(175, 77);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 112;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(377, 678);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 17);
            this.label20.TabIndex = 115;
            this.label20.Text = "Impresoras";
            // 
            // cbImpresoras
            // 
            this.cbImpresoras.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbImpresoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbImpresoras.FormattingEnabled = true;
            this.cbImpresoras.Location = new System.Drawing.Point(379, 698);
            this.cbImpresoras.Name = "cbImpresoras";
            this.cbImpresoras.Size = new System.Drawing.Size(366, 24);
            this.cbImpresoras.TabIndex = 114;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(759, 678);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 117;
            this.label2.Text = "Nro Copias";
            // 
            // txtNroCopias
            // 
            this.txtNroCopias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNroCopias.Location = new System.Drawing.Point(762, 701);
            this.txtNroCopias.MaxLength = 2;
            this.txtNroCopias.Name = "txtNroCopias";
            this.txtNroCopias.Size = new System.Drawing.Size(39, 22);
            this.txtNroCopias.TabIndex = 118;
            this.txtNroCopias.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroCopias_KeyPress);
            // 
            // btnEliminarFactura
            // 
            this.btnEliminarFactura.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminarFactura.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFactura.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFactura.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFactura.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFactura.ForeColor = System.Drawing.Color.White;
            this.btnEliminarFactura.Location = new System.Drawing.Point(199, 684);
            this.btnEliminarFactura.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarFactura.Name = "btnEliminarFactura";
            this.btnEliminarFactura.Size = new System.Drawing.Size(129, 42);
            this.btnEliminarFactura.TabIndex = 119;
            this.btnEliminarFactura.Text = "Eliminar Factura";
            this.btnEliminarFactura.UseVisualStyleBackColor = false;
            this.btnEliminarFactura.Click += new System.EventHandler(this.btnEliminarFactura_Click);
            // 
            // btnDropDownButton
            // 
            this.btnDropDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDropDownButton.Appearance.BackColor = System.Drawing.Color.Firebrick;
            this.btnDropDownButton.Appearance.Options.UseBackColor = true;
            this.btnDropDownButton.AppearanceHovered.BackColor = System.Drawing.Color.IndianRed;
            this.btnDropDownButton.AppearanceHovered.Options.UseBackColor = true;
            this.btnDropDownButton.Location = new System.Drawing.Point(13, 684);
            this.btnDropDownButton.Margin = new System.Windows.Forms.Padding(12);
            this.btnDropDownButton.Name = "btnDropDownButton";
            this.btnDropDownButton.Size = new System.Drawing.Size(170, 42);
            this.btnDropDownButton.TabIndex = 120;
            this.btnDropDownButton.Text = "Elija una opcion";
            // 
            // frmFacturaGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 735);
            this.Controls.Add(this.btnDropDownButton);
            this.Controls.Add(this.btnEliminarFactura);
            this.Controls.Add(this.txtNroCopias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cbImpresoras);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.rdBusqueda2);
            this.Controls.Add(this.rdBusqueda1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.panelBusqueda2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFacturaGestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión Facturas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFacturaGestion_FormClosing);
            this.Load += new System.EventHandler(this.frmFacturaGestion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.panelBusqueda2.ResumeLayout(false);
            this.panelBusqueda2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panelBusqueda2;
        private System.Windows.Forms.Label lblFechaHasta;
        private System.Windows.Forms.Label lblFechaDesde;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Label lblNroFactura;
        private System.Windows.Forms.TextBox txtFechaHasta;
        private System.Windows.Forms.TextBox txtFechaDesde;
        private System.Windows.Forms.TextBox txtCodigo_articulo_marca;
        private System.Windows.Forms.TextBox txtCodigo_articulo;
        private System.Windows.Forms.TextBox txtNroFactura;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.RadioButton rdBusqueda1;
        private System.Windows.Forms.RadioButton rdBusqueda2;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipoFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtClienteId;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnCancelarFiltro;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbImpresoras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNroCopias;
        private System.Windows.Forms.Button btnEliminarFactura;
        private DevExpress.XtraEditors.DropDownButton btnDropDownButton;
    }
}