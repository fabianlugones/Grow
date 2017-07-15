using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Clases;
namespace SinergiaApp
{
    public partial class frmCostosDeReposicion : Form
    {
        public frmCostosDeReposicion(List<Articulo_Costo> list)
        {
            InitializeComponent();
            dgvCostos.AutoGenerateColumns = false;
            dgvCostos.DataSource = list;
        }

        private void frmCostosDeReposicion_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
