namespace SinergiaApp
{
    partial class frmUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.permiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pass_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbAreaM = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtContraseñaEmailM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtEmailM = new System.Windows.Forms.TextBox();
            this.txtContraseñaM = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvUsPerM = new System.Windows.Forms.DataGridView();
            this.PermisoM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckM = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtNombreUsuarioM = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombreM = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsPerM)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtContraseña);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dgvPermisos);
            this.groupBox1.Controls.Add(this.btnIngresar);
            this.groupBox1.Controls.Add(this.cmbArea);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 607);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "NUEVO USUARIO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 14);
            this.label6.TabIndex = 13;
            this.label6.Text = "Contraseña:";
            // 
            // txtContraseña
            // 
            this.txtContraseña.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContraseña.Location = new System.Drawing.Point(183, 80);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(231, 21);
            this.txtContraseña.TabIndex = 3;
            // 
            // txtUsuario
            // 
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Location = new System.Drawing.Point(183, 54);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(231, 21);
            this.txtUsuario.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre de Usuario:";
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.permiso,
            this.Check});
            this.dgvPermisos.Location = new System.Drawing.Point(6, 192);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.Size = new System.Drawing.Size(490, 358);
            this.dgvPermisos.TabIndex = 9;
            this.dgvPermisos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPermisos_CellMouseClick);
            this.dgvPermisos.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPermisos_CellValueChanged);
            // 
            // permiso
            // 
            this.permiso.DataPropertyName = "Permiso";
            this.permiso.FillWeight = 375F;
            this.permiso.HeaderText = "Permiso";
            this.permiso.Name = "permiso";
            this.permiso.ReadOnly = true;
            this.permiso.Width = 375;
            // 
            // Check
            // 
            this.Check.DataPropertyName = "Check";
            this.Check.FillWeight = 55F;
            this.Check.HeaderText = "Incluir";
            this.Check.Name = "Check";
            this.Check.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Check.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Check.Width = 55;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.White;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.ForeColor = System.Drawing.Color.Black;
            this.btnIngresar.Image = ((System.Drawing.Image)(resources.GetObject("btnIngresar.Image")));
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresar.Location = new System.Drawing.Point(367, 556);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(123, 45);
            this.btnIngresar.TabIndex = 7;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Items.AddRange(new object[] {
            "GERENCIA",
            "COMPRAS",
            "PAGOS",
            "ADMINISTRACION",
            "TALLER"});
            this.cmbArea.Location = new System.Drawing.Point(183, 158);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(231, 22);
            this.cmbArea.TabIndex = 6;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(183, 130);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(231, 21);
            this.txtPass.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(183, 105);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(231, 21);
            this.txtEmail.TabIndex = 4;
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(183, 26);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(231, 21);
            this.txtNombre.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contraseña de email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Área perteneciente:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre y Apellido:";
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Nombre_usuario,
            this.Pass,
            this.Email,
            this.Pass_Email});
            this.dgvUsuarios.Location = new System.Drawing.Point(19, 20);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(544, 138);
            this.dgvUsuarios.TabIndex = 1;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Nombre_usuario
            // 
            this.Nombre_usuario.DataPropertyName = "Nombre_usuario";
            this.Nombre_usuario.HeaderText = "Usuario";
            this.Nombre_usuario.Name = "Nombre_usuario";
            this.Nombre_usuario.ReadOnly = true;
            // 
            // Pass
            // 
            this.Pass.DataPropertyName = "Contraseña";
            this.Pass.HeaderText = "Contraseña";
            this.Pass.Name = "Pass";
            this.Pass.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Pass_Email
            // 
            this.Pass_Email.DataPropertyName = "Contraseña_email";
            this.Pass_Email.HeaderText = "Pass Email";
            this.Pass_Email.Name = "Pass_Email";
            this.Pass_Email.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.cmbAreaM);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtContraseñaEmailM);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.txtEmailM);
            this.groupBox2.Controls.Add(this.txtContraseñaM);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.dgvUsPerM);
            this.groupBox2.Controls.Add(this.txtNombreUsuarioM);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dgvUsuarios);
            this.groupBox2.Controls.Add(this.txtNombreM);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(551, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(597, 600);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "VER / EDITAR USUARIOS";
            // 
            // cmbAreaM
            // 
            this.cmbAreaM.FormattingEnabled = true;
            this.cmbAreaM.Items.AddRange(new object[] {
            "GERENCIA",
            "COMPRAS",
            "PAGOS",
            "ADMINISTRACION",
            "TALLER"});
            this.cmbAreaM.Location = new System.Drawing.Point(148, 229);
            this.cmbAreaM.Name = "cmbAreaM";
            this.cmbAreaM.Size = new System.Drawing.Size(144, 22);
            this.cmbAreaM.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 14);
            this.label7.TabIndex = 25;
            this.label7.Text = "Contraseña:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 14);
            this.label11.TabIndex = 15;
            this.label11.Text = "Área perteneciente:";
            // 
            // txtContraseñaEmailM
            // 
            this.txtContraseñaEmailM.Location = new System.Drawing.Point(442, 229);
            this.txtContraseñaEmailM.Name = "txtContraseñaEmailM";
            this.txtContraseñaEmailM.Size = new System.Drawing.Size(146, 21);
            this.txtContraseñaEmailM.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(298, 233);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 14);
            this.label9.TabIndex = 20;
            this.label9.Text = "Contraseña de email:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(453, 549);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(77, 45);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtEmailM
            // 
            this.txtEmailM.Location = new System.Drawing.Point(442, 203);
            this.txtEmailM.Name = "txtEmailM";
            this.txtEmailM.Size = new System.Drawing.Size(146, 21);
            this.txtEmailM.TabIndex = 21;
            // 
            // txtContraseñaM
            // 
            this.txtContraseñaM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtContraseñaM.Location = new System.Drawing.Point(148, 203);
            this.txtContraseñaM.Name = "txtContraseñaM";
            this.txtContraseñaM.Size = new System.Drawing.Size(144, 21);
            this.txtContraseñaM.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(298, 207);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 14);
            this.label10.TabIndex = 17;
            this.label10.Text = "Email:";
            // 
            // dgvUsPerM
            // 
            this.dgvUsPerM.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsPerM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsPerM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PermisoM,
            this.CheckM});
            this.dgvUsPerM.Location = new System.Drawing.Point(40, 268);
            this.dgvUsPerM.Name = "dgvUsPerM";
            this.dgvUsPerM.Size = new System.Drawing.Size(490, 275);
            this.dgvUsPerM.TabIndex = 14;
            // 
            // PermisoM
            // 
            this.PermisoM.DataPropertyName = "Permiso";
            this.PermisoM.FillWeight = 375F;
            this.PermisoM.HeaderText = "Permiso";
            this.PermisoM.Name = "PermisoM";
            this.PermisoM.ReadOnly = true;
            this.PermisoM.Width = 375;
            // 
            // CheckM
            // 
            this.CheckM.DataPropertyName = "Check";
            this.CheckM.FillWeight = 55F;
            this.CheckM.HeaderText = "Incluir";
            this.CheckM.Name = "CheckM";
            this.CheckM.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.CheckM.Width = 55;
            // 
            // txtNombreUsuarioM
            // 
            this.txtNombreUsuarioM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreUsuarioM.Location = new System.Drawing.Point(148, 177);
            this.txtNombreUsuarioM.Name = "txtNombreUsuarioM";
            this.txtNombreUsuarioM.ReadOnly = true;
            this.txtNombreUsuarioM.Size = new System.Drawing.Size(144, 21);
            this.txtNombreUsuarioM.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 181);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 14);
            this.label8.TabIndex = 24;
            this.label8.Text = "Nombre de Usuario:";
            // 
            // txtNombreM
            // 
            this.txtNombreM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreM.Location = new System.Drawing.Point(442, 174);
            this.txtNombreM.Name = "txtNombreM";
            this.txtNombreM.Size = new System.Drawing.Size(146, 21);
            this.txtNombreM.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(292, 182);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(126, 14);
            this.label12.TabIndex = 14;
            this.label12.Text = "Nombre y Apellido:";
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1173, 702);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmUsuarios";
            this.Text = "frmUsuarios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsPerM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.DataGridViewTextBoxColumn permiso;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbAreaM;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtContraseñaEmailM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtEmailM;
        private System.Windows.Forms.TextBox txtContraseñaM;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvUsPerM;
        private System.Windows.Forms.TextBox txtNombreUsuarioM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pass_Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn PermisoM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckM;

    }
}