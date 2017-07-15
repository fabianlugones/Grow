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
    public partial class frmMensajes : Form
    {
        public frmMensajes()
        {
            InitializeComponent();
      
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuariosM.AutoGenerateColumns = false;
            dgvAvisos.AutoGenerateColumns = false;
            Listar();
        }
        private Usuarios u;
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (txtIdM.Text == "") return;

            if (txtMensajeM.Text == "") { MessageBox.Show("No se puede generar un aviso sin mensaje", "Adverencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Convert.ToInt32(nudHoraActiva2.Text) < 6 || Convert.ToInt32(nudHoraActiva2.Text) > 18)
            { MessageBox.Show("La hora de activacion de los avisos es de 6 a 18 ", "Adverencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (dtpFechaActivaM.Value == DateTime.Now.Date)
            {
                if (Convert.ToInt32(nudHoraActiva2.Text) < DateTime.Now.Hour)
                {
                    MessageBox.Show("No puede elegir una hora de activación menor a la actual ", "Adverencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
            }

            Avisos av = new Avisos();
            av.Emisor = u.Nombre;
            av.Id_usuario_emisor = u.Id_usuario;
            av.Fecha_activa = dtpFechaActivaM.Value;
            av.Hora_activa = Convert.ToInt32(nudHoraActiva2.Text);
            av.Aviso = txtMensajeM.Text;
            av.Id_aviso = Convert.ToInt32(txtIdM.Text);
            List<Avisos_usuarios> us_aList = new List<Avisos_usuarios>();
            bool hay_us = false;
            foreach (DataGridViewRow row in dgvUsuariosM.Rows)
            {
                Avisos_usuarios a_u = new Avisos_usuarios();
                a_u.Id_usuario = Convert.ToInt32(row.Cells["id_us"].Value);
                if (true == Convert.ToBoolean(row.Cells["checc"].Value))
                {
                    us_aList.Add(a_u);
                    hay_us = true;
                }
            }
            if (hay_us == false)
            {
                MessageBox.Show("Debe elegir almenos un usuario receptor del mensaje ", "Adverencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }

            AvisosAdap avAdap = new AvisosAdap();
            avAdap.UpdateAviso(av, us_aList, "M");
            List<Usuarios> us = new List<Usuarios>();
            dgvUsuariosM.DataSource = us;
            MessageBox.Show("Se registró correctamenete el aviso para el día: " + dtpFechaActiva.Text, "Registro", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            txtMensajeM.Clear();
            nudHoraActiva2.Value = 0;
            dtpFechaActivaM.Value = DateTime.Now;
            txtIdM.Clear();
            Listar();
        }
        public void Listar()
        {

            UsuariosAdap us = new UsuariosAdap();
            dgvUsuarios.DataSource = us.GetUsuarios();
            
            AutenticacionAdap autAdap = new AutenticacionAdap ();
           
            u = autAdap.UsuarioLogueado();

            AvisosAdap avAdap = new AvisosAdap();
            dgvAvisos.DataSource= avAdap.GetAvisosDeUsuarios(u.Id_usuario);
        
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtMensaje.Text == "") { MessageBox.Show("No se puede generar un aviso sin mensaje", "Adverencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Convert.ToInt32(nudHoraActiva.Text) < 6 || Convert.ToInt32(nudHoraActiva.Text) > 20)
            { MessageBox.Show("La hora de activacion de los avisos es de 6 a 18 ", "Adverencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (dtpFechaActiva.Value == DateTime.Now.Date)
            {
                if (Convert.ToInt32(nudHoraActiva.Text) < DateTime.Now.Hour)
                { MessageBox.Show("No puede elegir una hora de activación menor a la actual ", "Adverencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
            }

            List<Avisos_usuarios> us_aList = new List<Avisos_usuarios>();
            bool hay_us = false ;
             foreach (DataGridViewRow row in dgvUsuarios.Rows)
            {
                Avisos_usuarios a_u = new Avisos_usuarios();
               a_u.Id_usuario = Convert.ToInt32(row.Cells["Id"].Value);
               if (true == Convert.ToBoolean(row.Cells["Check"].Value))
               {   us_aList.Add(a_u);
                   hay_us = true;
               }
            }
             if (hay_us == false)
             { MessageBox.Show("Debe elegir almenos un usuario receptor del mensaje ", "Adverencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
             }
            AutenticacionAdap aut = new AutenticacionAdap ();
            Usuarios u = new Usuarios ();
            u = aut.UsuarioLogueado();
             Avisos av = new Avisos ();
             av.Aviso = txtMensaje.Text;
             av.Hora_activa = Convert.ToInt32(nudHoraActiva.Text);
             av.Fecha_activa = Convert.ToDateTime(dtpFechaActiva.Text);
             av.Emisor = u.Nombre;
             av.Id_usuario_emisor = u.Id_usuario;
              AvisosAdap avadap = new AvisosAdap();
             avadap.Insertar(av, us_aList);

             MessageBox.Show("Se registró correctamenete el aviso para el día: " + dtpFechaActiva.Text, "Registro", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
             txtMensaje.Clear();
             dtpFechaActiva.Value = DateTime.Now;
             nudHoraActiva.Text = "0";
       
             Listar();





        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvAvisos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Avisos av = new Avisos();
                av = ((Clases.Avisos)this.dgvAvisos.SelectedRows[0].DataBoundItem);
                txtMensajeM.Text = av.Aviso;
                nudHoraActiva2.Value = av.Hora_activa;
                dtpFechaActivaM.Value = av.Fecha_activa;
                AvisosAdap avAdap = new AvisosAdap();
                dgvUsuariosM.DataSource = avAdap.GetUsuariosDeAviso(av.Id_aviso);
                txtIdM.Text = av.Id_aviso.ToString();
               
            }
            finally { }
        }

        private void btnBajaAviso_Click(object sender, EventArgs e)
        {
            if (txtIdM.Text == "") return;
            Avisos av = new Avisos();
            av.Id_aviso =Convert.ToInt32(txtIdM.Text);

            List<Avisos_usuarios> us_aList = new List<Avisos_usuarios>();
            
            AvisosAdap avAdap = new AvisosAdap();
            avAdap.UpdateAviso(av, us_aList, "E");

            MessageBox.Show("Se dio de baja exitosamente el aviso ","Baja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            txtIdM.Clear();
            txtMensajeM.Clear();
            nudHoraActiva2.Value = 0;
            dtpFechaActivaM.Value = DateTime.Now;

            List<Usuarios> us = new List<Usuarios>();
            dgvUsuariosM.DataSource = us;
            Listar();

        }

        private void dgvAvisos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
