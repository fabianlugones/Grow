namespace SinergiaApp
{
    partial class frmMovimientosRegistradora
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMovimientosRegistradora));
            this.dgvCajaDelDia = new System.Windows.Forms.DataGridView();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Egreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCierre = new System.Windows.Forms.Label();
            this.lblHoraApertura = new System.Windows.Forms.Label();
            this.lblSaldoInicial = new System.Windows.Forms.Label();
            this.lblFinalCalculado = new System.Windows.Forms.Label();
            this.lblFinalReal = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lblComentario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaDelDia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCajaDelDia
            // 
            this.dgvCajaDelDia.AllowUserToAddRows = false;
            this.dgvCajaDelDia.AllowUserToDeleteRows = false;
            this.dgvCajaDelDia.BackgroundColor = System.Drawing.Color.White;
            this.dgvCajaDelDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajaDelDia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hora,
            this.Concepto,
            this.Monto,
            this.Egreso});
            this.dgvCajaDelDia.Location = new System.Drawing.Point(75, 140);
            this.dgvCajaDelDia.Name = "dgvCajaDelDia";
            this.dgvCajaDelDia.Size = new System.Drawing.Size(846, 301);
            this.dgvCajaDelDia.TabIndex = 5;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "Hora";
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "Concepto";
            this.Concepto.FillWeight = 500F;
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 500;
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Ingreso";
            this.Monto.HeaderText = "Ingreso ($)";
            this.Monto.Name = "Monto";
            // 
            // Egreso
            // 
            this.Egreso.DataPropertyName = "Egreso";
            this.Egreso.HeaderText = "Egreso ($)";
            this.Egreso.Name = "Egreso";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(29, 9);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(45, 15);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "label1";
            // 
            // lblCierre
            // 
            this.lblCierre.AutoSize = true;
            this.lblCierre.Location = new System.Drawing.Point(692, 9);
            this.lblCierre.Name = "lblCierre";
            this.lblCierre.Size = new System.Drawing.Size(45, 15);
            this.lblCierre.TabIndex = 7;
            this.lblCierre.Text = "label2";
            // 
            // lblHoraApertura
            // 
            this.lblHoraApertura.AutoSize = true;
            this.lblHoraApertura.Location = new System.Drawing.Point(357, 9);
            this.lblHoraApertura.Name = "lblHoraApertura";
            this.lblHoraApertura.Size = new System.Drawing.Size(45, 15);
            this.lblHoraApertura.TabIndex = 8;
            this.lblHoraApertura.Text = "label3";
            // 
            // lblSaldoInicial
            // 
            this.lblSaldoInicial.AutoSize = true;
            this.lblSaldoInicial.Location = new System.Drawing.Point(29, 57);
            this.lblSaldoInicial.Name = "lblSaldoInicial";
            this.lblSaldoInicial.Size = new System.Drawing.Size(45, 15);
            this.lblSaldoInicial.TabIndex = 9;
            this.lblSaldoInicial.Text = "label4";
            // 
            // lblFinalCalculado
            // 
            this.lblFinalCalculado.AutoSize = true;
            this.lblFinalCalculado.Location = new System.Drawing.Point(357, 57);
            this.lblFinalCalculado.Name = "lblFinalCalculado";
            this.lblFinalCalculado.Size = new System.Drawing.Size(45, 15);
            this.lblFinalCalculado.TabIndex = 10;
            this.lblFinalCalculado.Text = "label5";
            // 
            // lblFinalReal
            // 
            this.lblFinalReal.AutoSize = true;
            this.lblFinalReal.Location = new System.Drawing.Point(692, 57);
            this.lblFinalReal.Name = "lblFinalReal";
            this.lblFinalReal.Size = new System.Drawing.Size(45, 15);
            this.lblFinalReal.TabIndex = 11;
            this.lblFinalReal.Text = "label6";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(29, 109);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(45, 15);
            this.lblUsuario.TabIndex = 12;
            this.lblUsuario.Text = "label7";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.White;
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Location = new System.Drawing.Point(719, 447);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(202, 42);
            this.btnExcel.TabIndex = 13;
            this.btnExcel.Text = "EXPORTAR A EXCEL";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lblComentario
            // 
            this.lblComentario.AutoSize = true;
            this.lblComentario.Location = new System.Drawing.Point(357, 109);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(45, 15);
            this.lblComentario.TabIndex = 14;
            this.lblComentario.Text = "label5";
            // 
            // frmMovimientosRegistradora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 495);
            this.Controls.Add(this.lblComentario);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblFinalReal);
            this.Controls.Add(this.lblFinalCalculado);
            this.Controls.Add(this.lblSaldoInicial);
            this.Controls.Add(this.lblHoraApertura);
            this.Controls.Add(this.lblCierre);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dgvCajaDelDia);
            this.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMovimientosRegistradora";
            this.Text = "frmMovimientosRegistradora";
            this.Load += new System.EventHandler(this.frmMovimientosRegistradora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaDelDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCajaDelDia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Egreso;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCierre;
        private System.Windows.Forms.Label lblHoraApertura;
        private System.Windows.Forms.Label lblSaldoInicial;
        private System.Windows.Forms.Label lblFinalCalculado;
        private System.Windows.Forms.Label lblFinalReal;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblComentario;
    }
}