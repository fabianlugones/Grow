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
using Funciones;
namespace SinergiaApp
{
    public partial class frmVerVentas : Form
    {
        int id_caja;
        private Usuarios us;
        private List<PermisosUsuarios> perUs;

        private List<Venta_productos> vpList;
        public frmVerVentas()
        {
            InitializeComponent();
            dgvVenta.AutoGenerateColumns = false;
            dgvVentas.AutoGenerateColumns = false;
            dgvTopTen.AutoGenerateColumns = false;
            Listar();
            RegistradoraAdap regAdap = new RegistradoraAdap();
            id_caja = regAdap.GetIdCajaAbierta();
            Seguridad();
            Funcionalidades f = new Funcionalidades();
            if (f.TienePermiso(perUs, "Ver ventas historicas") == false)
            {
                gpFiltros.Visible = false;
            }
            else { gpFiltros.Visible = true; }
        }
        public void Seguridad()
        {
            AutenticacionAdap au = new AutenticacionAdap();
            us = au.UsuarioLogueado();
            PermisosUsuariosAdap puAdap = new PermisosUsuariosAdap();
            perUs = puAdap.GetPermisosDeUsuario(us.Id_usuario);
        
        }
        public void Listar()
        {
            VentasAdap vadap = new VentasAdap();
            dgvVentas.DataSource = vadap.GetAll();
            CalculoIndicadores();
            dgvTopTen.DataSource = vadap.TopTenDelAño();
            lblCantProdVendidos.Text = vadap.CantidadProductosVendidosAño().ToString() + " productos vendidos";
        
        }
        public string  comentario;

        public void CalculoIndicadores()
        {
            double total=0;
            double total_credito=0;
            double total_debito=0;
            double efectivo=0;
            int total_ventas = dgvVentas.RowCount;

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
               total = total + Convert.ToDouble(row.Cells["TotalVenta"].Value);

                if("EFECTIVO" == Convert.ToString(row.Cells["FormaPago"].Value)){ efectivo = efectivo + Convert.ToDouble(row.Cells["TotalVenta"].Value);}
                 if("CREDITO 1 CUOTA" == Convert.ToString(row.Cells["FormaPago"].Value)){ total_credito = total_credito + Convert.ToDouble(row.Cells["TotalVenta"].Value);}
                 if ("CREDITO 2 CUOTAS" == Convert.ToString(row.Cells["FormaPago"].Value)) { total_credito = total_credito + Convert.ToDouble(row.Cells["TotalVenta"].Value); }
                 if ("CREDITO 3 CUOTAS" == Convert.ToString(row.Cells["FormaPago"].Value)) { total_credito = total_credito + Convert.ToDouble(row.Cells["TotalVenta"].Value); }
                 if ("CREDITO 6 CUOTAS" == Convert.ToString(row.Cells["FormaPago"].Value)) { total_credito = total_credito + Convert.ToDouble(row.Cells["TotalVenta"].Value); }
                if("DEBITO" == Convert.ToString(row.Cells["FormaPago"].Value)){ total_debito = total_debito + Convert.ToDouble(row.Cells["TotalVenta"].Value);}
                 if("CUENTA CORRIENTE" == Convert.ToString(row.Cells["FormaPago"].Value)){ efectivo = efectivo + Convert.ToDouble(row.Cells["TotalVenta"].Value);}
               
            }

            lblEfectivo.Text ="$ "+ efectivo.ToString();
            lblDebito.Text ="$ "+ total_debito.ToString();
            lblCredito.Text ="$ "+ total_credito.ToString();
            lblGananciaVentas.Text ="$ "+ total.ToString();
            lblCantVentas.Text  =  total_ventas.ToString() + " ventas";


        
        
        }
        private void chbEstado_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chbEstado.Checked == true)
            {
                checkBox1.Checked = false;
              
                chbNumeroOrden.Checked = false;
                chbProveedor.Checked = false;
                txtFiltroOrden.Clear();
                txtFiltroOrden.Enabled = false;
                txtFiltroProveedor.Clear();
                txtFiltroProveedor.Enabled = false;
                cmbEstadoFiltro.Text = "";
                cmbEstadoFiltro.Enabled = true;
                // dateTimePicker1.Value = DateTime.Now;
                // dateTimePicker2.Value = DateTime.Now;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                txtFiltroOrden.Clear();
                txtFiltroOrden.Enabled = false;
            }
            else { cmbEstadoFiltro.Text="" ; cmbEstadoFiltro.Enabled = false; }

        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Venta v = new Venta();
                v = ((Clases.Venta)this.dgvVentas.SelectedRows[0].DataBoundItem);
                comentario = v.Comentario;
                txtTotal.Text = v.Total.ToString();
                cmbEstado.Text = v.Estado;
                txtNumeroVenta.Text = v.Id_Venta;
                VentasAdap vAdap = new VentasAdap();
                vpList = vAdap.GetProductosDeUnaVenta(v.Id_Venta);
                
                dgvVenta.DataSource = vpList;
                txtFormaDePago.Text = v.FormaPago;
                if (v.Estado != "COBRADA")
                {
                    cmbEstado.Enabled = true;
                    btnGuardar.Enabled = true;
                  
                }
                else { cmbEstado.Enabled = false; btnGuardar.Enabled = false; }

                if (v.FormaPago == "CUENTA CORRIENTE")
                {   double deuda =vAdap.GetDeudaDeVentaCC(v.Id_Venta);
                    cmbEstado.Enabled = false;
                    if (deuda > 0)
                    {

                        lblCobroCuenta.Visible = true;
                        lblDeuda.Visible = true;
                        txtCobroCuenta.Visible = true;
                        txtDeuda.Visible = true;
                        txtDeuda.Text = deuda.ToString();
                        lblPesoDeuda.Visible = true;

                    }

                }
                else 
                {
                    lblPesoDeuda.Visible = false;
                    lblCobroCuenta.Visible = false;
                    lblDeuda.Visible = false;
                    txtCobroCuenta.Visible = false;
                    txtDeuda.Visible = false;
                
                }
         
                cmbEstado.Items.Clear();
                cmbEstado.Items.Add("COBRADA");

               
            }
            catch
            {


            }
            PintarTablas();
        }
        public void PintarTablas()
        {


            int j = 0;
            foreach (DataGridViewRow row in dgvVenta.Rows)
            {

                bool promo = Convert.ToBoolean(row.Cells["PorPromo"].Value);

                if (promo == true)
                {
                    dgvVenta.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                }
                else
                {

                    dgvVenta.Rows[j].DefaultCellStyle.BackColor = Color.White;
                }





                j = j + 1;

            }






        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNumeroVenta.Text == "") return;
         
            Venta vt = new Venta();
            vt.Id_Venta = txtNumeroVenta.Text;
            vt.Estado = cmbEstado.Text;
            VentasAdap vadap = new VentasAdap();

            if (txtFormaDePago.Text == "CUENTA CORRIENTE")
            {
                if (txtCobroCuenta.Text == "")
                {

                    MessageBox.Show("Debe ingresar un monto de pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                }
                else
                {
                    try
                    {
                        double monto = Convert.ToDouble(txtCobroCuenta.Text);
                        if (monto == Convert.ToDouble(txtDeuda.Text))
                        {

                            Venta_pagos vpag = new Venta_pagos();
                            vpag.Id_Venta = vt.Id_Venta;
                            vpag.FechaPago = DateTime.Now;
                            vpag.Pago = monto;
                            vpag.Hora = DateTime.Now.Hour;

                            vadap.InsertPagoVenta(vpag);
                            vadap.UpdateEstadoVenta(vt.Id_Venta, "COBRADA");
                            MessageBox.Show("Se ha registrado el pago y cerrado la venta", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            if (monto > Convert.ToDouble(txtDeuda.Text))
                            {
                                MessageBox.Show("No puede registrar un pago mayor que la deuda", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
                            }
                            else
                            {

                                Venta_pagos vpago = new Venta_pagos();
                                vpago.Id_Venta = vt.Id_Venta;
                                vpago.FechaPago = DateTime.Now;
                                vpago.Pago = monto;
                                vpago.Hora = DateTime.Now.Hour;

                                vadap.InsertPagoVenta(vpago);

                                MessageBox.Show("Se ha registrado el pago exitosamente. Deuda actual: $" + (Convert.ToDouble(txtDeuda.Text) - monto).ToString(), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }


                        }
                    }
                    catch
                    {
                        MessageBox.Show("Debe ingresar un número entero o un decimal separado por coma para el monto del pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                    }


                }
            }
            else 
            {
                vadap.UpdateEstadoVenta(vt.Id_Venta, "COBRADA");
                MessageBox.Show("Se cerrado la venta exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            
            }

        

          

            dgvVenta.DataSource = null;
            cmbEstado.Text = "";
            txtNumeroVenta.Clear();
            lblCobroCuenta.Visible = false;
            lblDeuda.Visible = false;
            txtCobroCuenta.Visible = false;
            txtDeuda.Visible = false;
            lblPesoDeuda.Visible = false;
            txtDeuda.Clear();
            txtCobroCuenta.Clear();
            Listar();

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFiltroProveedor_TextChanged(object sender, EventArgs e)
        {
            VentasAdap va = new VentasAdap();
            dgvVentas.DataSource = va.GetFiltroCliente(txtFiltroProveedor.Text);
            CalculoIndicadores();
            dgvTopTen.DataSource = va.TopTenFiltroCliente(txtFiltroProveedor.Text);
            lblCantProdVendidos.Text = va.CantidadProductosFiltroCliente(txtFiltroProveedor.Text).ToString()+ " productos vendidos";
        }

        private void cmbEstadoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            VentasAdap va = new VentasAdap();
            dgvVentas.DataSource = va.GetFiltroEstado(cmbEstadoFiltro.Text);
            CalculoIndicadores();
            dgvTopTen.DataSource = va.TopTenFiltroEstado(cmbEstadoFiltro.Text);
            lblCantProdVendidos.Text = va.CantidadProductosFiltroEstado(cmbEstadoFiltro.Text).ToString() + " productos vendidos";
        }

        private void txtFiltroOrden_TextChanged(object sender, EventArgs e)
        {
            VentasAdap va = new VentasAdap();
            dgvVentas.DataSource = va.GetFiltroID(txtFiltroOrden.Text);
            CalculoIndicadores();
            dgvTopTen.DataSource = va.TopTenFiltroVenta(txtFiltroOrden.Text);
            lblCantProdVendidos.Text = va.CantidadProductosVendidosVenta(txtFiltroOrden.Text).ToString() + " productos vendidos";
        }

        private void chbProveedor_CheckedChanged(object sender, EventArgs e)
        {
           

            if (chbProveedor.Checked == true)
            {
                checkBox1.Checked = false;
                chbEstado.Checked = false;
                chbNumeroOrden.Checked = false;

                txtFiltroOrden.Clear();
                txtFiltroOrden.Enabled = false;
                txtFiltroProveedor.Clear();
                txtFiltroProveedor.Enabled = true;
                cmbEstadoFiltro.Text = "";
                cmbEstadoFiltro.Enabled = false;
                // dateTimePicker1.Value = DateTime.Now;
                // dateTimePicker2.Value = DateTime.Now;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                txtFiltroOrden.Clear();
                txtFiltroOrden.Enabled = false;
            }
            else { txtFiltroProveedor.Text = ""; txtFiltroProveedor.Enabled = false; }
        }

        private void chbNumeroOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNumeroOrden.Checked == true)
            {
                checkBox1.Checked = false;
                chbProveedor.Checked = false;
                chbEstado.Checked = false;
                //  chbNumeroOrden.Checked = false;
                // txtFiltroOrden.Clear();
                //txtFiltroOrden.Enabled = false;
                txtFiltroProveedor.Clear();
                txtFiltroProveedor.Enabled = false;
                cmbEstadoFiltro.Text = "";
                cmbEstadoFiltro.Enabled = false;
                // dateTimePicker1.Value = DateTime.Now;
                // dateTimePicker2.Value = DateTime.Now;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                txtFiltroOrden.Clear();
                txtFiltroOrden.Enabled = true;
            }
            else {

                txtFiltroOrden.Text = "";
                txtFiltroOrden.Enabled = false;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                // checkBox1.Checked = false;
                chbProveedor.Checked = false;
                chbEstado.Checked = false;
                chbNumeroOrden.Checked = false;
                txtFiltroOrden.Clear();
                txtFiltroOrden.Enabled = false;
                txtFiltroProveedor.Clear();
                txtFiltroProveedor.Enabled = false;
                cmbEstadoFiltro.Text = "";
                cmbEstadoFiltro.Enabled = false;

                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
             
            }
            else { dateTimePicker1.Enabled = false; dateTimePicker2.Enabled = false; }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            VentasAdap va = new VentasAdap();
            dgvVentas.DataSource = va.GetFiltroTiempo(dateTimePicker1.Value, dateTimePicker2.Value);
            CalculoIndicadores();
            dgvTopTen.DataSource = va.TopTenFiltroFecha(dateTimePicker1.Value, dateTimePicker2.Value);
            lblCantProdVendidos.Text = va.CantidadProductosFiltroFecha(dateTimePicker1.Value,dateTimePicker2.Value).ToString() + " productos vendidos";
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            VentasAdap va = new VentasAdap();
            dgvVentas.DataSource = va.GetFiltroTiempo(dateTimePicker1.Value, dateTimePicker2.Value);
            CalculoIndicadores();
            dgvTopTen.DataSource = va.TopTenFiltroFecha(dateTimePicker1.Value, dateTimePicker2.Value);
            lblCantProdVendidos.Text = va.CantidadProductosFiltroFecha(dateTimePicker1.Value, dateTimePicker2.Value).ToString() + " productos vendidos";
        }

        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            if (txtNumeroVenta.Text == "") return;
          
          
            
            DialogResult dialogResult = MessageBox.Show("Desea dar de baja la venta?", "Baja", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {

                VentasAdap vadap = new VentasAdap();
                if (vadap.SePuedeDarDeBaja(id_caja, txtNumeroVenta.Text) == false)
                {
                    MessageBox.Show("No se puede dar de baja la venta, tiene cobros registrados en caja que no es la actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return;
                }
                
                vadap.EliminarVenta(txtNumeroVenta.Text);
                Articulo_Costo_Adap acAdap = new Articulo_Costo_Adap();
                acAdap.EliminarCostoVenta(txtNumeroVenta.Text);

                if (txtFormaDePago.Text != "EFECTIVO" || txtFormaDePago.Text != "CUENTA CORRIENTE")
                {
                    MovimientosBancariosAdap movAdap = new MovimientosBancariosAdap();
                    movAdap.DeleteMovimiento(txtNumeroVenta.Text);
                }


                MessageBox.Show("Se dio de baja la venta exitosamente", "Baja", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ArticuloAdap aAdap = new ArticuloAdap(); 
                foreach (Venta_productos vp in vpList)
                {
                    aAdap.SumaStockk(vp.Cantidad, vp.Id_Articulo, "Retorno por eliminar venta: " + vp.Id_Venta, DateTime.Now);
                
                }
                
                dgvVenta.DataSource = null;
                cmbEstado.Text = "";
                txtNumeroVenta.Clear();
                lblCobroCuenta.Visible = false;
                lblDeuda.Visible = false;
                txtCobroCuenta.Visible = false;
                txtDeuda.Visible = false;
                lblPesoDeuda.Visible = false;
                txtDeuda.Clear();
                txtCobroCuenta.Clear();
                Listar();
            
            }
        }

        private void btnQuitarFiltros_Click(object sender, EventArgs e)
        {
            Listar();
            checkBox1.Checked = false;
            chbProveedor.Checked = false;
            chbEstado.Checked = false;
            //  chbNumeroOrden.Checked = false;
            // txtFiltroOrden.Clear();
            //txtFiltroOrden.Enabled = false;
            txtFiltroProveedor.Clear();
            txtFiltroProveedor.Enabled = false;
            cmbEstadoFiltro.Text = "";
            cmbEstadoFiltro.Enabled = false;
            // dateTimePicker1.Value = DateTime.Now;
            // dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            txtFiltroOrden.Clear();
            txtFiltroOrden.Enabled = false;
            chbNumeroOrden.Checked = false;
        }

        private void btnComentarios_Click(object sender, EventArgs e)
        {
            frmVerComentario ver = new frmVerComentario(txtNumeroVenta.Text,comentario,"venta");
            ver.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmVerVentas_Load(object sender, EventArgs e)
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
