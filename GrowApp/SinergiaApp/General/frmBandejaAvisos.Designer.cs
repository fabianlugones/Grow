namespace SinergiaApp
{
    partial class frmBandejaAvisos
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
            this.dgvAvisos = new System.Windows.Forms.DataGridView();
            this.Emisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aviso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.chbVerMensajes = new System.Windows.Forms.CheckBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.txtEmisor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvisos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAvisos
            // 
            this.dgvAvisos.AllowUserToAddRows = false;
            this.dgvAvisos.AllowUserToDeleteRows = false;
            this.dgvAvisos.BackgroundColor = System.Drawing.Color.White;
            this.dgvAvisos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAvisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Emisor,
            this.Fecha,
            this.Hora,
            this.Aviso});
            this.dgvAvisos.Location = new System.Drawing.Point(16, 41);
            this.dgvAvisos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvAvisos.Name = "dgvAvisos";
            this.dgvAvisos.ReadOnly = true;
            this.dgvAvisos.Size = new System.Drawing.Size(1328, 228);
            this.dgvAvisos.TabIndex = 2;
            this.dgvAvisos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvisos_CellClick);
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
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha_activa";
            this.Fecha.HeaderText = "Fecha de Aviso";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "Hora_activa";
            this.Hora.HeaderText = "Hora de Aviso";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            // 
            // Aviso
            // 
            this.Aviso.DataPropertyName = "Aviso";
            this.Aviso.FillWeight = 600F;
            this.Aviso.HeaderText = "Mensaje";
            this.Aviso.Name = "Aviso";
            this.Aviso.ReadOnly = true;
            this.Aviso.Width = 600;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(808, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "* toque sobre el mensaje para poder verlo completo y desactivarlo (si no lo desac" +
    "tiva, lo seguirá viendo en la pantalla de actividades )";
            // 
            // chbVerMensajes
            // 
            this.chbVerMensajes.AutoSize = true;
            this.chbVerMensajes.Location = new System.Drawing.Point(20, 276);
            this.chbVerMensajes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chbVerMensajes.Name = "chbVerMensajes";
            this.chbVerMensajes.Size = new System.Drawing.Size(192, 18);
            this.chbVerMensajes.TabIndex = 4;
            this.chbVerMensajes.Text = "VER TODOS LOS MENSAJES";
            this.chbVerMensajes.UseVisualStyleBackColor = true;
            this.chbVerMensajes.CheckedChanged += new System.EventHandler(this.chbVerMensajes_CheckedChanged);
            // 
            // txtMensaje
            // 
            this.txtMensaje.BackColor = System.Drawing.Color.White;
            this.txtMensaje.Location = new System.Drawing.Point(359, 338);
            this.txtMensaje.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.Size = new System.Drawing.Size(600, 169);
            this.txtMensaje.TabIndex = 5;
            // 
            // txtEmisor
            // 
            this.txtEmisor.Location = new System.Drawing.Point(395, 310);
            this.txtEmisor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEmisor.Name = "txtEmisor";
            this.txtEmisor.ReadOnly = true;
            this.txtEmisor.Size = new System.Drawing.Size(564, 21);
            this.txtEmisor.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 310);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 14);
            this.label2.TabIndex = 7;
            this.label2.Text = "De:";
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Location = new System.Drawing.Point(359, 515);
            this.btnDesactivar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(601, 29);
            this.btnDesactivar.TabIndex = 8;
            this.btnDesactivar.Text = "Desactivar Mensaje";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(827, 282);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 21);
            this.textBox1.TabIndex = 9;
            this.textBox1.Visible = false;
            // 
            // frmBandejaAvisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1444, 684);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnDesactivar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEmisor);
            this.Controls.Add(this.txtMensaje);
            this.Controls.Add(this.chbVerMensajes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAvisos);
            this.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmBandejaAvisos";
            this.Text = "frmBandejaAvisos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAvisos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aviso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbVerMensajes;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.TextBox txtEmisor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.TextBox textBox1;
    }
}