namespace Modulo_Administracion
{
    partial class frmDireccion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpbControles = new System.Windows.Forms.GroupBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.gpbDatos = new System.Windows.Forms.GroupBox();
            this.txtCodPostal = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtPais = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtApto = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.btnBuscarPais = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnCancelarSeleccion = new System.Windows.Forms.Button();
            this.btnBuscarProvincia = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.Label10 = new System.Windows.Forms.Label();
            this.btnBuscarLoc = new System.Windows.Forms.Button();
            this.btnBuscarCalle = new System.Windows.Forms.Button();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.cbTipoDir = new System.Windows.Forms.ComboBox();
            this.cbTipoCalle = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.gpbDirCargadas = new System.Windows.Forms.GroupBox();
            this.dgvDirecciones = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod_tipo_dir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sn_activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbControles.SuspendLayout();
            this.gpbDatos.SuspendLayout();
            this.gpbDirCargadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirecciones)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbControles
            // 
            this.gpbControles.Controls.Add(this.btnAceptar);
            this.gpbControles.Controls.Add(this.btnSalir);
            this.gpbControles.Controls.Add(this.btnNuevo);
            this.gpbControles.Location = new System.Drawing.Point(13, 374);
            this.gpbControles.Margin = new System.Windows.Forms.Padding(4);
            this.gpbControles.Name = "gpbControles";
            this.gpbControles.Padding = new System.Windows.Forms.Padding(4);
            this.gpbControles.Size = new System.Drawing.Size(1032, 69);
            this.gpbControles.TabIndex = 16;
            this.gpbControles.TabStop = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Firebrick;
            this.btnAceptar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnAceptar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnAceptar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnAceptar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(771, 17);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(107, 42);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Firebrick;
            this.btnSalir.Enabled = false;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(900, 17);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 42);
            this.btnSalir.TabIndex = 20;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.btnNuevo.Location = new System.Drawing.Point(11, 17);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(107, 42);
            this.btnNuevo.TabIndex = 17;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // gpbDatos
            // 
            this.gpbDatos.Controls.Add(this.txtCodPostal);
            this.gpbDatos.Controls.Add(this.txtLocalidad);
            this.gpbDatos.Controls.Add(this.txtProvincia);
            this.gpbDatos.Controls.Add(this.txtPais);
            this.gpbDatos.Controls.Add(this.txtPiso);
            this.gpbDatos.Controls.Add(this.txtNumero);
            this.gpbDatos.Controls.Add(this.txtApto);
            this.gpbDatos.Controls.Add(this.txtCalle);
            this.gpbDatos.Controls.Add(this.btnBuscarPais);
            this.gpbDatos.Controls.Add(this.btnBorrar);
            this.gpbDatos.Controls.Add(this.btnCancelarSeleccion);
            this.gpbDatos.Controls.Add(this.btnBuscarProvincia);
            this.gpbDatos.Controls.Add(this.btnAgregar);
            this.gpbDatos.Controls.Add(this.Label10);
            this.gpbDatos.Controls.Add(this.btnBuscarLoc);
            this.gpbDatos.Controls.Add(this.btnBuscarCalle);
            this.gpbDatos.Controls.Add(this.Label9);
            this.gpbDatos.Controls.Add(this.Label8);
            this.gpbDatos.Controls.Add(this.Label7);
            this.gpbDatos.Controls.Add(this.Label6);
            this.gpbDatos.Controls.Add(this.Label5);
            this.gpbDatos.Controls.Add(this.cbTipoDir);
            this.gpbDatos.Controls.Add(this.cbTipoCalle);
            this.gpbDatos.Controls.Add(this.Label4);
            this.gpbDatos.Controls.Add(this.Label3);
            this.gpbDatos.Controls.Add(this.Label2);
            this.gpbDatos.Controls.Add(this.Label1);
            this.gpbDatos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpbDatos.Location = new System.Drawing.Point(13, 155);
            this.gpbDatos.Margin = new System.Windows.Forms.Padding(4);
            this.gpbDatos.Name = "gpbDatos";
            this.gpbDatos.Padding = new System.Windows.Forms.Padding(4);
            this.gpbDatos.Size = new System.Drawing.Size(1032, 219);
            this.gpbDatos.TabIndex = 2;
            this.gpbDatos.TabStop = false;
            // 
            // txtCodPostal
            // 
            this.txtCodPostal.Enabled = false;
            this.txtCodPostal.Location = new System.Drawing.Point(567, 126);
            this.txtCodPostal.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodPostal.MaxLength = 50;
            this.txtCodPostal.Name = "txtCodPostal";
            this.txtCodPostal.Size = new System.Drawing.Size(163, 22);
            this.txtCodPostal.TabIndex = 12;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(567, 87);
            this.txtLocalidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtLocalidad.MaxLength = 3250767;
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(213, 22);
            this.txtLocalidad.TabIndex = 11;
            this.txtLocalidad.Leave += new System.EventHandler(this.txtLocalidad_LostFocus);
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(567, 55);
            this.txtProvincia.Margin = new System.Windows.Forms.Padding(4);
            this.txtProvincia.MaxLength = 50;
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(216, 22);
            this.txtProvincia.TabIndex = 10;
            this.txtProvincia.Leave += new System.EventHandler(this.txtProvincia_LostFocus);
            // 
            // txtPais
            // 
            this.txtPais.Location = new System.Drawing.Point(567, 23);
            this.txtPais.Margin = new System.Windows.Forms.Padding(4);
            this.txtPais.MaxLength = 50;
            this.txtPais.Name = "txtPais";
            this.txtPais.Size = new System.Drawing.Size(216, 22);
            this.txtPais.TabIndex = 9;
            this.txtPais.Leave += new System.EventHandler(this.txtPais_LostFocus);
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(292, 144);
            this.txtPiso.Margin = new System.Windows.Forms.Padding(4);
            this.txtPiso.MaxLength = 50;
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(87, 22);
            this.txtPiso.TabIndex = 7;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(147, 144);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumero.MaxLength = 50;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(87, 22);
            this.txtNumero.TabIndex = 6;
            // 
            // txtApto
            // 
            this.txtApto.Location = new System.Drawing.Point(147, 180);
            this.txtApto.Margin = new System.Windows.Forms.Padding(4);
            this.txtApto.MaxLength = 50;
            this.txtApto.Name = "txtApto";
            this.txtApto.Size = new System.Drawing.Size(232, 22);
            this.txtApto.TabIndex = 8;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(147, 108);
            this.txtCalle.Margin = new System.Windows.Forms.Padding(4);
            this.txtCalle.MaxLength = 50;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(232, 22);
            this.txtCalle.TabIndex = 5;
            this.txtCalle.Leave += new System.EventHandler(this.txtCalle_LostFocus);
            // 
            // btnBuscarPais
            // 
            this.btnBuscarPais.Location = new System.Drawing.Point(792, 20);
            this.btnBuscarPais.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarPais.Name = "btnBuscarPais";
            this.btnBuscarPais.Size = new System.Drawing.Size(37, 26);
            this.btnBuscarPais.TabIndex = 29;
            this.btnBuscarPais.Text = "...";
            this.btnBuscarPais.UseVisualStyleBackColor = true;
            this.btnBuscarPais.Visible = false;
            this.btnBuscarPais.Click += new System.EventHandler(this.btnBuscarPais_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackColor = System.Drawing.Color.Firebrick;
            this.btnBorrar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnBorrar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnBorrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnBorrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.ForeColor = System.Drawing.Color.White;
            this.btnBorrar.Location = new System.Drawing.Point(900, 70);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(107, 42);
            this.btnBorrar.TabIndex = 15;
            this.btnBorrar.Text = "Eliminar";
            this.btnBorrar.UseVisualStyleBackColor = false;
            this.btnBorrar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.btnCancelarSeleccion.Location = new System.Drawing.Point(900, 120);
            this.btnCancelarSeleccion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarSeleccion.Name = "btnCancelarSeleccion";
            this.btnCancelarSeleccion.Size = new System.Drawing.Size(107, 42);
            this.btnCancelarSeleccion.TabIndex = 14;
            this.btnCancelarSeleccion.Text = "Cancelar";
            this.btnCancelarSeleccion.UseVisualStyleBackColor = false;
            this.btnCancelarSeleccion.Click += new System.EventHandler(this.btnCancelarSeleccion_Click);
            // 
            // btnBuscarProvincia
            // 
            this.btnBuscarProvincia.Location = new System.Drawing.Point(792, 52);
            this.btnBuscarProvincia.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarProvincia.Name = "btnBuscarProvincia";
            this.btnBuscarProvincia.Size = new System.Drawing.Size(37, 26);
            this.btnBuscarProvincia.TabIndex = 30;
            this.btnBuscarProvincia.Text = "...";
            this.btnBuscarProvincia.UseVisualStyleBackColor = true;
            this.btnBuscarProvincia.Visible = false;
            this.btnBuscarProvincia.Click += new System.EventHandler(this.btnBuscarProvincia_Click);
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
            this.btnAgregar.Location = new System.Drawing.Point(900, 20);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 42);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(473, 129);
            this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(84, 17);
            this.Label10.TabIndex = 40;
            this.Label10.Text = "Cod. Postal:";
            // 
            // btnBuscarLoc
            // 
            this.btnBuscarLoc.Location = new System.Drawing.Point(792, 87);
            this.btnBuscarLoc.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarLoc.Name = "btnBuscarLoc";
            this.btnBuscarLoc.Size = new System.Drawing.Size(37, 26);
            this.btnBuscarLoc.TabIndex = 33;
            this.btnBuscarLoc.Text = "...";
            this.btnBuscarLoc.UseVisualStyleBackColor = true;
            this.btnBuscarLoc.Visible = false;
            this.btnBuscarLoc.Click += new System.EventHandler(this.btnBuscarLoc_Click);
            // 
            // btnBuscarCalle
            // 
            this.btnBuscarCalle.Location = new System.Drawing.Point(388, 100);
            this.btnBuscarCalle.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarCalle.Name = "btnBuscarCalle";
            this.btnBuscarCalle.Size = new System.Drawing.Size(37, 26);
            this.btnBuscarCalle.TabIndex = 24;
            this.btnBuscarCalle.Text = "...";
            this.btnBuscarCalle.UseVisualStyleBackColor = true;
            this.btnBuscarCalle.Visible = false;
            this.btnBuscarCalle.Click += new System.EventHandler(this.btnBuscarCalle_Click);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(473, 26);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(39, 17);
            this.Label9.TabIndex = 39;
            this.Label9.Text = "Pais:";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(33, 183);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(41, 17);
            this.Label8.TabIndex = 36;
            this.Label8.Text = "Apto:";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(473, 57);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(66, 17);
            this.Label7.TabIndex = 34;
            this.Label7.Text = "Provincia";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(473, 92);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(73, 17);
            this.Label6.TabIndex = 32;
            this.Label6.Text = "Localidad:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(33, 148);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(58, 17);
            this.Label5.TabIndex = 31;
            this.Label5.Text = "Numero";
            // 
            // cbTipoDir
            // 
            this.cbTipoDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDir.FormattingEnabled = true;
            this.cbTipoDir.Items.AddRange(new object[] {
            "asasdas",
            "reeeeeee",
            "rrrrrrrrrrrrrrrrrr"});
            this.cbTipoDir.Location = new System.Drawing.Point(147, 20);
            this.cbTipoDir.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipoDir.Name = "cbTipoDir";
            this.cbTipoDir.Size = new System.Drawing.Size(232, 24);
            this.cbTipoDir.TabIndex = 3;
            // 
            // cbTipoCalle
            // 
            this.cbTipoCalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoCalle.FormattingEnabled = true;
            this.cbTipoCalle.Location = new System.Drawing.Point(147, 60);
            this.cbTipoCalle.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipoCalle.Name = "cbTipoCalle";
            this.cbTipoCalle.Size = new System.Drawing.Size(232, 24);
            this.cbTipoCalle.TabIndex = 4;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(256, 144);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(39, 17);
            this.Label4.TabIndex = 28;
            this.Label4.Text = "Piso:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(33, 108);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(43, 17);
            this.Label3.TabIndex = 27;
            this.Label3.Text = "Calle:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(33, 28);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(103, 17);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Tipo Dirección:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(33, 70);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(95, 17);
            this.Label1.TabIndex = 25;
            this.Label1.Text = "Tipo de Calle:";
            // 
            // gpbDirCargadas
            // 
            this.gpbDirCargadas.Controls.Add(this.dgvDirecciones);
            this.gpbDirCargadas.Location = new System.Drawing.Point(13, 12);
            this.gpbDirCargadas.Margin = new System.Windows.Forms.Padding(4);
            this.gpbDirCargadas.Name = "gpbDirCargadas";
            this.gpbDirCargadas.Padding = new System.Windows.Forms.Padding(4);
            this.gpbDirCargadas.Size = new System.Drawing.Size(1032, 143);
            this.gpbDirCargadas.TabIndex = 0;
            this.gpbDirCargadas.TabStop = false;
            // 
            // dgvDirecciones
            // 
            this.dgvDirecciones.AllowUserToAddRows = false;
            this.dgvDirecciones.AllowUserToDeleteRows = false;
            this.dgvDirecciones.AllowUserToOrderColumns = true;
            this.dgvDirecciones.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDirecciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDirecciones.ColumnHeadersHeight = 22;
            this.dgvDirecciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.cod_tipo_dir,
            this.sn_activo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDirecciones.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDirecciones.Location = new System.Drawing.Point(11, 11);
            this.dgvDirecciones.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDirecciones.MultiSelect = false;
            this.dgvDirecciones.Name = "dgvDirecciones";
            this.dgvDirecciones.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDirecciones.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDirecciones.RowHeadersVisible = false;
            this.dgvDirecciones.RowHeadersWidth = 51;
            this.dgvDirecciones.RowTemplate.Height = 17;
            this.dgvDirecciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDirecciones.Size = new System.Drawing.Size(1013, 121);
            this.dgvDirecciones.TabIndex = 1;
            this.dgvDirecciones.TabStop = false;
            this.dgvDirecciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDirecciones_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tipo Dirección";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tipo Calle";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Calle";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Numero";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Apto";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 35;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Piso";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 35;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Pais";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Provincia";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 125;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Municipio";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 125;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Cp";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 46;
            // 
            // cod_tipo_dir
            // 
            this.cod_tipo_dir.HeaderText = "Cod Tipo Dir";
            this.cod_tipo_dir.MinimumWidth = 6;
            this.cod_tipo_dir.Name = "cod_tipo_dir";
            this.cod_tipo_dir.ReadOnly = true;
            this.cod_tipo_dir.Visible = false;
            this.cod_tipo_dir.Width = 125;
            // 
            // sn_activo
            // 
            this.sn_activo.HeaderText = "sn_activo";
            this.sn_activo.MinimumWidth = 6;
            this.sn_activo.Name = "sn_activo";
            this.sn_activo.ReadOnly = true;
            this.sn_activo.Width = 125;
            // 
            // frmDireccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1060, 456);
            this.Controls.Add(this.gpbControles);
            this.Controls.Add(this.gpbDirCargadas);
            this.Controls.Add(this.gpbDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDireccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dirección";
            this.Load += new System.EventHandler(this.frmDireccion_Load);
            this.gpbControles.ResumeLayout(false);
            this.gpbDatos.ResumeLayout(false);
            this.gpbDatos.PerformLayout();
            this.gpbDirCargadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirecciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbControles;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gpbDatos;
        private System.Windows.Forms.GroupBox gpbDirCargadas;
        private System.Windows.Forms.DataGridView dgvDirecciones;
        private System.Windows.Forms.Button btnBuscarPais;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCancelarSeleccion;
        private System.Windows.Forms.Button btnBuscarProvincia;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Button btnBuscarLoc;
        private System.Windows.Forms.Button btnBuscarCalle;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Label Label8;
        private System.Windows.Forms.Label Label7;
        private System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.ComboBox cbTipoDir;
        private System.Windows.Forms.ComboBox cbTipoCalle;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtCodPostal;
        private System.Windows.Forms.TextBox txtLocalidad;
        private System.Windows.Forms.TextBox txtProvincia;
        private System.Windows.Forms.TextBox txtPais;
        private System.Windows.Forms.TextBox txtPiso;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtApto;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod_tipo_dir;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn_activo;
    }
}