namespace SinergiaApp
{
    partial class frmOrdenesDeCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenesDeCompra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gpFiltro = new System.Windows.Forms.GroupBox();
            this.cmbFiltroProveedor = new System.Windows.Forms.ComboBox();
            this.txtFiltroOrden = new System.Windows.Forms.TextBox();
            this.chbNumeroOrden = new System.Windows.Forms.CheckBox();
            this.chbHistoricas = new System.Windows.Forms.CheckBox();
            this.cmbEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.btnQuitarFiltros = new System.Windows.Forms.Button();
            this.chbEstado = new System.Windows.Forms.CheckBox();
            this.chbProveedor = new System.Windows.Forms.CheckBox();
            this.pnArticulos = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDeuda = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPagamos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbRealizarPago = new System.Windows.Forms.GroupBox();
            this.btnGasto = new System.Windows.Forms.Button();
            this.gpPago = new System.Windows.Forms.GroupBox();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.gpPagoCaja = new System.Windows.Forms.GroupBox();
            this.rbSiPagoCaja = new System.Windows.Forms.RadioButton();
            this.txtDeCaja = new System.Windows.Forms.TextBox();
            this.rbNoPagoCaja = new System.Windows.Forms.RadioButton();
            this.txtFormaDePago = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnComentarios = new System.Windows.Forms.Button();
            this.btnDarDeBaja = new System.Windows.Forms.Button();
            this.txtMoneda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumeroOrden = new System.Windows.Forms.TextBox();
            this.dgvOrdenDeCompra = new System.Windows.Forms.DataGridView();
            this.Idd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_unitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvOrdenesDeCompra = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Emisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Generada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estadoo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAgo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Deuda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoFavor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCredito = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDeudas = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gpFiltro.SuspendLayout();
            this.pnArticulos.SuspendLayout();
            this.gbRealizarPago.SuspendLayout();
            this.gpPago.SuspendLayout();
            this.gpPagoCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenDeCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesDeCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gpFiltro
            // 
            this.gpFiltro.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.gpFiltro.BackColor = System.Drawing.Color.White;
            this.gpFiltro.Controls.Add(this.cmbFiltroProveedor);
            this.gpFiltro.Controls.Add(this.txtFiltroOrden);
            this.gpFiltro.Controls.Add(this.chbNumeroOrden);
            this.gpFiltro.Controls.Add(this.chbHistoricas);
            this.gpFiltro.Controls.Add(this.cmbEstadoFiltro);
            this.gpFiltro.Controls.Add(this.btnQuitarFiltros);
            this.gpFiltro.Controls.Add(this.chbEstado);
            this.gpFiltro.Controls.Add(this.chbProveedor);
            this.gpFiltro.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpFiltro.Location = new System.Drawing.Point(2, -4);
            this.gpFiltro.Name = "gpFiltro";
            this.gpFiltro.Size = new System.Drawing.Size(1249, 37);
            this.gpFiltro.TabIndex = 53;
            this.gpFiltro.TabStop = false;
            this.gpFiltro.Text = "Filtros";
            // 
            // cmbFiltroProveedor
            // 
            this.cmbFiltroProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFiltroProveedor.Enabled = false;
            this.cmbFiltroProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFiltroProveedor.FormattingEnabled = true;
            this.cmbFiltroProveedor.Items.AddRange(new object[] {
            "cobrada",
            "deuda con banco",
            "deuda personal"});
            this.cmbFiltroProveedor.Location = new System.Drawing.Point(212, 10);
            this.cmbFiltroProveedor.Name = "cmbFiltroProveedor";
            this.cmbFiltroProveedor.Size = new System.Drawing.Size(112, 21);
            this.cmbFiltroProveedor.TabIndex = 67;
            this.cmbFiltroProveedor.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroProveedor_SelectedIndexChanged);
            // 
            // txtFiltroOrden
            // 
            this.txtFiltroOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFiltroOrden.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFiltroOrden.Enabled = false;
            this.txtFiltroOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltroOrden.Location = new System.Drawing.Point(795, 9);
            this.txtFiltroOrden.Name = "txtFiltroOrden";
            this.txtFiltroOrden.Size = new System.Drawing.Size(101, 20);
            this.txtFiltroOrden.TabIndex = 66;
            this.txtFiltroOrden.TextChanged += new System.EventHandler(this.txtFiltroOrden_TextChanged);
            // 
            // chbNumeroOrden
            // 
            this.chbNumeroOrden.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbNumeroOrden.AutoSize = true;
            this.chbNumeroOrden.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbNumeroOrden.Location = new System.Drawing.Point(652, 11);
            this.chbNumeroOrden.Name = "chbNumeroOrden";
            this.chbNumeroOrden.Size = new System.Drawing.Size(137, 18);
            this.chbNumeroOrden.TabIndex = 65;
            this.chbNumeroOrden.Text = "Número de orden:";
            this.chbNumeroOrden.UseVisualStyleBackColor = true;
            this.chbNumeroOrden.CheckedChanged += new System.EventHandler(this.chbNumeroOrden_CheckedChanged);
            // 
            // chbHistoricas
            // 
            this.chbHistoricas.AutoSize = true;
            this.chbHistoricas.Location = new System.Drawing.Point(925, 10);
            this.chbHistoricas.Name = "chbHistoricas";
            this.chbHistoricas.Size = new System.Drawing.Size(112, 18);
            this.chbHistoricas.TabIndex = 64;
            this.chbHistoricas.Text = "Ver Historicas";
            this.chbHistoricas.UseVisualStyleBackColor = true;
            // 
            // cmbEstadoFiltro
            // 
            this.cmbEstadoFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbEstadoFiltro.Enabled = false;
            this.cmbEstadoFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstadoFiltro.FormattingEnabled = true;
            this.cmbEstadoFiltro.Items.AddRange(new object[] {
            "COMPRA CERRADA",
            "DEUDA CON PROVEEDOR",
            "CREDITO A FAVOR"});
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(488, 10);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(141, 21);
            this.cmbEstadoFiltro.TabIndex = 63;
            this.cmbEstadoFiltro.SelectedIndexChanged += new System.EventHandler(this.cmbEstadoFiltro_SelectedIndexChanged);
            // 
            // btnQuitarFiltros
            // 
            this.btnQuitarFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuitarFiltros.BackColor = System.Drawing.Color.White;
            this.btnQuitarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarFiltros.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarFiltros.Location = new System.Drawing.Point(1053, 8);
            this.btnQuitarFiltros.Name = "btnQuitarFiltros";
            this.btnQuitarFiltros.Size = new System.Drawing.Size(137, 24);
            this.btnQuitarFiltros.TabIndex = 61;
            this.btnQuitarFiltros.Text = "Quitar Filtros";
            this.btnQuitarFiltros.UseVisualStyleBackColor = false;
            this.btnQuitarFiltros.Click += new System.EventHandler(this.btnQuitarFiltros_Click);
            // 
            // chbEstado
            // 
            this.chbEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chbEstado.AutoSize = true;
            this.chbEstado.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbEstado.Location = new System.Drawing.Point(330, 11);
            this.chbEstado.Name = "chbEstado";
            this.chbEstado.Size = new System.Drawing.Size(152, 18);
            this.chbEstado.TabIndex = 58;
            this.chbEstado.Text = "Estado de la compra";
            this.chbEstado.UseVisualStyleBackColor = true;
            this.chbEstado.CheckedChanged += new System.EventHandler(this.chbEstado_CheckedChanged);
            // 
            // chbProveedor
            // 
            this.chbProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbProveedor.AutoSize = true;
            this.chbProveedor.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chbProveedor.Location = new System.Drawing.Point(0, 12);
            this.chbProveedor.Name = "chbProveedor";
            this.chbProveedor.Size = new System.Drawing.Size(213, 18);
            this.chbProveedor.TabIndex = 57;
            this.chbProveedor.Text = "Cuenta corriente proveedores:";
            this.chbProveedor.UseVisualStyleBackColor = true;
            this.chbProveedor.CheckedChanged += new System.EventHandler(this.chbProveedor_CheckedChanged);
            // 
            // pnArticulos
            // 
            this.pnArticulos.BackColor = System.Drawing.Color.White;
            this.pnArticulos.Controls.Add(this.button1);
            this.pnArticulos.Controls.Add(this.txtDeuda);
            this.pnArticulos.Controls.Add(this.label6);
            this.pnArticulos.Controls.Add(this.txtPagamos);
            this.pnArticulos.Controls.Add(this.label1);
            this.pnArticulos.Controls.Add(this.gbRealizarPago);
            this.pnArticulos.Controls.Add(this.btnComentarios);
            this.pnArticulos.Controls.Add(this.btnDarDeBaja);
            this.pnArticulos.Controls.Add(this.txtMoneda);
            this.pnArticulos.Controls.Add(this.label4);
            this.pnArticulos.Controls.Add(this.txtTotal);
            this.pnArticulos.Controls.Add(this.label5);
            this.pnArticulos.Controls.Add(this.txtNumeroOrden);
            this.pnArticulos.Controls.Add(this.dgvOrdenDeCompra);
            this.pnArticulos.Controls.Add(this.label2);
            this.pnArticulos.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnArticulos.Location = new System.Drawing.Point(12, 324);
            this.pnArticulos.Name = "pnArticulos";
            this.pnArticulos.Size = new System.Drawing.Size(1337, 351);
            this.pnArticulos.TabIndex = 67;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(479, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 39);
            this.button1.TabIndex = 108;
            this.button1.Text = "$ VER PAGOS $";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDeuda
            // 
            this.txtDeuda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeuda.Enabled = false;
            this.txtDeuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeuda.Location = new System.Drawing.Point(311, 22);
            this.txtDeuda.Name = "txtDeuda";
            this.txtDeuda.Size = new System.Drawing.Size(74, 15);
            this.txtDeuda.TabIndex = 107;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(311, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 14);
            this.label6.TabIndex = 106;
            this.label6.Text = "Debemos:";
            // 
            // txtPagamos
            // 
            this.txtPagamos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPagamos.Enabled = false;
            this.txtPagamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagamos.Location = new System.Drawing.Point(231, 22);
            this.txtPagamos.Name = "txtPagamos";
            this.txtPagamos.Size = new System.Drawing.Size(74, 15);
            this.txtPagamos.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(228, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 14);
            this.label1.TabIndex = 103;
            this.label1.Text = "Pagamos:";
            // 
            // gbRealizarPago
            // 
            this.gbRealizarPago.Controls.Add(this.btnGasto);
            this.gbRealizarPago.Controls.Add(this.gpPago);
            this.gbRealizarPago.Controls.Add(this.gpPagoCaja);
            this.gbRealizarPago.Controls.Add(this.txtFormaDePago);
            this.gbRealizarPago.Controls.Add(this.label20);
            this.gbRealizarPago.Enabled = false;
            this.gbRealizarPago.Location = new System.Drawing.Point(788, 13);
            this.gbRealizarPago.Name = "gbRealizarPago";
            this.gbRealizarPago.Size = new System.Drawing.Size(303, 253);
            this.gbRealizarPago.TabIndex = 102;
            this.gbRealizarPago.TabStop = false;
            this.gbRealizarPago.Text = "Realizar Pago";
            this.gbRealizarPago.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnGasto
            // 
            this.btnGasto.BackColor = System.Drawing.Color.White;
            this.btnGasto.Image = ((System.Drawing.Image)(resources.GetObject("btnGasto.Image")));
            this.btnGasto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGasto.Location = new System.Drawing.Point(149, 178);
            this.btnGasto.Name = "btnGasto";
            this.btnGasto.Size = new System.Drawing.Size(148, 44);
            this.btnGasto.TabIndex = 102;
            this.btnGasto.Text = "Realizar Pago";
            this.btnGasto.UseVisualStyleBackColor = false;
            this.btnGasto.Click += new System.EventHandler(this.btnGasto_Click);
            // 
            // gpPago
            // 
            this.gpPago.Controls.Add(this.txtPago);
            this.gpPago.Location = new System.Drawing.Point(10, 51);
            this.gpPago.Name = "gpPago";
            this.gpPago.Size = new System.Drawing.Size(287, 49);
            this.gpPago.TabIndex = 101;
            this.gpPago.TabStop = false;
            this.gpPago.Text = "Monto del pago:";
            this.gpPago.Visible = false;
            // 
            // txtPago
            // 
            this.txtPago.BackColor = System.Drawing.Color.White;
            this.txtPago.Enabled = false;
            this.txtPago.Location = new System.Drawing.Point(113, 20);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(117, 21);
            this.txtPago.TabIndex = 92;
            this.txtPago.TextChanged += new System.EventHandler(this.txtPago_TextChanged);
            // 
            // gpPagoCaja
            // 
            this.gpPagoCaja.Controls.Add(this.rbSiPagoCaja);
            this.gpPagoCaja.Controls.Add(this.txtDeCaja);
            this.gpPagoCaja.Controls.Add(this.rbNoPagoCaja);
            this.gpPagoCaja.Font = new System.Drawing.Font("Lucida Sans", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpPagoCaja.Location = new System.Drawing.Point(10, 106);
            this.gpPagoCaja.Name = "gpPagoCaja";
            this.gpPagoCaja.Size = new System.Drawing.Size(287, 66);
            this.gpPagoCaja.TabIndex = 100;
            this.gpPagoCaja.TabStop = false;
            this.gpPagoCaja.Text = "¿Se retiró dinero de caja en ese pago?";
            this.gpPagoCaja.Visible = false;
            // 
            // rbSiPagoCaja
            // 
            this.rbSiPagoCaja.AutoSize = true;
            this.rbSiPagoCaja.Location = new System.Drawing.Point(8, 35);
            this.rbSiPagoCaja.Name = "rbSiPagoCaja";
            this.rbSiPagoCaja.Size = new System.Drawing.Size(77, 15);
            this.rbSiPagoCaja.TabIndex = 96;
            this.rbSiPagoCaja.TabStop = true;
            this.rbSiPagoCaja.Text = "Si, se retiró:";
            this.rbSiPagoCaja.UseVisualStyleBackColor = true;
            this.rbSiPagoCaja.CheckedChanged += new System.EventHandler(this.rbSiPagoCaja_CheckedChanged);
            // 
            // txtDeCaja
            // 
            this.txtDeCaja.BackColor = System.Drawing.Color.Black;
            this.txtDeCaja.Enabled = false;
            this.txtDeCaja.Location = new System.Drawing.Point(113, 32);
            this.txtDeCaja.Name = "txtDeCaja";
            this.txtDeCaja.Size = new System.Drawing.Size(117, 18);
            this.txtDeCaja.TabIndex = 90;
            this.txtDeCaja.TextChanged += new System.EventHandler(this.txtDeCaja_TextChanged);
            // 
            // rbNoPagoCaja
            // 
            this.rbNoPagoCaja.AutoSize = true;
            this.rbNoPagoCaja.Location = new System.Drawing.Point(8, 16);
            this.rbNoPagoCaja.Name = "rbNoPagoCaja";
            this.rbNoPagoCaja.Size = new System.Drawing.Size(36, 15);
            this.rbNoPagoCaja.TabIndex = 95;
            this.rbNoPagoCaja.TabStop = true;
            this.rbNoPagoCaja.Text = "No";
            this.rbNoPagoCaja.UseVisualStyleBackColor = true;
            this.rbNoPagoCaja.CheckedChanged += new System.EventHandler(this.rbNoPagoCaja_CheckedChanged);
            // 
            // txtFormaDePago
            // 
            this.txtFormaDePago.FormattingEnabled = true;
            this.txtFormaDePago.Items.AddRange(new object[] {
            "EFECTIVO (CAJA)",
            "OTRAS FORMAS DE PAGO"});
            this.txtFormaDePago.Location = new System.Drawing.Point(114, 23);
            this.txtFormaDePago.Name = "txtFormaDePago";
            this.txtFormaDePago.Size = new System.Drawing.Size(183, 22);
            this.txtFormaDePago.TabIndex = 99;
            this.txtFormaDePago.SelectedIndexChanged += new System.EventHandler(this.txtFormaDePago_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(5, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 14);
            this.label20.TabIndex = 98;
            this.label20.Text = "Forma de pago:";
            // 
            // btnComentarios
            // 
            this.btnComentarios.BackColor = System.Drawing.Color.White;
            this.btnComentarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComentarios.Location = new System.Drawing.Point(558, 250);
            this.btnComentarios.Name = "btnComentarios";
            this.btnComentarios.Size = new System.Drawing.Size(203, 23);
            this.btnComentarios.TabIndex = 96;
            this.btnComentarios.Text = "Ver Comentarios";
            this.btnComentarios.UseVisualStyleBackColor = false;
            this.btnComentarios.Click += new System.EventHandler(this.btnComentarios_Click);
            // 
            // btnDarDeBaja
            // 
            this.btnDarDeBaja.BackColor = System.Drawing.Color.White;
            this.btnDarDeBaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDarDeBaja.FlatAppearance.BorderSize = 0;
            this.btnDarDeBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDarDeBaja.ForeColor = System.Drawing.Color.White;
            this.btnDarDeBaja.Image = ((System.Drawing.Image)(resources.GetObject("btnDarDeBaja.Image")));
            this.btnDarDeBaja.Location = new System.Drawing.Point(693, 3);
            this.btnDarDeBaja.Name = "btnDarDeBaja";
            this.btnDarDeBaja.Size = new System.Drawing.Size(68, 43);
            this.btnDarDeBaja.TabIndex = 95;
            this.toolTip1.SetToolTip(this.btnDarDeBaja, "Eliminar compra");
            this.btnDarDeBaja.UseVisualStyleBackColor = false;
            this.btnDarDeBaja.Click += new System.EventHandler(this.btnDarDeBaja_Click);
            // 
            // txtMoneda
            // 
            this.txtMoneda.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMoneda.Enabled = false;
            this.txtMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoneda.Location = new System.Drawing.Point(398, 22);
            this.txtMoneda.Name = "txtMoneda";
            this.txtMoneda.Size = new System.Drawing.Size(40, 15);
            this.txtMoneda.TabIndex = 93;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(395, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 15);
            this.label4.TabIndex = 92;
            this.label4.Text = "Moneda";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(148, 22);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(77, 15);
            this.txtTotal.TabIndex = 79;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(148, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 78;
            this.label5.Text = "Total:";
            // 
            // txtNumeroOrden
            // 
            this.txtNumeroOrden.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumeroOrden.Enabled = false;
            this.txtNumeroOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroOrden.Location = new System.Drawing.Point(17, 22);
            this.txtNumeroOrden.Name = "txtNumeroOrden";
            this.txtNumeroOrden.Size = new System.Drawing.Size(125, 15);
            this.txtNumeroOrden.TabIndex = 72;
            // 
            // dgvOrdenDeCompra
            // 
            this.dgvOrdenDeCompra.AllowUserToAddRows = false;
            this.dgvOrdenDeCompra.AllowUserToDeleteRows = false;
            this.dgvOrdenDeCompra.BackgroundColor = System.Drawing.Color.White;
            this.dgvOrdenDeCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenDeCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Idd,
            this.Nombre,
            this.Precio_unitario,
            this.Cantidad,
            this.IVA,
            this.Desc,
            this.Total});
            this.dgvOrdenDeCompra.Location = new System.Drawing.Point(6, 50);
            this.dgvOrdenDeCompra.Name = "dgvOrdenDeCompra";
            this.dgvOrdenDeCompra.ReadOnly = true;
            this.dgvOrdenDeCompra.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOrdenDeCompra.Size = new System.Drawing.Size(755, 194);
            this.dgvOrdenDeCompra.TabIndex = 69;
            this.dgvOrdenDeCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenDeCompra_CellContentClick);
            this.dgvOrdenDeCompra.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenDeCompra_CellContentDoubleClick);
            this.dgvOrdenDeCompra.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenDeCompra_CellDoubleClick);
            this.dgvOrdenDeCompra.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOrdenDeCompra_CellMouseDoubleClick);
            // 
            // Idd
            // 
            this.Idd.DataPropertyName = "Id_articulo";
            this.Idd.HeaderText = "ID interno";
            this.Idd.Name = "Idd";
            this.Idd.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.FillWeight = 225F;
            this.Nombre.HeaderText = "Nombre Articulo";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 225;
            // 
            // Precio_unitario
            // 
            this.Precio_unitario.DataPropertyName = "Precio_unitario";
            this.Precio_unitario.FillWeight = 90F;
            this.Precio_unitario.HeaderText = "Precio Unitario";
            this.Precio_unitario.Name = "Precio_unitario";
            this.Precio_unitario.ReadOnly = true;
            this.Precio_unitario.Width = 90;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // IVA
            // 
            this.IVA.DataPropertyName = "IVA";
            this.IVA.FillWeight = 45F;
            this.IVA.HeaderText = "IVA %";
            this.IVA.Name = "IVA";
            this.IVA.ReadOnly = true;
            this.IVA.Width = 45;
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
            this.Total.HeaderText = "Total ";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(14, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 14);
            this.label2.TabIndex = 45;
            this.label2.Text = "Número de compra:";
            // 
            // dgvOrdenesDeCompra
            // 
            this.dgvOrdenesDeCompra.AllowUserToAddRows = false;
            this.dgvOrdenesDeCompra.AllowUserToDeleteRows = false;
            this.dgvOrdenesDeCompra.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenesDeCompra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOrdenesDeCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrdenesDeCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Emisor,
            this.Generada,
            this.Estadoo,
            this.Costo,
            this.PAgo,
            this.Deuda,
            this.SaldoFavor});
            this.dgvOrdenesDeCompra.Location = new System.Drawing.Point(12, 39);
            this.dgvOrdenesDeCompra.Name = "dgvOrdenesDeCompra";
            this.dgvOrdenesDeCompra.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOrdenesDeCompra.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOrdenesDeCompra.RowHeadersWidth = 25;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvOrdenesDeCompra.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOrdenesDeCompra.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvOrdenesDeCompra.Size = new System.Drawing.Size(1142, 279);
            this.dgvOrdenesDeCompra.TabIndex = 45;
            this.dgvOrdenesDeCompra.RowsDefaultCellStyleChanged += new System.EventHandler(this.dgvOrdenesDeCompra_RowsDefaultCellStyleChanged);
            this.dgvOrdenesDeCompra.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenesDeCompra_CellClick);
            this.dgvOrdenesDeCompra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrdenesDeCompra_CellContentClick);
            this.dgvOrdenesDeCompra.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvOrdenesDeCompra_CellFormatting);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Numero";
            this.dataGridViewTextBoxColumn1.FillWeight = 75F;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Compra";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Proveedor";
            this.dataGridViewTextBoxColumn2.FillWeight = 150F;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Proveedor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // Emisor
            // 
            this.Emisor.DataPropertyName = "Emitido";
            this.Emisor.FillWeight = 150F;
            this.Emisor.Frozen = true;
            this.Emisor.HeaderText = "Emisor";
            this.Emisor.Name = "Emisor";
            this.Emisor.ReadOnly = true;
            this.Emisor.Width = 150;
            // 
            // Generada
            // 
            this.Generada.DataPropertyName = "FechaGeneracion";
            this.Generada.FillWeight = 150F;
            this.Generada.Frozen = true;
            this.Generada.HeaderText = "Generada";
            this.Generada.Name = "Generada";
            this.Generada.ReadOnly = true;
            this.Generada.Width = 150;
            // 
            // Estadoo
            // 
            this.Estadoo.DataPropertyName = "EstadoFinanciero";
            this.Estadoo.FillWeight = 200F;
            this.Estadoo.Frozen = true;
            this.Estadoo.HeaderText = "Estado";
            this.Estadoo.Name = "Estadoo";
            this.Estadoo.ReadOnly = true;
            this.Estadoo.Width = 200;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "CostoMoneda";
            this.Costo.Frozen = true;
            this.Costo.HeaderText = "Costo ($)";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            this.Costo.Width = 92;
            // 
            // PAgo
            // 
            this.PAgo.DataPropertyName = "Pago";
            this.PAgo.Frozen = true;
            this.PAgo.HeaderText = "Pagos realizados ($)";
            this.PAgo.Name = "PAgo";
            this.PAgo.ReadOnly = true;
            // 
            // Deuda
            // 
            this.Deuda.DataPropertyName = "Deuda";
            this.Deuda.Frozen = true;
            this.Deuda.HeaderText = "Deuda ($)";
            this.Deuda.Name = "Deuda";
            this.Deuda.ReadOnly = true;
            // 
            // SaldoFavor
            // 
            this.SaldoFavor.DataPropertyName = "SaldoAFavor";
            this.SaldoFavor.Frozen = true;
            this.SaldoFavor.HeaderText = "Saldo a favor ($)";
            this.SaldoFavor.Name = "SaldoFavor";
            this.SaldoFavor.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1160, 157);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 36);
            this.pictureBox1.TabIndex = 70;
            this.pictureBox1.TabStop = false;
            // 
            // lblCredito
            // 
            this.lblCredito.AutoSize = true;
            this.lblCredito.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredito.ForeColor = System.Drawing.Color.Black;
            this.lblCredito.Location = new System.Drawing.Point(1160, 224);
            this.lblCredito.Name = "lblCredito";
            this.lblCredito.Size = new System.Drawing.Size(111, 18);
            this.lblCredito.TabIndex = 69;
            this.lblCredito.Text = "Deuda Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(1160, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 68;
            this.label3.Text = "Creditos:";
            // 
            // lblDeudas
            // 
            this.lblDeudas.AutoSize = true;
            this.lblDeudas.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeudas.ForeColor = System.Drawing.Color.Black;
            this.lblDeudas.Location = new System.Drawing.Point(1160, 279);
            this.lblDeudas.Name = "lblDeudas";
            this.lblDeudas.Size = new System.Drawing.Size(111, 18);
            this.lblDeudas.TabIndex = 72;
            this.lblDeudas.Text = "Deuda Total:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(1160, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 18);
            this.label8.TabIndex = 71;
            this.label8.Text = "Deudas:";
            // 
            // frmOrdenesDeCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1313, 602);
            this.Controls.Add(this.lblDeudas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCredito);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pnArticulos);
            this.Controls.Add(this.gpFiltro);
            this.Controls.Add(this.dgvOrdenesDeCompra);
            this.Name = "frmOrdenesDeCompra";
            this.Text = "frmOrdenesDeCompra";
            this.Load += new System.EventHandler(this.frmOrdenesDeCompra_Load);
            this.gpFiltro.ResumeLayout(false);
            this.gpFiltro.PerformLayout();
            this.pnArticulos.ResumeLayout(false);
            this.pnArticulos.PerformLayout();
            this.gbRealizarPago.ResumeLayout(false);
            this.gbRealizarPago.PerformLayout();
            this.gpPago.ResumeLayout(false);
            this.gpPago.PerformLayout();
            this.gpPagoCaja.ResumeLayout(false);
            this.gpPagoCaja.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenDeCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrdenesDeCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpFiltro;
        private System.Windows.Forms.ComboBox cmbEstadoFiltro;
        private System.Windows.Forms.Button btnQuitarFiltros;
        private System.Windows.Forms.CheckBox chbEstado;
        private System.Windows.Forms.CheckBox chbProveedor;
        private System.Windows.Forms.Panel pnArticulos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNumeroOrden;
        private System.Windows.Forms.DataGridView dgvOrdenDeCompra;
        private System.Windows.Forms.DataGridView dgvOrdenesDeCompra;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMoneda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chbHistoricas;
        private System.Windows.Forms.TextBox txtFiltroOrden;
        private System.Windows.Forms.CheckBox chbNumeroOrden;
        private System.Windows.Forms.Button btnDarDeBaja;
        private System.Windows.Forms.Button btnComentarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_unitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn IVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Generada;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estadoo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAgo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Deuda;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoFavor;
        private System.Windows.Forms.GroupBox gpPago;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.GroupBox gpPagoCaja;
        private System.Windows.Forms.RadioButton rbSiPagoCaja;
        private System.Windows.Forms.TextBox txtDeCaja;
        private System.Windows.Forms.RadioButton rbNoPagoCaja;
        private System.Windows.Forms.ComboBox txtFormaDePago;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox gbRealizarPago;
        private System.Windows.Forms.Button btnGasto;
        private System.Windows.Forms.TextBox txtDeuda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPagamos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFiltroProveedor;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCredito;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDeudas;
        private System.Windows.Forms.Label label8;
    }
}