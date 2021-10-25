namespace Modulo_Administracion
{
    partial class frmImportarExcelProveedor
    {
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
            this.components = new System.ComponentModel.Container();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnCancelarSeleccion = new System.Windows.Forms.Button();
            this.txtArchivoExcel = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblMarca = new System.Windows.Forms.Label();
            this.btnImportar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvExcelExistentes = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelSeteoPMF = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnCancelarPMF = new System.Windows.Forms.Button();
            this.cbFamilia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvExcelInexistentes = new System.Windows.Forms.DataGridView();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvDatosErroneos = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnEliminarFilas = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelExistentes)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panelSeteoPMF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelInexistentes)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosErroneos)).BeginInit();
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
            this.btnSalir.Location = new System.Drawing.Point(818, 656);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(107, 42);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.btnCancelarSeleccion.Location = new System.Drawing.Point(704, 657);
            this.btnCancelarSeleccion.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarSeleccion.Name = "btnCancelarSeleccion";
            this.btnCancelarSeleccion.Size = new System.Drawing.Size(107, 42);
            this.btnCancelarSeleccion.TabIndex = 12;
            this.btnCancelarSeleccion.Text = "Cancelar";
            this.btnCancelarSeleccion.UseVisualStyleBackColor = false;
            this.btnCancelarSeleccion.Click += new System.EventHandler(this.btnCancelarSeleccion_Click);
            // 
            // txtArchivoExcel
            // 
            this.txtArchivoExcel.Location = new System.Drawing.Point(72, 97);
            this.txtArchivoExcel.Name = "txtArchivoExcel";
            this.txtArchivoExcel.ReadOnly = true;
            this.txtArchivoExcel.Size = new System.Drawing.Size(770, 22);
            this.txtArchivoExcel.TabIndex = 14;
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
            this.btnBuscar.Location = new System.Drawing.Point(851, 89);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 38);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(11, 100);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(55, 17);
            this.lblMarca.TabIndex = 29;
            this.lblMarca.Text = "Archivo";
            // 
            // btnImportar
            // 
            this.btnImportar.BackColor = System.Drawing.Color.Firebrick;
            this.btnImportar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnImportar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnImportar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnImportar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.ForeColor = System.Drawing.Color.White;
            this.btnImportar.Location = new System.Drawing.Point(589, 656);
            this.btnImportar.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(107, 42);
            this.btnImportar.TabIndex = 30;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 134);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(917, 516);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvExcelExistentes);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(909, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Articulos Existentes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvExcelExistentes
            // 
            this.dgvExcelExistentes.AllowUserToAddRows = false;
            this.dgvExcelExistentes.AllowUserToDeleteRows = false;
            this.dgvExcelExistentes.AllowUserToOrderColumns = true;
            this.dgvExcelExistentes.AllowUserToResizeRows = false;
            this.dgvExcelExistentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvExcelExistentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcelExistentes.Location = new System.Drawing.Point(6, 6);
            this.dgvExcelExistentes.Name = "dgvExcelExistentes";
            this.dgvExcelExistentes.ReadOnly = true;
            this.dgvExcelExistentes.RowHeadersWidth = 51;
            this.dgvExcelExistentes.RowTemplate.Height = 24;
            this.dgvExcelExistentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExcelExistentes.Size = new System.Drawing.Size(897, 263);
            this.dgvExcelExistentes.TabIndex = 17;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelSeteoPMF);
            this.tabPage2.Controls.Add(this.dgvExcelInexistentes);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(909, 487);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Articulos Inexistentes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelSeteoPMF
            // 
            this.panelSeteoPMF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeteoPMF.Controls.Add(this.btnEliminarFilas);
            this.panelSeteoPMF.Controls.Add(this.label4);
            this.panelSeteoPMF.Controls.Add(this.btnAplicar);
            this.panelSeteoPMF.Controls.Add(this.btnCancelarPMF);
            this.panelSeteoPMF.Controls.Add(this.cbFamilia);
            this.panelSeteoPMF.Controls.Add(this.label1);
            this.panelSeteoPMF.Controls.Add(this.cbMarca);
            this.panelSeteoPMF.Controls.Add(this.label3);
            this.panelSeteoPMF.Location = new System.Drawing.Point(6, 275);
            this.panelSeteoPMF.Name = "panelSeteoPMF";
            this.panelSeteoPMF.Size = new System.Drawing.Size(713, 205);
            this.panelSeteoPMF.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(622, 17);
            this.label4.TabIndex = 51;
            this.label4.Text = "Selecciona filas para asignarle proveedor - marca - familia ,  luego presionar ap" +
    "licar";
            // 
            // btnAplicar
            // 
            this.btnAplicar.BackColor = System.Drawing.Color.Firebrick;
            this.btnAplicar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnAplicar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnAplicar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnAplicar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnAplicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicar.ForeColor = System.Drawing.Color.White;
            this.btnAplicar.Location = new System.Drawing.Point(547, 51);
            this.btnAplicar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(138, 42);
            this.btnAplicar.TabIndex = 50;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnCancelarPMF
            // 
            this.btnCancelarPMF.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancelarPMF.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnCancelarPMF.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarPMF.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarPMF.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnCancelarPMF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarPMF.ForeColor = System.Drawing.Color.White;
            this.btnCancelarPMF.Location = new System.Drawing.Point(547, 103);
            this.btnCancelarPMF.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelarPMF.Name = "btnCancelarPMF";
            this.btnCancelarPMF.Size = new System.Drawing.Size(138, 42);
            this.btnCancelarPMF.TabIndex = 49;
            this.btnCancelarPMF.Text = "Cancelar";
            this.btnCancelarPMF.UseVisualStyleBackColor = false;
            this.btnCancelarPMF.Click += new System.EventHandler(this.btnCancelarPMF_Click);
            // 
            // cbFamilia
            // 
            this.cbFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFamilia.FormattingEnabled = true;
            this.cbFamilia.Location = new System.Drawing.Point(135, 91);
            this.cbFamilia.Name = "cbFamilia";
            this.cbFamilia.Size = new System.Drawing.Size(405, 24);
            this.cbFamilia.TabIndex = 47;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Familia";
            // 
            // cbMarca
            // 
            this.cbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(135, 61);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(405, 24);
            this.cbMarca.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 45;
            this.label3.Text = "Marca";
            // 
            // dgvExcelInexistentes
            // 
            this.dgvExcelInexistentes.AllowUserToAddRows = false;
            this.dgvExcelInexistentes.AllowUserToDeleteRows = false;
            this.dgvExcelInexistentes.AllowUserToOrderColumns = true;
            this.dgvExcelInexistentes.AllowUserToResizeRows = false;
            this.dgvExcelInexistentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvExcelInexistentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcelInexistentes.Location = new System.Drawing.Point(6, 6);
            this.dgvExcelInexistentes.Name = "dgvExcelInexistentes";
            this.dgvExcelInexistentes.ReadOnly = true;
            this.dgvExcelInexistentes.RowHeadersWidth = 51;
            this.dgvExcelInexistentes.RowTemplate.Height = 24;
            this.dgvExcelInexistentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExcelInexistentes.Size = new System.Drawing.Size(897, 263);
            this.dgvExcelInexistentes.TabIndex = 18;
            // 
            // cbProveedor
            // 
            this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(123, 25);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(405, 24);
            this.cbProveedor.TabIndex = 34;
            this.cbProveedor.SelectionChangeCommitted += new System.EventHandler(this.cbProveedor_SelectionChangeCommitted);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(14, 25);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(74, 17);
            this.lblProveedor.TabIndex = 35;
            this.lblProveedor.Text = "Proveedor";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvDatosErroneos);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(909, 458);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Datos Erroneos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvDatosErroneos
            // 
            this.dgvDatosErroneos.AllowUserToAddRows = false;
            this.dgvDatosErroneos.AllowUserToDeleteRows = false;
            this.dgvDatosErroneos.AllowUserToOrderColumns = true;
            this.dgvDatosErroneos.AllowUserToResizeRows = false;
            this.dgvDatosErroneos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDatosErroneos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosErroneos.Location = new System.Drawing.Point(3, 3);
            this.dgvDatosErroneos.Name = "dgvDatosErroneos";
            this.dgvDatosErroneos.ReadOnly = true;
            this.dgvDatosErroneos.RowHeadersWidth = 51;
            this.dgvDatosErroneos.RowTemplate.Height = 24;
            this.dgvDatosErroneos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatosErroneos.Size = new System.Drawing.Size(897, 263);
            this.dgvDatosErroneos.TabIndex = 19;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Firebrick;
            this.btnExcel.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnExcel.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnExcel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(595, 17);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(267, 38);
            this.btnExcel.TabIndex = 36;
            this.btnExcel.Text = "Abrir template excel para cargar datos";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnEliminarFilas
            // 
            this.btnEliminarFilas.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminarFilas.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFilas.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFilas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFilas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarFilas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFilas.ForeColor = System.Drawing.Color.White;
            this.btnEliminarFilas.Location = new System.Drawing.Point(547, 153);
            this.btnEliminarFilas.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarFilas.Name = "btnEliminarFilas";
            this.btnEliminarFilas.Size = new System.Drawing.Size(138, 42);
            this.btnEliminarFilas.TabIndex = 52;
            this.btnEliminarFilas.Text = "Eliminar Fila/s";
            this.btnEliminarFilas.UseVisualStyleBackColor = false;
            this.btnEliminarFilas.Click += new System.EventHandler(this.btnEliminarFilas_Click);
            // 
            // frmImportarExcelProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(942, 715);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtArchivoExcel);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCancelarSeleccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmImportarExcelProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Excel";
            this.Load += new System.EventHandler(this.frmImportarExcel_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelExistentes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panelSeteoPMF.ResumeLayout(false);
            this.panelSeteoPMF.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcelInexistentes)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosErroneos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnCancelarSeleccion;
        private System.Windows.Forms.TextBox txtArchivoExcel;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Button btnImportar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvExcelExistentes;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvExcelInexistentes;
        private System.Windows.Forms.Panel panelSeteoPMF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnCancelarPMF;
        private System.Windows.Forms.ComboBox cbFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvDatosErroneos;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnEliminarFilas;
    }
}