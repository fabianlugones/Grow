namespace SinergiaApp
{
    partial class frmGestionStock
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPositivo = new System.Windows.Forms.RadioButton();
            this.rbNegativo = new System.Windows.Forms.RadioButton();
            this.chbColores = new System.Windows.Forms.CheckBox();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.chbTiempo = new System.Windows.Forms.CheckBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.Id_Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Movimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaMov = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbPositivo);
            this.groupBox1.Controls.Add(this.rbNegativo);
            this.groupBox1.Controls.Add(this.chbColores);
            this.groupBox1.Controls.Add(this.txtArticulo);
            this.groupBox1.Controls.Add(this.chbTiempo);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgvMovimientos);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1151, 701);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "MOVIMIENTO DE STOCK";
            // 
            // rbPositivo
            // 
            this.rbPositivo.AutoSize = true;
            this.rbPositivo.Location = new System.Drawing.Point(865, 55);
            this.rbPositivo.Name = "rbPositivo";
            this.rbPositivo.Size = new System.Drawing.Size(258, 19);
            this.rbPositivo.TabIndex = 8;
            this.rbPositivo.TabStop = true;
            this.rbPositivo.Text = "Solo movimientos positivos de stock";
            this.rbPositivo.UseVisualStyleBackColor = true;
            this.rbPositivo.CheckedChanged += new System.EventHandler(this.rbPositivo_CheckedChanged);
            // 
            // rbNegativo
            // 
            this.rbNegativo.AutoSize = true;
            this.rbNegativo.Location = new System.Drawing.Point(865, 33);
            this.rbNegativo.Name = "rbNegativo";
            this.rbNegativo.Size = new System.Drawing.Size(261, 19);
            this.rbNegativo.TabIndex = 7;
            this.rbNegativo.TabStop = true;
            this.rbNegativo.Text = "Solo movimientos negativos de stock";
            this.rbNegativo.UseVisualStyleBackColor = true;
            this.rbNegativo.CheckedChanged += new System.EventHandler(this.rbNegativo_CheckedChanged);
            // 
            // chbColores
            // 
            this.chbColores.AutoSize = true;
            this.chbColores.Location = new System.Drawing.Point(6, 516);
            this.chbColores.Name = "chbColores";
            this.chbColores.Size = new System.Drawing.Size(169, 19);
            this.chbColores.TabIndex = 6;
            this.chbColores.Text = "Quitar colores de tabla";
            this.chbColores.UseVisualStyleBackColor = true;
            this.chbColores.CheckedChanged += new System.EventHandler(this.chbColores_CheckedChanged);
            // 
            // txtArticulo
            // 
            this.txtArticulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtArticulo.Location = new System.Drawing.Point(150, 45);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(330, 23);
            this.txtArticulo.TabIndex = 5;
            this.txtArticulo.TextChanged += new System.EventHandler(this.txtArticulo_TextChanged);
            // 
            // chbTiempo
            // 
            this.chbTiempo.AutoSize = true;
            this.chbTiempo.Location = new System.Drawing.Point(486, 47);
            this.chbTiempo.Name = "chbTiempo";
            this.chbTiempo.Size = new System.Drawing.Size(116, 19);
            this.chbTiempo.TabIndex = 4;
            this.chbTiempo.Text = "Desde / Hasta";
            this.chbTiempo.UseVisualStyleBackColor = true;
            this.chbTiempo.CheckedChanged += new System.EventHandler(this.chbTiempo_CheckedChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(731, 46);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(119, 23);
            this.dtpHasta.TabIndex = 3;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(608, 46);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(117, 23);
            this.dtpDesde.TabIndex = 2;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del artículo:";
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Articulo,
            this.Descripcion,
            this.Movimiento,
            this.FechaMov,
            this.Signo});
            this.dgvMovimientos.Location = new System.Drawing.Point(6, 76);
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dgvMovimientos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMovimientos.Size = new System.Drawing.Size(1095, 434);
            this.dgvMovimientos.TabIndex = 0;
            this.dgvMovimientos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMovimientos_CellFormatting);
            // 
            // Id_Articulo
            // 
            this.Id_Articulo.DataPropertyName = "ID";
            this.Id_Articulo.FillWeight = 150F;
            this.Id_Articulo.HeaderText = "ID Articulo";
            this.Id_Articulo.Name = "Id_Articulo";
            this.Id_Articulo.ReadOnly = true;
            this.Id_Articulo.Width = 150;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Nombre";
            this.Descripcion.FillWeight = 300F;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 300;
            // 
            // Movimiento
            // 
            this.Movimiento.DataPropertyName = "Descripcion";
            this.Movimiento.FillWeight = 500F;
            this.Movimiento.HeaderText = "Movimiento";
            this.Movimiento.Name = "Movimiento";
            this.Movimiento.ReadOnly = true;
            this.Movimiento.Width = 500;
            // 
            // FechaMov
            // 
            this.FechaMov.DataPropertyName = "Fecha_movimiento";
            this.FechaMov.HeaderText = "Fecha";
            this.FechaMov.Name = "FechaMov";
            this.FechaMov.ReadOnly = true;
            // 
            // Signo
            // 
            this.Signo.DataPropertyName = "Signo";
            this.Signo.HeaderText = "Signo Movimiento";
            this.Signo.Name = "Signo";
            this.Signo.ReadOnly = true;
            // 
            // frmGestionStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1362, 721);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmGestionStock";
            this.Text = "frmGestionStock";
            this.Load += new System.EventHandler(this.frmGestionStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPositivo;
        private System.Windows.Forms.RadioButton rbNegativo;
        private System.Windows.Forms.CheckBox chbColores;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.CheckBox chbTiempo;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Movimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaMov;
        private System.Windows.Forms.DataGridViewTextBoxColumn Signo;

    }
}