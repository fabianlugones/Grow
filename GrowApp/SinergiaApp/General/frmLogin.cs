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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
       
        }

        private void btnIngrear_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text == "") return;
            if (textBox2.Text == "") return;
            string nom = textBox1.Text;
            string c = textBox2.Text;
            AutenticacionAdap au = new AutenticacionAdap();
            if (au.Logueo(nom, c) == true)
            {
                frmMenus frmMenu = new frmMenus();
                frmMenu.Show();
                this.Visible = false ;
            }
            else { MessageBox.Show("Error de autenticacion"); return; }
            
        }

        private void btnReinicio_Click(object sender, EventArgs e)
        {
            FuncionesAdapcs f = new FuncionesAdapcs();
            f.Reinicio();

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text != "")
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    
                    btnIngrear.PerformClick();
                }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text != "")
                if ((int)e.KeyChar == (int)Keys.Enter)
                {

                    textBox2.Focus();
                }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
