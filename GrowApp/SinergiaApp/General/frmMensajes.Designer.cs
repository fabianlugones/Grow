namespace SinergiaApp
{
    partial class frmMensajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMensajes));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nudHoraActiva = new System.Windows.Forms.NumericUpDown();
            this.dtpFechaActiva = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAvisos = new System.Windows.Forms.DataGridView();
            this.Emisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aviso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBajaAviso = new System.Windows.Forms.Button();
            this.txtMensajeM = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIdM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvUsuariosM = new System.Windows.Forms.DataGridView();
            this.id_us = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.nudHoraActiva2 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaActivaM = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraActiva)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvisos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraActiva2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.txtMensaje);
            this.groupBox1.Controls.Add(this.dgvUsuarios);
            this.groupBox1.Controls.Add(this.nudHoraActiva);
            this.groupBox1.Controls.Add(this.dtpFechaActiva);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(455, 455);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CONFIGURACION DE AVISOS";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.Location = new System.Drawing.Point(8, 392);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(143, 53);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "GENERAR AVISO";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtMensaje
            // 
            this.txtMensaje.Location = new System.Drawing.Point(8, 245);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(439, 138);
            this.txtMensaje.TabIndex = 7;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Nombre,
            this.Check});
            this.dgvUsuarios.Location = new System.Drawing.Point(8, 90);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(439, 127);
            this.dgvUsuarios.TabIndex = 6;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id_usuario";
            this.Id.FillWeight = 30F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.FillWeight = 250F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Check
            // 
            this.Check.FillWeight = 50F;
            this.Check.HeaderText = "Check";
            this.Check.Name = "Check";
            this.Check.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // nudHoraActiva
            // 
            this.nudHoraActiva.Location = new System.Drawing.Point(184, 44);
            this.nudHoraActiva.Name = "nudHoraActiva";
            this.nudHoraActiva.Size = new System.Drawing.Size(48, 20);
            this.nudHoraActiva.TabIndex = 5;
            // 
            // dtpFechaActiva
            // 
            this.dtpFechaActiva.Location = new System.Drawing.Point(131, 18);
            this.dtpFechaActiva.Name = "dtpFechaActiva";
            this.dtpFechaActiva.Size = new System.Drawing.Size(233, 20);
            this.dtpFechaActiva.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 230);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mensaje:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Destinatarios";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hora del aviso (de 6 a 20):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha del aviso:";
            // 
            // dgvAvisos
            // 
            this.dgvAvisos.AllowUserToAddRows = false;
            this.dgvAvisos.AllowUserToDeleteRows = false;
            this.dgvAvisos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAvisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Emisor,
            this.Hora,
            this.Fecha,
            this.Aviso});
            this.dgvAvisos.Location = new System.Drawing.Point(7, 18);
            this.dgvAvisos.Name = "dgvAvisos";
            this.dgvAvisos.ReadOnly = true;
            this.dgvAvisos.Size = new System.Drawing.Size(744, 162);
            this.dgvAvisos.TabIndex = 1;
            this.dgvAvisos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvisos_CellClick);
            this.dgvAvisos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvisos_CellContentClick);
            // 
            // Emisor
            // 
            this.Emisor.DataPropertyName = "Emisor";
            this.Emisor.FillWeight = 150F;
            this.Emisor.HeaderText = "Emisor";
            this.Emisor.Name = "Emisor";
            this.Emisor.ReadOnly = true;
            this.Emisor.Width = 150;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "Hora_activa";
            this.Hora.HeaderText = "Hora Activa";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha_activa";
            this.Fecha.HeaderText = "Fecha Activa";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Aviso
            // 
            this.Aviso.DataPropertyName = "Aviso";
            this.Aviso.FillWeight = 350F;
            this.Aviso.HeaderText = "Mensaje";
            this.Aviso.Name = "Aviso";
            this.Aviso.ReadOnly = true;
            this.Aviso.Width = 350;
            // 
            // btnBajaAviso
            // 
            this.btnBajaAviso.BackColor = System.Drawing.Color.White;
            this.btnBajaAviso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBajaAviso.Image = ((System.Drawing.Image)(resources.GetObject("btnBajaAviso.Image")));
            this.btnBajaAviso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBajaAviso.Location = new System.Drawing.Point(17, 12);
            this.btnBajaAviso.Name = "btnBajaAviso";
            this.btnBajaAviso.Size = new System.Drawing.Size(180, 50);
            this.btnBajaAviso.TabIndex = 2;
            this.btnBajaAviso.Text = "Dar de baja aviso";
            this.btnBajaAviso.UseVisualStyleBackColor = false;
            this.btnBajaAviso.Click += new System.EventHandler(this.btnBajaAviso_Click);
            // 
            // txtMensajeM
            // 
            this.txtMensajeM.Location = new System.Drawing.Point(8, 209);
            this.txtMensajeM.Multiline = true;
            this.txtMensajeM.Name = "txtMensajeM";
            this.txtMensajeM.Size = new System.Drawing.Size(345, 78);
            this.txtMensajeM.TabIndex = 4;
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.White;
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.Image = ((System.Drawing.Image)(resources.GetObject("btnModificar.Image")));
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.Location = new System.Drawing.Point(551, 12);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(183, 49);
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Guardar Cambios";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtIdM);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.dgvUsuariosM);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.nudHoraActiva2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.dtpFechaActivaM);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtMensajeM);
            this.groupBox2.Controls.Add(this.dgvAvisos);
            this.groupBox2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(476, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 455);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AVISOS PROGRAMADOS";
            // 
            // txtIdM
            // 
            this.txtIdM.Location = new System.Drawing.Point(117, 354);
            this.txtIdM.Name = "txtIdM";
            this.txtIdM.Size = new System.Drawing.Size(49, 20);
            this.txtIdM.TabIndex = 15;
            this.txtIdM.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 359);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "ID del aviso:";
            this.label9.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.btnBajaAviso);
            this.panel1.Location = new System.Drawing.Point(16, 380);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(746, 67);
            this.panel1.TabIndex = 13;
            // 
            // dgvUsuariosM
            // 
            this.dgvUsuariosM.AllowUserToAddRows = false;
            this.dgvUsuariosM.AllowUserToDeleteRows = false;
            this.dgvUsuariosM.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuariosM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_us,
            this.dataGridViewTextBoxColumn1,
            this.checc});
            this.dgvUsuariosM.Location = new System.Drawing.Point(380, 209);
            this.dgvUsuariosM.Name = "dgvUsuariosM";
            this.dgvUsuariosM.Size = new System.Drawing.Size(371, 127);
            this.dgvUsuariosM.TabIndex = 10;
            // 
            // id_us
            // 
            this.id_us.DataPropertyName = "Id_usuario";
            this.id_us.FillWeight = 25F;
            this.id_us.HeaderText = "Id";
            this.id_us.Name = "id_us";
            this.id_us.Width = 25;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.dataGridViewTextBoxColumn1.FillWeight = 250F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // checc
            // 
            this.checc.DataPropertyName = "Check";
            this.checc.FillWeight = 50F;
            this.checc.HeaderText = "Check";
            this.checc.Name = "checc";
            this.checc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.checc.Width = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(378, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "Destinatarios";
            // 
            // nudHoraActiva2
            // 
            this.nudHoraActiva2.Location = new System.Drawing.Point(120, 329);
            this.nudHoraActiva2.Name = "nudHoraActiva2";
            this.nudHoraActiva2.Size = new System.Drawing.Size(48, 20);
            this.nudHoraActiva2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mensaje:";
            // 
            // dtpFechaActivaM
            // 
            this.dtpFechaActivaM.Location = new System.Drawing.Point(120, 300);
            this.dtpFechaActivaM.Name = "dtpFechaActivaM";
            this.dtpFechaActivaM.Size = new System.Drawing.Size(233, 20);
            this.dtpFechaActivaM.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 330);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hora del aviso:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 300);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 12);
            this.label7.TabIndex = 9;
            this.label7.Text = "Fecha del aviso:";
            // 
            // frmMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1362, 473);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMensajes";
            this.Text = "frmMensajes";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraActiva)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvisos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraActiva2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudHoraActiva;
        private System.Windows.Forms.DateTimePicker dtpFechaActiva;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.DataGridView dgvAvisos;
        private System.Windows.Forms.Button btnBajaAviso;
        private System.Windows.Forms.TextBox txtMensajeM;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvUsuariosM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudHoraActiva2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaActivaM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aviso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
    
        private System.Windows.Forms.TextBox txtIdM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_us;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checc;
    }
}