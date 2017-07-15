using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SinergiaApp
{
    public partial class frmBarraDeProgreso : Form
    {
        public frmBarraDeProgreso(string carga)
        {
            InitializeComponent();
            timer1.Enabled = true;
            se_carga = carga;
            if (carga == "calculando precios" || carga == "calculando stock")
            {
                pictureBox1.ImageLocation = @"C:\Software\Recurso\caja.gif";
            }
            frmBarraDeProgreso.CheckForIllegalCrossThreadCalls = false;
        }
        private string se_carga;

        private int contados = 0;
        private string puntos = ".";

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (puntos.Length)
            {
                case 1: puntos = ".."; break;
                case 2: puntos = "..."; break;
                case 3: puntos = "...."; break;
                case 4: puntos = "....."; break;
                case 5: puntos = "."; break;

            }
            contados = contados + 1;
            if (se_carga == "calculando precios" || se_carga == "calculando stock")
            {
                lblMensaje.Text = se_carga + puntos;
            }

            else
            {
                lblMensaje.Text = "Cargando " + se_carga + puntos;
            }
            if (contados == 50) this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
