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
using System.Text.RegularExpressions;
namespace SinergiaApp
{
    public partial class frmCuentaCorriente : Form
    {
        private List<CuentaCorriente>ccList;
        private List<CuentaCorriente>ccListFiltro;

        private List<CuentaCorriente>ccListHistorica;
        private List<CuentaCorriente>ccListFiltroHistorica;

        public frmCuentaCorriente()
        {
            InitializeComponent();
            dgvCuentaCorriente.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;

            Listar();
        }
        public void Listar()
        { 
          VentasAdap vadap = new VentasAdap ();
          ccListFiltroHistorica = ccListHistorica = vadap.GetAllCuentasCorrientes();
          dgvCuentaCorriente.DataSource=  ccListFiltro = ccList =   vadap.GetCuentasCorrientesAbiertas();
           
          
          Calculos();
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            VentasAdap va = new VentasAdap();
            if (chbCC.Checked == false)
            {
               
                   ccListFiltro = ccList.Where(u=> u.Nombre_cliente.Contains(txtFiltro.Text)).ToList();
                  dgvCuentaCorriente.DataSource = ccListFiltro;
                
            }
            else
            {
                ccListFiltroHistorica = ccListHistorica.Where(u=> u.Nombre_cliente.Contains(txtFiltro.Text)).ToList();
                  dgvCuentaCorriente.DataSource = ccListFiltroHistorica;
            }
                Calculos();
        }
        public void Calculos()
        {
             double deuda = 0;
            foreach (DataGridViewRow row in dgvCuentaCorriente.Rows)
            {
                OrdenDeCompra artic = new OrdenDeCompra();
                deuda = deuda + Convert.ToDouble(row.Cells["Debe"].Value);
                


            }
            lblDeuda.Text = "$ " + deuda.ToString();
 
        
        }

        private void dgvCuentaCorriente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CuentaCorriente c = new CuentaCorriente();
                c = ((Clases.CuentaCorriente)this.dgvCuentaCorriente.SelectedRows[0].DataBoundItem);
                txtCliente.Text = c.Nombre_cliente;
                txtDeuda.Text =  c.Deuda.ToString();
                txtIdVenta.Text = c.Id_Venta;
                txtTotalVenta.Text =  c.Total.ToString();
                if (c.Credito > 0)
                {
                    txtCobro.Enabled = false;
                }
                else { txtCobro.Enabled = true; }
                txtCredito.Text = c.Credito.ToString();
                ListarPagos(c.Id_Venta);
            }
            catch { }
            }

        private void btnCobrar_Click(object sender, EventArgs e)
        {
            RegistradoraAdap rAdap = new RegistradoraAdap();
            int id_reg = rAdap.GetIdCajaAbierta();
            if (false == rAdap.ExisteCajaAbierta())
            {
                MessageBox.Show("La caja registradora no ha sido abierta. Abrirla para poder realizar moviemientos." + "\r\n" + "No se pudo registrar el cobro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            if (txtIdVenta.Text == "")
            { MessageBox.Show("Debe seleccionar una venta para realizar el cobro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            double cobro = 0;
            try { cobro = Convert.ToDouble(txtCobro.Text); }
            catch { MessageBox.Show("El monto del cobro debe ser un número entero o u decimal separado por coma ','", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
            if (cobro > Convert.ToDouble(txtDeuda.Text))
            {
                MessageBox.Show("El monto del cobro no puede ser mayor que la deuda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
            }
          

            Venta_pagos vp = new Venta_pagos();
            vp.Pago = cobro;
            vp.FechaPago = DateTime.Now.Date;
            vp.Hora = DateTime.Now.Hour;
            vp.Id_Venta = txtIdVenta.Text;
            vp.Id_Caja = id_reg;
            if (chbEfectivo.Checked == true)
            {
                vp.FormaPago = "EFECTIVO";
            }
            else { vp.FormaPago = "OTRA FORMA DE PAGO"; }

            VentasAdap va = new VentasAdap();
              double deuda = Convert.ToDouble(txtDeuda.Text) - cobro; 
            va.InsertPagoVenta(vp);
            if (cobro < Convert.ToDouble(txtDeuda.Text))
            {
              
                MessageBox.Show("Se registró el cobro con éxito, deuda actual a la venta seleccionada: " + deuda, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
             
            }
            else {
                va.UpdateEstadoVenta(vp.Id_Venta, "COBRADA");
                MessageBox.Show("Se registró el cobro y se cerro la venta con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
                txtCobro.Clear();
                ListarPagos(txtIdVenta.Text);
                txtDeuda.Text =deuda.ToString();
                Listar();
        }
        public void ListarPagos( string id_venta)
        {
            VentasAdap va = new VentasAdap();
            dataGridView1.DataSource = va.GetPagosDeVenta(id_venta);
        
        }

        private void chbCC_CheckedChanged(object sender, EventArgs e)
        {
            if (chbCC.Checked == false)
            {
               
                   ccListFiltro = ccList.Where(u=> u.Nombre_cliente.Contains(txtFiltro.Text)).ToList();
                  dgvCuentaCorriente.DataSource = ccListFiltro;
                
            }
            else
            {
                ccListFiltroHistorica = ccListHistorica.Where(u=> u.Nombre_cliente.Contains(txtFiltro.Text)).ToList();
                  dgvCuentaCorriente.DataSource = ccListFiltroHistorica;
            }
        }

        private void frmCuentaCorriente_Load(object sender, EventArgs e)
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);


            excel.Cells[1, 1] = "Fecha del informe: " + DateTime.Now.Date.ToShortDateString();
            excel.Cells[3, 2] = "Fecha de venta";
            excel.Cells[3, 3] = "Código de venta";
            excel.Cells[3, 4] = "Cliente";
            excel.Cells[3, 5] = "Total de la venta ($)";
            excel.Cells[3, 6] = "Cobrado($)";
            excel.Cells[3, 7] = "Deuda($)";
            excel.Cells[3, 8] = "Credito($)";

            int filas = 3;
            List<CuentaCorriente> cclist = new List<CuentaCorriente>();
            if (chbCC.Checked == true) { cclist = ccListFiltroHistorica; } else { cclist = ccListFiltro; }
            foreach (CuentaCorriente cc in cclist)
            {
                filas++;

                excel.Cells[filas, 2] = cc.FechaVenta;
                excel.Cells[filas, 3] = cc.Id_Venta;
                excel.Cells[filas, 4] = cc.Nombre_cliente;
                excel.Cells[filas, 5] = cc.Total;
                excel.Cells[filas, 6] = cc.Cobro;
                excel.Cells[filas, 7] = cc.Deuda;
                excel.Cells[filas, 8] = cc.Credito;



                try
                {

                    string fileName = System.IO.Path.GetRandomFileName();
                    excel.Columns.AutoFit();
                    excel.Visible = true;


                    //   excel.Workbooks.Close();
                }
                catch { }
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (txtIdVenta.Text == "") return;
            Compra_y_ventas.frmDetalleVenta f = new Compra_y_ventas.frmDetalleVenta(txtIdVenta.Text);
            f.ShowDialog();
            
        }

        private void dgvCuentaCorriente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
