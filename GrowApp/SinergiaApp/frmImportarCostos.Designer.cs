namespace SinergiaApp
{
    partial class frmImportarCostos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarCostos));
            this.dgvArtivulos = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Porcentaje_Ganancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo_rep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDirArticulos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImportarArticulos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtivulos)).BeginInit();
            this.SuspendLayout();
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
            this.dgvArtivulos.Location = new System.Drawing.Point(13, 82);
            this.dgvArtivulos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvArtivulos.Name = "dgvArtivulos";
            this.dgvArtivulos.Size = new System.Drawing.Size(578, 489);
            this.dgvArtivulos.TabIndex = 8;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Porcentaje_Ganancia
            // 
            this.Porcentaje_Ganancia.DataPropertyName = "Porcentaje_ganancia";
            this.Porcentaje_Ganancia.HeaderText = "Porcentaje Ganancia";
            this.Porcentaje_Ganancia.Name = "Porcentaje_Ganancia";
            // 
            // Costo_rep
            // 
            this.Costo_rep.DataPropertyName = "Costo_reposicion";
            this.Costo_rep.HeaderText = "Costo Reposicion ($)";
            this.Costo_rep.Name = "Costo_rep";
            // 
            // txtDirArticulos
            // 
            this.txtDirArticulos.Location = new System.Drawing.Point(17, 36);
            this.txtDirArticulos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDirArticulos.Name = "txtDirArticulos";
            this.txtDirArticulos.ReadOnly = true;
            this.txtDirArticulos.Size = new System.Drawing.Size(452, 23);
            this.txtDirArticulos.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar Archivo de Articulos:";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(499, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 54);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 628);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(256, 15);
            this.label5.TabIndex = 18;
            this.label5.Text = "Colocar costo en columna C del excel";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 603);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Colocar % en columna B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 577);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Colocar ID en columna A";
            // 
            // btnImportarArticulos
            // 
            this.btnImportarArticulos.BackColor = System.Drawing.Color.White;
            this.btnImportarArticulos.Image = ((System.Drawing.Image)(resources.GetObject("btnImportarArticulos.Image")));
            this.btnImportarArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportarArticulos.Location = new System.Drawing.Point(364, 577);
            this.btnImportarArticulos.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.btnImportarArticulos.Name = "btnImportarArticulos";
            this.btnImportarArticulos.Size = new System.Drawing.Size(227, 68);
            this.btnImportarArticulos.TabIndex = 15;
            this.btnImportarArticulos.Text = "Importar";
            this.btnImportarArticulos.UseVisualStyleBackColor = false;
            this.btnImportarArticulos.Click += new System.EventHandler(this.btnImportarArticulos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(10, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(600, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "¡Cuidado! Los costos y los porcentajes se aplicaran al mes actual que se hace est" +
    "a carga";
            // 
            // frmImportarCostos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(626, 684);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImportarArticulos);
            this.Controls.Add(this.dgvArtivulos);
            this.Controls.Add(this.txtDirArticulos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmImportarCostos";
            this.Text = "frmImportarCostos";
            this.Load += new System.EventHandler(this.frmImportarCostos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArtivulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArtivulos;
        private System.Windows.Forms.TextBox txtDirArticulos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImportarArticulos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Porcentaje_Ganancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo_rep;
        private System.Windows.Forms.Label label2;
    }
}