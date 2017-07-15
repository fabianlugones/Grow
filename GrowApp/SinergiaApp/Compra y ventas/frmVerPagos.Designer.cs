namespace SinergiaApp
{
    partial class frmVerPagos
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
            this.dgvVerPagos = new System.Windows.Forms.DataGridView();
            this.lblOrden = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.numero_compra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha_pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Forma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto_caja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerPagos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVerPagos
            // 
            this.dgvVerPagos.AllowUserToAddRows = false;
            this.dgvVerPagos.AllowUserToDeleteRows = false;
            this.dgvVerPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVerPagos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvVerPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero_compra,
            this.fecha_pago,
            this.Hora,
            this.Forma,
            this.Monto,
            this.Monto_caja});
            this.dgvVerPagos.Location = new System.Drawing.Point(12, 94);
            this.dgvVerPagos.Name = "dgvVerPagos";
            this.dgvVerPagos.Size = new System.Drawing.Size(874, 201);
            this.dgvVerPagos.TabIndex = 0;
            // 
            // lblOrden
            // 
            this.lblOrden.AutoSize = true;
            this.lblOrden.Location = new System.Drawing.Point(25, 9);
            this.lblOrden.Name = "lblOrden";
            this.lblOrden.Size = new System.Drawing.Size(49, 15);
            this.lblOrden.TabIndex = 1;
            this.lblOrden.Text = "label1";
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(747, 58);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(49, 15);
            this.lblCosto.TabIndex = 4;
            this.lblCosto.Text = "label4";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(25, 58);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(49, 15);
            this.lblFecha.TabIndex = 5;
            this.lblFecha.Text = "label5";
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Location = new System.Drawing.Point(25, 33);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(49, 15);
            this.lblProveedor.TabIndex = 6;
            this.lblProveedor.Text = "label6";
            // 
            // numero_compra
            // 
            this.numero_compra.DataPropertyName = "Numero";
            this.numero_compra.HeaderText = "Número de Compra";
            this.numero_compra.Name = "numero_compra";
            // 
            // fecha_pago
            // 
            this.fecha_pago.DataPropertyName = "FechaPago";
            this.fecha_pago.HeaderText = "Fecha pago";
            this.fecha_pago.Name = "fecha_pago";
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "Hora";
            this.Hora.HeaderText = "Hora pago";
            this.Hora.Name = "Hora";
            // 
            // Forma
            // 
            this.Forma.DataPropertyName = "FormaDePago";
            this.Forma.HeaderText = "Forma de pago";
            this.Forma.Name = "Forma";
            // 
            // Monto
            // 
            this.Monto.DataPropertyName = "Pago";
            this.Monto.HeaderText = "Monto ($)";
            this.Monto.Name = "Monto";
            // 
            // Monto_caja
            // 
            this.Monto_caja.DataPropertyName = "Pago_de_caja";
            this.Monto_caja.HeaderText = "De Caja ($)";
            this.Monto_caja.Name = "Monto_caja";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(589, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "(el Monto ($) negativo indica que se descontó crédito de una cuenta corriente abi" +
    "erta)";
            // 
            // frmVerPagos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(996, 331);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblCosto);
            this.Controls.Add(this.lblOrden);
            this.Controls.Add(this.dgvVerPagos);
            this.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmVerPagos";
            this.Text = "frmVerPagos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerPagos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVerPagos;
        private System.Windows.Forms.Label lblOrden;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero_compra;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha_pago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Forma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto_caja;
        private System.Windows.Forms.Label label1;
    }
}