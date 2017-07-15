namespace SinergiaApp
{
    partial class frmPanelMensajes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPanelMensajes));
            this.btnEntrada = new System.Windows.Forms.Button();
            this.pnlAvisos = new System.Windows.Forms.Panel();
            this.btnEnviarMensajes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEntrada
            // 
            this.btnEntrada.BackColor = System.Drawing.Color.White;
            this.btnEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrada.ForeColor = System.Drawing.Color.Black;
            this.btnEntrada.Image = ((System.Drawing.Image)(resources.GetObject("btnEntrada.Image")));
            this.btnEntrada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEntrada.Location = new System.Drawing.Point(218, 12);
            this.btnEntrada.Name = "btnEntrada";
            this.btnEntrada.Size = new System.Drawing.Size(221, 56);
            this.btnEntrada.TabIndex = 11;
            this.btnEntrada.Text = "Bandeja de entrada";
            this.btnEntrada.UseVisualStyleBackColor = false;
            this.btnEntrada.Click += new System.EventHandler(this.btnEntrada_Click);
            // 
            // pnlAvisos
            // 
            this.pnlAvisos.BackColor = System.Drawing.Color.White;
            this.pnlAvisos.Location = new System.Drawing.Point(1, 74);
            this.pnlAvisos.Name = "pnlAvisos";
            this.pnlAvisos.Size = new System.Drawing.Size(1341, 573);
            this.pnlAvisos.TabIndex = 6;
            // 
            // btnEnviarMensajes
            // 
            this.btnEnviarMensajes.BackColor = System.Drawing.Color.White;
            this.btnEnviarMensajes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnviarMensajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviarMensajes.ForeColor = System.Drawing.Color.Black;
            this.btnEnviarMensajes.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarMensajes.Image")));
            this.btnEnviarMensajes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviarMensajes.Location = new System.Drawing.Point(12, 12);
            this.btnEnviarMensajes.Name = "btnEnviarMensajes";
            this.btnEnviarMensajes.Size = new System.Drawing.Size(200, 56);
            this.btnEnviarMensajes.TabIndex = 7;
            this.btnEnviarMensajes.Text = "Enviar Avisos";
            this.btnEnviarMensajes.UseVisualStyleBackColor = false;
            this.btnEnviarMensajes.Click += new System.EventHandler(this.btnEnviarMensajes_Click);
            // 
            // frmPanelMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1346, 648);
            this.Controls.Add(this.btnEntrada);
            this.Controls.Add(this.pnlAvisos);
            this.Controls.Add(this.btnEnviarMensajes);
            this.Name = "frmPanelMensajes";
            this.Text = "frmPanelMensajes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEntrada;
        private System.Windows.Forms.Panel pnlAvisos;
        private System.Windows.Forms.Button btnEnviarMensajes;

    }
}