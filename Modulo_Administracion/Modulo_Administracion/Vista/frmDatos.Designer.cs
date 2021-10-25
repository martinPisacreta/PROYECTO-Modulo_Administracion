namespace Modulo_Administracion
{
    partial class frmDatos
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
            this.txtDato = new System.Windows.Forms.TextBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnCancelarSeleccion = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.cbTipoDato = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.gpbDirCargadas = new System.Windows.Forms.GroupBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sn_activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbControles.SuspendLayout();
            this.gpbDatos.SuspendLayout();
            this.gpbDirCargadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbControles
            // 
            this.gpbControles.Controls.Add(this.btnAceptar);
            this.gpbControles.Controls.Add(this.btnSalir);
            this.gpbControles.Controls.Add(this.btnNuevo);
            this.gpbControles.Location = new System.Drawing.Point(13, 507);
            this.gpbControles.Margin = new System.Windows.Forms.Padding(4);
            this.gpbControles.Name = "gpbControles";
            this.gpbControles.Padding = new System.Windows.Forms.Padding(4);
            this.gpbControles.Size = new System.Drawing.Size(814, 69);
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
            this.btnAceptar.Location = new System.Drawing.Point(573, 17);
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
            this.btnSalir.Location = new System.Drawing.Point(702, 17);
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
            this.gpbDatos.Controls.Add(this.txtDato);
            this.gpbDatos.Controls.Add(this.btnBorrar);
            this.gpbDatos.Controls.Add(this.btnCancelarSeleccion);
            this.gpbDatos.Controls.Add(this.btnAgregar);
            this.gpbDatos.Controls.Add(this.cbTipoDato);
            this.gpbDatos.Controls.Add(this.Label3);
            this.gpbDatos.Controls.Add(this.Label2);
            this.gpbDatos.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gpbDatos.Location = new System.Drawing.Point(13, 326);
            this.gpbDatos.Margin = new System.Windows.Forms.Padding(4);
            this.gpbDatos.Name = "gpbDatos";
            this.gpbDatos.Padding = new System.Windows.Forms.Padding(4);
            this.gpbDatos.Size = new System.Drawing.Size(814, 173);
            this.gpbDatos.TabIndex = 2;
            this.gpbDatos.TabStop = false;
            // 
            // txtDato
            // 
            this.txtDato.Location = new System.Drawing.Point(147, 70);
            this.txtDato.Margin = new System.Windows.Forms.Padding(4);
            this.txtDato.MaxLength = 50;
            this.txtDato.Name = "txtDato";
            this.txtDato.Size = new System.Drawing.Size(352, 22);
            this.txtDato.TabIndex = 5;
            this.txtDato.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDato_KeyPress);
            this.txtDato.Leave += new System.EventHandler(this.txtDato_Leave);
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
            this.btnBorrar.Location = new System.Drawing.Point(699, 70);
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
            this.btnCancelarSeleccion.Location = new System.Drawing.Point(699, 120);
            this.btnCancelarSeleccion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarSeleccion.Name = "btnCancelarSeleccion";
            this.btnCancelarSeleccion.Size = new System.Drawing.Size(107, 42);
            this.btnCancelarSeleccion.TabIndex = 14;
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
            this.btnAgregar.Location = new System.Drawing.Point(699, 20);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(107, 42);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cbTipoDato
            // 
            this.cbTipoDato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoDato.FormattingEnabled = true;
            this.cbTipoDato.Items.AddRange(new object[] {
            "asasdas",
            "reeeeeee",
            "rrrrrrrrrrrrrrrrrr"});
            this.cbTipoDato.Location = new System.Drawing.Point(147, 20);
            this.cbTipoDato.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipoDato.Name = "cbTipoDato";
            this.cbTipoDato.Size = new System.Drawing.Size(352, 24);
            this.cbTipoDato.TabIndex = 3;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(33, 70);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(38, 17);
            this.Label3.TabIndex = 27;
            this.Label3.Text = "Dato";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(33, 28);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(70, 17);
            this.Label2.TabIndex = 26;
            this.Label2.Text = "Tipo Dato";
            // 
            // gpbDirCargadas
            // 
            this.gpbDirCargadas.Controls.Add(this.dgvDatos);
            this.gpbDirCargadas.Location = new System.Drawing.Point(13, 12);
            this.gpbDirCargadas.Margin = new System.Windows.Forms.Padding(4);
            this.gpbDirCargadas.Name = "gpbDirCargadas";
            this.gpbDirCargadas.Padding = new System.Windows.Forms.Padding(4);
            this.gpbDirCargadas.Size = new System.Drawing.Size(814, 306);
            this.gpbDirCargadas.TabIndex = 0;
            this.gpbDirCargadas.TabStop = false;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AllowUserToOrderColumns = true;
            this.dgvDatos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDatos.ColumnHeadersHeight = 22;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.sn_activo});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDatos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDatos.Location = new System.Drawing.Point(11, 11);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDatos.MultiSelect = false;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDatos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 17;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(788, 287);
            this.dgvDatos.TabIndex = 1;
            this.dgvDatos.TabStop = false;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            // 
            // Column3
            // 
            this.Column3.HeaderText = "cod_tipo_dato_cliente";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            this.Column3.Width = 125;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tipo Dato";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Dato";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // sn_activo
            // 
            this.sn_activo.HeaderText = "sn_activo";
            this.sn_activo.MinimumWidth = 6;
            this.sn_activo.Name = "sn_activo";
            this.sn_activo.ReadOnly = true;
            this.sn_activo.Visible = false;
            this.sn_activo.Width = 125;
            // 
            // frmDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(835, 589);
            this.Controls.Add(this.gpbControles);
            this.Controls.Add(this.gpbDirCargadas);
            this.Controls.Add(this.gpbDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente Datos";
            this.Load += new System.EventHandler(this.frmCliente_Datos_Load);
            this.gpbControles.ResumeLayout(false);
            this.gpbDatos.ResumeLayout(false);
            this.gpbDatos.PerformLayout();
            this.gpbDirCargadas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbControles;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox gpbDatos;
        private System.Windows.Forms.GroupBox gpbDirCargadas;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnCancelarSeleccion;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ComboBox cbTipoDato;
        private System.Windows.Forms.Label Label3;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.TextBox txtDato;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sn_activo;
    }
}