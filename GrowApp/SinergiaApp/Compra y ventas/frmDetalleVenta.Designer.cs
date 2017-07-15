namespace SinergiaApp.Compra_y_ventas
{
    partial class frmDetalleVenta
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
            this.dgvVenta = new System.Windows.Forms.DataGridView();
            this.Idd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorPromo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVenta
            // 
            this.dgvVenta.AllowUserToAddRows = false;
            this.dgvVenta.AllowUserToDeleteRows = false;
            this.dgvVenta.BackgroundColor = System.Drawing.Color.White;
            this.dgvVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idd,
            this.Nombre,
            this.Cant,
            this.Precio_unitario,
            this.Desc,
            this.Total,
            this.PorPromo});
            this.dgvVenta.Location = new System.Drawing.Point(26, 53);
            this.dgvVenta.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvVenta.Name = "dgvVenta";
            this.dgvVenta.ReadOnly = true;
            this.dgvVenta.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvVenta.Size = new System.Drawing.Size(809, 229);
            this.dgvVenta.TabIndex = 70;
            // 
            // Idd
            // 
            this.Idd.DataPropertyName = "Id_articulo";
            this.Idd.HeaderText = "ID";
            this.Idd.Name = "Idd";
            this.Idd.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.FillWeight = 225F;
            this.Nombre.HeaderText = "Nombre Artículo";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 225;
            // 
            // Cant
            // 
            this.Cant.DataPropertyName = "Cantidad";
            this.Cant.HeaderText = "Cantidad Comprada";
            this.Cant.Name = "Cant";
            this.Cant.ReadOnly = true;
            // 
            // Precio_unitario
            // 
            this.Precio_unitario.DataPropertyName = "Precio";
            this.Precio_unitario.FillWeight = 90F;
            this.Precio_unitario.HeaderText = "Precio Unitario";
            this.Precio_unitario.Name = "Precio_unitario";
            this.Precio_unitario.ReadOnly = true;
            this.Precio_unitario.Width = 90;
            // 
            // Desc
            // 
            this.Desc.DataPropertyName = "Descuento";
            this.Desc.FillWeight = 50F;
            this.Desc.HeaderText = "Desc %";
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            this.Desc.Width = 50;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Precio_total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // PorPromo
            // 
            this.PorPromo.DataPropertyName = "PorPromo";
            this.PorPromo.HeaderText = "Promo";
            this.PorPromo.Name = "PorPromo";
            this.PorPromo.ReadOnly = true;
            // 
            // frmDetalleVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(860, 325);
            this.Controls.Add(this.dgvVenta);
            this.Name = "frmDetalleVenta";
            this.Text = "frmDetalleVenta";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorPromo;

    }
}