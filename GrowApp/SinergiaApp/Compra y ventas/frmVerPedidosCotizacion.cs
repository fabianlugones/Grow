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
    public partial class frmVerPedidosCotizacion : Form
    {
        public frmVerPedidosCotizacion()
        {
            InitializeComponent();
            dgvPedidos.AutoGenerateColumns = false;
            dgvOrdenDeCompra.AutoGenerateColumns = false;

            Listar();
        }
        public void Listar()
        {
            PedidoCotizacionAdap pedAdap = new PedidoCotizacionAdap();
            dgvPedidos.DataSource = pedAdap.GetPedidosCotizacion();

        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PedidoCotizacion ped = new PedidoCotizacion();
                ped = ((Clases.PedidoCotizacion)this.dgvPedidos.SelectedRows[0].DataBoundItem);
                txtComentarios.Text = ped.Detalle;
                txtNumeroDePedido.Text = ped.Numero.ToString();
                txtSolicitado.Text = ped.Solicitado;
                cmbPrioridad.Text = ped.Prioridad;
                cmbProveedor.Text = ped.Proveedor;
                //dtpPlazoEntrega.Text = ped.Plazo_entrega.ToString();

                PedidoCotizacion_ArticuloAdap pedArtAdap = new PedidoCotizacion_ArticuloAdap();
                dgvOrdenDeCompra.DataSource = pedArtAdap.GetListaArticulos(ped.Numero);
            }
            catch { }

        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            PedidoCotizacionAdap pedAdap = new PedidoCotizacionAdap();
            dgvPedidos.DataSource= pedAdap.GetPedidosCotizacionFiltro(txtFiltroProveedor.Text, Convert.ToDateTime(dtpDesde.Text), Convert.ToDateTime(dtpHasta.Text));

        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            PedidoCotizacionAdap pedAdap = new PedidoCotizacionAdap();
            dgvPedidos.DataSource = pedAdap.GetPedidosCotizacionFiltro(txtFiltroProveedor.Text, Convert.ToDateTime(dtpDesde.Text), Convert.ToDateTime(dtpHasta.Text));

        }

        private void txtFiltroProveedor_TextChanged(object sender, EventArgs e)
        {
            PedidoCotizacionAdap pedAdap = new PedidoCotizacionAdap();
            dgvPedidos.DataSource = pedAdap.GetPedidosCotizacionFiltro(txtFiltroProveedor.Text, Convert.ToDateTime(dtpDesde.Text), Convert.ToDateTime(dtpHasta.Text));

        }

        private void btnGenerarOrden_Click(object sender, EventArgs e)
        {
            PedidoCotizacion ped = new PedidoCotizacion();
           // ped.Plazo_entrega = Convert.ToDateTime(dtpPlazoEntrega.Text);
            ped.Prioridad = cmbPrioridad.Text;
            ped.Proveedor = cmbProveedor.Text;
            ped.Numero = txtNumeroDePedido.Text;
            PedidoCotizacionAdap pcAdap = new PedidoCotizacionAdap();
           
           

        }

     
    }
}
