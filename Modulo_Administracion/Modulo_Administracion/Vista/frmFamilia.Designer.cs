namespace Modulo_Administracion
{
    partial class frmFamilia
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.tabFamilia = new System.Windows.Forms.TabControl();
            this.tabPageFamilia = new System.Windows.Forms.TabPage();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtFamilia = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.tabPageCoeficiente = new System.Windows.Forms.TabPage();
            this.lblCoeficiente_sin_beneficio = new System.Windows.Forms.Label();
            this.lblPrecio_mayorista = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCoeficiente_con_beneficio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAlgoritmo_10 = new System.Windows.Forms.TextBox();
            this.txtAlgoritmo_9 = new System.Windows.Forms.TextBox();
            this.txtAlgoritmo_8 = new System.Windows.Forms.TextBox();
            this.txtAlgoritmo_7 = new System.Windows.Forms.TextBox();
            this.txtAlgoritmo_6 = new System.Windows.Forms.TextBox();
            this.txtAlgoritmo_5 = new System.Windows.Forms.TextBox();
            this.txtAlgoritmo_4 = new System.Windows.Forms.TextBox();
            this.txtAlgoritmo_3 = new System.Windows.Forms.TextBox();
            this.txtAlgoritmo_2 = new System.Windows.Forms.TextBox();
            this.txtAlgoritmo_1 = new System.Windows.Forms.TextBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnCancelarSeleccion = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvFamilia = new System.Windows.Forms.DataGridView();
            this.tabFamilia.SuspendLayout();
            this.tabPageFamilia.SuspendLayout();
            this.tabPageCoeficiente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilia)).BeginInit();
            this.SuspendLayout();
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
            this.btnSalir.Location = new System.Drawing.Point(1035, 494);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 42);
            this.btnSalir.TabIndex = 10;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tabFamilia
            // 
            this.tabFamilia.Controls.Add(this.tabPageFamilia);
            this.tabFamilia.Controls.Add(this.tabPageCoeficiente);
            this.tabFamilia.Location = new System.Drawing.Point(12, 12);
            this.tabFamilia.Name = "tabFamilia";
            this.tabFamilia.SelectedIndex = 0;
            this.tabFamilia.Size = new System.Drawing.Size(629, 476);
            this.tabFamilia.TabIndex = 0;
            // 
            // tabPageFamilia
            // 
            this.tabPageFamilia.Controls.Add(this.cbMarca);
            this.tabPageFamilia.Controls.Add(this.cbProveedor);
            this.tabPageFamilia.Controls.Add(this.lblProveedor);
            this.tabPageFamilia.Controls.Add(this.lblMarca);
            this.tabPageFamilia.Controls.Add(this.lblFamilia);
            this.tabPageFamilia.Controls.Add(this.lblCodigo);
            this.tabPageFamilia.Controls.Add(this.txtFamilia);
            this.tabPageFamilia.Controls.Add(this.txtCodigo);
            this.tabPageFamilia.Location = new System.Drawing.Point(4, 25);
            this.tabPageFamilia.Name = "tabPageFamilia";
            this.tabPageFamilia.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFamilia.Size = new System.Drawing.Size(621, 447);
            this.tabPageFamilia.TabIndex = 0;
            this.tabPageFamilia.Text = "Familia";
            this.tabPageFamilia.UseVisualStyleBackColor = true;
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(132, 112);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(405, 24);
            this.cbMarca.TabIndex = 4;
            // 
            // cbProveedor
            // 
            this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(132, 82);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(405, 24);
            this.cbProveedor.TabIndex = 3;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(23, 82);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(74, 17);
            this.lblProveedor.TabIndex = 29;
            this.lblProveedor.Text = "Proveedor";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(23, 112);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(47, 17);
            this.lblMarca.TabIndex = 28;
            this.lblMarca.Text = "Marca";
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(23, 50);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(52, 17);
            this.lblFamilia.TabIndex = 11;
            this.lblFamilia.Text = "Familia";
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
            // txtFamilia
            // 
            this.txtFamilia.Location = new System.Drawing.Point(132, 50);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.Size = new System.Drawing.Size(405, 22);
            this.txtFamilia.TabIndex = 2;
            this.txtFamilia.Leave += new System.EventHandler(this.txtFamilia_Leave);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(132, 22);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 22);
            this.txtCodigo.TabIndex = 1;
            // 
            // tabPageCoeficiente
            // 
            this.tabPageCoeficiente.Controls.Add(this.lblCoeficiente_sin_beneficio);
            this.tabPageCoeficiente.Controls.Add(this.lblPrecio_mayorista);
            this.tabPageCoeficiente.Controls.Add(this.label5);
            this.tabPageCoeficiente.Controls.Add(this.lblCoeficiente_con_beneficio);
            this.tabPageCoeficiente.Controls.Add(this.label4);
            this.tabPageCoeficiente.Controls.Add(this.label3);
            this.tabPageCoeficiente.Controls.Add(this.label2);
            this.tabPageCoeficiente.Controls.Add(this.label1);
            this.tabPageCoeficiente.Controls.Add(this.txtAlgoritmo_10);
            this.tabPageCoeficiente.Controls.Add(this.txtAlgoritmo_9);
            this.tabPageCoeficiente.Controls.Add(this.txtAlgoritmo_8);
            this.tabPageCoeficiente.Controls.Add(this.txtAlgoritmo_7);
            this.tabPageCoeficiente.Controls.Add(this.txtAlgoritmo_6);
            this.tabPageCoeficiente.Controls.Add(this.txtAlgoritmo_5);
            this.tabPageCoeficiente.Controls.Add(this.txtAlgoritmo_4);
            this.tabPageCoeficiente.Controls.Add(this.txtAlgoritmo_3);
            this.tabPageCoeficiente.Controls.Add(this.txtAlgoritmo_2);
            this.tabPageCoeficiente.Controls.Add(this.txtAlgoritmo_1);
            this.tabPageCoeficiente.Location = new System.Drawing.Point(4, 25);
            this.tabPageCoeficiente.Name = "tabPageCoeficiente";
            this.tabPageCoeficiente.Size = new System.Drawing.Size(621, 447);
            this.tabPageCoeficiente.TabIndex = 1;
            this.tabPageCoeficiente.Text = "Coeficiente";
            this.tabPageCoeficiente.UseVisualStyleBackColor = true;
            // 
            // lblCoeficiente_sin_beneficio
            // 
            this.lblCoeficiente_sin_beneficio.AutoSize = true;
            this.lblCoeficiente_sin_beneficio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoeficiente_sin_beneficio.Location = new System.Drawing.Point(136, 193);
            this.lblCoeficiente_sin_beneficio.Name = "lblCoeficiente_sin_beneficio";
            this.lblCoeficiente_sin_beneficio.Size = new System.Drawing.Size(211, 17);
            this.lblCoeficiente_sin_beneficio.TabIndex = 48;
            this.lblCoeficiente_sin_beneficio.Text = "lblCoeficiente_sin_beneficio";
            // 
            // lblPrecio_mayorista
            // 
            this.lblPrecio_mayorista.AutoSize = true;
            this.lblPrecio_mayorista.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio_mayorista.Location = new System.Drawing.Point(452, 266);
            this.lblPrecio_mayorista.Name = "lblPrecio_mayorista";
            this.lblPrecio_mayorista.Size = new System.Drawing.Size(132, 17);
            this.lblPrecio_mayorista.TabIndex = 47;
            this.lblPrecio_mayorista.Text = "precio_mayorista";
            this.lblPrecio_mayorista.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(366, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 46;
            this.label5.Text = "Mayorista";
            this.label5.Visible = false;
            // 
            // lblCoeficiente_con_beneficio
            // 
            this.lblCoeficiente_con_beneficio.AutoSize = true;
            this.lblCoeficiente_con_beneficio.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoeficiente_con_beneficio.Location = new System.Drawing.Point(136, 266);
            this.lblCoeficiente_con_beneficio.Name = "lblCoeficiente_con_beneficio";
            this.lblCoeficiente_con_beneficio.Size = new System.Drawing.Size(216, 17);
            this.lblCoeficiente_con_beneficio.TabIndex = 45;
            this.lblCoeficiente_con_beneficio.Text = "lblCoeficiente_con_beneficio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 44;
            this.label4.Text = "Minorista";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(190, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 43;
            this.label3.Text = "Beneficio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 42;
            this.label2.Text = "Coeficiente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "Descuento:";
            // 
            // txtAlgoritmo_10
            // 
            this.txtAlgoritmo_10.Location = new System.Drawing.Point(369, 299);
            this.txtAlgoritmo_10.MaxLength = 5;
            this.txtAlgoritmo_10.Name = "txtAlgoritmo_10";
            this.txtAlgoritmo_10.Size = new System.Drawing.Size(88, 22);
            this.txtAlgoritmo_10.TabIndex = 40;
            this.txtAlgoritmo_10.Visible = false;
            this.txtAlgoritmo_10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlgoritmo_10_KeyPress);
            // 
            // txtAlgoritmo_9
            // 
            this.txtAlgoritmo_9.Location = new System.Drawing.Point(56, 299);
            this.txtAlgoritmo_9.MaxLength = 5;
            this.txtAlgoritmo_9.Name = "txtAlgoritmo_9";
            this.txtAlgoritmo_9.Size = new System.Drawing.Size(88, 22);
            this.txtAlgoritmo_9.TabIndex = 39;
            this.txtAlgoritmo_9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlgoritmo_9_KeyPress);
            this.txtAlgoritmo_9.Leave += new System.EventHandler(this.txtAlgoritmo_9_Leave);
            // 
            // txtAlgoritmo_8
            // 
            this.txtAlgoritmo_8.Location = new System.Drawing.Point(260, 139);
            this.txtAlgoritmo_8.MaxLength = 5;
            this.txtAlgoritmo_8.Name = "txtAlgoritmo_8";
            this.txtAlgoritmo_8.Size = new System.Drawing.Size(88, 22);
            this.txtAlgoritmo_8.TabIndex = 38;
            this.txtAlgoritmo_8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlgoritmo_8_KeyPress);
            this.txtAlgoritmo_8.Leave += new System.EventHandler(this.txtAlgoritmo_8_Leave);
            // 
            // txtAlgoritmo_7
            // 
            this.txtAlgoritmo_7.Location = new System.Drawing.Point(139, 139);
            this.txtAlgoritmo_7.MaxLength = 5;
            this.txtAlgoritmo_7.Name = "txtAlgoritmo_7";
            this.txtAlgoritmo_7.Size = new System.Drawing.Size(88, 22);
            this.txtAlgoritmo_7.TabIndex = 37;
            this.txtAlgoritmo_7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlgoritmo_7_KeyPress);
            this.txtAlgoritmo_7.Leave += new System.EventHandler(this.txtAlgoritmo_7_Leave);
            // 
            // txtAlgoritmo_6
            // 
            this.txtAlgoritmo_6.Location = new System.Drawing.Point(260, 111);
            this.txtAlgoritmo_6.MaxLength = 5;
            this.txtAlgoritmo_6.Name = "txtAlgoritmo_6";
            this.txtAlgoritmo_6.Size = new System.Drawing.Size(88, 22);
            this.txtAlgoritmo_6.TabIndex = 36;
            this.txtAlgoritmo_6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlgoritmo_6_KeyPress);
            this.txtAlgoritmo_6.Leave += new System.EventHandler(this.txtAlgoritmo_6_Leave);
            // 
            // txtAlgoritmo_5
            // 
            this.txtAlgoritmo_5.Location = new System.Drawing.Point(139, 111);
            this.txtAlgoritmo_5.MaxLength = 5;
            this.txtAlgoritmo_5.Name = "txtAlgoritmo_5";
            this.txtAlgoritmo_5.Size = new System.Drawing.Size(88, 22);
            this.txtAlgoritmo_5.TabIndex = 35;
            this.txtAlgoritmo_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlgoritmo_5_KeyPress);
            this.txtAlgoritmo_5.Leave += new System.EventHandler(this.txtAlgoritmo_5_Leave);
            // 
            // txtAlgoritmo_4
            // 
            this.txtAlgoritmo_4.Location = new System.Drawing.Point(260, 83);
            this.txtAlgoritmo_4.MaxLength = 5;
            this.txtAlgoritmo_4.Name = "txtAlgoritmo_4";
            this.txtAlgoritmo_4.Size = new System.Drawing.Size(88, 22);
            this.txtAlgoritmo_4.TabIndex = 34;
            this.txtAlgoritmo_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlgoritmo_4_KeyPress);
            this.txtAlgoritmo_4.Leave += new System.EventHandler(this.txtAlgoritmo_4_Leave);
            // 
            // txtAlgoritmo_3
            // 
            this.txtAlgoritmo_3.Location = new System.Drawing.Point(139, 83);
            this.txtAlgoritmo_3.MaxLength = 5;
            this.txtAlgoritmo_3.Name = "txtAlgoritmo_3";
            this.txtAlgoritmo_3.Size = new System.Drawing.Size(88, 22);
            this.txtAlgoritmo_3.TabIndex = 33;
            this.txtAlgoritmo_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlgoritmo_3_KeyPress);
            this.txtAlgoritmo_3.Leave += new System.EventHandler(this.txtAlgoritmo_3_Leave);
            // 
            // txtAlgoritmo_2
            // 
            this.txtAlgoritmo_2.Location = new System.Drawing.Point(260, 55);
            this.txtAlgoritmo_2.MaxLength = 5;
            this.txtAlgoritmo_2.Name = "txtAlgoritmo_2";
            this.txtAlgoritmo_2.Size = new System.Drawing.Size(88, 22);
            this.txtAlgoritmo_2.TabIndex = 32;
            this.txtAlgoritmo_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlgoritmo_2_KeyPress);
            this.txtAlgoritmo_2.Leave += new System.EventHandler(this.txtAlgoritmo_2_Leave);
            // 
            // txtAlgoritmo_1
            // 
            this.txtAlgoritmo_1.Location = new System.Drawing.Point(139, 55);
            this.txtAlgoritmo_1.MaxLength = 5;
            this.txtAlgoritmo_1.Name = "txtAlgoritmo_1";
            this.txtAlgoritmo_1.Size = new System.Drawing.Size(88, 22);
            this.txtAlgoritmo_1.TabIndex = 31;
            this.txtAlgoritmo_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlgoritmo_1_KeyPress);
            this.txtAlgoritmo_1.Leave += new System.EventHandler(this.txtAlgoritmo_1_Leave);
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
            this.btnNuevo.Location = new System.Drawing.Point(16, 495);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(107, 42);
            this.btnNuevo.TabIndex = 9;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            this.btnBorrar.Location = new System.Drawing.Point(805, 494);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(107, 42);
            this.btnBorrar.TabIndex = 8;
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
            this.btnCancelarSeleccion.Location = new System.Drawing.Point(920, 494);
            this.btnCancelarSeleccion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarSeleccion.Name = "btnCancelarSeleccion";
            this.btnCancelarSeleccion.Size = new System.Drawing.Size(107, 42);
            this.btnCancelarSeleccion.TabIndex = 7;
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
            this.btnAgregar.Location = new System.Drawing.Point(690, 494);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 42);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvFamilia
            // 
            this.dgvFamilia.AllowUserToAddRows = false;
            this.dgvFamilia.AllowUserToDeleteRows = false;
            this.dgvFamilia.AllowUserToOrderColumns = true;
            this.dgvFamilia.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.IndianRed;
            this.dgvFamilia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFamilia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvFamilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFamilia.GridColor = System.Drawing.Color.White;
            this.dgvFamilia.Location = new System.Drawing.Point(637, 37);
            this.dgvFamilia.MultiSelect = false;
            this.dgvFamilia.Name = "dgvFamilia";
            this.dgvFamilia.ReadOnly = true;
            this.dgvFamilia.RowHeadersVisible = false;
            this.dgvFamilia.RowHeadersWidth = 51;
            this.dgvFamilia.RowTemplate.Height = 24;
            this.dgvFamilia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFamilia.Size = new System.Drawing.Size(505, 447);
            this.dgvFamilia.TabIndex = 11;
            this.dgvFamilia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFamilia_CellClick);
            this.dgvFamilia.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFamilia_CellDoubleClick);
            // 
            // frmFamilia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 547);
            this.Controls.Add(this.dgvFamilia);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnCancelarSeleccion);
            this.Controls.Add(this.tabFamilia);
            this.Controls.Add(this.btnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFamilia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Familia";
            this.Load += new System.EventHandler(this.frmFamilia_Load);
            this.tabFamilia.ResumeLayout(false);
            this.tabPageFamilia.ResumeLayout(false);
            this.tabPageFamilia.PerformLayout();
            this.tabPageCoeficiente.ResumeLayout(false);
            this.tabPageCoeficiente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFamilia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TabControl tabFamilia;
        private System.Windows.Forms.TabPage tabPageFamilia;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtFamilia;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TabPage tabPageCoeficiente;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCancelarSeleccion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.TextBox txtAlgoritmo_10;
        private System.Windows.Forms.TextBox txtAlgoritmo_9;
        private System.Windows.Forms.TextBox txtAlgoritmo_8;
        private System.Windows.Forms.TextBox txtAlgoritmo_7;
        private System.Windows.Forms.TextBox txtAlgoritmo_6;
        private System.Windows.Forms.TextBox txtAlgoritmo_5;
        private System.Windows.Forms.TextBox txtAlgoritmo_4;
        private System.Windows.Forms.TextBox txtAlgoritmo_3;
        private System.Windows.Forms.TextBox txtAlgoritmo_2;
        private System.Windows.Forms.TextBox txtAlgoritmo_1;
        private System.Windows.Forms.Label lblCoeficiente_sin_beneficio;
        private System.Windows.Forms.Label lblPrecio_mayorista;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCoeficiente_con_beneficio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFamilia;
    }
}