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

namespace SinergiaApp.Compra_y_ventas
{
    public partial class frmDetalleVenta : Form
    {
        public frmDetalleVenta(string id_venta)
        {
            InitializeComponent();
            dgvVenta.AutoGenerateColumns = false;
            VentasAdap vAdap = new VentasAdap();

            dgvVenta.DataSource = vAdap.GetProductosDeUnaVenta(id_venta);
            
        }
    }
}
