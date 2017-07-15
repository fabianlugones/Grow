using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datos;
using Clases;

namespace SinergiaApp
{
    public partial class frmUsuarios : Form
    {
        private int id_us;
        public frmUsuarios()
        {
            InitializeComponent();
            dgvPermisos.AutoGenerateColumns = false;
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsPerM.AutoGenerateColumns = false;
            Listar();

        }
        public void Listar()
        { 
        PermisosUsuariosAdap perAdap = new PermisosUsuariosAdap ();
        dgvPermisos.DataSource = perAdap.GetPermisos();

        UsuariosAdap usAdap = new UsuariosAdap();
        dgvUsuarios.DataSource=  usAdap.GetUsuarios();
        
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") { MessageBox.Show("Falta ingresar nombre y apellido" + "\r\n" + "No se pudo ingresar usuario"); return; }
            if (txtEmail.Text == "") { MessageBox.Show("Falta ingresar email" + "\r\n" + "No se pudo ingresar usuario"); return; }
            if (txtPass.Text == "") { MessageBox.Show("Falta ingresar la contraseña del email" + "\r\n" + "No se pudo ingresar usuario"); return; }
            if (cmbArea.Text == "") { MessageBox.Show("Falta ingresar área pertenenciente" + "\r\n" + "No se pudo ingresar usuario"); return; }
            if (txtContraseña.Text == "") { MessageBox.Show("Falta ingresar la contraseña de usuario" + "\r\n" + "No se pudo ingresar usuario"); return; }
            if (txtUsuario.Text == "") { MessageBox.Show("Falta ingresar el nombre de usuario" + "\r\n" + "No se pudo ingresar usuario"); return; }
            UsuariosAdap usAdap = new UsuariosAdap ();
            Usuarios us = new Usuarios();
            us.Nombre = txtNombre.Text;
            us.Email = txtEmail.Text;
            us.Contraseña = txtContraseña.Text;
            us.Contraseña_email = txtPass.Text;
            us.Nombre_usuario = txtUsuario.Text;
            us.Tipo = cmbArea.Text;

            if (true == usAdap.SeRepiteNombreUS(us.Nombre_usuario))
            {MessageBox.Show("Ya existe nombre de usuario, pruebe con otro" + "\r\n" + "No se pudo agregar usuario"); return;
            }
            else
            { us.Id_usuario = usAdap.Insert(us); }


            List<PermisosUsuarios> pList = new List<PermisosUsuarios>();
            foreach (DataGridViewRow row in dgvPermisos.Rows)
            {
                PermisosUsuarios p = new PermisosUsuarios();
                p.Permiso = Convert.ToString(row.Cells["Permiso"].Value);
                p.Check = Convert.ToBoolean(row.Cells["Check"].Value);
                p.Id_usuario = us.Id_usuario;
                if (p.Check == true)
                { pList.Add(p);
                }
            }
            if (pList.Count != 0)
            {
                PermisosUsuariosAdap pAdap = new PermisosUsuariosAdap();
                pAdap.InsertPermisos(pList);    
            }

            MessageBox.Show("Se registro correctamente el usuario");
            Listar();
            txtContraseña.Clear();
            txtEmail.Clear();
            txtNombre.Clear();
            txtPass.Clear();
            txtUsuario.Clear();
            cmbArea.Text = "";
            Listar();


        }
        public void PintarChequeados()
        {

            int j = 0;
            foreach (DataGridViewRow row in dgvPermisos.Rows)
            {
                
                bool Estado = Convert.ToBoolean(row.Cells["Check"].Value);
                if (Estado == true)
                {
                    dgvPermisos.Rows[j].DefaultCellStyle.BackColor = Color.Blue;
                    dgvPermisos.Rows[j].DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    dgvPermisos.Rows[j].DefaultCellStyle.BackColor = Color.White;
                    dgvPermisos.Rows[j].DefaultCellStyle.ForeColor = Color.Black;
                }
                j = j + 1;


            }


        }

        private void dgvPermisos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PintarChequeados();
        }

        private void dgvPermisos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Usuarios us = new Usuarios();
                us = ((Clases.Usuarios)this.dgvUsuarios.SelectedRows[0].DataBoundItem);
                PermisosUsuariosAdap pUsAdap = new PermisosUsuariosAdap();
                dgvUsPerM.DataSource = pUsAdap.GetPermisosDeUsuarioModificar(us.Id_usuario);
                txtContraseñaEmailM.Text = us.Contraseña_email;
                txtContraseñaM.Text = us.Contraseña;
                txtEmailM.Text = us.Email;
                txtNombreM.Text = us.Nombre;
                txtNombreUsuarioM.Text = us.Nombre_usuario;
                cmbAreaM.Text = us.Tipo;
                id_us = us.Id_usuario;
            }
            catch { }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNombreM.Text == "") { MessageBox.Show("Falta ingresar nombre y apellido" + "\r\n" + "No se pudo guardar usuario"); return; }
            if (txtEmailM.Text == "") { MessageBox.Show("Falta ingresar email" + "\r\n" + "No se pudo guardar usuario"); return; }
            if (txtContraseñaM.Text == "") { MessageBox.Show("Falta ingresar la contraseña del email" + "\r\n" + "No se pudo guardar usuario"); return; }
            if (cmbAreaM.Text == "") { MessageBox.Show("Falta ingresar área pertenenciente" + "\r\n" + "No se pudo guardar usuario"); return; }
            if (txtContraseñaEmailM.Text == "") { MessageBox.Show("Falta ingresar la contraseña de usuario" + "\r\n" + "No se pudo guardar usuario"); return; }
 
            Usuarios us = new Usuarios();
            us.Email = txtEmailM.Text;
            us.Contraseña = txtContraseñaM.Text;
            us.Contraseña_email = txtContraseñaEmailM.Text;
            us.Nombre = txtNombreM.Text;
            us.Nombre_usuario = txtNombreUsuarioM.Text;
            us.Tipo = cmbAreaM.Text;
            UsuariosAdap usAda = new UsuariosAdap();
            usAda.Update(us);


            List<PermisosUsuarios> pList = new List<PermisosUsuarios>();
            foreach (DataGridViewRow row in dgvUsPerM.Rows)
            {
                PermisosUsuarios p = new PermisosUsuarios();
                p.Permiso = Convert.ToString(row.Cells["PermisoM"].Value);
                p.Check = Convert.ToBoolean(row.Cells["CheckM"].Value);
                p.Id_usuario = us.Id_usuario;
                if (p.Check == true)
                {
                    pList.Add(p);
                }
            }
  
            if (pList.Count != 0)
            {
                PermisosUsuariosAdap pAdap = new PermisosUsuariosAdap();
                pAdap.UpdatePermisosDeUsuarios(pList,id_us);
            }
            MessageBox.Show("Se modificó el ususario exitosamente");

            txtNombreUsuarioM.Clear();
            txtNombreM.Clear();
            txtContraseñaEmailM.Clear();
            txtContraseñaM.Clear();

            cmbAreaM.Text = "";
            txtEmailM.Clear();
            pList.Clear();
            dgvUsPerM.DataSource = pList;
            Listar();

        }


    }
}
