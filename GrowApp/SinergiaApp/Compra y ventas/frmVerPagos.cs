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
    public partial class frmVerPagos : Form
    {
        public frmVerPagos(OrdenDeCompra oc)
        {
            InitializeComponent();
            dgvVerPagos.AutoGenerateColumns = false;

            OrdenDeCompraAdap ocAdap = new OrdenDeCompraAdap();
            dgvVerPagos.DataSource = ocAdap.GetPagosOrden(oc.Numero);
            lblCosto.Text = "Costo: $" + oc.Costo.ToString();
            lblFecha.Text = "Fecha de compra: " + oc.FechaGeneracion.ToShortDateString();
            lblOrden.Text = "Número de compra: " + oc.Numero;
            lblProveedor.Text = "Proveedor: " + oc.Proveedor;

        }
    }
}
