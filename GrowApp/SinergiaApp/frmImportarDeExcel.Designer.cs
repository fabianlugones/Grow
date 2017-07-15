namespace GrowApp
{
    partial class frmImportarDeExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarDeExcel));
            this.btnImportarArticulos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImportarProv = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirArticulos = new System.Windows.Forms.TextBox();
            this.Costo_rep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje_Ganancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvArtivulos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtivulos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportarArticulos
            // 
            this.btnImportarArticulos.BackColor = System.Drawing.Color.White;
            this.btnImportarArticulos.Image = ((System.Drawing.Image)(resources.GetObject("btnImportarArticulos.Image")));
            this.btnImportarArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportarArticulos.Location = new System.Drawing.Point(518, 662);
            this.btnImportarArticulos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnImportarArticulos.Name = "btnImportarArticulos";
            this.btnImportarArticulos.Size = new System.Drawing.Size(205, 59);
            this.btnImportarArticulos.TabIndex = 1;
            this.btnImportarArticulos.Text = "Importar";
            this.btnImportarArticulos.UseVisualStyleBackColor = false;
            this.btnImportarArticulos.Click += new System.EventHandler(this.btnImportarArticulos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "IMPORTAR COSTOS Y PORCENTAJES";
            // 
            // btnImportarProv
            // 
            this.btnImportarProv.BackColor = System.Drawing.Color.White;
            this.btnImportarProv.Image = ((System.Drawing.Image)(resources.GetObject("btnImportarProv.Image")));
            this.btnImportarProv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportarProv.Location = new System.Drawing.Point(1098, 584);
            this.btnImportarProv.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnImportarProv.Name = "btnImportarProv";
            this.btnImportarProv.Size = new System.Drawing.Size(205, 59);
            this.btnImportarProv.TabIndex = 11;
            this.btnImportarProv.Text = "Importar Proveedores";
            this.btnImportarProv.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 662);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Colocar ID en columna A";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 684);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Colocar % en columna B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 706);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Colocar costo en columna C del excel";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(664, 49);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 47);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Archivo de Articulos:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDirArticulos
            // 
            this.txtDirArticulos.Location = new System.Drawing.Point(44, 72);
            this.txtDirArticulos.Name = "txtDirArticulos";
            this.txtDirArticulos.ReadOnly = true;
            this.txtDirArticulos.Size = new System.Drawing.Size(613, 23);
            this.txtDirArticulos.TabIndex = 3;
            this.txtDirArticulos.TextChanged += new System.EventHandler(this.txtDirArticulos_TextChanged);
            // 
            // Costo_rep
            // 
            this.Costo_rep.HeaderText = "Costo Reposicion ($)";
            this.Costo_rep.Name = "Costo_rep";
            // 
            // Porcentaje_Ganancia
            // 
            this.Porcentaje_Ganancia.HeaderText = "Porcentaje Ganancia";
            this.Porcentaje_Ganancia.Name = "Porcentaje_Ganancia";
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // dgvArtivulos
            // 
            this.dgvArtivulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvArtivulos.BackgroundColor = System.Drawing.Color.White;
            this.dgvArtivulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArtivulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Porcentaje_Ganancia,
            this.Costo_rep});
            this.dgvArtivulos.Location = new System.Drawing.Point(41, 102);
            this.dgvArtivulos.Name = "dgvArtivulos";
            this.dgvArtivulos.Size = new System.Drawing.Size(682, 554);
            this.dgvArtivulos.TabIndex = 4;
            this.dgvArtivulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvArtivulos_CellContentClick);
            // 
            // frmImportarDeExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(767, 745);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImportarProv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvArtivulos);
            this.Controls.Add(this.txtDirArticulos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnImportarArticulos);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmImportarDeExcel";
            this.Text = "frmImportarDeExcel";
            this.Load += new System.EventHandler(this.frmImportarDeExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtivulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportarArticulos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnImportarProv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDirArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo_rep;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje_Ganancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridView dgvArtivulos;
    }
}