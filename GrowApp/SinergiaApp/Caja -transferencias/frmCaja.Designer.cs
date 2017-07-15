namespace SinergiaApp
{
    partial class frmCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaja));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTransferencias = new System.Windows.Forms.Button();
            this.btnDeposito = new System.Windows.Forms.Button();
            this.btnRetiro = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCajaDelDia = new System.Windows.Forms.DataGridView();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Egreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtHorarioApertura = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCierre = new System.Windows.Forms.Button();
            this.txtSaldoEnCaja = new System.Windows.Forms.TextBox();
            this.txtSaldoCierreCalculado = new System.Windows.Forms.TextBox();
            this.btnApertura = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSaldoApertura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpCajas = new System.Windows.Forms.GroupBox();
            this.btnBuscarCajas = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnVerMovimientos = new System.Windows.Forms.Button();
            this.dgvCajasHistoricas = new System.Windows.Forms.DataGridView();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apertura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cierre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CierreC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CierreCal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaDelDia)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gpCajas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajasHistoricas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTransferencias);
            this.groupBox1.Controls.Add(this.btnDeposito);
            this.groupBox1.Controls.Add(this.btnRetiro);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dgvCajaDelDia);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1174, 378);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CAJA DE HOY";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnTransferencias
            // 
            this.btnTransferencias.BackColor = System.Drawing.Color.White;
            this.btnTransferencias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTransferencias.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferencias.Location = new System.Drawing.Point(720, 347);
            this.btnTransferencias.Name = "btnTransferencias";
            this.btnTransferencias.Size = new System.Drawing.Size(227, 25);
            this.btnTransferencias.TabIndex = 12;
            this.btnTransferencias.Text = "TRANFERENCIAS";
            this.btnTransferencias.UseVisualStyleBackColor = false;
            this.btnTransferencias.Click += new System.EventHandler(this.btnTransferencias_Click);
            // 
            // btnDeposito
            // 
            this.btnDeposito.BackColor = System.Drawing.Color.White;
            this.btnDeposito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDeposito.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposito.Location = new System.Drawing.Point(254, 347);
            this.btnDeposito.Name = "btnDeposito";
            this.btnDeposito.Size = new System.Drawing.Size(227, 25);
            this.btnDeposito.TabIndex = 11;
            this.btnDeposito.Text = "DEPÓSITOS";
            this.btnDeposito.UseVisualStyleBackColor = false;
            this.btnDeposito.Click += new System.EventHandler(this.btnDeposito_Click);
            // 
            // btnRetiro
            // 
            this.btnRetiro.BackColor = System.Drawing.Color.White;
            this.btnRetiro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetiro.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetiro.Location = new System.Drawing.Point(487, 347);
            this.btnRetiro.Name = "btnRetiro";
            this.btnRetiro.Size = new System.Drawing.Size(227, 25);
            this.btnRetiro.TabIndex = 10;
            this.btnRetiro.Text = "RETIROS";
            this.btnRetiro.UseVisualStyleBackColor = false;
            this.btnRetiro.Click += new System.EventHandler(this.btnRetiro_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Movimientos de esta sesión";
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
            this.dgvCajaDelDia.Location = new System.Drawing.Point(257, 40);
            this.dgvCajaDelDia.Name = "dgvCajaDelDia";
            this.dgvCajaDelDia.Size = new System.Drawing.Size(843, 301);
            this.dgvCajaDelDia.TabIndex = 4;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtComentario);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtHorarioApertura);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnCierre);
            this.groupBox2.Controls.Add(this.txtSaldoEnCaja);
            this.groupBox2.Controls.Add(this.txtSaldoCierreCalculado);
            this.groupBox2.Controls.Add(this.btnApertura);
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSaldoApertura);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(242, 332);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "APERTURA / CIERRE";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtHorarioApertura
            // 
            this.txtHorarioApertura.Location = new System.Drawing.Point(136, 127);
            this.txtHorarioApertura.Name = "txtHorarioApertura";
            this.txtHorarioApertura.ReadOnly = true;
            this.txtHorarioApertura.Size = new System.Drawing.Size(100, 23);
            this.txtHorarioApertura.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Horario Apertura:";
            // 
            // btnCierre
            // 
            this.btnCierre.BackColor = System.Drawing.Color.White;
            this.btnCierre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCierre.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCierre.Location = new System.Drawing.Point(6, 293);
            this.btnCierre.Name = "btnCierre";
            this.btnCierre.Size = new System.Drawing.Size(227, 33);
            this.btnCierre.TabIndex = 9;
            this.btnCierre.Text = "CIERRE DE CAJA";
            this.btnCierre.UseVisualStyleBackColor = false;
            this.btnCierre.Click += new System.EventHandler(this.btnCierre_Click);
            // 
            // txtSaldoEnCaja
            // 
            this.txtSaldoEnCaja.Location = new System.Drawing.Point(136, 190);
            this.txtSaldoEnCaja.Name = "txtSaldoEnCaja";
            this.txtSaldoEnCaja.Size = new System.Drawing.Size(100, 23);
            this.txtSaldoEnCaja.TabIndex = 8;
            // 
            // txtSaldoCierreCalculado
            // 
            this.txtSaldoCierreCalculado.Location = new System.Drawing.Point(136, 158);
            this.txtSaldoCierreCalculado.Name = "txtSaldoCierreCalculado";
            this.txtSaldoCierreCalculado.ReadOnly = true;
            this.txtSaldoCierreCalculado.Size = new System.Drawing.Size(100, 23);
            this.txtSaldoCierreCalculado.TabIndex = 7;
            // 
            // btnApertura
            // 
            this.btnApertura.BackColor = System.Drawing.Color.White;
            this.btnApertura.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApertura.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApertura.Location = new System.Drawing.Point(9, 81);
            this.btnApertura.Name = "btnApertura";
            this.btnApertura.Size = new System.Drawing.Size(227, 33);
            this.btnApertura.TabIndex = 4;
            this.btnApertura.Text = "APERTURA DE CAJA";
            this.btnApertura.UseVisualStyleBackColor = false;
            this.btnApertura.Click += new System.EventHandler(this.btnApertura_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(71, 52);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(165, 23);
            this.txtUsuario.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Usuario:";
            // 
            // txtSaldoApertura
            // 
            this.txtSaldoApertura.Location = new System.Drawing.Point(136, 26);
            this.txtSaldoApertura.Name = "txtSaldoApertura";
            this.txtSaldoApertura.ReadOnly = true;
            this.txtSaldoApertura.Size = new System.Drawing.Size(100, 23);
            this.txtSaldoApertura.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Saldo de sistema:  $";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Saldo en caja:        $";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo de Apertura:$";
            // 
            // gpCajas
            // 
            this.gpCajas.Controls.Add(this.btnBuscarCajas);
            this.gpCajas.Controls.Add(this.label8);
            this.gpCajas.Controls.Add(this.label6);
            this.gpCajas.Controls.Add(this.dtpHasta);
            this.gpCajas.Controls.Add(this.dtpDesde);
            this.gpCajas.Controls.Add(this.label3);
            this.gpCajas.Controls.Add(this.btnVerMovimientos);
            this.gpCajas.Controls.Add(this.dgvCajasHistoricas);
            this.gpCajas.Location = new System.Drawing.Point(12, 396);
            this.gpCajas.Name = "gpCajas";
            this.gpCajas.Size = new System.Drawing.Size(1174, 243);
            this.gpCajas.TabIndex = 1;
            this.gpCajas.TabStop = false;
            this.gpCajas.Text = "BUSCAR CAJAS ANTIGUAS";
            // 
            // btnBuscarCajas
            // 
            this.btnBuscarCajas.BackColor = System.Drawing.Color.White;
            this.btnBuscarCajas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarCajas.FlatAppearance.BorderSize = 0;
            this.btnBuscarCajas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarCajas.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCajas.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCajas.Image")));
            this.btnBuscarCajas.Location = new System.Drawing.Point(15, 162);
            this.btnBuscarCajas.Name = "btnBuscarCajas";
            this.btnBuscarCajas.Size = new System.Drawing.Size(89, 43);
            this.btnBuscarCajas.TabIndex = 15;
            this.btnBuscarCajas.UseVisualStyleBackColor = false;
            this.btnBuscarCajas.Click += new System.EventHandler(this.btnBuscarCajas_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Desde:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(15, 133);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(104, 23);
            this.dtpHasta.TabIndex = 12;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(15, 82);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(104, 23);
            this.dtpDesde.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Seleccionar rango de fechas";
            // 
            // btnVerMovimientos
            // 
            this.btnVerMovimientos.BackColor = System.Drawing.Color.White;
            this.btnVerMovimientos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerMovimientos.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerMovimientos.Location = new System.Drawing.Point(870, 203);
            this.btnVerMovimientos.Name = "btnVerMovimientos";
            this.btnVerMovimientos.Size = new System.Drawing.Size(227, 33);
            this.btnVerMovimientos.TabIndex = 10;
            this.btnVerMovimientos.Text = "VER EN DETALLE";
            this.btnVerMovimientos.UseVisualStyleBackColor = false;
            this.btnVerMovimientos.Click += new System.EventHandler(this.btnVerMovimientos_Click);
            // 
            // dgvCajasHistoricas
            // 
            this.dgvCajasHistoricas.AllowUserToAddRows = false;
            this.dgvCajasHistoricas.AllowUserToDeleteRows = false;
            this.dgvCajasHistoricas.BackgroundColor = System.Drawing.Color.White;
            this.dgvCajasHistoricas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajasHistoricas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Apertura,
            this.Cierre,
            this.Usuario,
            this.MontoInicial,
            this.CierreC,
            this.CierreCal});
            this.dgvCajasHistoricas.Location = new System.Drawing.Point(213, 33);
            this.dgvCajasHistoricas.Name = "dgvCajasHistoricas";
            this.dgvCajasHistoricas.Size = new System.Drawing.Size(955, 164);
            this.dgvCajasHistoricas.TabIndex = 0;
            this.dgvCajasHistoricas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCajasHistoricas_CellClick);
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Apertura
            // 
            this.Apertura.DataPropertyName = "HoraMinutosApertura";
            this.Apertura.FillWeight = 120F;
            this.Apertura.HeaderText = "Apertura";
            this.Apertura.Name = "Apertura";
            this.Apertura.Width = 120;
            // 
            // Cierre
            // 
            this.Cierre.DataPropertyName = "HoraMinutosCierre";
            this.Cierre.FillWeight = 120F;
            this.Cierre.HeaderText = "Cierre";
            this.Cierre.Name = "Cierre";
            this.Cierre.Width = 120;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            // 
            // MontoInicial
            // 
            this.MontoInicial.DataPropertyName = "Dinero_inicial";
            this.MontoInicial.FillWeight = 150F;
            this.MontoInicial.HeaderText = "Inicial ($)";
            this.MontoInicial.Name = "MontoInicial";
            this.MontoInicial.Width = 150;
            // 
            // CierreC
            // 
            this.CierreC.DataPropertyName = "Dinero_en_caja_ciere";
            this.CierreC.FillWeight = 150F;
            this.CierreC.HeaderText = "Cierre Real ($)";
            this.CierreC.Name = "CierreC";
            this.CierreC.Width = 150;
            // 
            // CierreCal
            // 
            this.CierreCal.DataPropertyName = "Dinero_en_caja_calculado";
            this.CierreCal.FillWeight = 165F;
            this.CierreCal.HeaderText = "Cierre Calculado ($)";
            this.CierreCal.Name = "CierreCal";
            this.CierreCal.Width = 165;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Comentario:";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(86, 219);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(147, 59);
            this.txtComentario.TabIndex = 13;
            // 
            // frmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1266, 685);
            this.Controls.Add(this.gpCajas);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmCaja";
            this.Text = "frmCaja";
            this.Load += new System.EventHandler(this.frmCaja_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajaDelDia)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gpCajas.ResumeLayout(false);
            this.gpCajas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajasHistoricas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSaldoApertura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSaldoEnCaja;
        private System.Windows.Forms.TextBox txtSaldoCierreCalculado;
        private System.Windows.Forms.Button btnApertura;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCierre;
        private System.Windows.Forms.DataGridView dgvCajaDelDia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Egreso;
        private System.Windows.Forms.GroupBox gpCajas;
        private System.Windows.Forms.DataGridView dgvCajasHistoricas;
        private System.Windows.Forms.Button btnDeposito;
        private System.Windows.Forms.Button btnRetiro;
        private System.Windows.Forms.Button btnBuscarCajas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnVerMovimientos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apertura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cierre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn CierreC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CierreCal;
        private System.Windows.Forms.TextBox txtHorarioApertura;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTransferencias;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label10;
    }
}