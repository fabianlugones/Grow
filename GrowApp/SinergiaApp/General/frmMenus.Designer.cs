namespace SinergiaApp
{
    partial class frmMenus
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenus));
            this.pnlFrm = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBanco = new System.Windows.Forms.Button();
            this.btnGestionStock = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.btnCuentaCorriente = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnAvisos = new System.Windows.Forms.Button();
            this.btnIzquierda = new System.Windows.Forms.Button();
            this.btnCronograma = new System.Windows.Forms.Button();
            this.btnAgregarArtic = new System.Windows.Forms.Button();
            this.btnTareasMateriales = new System.Windows.Forms.Button();
            this.btnInicio2 = new System.Windows.Forms.Button();
            this.btnDerecha = new System.Windows.Forms.Button();
            this.btnCompra = new System.Windows.Forms.Button();
            this.btnVerCompras = new System.Windows.Forms.Button();
            this.btnNuevoPromo = new System.Windows.Forms.Button();
            this.btnVerVentas = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnVerPromos = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerMenu = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlFrm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFrm
            // 
            this.pnlFrm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFrm.AutoScroll = true;
            this.pnlFrm.BackColor = System.Drawing.Color.White;
            this.pnlFrm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlFrm.Controls.Add(this.pictureBox2);
            this.pnlFrm.Location = new System.Drawing.Point(-2, 59);
            this.pnlFrm.MaximumSize = new System.Drawing.Size(1400, 800);
            this.pnlFrm.Name = "pnlFrm";
            this.pnlFrm.Size = new System.Drawing.Size(1366, 686);
            this.pnlFrm.TabIndex = 4;
            this.pnlFrm.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFrm_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1175, 504);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(162, 125);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnBanco);
            this.panel1.Controls.Add(this.btnGestionStock);
            this.panel1.Controls.Add(this.btnImport);
            this.panel1.Controls.Add(this.btnCaja);
            this.panel1.Controls.Add(this.btnCuentaCorriente);
            this.panel1.Controls.Add(this.btnVentas);
            this.panel1.Controls.Add(this.btnAvisos);
            this.panel1.Controls.Add(this.btnIzquierda);
            this.panel1.Controls.Add(this.btnCronograma);
            this.panel1.Controls.Add(this.btnAgregarArtic);
            this.panel1.Controls.Add(this.btnTareasMateriales);
            this.panel1.Controls.Add(this.btnInicio2);
            this.panel1.Controls.Add(this.btnDerecha);
            this.panel1.Controls.Add(this.btnCompra);
            this.panel1.Controls.Add(this.btnVerCompras);
            this.panel1.Controls.Add(this.btnNuevoPromo);
            this.panel1.Controls.Add(this.btnVerVentas);
            this.panel1.Controls.Add(this.btnClientes);
            this.panel1.Controls.Add(this.btnVerPromos);
            this.panel1.Controls.Add(this.btnProveedores);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1386, 61);
            this.panel1.TabIndex = 8;
            // 
            // btnBanco
            // 
            this.btnBanco.BackColor = System.Drawing.Color.White;
            this.btnBanco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBanco.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnBanco.FlatAppearance.BorderSize = 0;
            this.btnBanco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanco.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanco.Image = ((System.Drawing.Image)(resources.GetObject("btnBanco.Image")));
            this.btnBanco.Location = new System.Drawing.Point(485, 126);
            this.btnBanco.Name = "btnBanco";
            this.btnBanco.Size = new System.Drawing.Size(104, 60);
            this.btnBanco.TabIndex = 31;
            this.btnBanco.Text = "Banco";
            this.btnBanco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBanco.UseVisualStyleBackColor = true;
            this.btnBanco.Click += new System.EventHandler(this.btnBanco_Click);
            // 
            // btnGestionStock
            // 
            this.btnGestionStock.BackColor = System.Drawing.Color.White;
            this.btnGestionStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGestionStock.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnGestionStock.FlatAppearance.BorderSize = 0;
            this.btnGestionStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionStock.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestionStock.Image = ((System.Drawing.Image)(resources.GetObject("btnGestionStock.Image")));
            this.btnGestionStock.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGestionStock.Location = new System.Drawing.Point(1079, 63);
            this.btnGestionStock.Name = "btnGestionStock";
            this.btnGestionStock.Size = new System.Drawing.Size(120, 60);
            this.btnGestionStock.TabIndex = 30;
            this.btnGestionStock.Text = "Gestión de Stock";
            this.btnGestionStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestionStock.UseVisualStyleBackColor = true;
            this.btnGestionStock.Click += new System.EventHandler(this.btnGestionStock_Click);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.White;
            this.btnImport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.Location = new System.Drawing.Point(314, 126);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(95, 62);
            this.btnImport.TabIndex = 29;
            this.btnImport.Text = "Import";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCaja
            // 
            this.btnCaja.BackColor = System.Drawing.Color.White;
            this.btnCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCaja.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCaja.FlatAppearance.BorderSize = 0;
            this.btnCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaja.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnCaja.Image")));
            this.btnCaja.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCaja.Location = new System.Drawing.Point(9, 66);
            this.btnCaja.Margin = new System.Windows.Forms.Padding(0);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(93, 57);
            this.btnCaja.TabIndex = 28;
            this.btnCaja.Text = "Caja";
            this.btnCaja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCaja.UseVisualStyleBackColor = false;
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            // 
            // btnCuentaCorriente
            // 
            this.btnCuentaCorriente.BackColor = System.Drawing.Color.White;
            this.btnCuentaCorriente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCuentaCorriente.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCuentaCorriente.FlatAppearance.BorderSize = 0;
            this.btnCuentaCorriente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuentaCorriente.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuentaCorriente.Image = ((System.Drawing.Image)(resources.GetObject("btnCuentaCorriente.Image")));
            this.btnCuentaCorriente.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCuentaCorriente.Location = new System.Drawing.Point(289, 66);
            this.btnCuentaCorriente.Name = "btnCuentaCorriente";
            this.btnCuentaCorriente.Size = new System.Drawing.Size(89, 57);
            this.btnCuentaCorriente.TabIndex = 27;
            this.btnCuentaCorriente.Text = "C. Corriente";
            this.btnCuentaCorriente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCuentaCorriente.UseVisualStyleBackColor = false;
            this.btnCuentaCorriente.Click += new System.EventHandler(this.btnCuentaCorriente_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.White;
            this.btnVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVentas.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnVentas.FlatAppearance.BorderSize = 0;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVentas.Image")));
            this.btnVentas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVentas.Location = new System.Drawing.Point(100, 66);
            this.btnVentas.Margin = new System.Windows.Forms.Padding(0);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(93, 57);
            this.btnVentas.TabIndex = 17;
            this.btnVentas.Text = "Nueva Venta";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnAvisos
            // 
            this.btnAvisos.BackColor = System.Drawing.Color.White;
            this.btnAvisos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAvisos.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnAvisos.FlatAppearance.BorderSize = 0;
            this.btnAvisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAvisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAvisos.Image = ((System.Drawing.Image)(resources.GetObject("btnAvisos.Image")));
            this.btnAvisos.Location = new System.Drawing.Point(403, 126);
            this.btnAvisos.Name = "btnAvisos";
            this.btnAvisos.Size = new System.Drawing.Size(91, 60);
            this.btnAvisos.TabIndex = 26;
            this.btnAvisos.Text = "Avisos";
            this.btnAvisos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAvisos.UseVisualStyleBackColor = false;
            this.btnAvisos.Click += new System.EventHandler(this.btnAvisos_Click);
            // 
            // btnIzquierda
            // 
            this.btnIzquierda.BackColor = System.Drawing.Color.White;
            this.btnIzquierda.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIzquierda.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnIzquierda.FlatAppearance.BorderSize = 0;
            this.btnIzquierda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzquierda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzquierda.Image = ((System.Drawing.Image)(resources.GetObject("btnIzquierda.Image")));
            this.btnIzquierda.Location = new System.Drawing.Point(27, 131);
            this.btnIzquierda.Name = "btnIzquierda";
            this.btnIzquierda.Size = new System.Drawing.Size(65, 55);
            this.btnIzquierda.TabIndex = 22;
            this.btnIzquierda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIzquierda.UseVisualStyleBackColor = false;
            this.btnIzquierda.Click += new System.EventHandler(this.btnIzquierda_Click);
            // 
            // btnCronograma
            // 
            this.btnCronograma.BackColor = System.Drawing.Color.White;
            this.btnCronograma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCronograma.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCronograma.FlatAppearance.BorderSize = 0;
            this.btnCronograma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCronograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCronograma.Image = ((System.Drawing.Image)(resources.GetObject("btnCronograma.Image")));
            this.btnCronograma.Location = new System.Drawing.Point(111, 126);
            this.btnCronograma.Name = "btnCronograma";
            this.btnCronograma.Size = new System.Drawing.Size(95, 60);
            this.btnCronograma.TabIndex = 23;
            this.btnCronograma.Text = "Usuarios";
            this.btnCronograma.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCronograma.UseVisualStyleBackColor = false;
            this.btnCronograma.Click += new System.EventHandler(this.btnCronograma_Click);
            // 
            // btnAgregarArtic
            // 
            this.btnAgregarArtic.BackColor = System.Drawing.Color.White;
            this.btnAgregarArtic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarArtic.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnAgregarArtic.FlatAppearance.BorderSize = 0;
            this.btnAgregarArtic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarArtic.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarArtic.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarArtic.Image")));
            this.btnAgregarArtic.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgregarArtic.Location = new System.Drawing.Point(384, 66);
            this.btnAgregarArtic.Name = "btnAgregarArtic";
            this.btnAgregarArtic.Size = new System.Drawing.Size(95, 57);
            this.btnAgregarArtic.TabIndex = 8;
            this.btnAgregarArtic.Text = "Artículos";
            this.btnAgregarArtic.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAgregarArtic.UseVisualStyleBackColor = false;
            this.btnAgregarArtic.Click += new System.EventHandler(this.btnAgregarArtic_Click);
            // 
            // btnTareasMateriales
            // 
            this.btnTareasMateriales.BackColor = System.Drawing.Color.White;
            this.btnTareasMateriales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTareasMateriales.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnTareasMateriales.FlatAppearance.BorderSize = 0;
            this.btnTareasMateriales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTareasMateriales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTareasMateriales.Image = ((System.Drawing.Image)(resources.GetObject("btnTareasMateriales.Image")));
            this.btnTareasMateriales.Location = new System.Drawing.Point(213, 126);
            this.btnTareasMateriales.Name = "btnTareasMateriales";
            this.btnTareasMateriales.Size = new System.Drawing.Size(95, 60);
            this.btnTareasMateriales.TabIndex = 24;
            this.btnTareasMateriales.Text = "Informe Stock";
            this.btnTareasMateriales.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTareasMateriales.UseVisualStyleBackColor = false;
            this.btnTareasMateriales.Click += new System.EventHandler(this.btnTareasMateriales_Click);
            // 
            // btnInicio2
            // 
            this.btnInicio2.BackColor = System.Drawing.Color.White;
            this.btnInicio2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio2.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnInicio2.FlatAppearance.BorderSize = 0;
            this.btnInicio2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio2.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio2.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio2.Image")));
            this.btnInicio2.Location = new System.Drawing.Point(1205, 63);
            this.btnInicio2.Name = "btnInicio2";
            this.btnInicio2.Size = new System.Drawing.Size(60, 57);
            this.btnInicio2.TabIndex = 20;
            this.btnInicio2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInicio2.UseVisualStyleBackColor = true;
            this.btnInicio2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDerecha
            // 
            this.btnDerecha.BackColor = System.Drawing.Color.White;
            this.btnDerecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDerecha.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnDerecha.FlatAppearance.BorderSize = 0;
            this.btnDerecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDerecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDerecha.Image = ((System.Drawing.Image)(resources.GetObject("btnDerecha.Image")));
            this.btnDerecha.Location = new System.Drawing.Point(1289, 63);
            this.btnDerecha.Name = "btnDerecha";
            this.btnDerecha.Size = new System.Drawing.Size(62, 57);
            this.btnDerecha.TabIndex = 21;
            this.btnDerecha.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDerecha.UseVisualStyleBackColor = false;
            this.btnDerecha.Click += new System.EventHandler(this.btnDerecha_Click);
            // 
            // btnCompra
            // 
            this.btnCompra.BackColor = System.Drawing.Color.White;
            this.btnCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompra.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnCompra.FlatAppearance.BorderSize = 0;
            this.btnCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompra.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompra.Image = ((System.Drawing.Image)(resources.GetObject("btnCompra.Image")));
            this.btnCompra.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCompra.Location = new System.Drawing.Point(895, 66);
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(78, 57);
            this.btnCompra.TabIndex = 11;
            this.btnCompra.Text = "Compra";
            this.btnCompra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCompra.UseVisualStyleBackColor = false;
            this.btnCompra.Click += new System.EventHandler(this.btnCompra_Click);
            // 
            // btnVerCompras
            // 
            this.btnVerCompras.BackColor = System.Drawing.Color.White;
            this.btnVerCompras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerCompras.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnVerCompras.FlatAppearance.BorderSize = 0;
            this.btnVerCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerCompras.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCompras.Image = ((System.Drawing.Image)(resources.GetObject("btnVerCompras.Image")));
            this.btnVerCompras.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVerCompras.Location = new System.Drawing.Point(979, 66);
            this.btnVerCompras.Name = "btnVerCompras";
            this.btnVerCompras.Size = new System.Drawing.Size(95, 57);
            this.btnVerCompras.TabIndex = 10;
            this.btnVerCompras.Text = "Ver Compras";
            this.btnVerCompras.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVerCompras.UseVisualStyleBackColor = false;
            this.btnVerCompras.Click += new System.EventHandler(this.btnVerCompras_Click);
            // 
            // btnNuevoPromo
            // 
            this.btnNuevoPromo.BackColor = System.Drawing.Color.White;
            this.btnNuevoPromo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoPromo.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnNuevoPromo.FlatAppearance.BorderSize = 0;
            this.btnNuevoPromo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoPromo.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoPromo.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoPromo.Image")));
            this.btnNuevoPromo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNuevoPromo.Location = new System.Drawing.Point(484, 66);
            this.btnNuevoPromo.Name = "btnNuevoPromo";
            this.btnNuevoPromo.Size = new System.Drawing.Size(95, 57);
            this.btnNuevoPromo.TabIndex = 12;
            this.btnNuevoPromo.Text = "Nueva promo";
            this.btnNuevoPromo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNuevoPromo.UseVisualStyleBackColor = true;
            this.btnNuevoPromo.Click += new System.EventHandler(this.btnNuevoPromo_Click);
            // 
            // btnVerVentas
            // 
            this.btnVerVentas.BackColor = System.Drawing.Color.White;
            this.btnVerVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerVentas.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnVerVentas.FlatAppearance.BorderSize = 0;
            this.btnVerVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerVentas.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerVentas.Image = ((System.Drawing.Image)(resources.GetObject("btnVerVentas.Image")));
            this.btnVerVentas.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVerVentas.Location = new System.Drawing.Point(196, 66);
            this.btnVerVentas.Name = "btnVerVentas";
            this.btnVerVentas.Size = new System.Drawing.Size(87, 57);
            this.btnVerVentas.TabIndex = 19;
            this.btnVerVentas.Text = "Ventas";
            this.btnVerVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVerVentas.UseVisualStyleBackColor = false;
            this.btnVerVentas.Click += new System.EventHandler(this.btnVerVentas_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.White;
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnClientes.Image")));
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnClientes.Location = new System.Drawing.Point(686, 66);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(95, 57);
            this.btnClientes.TabIndex = 18;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnVerPromos
            // 
            this.btnVerPromos.BackColor = System.Drawing.Color.White;
            this.btnVerPromos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerPromos.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnVerPromos.FlatAppearance.BorderSize = 0;
            this.btnVerPromos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerPromos.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerPromos.Image = ((System.Drawing.Image)(resources.GetObject("btnVerPromos.Image")));
            this.btnVerPromos.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnVerPromos.Location = new System.Drawing.Point(585, 66);
            this.btnVerPromos.Name = "btnVerPromos";
            this.btnVerPromos.Size = new System.Drawing.Size(95, 57);
            this.btnVerPromos.TabIndex = 13;
            this.btnVerPromos.Text = "Ver Promos";
            this.btnVerPromos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVerPromos.UseVisualStyleBackColor = false;
            this.btnVerPromos.Click += new System.EventHandler(this.btnVerPromos_Click);
            // 
            // btnProveedores
            // 
            this.btnProveedores.BackColor = System.Drawing.Color.White;
            this.btnProveedores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedores.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnProveedores.FlatAppearance.BorderSize = 0;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedores.Image = ((System.Drawing.Image)(resources.GetObject("btnProveedores.Image")));
            this.btnProveedores.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnProveedores.Location = new System.Drawing.Point(787, 66);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(102, 57);
            this.btnProveedores.TabIndex = 14;
            this.btnProveedores.Text = "Proveedores";
            this.btnProveedores.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1431, 175);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(262, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // timerMenu
            // 
            this.timerMenu.Interval = 50;
            this.timerMenu.Tick += new System.EventHandler(this.timerMenu_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmMenus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1362, 745);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlFrm);
            this.MaximumSize = new System.Drawing.Size(1400, 800);
            this.Name = "frmMenus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "America Sativa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMenu_FormClosed);
            this.Load += new System.EventHandler(this.frmMenus_Load);
            this.pnlFrm.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlFrm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnIzquierda;
        private System.Windows.Forms.Button btnCronograma;
        private System.Windows.Forms.Button btnTareasMateriales;
        private System.Windows.Forms.Button btnAvisos;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnAgregarArtic;
        private System.Windows.Forms.Button btnInicio2;
        private System.Windows.Forms.Button btnCompra;
        private System.Windows.Forms.Button btnVerCompras;
        private System.Windows.Forms.Button btnNuevoPromo;
        private System.Windows.Forms.Button btnVerVentas;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnVerPromos;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Timer timerMenu;
        private System.Windows.Forms.Button btnCuentaCorriente;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnGestionStock;
        private System.Windows.Forms.Button btnBanco;
        private System.Windows.Forms.Button btnDerecha;
    }
}

