using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SinergiaApp
{
    public partial class frmPanelMensajes : Form
    {
        public frmPanelMensajes()
        {
            InitializeComponent();
        }
        frmMensajes _frmMensajes;
        frmBandejaAvisos _frmBandejaAvisos;

       
        private void btnEntrada_Click(object sender, EventArgs e)
        {
            pnlAvisos.Controls.Clear();
            _frmBandejaAvisos = new frmBandejaAvisos
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlAvisos.Controls.Add(_frmBandejaAvisos);
            _frmBandejaAvisos.Show();

        }

        private void btnEnviarMensajes_Click(object sender, EventArgs e)
        {
            pnlAvisos.Controls.Clear();
            _frmMensajes = new frmMensajes
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };
            pnlAvisos.Controls.Add(_frmMensajes);
            _frmMensajes.Show();
        }
    }
}
