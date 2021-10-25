namespace Modulo_Administracion.Vista
{
    partial class frmCliente_Cuenta_Corriente
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelVer = new System.Windows.Forms.Panel();
            this.rdTodos = new System.Windows.Forms.RadioButton();
            this.rdDeuda = new System.Windows.Forms.RadioButton();
            this.btnEliminarFila = new System.Windows.Forms.Button();
            this.btnAgregarMovimiento = new System.Windows.Forms.Button();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelPrincipal.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelVer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPrincipal.Controls.Add(this.panelFooter);
            this.panelPrincipal.Controls.Add(this.gridControl1);
            this.panelPrincipal.Location = new System.Drawing.Point(12, 3);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1091, 553);
            this.panelPrincipal.TabIndex = 83;
            // 
            // panelFooter
            // 
            this.panelFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFooter.Controls.Add(this.panelVer);
            this.panelFooter.Controls.Add(this.btnEliminarFila);
            this.panelFooter.Controls.Add(this.btnAgregarMovimiento);
            this.panelFooter.Controls.Add(this.btnGenerarReporte);
            this.panelFooter.Controls.Add(this.btnGrabar);
            this.panelFooter.Controls.Add(this.btnSalir);
            this.panelFooter.Location = new System.Drawing.Point(13, 467);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1065, 83);
            this.panelFooter.TabIndex = 88;
            // 
            // panelVer
            // 
            this.panelVer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelVer.Controls.Add(this.rdTodos);
            this.panelVer.Controls.Add(this.rdDeuda);
            this.panelVer.Location = new System.Drawing.Point(405, 9);
            this.panelVer.Name = "panelVer";
            this.panelVer.Size = new System.Drawing.Size(227, 55);
            this.panelVer.TabIndex = 128;
            // 
            // rdTodos
            // 
            this.rdTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdTodos.AutoSize = true;
            this.rdTodos.Location = new System.Drawing.Point(135, 20);
            this.rdTodos.Name = "rdTodos";
            this.rdTodos.Size = new System.Drawing.Size(77, 21);
            this.rdTodos.TabIndex = 129;
            this.rdTodos.TabStop = true;
            this.rdTodos.Text = "TODAS";
            this.rdTodos.UseVisualStyleBackColor = true;
            this.rdTodos.CheckedChanged += new System.EventHandler(this.rdTodos_CheckedChanged);
            // 
            // rdDeuda
            // 
            this.rdDeuda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdDeuda.AutoSize = true;
            this.rdDeuda.Location = new System.Drawing.Point(15, 20);
            this.rdDeuda.Name = "rdDeuda";
            this.rdDeuda.Size = new System.Drawing.Size(114, 21);
            this.rdDeuda.TabIndex = 128;
            this.rdDeuda.TabStop = true;
            this.rdDeuda.Text = "ADEUDADAS";
            this.rdDeuda.UseVisualStyleBackColor = true;
            this.rdDeuda.CheckedChanged += new System.EventHandler(this.rdDeuda_CheckedChanged);
            // 
            // btnEliminarFila
            // 
            this.btnEliminarFila.BackColor = System.Drawing.Color.OrangeRed;
            this.btnEliminarFila.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnEliminarFila.FlatAppearance.CheckedBackColor = System.Drawing.Color.Orange;
            this.btnEliminarFila.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnEliminarFila.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnEliminarFila.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFila.ForeColor = System.Drawing.Color.White;
            this.btnEliminarFila.Location = new System.Drawing.Point(164, 9);
            this.btnEliminarFila.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminarFila.Name = "btnEliminarFila";
            this.btnEliminarFila.Size = new System.Drawing.Size(154, 42);
            this.btnEliminarFila.TabIndex = 125;
            this.btnEliminarFila.Text = "Eliminar Movimiento";
            this.btnEliminarFila.UseVisualStyleBackColor = false;
            this.btnEliminarFila.Click += new System.EventHandler(this.btnEliminarMovimiento_Click);
            // 
            // btnAgregarMovimiento
            // 
            this.btnAgregarMovimiento.BackColor = System.Drawing.Color.OrangeRed;
            this.btnAgregarMovimiento.FlatAppearance.BorderColor = System.Drawing.Color.Orange;
            this.btnAgregarMovimiento.FlatAppearance.CheckedBackColor = System.Drawing.Color.Orange;
            this.btnAgregarMovimiento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Orange;
            this.btnAgregarMovimiento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Orange;
            this.btnAgregarMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMovimiento.ForeColor = System.Drawing.Color.White;
            this.btnAgregarMovimiento.Location = new System.Drawing.Point(4, 9);
            this.btnAgregarMovimiento.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarMovimiento.Name = "btnAgregarMovimiento";
            this.btnAgregarMovimiento.Size = new System.Drawing.Size(152, 42);
            this.btnAgregarMovimiento.TabIndex = 124;
            this.btnAgregarMovimiento.Text = "Agregar Movimiento";
            this.btnAgregarMovimiento.UseVisualStyleBackColor = false;
            this.btnAgregarMovimiento.Click += new System.EventHandler(this.btnAgregarMovimiento_Click);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarReporte.BackColor = System.Drawing.Color.Firebrick;
            this.btnGenerarReporte.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnGenerarReporte.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnGenerarReporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnGenerarReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnGenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporte.ForeColor = System.Drawing.Color.White;
            this.btnGenerarReporte.Location = new System.Drawing.Point(649, 9);
            this.btnGenerarReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(138, 42);
            this.btnGenerarReporte.TabIndex = 122;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.BackColor = System.Drawing.Color.Firebrick;
            this.btnGrabar.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnGrabar.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnGrabar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrabar.ForeColor = System.Drawing.Color.White;
            this.btnGrabar.Location = new System.Drawing.Point(795, 9);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(138, 42);
            this.btnGrabar.TabIndex = 85;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.Firebrick;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.CheckedBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.IndianRed;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(941, 9);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(111, 42);
            this.btnSalir.TabIndex = 84;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(13, 9);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1065, 452);
            this.gridControl1.TabIndex = 87;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.EditorKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gridControl1_EditorKeyPress);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // frmCliente_Cuenta_Corriente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 568);
            this.Controls.Add(this.panelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCliente_Cuenta_Corriente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCliente_Cuenta_Corriente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCliente_Cuenta_Corriente_FormClosing);
            this.panelPrincipal.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelVer.ResumeLayout(false);
            this.panelVer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelFooter;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Button btnAgregarMovimiento;
        private System.Windows.Forms.Button btnEliminarFila;
        private System.Windows.Forms.Panel panelVer;
        private System.Windows.Forms.RadioButton rdTodos;
        private System.Windows.Forms.RadioButton rdDeuda;
    }
}