using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
using Datos;

namespace SinergiaApp
{
    public partial class frmProveedores : Form
    {
        public List<PermisosUsuarios> permisos = new List<PermisosUsuarios>();
        public Usuarios us;

        public frmProveedores()
        {
            InitializeComponent();
            dgvProveedores.AutoGenerateColumns = false;
            Listar();
            Seguridad();
        }
        public void Listar() 
        {
            ProveedorAdap prvAdap = new ProveedorAdap();
            dgvProveedores.DataSource = prvAdap.GetAll();
        

        }
        public void Seguridad()
        {
            AutenticacionAdap aut = new AutenticacionAdap();
            us = aut.UsuarioLogueado();
            PermisosUsuariosAdap padap = new PermisosUsuariosAdap();
            permisos = padap.GetPermisosDeUsuario(us.Id_usuario);

        }
        public bool PuedeCrear()
        {
            bool puede_generar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso.Trim() == "Crear proveedor")
                {

                    puede_generar = true;
                }
            }
            return puede_generar;


        }
        public bool Modificar()
        {
            bool puede_generar = false;
            foreach (PermisosUsuarios p in permisos)
            {
                if (p.Permiso.Trim() == "Modificar proveedores")
                {

                    puede_generar = true;
                }
            }
            return puede_generar;


        }


        private void btnIngresarProveedor_Click(object sender, EventArgs e)
        {
            if (PuedeCrear() == false) { MessageBox.Show("No tiene permisos para crear proveedores"); return; }

            if (txtRazonSocial.Text == "") { MessageBox.Show("Debe ingresar Razon Social. No se pudo registrar proveedor"); return; }
            if (cmbCategoria.Text == "") { MessageBox.Show("Debe ingresar una categoria de proveedor. No se pudo registrar proveedor"); return; }
            if (txtTelefono1.Text == "" && txtTelefono2.Text == "") { MessageBox.Show("Debe ingresar un telefono. No se pudo registrar proveedor"); return; }
            if (txtTelefono2.Text == "") { txtTelefono2.Text = "no registra"; }
            if (txtEmail.Text == "") { txtEmail.Text = "no registra"; }
            if (txtNombreContacto.Text == "") { txtNombreContacto.Text = "no registra"; }
            if (txtDireccion.Text == "") { txtDireccion.Text = "no registra"; }
            Proveedor prv = new Proveedor();
            prv.Razon_social = txtRazonSocial.Text;
            prv.Telefono1 = txtTelefono1.Text;
            prv.Telefono2 = txtTelefono2.Text;
            prv.Nombre_contacto = txtNombreContacto.Text;
            prv.Categoria = cmbCategoria.Text;
            prv.Email = txtEmail.Text;
            prv.Direccion = txtDireccion.Text;

            


            ProveedorAdap prvAdap = new ProveedorAdap();
            prvAdap.Insert(prv);
            MessageBox.Show("Se registro correctamente el proveedor");
            txtDireccion.Clear();
            txtEmail.Clear();
            txtNombreContacto.Clear();
            txtRazonSocial.Clear();
            txtTelefono1.Clear();
            txtTelefono2.Clear();
            cmbCategoria.Text = "";

            Listar();
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Proveedor prv = new Proveedor();
                prv = ((Clases.Proveedor)this.dgvProveedores.SelectedRows[0].DataBoundItem);
                txtDireccionM.Text = prv.Direccion;
                txtEmailM.Text = prv.Email;
                txtNombreContactoM.Text = prv.Nombre_contacto;
                txtRazonSocialM.Text = prv.Razon_social;
                txtTelefono1M.Text = prv.Telefono1;
                txtTelefono2M.Text = prv.Telefono2;
                cmbCategoriaM.Text = prv.Categoria;
            }
            catch { }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (Modificar() == false) { MessageBox.Show("No tiene permisos para modificar proveedores"); return; }
            if (cmbCategoriaM.Text == "") { MessageBox.Show("Debe ingresar una categoria de proveedor. No se pudo registrar proveedor"); return; }
            if (txtTelefono1M.Text == "" && txtTelefono2M.Text == "") { MessageBox.Show("Debe ingresar un telefono. No se pudo registrar proveedor"); return; }
            if (txtTelefono2M.Text == "") { txtTelefono2M.Text = "no registra"; }
            if (txtEmailM.Text == "") { txtEmailM.Text = "no registra"; }
            if (txtNombreContactoM.Text == "") { txtNombreContactoM.Text = "no registra"; }
            if (txtDireccionM.Text == "") { txtDireccionM.Text = "no registra"; }
            Proveedor prv = new Proveedor();
            prv.Razon_social = txtRazonSocialM.Text;
            prv.Telefono1 = txtTelefono1M.Text;
            prv.Telefono2 = txtTelefono2M.Text;
            prv.Nombre_contacto = txtNombreContactoM.Text;
            prv.Categoria = cmbCategoriaM.Text;
            prv.Email = txtEmailM.Text;
            prv.Direccion = txtDireccionM.Text;

            ProveedorAdap prvAdap = new ProveedorAdap();
            prvAdap.Update(prv);
            MessageBox.Show("Se modificó el proveedor con éxito");
            txtDireccionM.Clear();
            txtEmailM.Clear();
            txtNombreContactoM.Clear();
            txtRazonSocialM.Clear();
            txtTelefono1M.Clear();
            txtTelefono2M.Clear();
            cmbCategoriaM.Text = "";
            Listar();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            ProveedorAdap pvAdap = new ProveedorAdap();
            pvAdap.DarDeBaja(txtRazonSocialM.Text);
            MessageBox.Show("Se dio de baja el proveedor con éxito");
            txtDireccionM.Clear();
            txtEmailM.Clear();
            txtNombreContactoM.Clear();
            txtRazonSocialM.Clear();
            txtTelefono1M.Clear();
            txtTelefono2M.Clear();
            cmbCategoriaM.Text = "";
            Listar();
        }

      
    }
}
