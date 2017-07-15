namespace SinergiaApp
{
    partial class frmImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImport));
            this.label2 = new System.Windows.Forms.Label();
            this.dgvArtivulos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub_categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock_minimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDirArticulos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImportarArticulos = new System.Windows.Forms.Button();
            this.btnImp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtivulos)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "IMPORTAR ARTICULOS";
            // 
            // dgvArtivulos
            // 
            this.dgvArtivulos.AllowUserToAddRows = false;
            this.dgvArtivulos.AllowUserToDeleteRows = false;
            this.dgvArtivulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArtivulos.BackgroundColor = System.Drawing.Color.White;
            this.dgvArtivulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtivulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.Unidad,
            this.Categoria,
            this.Sub_categoria,
            this.Proveedor,
            this.Stock_minimo,
            this.Porcentaje,
            this.Cantidad,
            this.CostoUnit});
            this.dgvArtivulos.Location = new System.Drawing.Point(24, 83);
            this.dgvArtivulos.Name = "dgvArtivulos";
            this.dgvArtivulos.Size = new System.Drawing.Size(1097, 464);
            this.dgvArtivulos.TabIndex = 9;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.FillWeight = 200F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "Unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.FillWeight = 150F;
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            // 
            // Sub_categoria
            // 
            this.Sub_categoria.DataPropertyName = "Categoria_2";
            this.Sub_categoria.HeaderText = "Sub Categoria";
            this.Sub_categoria.Name = "Sub_categoria";
            // 
            // Proveedor
            // 
            this.Proveedor.DataPropertyName = "Proveedor_habitual";
            this.Proveedor.HeaderText = "Proveedor habitual";
            this.Proveedor.Name = "Proveedor";
            // 
            // Stock_minimo
            // 
            this.Stock_minimo.DataPropertyName = "Stock_min";
            this.Stock_minimo.HeaderText = "Stock Mínimo";
            this.Stock_minimo.Name = "Stock_minimo";
            // 
            // Porcentaje
            // 
            this.Porcentaje.DataPropertyName = "Porcentaje_ganancia";
            this.Porcentaje.HeaderText = "% Ganancia";
            this.Porcentaje.Name = "Porcentaje";
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // CostoUnit
            // 
            this.CostoUnit.DataPropertyName = "Costo_unitario";
            this.CostoUnit.HeaderText = "Costo unitario";
            this.CostoUnit.Name = "CostoUnit";
            // 
            // txtDirArticulos
            // 
            this.txtDirArticulos.Location = new System.Drawing.Point(27, 53);
            this.txtDirArticulos.Name = "txtDirArticulos";
            this.txtDirArticulos.ReadOnly = true;
            this.txtDirArticulos.Size = new System.Drawing.Size(1036, 23);
            this.txtDirArticulos.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Buscar Archivo de Articulos:";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1062, 35);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 47);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImportarArticulos
            // 
            this.btnImportarArticulos.BackColor = System.Drawing.Color.White;
            this.btnImportarArticulos.Image = ((System.Drawing.Image)(resources.GetObject("btnImportarArticulos.Image")));
            this.btnImportarArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportarArticulos.Location = new System.Drawing.Point(916, 553);
            this.btnImportarArticulos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnImportarArticulos.Name = "btnImportarArticulos";
            this.btnImportarArticulos.Size = new System.Drawing.Size(205, 59);
            this.btnImportarArticulos.TabIndex = 11;
            this.btnImportarArticulos.Text = "Importar Articulos";
            this.btnImportarArticulos.UseVisualStyleBackColor = false;
            this.btnImportarArticulos.Click += new System.EventHandler(this.btnImportarArticulos_Click);
            // 
            // btnImp
            // 
            this.btnImp.BackColor = System.Drawing.Color.White;
            this.btnImp.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImp.Location = new System.Drawing.Point(1136, 119);
            this.btnImp.Name = "btnImp";
            this.btnImp.Size = new System.Drawing.Size(103, 57);
            this.btnImp.TabIndex = 12;
            this.btnImp.Text = "Importar Costos";
            this.btnImp.UseVisualStyleBackColor = false;
            this.btnImp.Click += new System.EventHandler(this.btnImp_Click);
            // 
            // frmImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1266, 624);
            this.Controls.Add(this.btnImp);
            this.Controls.Add(this.btnImportarArticulos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvArtivulos);
            this.Controls.Add(this.txtDirArticulos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmImport";
            this.Text = "frmImport";
            this.Load += new System.EventHandler(this.frmImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtivulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvArtivulos;
        private System.Windows.Forms.TextBox txtDirArticulos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImportarArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sub_categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock_minimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoUnit;
        private System.Windows.Forms.Button btnImp;
    }
}