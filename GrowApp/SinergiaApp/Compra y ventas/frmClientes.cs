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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            dgvProveedores.AutoGenerateColumns = false;
            Listar();
        }

        private void btnIngresarProveedor_Click(object sender, EventArgs e)
        {

            if (txtRazonSocial.Text == "") { MessageBox.Show("Debe ingresar Razon Social. No se pudo registrar proveedor"); return; }
            //if (cmbCategoria.Text == "") { MessageBox.Show("Debe ingresar una categoria de proveedor. No se pudo registrar proveedor"); return; }
           // if (txtTelefono1.Text == "" && txtTelefono2.Text == "") { MessageBox.Show("Debe ingresar un telefono. No se pudo registrar proveedor"); return; }
            if (txtDNI.Text == "") { MessageBox.Show("Debe ingresar DNI. No se pudo registrar proveedor"); return; }
            //if (txtTelefono2.Text == "") { txtTelefono2.Text = "no registra"; }
            if (txtEmail.Text == "") { txtEmail.Text = "no registra"; }
           // if (txtNombreContacto.Text == "") { txtNombreContacto.Text = "no registra"; }
           if (txtDireccion.Text == "") { txtDireccion.Text = "no registra"; }
            Clientes prv = new Clientes();
            prv.Razon_social = txtRazonSocial.Text;
            prv.Telefono1 = txtTelefono1.Text;
            prv.Telefono2 = txtTelefono2.Text;
            //prv.Nombre_contacto = txtNombreContacto.Text;
            //prv.Categoria = cmbCategoria.Text;
            prv.Email = txtEmail.Text;
            prv.Direccion = txtDireccion.Text;
                prv.DNI=txtDNI.Text;
            ClientesAdap prvAdap = new ClientesAdap();
            if (prvAdap.ExisteClientes(prv.DNI) == 0)
            {
                prvAdap.Insert(prv);
            }
            else { MessageBox.Show("Ya existe cliente con ese DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }

            MessageBox.Show("Se registro correctamente el cliente");
            txtDireccion.Clear();

            txtEmail.Clear();  
            txtRazonSocial.Clear();
            txtTelefono1.Clear();
            txtTelefono2.Clear();
           
            txtDNI.Clear();
            Listar();
        }
       public void Listar() 
        {
            ClientesAdap cl = new ClientesAdap();
            dgvProveedores.DataSource = cl.GetAll();
        

        }

       private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           try
           {
               Clientes prv = new Clientes();
               prv = ((Clases.Clientes)this.dgvProveedores.SelectedRows[0].DataBoundItem);
               txtDireccionM.Text = prv.Direccion;
               txtEmailM.Text = prv.Email;
            
               txtRazonSocialM.Text = prv.Razon_social;
               txtTelefono1M.Text = prv.Telefono1;
               txtTelefono2M.Text = prv.Telefono2;
               txtDniM.Text = prv.DNI;
           }
           catch { }
       }

       private void btnGuardarCambios_Click(object sender, EventArgs e)
       {
         
           if (txtTelefono1M.Text == "" && txtTelefono2M.Text == "") { MessageBox.Show("Debe ingresar un telefono. No se pudo registrar cliente","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning); return; }
           if (txtRazonSocialM.Text == "") { MessageBox.Show("Debe ingresar Nombre y apellido. No se pudo registrar cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
           if (txtTelefono2M.Text == "") { txtTelefono2M.Text = "no registra"; }
           if (txtEmailM.Text == "") { txtEmailM.Text = "no registra"; }
    
           if (txtDireccionM.Text == "") { txtDireccionM.Text = "no registra"; }
           Clientes prv = new Clientes();
           prv.Razon_social = txtRazonSocialM.Text;
           prv.Telefono1 = txtTelefono1M.Text;
           prv.Telefono2 = txtTelefono2M.Text;
     
           prv.Email = txtEmailM.Text;
           prv.Direccion = txtDireccionM.Text;
           prv.DNI = txtDniM.Text;
           ClientesAdap prvAdap = new ClientesAdap();
           prvAdap.Update(prv);
           MessageBox.Show("Se modificó el cliente con éxito","Éxito",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
           txtDireccionM.Clear();
           txtEmailM.Clear();
           txtDniM.Clear();
           txtRazonSocialM.Clear();
           txtTelefono1M.Clear();
           txtTelefono2M.Clear();
   
           Listar();
       }

       private void btnBaja_Click(object sender, EventArgs e)
       {
           if (txtDniM.Text == "") return;
           ClientesAdap cl = new ClientesAdap();
           cl.DarDeBaja(txtDniM.Text);
           MessageBox.Show("Se dio de baja correctamente el cliente", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
           txtDireccionM.Clear();
           txtEmailM.Clear();
           txtDniM.Clear();
           txtRazonSocialM.Clear();
           txtTelefono1M.Clear();
           txtTelefono2M.Clear();
   
           Listar();
       }

       private void txtTelefono2_TextChanged(object sender, EventArgs e)
       {

       }

       private void frmClientes_Load(object sender, EventArgs e)
       {
           foreach (Form a in Application.OpenForms)
           {
               if (a.Name == "frmBarraDeProgreso")
               {
                   a.Close();
                   return;
               }
           }
       }
    }
}
