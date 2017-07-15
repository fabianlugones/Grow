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
    public partial class frmBandejaAvisos : Form
    {
        public frmBandejaAvisos()
        {
            InitializeComponent();
            dgvAvisos.AutoGenerateColumns = false;
            Listar();


        }
        private Usuarios u;
        public void Listar()
        {
            AutenticacionAdap aut = new AutenticacionAdap();
            u = aut.UsuarioLogueado();
            AvisosAdap avAdap = new AvisosAdap();
            dgvAvisos.DataSource = avAdap.RecibidosActivos(u.Id_usuario);
        
        
        }

        public void ListarTodos()
        {
            AvisosAdap avAdap = new AvisosAdap();
            dgvAvisos.DataSource = avAdap.RecibidosTodos(u.Id_usuario);
        
        
        }

        private void dgvAvisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Avisos av = new Avisos();
                av = ((Clases.Avisos)this.dgvAvisos.SelectedRows[0].DataBoundItem);
                txtEmisor.Text = av.Emisor;
                txtMensaje.Text = av.Aviso;
                textBox1.Text = av.Id_aviso.ToString();

            }
            catch { }
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            AvisosAdap avAdap = new AvisosAdap();
            avAdap.DesactivarUnAviso(Convert.ToInt32(textBox1.Text), u.Id_usuario);
            txtEmisor.Clear();
            txtMensaje.Clear();
            textBox1.Clear();
            MessageBox.Show("Se desactivo el mensaje con éxito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (chbVerMensajes.Checked == true)
            {
                ListarTodos();

            }
            else
            {
                Listar();


            }

            
        }

        private void chbVerMensajes_CheckedChanged(object sender, EventArgs e)
        {
            if (chbVerMensajes.Checked == true)
            {
                ListarTodos();
            
            }
            else 
            {
                Listar();
 

            }
        }


    }
}
