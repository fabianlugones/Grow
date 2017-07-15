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
    public partial class frmGestionStock : Form
    {
        public frmGestionStock()
        {
            InitializeComponent();
            dgvMovimientos.AutoGenerateColumns = false;
            Listar();
        }
        public List<GestionArticulos> gaList;
        public void Listar()
        {
            ArticuloAdap aa = new ArticuloAdap();
            gaList = aa.InformeGestionArticulos();
            dgvMovimientos.DataSource = gaList;

        }

        private void rbPositivo_CheckedChanged(object sender, EventArgs e)
        {
            ListarFiltroForm("+");
        }

        private void rbNegativo_CheckedChanged(object sender, EventArgs e)
        {
            ListarFiltroForm("-");

        }
        public void ListarFiltroForm(string signo)
        {
            List<GestionArticulos> gaFiltroList = new List<GestionArticulos>();

            foreach (GestionArticulos ga in gaList)
            {
                if (ga.Signo == Convert.ToChar(signo))
                {

                    gaFiltroList.Add(ga);
                }


            }
            dgvMovimientos.DataSource = gaFiltroList;
            PintarTabla();
        }



        private void chbTiempo_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTiempo.Checked == true)
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;

            }
            else
            {
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
                if (txtArticulo.Text == "")
                {
                    Listar();
                }
                else { ListarFiltroArt(); }
            }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            ListarFiltroArticuloTiempo();

        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            ListarFiltroArticuloTiempo();
        }

        private void txtArticulo_TextChanged(object sender, EventArgs e)
        {
            ListarFiltroArt();
        }

        private void chbColores_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvMovimientos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            PintarTabla();
        }
        public void PintarTabla()
        {
            int j = 0;
            if (chbColores.Checked == false)
            {

                foreach (DataGridViewRow row in dgvMovimientos.Rows)
                {
                    if ('-' == Convert.ToChar(row.Cells["Signo"].Value))
                    {
                        dgvMovimientos.Rows[j].DefaultCellStyle.BackColor = Color.OrangeRed;
                        dgvMovimientos.Rows[j].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        dgvMovimientos.Rows[j].DefaultCellStyle.BackColor = Color.GreenYellow;
                        dgvMovimientos.Rows[j].DefaultCellStyle.ForeColor = Color.Black;

                    }
                    j = j + 1;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvMovimientos.Rows)
                {
                    if ('-' == Convert.ToChar(row.Cells["Signo"].Value))
                    {
                        dgvMovimientos.Rows[j].DefaultCellStyle.BackColor = Color.White;
                        dgvMovimientos.Rows[j].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        dgvMovimientos.Rows[j].DefaultCellStyle.BackColor = Color.White;
                        dgvMovimientos.Rows[j].DefaultCellStyle.ForeColor = Color.Black;

                    }
                    j = j + 1;
                }

            }
        }

        public void ListarFiltroArt()
        {
            ArticuloAdap aa = new ArticuloAdap();
            gaList = aa.InformeGestionArticulosFiltroArticulo(txtArticulo.Text);
            dgvMovimientos.DataSource = gaList;
            if (rbNegativo.Checked == true)
            {
                ListarFiltroForm("-");
            }
            if (rbPositivo.Checked == true)
            {
                ListarFiltroForm("+");
            }

        }
        public void ListarFiltroArticuloTiempo()
        {
            ArticuloAdap aa = new ArticuloAdap();
            if (txtArticulo.Text == "")
            {
                gaList = aa.InformeGestionArticulosFiltroTiempo(dtpDesde.Value, dtpHasta.Value);
                dgvMovimientos.DataSource = gaList;
            }
            else
            {
                gaList = aa.InformeGestionArticulosFiltroArticuloTiempo(txtArticulo.Text, dtpDesde.Value, dtpHasta.Value);
                dgvMovimientos.DataSource = gaList;

            }

            if (rbNegativo.Checked == true)
            {
                ListarFiltroForm("-");
            }
            if (rbPositivo.Checked == true)
            {
                ListarFiltroForm("+");
            }
        }

        private void frmGestionStock_Load(object sender, EventArgs e)
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
