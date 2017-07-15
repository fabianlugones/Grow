namespace SinergiaApp
{
    partial class frmCostosReposicioncs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCostosReposicioncs));
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo_total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cant_acum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo_acum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_u_u_p = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtCostoRec = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.btnIngresarArticulo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbFiltroProductos = new System.Windows.Forms.ComboBox();
            this.lblCostRep = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnHistoricos = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.AllowUserToAddRows = false;
            this.dgvArticulos.AllowUserToDeleteRows = false;
            this.dgvArticulos.BackgroundColor = System.Drawing.Color.White;
            this.dgvArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.ID,
            this.Nombre,
            this.Cantidad,
            this.Costo_unitario,
            this.Costo_total,
            this.cant_acum,
            this.Costo_acum,
            this.c_u_u_p});
            this.dgvArticulos.Location = new System.Drawing.Point(23, 75);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.ReadOnly = true;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvArticulos.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvArticulos.Size = new System.Drawing.Size(1152, 480);
            this.dgvArticulos.TabIndex = 1;
            this.dgvArticulos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArticulos_CellClick);
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.ID.FillWeight = 50F;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle2;
            this.Nombre.FillWeight = 350F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 350;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Costo_unitario
            // 
            this.Costo_unitario.DataPropertyName = "Costo_unitario";
            this.Costo_unitario.HeaderText = "Costo Unitario ($)";
            this.Costo_unitario.Name = "Costo_unitario";
            this.Costo_unitario.ReadOnly = true;
            // 
            // Costo_total
            // 
            this.Costo_total.DataPropertyName = "Costo_total";
            this.Costo_total.HeaderText = "Costo Total ($)";
            this.Costo_total.Name = "Costo_total";
            this.Costo_total.ReadOnly = true;
            // 
            // cant_acum
            // 
            this.cant_acum.DataPropertyName = "Cantidad_acumulada";
            this.cant_acum.HeaderText = "Cantidad Acumulada";
            this.cant_acum.Name = "cant_acum";
            this.cant_acum.ReadOnly = true;
            // 
            // Costo_acum
            // 
            this.Costo_acum.DataPropertyName = "Costo_total_sin_rep";
            this.Costo_acum.HeaderText = "Costo acumulado ($)";
            this.Costo_acum.Name = "Costo_acum";
            this.Costo_acum.ReadOnly = true;
            // 
            // c_u_u_p
            // 
            this.c_u_u_p.DataPropertyName = "C_U_P_P";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.c_u_u_p.DefaultCellStyle = dataGridViewCellStyle3;
            this.c_u_u_p.HeaderText = "C.U.U.P ($)";
            this.c_u_u_p.Name = "c_u_u_p";
            this.c_u_u_p.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Estos valores pertenecen a los valores actualizados a la última compra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(298, 597);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Costo de reposición:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 597);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Id Artículo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(626, 597);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Fecha:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(111, 590);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(181, 21);
            this.txtId.TabIndex = 7;
            // 
            // txtCostoRec
            // 
            this.txtCostoRec.Location = new System.Drawing.Point(458, 590);
            this.txtCostoRec.Name = "txtCostoRec";
            this.txtCostoRec.Size = new System.Drawing.Size(162, 21);
            this.txtCostoRec.TabIndex = 8;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(677, 589);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(181, 21);
            this.txtFecha.TabIndex = 9;
            // 
            // btnIngresarArticulo
            // 
            this.btnIngresarArticulo.BackColor = System.Drawing.Color.White;
            this.btnIngresarArticulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresarArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnIngresarArticulo.Image")));
            this.btnIngresarArticulo.Location = new System.Drawing.Point(864, 576);
            this.btnIngresarArticulo.Name = "btnIngresarArticulo";
            this.btnIngresarArticulo.Size = new System.Drawing.Size(84, 46);
            this.btnIngresarArticulo.TabIndex = 10;
            this.btnIngresarArticulo.UseVisualStyleBackColor = false;
            this.btnIngresarArticulo.Click += new System.EventHandler(this.btnIngresarArticulo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 14);
            this.label6.TabIndex = 101;
            this.label6.Text = "Buscar por nombre o id";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(437, 597);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 14);
            this.label7.TabIndex = 103;
            this.label7.Text = "$";
            // 
            // cmbFiltroProductos
            // 
            this.cmbFiltroProductos.FormattingEnabled = true;
            this.cmbFiltroProductos.Location = new System.Drawing.Point(188, 44);
            this.cmbFiltroProductos.Name = "cmbFiltroProductos";
            this.cmbFiltroProductos.Size = new System.Drawing.Size(250, 22);
            this.cmbFiltroProductos.TabIndex = 105;
            this.cmbFiltroProductos.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroProductos_SelectedIndexChanged);
            // 
            // lblCostRep
            // 
            this.lblCostRep.AutoSize = true;
            this.lblCostRep.Location = new System.Drawing.Point(906, 44);
            this.lblCostRep.Name = "lblCostRep";
            this.lblCostRep.Size = new System.Drawing.Size(217, 14);
            this.lblCostRep.TabIndex = 106;
            this.lblCostRep.Text = "COSTO DE REPOSICIÓN ACTUAL:$";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 14);
            this.label2.TabIndex = 107;
            this.label2.Text = "Desde";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(638, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 108;
            this.label8.Text = "Hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(502, 42);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(130, 21);
            this.dtpDesde.TabIndex = 109;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(686, 41);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(130, 21);
            this.dtpHasta.TabIndex = 110;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(822, 41);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(78, 21);
            this.btnFiltrar.TabIndex = 111;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnHistoricos
            // 
            this.btnHistoricos.BackColor = System.Drawing.Color.White;
            this.btnHistoricos.Location = new System.Drawing.Point(1198, 40);
            this.btnHistoricos.Name = "btnHistoricos";
            this.btnHistoricos.Size = new System.Drawing.Size(78, 21);
            this.btnHistoricos.TabIndex = 112;
            this.btnHistoricos.Text = "Historicos";
            this.btnHistoricos.UseVisualStyleBackColor = false;
            this.btnHistoricos.Click += new System.EventHandler(this.btnHistoricos_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.White;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(1208, 122);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(87, 51);
            this.btnExcel.TabIndex = 113;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1208, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 92);
            this.button1.TabIndex = 114;
            this.button1.Text = "Reporte historico de % y Costos";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmCostosReposicioncs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1307, 678);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnHistoricos);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCostRep);
            this.Controls.Add(this.cmbFiltroProductos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnIngresarArticulo);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtCostoRec);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvArticulos);
            this.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmCostosReposicioncs";
            this.Text = "frmCostosReposicioncs";
            this.Load += new System.EventHandler(this.frmCostosReposicioncs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtCostoRec;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Button btnIngresarArticulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbFiltroProductos;
        private System.Windows.Forms.Label lblCostRep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnHistoricos;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn cant_acum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo_acum;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_u_u_p;
        private System.Windows.Forms.Button button1;
    }
}